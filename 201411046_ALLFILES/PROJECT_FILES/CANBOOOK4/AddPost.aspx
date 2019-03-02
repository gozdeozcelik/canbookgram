<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="AddPost.aspx.cs" Inherits="AddPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
        <br />
    </p>
    <p>
        <asp:Button ID="btnPhoto" runat="server" OnClick="Button2_Click" Text="PHOTO" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnPOst" runat="server" OnClick="Button3_Click" Text="POST" />
    </p>
    <p>
        &nbsp;</p>
    <p>

    <asp:Label ID="PostText"  Width="100px" Height="16px" ForeColor="Red"  runat="server" Text="Post:" Visible="False"></asp:Label>
            <br />
    <asp:TextBox ID="txtPost" runat="server" Height="77px" Width="392px" Visible="False"></asp:TextBox>
    <br />
    <asp:Label ID="Photo"  Width="100px" Height="16px" ForeColor="Red"  runat="server" Text=" Photo: " Visible="False"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:FileUpload ID="fuLogoUp" runat="server" class="w3-input w3-border" Width="400px" Visible="False" />                                 
   
    <br />
    <br />
    <asp:Button ID="btnShare" runat="server" OnClick="Button1_Click" Text="SHARE" Visible="False" />
   
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
   
</asp:Content>

