using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FriendList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int flg = 0;
            BOOKGRAMEntities db = new BOOKGRAMEntities();
            String spt = Session["personId"].ToString();
            int supid = Convert.ToInt32(spt);
            Friend[] friendList = (from x in db.Friend where x.isActive == true && (x.Friend1Id==supid || x.Friend2Id == supid) select x).ToArray();
            

      

            grdTeamOp.DataSource = friendList;
            grdTeamOp.DataBind();
        }
    }
    public string FindAvatar(object ID)
    {
        string AvatarPath = "";
       
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        int friendId = Convert.ToInt32(ID);
        int personID;
       
        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Friend pt = (from x in db.Friend where x.FriendId == friendId && x.isActive==true select x).SingleOrDefault();
            if(supid== pt.Friend1Id)
            {
                personID = pt.Friend2Id.Value;
            }
            else if(supid == pt.Friend2Id)
            {
                personID = pt.Friend1Id.Value;
            }
            else
            {
                personID = -5;
            }

           
            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();

            if (te != null)
            {
                AvatarPath = te.Imagepath.ToString();
            }
        }

        return AvatarPath;
    }
    public string FindFriendName(object ID)
    {
        string name = "";

        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        int friendId = Convert.ToInt32(ID);
        int personID;

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Friend pt = (from x in db.Friend where x.FriendId == friendId && x.isActive == true select x).SingleOrDefault();
            if (supid == pt.Friend1Id)
            {
                personID = pt.Friend2Id.Value;
            }
            else if (supid == pt.Friend2Id)
            {
                personID = pt.Friend1Id.Value;
            }
            else
            {
                personID = -5;
            }


            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();

            if (te != null)
            {
                name = te.FirstName.ToString();
            }
        }

        return name;
    }
    public string FindFriendsurname(object ID)
    {
        string surname = "";

        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        int friendId = Convert.ToInt32(ID);
        int personID;

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Friend pt = (from x in db.Friend where x.FriendId == friendId && x.isActive == true select x).SingleOrDefault();
            if (supid == pt.Friend1Id)
            {
                personID = pt.Friend2Id.Value;
            }
            else if (supid == pt.Friend2Id)
            {
                personID = pt.Friend1Id.Value;
            }
            else
            {
                personID = -5;
            }


            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();

            if (te != null)
            {
                surname = te.LastName.ToString();
            }
        }

        return surname;
    }
    protected void grdTeamOp_RowsCanceling(object sender, GridViewCancelEditEventArgs e)
    {
        grdTeamOp.EditIndex = -1;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        Friend[] friendList = (from x in db.Friend where x.isActive == true && (x.Friend1Id == supid || x.Friend2Id == supid) select x).ToArray();
       
        db.SaveChanges();


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

        Response.Redirect("FriendList.aspx");


    }



}