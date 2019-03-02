using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
public class LoginService : ILoginService
{
    public void DoWork()
    {
    }
    public Person isValidPerson(string username, string password)
    {
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        Hashing h = new Hashing();
        Person s = (from x in db.Person where x.Username == username && x.IsActive == true select x).SingleOrDefault();
        if (h.VerifyPassword(password, s.Password.ToString()))
        {
            return s;
        }
        else
            return null;

    }

}
