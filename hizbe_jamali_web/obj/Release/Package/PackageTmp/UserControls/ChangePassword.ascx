<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ChangePassword.ascx.vb" Inherits="Hizbe_Jamali_Web.ChangePassword1" %>
<h2>Change Password</h2>
<div class="dotted_line"></div>
<asp:Panel ID="Panel1" runat="server" DefaultButton="btnChangePassword">
    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
    <table>

        <tr>

            <td valign="top">
                <asp:Label ID="Label1" runat="server" Text="Current ITS Password" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label>
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
                <asp:Label ID="lblNewPassword" runat="server" Text="New ITS Password" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label>
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
                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm ITS Password" ForeColor="#663300" Font-Bold="True" Font-Size="Small" Font-Names="Arial "></asp:Label>
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
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="button" OnClick="btnChangePassword_Click" /></td>
        </tr>
    </table>
</asp:Panel>
