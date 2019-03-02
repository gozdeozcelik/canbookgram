<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Messeage.aspx.cs" Inherits="Messeage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <asp:Label runat="server" Text="Receiver:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlReceiver" runat="server">
         <asp:ListItem>Select a receiver...</asp:ListItem>
    </asp:DropDownList>
    <br />
&nbsp;<asp:TextBox ID="txtMesseage" runat="server" Height="141px" Width="247px"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnSend" runat="server" Text="SEND" Width="61px" OnClick="btnSend_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="CANCEL" OnClick="btnCancel_Click" />
</asp:Content>

