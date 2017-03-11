Partial Public Class profile
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
        Call DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT SUM(Amount) FROM JournalEntry WHERE  Ejamaat= '" & Globals.GetSessionEJamaatID & "' AND PAIDAGAINST = '" & Globals.UserAccountType.ToString & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblAccountBal.Text = ds.Tables(0).Rows(0)(0).ToString
        ' lblAccountBal.Text = CType(lblAccountBal.Text, Double).ToString("0.00")

        con.Close()
        litMenuLink.Text = Globals.SetLink
    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT DOJ, Narration, FCY, Amount FROM JournalEntry WHERE Ejamaat= '" & Globals.GetSessionEJamaatID & "' AND PAIDAGAINST = '" & Globals.UserAccountType.ToString & "' ORDER BY DOJ DESC", con)
        ds = New DataSet
        da.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()

        Dim lbl As Label = CType(GridView2.FooterRow.FindControl("lblTotal"), Label)
        lbl.Text = ds.Tables(0).Compute("sum(Amount)", String.Empty).ToString()
    End Sub
    Public Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
        DatagridUpdate()
    End Sub
    Public Sub GridView2_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView2.RowCancelingEdit

    End Sub
    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand

    End Sub
    Public Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim rowTotal As Decimal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"))
        '    grdTotal = grdTotal + rowTotal
        'End If

        'Dim ds As DataTable = CType(e.Row.DataItem, DataTable)
        'If e.Row.RowType = DataControlRowType.Footer Then
        '    Dim lbl As Label = DirectCast(e.Row.FindControl("lblTotal"), Label)
        '    lbl.Text = ds.Rows.Count.ToString 'grdTotal.ToString("0.00")
        'End If

    End Sub
    Public Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
    End Sub
    Public Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
    End Sub
    Public Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating

    End Sub

End Class