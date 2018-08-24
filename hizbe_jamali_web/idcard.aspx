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
         @media print {
              .header {
                color: rgba(0, 0, 0, 0);
                text-shadow: 0 0 0 #ccc;
              }

              @media print and (-webkit-min-device-pixel-ratio:0) {
                .header {
                  color: #ccc;
                  -webkit-print-color-adjust: exact;
                }
              }
           }

        table table {
            width: 98%;
            border-collapse: collapse;
            position: relative;
            margin: 5px;
            height: 225px;
        }

            table table tr td.header {
                background: #566A8F;
                font-family: 'Androgyne';
                font-size: 30px;
                text-align: center;
                color: #fff;
                height: 0px;
            }

            table table tr td.info {
                color: #566A8F;
                font-family: 'Androgyne';
                font-size: 12px;
                text-transform: uppercase;
                padding: 4px;
                text-align: left;
                height: 10px;
            }

            table table tr td {
                border: 1px solid #566A8F;
                padding: 3px 0;
            }

        .col-md-6, .col-md-10, .col-md-12, .col-md-2, .col-md-7, .col-md-5, .col-md-9 {
            padding: 0 !important;
        }

        .col-md-6 {
            border: 1px solid #566A8F;
        }

        .bor-b {
            border-bottom: 1px solid #566A8F;
        }

        .bor-l {
            border-left: 1px solid #566A8F;
        }

        .bor-r {
            border-right: 1px solid #566A8F;
        }

        .bor-t {
            border-top: 1px solid #566A8F;
        }

        .header {
            background: #566A8F;
            font-family: 'Androgyne';
            color: #fff;
        }

        .font-androgyne {
            font-family: 'Androgyne';
            color: #566A8F;
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
        <asp:PlaceHolder ID="plcError" runat="server" Visible="false">
            <div class="row" style="padding: 2% 25%;">
                <div class="col-md-12">
                    <asp:Label ID="lblError" runat="server" Style="font: bold 20px calibri, arial; color: red;"></asp:Label>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcCardType1" runat="server">
            <div style="text-align: center;">
                <div class="text-center">
                    <div class="row" style="padding: 2% 25%;">
                        <div class="col-md-12">
                            <div class="input-group">
                                <span class="input-group">
                                    <asp:FileUpload ID="fuZaereenList" runat="server" CssClass="form-control" />
                                    <span class="input-group-btn" style="width: 0px;"></span>
                                    <asp:TextBox ID="txtGLName" runat="server" CssClass="form-control" placeholder="Group Leader Name"></asp:TextBox>
                                    <span class="input-group-btn" style="width: 0px;"></span>
                                    <asp:TextBox ID="txtGLNumber" runat="server" CssClass="form-control" placeholder="Group Leader Mobile #"></asp:TextBox>
                                    <span class="input-group-btn" style="width: 0px;"></span>
                                </span>
                                <span class="input-group-btn">
                                    <asp:Button ID="Button1" runat="server" Text="Generate ID-Card" CssClass="btn btn-default" OnClick="btnSubmit_Click" />
                                    <input type="button" value="Print" class="btn btn-default" onclick="window.print();" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <asp:PlaceHolder ID="plcNoRecordsCard1" runat="server" Visible="false">
                        <div style="padding: 10px; color: red; text-align: center;">
                            <p>No Records Found !!!</p>
                        </div>
                    </asp:PlaceHolder>
                    <div style="text-align: center;">


                        <asp:DataList ID="rptIdCard" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" Width="100%" BorderWidth="0">
                            <ItemTemplate>






                                <table>
                                    <tr>
                                        <td width="25%"><span style="font-size:50px;"><%# Container.ItemIndex + 1 %></span></td>
                                        <td class="header" colspan="2">
                                            <span style="font-size:20px;">HIZBE JAMALI</span>
                                           
                                        </td>
                                        <td width="5%">
                                             <img src="/images/logo.png" width="50" />
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
                                        <td class="info" width="50%">+964 </td>
                                        <td class="info" colspan="2">Hotel: </td>
                                    </tr>
                                    <tr>
                                        <td class="info">Najaf:
                                        </td>
                                        <td class="info" width="50%">+964 </td>
                                        <td class="info" colspan="2">Hotel: </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcCardType2" runat="server">
            <div class="row" style="padding: 2% 25%;">
                <div class="col-md-12">
                    <div class="input-group">
                        <asp:FileUpload ID="fupCardType2" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <asp:Button ID="btnCardType2" runat="server" Text="Generate ID-Card" CssClass="btn btn-default" OnClick="btnCardType2_Click" />
                            <input type="button" value="Print" class="btn btn-default" onclick="window.print();" />
                        </span>
                    </div>
                </div>
            </div>
            <asp:PlaceHolder ID="plcNoRecordsCard2" runat="server" Visible="false">
                <div style="padding: 10px; color: red; text-align: center;">
                    <p>No Records Found !!!</p>
                </div>
            </asp:PlaceHolder>
            <div style="text-align: center;">
                <asp:DataList ID="dtlCard2" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" Width="100%" BorderWidth="0">
                    <ItemTemplate>
                        <div class="row" style="margin:10px 0 10px 10px;">
                            <div class="col-md-11 bor-t bor-r bor-b bor-l">
                                <div class="row">
                                    <div class="col-md-10">
                                        <div class="col-md-12 bor-b bor-r header">
                                            <h3>Hizbe Jamali</h3>
                                        </div>
                                        <div class="col-md-12">
                                            <div class="col-md-3">
                                                <h1 class="font-androgyne" style="font-size: 70px;"><%# Container.ItemIndex + 1 %></h1>
                                            </div>
                                            <div class="col-md-9">
                                                <div class="col-md-12 bor-b bor-r bor-l font-androgyne" style="font-size: 45px;">
                                                    <%# Eval("Name") %>
                                                </div>
                                                <div class="col-md-7 bor-l bor-r font-androgyne">
                                                    <h3><%# Eval("MobileNumber") %></h3>
                                                </div>
                                                <div class="col-md-5 bor-r font-androgyne">
                                                    <h3><%# Eval("City")%></h3>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="col-md-12">
                                            <img src="/images/logo.png" style="width: 80px;margin-top:5px;" />
                                        </div>
                                        <div class="col-md-12 font-androgyne">
                                            <h1><%# Container.ItemIndex + 1 %></h1>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </asp:PlaceHolder>
    </form>
</body>
</html>
