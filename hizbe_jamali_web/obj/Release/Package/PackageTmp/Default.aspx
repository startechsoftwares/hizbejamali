<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Hizbe_Jamali_Web._Default" %>


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
<script type="text/javascript">
    $(function () {
        blinkeffect('#txtblnk');
    })
    function blinkeffect(selector) {
        $(selector).fadeOut('slow', function () {
            $(this).fadeIn('slow', function () {
                blinkeffect(this);
            });
        });
    }
</script>
</head>
<body>
<div id="wrapper">
 <div id="txtblnk"> <p><strong><font color="red">Current Member's Count:-<asp:Label ID="lblcount" runat="server"></asp:Label></font></strong></p> </div>
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
 
  
  <div id="slider"> <img src="images/slideshow/slides/slide1.png" alt="" /> <img src="images/slideshow/slides/slide2.png" alt="" title="#htmlcaption" /> <img src="images/slideshow/slides/slide3.png" alt="" /> <img src="images/slideshow/slides/slide4.png" alt="" /> </div>
    
  <div class="dotted_line"></div>
  <!-- Begin top content -->
  <div id="top_content">
 
  <h1><span style="color:#08a5ff;">About Us</span> </h1>
   <div class="dotted_line"></div>
  Hizbe jamali was founded with raza of Al Hayyul Muqaddas Syedna Mohammed Burhanuddin RA in 1433 Hijri (March 2012 AD).<br /><br />

The main purpose to form this committee is to obtain Syedna Mohammed Burhanuddin RA & Syedna Mufaddal Moula TUS Khushi and Doa Mubarak by sending Mumineen & Mumenaat to Karbala Moalla & Najaf E Ashraf Ziyarat Mubarak.<br /><br />

We have started this azeem khidmat on the occasion of 101 ST Milad Mubarak of Syedna Mohammed Burhanuddin RA by contributing 500 INR Monthly. Initially total strength of committee was 65members and later more and more people joined the group by making monthly & voluntary contribution. Not only from Mumbai but we received overwhelming response from Dubai, Pune, Kuwait, Daress Salaam etc. On April 2012 the committee got sharaf of sending one mumin bhai to Karbala Moalla & Najaf E Ashraf Ziyarat Mubarak As months passed away strength of Hizbe Jamali got increased and Hizbe Jamali got sharaf of sending 5 more mumineen in Sept 2012 to Karbala Moalla & Najaf E Ashraf Ziyarat Mubarak <br /><br />

Meanwhile committee also got azeem sharaf of ziyafat of Syedna Mohammed Burhanuddin RA on 3 zilhajj 1433 17 oct 2012 at Khanadala.<br /><br />

After Ziyafat with the Doa Mubarak of Syedna Mohammed Burhanuddin RA the strength increased to 130 plus members and in the month of Janaury 2013 Hizbe Jamali did khidmat of sending 6 more mumineen to Karbala Moalla & Najaf E Ashraf Ziyarat Mubarak.<br />

The main objective behind making this website is to share our experience that niyyat of sending mumineen to Imam Husain AS ziyarat turned our lifestyles completely & more aala tasawwur is Imam Husain AS naa Daai gave us sharaf of Ziyafat. Also thru this website we aim to encourage people to join Hizbe Jamali.<br /><br />

Beside these milestones there're uncountable success and achievements in our members' lives individually and cummulatively with blessing and benediction of Syedna Mohammed Burhanuddin RA & Syedna Mufaddal Moula TUS. And it's now going to be manifold with barakaat and behjat of both Moulas in the days to come.<br /><br />

Our objective is for sure...<br /><br />

Khuda Syedna Mohammed Burhanuddin RA ne Janntaul Firdaus maa Afzalul Jazaa aapjo ane apnaa janasheen ane haqaan haqaa mansoos Syedna Mufaddal Saifuddin TUS ne jaha tak mumineen Karbala Moalla ni ziyarat si behrowar thata rahe waha lag aap ni umar shareef ni daraaz ane daraaz karjo. Ameen.. <br /><br />

Ameen! <br />
Shukriya & Iltemaas-ud-doa! <br />

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
