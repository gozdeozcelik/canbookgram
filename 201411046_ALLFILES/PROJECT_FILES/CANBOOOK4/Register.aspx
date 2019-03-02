<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/HomeMasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <html xmlns="http://www.w3.org/1999/xhtml">

<head >
    <title>Register Page</title>
    <meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Raleway">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
body,h1,h2,h3,h4,h5,h6 {font-family: "Raleway", Arial, Helvetica, sans-serif}
.myLink {display: none}
button {
  background-color: #ffd800;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  cursor: pointer;
  width: 100%;
  opacity: 0.9;
}
    .auto-style1 {
        width: 508px;
        height: 832px;
    }

}
</style>
 

</head>
<body>
  
    
            <h1 class="w3-xxxlarge w3-text-red"><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SIGN UP</b></h1>
    <hr style="width:736px; border:5px solid red" class="w3-round">
<p style="margin-left: 200px" class="auto-style1">
    <asp:Label ID="Label1" Width="100px"  Height="10px"   runat="server" Text="First Name:" Font-Bold="True" Font-Italic="True" ForeColor="Red"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtboxName" Width="400px"  Height="10px" class="w3-input w3-padding-16 w3-border" runat="server"></asp:TextBox>
        &nbsp;
    </br>
            <asp:Label ID="Label2" Width="100px" Height="10px" ForeColor="Red" runat="server" Text="Last Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxSurname" Width="400px" Height="10px" class="w3-input w3-padding-16 w3-border" runat="server" style="margin-bottom: 1px"></asp:TextBox>
        
     
            <asp:Label ID="Label3"  Width="100px" Height="10px" ForeColor="Red" runat="server" Text="City:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxAddress" Width="400px"  Height="10px" class="w3-input w3-padding-16 w3-border" runat="server"></asp:TextBox>
        </br>
        
            <asp:Label ID="Label4"  Width="100px" Height="10px" ForeColor="Red"  runat="server" Text="Birth Date:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxDate"  Width="400px" Height="10px" class="w3-input w3-padding-16 w3-border" runat="server" style="margin-bottom: 1px" TextMode="Date"></asp:TextBox>
        </br>
            <asp:Label ID="Label5"  Width="100px" Height="10px" ForeColor="Red"  runat="server" Text="Email"></asp:Label>
            :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxEmail"  Width="400px" Height="10px"  class="w3-input w3-padding-16 w3-border" runat="server" style="margin-bottom: 1px"></asp:TextBox>
            <asp:Label ID="Label9"  Width="100px" Height="10px" ForeColor="Red"  runat="server" Text="Profile Photo: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:FileUpload ID="fuLogoUp" runat="server" class="w3-input w3-border" Width="400px" />
           
    </br>
            <asp:Label ID="Label10"  Width="100px" Height="10px" ForeColor="Red"  runat="server" Text="Hide: "></asp:Label>
            &nbsp;
    <asp:CheckBox ID="chcBox" runat="server" OnCheckedChanged="chcBox_CheckedChanged" />
      </br>
            <asp:Label ID="Label7"  Width="100px" Height="10px" ForeColor="Red" runat="server" Text="Username:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxUsername"  Width="400px" Height="10px" class="w3-input w3-padding-16 w3-border"  runat="server" style="margin-bottom: 1px"></asp:TextBox>
       </br>
            <asp:Label ID="Label8"  Width="100px" Height="10px" ForeColor="Red"  runat="server" Text="Password"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtboxPass"  Width="400px" Height="10px"  class="w3-input w3-padding-16 w3-border" runat="server" style="margin-bottom: 1px"></asp:TextBox>
        </br>
    <asp:Label ID="uyari"  visible="false" Width="100px" Height="10px" ForeColor="Red" runat="server" Text="Starred areas cannot be blank!! :"></asp:Label>
     </br>
            &nbsp;<asp:Button ID="btnSave"  runat="server" Text="Save" OnClick="btnSave_Click" BackColor="Lime" Font-Bold="True" Font-Overline="False" Height="45px" Width="409px" />
        </br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
            </div>
            </form>
   
</body>
</asp:Content>

