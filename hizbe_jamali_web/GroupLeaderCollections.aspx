<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GroupLeaderCollections.aspx.vb" Inherits="Hizbe_Jamali_Web.GroupLeaderCollections" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" type="text/css" rel="stylesheet" />
    <style>
        div.column {
            background: #28a745;
            text-align: center;
        }

        div.header {
            font-size: 16px;
            color: #fff;
            text-transform: uppercase;
            font-weight: bold;
            padding-top: 10px;
        }

        div.amount {
            font-size: 30px;
            color: #fff;
            font-weight: bold;
            padding-bottom: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row m-lg-3 text-center">
            <div class="col-md-12">
                <div class="input-group">
                    <asp:DropDownList ID="drpGroupLeaders" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:TextBox ID="txtFromDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    <asp:TextBox ID="txtToDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="btnGroupLeaderCollections" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnGroupLeaderCollections_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:PlaceHolder ID="plcCollectionRow" runat="server" Visible="false">
            <div class="row m-lg-3">
                <div class="col-md-4">
                    <div class="column">
                        <div class="header">Total Collections</div>
                        <div class="amount">
                            <asp:Literal ID="lblTotal" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="column">
                        <div class="header">KUN Collections</div>
                        <div class="amount">
                            <asp:Literal ID="lblTotalKun" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="column">
                        <div class="header">Foster Collections</div>
                        <div class="amount">
                            <asp:Literal ID="lblTotalFoster" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="row m-lg-3">
            <div class="col-md-12">
                <asp:GridView Width="100%" ID="grdGroupLeaderCollections" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Membername" DataField="Membername" />
                        <asp:BoundField HeaderText="AddedDate" DataField="AddedDate" DataFormatString="{0:MMMM dd, yyyy}" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" />
                        <asp:BoundField HeaderText="Currency" DataField="CurrencyName" />
                        <asp:BoundField HeaderText="PaidAgainst" DataField="PaidAgainst" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
