<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="executedb.aspx.vb" Inherits="Hizbe_Jamali_Web.executedb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtQuery" runat="server" TextMode="MultiLine" Height="200" Width="100%"></asp:TextBox><br />
        <asp:Button ID="btnExecuteQuery" runat="server" Text="Execute" OnClick="btnExecuteQuery_Click" /><br />
        <asp:GridView ID="grdDbRecords" runat="server" AllowPaging="true" PageSize="50" Width="100%" OnPageIndexChanging="grdDbRecords_PageIndexChanging" EmptyDataText="No Records Found"></asp:GridView>
    </form>
</body>
</html>
