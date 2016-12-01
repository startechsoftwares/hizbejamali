<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="repzaereenverify.aspx.vb" EnableEventValidation="false" Inherits="Hizbe_Jamali_Web.repzaereenverify" %>

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
    <link rel="stylesheet" type="text/css" media="screen" href="css/nivo-slider.css" />
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
        $(document).ready(function () {
            $("ul.top_navigation").superfish();
        });
    </script>
    <!-- Nivo Slider options -->
    <script type="text/javascript">
        $(window).load(function () {
            $('#slider').nivoSlider();
        });
    </script>
    <!-- PrettyPhoto options -->
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $("a[rel^='prettyPhoto']").prettyPhoto();
        });


    </script>

    <%--<script language="javascript" type="text/javascript">
    function CallPrint(strid) {
        var prtContent = document.getElementById(strid);
        var WinPrint = window.open('', '', 'letf=-1,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }
</script>--%>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
         var printWindow = window.open('', '', 'height=1,width=1');
         printWindow.document.write(panel.innerHTML);
         printWindow.document.close();
         setTimeout(function () {
             printWindow.print();
         }, 500);
         return false;
     }
    </script>
</head>

<body>

    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <form id="form1" runat="server">
        <div id="wrapper">
            <!-- Begin header -->
            <div id="header" align="center">
                <div id="left_section">
                    <img src="images/logo.png" width="349" height="80" border="0" alt="" class="logo" /></div>
                <div id="right_section" style="width: 500px;">
                    <br />
                    <br />
                    <h3>
                        <asp:Table ID="Table7" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>Group Leader:-</asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label></asp:TableCell>
                            </asp:TableRow>

                        </asp:Table>
                    </h3>

                </div>
            </div>

            <asp:PlaceHolder ID="plcErrorMessage" runat="server" Visible="false">
                <asp:Label Style="padding: 20px 0; color: red; display: block;" ID="lblError" runat="server">You are not authorized to access this page.
                    <asp:HyperLink ID="lnkDashBoard" runat="server" Style="text-decoration: underline; color: red;">Go back to your members page now</asp:HyperLink>
                </asp:Label>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="plcMainContent" runat="server" Visible="false">
                <!-- Begin top content -->
                <div id="content">
                    <div id="contact_us_left_coloumn">
                        <h2>Zaereen's Verification Form</h2>
                        <div class="dotted_line"></div>


                        <asp:Table ID="Table2" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label1" runat="server" Text="Filter Records By:- "></asp:Label></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label2" runat="server" Text="Status: "></asp:Label></asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="cboxStatusZ" runat="server" AutoPostBack="True"></asp:DropDownList></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Button ID="btnExcel" runat="server" Text="Export To Excel" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblMissing" runat="server" Text="** Please fill up all details" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>



                        <asp:Table ID="Table6" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell Width="100%">
                                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" GridLines="None" HeaderStyle-Width="100px" CssClass="mGrid" AllowPaging="True" Width="100%" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" PagerSettings-PageButtonCount="20" PageSize="20" AllowSorting="False">
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <Columns>

                                            <asp:CommandField ShowSelectButton="True" SelectText="View" />
                                            <asp:CommandField ShowEditButton="True" />
                                            <asp:CommandField ShowDeleteButton="True" />

                                            <asp:BoundField DataField="Account_No" HeaderText="S.No" ReadOnly="True" SortExpression="Account_No" />
                                            <asp:BoundField DataField="DOJ" HeaderText="Date" ReadOnly="True" SortExpression="DOJ" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField DataField="Zaereen_Name" HeaderText="Zaereen Name" ReadOnly="True" SortExpression="Zaereen_Name" />
                                            <asp:BoundField DataField="Age" HeaderText="Age" ReadOnly="True" SortExpression="Age" />

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
                    <div id="bill">
                        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
                        <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="600px" Width="1000px" Style="display: none">
                            <asp:Panel ID="pnlContents" runat="server">
                                <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                                    <tr style="background-color: #D55500">
                                        <td colspan="1" style="height: 5%; color: White; font-weight: bold; font-size: larger" align="left">
                                            <img src="images/logo.png" width="120" height="100" border="0" alt="" class="logo" /></td>
                                        <td colspan="3" style="height: 5%; color: White; font-weight: bold; font-size: xx-large; font-family: 'Times New Roman';" align="center">Zaereen Verification Form</td>
                                    </tr>
                                    <tr>
                                        <td width="250px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Trans No:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="lblTNo" runat="server" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="250px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Date:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtDate" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">ITS ID:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtEjamaat" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Zaereen Name:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtName" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Gender:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtGender" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Age:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtAge" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Contact Number:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtContact" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Occupation:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtOccupation" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Telephone1:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtContact1" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Telephone2:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtContact2" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Rec By Member:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtRecMem" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Rec By Core Team:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtRecMemHJ" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Member's Contact:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtContactMember" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Leader's Contact:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtContactLeader" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Monthly Income:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtIncome" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Monthly Exp:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtExp" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Deeni She'aar:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:CheckBox ID="chkbxDadi" runat="server" Text="Dadi" Font-Names="Arial" />
                                            <asp:CheckBox ID="chkbxTopi" runat="server" Text="Topi" Font-Names="Arial" />
                                            <asp:CheckBox ID="chkbxRida" runat="server" Text="Rida" Font-Names="Arial" />
                                            <asp:CheckBox ID="chkbxMoharramat" runat="server" Text="Moharramat Safai" Font-Names="Arial" />
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">No Of Dependents:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtDependants" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Jamaa Raqam:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtJama" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Raqam Niyyat:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtNiyyat" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Overseas Ziyarat:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtZiyarat" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">If Yes, Names:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtZiyaratName" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Medical Fitness:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtMedical" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Address:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtAddress" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Passport Validity
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtPPVal" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">If Yes, Expiry Date
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtPPExp" runat="server" Text="Label" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Status:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:DropDownList ID="cboxStatus" runat="server" Font-Names="Arial" Width="100px"></asp:DropDownList>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Remarks
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:Label ID="txtRemarks" runat="server" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Amount Sanctioned:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:TextBox ID="txtSanction" runat="server" CssClass="tb5" Font-Names="Arial"></asp:TextBox>
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial; font-weight: bold;">Comment:
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:TextBox ID="txtComment" runat="server" CssClass="tb5a" Font-Names="Arial" TextMode="MultiLine"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin" colspan="4">
                                            <asp:Label ID="lblremarks" runat="server" Font-Bold="True" ForeColor="Red" Font-Names="Arial"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="200px" style="border-style: solid; border-width: thin" colspan="2">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" Width="100px" BorderStyle="Solid" BorderColor="Black" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Width="100px" BorderStyle="Solid" BorderColor="Black" />
                                            <asp:Button ID="BtnPrint" runat="server" Text="Print" OnClientClick="return PrintPanel();" Width="100px" BorderStyle="Solid" BorderColor="Black" />
                                        </td>
                                        <td width="200px" style="border-style: solid; border-width: thin; font-family: Arial;">Travelled By:
                                        </td>
                                        <td width="400px" style="border-style: solid; border-width: thin; font-family: Arial;">
                                            <asp:DropDownList ID="cboxTravelled" runat="server" Font-Names="Arial" Width="200px"></asp:DropDownList>
                                    </tr>



                                </table>
                            </asp:Panel>
                        </asp:Panel>
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
                                <%--<li><a class="menulink" href="pymntv.aspx">Payment Voucher</a></li>
        <li><a class="menulink" href="trfv.aspx">Transfer Voucher</a></li>--%>
                                <li><a class="menulink" href="repsoa.aspx">Statement Of Account</a></li>
                                <%--<li><a class="menulink" href="repcash1.aspx">Cash Flow - I</a></li>
        <li><a class="menulink" href="repcash2.aspx">Cash Flow - II</a></li>--%>
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
            </asp:PlaceHolder>
            <!-- Start footer -->
            <div id="footer">
                <div id="footer_left_coloumn">Copyright © 2013 hizbejamali.com.  </div>

                <div id="footer_right_coloumn">All Rights Reserved</div>
            </div>
            <!-- End footer -->
        </div>
    </form>
</body>
</html>

