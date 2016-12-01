<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="formZaereen.aspx.vb" Inherits="Hizbe_Jamali_Web.formZaereen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
<asp:ToolkitScriptManager ID="ScriptManager1" runat="server"></asp:ToolkitScriptManager>
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
            <asp:TableCell><asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label><asp:Label ID="lblSession" runat="server"></asp:Label></asp:TableCell>
        </asp:TableRow>
        
       </asp:Table>
        </h3>
     
    </div>
  </div>

  
  <!-- Begin top content -->
 <div id="content">
 <div id="contact_us_left_coloumn">
 <h2>Zaereen's Verification Form</h2>
  <div class="dotted_line"></div>
    
       <asp:Table ID="Table2" runat="server">
        <asp:TableRow>
        <asp:TableCell><asp:Label ID="lblMissing" runat="server" Text="** Please fill up all details" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label></asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        
     <asp:Table ID="Table1" runat="server" CellSpacing="1" CellPadding="1">
     
     <asp:TableRow>
     <asp:TableCell>Trans No:</asp:TableCell>
     <asp:TableCell><asp:Label ID="lblTNo" runat="server"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Date:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtDate" runat="server" CssClass="tb5small"></asp:TextBox></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>ITS ID:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtEjamaat" runat="server" CssClass="tb5small"></asp:TextBox><asp:Label ID="lblEjamaat" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Zaereen's Name:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtName" runat="server" CssClass="tb5"></asp:TextBox><asp:Label ID="lblName" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Gender:</asp:TableCell>
     <asp:TableCell><asp:DropDownList ID="cboxGender" runat="server" CssClass="cbox"></asp:DropDownList></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Age:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtAge" runat="server" CssClass="tb5"></asp:TextBox><asp:Label ID="lblAge" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Contact Number:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtContact" runat="server" CssClass="tb5"></asp:TextBox><asp:Label ID="lblContact" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Telephone 1:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtContact1" runat="server" CssClass="tb5"></asp:TextBox><asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Telephone 2:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtContact2" runat="server" CssClass="tb5"></asp:TextBox><asp:Label ID="Label2" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Occupation:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtOccupation" runat="server" CssClass="tb5"></asp:TextBox><asp:Label ID="lblOccupation" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Member Recmnd:</asp:TableCell>
     <asp:TableCell><asp:DropDownList ID="cboxMember" runat="server" CssClass="cbox"></asp:DropDownList><asp:Label ID="lblRecMem" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Leader Recmnd:</asp:TableCell>
     <asp:TableCell><asp:DropDownList ID="cboxMemberAdmin" runat="server" CssClass="cbox"></asp:DropDownList><asp:Label ID="lblRemAdmin" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Deeni She'aar:</asp:TableCell>
     <asp:TableCell>
         <asp:CheckBox ID="chkbxDadi" runat="server" Text="Dadi" />
         <asp:CheckBox ID="chkbxTopi" runat="server" Text="Topi" />
         <asp:CheckBox ID="chkbxRida" runat="server" Text="Rida" />
         <asp:CheckBox ID="chkbxMoharramat" runat="server" Text="Moharramaat Safaai" />
         </asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Monthly Income:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtIncome" runat="server" CssClass="tb5small"></asp:TextBox><asp:Label ID="lblIncome" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Monthly Expenses:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtExp" runat="server" CssClass="tb5small"></asp:TextBox><asp:Label ID="lblExp" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>No Of Dependents:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtDependants" runat="server" CssClass="tb5small"></asp:TextBox><asp:Label ID="lblDependants" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Medical Condition:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtMedical" runat="server" CssClass="tb5small"></asp:TextBox><asp:Label ID="lblMedical" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Jamaa Raqam:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtJamaa" runat="server" CssClass="tb5small"></asp:TextBox><asp:Label ID="lblJamaa" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Niyyat Karbala Raqam:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtNiyyat" runat="server" CssClass="tb5small"></asp:TextBox><asp:Label ID="lblNiyyat" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Overseas Ziyarat:</asp:TableCell>
     <asp:TableCell><asp:DropDownList ID="cboxZiyarat" runat="server" CssClass="cbox"></asp:DropDownList></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>If Yes, Enter</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtZiyarat" runat="server" CssClass="tb5small"></asp:TextBox><asp:Label ID="lblZiyaratName" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>Address:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtAddress" runat="server" CssClass="tb5a"></asp:TextBox><asp:Label ID="lblAddress" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow> 
     
     <asp:TableRow>
     <asp:TableCell>Passport Validity:</asp:TableCell>
     <asp:TableCell><asp:DropDownList ID="cboxValidity" runat="server" CssClass="cbox"></asp:DropDownList></asp:TableCell>
     </asp:TableRow>
     
     <asp:TableRow>
     <asp:TableCell>If Yes, Date</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtDatePP" runat="server" CssClass="tb5small"></asp:TextBox><img src="images/cal.gif" onclick="javascript:NewCssCal('txtDatePP')" style="cursor:pointer"/><asp:Label ID="lblDatePP" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>
       
     <asp:TableRow>
     <asp:TableCell>Remarks:</asp:TableCell>
     <asp:TableCell><asp:TextBox ID="txtRemarks" runat="server" CssClass="tb5a"></asp:TextBox><asp:Label ID="lblRemarks" runat="server" ForeColor="Red" Font-Size="X-Small" Font-Bold="True"></asp:Label></asp:TableCell>
     </asp:TableRow>   
          
     <asp:TableRow>
     <asp:TableCell>Status:</asp:TableCell>
     <asp:TableCell><asp:DropDownList ID="cboxStatus" runat="server" CssClass="cbox"></asp:DropDownList></asp:TableCell>
     </asp:TableRow>
     
     </asp:Table>
     
     <asp:Table ID="Table3" runat="server">
     <asp:TableRow>
     <asp:TableCell><asp:Button ID="btnNew" runat="server" Text="New" /></asp:TableCell>
     <asp:TableCell><asp:Button ID="btnSubmit" runat="server" Text="Submit" /></asp:TableCell>
     </asp:TableRow>  
          
     </asp:Table>
         

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
