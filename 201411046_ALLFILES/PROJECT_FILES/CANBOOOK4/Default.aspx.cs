using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
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
        int id;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);
        Friend[] friendList = (from x in db.Friend where x.isActive == true && (x.Friend1Id == supid || x.Friend2Id == supid) select x).ToArray();
        List<int> idList = new List<int>();
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


        Post[] postList = (from x in db.Post where x.IsActive == true select x).ToArray();
        int postId;
        List<Post> post = new List<Post>();
        List<Post> ppp = new List<Post>();
        Post p = new Post();
        List<int> postIdList = new List<int>();
        for (int i = 0; i < idList.Count; i++)
        {
            for (int j = 0; j < postList.Length; j++)
            {
                if (idList[i] == postList[j].PersonId)
                {
                    postId = postList[j].PostId;
                    postIdList.Add(postId);
                }
            }
        }
        for (int i = 0; i < postIdList.Count; i++)
        {
            postId = postIdList[i];
            Post te = (from x in db.Post where x.PostId == postId select x).SingleOrDefault();
            ppp.Add(te);
        }


        while (cnt < ppp.Count)
        {


            post.Add(new Post()
            {

                PostId = ppp[cnt].PostId,
                PostText = ppp[cnt].PostText,
                ImagePath = ppp[cnt].ImagePath,
                Dislike_num = ppp[cnt].Dislike_num,
                Like_num = ppp[cnt].Like_num,


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

            Response.Redirect("Default.aspx");
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
            Response.Redirect("Default.aspx");
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