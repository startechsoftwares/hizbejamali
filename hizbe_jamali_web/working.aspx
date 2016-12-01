<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="working.aspx.vb" Inherits="Hizbe_Jamali_Web.working" %>


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
  <h1><span style="color:#08a5ff;">Working Method</span> </h1>
  <div class="dotted_line"></div>
 1. With Raza & Doa Mubarak of Al Hayyul Muqaddas Syedna Mohammed Burhanuddin RA Hizbe Jamali is doing azeem khidmat of sending Mumineen to Karbala Moalla & Najaf E Ashraf Ziyarat.<br /><br />
2. Monthly members contribute 500INR. Also voluntary contribution can be done.<br /><br />
3. Zaereen are selected on basis of certain criteria as follows<br />
a) Those mumineen who have not done Imam Husain As ziyarat in their lifetime<br />
b) Those mumineen who does not have muqnat to do ziyarat.<br />
c) Widow/Jobless mumineen/Mumenaat are also given preferences considering their family status<br />
d) Those mumineen suffering from severe diseases like cancer etc are also given prefererences<br /><br />
4. Zaereen are recommended by Hizbe Jamali members or any other sources also.<br /><br />
5. Once Zaereen are short listed, detail investigation is done by working committee thru jamaat and personal level<br /><br />
6. Once Zaereen are selected after investigation, all details related to Zaereen is emailed to all members of Hizbe jamali to keep all records transparent. This is to ensure that all members should know Zaereen details and to motivate members to participate in this khidmat more actively.<br /><br />
7. Working committee holds the responsibility to arrange passport, tickets and other documents related to Zaereen travel. <br /><br />
8. Decisions taken by working committee are final. At the same time suggestions & recommendation of all Hizbe Jamali members will be more valuable asset.<br /><br />
9. Hizbe Jamali members does this azeem khidmat solely for Al Hayyul Muqaddas Syedna Mohammed Burhanuddin RA and Ali Qadar Syedna Mufaddal Moula TUS khushi Mubarak. <br /><br />


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
</body>
</html>
