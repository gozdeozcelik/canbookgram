using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FriendOperation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            int frid;
            string adm = Session["personId"].ToString();
            int adminId = Convert.ToInt32(adm);

            BOOKGRAMEntities db = new BOOKGRAMEntities();
            Person pe = (from x in db.Person where x.PersonId == adminId select x).SingleOrDefault();
            frid = pe.PersonId;
            Friend[] friendList = (from x in db.Friend where x.isActive == true && (x.Friend1Id == frid || x.Friend2Id == frid) select x).ToArray();
            grdTeamOp.DataSource = friendList;
            grdTeamOp.DataBind();
        }
    }
    protected void grdTeamOp_RowsCanceling(object sender, GridViewCancelEditEventArgs e)
    {

        int frid;

        grdTeamOp.EditIndex = -1;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        string adm = Session["personId"].ToString();
        int adminId = Convert.ToInt32(adm);

        Person pe = (from x in db.Person where x.PersonId == adminId select x).SingleOrDefault();
        frid = pe.PersonId;
        Friend[] friendList = (from x in db.Friend where x.isActive == true && (x.Friend1Id == frid || x.Friend2Id == frid) select x).ToArray();
        grdTeamOp.DataSource = friendList;
        grdTeamOp.DataBind();

    }


    protected void grdTeamOp_RowsDeleting(object sender, GridViewDeleteEventArgs e)
    {

        GridViewRow row = (GridViewRow)grdTeamOp.Rows[e.RowIndex];
        Label lbldeleteid = (Label)row.FindControl("lblId");
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        int id = Convert.ToInt32(lbldeleteid.Text);
        Friend c = (from x in db.Friend where x.FriendId == id && x.isActive == true select x).SingleOrDefault();
        if (c != null)
            c.isActive = false;

        db.SaveChanges();


        grdTeamOp.DataBind();




    }


}