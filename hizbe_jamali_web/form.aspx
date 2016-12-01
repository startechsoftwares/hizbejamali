<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="form.aspx.vb" Inherits="Hizbe_Jamali_Web.form" %>

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
    <style>
        .success {
            background-color: green;
            padding: 20px;
            margin:0;
            color: #fff;
            font-size: 14px;
            width: 96%;
        }
        .error {
            background-color: red;
            padding: 20px;
            margin:0;
            color: #fff;
            font-size: 14px;
            width: 96%;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div id="wrapper">
            <!-- Begin header -->
            <div id="header" align="center">
                <div id="left_section">
                    <img src="images/logo.png" width="349" height="80" border="0" alt="" class="logo" />
                </div>
                <div id="right_section" style="width: 500px;">
                    <br />
                    <br />
                    <h3></h3>

                </div>
            </div>


            <!-- Begin top content -->
            <div id="content">

                <h2>Member's Registeration Form</h2>
                <div class="dotted_line"></div>

                <div style="border: none; height: 99%;">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    <div class="member-info">
                        <div class="profile-pic">
                            <div class="image-placeholder">
                                <div style="width: 200px; height: 235px; text-align: center;">
                                    <asp:Image ID="imgProfile" runat="server" ImageUrl="~/images/NoPhoto.jpg" />
                                </div>
                            </div>
                            <asp:FileUpload ID="fuProfile" CssClass="profilePic" runat="server" onchange="ShowpImagePreview(this)" />
                            <div style="clear: both"></div>
                            <asp:CustomValidator ID="cusProfile" runat="server" ClientValidationFunction="ValidatePhotoSelected" Display="Dynamic" ValidationGroup="addForm">
                <i class="validation-error">Please select profile photo</i>
                            </asp:CustomValidator>
                            <div style="clear: both"></div>
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
                                <div class="single-field">
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
                                        <asp:RegularExpressionValidator ID="regMobileNumber" ValidationExpression="\d{10}" runat="server" ControlToValidate="txtMobileNumber" Display="Dynamic" ValidationGroup="addForm">
                            <i class="validation-error">Mobile number is invalid</i>
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <div class="fields">
                                <div class="field">
                                    <div class="label">Group Leader</div>
                                    <div class="text">
                                        <asp:DropDownList ID="drpGroupLeaders" runat="server"></asp:DropDownList>
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
                            <div class="fields action">
                                <div class="field">
                                    <div class="text">
                                        <asp:Button ID="btnAddMember" ValidationGroup="addForm" CausesValidation="true" runat="server" Text="REGISTER NOW" OnClick="btnAddMember_Click" /><div class="clear"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End top content -->

                <div class="clear"></div>


                <div class="clear"></div>
                <div style="height: 10px;"></div>
                <div class="dotted_line"></div>
                <!-- Start footer -->
                <div id="footer">
                    <div id="footer_left_coloumn">Copyright © 2013 hizbejamali.com.  </div>

                    <div id="footer_right_coloumn">All Rights Reserved</div>
                </div>
                <!-- End footer -->
            </div>
    </form>
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
            var _old_eID = '<%= Convert.ToString(Request.QueryString("q"))%>'
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
            if ($("#" + '<%= imgProfile.ClientID%>').attr("src") == "" || $("#" + '<%= imgProfile.ClientID%>').attr("src").toLowerCase().indexOf("nophoto") != -1) {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }

        function EmailCheck(source, args) {
            var emailText = document.getElementById('<%= txtEmailId.ClientID%>');
        var regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        args.IsValid = regex.test(emailText.value.trim());
    }
    </script>
</body>
</html>
