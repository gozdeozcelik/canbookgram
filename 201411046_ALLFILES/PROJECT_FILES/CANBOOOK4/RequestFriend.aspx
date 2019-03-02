<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="RequestFriend.aspx.cs" Inherits="RequestFriend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <p>
    <br />
</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
</p>
<p>
    <asp:GridView ID="grdConfirmSupported" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="155px" Width="289px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
              <asp:TemplateField HeaderText="Photo" >
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl='<%# FindAvatar(Eval("FriendId")) %>' Widht="100px" />
            </ItemTemplate>
        </asp:TemplateField>

            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblFirstName" runat="server" Text='<%# FindFriendName(Eval("FriendId")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Surname">
                <ItemTemplate>
                    <asp:Label ID="lblSurname" runat="server" Text='<%# FindFriendsurname(Eval("FriendId")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Selected">
                <ItemTemplate>
                    <asp:CheckBox ID="chkConfirm" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="ID" Visible="False" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ADD" />
</p>
    <p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>

