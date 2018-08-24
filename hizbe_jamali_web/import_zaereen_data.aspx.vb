Imports System.IO
Imports Excel
Public Class export_report
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If fuExcelFile.HasFile Then
            'create folder under App_Data if not already created and add the uploaded file in it
            If Not Directory.Exists(Server.MapPath("~/App_Data/Zaereen Ledger")) Then
                Directory.CreateDirectory(Server.MapPath("~/App_Data/Zaereen Ledger"))
            End If
            fuExcelFile.SaveAs(Server.MapPath("~/App_Data/Zaereen Ledger/" + Path.GetFileName(fuExcelFile.FileName)))
            Dim file As New FileStream(Server.MapPath("~/App_Data/Zaereen Ledger/" + Path.GetFileName(fuExcelFile.FileName)), FileMode.Open, FileAccess.Read)
            Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(file)
            excelReader.IsFirstRowAsColumnNames = True
            Dim dataSet As DataSet = excelReader.AsDataSet
            Dim _zInfo As New ZaereenLedgerInfo
            _zInfo.Add(dataSet)
            file.Dispose()
            Response.Write("Data Uploaded Successfully")
        Else
            Response.Write("Please select excel file")
        End If
    End Sub
End Class