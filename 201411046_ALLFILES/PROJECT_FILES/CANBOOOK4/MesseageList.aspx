﻿<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="MesseageList.aspx.cs" Inherits="MesseageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
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
    
    <div>
          <asp:Label ID="Label1" runat="server" Text="Messeage List: "></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlReceiver" OnSelectedIndexChanged="ddlEnter_SelectedIndexChanged" runat="server">
            <asp:ListItem>Select a sender name...</asp:ListItem>
        </asp:DropDownList>

        &nbsp;<asp:Button ID="btnOK" runat="server" Text="OK"  />
            <asp:Repeater ID="rptCategories" runat="server" OnItemCommand="rptCategories_ItemCommand"> 
           
         
           <ItemTemplate>
              
                       <div class="w3-container w3-card w3-white w3-round w3-margin">
                    <asp:Image ID="Image1" height="70px" Width="70px" class="w3-left w3-circle w3-margin-right" ImageUrl='<%# FindAvatar(Eval("MessageId")) %>' runat="server" />
                     <Label ID="lblId"  visible="true" runat="server" ><%# FindSenderName(Eval("MessageId")) %></Label>
               <Label ID="lblSurname" visible="true" runat="server" ><%# FindSenderSurName(Eval("MessageId")) %></Label>
               </div>
    <div class="w3-container w3-card w3-white w3-round w3-margin">
         <hr class="w3-clear">
          <p><%#Eval("MessageText") %></p>
 
        <br />

     
        </div>
               
              
                <div class="w3-container w3-card w3-white w3-round w3-margin"><br>
      
                   
                    <td><asp:LinkButton ID="lnkDelete" runat="server" class="w3-button w3-theme-d1 w3-margin-bottom" CommandArgument='<%# Eval("MessageId") %>' CommandName="delete" Text="delete"></i>Delete</asp:LinkButton></td>
                   

    </tr>
</AlternatingItemTemplate>
<FooterTemplate>
        </tbody>
    </table> 
</FooterTemplate>
          </asp:Repeater>

        
      &nbsp;

        
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

