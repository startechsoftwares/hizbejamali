Public Partial Class membercashflow
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Dim tcamt As Integer = 0
    Dim tdamt As Integer = 0
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

        Dim openingBalanceDataTable As DataTable = New DataTable()
        Dim currentDataTable As New DataTable
        Dim dtTable As DataTable = New DataTable()

        Dim OpeningBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' ", con)
        OpeningBalanceAdapter.Fill(openingBalanceDataTable)

        Dim currentBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' AND DOJ > NOW() ORDER BY JVNo ASC", con)
        currentBalanceAdapter.Fill(currentDataTable)
        dtTable.Columns.AddRange(New DataColumn() {New DataColumn("DOJ"), New DataColumn("JVNo"), New DataColumn("Narration"), New DataColumn("FCY"), New DataColumn("Debit", GetType(Integer)), New DataColumn("Credit", GetType(Integer)), New DataColumn("Balance", GetType(Integer))})

        Dim debit As Integer = 0, credit As Integer = 0, total As Integer = 0, openingBalance As Integer = 0
        Dim row As DataRow
        For Each row In openingBalanceDataTable.Rows
            If row("Sign").Trim() = "Cr" Then
                credit = Convert.ToInt32(row("Amount"))
                total = total - credit
            Else
                debit = Convert.ToInt32(row("Amount"))
                total = total + debit
            End If
        Next

        Dim NewRow As DataRow = dtTable.NewRow
        NewRow("DOJ") = ""
        NewRow("JVNo") = ""
        NewRow("Narration") = "Opening Balance"
        NewRow("FCY") = ""
        NewRow("Credit") = 0
        NewRow("Debit") = 0
        NewRow("Balance") = total
        dtTable.Rows.Add(NewRow)

        For Each row In currentDataTable.Rows
            Dim New_row As DataRow = dtTable.NewRow()
            New_row("DOJ") = row("DOJ")
            New_row("JVNo") = row("JVNo")
            New_row("Narration") = row("Narration")
            New_row("FCY") = row("FCY")
            If row("Sign").Trim() = "Cr" Then
                New_row("Credit") = row("Amount")
                New_row("Debit") = 0
                credit = Convert.ToInt32(row("Amount"))
                total = total - credit
            Else
                New_row("Debit") = row("Amount")
                New_row("Credit") = 0
                debit = Convert.ToInt32(row("Amount"))
                total = total + debit
            End If
            New_row("Balance") = total
            dtTable.Rows.Add(New_row)
        Next
        GridView2.DataSource = dtTable
        GridView2.DataBind()

        con.Close()
        litMenuLink.Text = Globals.SetLink
    End Sub
    Public Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        Dim openingBalanceDataTable As DataTable = New DataTable()
        Dim currentDataTable As New DataTable
        Dim dtTable As DataTable = New DataTable()

        If txtDateF.Text <> "" And txtDateT.Text <> "" Then
            Dim OpeningBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' AND DOJ<CDate('" & txtDateF.Text & "')", con)
            OpeningBalanceAdapter.Fill(openingBalanceDataTable)

            Dim currentBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' AND DOJ>=CDate('" & txtDateF.Text & "') AND DOJ<=CDate('" & txtDateT.Text & "') ORDER BY DOJ ASC", con)
            currentBalanceAdapter.Fill(currentDataTable)
            dtTable.Columns.AddRange(New DataColumn() {New DataColumn("DOJ"), New DataColumn("JVNo"), New DataColumn("Narration"), New DataColumn("FCY"), New DataColumn("Debit", GetType(Integer)), New DataColumn("Credit", GetType(Integer)), New DataColumn("Balance", GetType(Integer))})

            Dim debit As Integer = 0, credit As Integer = 0, total As Integer = 0, openingBalance As Integer = 0
            Dim row As DataRow
            For Each row In openingBalanceDataTable.Rows
                If row("Sign").Trim() = "Cr" Then
                    credit = Convert.ToInt32(row("Amount"))
                    total = total - credit
                Else
                    debit = Convert.ToInt32(row("Amount"))
                    total = total + debit
                End If
            Next

            Dim NewRow As DataRow = dtTable.NewRow
            NewRow("DOJ") = ""
            NewRow("JVNo") = ""
            NewRow("Narration") = "Opening Balance"
            NewRow("FCY") = ""
            NewRow("Credit") = 0
            NewRow("Debit") = 0
            NewRow("Balance") = total
            dtTable.Rows.Add(NewRow)

            For Each row In currentDataTable.Rows
                Dim New_row As DataRow = dtTable.NewRow()
                New_row("DOJ") = row("DOJ")
                New_row("JVNo") = row("JVNo")
                New_row("Narration") = row("Narration")
                New_row("FCY") = row("FCY")
                If row("Sign").Trim() = "Cr" Then
                    New_row("Credit") = row("Amount")
                    New_row("Debit") = 0
                    credit = Convert.ToInt32(row("Amount"))
                    total = total - credit
                Else
                    New_row("Debit") = row("Amount")
                    New_row("Credit") = 0
                    debit = Convert.ToInt32(row("Amount"))
                    total = total + debit
                End If
                New_row("Balance") = total
                dtTable.Rows.Add(New_row)
            Next
            GridView2.DataSource = dtTable
            GridView2.DataBind()
        Else
            Dim OpeningBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' ", con)
            OpeningBalanceAdapter.Fill(openingBalanceDataTable)

            Dim currentBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' ORDER BY DOJ ASC", con)
            currentBalanceAdapter.Fill(currentDataTable)
            dtTable.Columns.AddRange(New DataColumn() {New DataColumn("DOJ"), New DataColumn("JVNo"), New DataColumn("Narration"), New DataColumn("FCY"), New DataColumn("Debit", GetType(Integer)), New DataColumn("Credit", GetType(Integer)), New DataColumn("Balance", GetType(Integer))})

            Dim debit As Integer = 0, credit As Integer = 0, total As Integer = 0, openingBalance As Integer = 0
            Dim row As DataRow
            For Each row In openingBalanceDataTable.Rows
                If row("Sign").Trim() = "Cr" Then
                    credit = Convert.ToInt32(row("Amount"))
                    total = total - credit
                Else
                    debit = Convert.ToInt32(row("Amount"))
                    total = total + debit
                End If
            Next

            Dim NewRow As DataRow = dtTable.NewRow
            NewRow("DOJ") = ""
            NewRow("JVNo") = ""
            NewRow("Narration") = "Opening Balance"
            NewRow("FCY") = ""
            NewRow("Credit") = 0
            NewRow("Debit") = 0
            NewRow("Balance") = total
            dtTable.Rows.Add(NewRow)

            For Each row In currentDataTable.Rows
                Dim New_row As DataRow = dtTable.NewRow()
                New_row("DOJ") = row("DOJ")
                New_row("JVNo") = row("JVNo")
                New_row("Narration") = row("Narration")
                New_row("FCY") = row("FCY")
                If row("Sign").Trim() = "Cr" Then
                    New_row("Credit") = row("Amount")
                    New_row("Debit") = 0
                    credit = Convert.ToInt32(row("Amount"))
                    total = total - credit
                Else
                    New_row("Debit") = row("Amount")
                    New_row("Credit") = 0
                    debit = Convert.ToInt32(row("Amount"))
                    total = total + debit
                End If
                New_row("Balance") = total
                dtTable.Rows.Add(New_row)
            Next
            GridView2.DataSource = dtTable
            GridView2.DataBind()
        End If





    End Sub
    Public Sub GridView2_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView2.RowCancelingEdit

    End Sub
    Private Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView2.RowCommand

    End Sub
    Public Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
    End Sub
    Public Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
    End Sub
    Public Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
    End Sub
    Public Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating

    End Sub
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim openingBalanceDataTable As DataTable = New DataTable()
        Dim currentDataTable As New DataTable
        Dim dtTable As DataTable = New DataTable()

        If txtDateF.Text <> "" And txtDateT.Text <> "" Then
            Dim OpeningBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' AND DOJ<CDate('" & txtDateF.Text & "')", con)
            OpeningBalanceAdapter.Fill(openingBalanceDataTable)

            Dim currentBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' AND DOJ>=CDate('" & txtDateF.Text & "') AND DOJ<=CDate('" & txtDateT.Text & "') ORDER BY JVNo ASC", con)
            currentBalanceAdapter.Fill(currentDataTable)
            dtTable.Columns.AddRange(New DataColumn() {New DataColumn("DOJ"), New DataColumn("JVNo"), New DataColumn("Narration"), New DataColumn("FCY"), New DataColumn("Debit", GetType(Integer)), New DataColumn("Credit", GetType(Integer)), New DataColumn("Balance", GetType(Integer))})

            Dim debit As Integer = 0, credit As Integer = 0, total As Integer = 0, openingBalance As Integer = 0
            Dim row As DataRow
            For Each row In openingBalanceDataTable.Rows
                If row("Sign").Trim() = "Cr" Then
                    credit = Convert.ToInt32(row("Amount"))
                    total = total - credit
                Else
                    debit = Convert.ToInt32(row("Amount"))
                    total = total + debit
                End If
            Next

            Dim NewRow As DataRow = dtTable.NewRow
            NewRow("DOJ") = ""
            NewRow("JVNo") = ""
            NewRow("Narration") = "Opening Balance"
            NewRow("FCY") = ""
            NewRow("Credit") = 0
            NewRow("Debit") = 0
            NewRow("Balance") = total
            dtTable.Rows.Add(NewRow)

            For Each row In currentDataTable.Rows
                Dim New_row As DataRow = dtTable.NewRow()
                New_row("DOJ") = row("DOJ")
                New_row("JVNo") = row("JVNo")
                New_row("Narration") = row("Narration")
                New_row("FCY") = row("FCY")
                If row("Sign").Trim() = "Cr" Then
                    New_row("Credit") = row("Amount")
                    New_row("Debit") = 0
                    credit = Convert.ToInt32(row("Amount"))
                    total = total - credit
                Else
                    New_row("Debit") = row("Amount")
                    New_row("Credit") = 0
                    debit = Convert.ToInt32(row("Amount"))
                    total = total + debit
                End If
                New_row("Balance") = total
                dtTable.Rows.Add(New_row)
            Next
            GridView2.DataSource = dtTable
            GridView2.DataBind()
        Else
            Dim OpeningBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' ", con)
            OpeningBalanceAdapter.Fill(openingBalanceDataTable)

            Dim currentBalanceAdapter As New OleDb.OleDbDataAdapter("SELECT JVNo,DOJ,Narration,FCY,Amount,Sign FROM JournalEntry1 WHERE Account_Name='Cash Account' ORDER BY DOJ ASC", con)
            currentBalanceAdapter.Fill(currentDataTable)
            dtTable.Columns.AddRange(New DataColumn() {New DataColumn("DOJ"), New DataColumn("JVNo"), New DataColumn("Narration"), New DataColumn("FCY"), New DataColumn("Debit", GetType(Integer)), New DataColumn("Credit", GetType(Integer)), New DataColumn("Balance", GetType(Integer))})

            Dim debit As Integer = 0, credit As Integer = 0, total As Integer = 0, openingBalance As Integer = 0
            Dim row As DataRow
            For Each row In openingBalanceDataTable.Rows
                If row("Sign").Trim() = "Cr" Then
                    credit = Convert.ToInt32(row("Amount"))
                    total = total - credit
                Else
                    debit = Convert.ToInt32(row("Amount"))
                    total = total + debit
                End If
            Next

            Dim NewRow As DataRow = dtTable.NewRow
            NewRow("DOJ") = ""
            NewRow("JVNo") = ""
            NewRow("Narration") = "Opening Balance"
            NewRow("FCY") = ""
            NewRow("Credit") = 0
            NewRow("Debit") = 0
            NewRow("Balance") = total
            dtTable.Rows.Add(NewRow)

            For Each row In currentDataTable.Rows
                Dim New_row As DataRow = dtTable.NewRow()
                New_row("DOJ") = row("DOJ")
                New_row("JVNo") = row("JVNo")
                New_row("Narration") = row("Narration")
                New_row("FCY") = row("FCY")
                If row("Sign").Trim() = "Cr" Then
                    New_row("Credit") = row("Amount")
                    New_row("Debit") = 0
                    credit = Convert.ToInt32(row("Amount"))
                    total = total - credit
                Else
                    New_row("Debit") = row("Amount")
                    New_row("Credit") = 0
                    debit = Convert.ToInt32(row("Amount"))
                    total = total + debit
                End If
                New_row("Balance") = total
                dtTable.Rows.Add(New_row)
            Next
            GridView2.DataSource = dtTable
            GridView2.DataBind()
        End If




    End Sub
End Class