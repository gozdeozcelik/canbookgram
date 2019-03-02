using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptCategories.DataSource = CategoryBnd();
            rptCategories.DataBind();
        }

    }
    public List<Post> CategoryBnd()
    {
        int cnt = 0;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        Post[] postList = (from x in db.Post where x.IsActive == true  && x.PersonId==supid select x).ToArray();
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
        if (e.CommandName.ToString() == "like")
        {
            BOOKGRAMEntities db = new BOOKGRAMEntities();

            int postId;
            String id;
            id = e.CommandArgument.ToString();
            postId = Convert.ToInt32(id);
            Post te = (from x in db.Post where x.PostId == postId select x).SingleOrDefault();
            te.Like_num++;
            db.SaveChanges();

            Response.Redirect("MyProfile.aspx");
        }
        else if (e.CommandName.ToString() == "dislike")
        {
            BOOKGRAMEntities db = new BOOKGRAMEntities();

            int postId;
            String id;
            id = e.CommandArgument.ToString();
            postId = Convert.ToInt32(id);
            Post te = (from x in db.Post where x.PostId == postId select x).SingleOrDefault();
            te.Dislike_num++;
            db.SaveChanges();
            Response.Redirect("MyProfile.aspx");
        }
        else if (e.CommandName.ToString() == "comment")
        {
            Session["postId"] = e.CommandArgument.ToString();

            Response.Redirect("CommentPage.aspx");
        }
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