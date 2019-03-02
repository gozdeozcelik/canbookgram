using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BOOKGRAMEntities db = new BOOKGRAMEntities();
            String spt = Session["personId"].ToString();
            int supid = Convert.ToInt32(spt);
            Person[] teamList = (from x in db.Person where x.IsActive == true && x.PersonId == supid select x).ToArray();


            grdSupUpdate.DataSource = teamList;
            grdSupUpdate.DataBind();
        }
    }
    protected void grdSupUpdate_cancelingRows(object sender, GridViewCancelEditEventArgs e)
    {
        grdSupUpdate.EditIndex = -1;
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        Person[] teamList = (from x in db.Person where x.IsActive == true && x.PersonId == supid select x).ToArray();


        grdSupUpdate.DataSource = teamList;
        grdSupUpdate.DataBind();
    }



    protected void grdSupUpdate_editingRow(object sender, GridViewEditEventArgs e)
    {

        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        grdSupUpdate.EditIndex = e.NewEditIndex;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        Person[] teamList = (from x in db.Person where x.IsActive == true && x.PersonId == supid select x).ToArray();


        grdSupUpdate.DataSource = teamList;
        db.SaveChanges();


        grdSupUpdate.DataBind();

    }

    protected void grdSupUpdate_UpdatingRows(object sender, GridViewUpdateEventArgs e)
    {
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        GridViewRow row = (GridViewRow)grdSupUpdate.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblId");
        TextBox txtNewName = (TextBox)row.FindControl("txtNumber");
        TextBox txtCity = (TextBox)row.FindControl("txtCity");
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        int id = Convert.ToInt32(lbldeleteid.Text);
        Person c = (from x in db.Person where x.PersonId == id && x.IsActive == true && x.PersonId == supid select x).SingleOrDefault();

        c.Email = txtNewName.Text;
        c.City = txtCity.Text;
        db.SaveChanges();

        grdSupUpdate.EditIndex = -1;


        Person[] teamList = (from x in db.Person where x.IsActive == true && x.PersonId == supid select x).ToArray();


        grdSupUpdate.DataSource = teamList;
        grdSupUpdate.DataBind();
    }

}
