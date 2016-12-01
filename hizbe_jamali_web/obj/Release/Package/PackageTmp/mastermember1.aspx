<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mastermember1.aspx.vb" Inherits="Hizbe_Jamali_Web.mastermember1" %>
<%@ Register Src="~/UserControls/AddMember.ascx" TagName="AddMember" TagPrefix="hj" %>
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
                    <img src="images/logo.png" width="349" height="80" border="0" alt="" class="logo" />
                </div>
                <div id="right_section" style="width: 500px;">
                    <br />
                    <br />
                    <h3>
                        <asp:Table ID="Table7" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>Group Leader:-</asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>

                        </asp:Table>
                    </h3>

                </div>
            </div>


            <!-- Begin top content -->
            <div id="content">
                <div id="contact_us_left_coloumn">
                    <h2>Member's Registeration Form</h2>
                    <div class="dotted_line"></div>


                    <asp:Table ID="Table2" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button ID="btnSearch" runat="server" Text="New Member's Registration" />
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:CheckBox ID="chkbxShowall" runat="server" Text="Show All Members" AutoPostBack="True" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblMissing" runat="server" Text="** Please fill up all details" ForeColor="Red" Font-Bold="True" Font-Size="Medium"></asp:Label>
                            </asp:TableCell>
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

                                        <asp:BoundField DataField="Ejamaat" HeaderText="ITS ID" ReadOnly="True" SortExpression="Ejamaat" />
                                        <asp:BoundField DataField="Member_Name" HeaderText="Member's Name" ReadOnly="True" SortExpression="Member_Name" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" ReadOnly="True" SortExpression="Mobile" />

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
                <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="53%" Width="50%" Style="display: none">
                    <hj:AddMember ID="AddMember1" runat="server" />
                    <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%; display: none;" cellpadding="10" cellspacing="10">
                        <tr style="background-color: #D55500">
                            <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger" align="center">Member's Details</td>
                        </tr>
                        <tr>
                            <td style="width: 45%">E-Jamaat ID:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEjamaatAJ" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Member Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemberNameAJ" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Group Leader:
                            </td>
                            <td>
                                <asp:Label ID="lblGroupLeader" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Mobile:
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileAJ" runat="server" CssClass="tb5small"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Email:
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailAJ" runat="server" CssClass="tb5"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Country:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboxCountryAJ" runat="server" CssClass="cbox"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Status:
                            </td>
                            <td>
                                <asp:DropDownList ID="cboxStatus" runat="server" CssClass="cbox"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Photo:
                            </td>
                            <td>
                                <asp:UpdatePanel ID="updFileUploadPanel" runat="server">
                                    <ContentTemplate>
                                        <asp:FileUpload ID="fuLeader" runat="server" />
                                        <asp:Button ID="btnUploadPic" runat="server" Text="Upload Picture" OnClick="btnUploadPic_Click" />
                                        <asp:Image ID="Image1" runat="server" Width="50%" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                            </td>
                        </tr>
                    </table>

                </asp:Panel>



                <div id="contact_us_right_coloumn">
                    <h2>Menu</h2>
                    <h1 style="font-size: large">
                        <ul>
                            <li><a class="menulink" href="homeadmin1.aspx">Home</a></li>
                            <li><a class="menulink" href="mastermember1.aspx">Member's Ledger</a></li>
                            <li><a class="menulink" href="rcptv1.aspx">Receipt Voucher</a></li>
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
                <div id="footer_left_coloumn">Copyright © 2013 hizbejamali.com.  </div>

                <div id="footer_right_coloumn">All Rights Reserved</div>
            </div>
            <!-- End footer -->
        </div>
    </form>
</body>
</html>
