<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rcptv.aspx.vb" Inherits="Hizbe_Jamali_Web.rcptv" %>

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
    <link rel="stylesheet" type="text/css" href="css/jquery.fancybox.css?v=2.1.5" media="screen" />
    <script src="js/datetimepicker_css.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js" type="text/javascript"></script>
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
    <script type="text/javascript" src="js/jquery.fancybox.js"></script>
    <script type="text/javascript" src="js/jquery.fancybox.pack.js"></script>
    <script type="text/javascript">
        Cufon.replace('#header #right_section ul.top_navigation li a.menulink', { fontFamily: 'Androgyne', hover: 'true', textShadow: '1px 1px 1px #fff' });
        Cufon.replace('h1', { fontFamily: 'ScriptMT', textShadow: '1px 1px 1px #fff' });
        Cufon.replace('h2', { fontFamily: 'ScriptMT', textShadow: '1px 1px 1px #fff' });
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
            $(".fancybox").fancybox();
            $("ul.top_navigation").superfish();

            $(".save-click").click(function () {
                var txn = $('#<%= lblTNo.ClientID%>').val();
                var date = $('#<%= txtDate.ClientID%>').val();
                var memName = $('#<%= cboxSname.ClientID%> option:selected').text();
                var currency = $('#<%= cboxFCY.ClientID%>').val();
                var narration = $('#<%= txtNarration.ClientID%>').val();
                var amount = $('#<%= txtAmount.ClientID%>').val();
                var receipt_against = $('#<%= drpAccountType.ClientID%> option:selected').text();
                if (date != "" && narration != "" && amount != "") {
                    $(".txn").html(txn);
                    $(".rptdate").html(date);
                    $(".memname").html(memName);
                    $(".currency").html(currency);
                    $(".narration").html(narration);
                    $(".amount").html(amount);
                    $(".receipt").html(receipt_against);
                    $.fancybox({
                        'type': 'inline',
                        'content': $('.receipt-preview'),
                        'parent': 'form:first'
                    });
                }
                else {
                    alert("All fields are mandatory");
                }
                return false;
            });
        });

        function SetTextInTextBox2() {
            document.getElementById('txtNarration').value = "Contribution Recvd For "
        }
    </script>
    <style>
        .input {
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 8px;
            color: #424242;
            font-family: "Trebuchet MS",Arial,Helvetica,sans-serif;
            font-size: 16px;
            padding: 8px;
            cursor: default;
        }
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
                                <asp:TableCell>Group Leader:-</asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label>
                                </asp:TableCell>
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
                        <h2>Receipt Voucher</h2>
                        <div class="dotted_line"></div>



                        <table width="100%" style="border: thin solid #000000; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" width="100%">
                                    <asp:Label ID="lblMessage" runat="server" Visible="false" Style="text-shadow: none;"></asp:Label>
                                    <asp:PlaceHolder ID="plcReceiptConfirmation" runat="server" Visible="false">
                                        <div style="text-align: center; background: red; padding-bottom: 10px;">
                                            <asp:LinkButton ID="lnkYes" Style="color: #fff; text-decoration: underline;"
                                                runat="server" Text="YES" OnClick="lnkReceiptGenerationConfirm_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkNo" Style="color: #fff; text-decoration: underline; margin-left: 10px;"
                                                runat="server" Text="NO" OnClick="lnkReceiptGenerationConfirm_Click"></asp:LinkButton>
                                        </div>
                                    </asp:PlaceHolder>
                                </td>
                            </tr>
                            <tr style="background-color: #3399FF">
                                <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger" align="center" width="100%">Receipt Voucher Details</td>
                            </tr>
                            <tr>
                                <td style="width: 25%">Trans No:
                                </td>
                                <td>
                                    <asp:TextBox ID="lblTNo" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" MaxLength="100"></asp:TextBox>
                                    <img src="images/cal.gif" onclick="javascript:NewCssCal('txtDate')" style="cursor: pointer" />
                                </td>
                            </tr>
                            <tr>
                                <td>Name:
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboxSname" runat="server" CssClass="cbox" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="cboxSname_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Narration:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNarration" runat="server" MaxLength="100" CssClass="tb5a" onfocus="SetTextInTextBox2()"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>FCY:
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboxFCY" runat="server" Width="100px"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td>Amount:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount" runat="server" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Receipt Against:
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpAccountType" runat="server"></asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblNoData" runat="server" Text="Label" ForeColor="Red" Font-Bold="True"></asp:Label>
                                </td>
                                <td>
                            </tr>


                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnNew" runat="server" Text="New" CssClass="button" Width="80px" />
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="button" Width="80px" />
                                    <span class="button input save-click">Save</span>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="button" Width="80px" />
                                </td>
                            </tr>
                        </table>


                        <asp:Table ID="Table3" runat="server" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <h4 style="margin-bottom: 0;">
                                        <asp:Label ID="Label3" runat="server" Text="Member:-"></asp:Label></h4>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="cboxMemberName" runat="server" CssClass="cbox" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="cboxMemberName_SelectedIndexChanged"></asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="drpUserAccountTypeSearch" runat="server"></asp:DropDownList>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="button" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <h4>
                                        <asp:Label ID="Label4" runat="server" Text="Search By Range:-" style="font-size: 14px;"></asp:Label></h4>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtFromRange" runat="server" placeholder="From Date"></asp:TextBox>
                                    <img src="images/cal.gif" onclick="javascript:NewCssCal('txtFromRange')" style="cursor: pointer" />

                                     <asp:TextBox ID="txtToRange" runat="server" placeholder="To Date"></asp:TextBox>
                                    <img src="images/cal.gif" onclick="javascript:NewCssCal('txtToRange')" style="cursor: pointer" />
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button ID="btnSearchByRange" runat="server" Text="Search" CssClass="button" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>





                        <asp:Table ID="Table6" runat="server" Width="100%">
                            <asp:TableRow ID="trRow" runat="server" Visible="false">
                                <asp:TableCell Width="100%">
                                    <asp:Label ID="lblTotal" runat="server" style="float:right; font-size: 20px; display:block; color: red;"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell Width="100%">
                                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="false"
                                        GridLines="None" HeaderStyle-Width="100px" CssClass="mGrid" AllowPaging="True" Width="100%" OnPageIndexChanging="GridView2_PageIndexChanging"
                                        OnRowCancelingEdit="GridView2_RowCancelingEdit"
                                        OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting"
                                        OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" PagerSettings-PageButtonCount="20" PageSize="20">
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <Columns>

                                            <asp:BoundField DataField="JVNo" HeaderText="No" ReadOnly="True" SortExpression="JVNo" />
                                            <asp:BoundField DataField="AddedDate" HeaderText="Date" ReadOnly="True" SortExpression="AddedDate" DataFormatString="{0:MM/dd/yyyy}" />
                                            <asp:TemplateField HeaderText="Narration" SortExpression="Narration">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Narration")%>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Narration") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="FCY" SortExpression="FCY">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("CurrencyName")%>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CurrencyName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Amount" SortExpression="Amount" ItemStyle-HorizontalAlign="Right">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Amount", "{0:n}") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Amount" , "{0:n}") %>'></asp:Label>
                                                </ItemTemplate>
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
                    <asp:Label ID="lblresult" runat="server" />
                    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlpopup"
                        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
                    </asp:ModalPopupExtender>

                    <asp:Panel ID="pnlpopup" runat="server" BackColor="White" Height="400px" Width="400px" Style="display: none">
                        <table width="100%" style="border: Solid 3px #D55500; width: 100%; height: 100%" cellpadding="0" cellspacing="0">
                            <tr style="background-color: #D55500">
                                <td colspan="2" style="height: 10%; color: White; font-weight: bold; font-size: larger" align="center">Member's Details</td>
                            </tr>
                            <tr>
                                <td style="width: 45%">Trans No:
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>Date
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>Name:
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>Narration:
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>FCY:
                                </td>
                                <td></td>
                            </tr>

                            <tr>
                                <td>Amount:
                                </td>
                                <td></td>
                            </tr>

                            <tr>
                                <td colspan="2"></td>
                            </tr>

                            <tr>
                                <td colspan="2"></td>
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
        <div id="rptPreview" style="display: none;">
            <div class="receipt-preview" style="width: 600px; background-color: #ccc; padding: 1% 0;">
                <h1 style="text-align: center;">Receipt Voucher Preview</h1>
                <div class="preview-panel">
                    <div class="row">
                        <div class="col-one"><span>Transaction Number</span></div>
                        <div class="col-two"><div class="label txn"></div></div>
                    </div>
                    <div class="row">
                        <div class="col-one"><span>Receipt Date</span></div>
                        <div class="col-two"><div class="label rptdate"></div></div>
                    </div>
                    <div class="row">
                        <div class="col-one"><span>Member Name</span></div>
                        <div class="col-two"><div class="label memname"></div></div>
                    </div>
                    <div class="row">
                        <div class="col-one"><span>Receipt Narration</span></div>
                        <div class="col-two"><div class="label narration"></div></div>
                    </div>
                    <div class="row">
                        <div class="col-one"><span>Currency</span></div>
                        <div class="col-two"><div class="label currency"></div></div>
                    </div>
                    <div class="row">
                        <div class="col-one"><span>Amount</span></div>
                        <div class="col-two"><div class="label amount"></div></div>
                    </div>
                    <div class="row">
                        <div class="col-one"><span>Receipt Against</span></div>
                        <div class="col-two"><div class="label receipt"></div></div>
                    </div>
                </div>
                <div style="clear:both"></div>
                <div style="text-align: center;padding: 1% 0 0;">
                    <asp:Button ID="btnAddReceipt" runat="server" Text="Generate Receipt" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
