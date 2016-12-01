Public Partial Class formZaereen1
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Globals.RedirectUserIfLoggedOut()
        con.Open()
        cm.Connection = con
        'Call FormLoad()
        lblTNo.Text = "2"
        con.Close()
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        con.Open()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & lblTNo.Text & "", con)
        ds = New DataSet

        If da.Fill(ds) Then
            cm.CommandText = "UPDATE ZaereenVerify SET Zaereen_Name='" & txtName.Text & " ' WHERE Account_No=" & lblTNo.Text & ""
            cm.ExecuteNonQuery()
            lblMissing.Text = "Record Updated"
        Else
            cm.CommandText = "INSERT INTO ZaereenVerify (Account_No,Zaereen_Name) VALUES (" & lblTNo.Text & ", '" & txtName.Text & "')"
            cm.ExecuteNonQuery()
            lblMissing.Text = "Reccord Not Updated"
        End If
        con.Close()
    End Sub
    Public Sub FormLoad()
        If String.IsNullOrEmpty(DirectCast(Session("VNO"), String)) Then
        Else
            da = New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE  Account_No= " & Session("VNO") & " ", con)
            ds = New DataSet
            If da.Fill(ds) Then
                lblTNo.Text = ds.Tables(0).Rows(0)(0)
                txtName.Text = ds.Tables(0).Rows(0)(3)
            End If

        End If

    End Sub
End Class