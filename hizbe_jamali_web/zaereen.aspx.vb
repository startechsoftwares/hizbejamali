Public Partial Class zaereen
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Private grdTotal As Decimal = 0
    Dim cm As New OleDb.OleDbCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
        cm.Connection = con
        con.Open()

        lblLogged.Text = Session("TID")

        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0)

        da = New OleDb.OleDbDataAdapter("SELECT SUM(Amount) FROM JournalEntry WHERE  Account_Name = '" & lblLogged.Text & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblAccountBal.Text = ds.Tables(0).Rows(0)(0).ToString

        Call DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT SUM(TripExp) FROM ZaereenLedger", con)
        ds = New DataSet
        da.Fill(ds)
        lblTotal.Text = ds.Tables(0).Rows(0)(0)
        Dim num As Integer = lblTotal.Text
        lblTotal.Text = num.ToString("N")

        Call ReadOnlyText()
        con.Close()
        ' litMenuLink.Text = Globals.SetLink
    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT Account_No,Zaereen_Name, Mobile, Occupation, Age, Ejamaat, DOJ, Trip, TripExp FROM ZaereenLedger ORDER BY Account_No DESC", con)
        ds = New DataSet
        da.Fill(ds)
        dt = ds.Tables(0)
        GridView2.DataSource = dt
        GridView2.DataBind()
    End Sub
    Public Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
    End Sub
    Public Sub GridView2_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView2.RowCancelingEdit

    End Sub
    Public Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        con.Open()
        If e.CommandName = "Edit" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            lblTNo.Text = row.Cells(1).Text.ToString
            txtEjamaat.Text = row.Cells(2).Text.ToString
            da = New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenLedger WHERE Ejamaat='" & txtEjamaat.Text & "'", con)
            ds = New DataSet
            da.Fill(ds)
            txtName.Text = ds.Tables(0).Rows(0)(1)
            txtAge.Text = ds.Tables(0).Rows(0)(2)
            txtEjamaat.Text = ds.Tables(0).Rows(0)(3)
            txtContact.Text = ds.Tables(0).Rows(0)(4)
            txtDate.Text = ds.Tables(0).Rows(0)(5)
            txtTripDays.Text = ds.Tables(0).Rows(0)(6)
            txtOccupation.Text = ds.Tables(0).Rows(0)(7)
            txtAddress.Text = ds.Tables(0).Rows(0)(8).ToString
            txtTripExp.Text = ds.Tables(0).Rows(0)(9)
            txtRemarks.Text = ds.Tables(0).Rows(0)(11).ToString
            txtStatus.Text = ds.Tables(0).Rows(0)(12).ToString
            ModalPopupExtender1.Show()
        End If
        con.Close()
    End Sub
    Public Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound

    End Sub
    Public Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
    End Sub
    Public Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
    End Sub
    Public Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating

    End Sub
    Public Sub ReadOnlyText()
        ''txtAddress.ReadOnly = True
        'txtAge.ReadOnly = True
        'txtContact.ReadOnly = True
        'txtDate.ReadOnly = True
        'txtEjamaat.ReadOnly = True
        'txtName.ReadOnly = True
        'txtOccupation.ReadOnly = True
        ''txtRemarks.ReadOnly = True
        ''txtStatus.ReadOnly = True
        'txtTripDays.ReadOnly = True
        'txtTripExp.ReadOnly = True
    End Sub

End Class