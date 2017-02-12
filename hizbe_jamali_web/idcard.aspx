<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="idcard.aspx.vb" Inherits="Hizbe_Jamali_Web.idcard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        @font-face {
            font-family: 'Androgyne';
            src: url('fonts/Androgyne.ttf.woff') format('woff'),url('fonts/Androgyne.ttf.svg#Androgyne') format('svg'),url('fonts/Androgyne.ttf.eot'),url('fonts/Androgyne.eot?#iefix') format('embedded-opentype');
            font-weight: normal;
            font-style: normal;
        }

        table table {
            width: 353px;
            border-collapse: collapse;
            position: relative;
            margin: 5px;
        }

            table table tr td.header {
                background: #566A8F;
                font-family: 'Androgyne';
                font-size: 30px;
                text-align: center;
                color: #fff;
                padding: 10px;
                height: 70px;
            }

            table table tr td.info {
                color: #566A8F;
                font-family: 'Androgyne';
                font-size: 12px;
                text-transform: uppercase;
                padding: 4px;
                text-align: left;
            }

            table table tr td {
                border: 1px solid #566A8F;
                padding: 3px 0;
            }
    </style>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script>
        $(function () {
            var dateFormat = "mm/dd/yy",
              from = $("#txtFrom")
                .datepicker({
                    defaultDate: "+1w",
                    changeMonth: true,
                    changeYear: true,
                    numberOfMonths: 1
                })
                .on("change", function () {
                    to.datepicker("option", "minDate", getDate(this));
                }),
              to = $("#txtTo").datepicker({
                  defaultDate: "+1w",
                  changeMonth: true,
                  changeYear: true,
                  numberOfMonths: 1
              })
              .on("change", function () {
                  from.datepicker("option", "maxDate", getDate(this));
              });

            function getDate(element) {
                var date;
                try {
                    date = $.datepicker.parseDate(dateFormat, element.value);
                } catch (error) {
                    date = null;
                }

                return date;
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; display: none;">
            <label for="from">SELECT RANGE - FROM</label>
            <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
            <label for="to">TO</label>
            <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click" />
        </div>
        <div style="text-align: center;">
            <div class="text-center">
                <div class="row" style="padding: 2% 25%;">
                    <div class="col-md-12">
                        <div class="input-group">
                            <span class="input-group">
                                <asp:FileUpload ID="fuZaereenList" runat="server" CssClass="form-control" />
                                <span class="input-group-btn" style="width:0px;"></span>
                                <asp:TextBox ID="txtGLName" runat="server" CssClass="form-control" placeholder="Group Leader Name"></asp:TextBox>
                                <span class="input-group-btn" style="width:0px;"></span>
                                <asp:TextBox ID="txtGLNumber" runat="server" CssClass="form-control" placeholder="Group Leader Mobile #"></asp:TextBox>
                                <span class="input-group-btn" style="width:0px;"></span>
                            </span>
                            <span class="input-group-btn">
                                <asp:Button ID="Button1" runat="server" Text="Generate ID-Card" CssClass="btn btn-default" OnClick="btnSubmit_Click" />
                                <input type="button" value="Print" class="btn btn-default" onclick="window.print();" />
                            </span>
                        </div>
                    </div>
                </div>

                <%--<div class="container" style="padding: 15%;">
            <div class="row">
                <div class="col-md-3">
                    <label>ITS</label>
                    <asp:TextBox ID="txtITS" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <label>Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-md-2">
                    <label>Age</label>
                    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label>MobileNumber</label>
                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label>Group Leader</label>
                    <asp:TextBox ID="txtGroupLeader" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-md-6">
                    <label>Karbala Address</label>
                    <asp:TextBox ID="txtKarbalaAddress" Rows="5" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label>Najaf Address</label>
                    <asp:TextBox ID="txtNajaf" Rows="5" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="margin-top:10px;"> 
                <div></div>
            </div>
        </div>--%>
                <asp:PlaceHolder ID="plcNoRecords" runat="server" Visible="false">
                    <div style="padding: 10px; color: red; text-align: center;">
                        <p>No Records Found !!!</p>
                    </div>
                </asp:PlaceHolder>
                <div style="text-align: center;">
                    <asp:DataList ID="rptIdCard" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" Width="100%" BorderWidth="0">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td width="25%"></td>
                                    <td class="header" colspan="3">
                                        <img src="/images/logo.png" width="50" style="position: absolute; border: 0; left: 5%; top: 1%;" />
                                        HIZBE JAMALI
                                    </td>
                                </tr>
                                <tr>

                                    <td class="info">Name:
                                    </td>
                                    <td colspan="3" class="info"><%# Eval("Name")%>
                                    </td>

                                </tr>
                                <tr>

                                    <td class="info">ITS ID:
                                    </td>
                                    <td class="info" width="24%"><%# Eval("ITS")%>
                                    </td>
                                    <td class="info">Mobile #:
                                    </td>
                                    <td class="info">+91 - <%# Eval("MobileNumber")%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">G.L Name:
                                    </td>
                                    <td colspan="3" class="info"><%# Eval("GroupLeaderName") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">G.L Number:
                                    </td>
                                    <td colspan="3" class="info"><%# Eval("GroupLeaderMobileNumber") %>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="info">Karbala:
                                    </td>
                                    <td class="info" colspan="3">+964 7505755896 - Hotel:</td>
                                </tr>
                                <tr>
                                    <td class="info">Najaf:
                                    </td>
                                    <td class="info" colspan="3">+964 7711659452 - Hotel:</td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
