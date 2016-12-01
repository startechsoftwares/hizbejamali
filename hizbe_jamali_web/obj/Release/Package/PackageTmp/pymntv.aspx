<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pymntv.aspx.vb" Inherits="Hizbe_Jamali_Web.pymntv" %>

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
            <asp:TableCell><asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        
       </asp:Table>
        </h3>
     
    </div>
  </div>

  
  <!-- Begin top content -->
 <div id="content">
 <div id="contact_us_left_coloumn">
 <h2>Payment Voucher</h2>
  <div class="dotted_line"></div>
    
       
       <asp:Table ID="Table2" runat="server" Width="100%">
        <asp:TableRow>
        <asp:TableCell Width="15%"><h4><asp:Label ID="Label1" runat="server" Text="From:-"></asp:Label></h4></asp:TableCell>
        <asp:TableCell Width="35"><asp:TextBox ID="txtDateF" runat="server" MaxLength="100" ></asp:TextBox>
        <img src="images/cal.gif" onclick="javascript:NewCssCal('txtDateF')" style="cursor:pointer"/></asp:TableCell>
        <asp:TableCell Width="15%"><h4><asp:Label ID="Label6" runat="server" Text="To:-"></asp:Label></h4></asp:TableCell>
        <asp:TableCell Width="35"><asp:TextBox ID="txtDateT" runat="server" MaxLength="100" ></asp:TextBox>
        <img src="images/cal.gif" onclick="javascript:NewCssCal('txtDateT')" style="cursor:pointer"/></asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        
        <asp:Table ID="Table3" runat="server" Width="100%" >
        <asp:TableRow>
        <asp:TableCell Width="15%"><h4><asp:Label ID="Label3" runat="server" Text="Member:-"></asp:Label></h4></asp:TableCell>
        <asp:TableCell Width="85%"><asp:DropDownList ID="cboxMemberName" runat="server" CssClass="cbox"></asp:DropDownList></asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        
        
        <asp:Table ID="Table5" runat="server" Width="100%" >
        <asp:TableRow>
        <asp:TableCell Width="10%"><asp:Button ID="btnNew" runat="server" Text="New Voucher" CssClass="button" /></asp:TableCell>
        <asp:TableCell Width="80%"><asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" /></asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        
        <asp:Table ID="Table6" runat="server" Width="100%" >
        <asp:TableRow>
        <asp:TableCell Width="100%">
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false"
        GridLines="None" HeaderStyle-Width="100px" CssClass="mGrid" AllowPaging="True" Width="100%" onpageindexchanging="GridView2_PageIndexChanging"  
        onrowcancelingedit="GridView2_RowCancelingEdit"  
        onrowdatabound="GridView2_RowDataBound" onrowdeleting="GridView2_RowDeleting"  
        onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating" PagerSettings-PageButtonCount="20" PageSize="20">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
        <asp:CommandField ShowEditButton="True" /> 
        <asp:CommandField ShowDeleteButton="True" /> 
       <asp:BoundField DataField="JVNo" HeaderText="No" ReadOnly="True" SortExpression="JVNo" /> 
        <asp:BoundField DataField="DOJ" HeaderText="Date" ReadOnly="True" SortExpression="DOJ" DataFormatString="{0:MM/dd/yyyy}"  /> 
      
        <asp:TemplateField HeaderText="Member's Name" SortExpression="Account_Name"> 
            <EditItemTemplate><asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Account_Name") %>'></asp:TextBox></EditItemTemplate> 
            <ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%# Bind("Account_Name") %>'></asp:Label></ItemTemplate> 
        </asp:TemplateField> 
        
             
        <asp:TemplateField HeaderText="FCY" SortExpression="FCY"> 
            <EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FCY") %>'></asp:TextBox></EditItemTemplate> 
            <ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("FCY") %>'></asp:Label></ItemTemplate> 
        </asp:TemplateField> 
        
        <asp:TemplateField HeaderText="Amount" SortExpression="Amount" ItemStyle-HorizontalAlign="Right"> 
            <EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Amount", "{0:n}") %>'></asp:TextBox></EditItemTemplate> 
            <ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("Amount" , "{0:n}") %>'></asp:Label></ItemTemplate> 
            
        </asp:TemplateField>
        
                
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Width="100%" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
       <FooterStyle BackColor="#99CCCC" ForeColor="#003399" /> 
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" /> 
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" /> 
    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" /> 
        </asp:GridView> 
       

        </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        </div>
    <asp:Label ID="lblresult" runat="server"/>
        <asp:Button ID="btnShowPopup" runat="server" style="display:none" />
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
        </asp:ModalPopupExtender>

        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="320px" Width="400px" style="display:none">
        <table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
        <tr style="background-color:#D55500">
<td colspan="2" style=" height:10%; color:White; font-weight:bold; font-size:larger" align="center">Member's Details</td>
</tr>
<tr>
<td style=" width:45%">
Trans No:
</td>
<td>
<asp:Label ID="lblTNo" runat="server"></asp:Label>
</td>
</tr>
<tr>
<td>
Date
</td>
<td>
<asp:TextBox ID="txtDate" runat="server" MaxLength="100" ></asp:TextBox>
<img src="images/cal.gif" onclick="javascript:NewCssCal('txtDate')" style="cursor:pointer"/>
</td>
</tr>
<tr>
<td>
Name:
</td>
<td>
<asp:DropDownList ID="cboxSname" runat="server" CssClass="cbox"></asp:DropDownList>
</td>
</tr>
<tr>
<td>
Narration:
</td>
<td>
<asp:TextBox ID="txtNarration" runat="server" MaxLength="100" CssClass="tb5a" onfocus="SetTextInTextBox2()"></asp:TextBox>
</td>
</tr>
<tr>
<td>
FCY:
</td>
<td>
<asp:DropDownList ID="cboxFCY" runat="server"></asp:DropDownList>
</td>
</tr>
<tr>
<td>
Amount:
</td>
<td>
<asp:TextBox ID="txtAmount" runat="server" MaxLength="100" ></asp:TextBox>
</td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" />
</td>
</tr>
</table>


</asp:Panel>
            
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
