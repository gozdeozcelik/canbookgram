using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Hashing
/// </summary>
public class Hashing
{

    public Hashing()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string HashPassword(string password) //Takes a string and creates hash of the string
    {
        //STEP 1 Create the salt value with a cryptographic PRNG:

        byte[] salt;
        new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

        //STEP 2 Create the Rfc2898DeriveBytes and get the hash value:

        var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, 10000);
        //Note: Depending on the performance requirements of your specific application, the value '10000' can be reduced. 
        //      A minimum value should be around 1000.
        byte[] hash = pbkdf2.GetBytes(20);

        //STEP 3 Combine the salt and password bytes for later use:

        byte[] hashBytes = new byte[36];
        System.Array.Copy(salt, 0, hashBytes, 0, 16);
        System.Array.Copy(hash, 0, hashBytes, 16, 20);

        //STEP 4 Turn the combined salt+hash into a string for storage

        string savedPasswordHash = System.Convert.ToBase64String(hashBytes);

        //STEP 5 Return hashed password (It will be 48 characters long)
        return savedPasswordHash;

    }

    public bool VerifyPassword(string password, string savedPasswordHash)
    {
        //STEP 6 Verify the user-entered password against a stored password

        /* Extract the bytes */
        byte[] hashBytes = System.Convert.FromBase64String(savedPasswordHash);
        /* Get the salt */
        byte[] salt = new byte[16];
        System.Array.Copy(hashBytes, 0, salt, 0, 16);
        /* Compute the hash on the password the user entered */
        var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbkdf2.GetBytes(20);
        /* Compare the results */
        for (int i = 0; i < 20; i++)
            if (hashBytes[i + 16] != hash[i])
                return false;
        return true;
    }
}