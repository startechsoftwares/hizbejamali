Imports System.Data.OleDb
Imports System.Data
Public Class executedb
    Inherits System.Web.UI.Page

    Public Sub BindGrid(query As String)
        Dim connection As New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
        connection.Open()
        Try
            If txtQuery.Text.StartsWith("insert") Or txtQuery.Text.StartsWith("update") Or txtQuery.Text.StartsWith("delete") Then
                With New OleDbCommand(txtQuery.Text, connection)
                    .CommandType = CommandType.Text
                    .ExecuteNonQuery()
                End With
                Response.Write("Records updated successfully")
            Else
                Dim oledb As New OleDbDataAdapter(query, connection)
                Dim dt As New DataTable
                oledb.Fill(dt)
                grdDbRecords.DataSource = dt
                grdDbRecords.DataBind()
            End If
        Catch ex As Exception
            Response.Write(ex.ToString)
        Finally
            connection.Close()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub grdDbRecords_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdDbRecords.PageIndexChanging
        grdDbRecords.PageIndex = e.NewPageIndex
        BindGrid(txtQuery.Text)
    End Sub

    Protected Sub btnExecuteQuery_Click(sender As Object, e As EventArgs) Handles btnExecuteQuery.Click
        BindGrid(txtQuery.Text)
    End Sub
End Class