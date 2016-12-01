<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="foster.aspx.vb" Inherits="Hizbe_Jamali_Web.foster" %>

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
    <link rel="stylesheet" type="text/css" media="screen" href="css/nivo-slider.css" />
    <!-- Link to the Pretty Photo CSS style -->
    <link rel="stylesheet" type="text/css" media="screen" href="css/prettyPhoto.css" />

    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

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
    <script src="js/equal-height.js" type="text/javascript"></script>
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
    <style>
        .label {
            color: #000;
            font-size: 100%;
        }

        #contact_us_left_coloumn table td {
            font-size: 14px;
            font-weight: bold;
            font-family: 'Trebuchet MS';
            text-align: center;
        }

        .panel-title a:hover {
            text-decoration: none;
        }

        .mGrid tr {
            text-shadow: none;
            font-family: 'Trebuchet MS';
        }

        .mGrid th {
            font-size: 100%;
            text-align: center;
        }

        td.name {
            text-align: left !important;
        }

        .panel-heading .accordion-toggle:after {
            /* symbol for "opening" panels */
            font-family: 'Glyphicons Halflings';  /* essential for enabling glyphicon */
            content: "\2212";    /* adjust as needed, taken from bootstrap.css */
            float: left;        /* adjust as needed */
            margin-right: 10px;
            color: grey;         /* adjust as needed */
        }
        .panel-heading .accordion-toggle.collapsed:after {
            /* symbol for "collapsed" panels */
            content: "\002b";    /* adjust as needed, taken from bootstrap.css */
        }

/*

        .panel-heading:before {
            content: "\002b";
            font-size: 25px;
            font-weight: bold;
            float: left;
            margin-left: -5px;
            margin-top: -8px;
            margin-right: 10px;
        }
        .panel-heading:after {
            content: "\2212";
            font-size: 25px;
            font-weight: bold;
            float: left;
            margin-left: -5px;
            margin-top: -8px;
            margin-right: 10px;
        }
*/
    </style>
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
                                <asp:TableCell>Logged As:-</asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="Label4" runat="server" Text="Account Balance:-"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblAccountBal" runat="server"></asp:Label>
                                </asp:TableCell>
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

                    <table width="100%">
                        <tr>
                            <td style="text-align: right !important;">
                                <span style="font: bold 18px trebuchet MS;">Total Amount Spent in Fostership:&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTotal" runat="server" Text="" CssClass="label1"></asp:Label></span>
                            </td>
                        </tr>
                    </table>

                    <asp:Table ID="Table6" runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell Width="100%">
                                <asp:GridView ID="grdFoster" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"
                                    GridLines="None" HeaderStyle-Width="100px" CssClass="mGrid" AllowPaging="True" Width="100%" OnPageIndexChanging="grdFoster_PageIndexChanging"
                                    OnRowCommand="grdFoster_RowCommand"
                                    PagerSettings-PageButtonCount="20" PageSize="20" ShowHeader="true">
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <Columns>
                                        <asp:ImageField DataImageUrlField="Photo" HeaderText="Photo" ControlStyle-Height="50" ControlStyle-Width="50"></asp:ImageField>
                                        <asp:TemplateField HeaderText="ITS ID">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkITS" runat="server" Text='<%# Eval("ITSID")%>' CommandName='<%# Eval("ITSID")%>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FullName" HeaderText="Name" ReadOnly="True" SortExpression="FullName" ItemStyle-CssClass="name" />
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact" ReadOnly="True" SortExpression="ContactNumber" />
                                        <asp:BoundField DataField="TotalFosterAmount" HeaderText="Initial" ReadOnly="True" SortExpression="TotalFosterAmount" ItemStyle-Width="12%" />
                                        <asp:BoundField DataField="TotalRecurringAmount" HeaderText="Recurring" ReadOnly="True" SortExpression="TotalRecurringAmount" ItemStyle-Width="5%" />
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
                <asp:Label ID="lblresult" runat="server" />
                <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
                    CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
                </asp:ModalPopupExtender>


                <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Width="600px" Style="display: none; padding: 20px; margin-top: -10% !important; border: 5px solid #ccc; box-shadow: 0 5px 30px #000;">

                    <div class="panel-group" id="accordion">
                        <asp:Repeater ID="rptFosterGroups" runat="server" OnItemDataBound="rptFosterGroups_ItemDataBound">
                            <ItemTemplate>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a data-toggle="collapse" class="accordion-toggle collapsed" data-parent="#accordion" href='#collapse<%# Container.ItemIndex%>'>
                                                <asp:Label ID="lblGroupName" runat="server" Style="font-size: 16px; text-transform: uppercase; font-weight: bold; font-family: 'Trebuchet MS';" Text='<%# String.Format("{0}", Eval("GroupName"))%>'></asp:Label>
                                                <asp:Label ID="lblTotal" runat="server" CssClass="badge" Style="float: right;"></asp:Label>
                                            </a>
                                            <asp:HiddenField ID="hdnGroupID" runat="server" Value='<%# Eval("GroupID")%>' />
                                        </h4>
                                    </div>
                                    <div id='collapse<%# Container.ItemIndex%>' class="panel-collapse collapse">
                                        <div class="panel-body" style="overflow: hidden; min-height: 200px; height: 200px; overflow-y: auto">
                                            <div class="row">
                                                <asp:Repeater ID="rptFosterItems" runat="server" OnItemDataBound="rptFosterItems_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="col-md-12">
                                                            <div style="background: #f5f5f5; padding: 5px; margin-bottom: 5px; font-size: 14px; font-family: 'Trebuchet MS'; color: #000; text-transform: capitalize;">
                                                                <%# Eval("ItemName") %>
                                                                <asp:Label ID="lblAmount" runat="server" CssClass="badge" Style="float: right;"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>
                                            <div style="height: 10px;"></div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:Button ID="btnCancel" runat="server" Text="Close" CssClass="button" />
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
                <div id="footer_left_coloumn">Copyright © 2013 hizbejamali.com.  </div>

                <div id="footer_right_coloumn">All Rights Reserved</div>
            </div>
            <!-- End footer -->
        </div>
    </form>
    <script>
        $(function () {
            $(".accordion").accordion();
        });

        $(window).load(function () {
            equalheight('.foster-items');
        });


    </script>
</body>
</html>
