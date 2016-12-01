<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="Hizbe_Jamali_Web.login" %>
<%@ Register Src="~/StyleAndScript.ascx" TagName="Styling" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Hizbe Jamali</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<uc:Styling ID="Styling" runat="server" />
</head>
<body> 
<form id="form1" runat="server">
<div id="wrapper">
  <!-- Begin header -->
  <div id="header" align="center">
   <div id="left_section"><img src="images/logo.png" width="349" height="80" border="0" alt="" class="logo" /></div>
    <div id="right_section">
      <ul class="top_navigation">
         <li><a class="menulink" href="Default.aspx">Home</a></li>
        <li><a class="menulink" href="gallery.aspx">Nawaazeshaat</a></li>
        <li><a class="menulink" href="working.aspx">Working</a></li>
        <li><a class="menulink" href="bayaan.aspx">Bayaan</a></li>
        <li><a class="menulink" href="login.aspx">Login</a></li>
        <li><a class="menulink" href="contact.aspx">Contact</a></li>
      </ul>
    </div>
  </div>

  
  <!-- Begin top content -->
  <div id="top_content">
  <h1><span style="color:#08a5ff;">Login Page</span> </h1>
  <div class="dotted_line"></div>
     <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">

         <asp:Label ID="TimeOutMessage" runat="server" CssClass="error" Visible="false"></asp:Label>
<table align="center" frame="box" style="color: #000; width: 43%">
    <tr>
    <td>
          <asp:Label ID="Label1" runat="server" Text="ITS ID:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label>
    </td>
    <td>
          <asp:TextBox ID="txteJamaatID" runat="server" CssClass="tb5"></asp:TextBox>
    </td>
    </tr>
      <tr>
          <td>
              <asp:Label ID="Label2" runat="server" Text="Password:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label></td>
          <td>
              <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="tb5"></asp:TextBox></td>
     </tr>
    <tr>
          <td width="60%">
              <asp:Label ID="Label3" runat="server" Text="Login Type:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label></td>
          <td>
              <asp:DropDownList ID="drpAccountType" runat="server">
                  <asp:ListItem Text="KUN" Value="KUN"></asp:ListItem>
                  <asp:ListItem Text="Fostership" Value="Foster"></asp:ListItem>
              </asp:DropDownList>
          </td>
     </tr>
      <tr>
          <td><asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" /></td>
          <td><a href="/forgotpassword.aspx">Forgot Password</a></td>
      </tr>
      <tr>
          <td colspan="2" align="center">
          <asp:Label ID="lblMissing" runat="server" Visible="false" Text="** You are not registered member for Hizbe Jamali." ForeColor="Red" Font-Bold="True" Font-Size="Small"></asp:Label>
              </td>
      </tr>
</table>
        </asp:Panel>

  </div>
  <!-- End top content -->
  <div class="clear"></div>
 
  
  <div class="clear"></div>
  <div class="dotted_line"></div>
  <!-- Start footer -->
  <div id="footer">
   <div id="footer_left_coloumn">  Copyright © 2013 hizbejamali.com.  </div>
    
    <div id="footer_right_coloumn">All Rights Reserved</div>
  </div>
  <!-- End footer -->
</div>
</form>
</body>
</html>
