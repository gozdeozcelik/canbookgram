﻿<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="SeeOtherProfile.aspx.cs" Inherits="SeeOtherProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    
    <div>
          <asp:Label ID="Label1" runat="server" Text="Search List: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlName" OnSelectedIndexChanged="ddlEnter_SelectedIndexChanged" runat="server">
            <asp:ListItem>Select a person...</asp:ListItem>
        </asp:DropDownList>

        &nbsp;<asp:Button ID="btnOK" runat="server" Text="OK"  />
          <br />
    </div>
    <div>
        
       
         
        <asp:Label ID="lblUyari" Visible="false" runat="server" Text="The user profile is unlock so must be add friend!"></asp:Label>
         <asp:Repeater ID="rptCategories" runat="server" > 
           
         
           <ItemTemplate>
              
                       <div class="w3-container w3-card w3-white w3-round w3-margin">
                    <asp:Image ID="Image1" height="70px" Width="70px" class="w3-left w3-circle w3-margin-right" ImageUrl='<%# FindAvatar(Eval("PostId")) %>' runat="server" />
                     <Label ID="lblId"  visible="true" runat="server" ><%# FindSenderName(Eval("PostId")) %></Label>
               <Label ID="lblSurname" visible="true" runat="server" ><%# FindSenderSurName(Eval("PostId")) %></Label>
               </div>
    <div class="w3-container w3-card w3-white w3-round w3-margin">
         <hr class="w3-clear">
          <p><%#Eval("PostText") %></p>
 
        <br />

         <Label ID="lblLikeCount"  visible="true" runat="server" ><%#Eval("Like_num")%>:Like    </Label>
       
         <Label ID="lblDislikeCount"  visible="true" runat="server" ><%#Eval("Dislike_num")%>:Dislike      </Label>
        </div>
               <div class="w3-container w3-card w3-white w3-round w3-margin">

                    <asp:Image ID="photoim" height="70px" Width="70px" ImageUrl='<%# FindImage(Eval("PostId")) %>' runat="server" />

                     </div>
              
                <div class="w3-container w3-card w3-white w3-round w3-margin"><br>
      
                    <td><asp:LinkButton ID="lnkSil" runat="server" class="w3-button w3-theme-d1 w3-margin-bottom" CommandArgument='<%# Eval("PostId") %>' CommandName="like" Text="like"><i class="fa fa-thumbs-up"></i>Like</asp:LinkButton></td>
                    <td><asp:LinkButton ID="lnkDislike" runat="server" class="w3-button w3-theme-d1 w3-margin-bottom" CommandArgument='<%# Eval("PostId") %>' CommandName="dislike" Text="dislike"></i>Dislike</asp:LinkButton></td>
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

