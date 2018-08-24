<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Hizbe_Jamali_Web.Login1" %>
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
   <div id="left_section"><img src="/images/logo.png" width="349" height="80" border="0" alt="" class="logo" /></div>
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
  <h1><span style="color:#08a5ff;">Admin Login Page</span> </h1>
  <div class="dotted_line"></div>
     <asp:Panel ID="Panel1" runat="server" DefaultButton="btnLogin">


  <table align="center" frame="box-color: #FFCC66; border-width: 5px;" width="35%" style="border-color: #000000;">
    <tr>
    <td>
          <asp:Label ID="Label1" runat="server" Text="ITS ID:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label>
    </td>
    <td>
          <asp:TextBox ID="txteJamaatID" runat="server" CssClass="tb5"></asp:TextBox>
    </td>
    </tr>
      <tr>
          <td><asp:Label ID="Label2" runat="server" Text="Password:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label></td>
          <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="tb5"></asp:TextBox></td>
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
<%--    <asp:Button Text="Member Login" BorderStyle="None" ID="Tab1" CssClass="Initial" runat="server" OnClick="Tab1_Click" />
    <asp:Button Text="Admin Login" BorderStyle="None" ID="Tab2" CssClass="Initial" runat="server" OnClick="Tab2_Click" />
   
    <asp:MultiView ID="MainView" runat="server">
    
    <asp:View ID="View1" runat="server">
        <table>
        <tr>
        <td>
        <h3>
        <span>
        <asp:Table ID="Table4" runat="server" BorderColor="#663300" >
        <asp:TableRow>
        <asp:TableCell><asp:Label ID="Label1" runat="server" Text="ITS ID:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label></asp:TableCell>
        <asp:TableCell><asp:TextBox ID="txtMember" runat="server" CssClass="tb5"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
            <asp:TableRow>
                            <asp:TableCell><asp:Label ID="Label2" runat="server" Text="Password:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="txtMemberPassword" runat="server" CssClass="tb5" TextMode="Password"></asp:TextBox></asp:TableCell>
                            </asp:TableRow>
        <asp:TableRow>
        <asp:TableCell><asp:Button ID="btnMember" runat="server" Text="Login" CssClass="button" /></asp:TableCell>
        </asp:TableRow>
        </asp:Table> 
        </span>
        </h3>
        </td>
        </tr>
        </table>
     </asp:View>
        
    <asp:View ID="View2" runat="server">
        <table>
         <tr>
         <td>
         <h3>
         <asp:Table ID="Table5" runat="server" BorderColor="#663300" >
                            <asp:TableRow>
                            <asp:TableCell><asp:Label ID="Label3" runat="server" Text="ITS ID:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="txtTeacher" runat="server" CssClass="tb5"></asp:TextBox></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                            <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Password:" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label></asp:TableCell>
                            <asp:TableCell><asp:TextBox ID="txtTeacherPW" runat="server" CssClass="tb5" TextMode="Password"></asp:TextBox></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                            <asp:TableCell><asp:Button ID="btnTeacher" runat="server" Text="Login" CssClass="button" /></asp:TableCell>
                            </asp:TableRow>
                      </asp:Table> 
                    </h3>
                  </td>
                </tr>
              </table>
            </asp:View>
          </asp:MultiView>
        </td>
      </tr>
    </table>
      <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
      <asp:TableRow>
      <asp:TableCell></asp:TableCell>
      </asp:TableRow>
      </asp:Table>--%>
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
