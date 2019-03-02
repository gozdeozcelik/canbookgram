using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Messeage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String spt = Session["personId"].ToString();
            int supid = Convert.ToInt32(spt);
            BOOKGRAMEntities db = new BOOKGRAMEntities();
            int value;
            Friend[] friendList = (from x in db.Friend where x.isActive == true && (x.Friend1Id == supid || x.Friend2Id == supid) select x).ToArray();
            List<Person> personList = new List<Person>();
            List<int> idList = new List<int>();
            string nameSurname;
            List<string> nameList = new List<string>();
            int id;
            Person p = new Person();
            //firstly take receiver personId
            for (int i = 0; i < friendList.Length; i++)
            {
                if(friendList[i].Friend1Id == supid)
                {
                   id= friendList[i].Friend2Id.Value;
                   
                }
                else
                {
                   id = friendList[i].Friend1Id.Value;
                }
                idList.Add(id);
               
              
                
               

            }
            //secondly take name+surname
            for (int i = 0; i < idList.Count; i++)
            {
                value = idList[i];
                Person te = (from x in db.Person where x.PersonId ==value  select x).SingleOrDefault();
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MyProfile.aspx");
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        string nameSurname;
        string[] values;
        string name;
        string surname;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        MessageList sendMesseage = new MessageList();
        sendMesseage.IsActive = true;
        sendMesseage.IsRead = false;
        sendMesseage.MessageText = txtMesseage.Text;
        sendMesseage.senderUserId = supid;
        nameSurname = ddlReceiver.Text;
        values = nameSurname.Split(' ');
        name = values[0];
        surname = values[1];
        Person t = (from x in db.Person where x.FirstName == name && x.LastName==surname select x).SingleOrDefault();
        sendMesseage.receiverUserId = t.PersonId;
        db.MessageList.Add(sendMesseage);
        db.SaveChanges();
        Response.Redirect("Messeage.aspx");



    }
}