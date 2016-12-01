Imports System.Globalization

Partial Public Class rcptv1
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim dt1 As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Dim member As New MemberInfo
    Private Shared SearchByName As Boolean = False
    Private Shared SearchByRange As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
        cm.Connection = con
        con.Open()
        member = MemberInfo.GetMember(Globals.GetSessionEJamaatID)
        lblLogged.Text = member.GroupLeader
        'da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        'ds = New DataSet
        'da.Fill(ds)
        'lblLogged.Text = ds.Tables(0).Rows(0)(0).ToString
        'da = New OleDb.OleDbDataAdapter("SELECT Name FROM GroupLeader WHERE  OName='" & lblLogged.Text & "'", con)
        'ds = New DataSet
        'da.Fill(ds)
        'lblLogged.Text = ds.Tables(0).Rows(0)(0).ToString
        lblNoData.Visible = False
        If IsPostBack = False Then
            cboxFCY.Items.Add("IRS")
            cboxFCY.Items.Add("DHS")
            cboxFCY.Items.Add("USD")
            cboxFCY.Items.Add("KWD")
            cboxFCY.Items.Add("SAR")
            cboxFCY.Items.Add("GBP")
            cboxFCY.Items.Add("QAR")

            da = New OleDb.OleDbDataAdapter("SELECT Member_Name, Ejamaat FROM PartyLedger WHERE Group_Leader='" & member.GroupLeader & "' AND Status = 'Active' ORDER BY Member_Name", con)
            dt = New DataTable
            da.Fill(dt)

            cboxMemberName.DataSource = dt
            cboxMemberName.DataTextField = "Member_Name"
            cboxMemberName.DataValueField = "Ejamaat"
            cboxMemberName.DataBind()

            cboxSname.DataSource = dt
            cboxSname.DataTextField = "Member_Name"
            cboxSname.DataValueField = "Ejamaat"
            cboxSname.DataBind()

            cboxMemberName.Items.Add(New ListItem("Voluntary Contribution", "-1"))
            cboxSname.Items.Add(New ListItem("Voluntary Contribution", "-1"))
        End If
        Dim account As AccountType = MemberInfo.LeaderType(Globals.GetSessionEJamaatID)
        Select Case account
            Case AccountType.Member
                plcErrorMessage.Visible = True
                lnkDashBoard.NavigateUrl = "~/homemember.aspx?TD=" + Globals.GetSessionEJamaatID
            Case AccountType.Administrator
                plcErrorMessage.Visible = True
                lnkDashBoard.NavigateUrl = "~/homeadmin.aspx?TD=" + Globals.GetSessionEJamaatID
            Case AccountType.GroupLeader
                plcMainContent.Visible = True
        End Select
        con.Close()
    End Sub
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        da = New OleDb.OleDbDataAdapter("SELECT MAX(JVNo) FROM JournalEntry", con)
        ds = New DataSet
        If da.Fill(ds) Then
            lblTNo.Text = ds.Tables(0).Rows(0)(0) + 1
        Else
            lblTNo.Text = 1
        End If
    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("s", con)
        ds = New DataSet
        da.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()
    End Sub
    Public Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        If (SearchByName) Then
            searchgridupdate()
        Else
            SearchReceiptByRange()
        End If
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
            da = New OleDb.OleDbDataAdapter("SELECT * FROM JournalEntry WHERE JVNo=" & lblTNo.Text & "", con)
            ds = New DataSet
            da.Fill(ds)
            txtDate.Text = ds.Tables(0).Rows(0)(1)
            cboxSname.Text = ds.Tables(0).Rows(0)(2)
            txtNarration.Text = ds.Tables(0).Rows(0)(3)
            cboxFCY.Text = ds.Tables(0).Rows(0)(5)
            txtAmount.Text = ds.Tables(0).Rows(0)(6)
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
        txtNarration.Text = ""
        txtAmount.Text = ""
        dt1.Clear()
    End Sub

    Public Sub GenerateReceipt()
        con.Open()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM JournalEntry WHERE JVNo=" & Val(lblTNo.Text) & " AND Type='RV'", con)
        ds = New DataSet
        If da.Fill(ds) Then
            cm.CommandText = "UPDATE JournalEntry SET DOJ='" & txtDate.Text & "', Account_Name='" & cboxSname.SelectedItem.Text & "', Narration='" & txtNarration.Text & "', Leader_Name='" & lblLogged.Text & "', FCY='" + cboxFCY.Text + "', FCAmount='" & Val(txtAmount.Text) & "', Rate='1', Amount='" & Val(txtAmount.Text) & "',Sign='Cr', Status='Paid', Type='RV' WHERE JVNo=" & Val(lblTNo.Text) & " AND Type='RV' AND Sign='Cr'"
            cm.ExecuteNonQuery()
            cm.CommandText = "UPDATE JournalEntry SET DOJ='" & txtDate.Text & "', Account_Name='Cash Account', Narration='Monthly Contribution by Members', Leader_Name='" & lblLogged.Text & "', FCY='" & cboxFCY.Text & "', FCAmount='" & CType(txtAmount.Text, Integer) & "', Rate='1', Amount='" & CType(txtAmount.Text, Integer) & "',Sign='Dr', Status='Paid', Type='RV' WHERE JVNo=" & Val(lblTNo.Text) & " AND Type='RV' AND Sign='Dr'"
            cm.ExecuteNonQuery()
            Call ClearAll()
        Else
            cm.CommandText = "INSERT INTO JournalEntry (JVNo, DOJ, Account_Name, Narration, Leader_Name, FCY, FCAmount, Rate, Amount, Sign, Status,Type,Ejamaat,PaidAgainst) VALUES (  '" & Val(lblTNo.Text) & "', '" & txtDate.Text & "','" & cboxSname.SelectedItem.Text & "', '" & txtNarration.Text & "','" & lblLogged.Text & "','" + cboxFCY.Text + "','" & Val(txtAmount.Text) & "', '1','" & Val(txtAmount.Text) & "', 'Cr ', 'Paid','RV','" & cboxSname.SelectedValue.Trim & "', '" & drpAccountType.SelectedItem.Value & "')"
            cm.ExecuteNonQuery()
            cm.CommandText = "INSERT INTO JournalEntry (JVNo, DOJ, Account_Name, Narration, Leader_Name, FCY, FCAmount, Rate, Amount, Sign, Status,Type) VALUES (  '" & Val(lblTNo.Text) & "', '" & txtDate.Text & "','Cash Account', 'Monthly Contribution by Members','" & lblLogged.Text & "', '" & cboxFCY.Text & "','" & CType(txtAmount.Text, Integer) & "', '1','" & CType(txtAmount.Text, Integer) & "', 'Dr ', 'Paid','RV')"
            cm.ExecuteNonQuery()
        End If
        plcReceiptConfirmation.Visible = False
        lblMessage.Text = "Receipt voucher added successfully"
        lblMessage.CssClass = "receipt-success"
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddReceipt.Click
        lblMessage.Visible = True
        Dim member As MemberInfo = MemberInfo.GetMember(cboxSname.SelectedValue)
        If lblTNo.Text <> "" Or txtDate.Text <> "" Or txtAmount.Text <> "" Or txtNarration.Text <> "" Or cboxMemberName.Text <> "" Then
            If String.IsNullOrEmpty(member.Email) Then
                lblMessage.Text = "Email address for this member does not exists, member will not be able to receive mail. Do you still want to generate receipt?"
                plcReceiptConfirmation.Visible = True
                lblMessage.CssClass = "receipt-error"
            Else
                GenerateReceipt()
                Dim params As New List(Of MailParameters)
                params.Add(New MailParameters() With {.ParameterName = "##receiptno##", .ParameterValue = lblTNo.Text})
                params.Add(New MailParameters() With {.ParameterName = "##name##", .ParameterValue = member.MemberFullName})
                params.Add(New MailParameters() With {.ParameterName = "##narration##", .ParameterValue = txtNarration.Text})
                params.Add(New MailParameters() With {.ParameterName = "##paymentdate##", .ParameterValue = Convert.ToDateTime(txtDate.Text).ToString("MMMM dd, yyyy")})
                params.Add(New MailParameters() With {.ParameterName = "##amount##", .ParameterValue = txtAmount.Text})
                params.Add(New MailParameters() With {.ParameterName = "##currency##", .ParameterValue = cboxFCY.Text})
                Globals.SendMail(MailType.PaymentReceipt, member.Email, params)
                Call ClearAll()
            End If
        Else
            lblMessage.CssClass = "receipt-error"
            lblMessage.Text = "**Please enter all Details."
        End If
        con.Close()
    End Sub
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchByName = True
        Call searchgridupdate()
    End Sub
    Public Sub searchgridupdate()
        da = New OleDb.OleDbDataAdapter("SELECT JVNo, DOJ as AddedDate, Account_Name, Narration, FCY as CurrencyName, Amount, Sign FROM JournalEntry WHERE Sign='Cr' AND ejamaat='" & cboxMemberName.SelectedValue.Trim & "' AND PaidAgainst='" & drpUserAccountTypeSearch.SelectedValue & "' ORDER BY JVNo DESC", con)
        ds = New DataSet
        da.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()
        trRow.Visible = False
    End Sub
    Private Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        con.Open()

        da = New OleDb.OleDbDataAdapter("SELECT * FROM JournalEntry WHERE JVNo=" & lblTNo.Text & " AND Type='RV' AND Sign='Cr'", con)
        ds = New DataSet

        If lblTNo.Text = "" Then
            lblNoData.Text = "**Please enter valid Transaction No"
            lblNoData.Visible = True
        Else
            If da.Fill(ds) Then
                txtDate.Text = ds.Tables(0).Rows(0)(1)
                cboxSname.SelectedIndex = cboxSname.Items.IndexOf(cboxSname.Items.FindByValue(ds.Tables(0).Rows(0)(2).ToString))
                txtNarration.Text = ds.Tables(0).Rows(0)(3)
                cboxFCY.Text = ds.Tables(0).Rows(0)(5)
                txtAmount.Text = ds.Tables(0).Rows(0)(6)
            Else
                lblNoData.Text = "** Requested Voucher Not Found."
                lblNoData.Visible = True
            End If
        End If

        con.Close()
    End Sub
    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        con.Open()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM JournalEntry WHERE JVNo=" & lblTNo.Text & " AND Type='RV' AND Sign='Cr'", con)
        ds = New DataSet

        If lblTNo.Text = "" Then
            lblNoData.Text = "**Please enter valid Transaction No to delete"
            lblNoData.Visible = True
        ElseIf da.Fill(ds) Then
            txtDate.Text = ds.Tables(0).Rows(0)(1)
            cboxSname.SelectedIndex = cboxSname.Items.IndexOf(cboxSname.Items.FindByValue(ds.Tables(0).Rows(0)(2).ToString))
            txtNarration.Text = ds.Tables(0).Rows(0)(3)
            cboxFCY.Text = ds.Tables(0).Rows(0)(5)
            txtAmount.Text = ds.Tables(0).Rows(0)(6)
            Dim da1 As New OleDb.OleDbDataAdapter("SELECT * FROM JournalEntry WHERE JVNo=" & lblTNo.Text & " AND Type='RV'", con)
            Dim ds1 As New DataSet
            da1.Fill(ds1)
            cm.CommandText = "DELETE JVNo FROM JournalEntry WHERE JVNo=" & lblTNo.Text & " AND Type='RV'"
            cm.ExecuteNonQuery()
            Call ClearAll()
        Else
            lblNoData.Text = "** Requested Voucher Not Found."
            lblNoData.Visible = True
        End If
        con.Close()
    End Sub

    Protected Sub lnkReceiptGenerationConfirm_Click(sender As Object, e As EventArgs)
        Dim btn As LinkButton = CType(sender, LinkButton)
        If btn.ID = "lnkYes" Then
            GenerateReceipt()
        Else
            lblMessage.Visible = False
            plcReceiptConfirmation.Visible = False
        End If
    End Sub

    Private Sub SearchReceiptByRange()
        If txtFromRange.Text <> String.Empty And txtToRange.Text <> String.Empty Then
            Dim journal As List(Of MemberJournal) = New MemberJournal().SearchRangeByGroupLeader(lblLogged.Text, txtFromRange.Text, txtToRange.Text)
            GridView2.DataSource = journal
            GridView2.DataBind()
            trRow.Visible = True
            Dim _totalAmount As Integer = journal.Sum(Function(item) item.Amount)
            lblTotal.Text = "Total Amount: " + _totalAmount.ToString("n0", CultureInfo.InvariantCulture)
        Else
            GridView2.DataSource = Nothing
            GridView2.DataBind()
        End If
    End Sub
    Protected Sub btnSearchByRange_Click(sender As Object, e As EventArgs) Handles btnSearchByRange.Click
        SearchByRange = True
        SearchReceiptByRange()
    End Sub

    Protected Sub cboxSname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxSname.SelectedIndexChanged
        Dim controller As New MemberController
        Dim members As List(Of MemberInfo) = controller.GetAllMembers().FindAll(Function(item) item.EjamaatID = cboxSname.SelectedValue)
        drpAccountType.Items.Clear()
        For Each memer As MemberInfo In members
            If (memer.UserAccountType = "FOSTER") Then
                drpAccountType.Items.Add(New ListItem("Fostership", "Foster"))
            ElseIf (memer.UserAccountType = "KUN") Then
                drpAccountType.Items.Add(New ListItem("KUN", "KUN"))
            End If
        Next
    End Sub

    Protected Sub cboxMemberName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxMemberName.SelectedIndexChanged
        Dim controller As New MemberController
        Dim members As List(Of MemberInfo) = controller.GetAllMembers().FindAll(Function(item) item.EjamaatID = cboxMemberName.SelectedValue)
        drpUserAccountTypeSearch.Items.Clear()
        For Each memer As MemberInfo In members
            If (memer.UserAccountType = "FOSTER") Then
                drpUserAccountTypeSearch.Items.Add(New ListItem("Fostership", "Foster"))
            ElseIf (memer.UserAccountType = "KUN") Then
                drpUserAccountTypeSearch.Items.Add(New ListItem("KUN", "KUN"))
            End If
        Next
    End Sub
End Class