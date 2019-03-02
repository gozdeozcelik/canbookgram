using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        LoginService ls = new LoginService();
        Hashing h = new Hashing();
        // h.HashPassword
        string username = txtEmail.Text;
        string password = txtPassword.Text;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        Person[] personList = (from x in db.Person select x).ToArray();
        Person a = ls.isValidPerson(username, password);
        if (a != null)
        {
            for (int i = 0; i < personList.Length; i++)
            {
                //if (personList[i].Username == username && personList[i].Password == password && personList[i].isActive == true)
                //{

                Session["personInfo"] = a.FirstName;
                Session["personSurname"] = a.LastName;
                Session["personId"] = a.PersonId;

                Response.Redirect("Default.aspx");

                //}
            }
        }
        else
        {
            lblMesseage.Visible = true;
            lblMesseage.Text = "Please check your information";
        }


    }

}