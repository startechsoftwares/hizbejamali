<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AddMember.ascx.vb" Inherits="Hizbe_Jamali_Web.AddMember" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style>
    i.validation-error {
        color: red;
        font-weight: bold;
        font-size: 10px;
    }
</style>
<div style="border: Solid 3px #D55500; height: 99%;">
    <div class="header">
        <span>Member's Information</span>
    </div>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <div class="member-info">
        <div class="profile-pic">
            <div class="image-placeholder">
                <div style="width: 200px; height: 235px; text-align: center;">
                    <asp:Image ID="imgProfile" runat="server" ImageUrl="~/images/NoPhoto.jpg" />
                </div>
            </div>
            <asp:FileUpload ID="fuProfile" CssClass="profilePic" runat="server" onchange="ShowpImagePreview(this)" />
            <%--<asp:CustomValidator ID="cusProfile" runat="server" ClientValidationFunction="ValidatePhotoSelected" Display="Dynamic" ValidationGroup="addForm">
                <i class="validation-error">Please select profile photo</i>
            </asp:CustomValidator>--%>
            <div style="clear: both"></div>
            <div class="fields action">
                <div class="field">
                    <div class="text">
                        <asp:Button ID="btnAddMember" CssClass="input-button" ValidationGroup="addForm" CausesValidation="true" runat="server"
                            Text="Add Member" OnClick="btnAddMember_Click" />
                    </div>
                </div>
                <div class="field1" style="float: left;">
                    <div class="text">
                        <asp:Button ID="btnCancel" CssClass="input-button" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
            <div style="clear: both; margin-bottom: 10px;"></div>
            <asp:PlaceHolder ID="plcCoreMember" runat="server" Visible="false">
                <div class="fields action" style="text-align: center;">
                    <div class="field">
                        <div class="text">
                            <asp:Button Style="font-size: 13px !important;" ID="btnApproveMember" CssClass="input-button" ValidationGroup="addForm" CausesValidation="true" runat="server" Text="Approve Member" OnClick="btnAddMember_Click" />
                        </div>
                    </div>
                    <div class="field1" style="float: left;">
                        <div class="text">
                            <asp:Button ID="btnRejectMember" CssClass="input-button" runat="server" Text="Reject" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
        <div class="personal-details">
            <div class="fields">
                <div class="single-field">
                    <div class="label">Member Name</div>
                    <div class="text">
                        <asp:TextBox ID="txtMemberName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="txtMemberName" Display="Dynamic" ValidationGroup="addForm">
                            <i class="validation-error">Please enter member-name</i>
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">Email ID</div>
                    <div class="text">
                        <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqEmailID" runat="server" ControlToValidate="txtEmailId" Display="Dynamic" ValidationGroup="addForm">
                            <i class="validation-error">Enter email address</i>
                        </asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cstValidator" runat="server" ClientValidationFunction="EmailCheck" Display="Dynamic" ControlToValidate="txtEmailId" ValidationGroup="addForm">
                            <i class="validation-error">Email address is Invalid</i>
                        </asp:CustomValidator>
                    </div>
                </div>
                <div class="field1">
                    <div class="label">Status</div>
                    <div class="text">
                        <asp:RadioButtonList ID="rdStatus" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Active">Active</asp:ListItem>
                            <asp:ListItem Value="Inactive">Inactive</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">ITS ID</div>
                    <div class="text">
                        <asp:TextBox ID="txteJamaatID" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqEjamaatID" runat="server" ControlToValidate="txteJamaatID" Display="Dynamic" ValidationGroup="addForm">
                            <i class="validation-error">Please enter ITS ID</i>
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regITS" ValidationExpression="\d{8}" runat="server" ControlToValidate="txteJamaatID" Display="Dynamic" ValidationGroup="addForm">
                            <i class="validation-error">Incorrect ITS ID</i>
                        </asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cusEjamaatID" runat="server" ClientValidationFunction="ValidateEjamaatID" Display="Dynamic" ValidationGroup="addForm" ControlToValidate="txteJamaatID">
                            <i class="validation-error">ITS user already exists</i>
                        </asp:CustomValidator>
                    </div>
                </div>
                <div class="field1">
                    <div class="label">Mobile Number</div>
                    <div class="text">
                        <asp:TextBox ID="txtMobileNumber" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqMobileNummber" runat="server" ControlToValidate="txtMobileNumber" Display="Dynamic" ValidationGroup="addForm">
                            <i class="validation-error">Please enter mobile-number</i>
                        </asp:RequiredFieldValidator>
                        <%--  <asp:RegularExpressionValidator ID="regMobileNumber" ValidationExpression="\d{10}" runat="server" ControlToValidate="txtMobileNumber" Display="Dynamic" ValidationGroup="addForm">
                            <i class="validation-error">Mobile number is invalid</i>
                        </asp:RegularExpressionValidator>--%>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">
                        <asp:Label ID="lblLeaderType" runat="server"></asp:Label>
                    </div>
                    <div class="text">
                        <asp:DropDownList ID="drpCoreLeaders" runat="server"></asp:DropDownList>
                        <asp:Label ID="lblGroupLeader" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="field1">
                    <div class="label">Country</div>
                    <div class="text">
                        <asp:DropDownList ID="drpCountry" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">Karbala Ziyaarat</div>
                    <div class="text">
                        <asp:RadioButtonList ID="rdKarbalaZiyaarat" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="field1">
                    <div class="label">Moharramaat</div>
                    <div class="text">
                        <asp:RadioButtonList ID="rdMoharramaat" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">Deeni She'ar <span style="font-size: 10px;">(Dadi/Topi/Rida)</span></div>
                    <div class="text">
                        <asp:RadioButtonList ID="rdDeeniSheear" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="True">Yes</asp:ListItem>
                            <asp:ListItem Value="False">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="field1">
                    <div class="label">Gender</div>
                    <div class="text">
                        <asp:RadioButtonList ID="rdGender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class="fields">
                <div class="field">
                    <div class="label">Account Type</div>
                    <div class="text">
                        <asp:CheckBoxList ID="chkBoxUserType" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="KUN" Selected="True">KUN</asp:ListItem>
                            <asp:ListItem Value="Foster">Fostership</asp:ListItem>
                        </asp:CheckBoxList>
                        <asp:CustomValidator runat="server" ID="cvmodulelist" ClientValidationFunction="ValidateModuleList" ValidationGroup="addForm" Display="Dynamic">
                            <i class="validation-error">Please select atleast one User Type</i>
                        </asp:CustomValidator>
                        <script>
                            // javascript to add to your aspx page
                            function ValidateModuleList(source, args) {
                                var chkListModules = document.getElementById('<%= chkBoxUserType.ClientID%>');
                                var chkListinputs = chkListModules.getElementsByTagName("input");
                                for (var i = 0; i < chkListinputs.length; i++) {
                                    if (chkListinputs[i].checked) {
                                        args.IsValid = true;
                                        return;
                                    }
                                }
                                args.IsValid = false;
                            }
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnRejectMember" CancelControlID="btnRejectCancel" PopupControlID="pnlRejectReason" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
<asp:Panel ID="pnlRejectReason" runat="server" BackColor="White" Height="320px" Width="30%" Style="display: none; border: 2px solid #D55500;">
    <div style="background-color: #D55500; padding: 10px; text-align: left; font-weight: bold; color: #fff;">REJECT REASON</div>
    <asp:TextBox ID="txtRejectReason" runat="server" TextMode="MultiLine" Style="height: 180px; width: 90%; margin: 10px 10px 0 10px;"></asp:TextBox>
    <div style="clear: both"></div>
    <asp:RequiredFieldValidator ID="rfvRejectReason" runat="server" ControlToValidate="txtRejectReason" Display="Dynamic" ValidationGroup="RejectReason">
        <i class="validation-error" style="margin-left:15px;">Please enter reason for Reject</i>
    </asp:RequiredFieldValidator>
    <div style="clear: both"></div>
    <div style="text-align: center; margin-top: 10px;">
        <asp:Button ID="btnRejectNow" runat="server" Text="Reject" OnClick="btnRejectNow_Click" ValidationGroup="RejectReason" CausesValidation="true" />
        <asp:Button ID="btnRejectCancel" runat="server" Text="Cancel" />
    </div>
