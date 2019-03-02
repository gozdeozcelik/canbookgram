using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MesseageList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String spt = Session["personId"].ToString();
            int supid = Convert.ToInt32(spt);
            BOOKGRAMEntities db = new BOOKGRAMEntities();
            int value;
            MessageList[] messeageList = (from x in db.MessageList where x.IsActive == true && x.receiverUserId== supid select x).ToArray();
            List<int> idList = new List<int>();
            string nameSurname;
            List<string> nameList = new List<string>();
           
            //firstly take receiver personId
            for (int i = 0; i < messeageList.Length; i++)
            {
                value = messeageList[i].senderUserId.Value;
                idList.Add(value);

            }
            for (int i = 0; i < idList.Count; i++)
            {
                for (int j = i + 1; j < idList.Count; j++)
                {
                    if (idList[i] == idList[j])
                    {
                        idList.RemoveAt(i);
                    }
                }
            }
            //secondly take name+surname
            for (int i = 0; i < idList.Count; i++)
            {
                value = idList[i];
                Person te = (from x in db.Person where x.PersonId == value select x).SingleOrDefault();
                nameSurname = te.FirstName + " " + te.LastName;
                nameList.Add(nameSurname);




            }
          
            //write to ddl
            for (int i = 0; i < idList.Count; i++)
            {

                ddlReceiver.Items.Add(nameList[i]);

            }


           
        }


    }
    public List<MessageList> CategoryBnd()
    {
        int cnt = 0;
        string NameSurname;
        string[] values;
        string name;
        string surname;
        int id;
        NameSurname = ddlReceiver.SelectedValue.ToString();
        values = NameSurname.Split(' ');
        name = values[0];
        surname = values[1];
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        Person te = (from x in db.Person where x.FirstName == name && x.LastName==surname select x).SingleOrDefault();
        id = te.PersonId;
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        MessageList[] messeageList = (from x in db.MessageList where x.IsActive == true && x.receiverUserId==supid && x.senderUserId==id select x).ToArray();
        List<MessageList> post = new List<MessageList>();
        MessageList mList = new MessageList();
        while (cnt < messeageList.Length)
        {


            post.Add(new MessageList()
            {
                MessageId = messeageList[cnt].MessageId,
                MessageText = messeageList[cnt].MessageText,
                senderUserId = messeageList[cnt].senderUserId,
                receiverUserId = messeageList[cnt].receiverUserId,
                IsActive = messeageList[cnt].IsActive,



            });
            cnt++;




        }
        return post;
    }
    public string FindAvatar(object ID)
    {
        string AvatarPath = "";
        // string newTeam = "";
        int messageId = Convert.ToInt32(ID);
        int personID;
        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            MessageList pt = (from x in db.MessageList where x.MessageId == messageId select x).SingleOrDefault();
            personID = pt.senderUserId.Value;
            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();

            if (te != null)
            {
                AvatarPath = te.Imagepath.ToString();
            }
        }

        return AvatarPath;
    }



    //void btn_Click(object sender, EventArgs e)
    //{
    //    Button btn = (Button)sender;
    //    RepeaterItem ritem = (RepeaterItem)btn.NamingContainer;

    //    Response.Redirect("MyProfile.aspx");


    //}
    protected void btnLike_Click(object sender, EventArgs e)

    {
        Button btn = (Button)sender;
        RepeaterItem ritem = (RepeaterItem)btn.NamingContainer;
        Response.Redirect("MyProfile.aspx");




    }
    protected void rptCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "delete")
        {
            string nameSurname;
            //string[] values;
            //string name;
            //string surname;
            BOOKGRAMEntities db = new BOOKGRAMEntities();
            //nameSurname = ddlReceiver.SelectedValue.ToString();
            //values = nameSurname.Split(' ');
            //name = values[0];
            //surname = values[1];
            int messeageId;
            String id;
            id = e.CommandArgument.ToString();
            messeageId = Convert.ToInt32(id);
            MessageList te = (from x in db.MessageList where x.MessageId == messeageId select x).SingleOrDefault();
            te.IsActive=false;
            db.SaveChanges();

            Response.Redirect("MesseageList.aspx");
        }
       
    }
    public string FindSenderName(object ID)
    {
        string name = "";
        int personID;

        // string newTeam = "";
        int messeageId = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            MessageList pt = (from x in db.MessageList where x.MessageId == messeageId select x).SingleOrDefault();
            personID = pt.senderUserId.Value;
            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();
            if (te != null)
            {
                name = te.FirstName;
            }
        }


        return name;
    }
    public string FindSenderSurName(object ID)
    {
        string name = "";
        int personID;

        // string newTeam = "";
        int messeageId = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            MessageList pt = (from x in db.MessageList where x.MessageId == messeageId select x).SingleOrDefault();
            personID = pt.senderUserId.Value;
            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();
            if (te != null)
            {
                name = te.LastName;
            }
        }


        return name;
    }
   
    protected void ddlEnter_SelectedIndexChanged(object sender, EventArgs e)
    {
       
       
       


        rptCategories.DataSource = CategoryBnd();
        rptCategories.DataBind();
    }

   
}