<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="gallery.aspx.vb" Inherits="Hizbe_Jamali_Web.gallery" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Hizbe Jamali</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<!-- Link to the site's main CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href="css/style.css" />
 <link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
<!-- Link to the Superfish menu CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href="css/superfish.css" />
<!-- Link to the Nivo Slider CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href="css/nivo-slider.css"  />
<!-- Link to the Pretty Photo CSS style -->
<link rel="stylesheet" type="text/css" media="screen" href="css/prettyPhoto.css" />
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script>
<!-- Start WOWSlider.com HEAD section --> <!-- add to the <head> of your page -->
	<link rel="stylesheet" type="text/css" href="engine1/style.css" />
	<script type="text/javascript" src="engine1/jquery.js"></script>
	<!-- End WOWSlider.com HEAD section -->
<!-- Cufon scripts -->
<script type="text/javascript" src="js/jquery-1.7.1.js" ></script>
<script type="text/javascript" src="js/scripts.js"></script>
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
  <h1><span style="color:#08a5ff;">Nawaazeshaat Album</span> </h1>
  <div class="dotted_line"></div>
   <h3>Al Hayyul Muqaddas Syedna Mohammed Burhanuddin (RA) Ziyaafat Sharaf on 3rd Zilhajj 1433 (17th oct 2012) at Khandala.<br />
   Aali Qadar Syedna Mufaddal Saifuddin Moula (TUS) Ziyaafat Sharaf on 13th Zilhajj 1433 (7th oct 2014) at Khandala.</h3>
  <%--<asp:Image ID="Image1" runat="server" ImageUrl="images/Ziyafat1.jpg" />
    <asp:Image ID="Image2" runat="server" ImageUrl="images/Ziyafat2.jpg" />--%>

  	<!-- Start WOWSlider.com BODY section --> <!-- add to the <body> of your page -->
	<div id="wowslider-container1">
	<div class="ws_images"><ul>
		<li><img src="data1/images/ziyafat2.jpg" alt="Ziyafat2" title="Ziyafat2" id="wows1_0"/></li>
		<li><img src="data1/images/ziyafat1.jpg" alt="Ziyafat1" title="Ziyafat1" id="wows1_1"/></li>
		<li><img src="data1/images/dsc_1412.jpg" alt="DSC_1412" title="DSC_1412" id="wows1_2"/></li>
		<li><img src="data1/images/dsc_1416.jpg" alt="DSC_1416" title="DSC_1416" id="wows1_3"/></li>
		<li><img src="data1/images/dsc_1421.jpg" alt="DSC_1421" title="DSC_1421" id="wows1_4"/></li>
		<li><img src="data1/images/dsc_1425.jpg" alt="DSC_1425" title="DSC_1425" id="wows1_5"/></li>
		<li><img src="data1/images/dsc_1459.jpg" alt="DSC_1459" title="DSC_1459" id="wows1_6"/></li>
		<li><img src="data1/images/dsc_1460.jpg" alt="DSC_1460" title="DSC_1460" id="wows1_7"/></li>
		<li><a href="http://wowslider.com/vf"><img src="data1/images/dsc_1859.jpg" alt="full screen slider" title="DSC_1859" id="wows1_8"/></a></li>
		<li><img src="data1/images/dsc_1861.jpg" alt="DSC_1861" title="DSC_1861" id="wows1_9"/></li>
	</ul></div>
	<div class="ws_thumbs">
<div>
		<a href="#" title="Ziyafat2"><img src="data1/tooltips/ziyafat2.jpg" alt="" /></a>
		<a href="#" title="Ziyafat1"><img src="data1/tooltips/ziyafat1.jpg" alt="" /></a>
		<a href="#" title="DSC_1412"><img src="data1/tooltips/dsc_1412.jpg" alt="" /></a>
		<a href="#" title="DSC_1416"><img src="data1/tooltips/dsc_1416.jpg" alt="" /></a>
		<a href="#" title="DSC_1421"><img src="data1/tooltips/dsc_1421.jpg" alt="" /></a>
		<a href="#" title="DSC_1425"><img src="data1/tooltips/dsc_1425.jpg" alt="" /></a>
		<a href="#" title="DSC_1459"><img src="data1/tooltips/dsc_1459.jpg" alt="" /></a>
		<a href="#" title="DSC_1460"><img src="data1/tooltips/dsc_1460.jpg" alt="" /></a>
		<a href="#" title="DSC_1859"><img src="data1/tooltips/dsc_1859.jpg" alt="" /></a>
		<a href="#" title="DSC_1861"><img src="data1/tooltips/dsc_1861.jpg" alt="" /></a>
	</div>
</div>
<span class="wsl"><a href="http://wowslider.com/vu">image carousel</a> by WOWSlider.com v6.9</span>
	<div class="ws_shadow"></div>
	</div>	
	<script type="text/javascript" src="engine1/wowslider.js"></script>
	<script type="text/javascript" src="engine1/script.js"></script>
	<!-- End WOWSlider.com BODY section -->
  </div>
 <div class="dotted_line"></div>
 
  
  <!-- End top content -->
  <div class="clear"></div>
 
    
  <!-- Start footer -->
  <div id="footer">
   <div id="footer_left_coloumn">Copyright © 2013 hizbejamali.com.  </div>
    
    <div id="footer_right_coloumn">All Rights Reserved</div>
  </div>
  <!-- End footer -->
</body>
</html>