</asp:Panel>

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
        function ValidateEjamaatID(source, args) {
            var _eID = '<%= txteJamaatID.ClientID%>';
            var _old_eID = '<%= Convert.ToString(_itsID)%>'
            if (_old_eID != "" || _old_eID != undefined) {
                if (_old_eID == $("#" + _eID).val()) {
                    args.IsValid = true;
                    return false;
                }
            }
            $.ajax({
                type: "POST",
                url: "GlobalServices.asmx/IsUserExists",
                dataType: "json",
                contentType: "application/json",
                data: "{'ejamaatID':'" + $("#" + _eID).val() + "'}",
                async: false,
                success: function (data) {
                    args.IsValid = !data.d;
                },
                error: function (data) {
                    alert(data.responseText);
                    return false;
                }
            });
        }

        function ValidatePhotoSelected(source, args) {
            var _fUp = document.getElementById('<%= fuProfile.ClientID%>');
            var _old_eID = '<%= Convert.ToString(_itsID)%>';
            var _old_profil_pic = '<%= imgProfile.ClientID%>';
            if (_old_eID != "" || _old_eID != undefined) {
                if ($("#" + _old_profil_pic).attr("src") == "") {
                    args.IsValid = false;
                }
                else {
                    args.IsValid = true;
                }
                return false;
            }
            args.IsValid = _fUp.value != '';
        }

        function EmailCheck(source, args) {
            var emailText = document.getElementById('<%= txtEmailId.ClientID%>');
            var regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            args.IsValid = regex.test(emailText.value.trim());
        }
</script>

