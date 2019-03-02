<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="FriendOperation.aspx.cs" Inherits="FriendOperation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <p>
        <br />
    </p>
    <p>
    </p>
    <p>
        <asp:GridView ID="grdTeamOp" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="grdTeamOp_RowsCanceling" OnRowDeleting="grdTeamOp_RowsDeleting" OnSelectedIndexChanged="Page_Load" Height="509px" Width="1007px">

            <Columns>
                <asp:TemplateField HeaderText="ID" Visible="False"    >
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("FriendId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

        <%--<asp:TemplateField HeaderText="PP">
            <ItemTemplate>
                <asp:Image ID="Image1" Height="100px" Widht="100px" runat="server" ImageUrl='<%# Bind("ImagePath") %>'></asp:Image>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="First Name">
            <ItemTemplate>
                <asp:Label ID="lblPosition" runat="server" Text='<%# Bind("FriendId") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Font-Bold="True" Font-Names="Arial Black" HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
        </asp:TemplateField>

                  <asp:TemplateField HeaderText="Last Name">
                      <EditItemTemplate>
                          <asp:TextBox ID="txtTeamName" runat="server" Text='<%# Bind("Friend1Id") %>'></asp:TextBox>
                      </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblTeamName" runat="server" Text='<%# Bind("Friend2Id") %>'>></asp:Label>
            </ItemTemplate>
            <ItemStyle Font-Bold="True" Font-Names="Arial Black" HorizontalAlign="Center" VerticalAlign="Middle" Width="250px" />
        </asp:TemplateField>
        
        
     
       
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Logos/delete.png" HeaderText="Operation" ShowDeleteButton="True" ShowHeader="True" UpdateImageUrl="~/Logos/update.png" CancelImageUrl="~/Logos/cancel.png" >
        
        
     
       
                <ControlStyle Height="40px" />
                </asp:CommandField>
        
        
     
       
    </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#487575" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
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
    </p>
</asp:Content>

