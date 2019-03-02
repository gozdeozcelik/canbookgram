using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SeeOtherProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String spt = Session["personId"].ToString();
            int supid = Convert.ToInt32(spt);
            String nameSurname;
            BOOKGRAMEntities db = new BOOKGRAMEntities();

            Person[] personList = (from x in db.Person where x.IsActive == true && x.PersonId != supid select x).ToArray();

            for (int i = 0; i < personList.Length; i++)
            {
                nameSurname = personList[i].FirstName + " " + personList[i].LastName;
                ddlName.Items.Add(nameSurname);


            }
        }
    }
    protected void ddlEnter_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] values;
        int id;
        string name, surname, NameSurname;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        NameSurname = ddlName.SelectedValue.ToString();
        values = NameSurname.Split(' ');
        name = values[0];
        surname = values[1];
        Person te = (from x in db.Person where x.FirstName == name && x.LastName == surname select x).SingleOrDefault();
        id = te.PersonId;
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        Friend f = (from x in db.Friend where x.isActive == true && ( (x.Friend1Id == supid && x.Friend2Id==id) || x.Friend2Id == supid && x.Friend1Id == id) select x).SingleOrDefault();
        if(f==null )
        {
            if(te.Hide== false )
            {
                //can see
              
                    rptCategories.DataSource = CategoryBnd();
                    rptCategories.DataBind();
                
            }
            else
            {
                //not see
                lblUyari.Visible = true;
            }

        }
        else 
        {
            //can see
            
                rptCategories.DataSource = CategoryBnd();
                rptCategories.DataBind();
            

        }





    }
    public List<Post> CategoryBnd()
    {
        int cnt = 0;
        string[] values;
        int id;
        string name, surname, NameSurname;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        NameSurname = ddlName.SelectedValue.ToString();
        values = NameSurname.Split(' ');
        name = values[0];
        surname = values[1];
        Person te = (from x in db.Person where x.FirstName == name && x.LastName == surname select x).SingleOrDefault();
        id = te.PersonId;

        Post[] postList = (from x in db.Post where x.IsActive == true && x.PersonId == id select x).ToArray();
        List<Post> post = new List<Post>();
        Post p = new Post();
        while (cnt < postList.Length)
        {


            post.Add(new Post()
            {
                PostId = postList[cnt].PostId,
                PostText = postList[cnt].PostText,
                ImagePath = postList[cnt].ImagePath,
                Dislike_num = postList[cnt].Dislike_num,
                Like_num = postList[cnt].Like_num,


            });
            cnt++;




        }
        return post;
    }
    public string FindAvatar(object ID)
    {
        string AvatarPath = "";
        // string newTeam = "";
        int postID = Convert.ToInt32(ID);
        int personID;
        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Post pt = (from x in db.Post where x.PostId == postID select x).SingleOrDefault();
            personID = pt.PersonId.Value;
            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();

            if (te != null)
            {
                AvatarPath = te.Imagepath.ToString();
            }
        }

        return AvatarPath;
    }
    public string FindSenderName(object ID)
    {
        string name = "";
        int personID;

        // string newTeam = "";
        int postID = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Post pt = (from x in db.Post where x.PostId == postID select x).SingleOrDefault();
            personID = pt.PersonId.Value;
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
        int postID = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Post pt = (from x in db.Post where x.PostId == postID select x).SingleOrDefault();
            personID = pt.PersonId.Value;
            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();

            if (te != null)
            {
                name = te.LastName;
            }
        }


        return name;
    }
    public string FindImage(object ID)
    {
        string ImagePathh = "";

        int postID = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Post te = (from x in db.Post where x.PostId == postID select x).SingleOrDefault();
            if (te != null)
            {
                if (te.PostTypeId == 2)
                {
                    ImagePathh = te.ImagePath.ToString();


                }

            }
        }

        return ImagePathh;
    }
}

      

