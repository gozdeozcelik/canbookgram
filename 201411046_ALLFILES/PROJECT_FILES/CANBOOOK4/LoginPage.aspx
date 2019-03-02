<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMasterPage.master" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style17 {
        margin-left: 480px;
    }
    .auto-style18 {
        display: block;
        font-size: 14px;
        line-height: 1.428571429;
        color: #555;
        border-radius: 4px;
        -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
        -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        vertical-align: middle;
        border: 1px solid #ccc;
        margin-left: 16px;
        padding: 6px 12px;
        background-color: #fff;
        background-image: none;
    }
    .auto-style19 {
        display: block;
        font-size: 14px;
        line-height: 1.428571429;
        color: #555;
        border-radius: 4px;
        -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
        box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
        -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
        vertical-align: middle;
        border: 1px solid #ccc;
        padding: 6px 12px;
        background-color: #fff;
        background-image: none;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="auto-style17">
<link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

</p>

<div id="fullscreen_bg" class="auto-style17"/>

<div class="container">

	<form class="form-signin">
		<h1 class="form-signin-heading text-muted">Sign In</h1>
        <asp:Label ID="Label1"   runat="server" Font-Bold="True" Font-Underline="True" Text="Username:" Width="81px">USERNAME:</asp:Label>
        <asp:TextBox ID="txtEmail" cssclass="auto-style18"    runat="server" style="margin-top: 2px; margin-bottom: 2px" Width="202px"></asp:TextBox>
        <asp:RequiredFieldValidator cssclass="form-control"  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please fill username!" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
		<p>
            <asp:Label ID="Label2"   runat="server" Font-Bold="True" Font-Underline="True" Text="Password:">PASSWORD :</asp:Label>
            <asp:TextBox ID="txtPassword" cssclass="auto-style19"    runat="server" MaxLength="6" style="margin-left: 13px; margin-top: 2px; margin-bottom: 2px" TextMode="Password" Width="211px"></asp:TextBox>
            <asp:RequiredFieldValidator cssclass="form-control"  ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please fill password!" ForeColor="Red" ValidationGroup="Login"></asp:RequiredFieldValidator>
       
        &nbsp;&nbsp;&nbsp;&nbsp;
       
        <asp:Button ID="btnLogin"  cssclass="btn btn-lg btn-primary btn-block"  runat="server" OnClick="btnLogin_Click" Text="Login" ValidationGroup="Login" Width="248px" style="margin-left: 23" />
        <p>
          <p>
            <asp:Label ID="lblMesseage" cssclass="container"   runat="server" Font-Bold="True" Text="Uyarı" Visible="False"></asp:Label>
        </p>
	</form>

</div>
</asp:Content>


