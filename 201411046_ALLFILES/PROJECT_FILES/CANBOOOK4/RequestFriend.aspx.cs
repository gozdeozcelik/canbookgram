using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RequestFriend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BOOKGRAMEntities db = new BOOKGRAMEntities();
            string adm = Session["personId"].ToString();
            int adminId = Convert.ToInt32(adm);

            Friend[] friendList = (from x in db.Friend where x.isActive == false && (x.Friend1Id == adminId || x.Friend2Id == adminId) select x).ToArray();

            grdConfirmSupported.DataSource = friendList;
            grdConfirmSupported.DataBind();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string message = "Successfully friendship!!";
        string adm = Session["personId"].ToString();
        int adminId = Convert.ToInt32(adm);
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        for (int i = 0; i < grdConfirmSupported.Rows.Count; i++)
        {
            GridViewRow row = (GridViewRow)grdConfirmSupported.Rows[i];
            CheckBox chkNew = (CheckBox)row.FindControl("chkConfirm");
            Label lblName = (Label)row.FindControl("lblFirstName");
            Label lblSurname = (Label)row.FindControl("lblLastname");
            Person c = (from x in db.Person where x.FirstName == lblName.Text && x.IsActive == true  select x).SingleOrDefault();
            int id = c.PersonId;
            if (chkNew.Checked)
            {
                // message += lblName.Text;
                Friend p = (from x in db.Friend where x.isActive == false && ((x.Friend1Id == id && x.Friend2Id == adminId) || (x.Friend2Id == id && x.Friend1Id == adminId)) select x).SingleOrDefault();
                p.isActive = true;
                db.SaveChanges();

            }
        }

        lblMessage.Text = message;
        grdConfirmSupported.Visible = false;
        Button1.Visible = false;

    }
    public string FindFriendName(object ID)
    {
        string name = "";
        int personId = -5;
        string adm = Session["personId"].ToString();
        int adminId = Convert.ToInt32(adm);
        // string newTeam = "";
        int friendId = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Friend te = (from x in db.Friend where x.FriendId == friendId select x).SingleOrDefault();
            if (te != null)
            {
                if (te.Friend1Id == adminId)
                {
                    personId = te.Friend2Id.Value;

                }
                else
                {
                    personId = te.Friend1Id.Value;
                }
            }
        }
        BOOKGRAMEntities db2 = new BOOKGRAMEntities();
        Person pe = (from x in db2.Person where x.PersonId == personId select x).SingleOrDefault();
        name = pe.FirstName;

        return name;
    }
    public string FindFriendsurname(object ID)
    {
        string name = "";
        int personId = -5;
        string adm = Session["personId"].ToString();
        int adminId = Convert.ToInt32(adm);
        // string newTeam = "";
        int friendId = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Friend te = (from x in db.Friend where x.FriendId == friendId select x).SingleOrDefault();
            if (te != null)
            {
                if (te.Friend1Id == adminId)
                {
                    personId = te.Friend2Id.Value;

                }
                else
                {
                    personId = te.Friend1Id.Value;
                }
            }
        }
        BOOKGRAMEntities db2 = new BOOKGRAMEntities();
        Person pe = (from x in db2.Person where x.PersonId == personId select x).SingleOrDefault();
        name = pe.LastName;

        return name;
    }
    public string FindAvatar(object ID)
    {
        string name = "";
        int personId = -5;
        string adm = Session["personId"].ToString();
        int adminId = Convert.ToInt32(adm);
       
        int friendId = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Friend te = (from x in db.Friend where x.FriendId == friendId select x).SingleOrDefault();
            if (te != null)
            {
                if (te.Friend1Id == adminId)
                {
                    personId = te.Friend2Id.Value;

                }
                else
                {
                    personId = te.Friend1Id.Value;
                }
            }
        }
        BOOKGRAMEntities db2 = new BOOKGRAMEntities();
        Person pe = (from x in db2.Person where x.PersonId == personId select x).SingleOrDefault();
        name = pe.Imagepath;

        return name;
    }

}