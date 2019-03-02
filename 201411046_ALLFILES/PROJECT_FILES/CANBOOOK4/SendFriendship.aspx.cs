using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SendFriendship : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int cnt = 0, flg = 0;
            int id, friendId,deneme;
            List<int> idList = new List<int>();
            List<int> otherIdList = new List<int>();
            List<Person> ppp = new List<Person>();
            List<Person> person = new List<Person>();
            List<Friend> friend = new List<Friend>();
            BOOKGRAMEntities db = new BOOKGRAMEntities();
            String spt = Session["personId"].ToString();
            int supid = Convert.ToInt32(spt);
            Person[] controlMax = (from x in db.Person where x.PersonId != supid && x.IsActive == true select x).ToArray();
            Friend[] friendList = (from x in db.Friend where x.isActive == true && (x.Friend1Id == supid || x.Friend2Id == supid) select x).ToArray();
            if (friendList.Length != 0 || friendList.Length!= controlMax.Length+1)
            {

                for (int i = 0; i < friendList.Length; i++)
                {
                    if (friendList[i].Friend1Id == supid)
                    {
                        id = friendList[i].Friend2Id.Value;
                    }
                    else
                    {
                        id = friendList[i].Friend1Id.Value;
                    }
                    idList.Add(id);
                }
                Person[] personList = (from x in db.Person where x.PersonId != supid && x.IsActive == true select x).ToArray();
                for(int i = 0; i < personList.Length; i++)
                {
                    otherIdList.Add(personList[i].PersonId);
                }
                for (int i = 0; i < idList.Count; i++)
                {
                    for (int j = 0; j < otherIdList.Count; j++)
                    {
                        if (idList[i] == otherIdList[j])
                        {
                            otherIdList.RemoveAt(j);
                            break;
                        }
                      
                       

                       
                    }
                  
                }

                for (int i = 0; i < otherIdList.Count; i++)
                {
                    friendId = otherIdList[i];
                    Person te = (from x in db.Person where x.PersonId == friendId select x).SingleOrDefault();
                    ppp.Add(te);
                }
                while (cnt < ppp.Count)
                {


                    person.Add(new Person()
                    {

                        PersonId = ppp[cnt].PersonId,
                        FirstName = ppp[cnt].FirstName,
                        LastName = ppp[cnt].LastName,
                        Imagepath = ppp[cnt].Imagepath,



                    });
                    cnt++;
                    grdTeamOp.DataSource = person;
                    grdTeamOp.DataBind();

                }
            }
            else if(friendList.Length == 0)
            {
                Person[] personList = (from x in db.Person where x.PersonId != supid && x.IsActive == true select x).ToArray();
                for (int i = 0; i < personList.Length; i++)
                {
                    friendId = personList[i].PersonId;
                    Person te = (from x in db.Person where x.PersonId == friendId select x).SingleOrDefault();
                    ppp.Add(te);
                }
                while (cnt < ppp.Count)
                {


                    person.Add(new Person()
                    {

                        PersonId = ppp[cnt].PersonId,
                        FirstName = ppp[cnt].FirstName,
                        LastName = ppp[cnt].LastName,
                        Imagepath = ppp[cnt].Imagepath,



                    });
                    cnt++;

                 }
                grdTeamOp.DataSource = person;
                grdTeamOp.DataBind();
            }

            else if (friendList.Length == controlMax.Length+1)
            {

            }

               
            }
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
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
       
        Friend newFriend = new Friend();
        newFriend.Friend1Id = supid;
        newFriend.Friend2Id = id;
        newFriend.isActive = false;
        db.Friend.Add(newFriend);

        db.SaveChanges();


        grdTeamOp.DataBind();

        Response.Redirect("FriendList.aspx");


    }


}