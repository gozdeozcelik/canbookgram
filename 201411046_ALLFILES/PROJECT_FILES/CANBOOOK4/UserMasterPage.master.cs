using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        String lbl = Session["personInfo"].ToString();
        lbl= lbl+" "+ Session["personSurname"].ToString();
      

        lblName.Text = "Welcome " + lbl + "!";
    }
}
