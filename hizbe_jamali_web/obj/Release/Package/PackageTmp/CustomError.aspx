<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CustomError.aspx.vb" Inherits="Hizbe_Jamali_Web.CustomError" %>

<%@ Register Src="~/StyleAndScript.ascx" TagName="Styling" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Occured on website</title>
    <uc1:Styling ID="styling" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <!-- Begin header -->
            <div id="header" align="center">
                <div id="left_section">
                    <img src="images/logo.png" width="349" height="80" border="0" alt="" class="logo" />
                </div>
            </div>


            <!-- Begin top content -->
            <div id="content">
                <div id="contact_us_left_coloumn" style="width: 100% !important;">
                    <h2>Error Occured</h2>
                    <div class="dotted_line"></div>
                    <div style="text-align: center; padding: 20px 0 !important;">
                        Oops! There is something wrong on our server, please try again later. If problem persists, contact <a href="mailto:helpdesk@startechsoftwares.com">site administrator </a> with all details.
                    </div>
                    <!-- End top content -->
                    <div class="clear"></div>


                    <div class="clear"></div>
                    <div class="dotted_line"></div>
                </div>
            </div>


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
