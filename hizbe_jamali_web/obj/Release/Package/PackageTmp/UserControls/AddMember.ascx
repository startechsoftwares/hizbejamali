<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AddMember.ascx.vb" Inherits="Hizbe_Jamali_Web.AddMember" %>
<div style="border: Solid 3px #D55500; height: 99%;">
    <div class="header">
        <span>Member's Information</span>
    </div>
    <div class="member-info">
        <div class="profile-pic">
            <div class="image-placeholder">
                <div style="width: 200px; height: 235px; text-align: center;">
                    <asp:Image ID="imgProfile" runat="server" ImageUrl="~/images/NoPhoto.jpg" />
                </div>
            </div>
            <asp:FileUpload ID="fuProfile" runat="server" onchange="ShowpImagePreview(this)" />
            <div style="clear: both"></div>
        </div>
        <div class="personal-details">
            <div class="fields">
                <div class="single-field">
                    <div class="label">Member Name</div>
                    <div class="text">
                        <asp:TextBox ID="txtMemberName" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">eJamaat ID</div>
                    <div class="text">
                        <asp:TextBox ID="txteJamaatID" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="field1">
                    <div class="label">Mobile Number</div>
                    <div class="text">
                        <asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">Group Leader</div>
                    <div class="text">
                        <asp:DropDownList ID="drpGroupLeaders" runat="server" Visible="false"></asp:DropDownList>
                        <asp:Label ID="lblGroupLeader" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="field1">
                    <div class="label">Email ID</div>
                    <div class="text">
                        <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">Country</div>
                    <div class="text">
                        <asp:DropDownList ID="drpCountry" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="field1">
                    <div class="label">Status</div>
                    <div class="text">
                        <asp:DropDownList ID="drpStatus" runat="server">
                            <asp:ListItem Text="Active"></asp:ListItem>
                            <asp:ListItem Text="In Active"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields action">
                <div class="field">
                    <div class="text">
                        <asp:Button ID="btnAddMember" runat="server" Text="Add Member" OnClick="btnAddMember_Click" />
                    </div>
                </div>
                <div class="field1">
                    <div class="text">
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    function ShowpImagePreview(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#<%= imgProfile.ClientID%>').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
            }
        }
</script>
