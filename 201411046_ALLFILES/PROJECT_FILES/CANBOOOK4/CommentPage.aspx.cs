using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CommentPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //rptComment.DataSource = CommendBind();
            //rptComment.DataBind();
            String spt = Session["postId"].ToString();
            int supid = Convert.ToInt32(spt);
            //lblPostId.Text = spt;
            rptCategories.DataSource = CategoryBnd();
            rptCategories.DataBind();


        }

    }
    public List<Comment> CategoryBnd()
    {
        String spt = Session["postId"].ToString();
        int supid = Convert.ToInt32(spt);
        int cnt = 0;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        Comment[] commentList = (from x in db.Comment where x.IsActive == true && x.PostId==supid select x).ToArray();
        List<Comment> comment = new List<Comment>();
        Comment p = new Comment();
        while (cnt < commentList.Length)
        {


            comment.Add(new Comment()
            {
                PostId = commentList[cnt].PostId,
                CommentText = commentList[cnt].CommentText,
                PersonId = commentList[cnt].PersonId,
                IsActive = commentList[cnt].IsActive,
                CommentId= commentList[cnt].CommentId,



            });
            cnt++;




        }
        return comment;
    }
    public string FindAvatar(object ID)
    {
        string AvatarPath = "";
        // string newTeam = "";
        int commentId = Convert.ToInt32(ID);
        int personID;
        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Comment pt = (from x in db.Comment where x.CommentId == commentId select x).SingleOrDefault();
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
        Response.Redirect("Default.aspx");




    }
    
    public string FindSenderName(object ID)
    {
        string name = "";
        int personID;

        // string newTeam = "";
        int commentId = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Comment pt = (from x in db.Comment where x.CommentId == commentId select x).SingleOrDefault();
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
        int commentId = Convert.ToInt32(ID);

        using (BOOKGRAMEntities db = new BOOKGRAMEntities())
        {
            Comment pt = (from x in db.Comment where x.CommentId == commentId select x).SingleOrDefault();
            personID = pt.PersonId.Value;
            Person te = (from x in db.Person where x.PersonId == personID select x).SingleOrDefault();

            if (te != null)
            {
                name = te.LastName;
            }
        }


        return name;
    }
   



    protected void btnSend_Click(object sender, EventArgs e)
    {
        String spt = Session["postId"].ToString();
        int supid = Convert.ToInt32(spt);
        String sspt = Session["personId"].ToString();
        int perid = Convert.ToInt32(sspt);
        //lblPostId.Text = spt;
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        Comment newComment = new Comment();
        newComment.CommentText= txtPost.Text;
        newComment.IsActive = true;
        newComment.PostId = supid;
        newComment.PersonId = perid;
        db.Comment.Add(newComment);
        db.SaveChanges();
        Response.Redirect("CommentPage.aspx");




    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}