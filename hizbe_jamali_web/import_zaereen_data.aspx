<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="import_zaereen_data.aspx.vb" Inherits="Hizbe_Jamali_Web.export_report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .container{width:1170px;margin:auto;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
               <asp:FileUpload ID="fuExcelFile" runat="server" />
               <asp:Button ID="btnUpload" runat="server" Text="UPLOAD" OnClick="btnUpload_Click" />
            </div>
        </div>
    </form>
</body>
</html>
