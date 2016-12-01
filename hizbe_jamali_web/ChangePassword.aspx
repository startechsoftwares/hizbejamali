<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChangePassword.aspx.vb" Inherits="Hizbe_Jamali_Web.ChangePassword" %>

<%@ Register Src="~/StyleAndScript.ascx" TagName="Styling" TagPrefix="uc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>Hizbe Jamali</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc:Styling ID="style" runat="server" />
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
                            <asp:TableRow ID="rowLoggedAs" Visible="false">
                                <asp:TableCell>Logged As:-</asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblLogged" runat="server" Text="Label"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow ID="rowGroupLeader" Visible="false">
                                <asp:TableCell>Group Leader:-</asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblLeader" runat="server" Text="Label"></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow ID="rowAccountBalance" Visible="false">
                                <asp:TableCell>
                                    <asp:Label ID="Label4" runat="server" Text="Account Balance:-"></asp:Label></asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblAccountBal" runat="server"></asp:Label></asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </h3>

                </div>
            </div>


            <!-- Begin top content -->
            <div id="content">
                <div id="contact_us_left_coloumn">
                    <h2>Change Password</h2>
                    <div class="dotted_line"></div>
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnChangePassword">

                        <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                        <table>

                            <tr>

                                <td valign="top">
                                    <asp:Label ID="lblCurrentPassword" runat="server" Text="Current Password" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="tb5"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="rfvCurrentPassword" SetFocusOnError="true" Display="Dynamic"
                                        runat="server" ControlToValidate="txtCurrentPassword">
                                        <span class="small">Please enter current password</span>
                                    </asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvCurrentPassword" runat="server"
                                        Display="Dynamic" OnServerValidate="cvCurrentPassword_ServerValidate" ValidateEmptyText="false" SetFocusOnError="true">
                                        <span class="small">Current password is invalid</span>
                                    </asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>

                                <td valign="top">
                                    <asp:Label ID="lblNewPassword" runat="server" Text="New Password" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="tb5" TextMode="Password"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="rfvNewPassword" SetFocusOnError="true" Display="Dynamic"
                                        runat="server" ControlToValidate="txtNewPassword">
                                        <span class="small">Please enter new password</span>
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>

                                <td valign="top">
                                    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="tb5" TextMode="Password"></asp:TextBox><br />
                                    <asp:CompareValidator ID="cmpConfirmPassword" ControlToCompare="txtConfirmPassword" SetFocusOnError="true" Display="Dynamic"
                                        runat="server" ControlToValidate="txtNewPassword">
                                        <span class="small">New and Confirm password should match</span>
                                    </asp:CompareValidator>

                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="button" OnClick="btnChangePassword_Click" />
                                    <asp:Button ID="btnSkipChangePassword" runat="server" Text="SKIP" CssClass="button" OnClick="btnSkipChangePassword_Click" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>


                </div>
                <!-- End top content -->
                <asp:PlaceHolder ID="plcAdmin" runat="server" Visible="false">
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
                                <li><a class="menulink" href="repcash1.aspx">Cash Flow - I</a></li>
                                <li><a class="menulink" href="repcash2.aspx">Cash Flow - II</a></li>
                                <li><a class="menulink" href="formZaereen.aspx">Zaereen's Verification Form</a></li>
                                <li><a class="menulink" href="repzaereenverify.aspx">Zaereen's Verification Report</a></li>
                                <li><a class="menulink" href="changepassword.aspx">Change Password</a></li>
                                <li><a class="menulink" href="login.aspx">Log Out</a></li>
                            </ul>
                        </h1>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="plcGroupLeader" runat="server" Visible="false">
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
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="plcMember" runat="server" Visible="false">
                    <div id="contact_us_right_coloumn">
                        <h2>Menu</h2>
                        <h1 style="font-size: large">
                            <ul>
                                <li><a class="menulink" href="homemember.aspx">Home</a></li>
                                <li><a class="menulink" href="profile.aspx">Statement Of Account</a></li>
                                <asp:Literal ID="litMenuLink" runat="server"></asp:Literal>
                                <li><a class="menulink" href="membercashflow.aspx">Cash Flow</a></li>
                                <li><a class="menulink" href="changepassword.aspx">Change Password</a></li>
                                <li><a class="menulink" href="login.aspx">Log Out</a></li>
                            </ul>
                        </h1>
                    </div>
                </asp:PlaceHolder>
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
