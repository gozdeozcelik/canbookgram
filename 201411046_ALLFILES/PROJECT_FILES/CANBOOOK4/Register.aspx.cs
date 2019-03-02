using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        RegService rg = new RegService();
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        
        Person newSupporter = new Person();
        newSupporter.FirstName = txtboxName.Text;
        newSupporter.LastName = txtboxSurname.Text;
        newSupporter.Email = txtboxEmail.Text;
        newSupporter.BirthDate = Convert.ToDateTime(txtboxDate.Text);
        newSupporter.City = txtboxAddress.Text;

        newSupporter.Friend_num = 0;
        //HIDEYI SOR

        newSupporter.IsActive = true;
        newSupporter.Post_num = 0;
        newSupporter.Message_num = 0;
        newSupporter.Username = txtboxUsername.Text;
        newSupporter.Friend_num = 0;

   

        newSupporter.Password = rg.makePersonPassword(txtboxPass.Text);
        if (fuLogoUp.HasFile)
        {
            fuLogoUp.SaveAs(Server.MapPath("~/Logos/" + fuLogoUp.FileName));
        }
        newSupporter.Imagepath = "~/Logos/" + fuLogoUp.FileName;
        if (chcBox.Checked == true)
        {
            newSupporter.Hide = true;
        }
        else
        {
            newSupporter.Hide = false;
        }


        db.Person.Add(newSupporter);
        db.SaveChanges();
        Response.Redirect("Register.aspx");
    }



    protected void chcBox_CheckedChanged(object sender, EventArgs e)
    {

    }
}
