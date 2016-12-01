<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="form.aspx.vb" Inherits="Hizbe_Jamali_Web.form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<title>Hizbe Jamali</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<!-- Link to the site's main CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href="css/style.css" />
<!-- Link to the Superfish menu CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href="css/superfish.css" />
<!-- Link to the Nivo Slider CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href="css/nivo-slider.css"  />
<!-- Link to the Pretty Photo CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href="css/prettyPhoto.css" />
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
<!-- Cufon scripts -->
<script type="text/javascript" src="js/cufon-yui.js"></script>
<script type="text/javascript" src="js/ScriptMT_700.font.js"></script>
<script type="text/javascript" src="js/Androgyne_400.font.js"></script>
<!-- Superfish scripts -->
<script type="text/javascript" src="js/hoverIntent.js"></script>
<script type="text/javascript" src="js/superfish.js"></script>
<!-- Nivo Slider script -->
<script src="js/jquery.nivo.slider.pack.js" type="text/javascript"></script>
<!-- Custom JS script -->
<script src="js/custom.js" type="text/javascript"></script>
<!-- PrettyPhoto script -->
<script src="js/jquery.prettyPhoto.js" type="text/javascript"></script>
<!-- Define which elements should be replaced with Cufon -->
<script type="text/javascript">  
Cufon.replace('#header #right_section ul.top_navigation li a.menulink', { fontFamily: 'Androgyne', hover: 'true', textShadow: '1px 1px 1px #fff' });
Cufon.replace('h1', { fontFamily: 'ScriptMT', textShadow: '1px 1px 1px #fff' });
Cufon.replace('h2', { fontFamily: 'ScriptMT', textShadow: '1px 1px 1px #fff' });
</script>
<!-- Superfish menu options -->
<script type="text/javascript"> 
$(document).ready(function(){ 
	$("ul.top_navigation").superfish(); 
}); 
</script>
<!-- Nivo Slider options -->
<script type="text/javascript">
$(window).load(function() {
    $('#slider').nivoSlider();
});
</script>
<!-- PrettyPhoto options -->
<script type="text/javascript" charset="utf-8">
$(document).ready(function(){
	$("a[rel^='prettyPhoto']").prettyPhoto();
});
</script>
</head>

<body> 
<form id="form1" runat="server">

<div id="wrapper">
  <!-- Begin header -->
  <div id="header" align="center">
   <div id="left_section"><img src="images/logo.png" width="349" height="80" border="0" alt="" class="logo" /></div>
    <div id="right_section" style="width: 500px; ">
      <br />
      <br />
      <h3>
      </h3>
     
    </div>
  </div>

  
  <!-- Begin top content -->
 <div id="content">

 <h2>Member's Registeration Form</h2>
  <div class="dotted_line"></div>
    
       
                 
               
<table width="100%">
<tr>
<td>
E-Jamaat ID:
</td>
<td>
<asp:TextBox ID="txtEjamaatAJ" runat="server" Width="200px" AutoPostBack="True" MaxLength="8"></asp:TextBox>
<asp:Label ID="lblEjamaat" runat="server" ForeColor="#FF3300"></asp:Label>
</td>
</tr>
<tr>
<td>
Member Name:
</td>
<td>
<asp:TextBox ID="txtMemberNameAJ" runat="server" CssClass="tb5" Width="600px"></asp:TextBox>
<asp:Label ID="lblMember" runat="server" ForeColor="#FF3300"></asp:Label>
</td>
</tr>
<tr>
<td>
Group Leader:
</td>
<td>
<asp:DropDownList ID="cboxGrpLeaderAJ" runat="server" CssClass="cbox" Width="200px"></asp:DropDownList>
<asp:Label ID="lblLeader" runat="server" ForeColor="#FF3300"></asp:Label>
</td>
</tr>
<tr>
<td>
Mobile:
</td>
<td>
<asp:TextBox ID="txtMobileAJ" runat="server" CssClass="tb5small" Width="200px"></asp:TextBox>
<asp:Label ID="lblMobile" runat="server" ForeColor="#FF3300"></asp:Label>
</td>
</tr>
<tr>
<td>
Email:
</td>
<td>
<asp:TextBox ID="txtEmailAJ" runat="server" CssClass="tb5" Width="300px"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Country:
</td>
<td>
<asp:DropDownList ID="cboxCountryAJ" runat="server" CssClass="cbox" Width="200px"></asp:DropDownList>
<asp:Label ID="lblCountry" runat="server" ForeColor="#FF3300"></asp:Label>
</td>
</tr>

<tr>
<td colspan="2">
<asp:Label ID="lblDuplicate" runat="server" ForeColor="#FF3300"></asp:Label>
</td>
</tr>

<tr>
<td colspan="2">
<asp:Button ID="btnSubmit" runat="server" Text="Submit" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</td>
</tr>
</table>

       
       

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
