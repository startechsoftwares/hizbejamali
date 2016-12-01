<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="repcash2.aspx.vb" Inherits="Hizbe_Jamali_Web.repcash2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
<script src="js/datetimepicker_css.js"></script>
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
      <asp:Table ID="Table7" runat="server">
        <asp:TableRow>
            <asp:TableCell>Group Leader:-</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        
       </asp:Table>
        </h3>
     
    </div>
  </div>

  
  <!-- Begin top content -->
 <div id="content">
 <div id="contact_us_left_coloumn">
  <h2>Cash Flow Statement - II</h2>
  <div class="dotted_line"></div>
    
      This page is under construction
        
       
  </div>
  <div id="contact_us_right_coloumn">
      <h2>Menu</h2>
      <h1 style="font-size: large">
      <ul>
       <li><a class="menulink" href="homeadmin.aspx">Home</a></li>
        <li><a class="menulink" href="mastermember.aspx">Member's Ledger</a></li>
        <li><a class="menulink" href="masterzaereen.aspx">Zaereen's Ledger</a></li>
        <li><a class="menulink" href="mastertravel.aspx">Travel Agent's Ledger</a></li>
        <li><a class="menulink" href="masterleader.aspx">Group Leader Ledger</a></li>
        <li><a class="menulink" href="rcptv.aspx">Receipt Voucher</a></li>
        <li><a class="menulink" href="pymntv.aspx">Payment Voucher</a></li>
        <li><a class="menulink" href="trfv.aspx">Transfer Voucher</a></li>
        <li><a class="menulink" href="repsoa.aspx">Statement Of Account</a></li>
        <li><a class="menulink" href="repcash1.aspx">Cash Flow - I</a></li>
        <li><a class="menulink" href="repcash2.aspx">Cash Flow - II</a></li>
        <li><a class="menulink" href="formZaereen.aspx">Zaereen's Verification Form</a></li>
        <li><a class="menulink" href="repzaereenverify.aspx">Zaereen's Verification Report</a></li>
          <li><a class="menulink" href="changepassword.aspx">Change Password</a></li>
        <li><a class="menulink" href="login.aspx">Log Out</a></li>
      </ul>
      </h1>
  </div>
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
