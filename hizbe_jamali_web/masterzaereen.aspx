﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="masterzaereen.aspx.vb" Inherits="Hizbe_Jamali_Web.masterzaereen" %>

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
</head>

<body>
    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ScriptManager1" runat="server"></asp:ToolkitScriptManager>
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
                        <h2>Zaereen's Registeration Form</h2>
                        <div class="dotted_line"></div>


                        <asp:Table ID="Table2" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Button ID="btnSearch" runat="server" Text="New Zaereen's Registration" /></asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblMissing" runat="server" Text="** Please fill up all details" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>

                        <asp:Table ID="Table6" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell Width="100%">
                                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" GridLines="None" HeaderStyle-Width="100px" CssClass="mGrid" AllowPaging="True" Width="100%" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting" OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" PagerSettings-PageButtonCount="20" PageSize="20">
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <Columns>

                                            <asp:CommandField ShowEditButton="True" />
                                            <asp:CommandField ShowDeleteButton="True" />

                                            <asp:BoundField DataField="Account_No" HeaderText="S.No" ReadOnly="True" SortExpression="Account_No" />
                                            <asp:BoundField DataField="Ejamaat" HeaderText="Ejamaat" ReadOnly="True" SortExpression="Ejamaat" />
                                            <asp:BoundField DataField="DOJ" HeaderText="Date" ReadOnly="True" SortExpression="DOJ" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:BoundField DataField="Zaereen_Name" HeaderText="Zaereen Name" ReadOnly="True" SortExpression="Zaereen_Name" />

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
                    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
                    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="670px" Width="600px" Style="display: none">
                        <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                            <tr style="background-color: #D55500">
                                <td colspan="2" style="height: 5%; color: White; font-weight: bold; font-size: larger" align="center">Member's Details</td>
                            </tr>
                            <tr>
                                <td style="width: 45%">Trans No:
                                </td>
                                <td>
                                    <asp:Label ID="lblTNo" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Ejamaat ID:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEjamaat" runat="server" CssClass="tb5small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Zaereen Name:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="tb5"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Age:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAge" runat="server" CssClass="tb5small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Mobile:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="tb5small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Date Of Journey:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="tb5small"></asp:TextBox>
                                    <img src="images/cal.gif" onclick="javascript:NewCssCal('txtDate')" style="cursor: pointer" />
                                </td>
                            </tr>
                            <tr>
                                <td>Trip Days:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTripDays" runat="server" CssClass="tb5small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Occupation:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOccupation" runat="server" CssClass="tb5small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Address:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="tb5a"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Remarks
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="tb5a"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Financial Status
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStatus" runat="server" CssClass="tb5a"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Trip Expense:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTripExp" runat="server" CssClass="tb5small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
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
