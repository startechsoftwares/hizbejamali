Partial Public Class _Default
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.JET.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Globals.RedirectUserIfLoggedOut()
        con.Open()
        cm.Connection = con
        da = New OleDb.OleDbDataAdapter("SELECT COUNT(Member_Name) FROM PartyLedger WHERE Status='Active'", con)
        ds = New DataSet
        da.Fill(ds)
        lblcount.Text = ds.Tables(0).Rows(0)(0)
        con.Close()
    End Sub

End Class