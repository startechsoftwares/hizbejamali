<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="zaereen.aspx.vb" Inherits="Hizbe_Jamali_Web.zaereen" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
            <asp:TableCell>Logged As:-</asp:TableCell>
            <asp:TableCell><asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="Label4" runat="server" Text="Account Balance:-"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="lblAccountBal" runat="server"></asp:Label></asp:TableCell>
        </asp:TableRow>
       </asp:Table>
        </h3>
     
    </div>
  </div>

  
  <!-- Begin top content -->
 <div id="content">
 <div id="contact_us_left_coloumn">
  <h2>Zaereen's Information</h2>
  <div class="dotted_line"></div>
        <asp:Table ID="Table1" runat="server" Width="100%">
            <asp:TableRow>
            <asp:TableCell><asp:Label ID="Label3" runat="server" Text="Total Amount spent on Zaereen:-" CssClass="label"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:Label ID="lblTotal" runat="server" Text="" CssClass="label1"></asp:Label></asp:TableCell>
            </asp:TableRow>
             
            </asp:Table>
      
        <asp:Table ID="Table6" runat="server" Width="100%" >
        <asp:TableRow>
        <asp:TableCell Width="100%">
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
        GridLines="None" HeaderStyle-Width="100px" CssClass="mGrid" AllowPaging="True" Width="100%" onpageindexchanging="GridView2_PageIndexChanging"  
        onrowcancelingedit="GridView2_RowCancelingEdit"  
        onrowdatabound="GridView2_RowDataBound" onrowdeleting="GridView2_RowDeleting"  
        onrowediting="GridView2_RowEditing" onrowupdating="GridView2_RowUpdating" PagerSettings-PageButtonCount="20" PageSize="20" ShowHeader="true">
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <Columns>
        <asp:CommandField ShowEditButton="True" EditText="View" ControlStyle-Font-Underline="True" /> 
       <asp:BoundField DataField="Account_No" HeaderText="S.No" ReadOnly="True" SortExpression="Account_No" /> 
       <asp:BoundField DataField="Ejamaat" HeaderText="Ejamaat" ReadOnly="True" SortExpression="Ejamaat" /> 
       <asp:BoundField DataField="DOJ" HeaderText="Date" ReadOnly="True" SortExpression="DOJ" DataFormatString="{0:MM/dd/yyyy}" /> 
       <asp:BoundField DataField="Zaereen_Name" HeaderText="Zaereen Name" ReadOnly="True" SortExpression="Zaereen_Name" /> 
       
                
      <asp:TemplateField HeaderText="Trip Exp" SortExpression="TripExp" ItemStyle-HorizontalAlign="Right"> 
            <EditItemTemplate><asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("TripExp", "{0:n}") %>'></asp:TextBox></EditItemTemplate> 
            <ItemTemplate><asp:Label ID="Label2" runat="server" Text='<%# Bind("TripExp" , "{0:n}") %>'></asp:Label></ItemTemplate> 
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

          
        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="600px" Width="600px" style="display:none">
        <table width="100%" style="border:Solid 3px #D55500; width:100%; height:100%" cellpadding="0" cellspacing="0">
        <tr style="background-color:#D55500">
<td colspan="2" style=" height:2%; color:White; font-weight:bold; font-size:larger" align="center">Member's Details</td>
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
Ejamaat ID:
</td>
<td>
<asp:Label ID="txtEjamaat" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Zaereen Name:
</td>
<td>
<asp:Label ID="txtName" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Age:
</td>
<td>
<asp:Label ID="txtAge" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Mobile:
</td>
<td>
<asp:Label ID="txtContact" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Date Of Journey:
</td>
<td>
<asp:Label ID="txtDate" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Trip Days:
</td>
<td>
<asp:Label ID="txtTripDays" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Occupation:
</td>
<td>
<asp:Label ID="txtOccupation" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Address:
</td>
<td>
<asp:Label ID="txtAddress" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Remarks
</td>
<td>
<asp:Label ID="txtRemarks" runat="server" Text="Label" BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Financial Status
</td>
<td>
<asp:Label ID="txtStatus" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
Trip Expense:
</td>
<td>
<asp:Label ID="txtTripExp" runat="server" Text="Label"  BorderStyle="Solid" BorderWidth="1px" BorderColor="#CCCCCC"></asp:Label>
</td>
</tr>
<tr>
<td>
</td>
<td>
</td>
</tr>
<tr>
<td>
</td>
<td>
<asp:Button ID="btnCancel" runat="server" Text="Close" CssClass="button" />
</td>
</tr>
</table>


</asp:Panel>        

  <div id="contact_us_right_coloumn">
      <h2>Menu</h2>
      <h1 style="font-size: large">
      <ul>
        <li><a class="menulink" href="homemember.aspx">Home</a></li>
        <li><a class="menulink" href="profile.aspx">Statement Of Account</a></li>
        <asp:Literal ID="litMenuLink" runat="server"></asp:Literal>
        <%--<li><a class="menulink" href="membercashflow.aspx">Cash Flow</a></li>--%>
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
