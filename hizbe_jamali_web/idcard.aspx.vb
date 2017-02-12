Imports System.Collections.Generic
Imports System.IO

Public Class IdCardData
    Private _its As String
    Public Property ITS As String
        Get
            Return _its
        End Get
        Set(value As String)
            _its = value
        End Set
    End Property
    Private _name As String
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Private _age As Integer
    Public Property Age As Integer
        Get
            Return _age
        End Get
        Set(value As Integer)
            _age = value
        End Set
    End Property
    Private _mobileNumber As String
    Public Property MobileNumber As String
        Get
            Return _mobileNumber
        End Get
        Set(value As String)
            _mobileNumber = value
        End Set
    End Property
    Private _glname As String
    Public Property GroupLeaderName As String
        Get
            Return _glname
        End Get
        Set(value As String)
            _glname = value
        End Set
    End Property

    Private _glmobile As String
    Public Property GroupLeaderMobileNumber As String
        Get
            Return _glmobile
        End Get
        Set(value As String)
            _glmobile = value
        End Set
    End Property

End Class
Public Class idcard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)


        If fuZaereenList.HasFile Then
            Dim idCardList As New List(Of IdCardData)
            Dim reader As New StreamReader(fuZaereenList.PostedFile.InputStream)
            While Not reader.EndOfStream
                Dim rowValue() As String = reader.ReadLine().Split(",")
                Dim id As New IdCardData
                id.Name = rowValue(0)
                id.Age = rowValue(1)
                id.MobileNumber = rowValue(2)
                id.ITS = String.Empty
                If (rowValue.Length > 3 AndAlso rowValue(3) <> String.Empty) Then
                    id.ITS = rowValue(3)
                End If
                If txtGLName.Text <> String.Empty Then
                    id.GroupLeaderName = txtGLName.Text
                End If
                If txtGLNumber.Text <> String.Empty Then
                    id.GroupLeaderMobileNumber = txtGLNumber.Text
                End If
                idCardList.Add(id)
            End While
            rptIdCard.DataSource = idCardList
            rptIdCard.DataBind()
            'Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fuZaereenList.PostedFile.InputStream)
            'excelReader.IsFirstRowAsColumnNames = True
            'Dim ds As DataSet = excelReader.AsDataSet
            'Dim dt As New System.Data.DataTable("ZaereenList")
            'dt.Columns.AddRange(New DataColumn() {New DataColumn("ITS"), New DataColumn("Name"), New DataColumn("MobileNumber"), New DataColumn("Age")})
            'For Each row As DataRow In ds.Tables(0).Rows
            '    Dim dRow As DataRow = dt.NewRow
            '    For Each col As DataColumn In ds.Tables(0).Columns
            '        dRow(col.ColumnName) = row(col.ColumnName).ToString
            '    Next
            '    dt.Rows.Add(dRow)
            'Next
            'rptIdCard.DataSource = dt
            'rptIdCard.DataBind()
        End If

        'If txtFrom.Text <> String.Empty And txtTo.Text <> String.Empty Then
        '    Dim z As New ZaereenController
        '    Dim dr() As DataRow = z.GetZaereenList.Select("DOJ > '" + txtFrom.Text + "' and DOJ < '" + txtTo.Text + "'")
        '    If dr.Count > 0 Then
        '        Dim dt As DataTable = dr.CopyToDataTable
        '        rptIdCard.DataSource = dt
        '        rptIdCard.DataBind()
        '        plcNoRecords.Visible = False
        '    Else
        '        plcNoRecords.Visible = True
        '    End If
        'Else

        'End If
    End Sub
End Class