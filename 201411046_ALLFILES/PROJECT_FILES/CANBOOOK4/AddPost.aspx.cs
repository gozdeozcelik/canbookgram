using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BOOKGRAMEntities db = new BOOKGRAMEntities();
        String spt = Session["personId"].ToString();
        int supid = Convert.ToInt32(spt);

        Post newPost = new Post();
        newPost.PostText = txtPost.Text;
        newPost.Dislike_num = 0;
        newPost.Like_num = 0;
        newPost.IsActive = true;
        newPost.PersonId = supid;
        newPost.Comment_num = 0;
       

        if (fuLogoUp.Visible == true)
        {
            if (fuLogoUp.HasFile)
            {
                fuLogoUp.SaveAs(Server.MapPath("~/Logos/" + fuLogoUp.FileName));
            }
            newPost.ImagePath = "~/Logos/" + fuLogoUp.FileName;
            newPost.PostTypeId = 2;
        }
        else
        {
            newPost.PostTypeId = 1;
        }





        db.Post.Add(newPost);
        db.SaveChanges();
        Response.Redirect("AddPost.aspx");
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        txtPost.Visible = true;
        btnPhoto.Visible = false;
        btnPOst.Visible = false;
        PostText.Visible = true;
        btnShare.Visible = true;
        fuLogoUp.Visible = true;
        PostText.Visible = true;
        Photo.Visible = true;


    }

    protected void Button3_Click(object sender, EventArgs e)
    {

        txtPost.Visible = true;
        btnPhoto.Visible = false;
        btnPOst.Visible = false;
        PostText.Visible = true;
        btnShare.Visible = true;
        PostText.Visible = true;

    }
}