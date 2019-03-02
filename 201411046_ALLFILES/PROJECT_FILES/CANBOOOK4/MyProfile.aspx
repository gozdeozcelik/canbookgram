<%@ Page Title=" "EnableEventValidation="false" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="MyProfile.aspx.cs" Inherits="MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
<body class="w3-theme-l5">
</head>
<body>
    
    <div>
        
        <asp:Repeater ID="rptCategories" runat="server" OnItemCommand="rptCategories_ItemCommand"> 
           
         
           <ItemTemplate>
              
                       <div class="w3-container w3-card w3-white w3-round w3-margin">
                    <asp:Image ID="Image1" height="70px" Width="70px" class="w3-left w3-circle w3-margin-right" ImageUrl='<%# FindAvatar(Eval("PostId")) %>' runat="server" />
                     <Label ID="lblId"  visible="true" runat="server" ><%# FindSenderName(Eval("PostId")) %></Label>
               <Label ID="lblSurname" visible="true" runat="server" ><%# FindSenderSurName(Eval("PostId")) %></Label>
               </div>

    <div class="w3-container w3-card w3-white w3-round w3-margin">
         <hr class="w3-clear">
          <p><%#Eval("PostText") %></p>
 </div>
                  <div class="w3-container w3-card w3-white w3-round w3-margin">

                    <asp:Image ID="photoim" height="70px" Width="70px" ImageUrl='<%# FindImage(Eval("PostId")) %>' runat="server" />

                     </div>
        <br />

         <Label ID="lblLikeCount"  visible="true" runat="server" ><%#Eval("Like_num")%>:Like    </Label>
       
         <Label ID="lblDislikeCount"  visible="true" runat="server" ><%#Eval("Dislike_num")%>:Dislike      </Label>
        </div>
            
              
                <div class="w3-container w3-card w3-white w3-round w3-margin"><br>
      
                   
                    <td><asp:LinkButton ID="lnkComment" runat="server" class="w3-button w3-theme-d1 w3-margin-bottom" CommandArgument='<%# Eval("PostId") %>' CommandName="comment" Text="dislike"><i class="fa fa-comment"></i> </i>Comment</asp:LinkButton></td>

    </tr>
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

