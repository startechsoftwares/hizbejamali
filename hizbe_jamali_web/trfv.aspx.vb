Public Partial Class trfv
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
        cm.Connection = con
        con.Open()

        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0)
        If IsPostBack = False Then
            cboxFCY.Items.Add("IRS")
            cboxFCYAg.Items.Add("DHS")
            cboxFCYAg.Items.Add("USD")
            cboxFCYAg.Items.Add("KWD")

        End If
        con.Close()
    End Sub
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        da = New OleDb.OleDbDataAdapter("SELECT MAX(JVNo) FROM JournalEntry WHERE Type='ITT'", con)
        ds = New DataSet
        If da.Fill(ds) Then
            lblTNo.Text = ds.Tables(0).Rows(0)(0) + 1.ToString
            ModalPopupExtender1.Show()
        Else
            lblTNo.Text = 1
            ModalPopupExtender1.Show()
        End If
    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT JVNo, DOJ, Account_Name, FCY, Amount, Sign FROM JournalEntry WHERE Sign='Cr' ORDER BY JVNo DESC", con)
        ds = New DataSet
        da.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()
    End Sub
    Public Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()
    End Sub
    Public Sub GridView2_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView2.RowCancelingEdit

    End Sub
    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand
        con.Open()
        If e.CommandName = "Edit" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            lblTNo.Text = row.Cells(2).Text.ToString
            da = New OleDb.OleDbDataAdapter("SELECT * FROM JournalEntry WHERE JVNo=" & lblTNo.Text & " Type='ITT'", con)
            ds = New DataSet
            da.Fill(ds)
            txtDate.Text = ds.Tables(0).Rows(0)(1)
            cboxFCYAg.Text = ds.Tables(0).Rows(0)(1)
            txtAmtIRS.Text = ds.Tables(0).Rows(0)(1)
            txtRate.Text = ds.Tables(0).Rows(0)(1)
            txtAmtDHS.Text = ds.Tables(0).Rows(0)(1)
            ModalPopupExtender1.Show()
        End If


        If e.CommandName = "Delete" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            da = New OleDb.OleDbDataAdapter("SELECT * FROM JournalEntry WHERE JVNo=" & row.Cells(2).Text & "", con)
            ds = New DataSet
            If da.Fill(ds) Then
                cm.CommandText = "DELETE JVNo FROM JournalEntry WHERE JVNo=" & row.Cells(2).Text & ""
                cm.ExecuteNonQuery()
                Call ClearAll()
            End If

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
    Private Sub ClearAll()
        lblTNo.Text = ""
        txtAmtDHS.Text = ""
        txtAmtIRS.Text = ""
        txtDate.Text = ""
        txtRate.Text = ""
        txtRemarks.Text = ""
        dt1.Clear()
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        con.Open()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM JournalEntry WHERE JVNo=" & Val(lblTNo.Text) & " AND Type='ITT'", con)
        ds = New DataSet
        da.Fill(ds)

        If da.Fill(ds) Then
            cm.CommandText = "DELETE * FROM JournalEntry WHERE JVNo=" & Val(lblTNo.Text) & " AND Type='ITT'"
            cm.ExecuteNonQuery()
            cm.CommandText = "INSERT INTO JournalEntry (JVNo, DOJ, Account_Name, Narration,Leader_Name, FCY, FCAmount, Rate, Amount, Sign, Status,Type) VALUES (  '" & Val(lblTNo.Text) & "', '" & txtDate.Text & "','Cash Account', '" & txtRemarks.Text & "','" & lblLogged.Text & "','" & cboxFCYAg.Text & "','" & Val(txtAmtDHS.Text) & "', '1','" & Val(txtAmtDHS.Text) & "', 'Cr ', 'Paid','ITT')"
            cm.ExecuteNonQuery()
            cm.CommandText = "INSERT INTO JournalEntry (JVNo, DOJ, Account_Name, Narration, Leader_Name, FCY, FCAmount, Rate, Amount, Sign, Status,Type) VALUES (  '" & Val(lblTNo.Text) & "', '" & txtDate.Text & "','Cash Account', '" & txtRemarks.Text & "','" & lblLogged.Text & "', '" & cboxFCY.Text & "','" & CType(txtAmtIRS.Text, Integer) & "', '1','" & CType(txtAmtIRS.Text, Integer) & "', 'Dr ', 'Paid','ITT')"
            cm.ExecuteNonQuery()
            Call ClearAll()
        Else
            cm.CommandText = "INSERT INTO JournalEntry (JVNo, DOJ, Account_Name, Narration,Leader_Name, FCY, FCAmount, Rate, Amount, Sign, Status,Type) VALUES (  '" & Val(lblTNo.Text) & "', '" & txtDate.Text & "','Cash Account', '" & txtRemarks.Text & "','" & lblLogged.Text & "','" & cboxFCYAg.Text & "','" & Val(txtAmtDHS.Text) & "', '1','" & Val(txtAmtDHS.Text) & "', 'Cr ', 'Paid','ITT')"
            cm.ExecuteNonQuery()
            cm.CommandText = "INSERT INTO JournalEntry (JVNo, DOJ, Account_Name, Narration, Leader_Name, FCY, FCAmount, Rate, Amount, Sign, Status,Type) VALUES (  '" & Val(lblTNo.Text) & "', '" & txtDate.Text & "','Cash Account', '" & txtRemarks.Text & "','" & lblLogged.Text & "', '" & cboxFCY.Text & "','" & CType(txtAmtIRS.Text, Integer) & "', '1','" & CType(txtAmtIRS.Text, Integer) & "', 'Dr ', 'Paid','ITT')"
            cm.ExecuteNonQuery()
            Call ClearAll()
        End If

        con.Close()
    End Sub
End Class