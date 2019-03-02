<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="CommentPage.aspx.cs" Inherits="CommentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
      <html>
<head>
    <title></title>
    <meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<link rel="stylesheet" href="https://www.w3schools.com/lib/w3-theme-blue-grey.css">
<link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Open+Sans'>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style>
html,body,h1,h2,h3,h4,h5 {font-family: "Open Sans", sans-serif}
</style>
<body>
</head>
<body>
        <div class="w3-container w3-card w3-white w3-round w3-margin">
      <br />
            <%--<asp:Label ID="lblPostId" runat="server" Text="Label"></asp:Label>
    <br />--%>
    <asp:TextBox ID="txtPost" runat="server" Height="62px" Width="346px" ></asp:TextBox>
    <br />
     
&nbsp;<asp:Button ID="btnSend" runat="server" Text="SAVE" OnClick="btnSend_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="CANCEL" />
       </div>
    <div>
        
        <asp:Repeater ID="rptCategories" runat="server" > 
           
         
           <ItemTemplate>
              
                       <div class="w3-container w3-card w3-white w3-round w3-margin">
                    <asp:Image ID="Image1" height="70px" Width="70px" class="w3-left w3-circle w3-margin-right" ImageUrl='<%# FindAvatar(Eval("CommentId")) %>' runat="server" />
                     <Label ID="lblId"  visible="true" runat="server" ><%# FindSenderName(Eval("CommentId")) %></Label>
               <Label ID="lblSurname" visible="true" runat="server" ><%# FindSenderSurName(Eval("CommentId")) %></Label>
               </div>
    <div class="w3-container w3-card w3-white w3-round w3-margin">
         <hr class="w3-clear">
          <p><%#Eval("CommentText") %></p>
 
        <br />

      
</AlternatingItemTemplate>
<FooterTemplate>
        </tbody>
    </table> 
</FooterTemplate>
        </asp:Repeater>

        
      </div>
             
                <br>
             
               </br>
                
           </ItemTemplate>
        </asp:Repeater>
    
    </div>
    </form>
</body>
</html>
</asp:Content>

