Public Partial Class repsoa
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Dim member As MemberInfo
    Dim _membersList As List(Of MemberInfo)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
        
        Dim _dropdownMembers = New MemberInfo().GetAllMembers(Hizbe_Jamali_Web.UserType.Active).OrderBy(Function(z) z.MemberFullName).GroupBy(Function(x) New With {Key x.MemberFullName, Key x.EjamaatID}).Select(Function(group) New With {Key .MemberFullName = group.Key.MemberFullName, Key .EjamaatID = group.Key.EjamaatID}).ToList()
        Dim _leaders As List(Of MemberInfo) = New MemberInfo().GetAllLeaders()
        
        If IsPostBack = False Then
            Dim userType As AccountType = MemberInfo.LeaderType(Globals.GetSessionEJamaatID)
            Select Case userType
                Case AccountType.Administrator
                    trLeader.Visible = True

                    cboxGroupLeader.DataSource = _leaders
                    cboxGroupLeader.DataTextField = "MemberName"
                    cboxGroupLeader.DataValueField = "EjamaatID"
                    cboxGroupLeader.DataBind()
                    cboxGroupLeader.Items.Insert(0, "All")

                    cboxMname.DataSource = _dropdownMembers
                    cboxMname.DataTextField = "MemberFullName"
                    cboxMname.DataValueField = "EjamaatID"
                    cboxMname.DataBind()

                Case AccountType.GroupLeader
                    Dim _members As List(Of MemberInfo) = New MemberInfo().GetAllGroupMembers(Globals.GetSessionEJamaatID)
                    cboxMname.DataSource = _members
                    cboxMname.DataTextField = "MemberFullName"
                    cboxMname.DataValueField = "EjamaatID"
                    cboxMname.DataBind()
            End Select
        End If
        lblLogged.Text = _leaders.Find(Function(item) item.EjamaatID = Globals.GetSessionEJamaatID).MemberFullName
        Select Case Globals.LoggedInUserType
            Case AccountType.Administrator
                plcAdmin.Visible = True
            Case AccountType.GroupLeader
                plcGroupLeader.Visible = True
        End Select
    End Sub
    Public Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        BindGrid()
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

    Public Sub BindGrid()
        da = New OleDb.OleDbDataAdapter("SELECT JVNo, DOJ, Narration, FCY, Amount, Sign FROM JournalEntry WHERE  Ejamaat = '" & cboxMname.SelectedValue.Trim & "' and PaidAgainst='" + drpAccountType.SelectedValue + "' ORDER BY DOJ DESC", con)
        ds = New DataSet
        da.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()
        Call TotalAmt()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim _list As New List(Of MemberInfo)
        _membersList = New MemberInfo().GetAllMembers(UserType.All)

        If cboxGroupLeader.SelectedItem.Text <> "All" Then
            _list = _membersList.FindAll(Function(item) item.GroupLeader = cboxGroupLeader.SelectedItem.Text)
        Else
            _list = _membersList
        End If

        If drpStatus.SelectedIndex > 0 Then
            _list = _list.FindAll(Function(item) item.Status = drpStatus.SelectedItem.Text)
        End If
        cboxMname.Items.Clear()
        cboxMname.DataSource = _list.FindAll(Function(item) item.UserAccountType = drpAccountType.SelectedItem.Text.ToUpper)
        cboxMname.DataTextField = "MemberFullName"
        cboxMname.DataValueField = "EjamaatID"
        cboxMname.DataBind()
    End Sub
    Private Sub cboxMname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxMname.SelectedIndexChanged
        BindGrid()
    End Sub
    Public Sub TotalAmt()
        da = New OleDb.OleDbDataAdapter("SELECT SUM(Amount) FROM JournalEntry WHERE  ejamaat = '" & cboxMname.SelectedValue.Trim & "' and PaidAgainst='" + drpAccountType.SelectedValue + "'", con)
        ds = New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(ds.Tables(0).Rows(0)(0).ToString) Then
                lblAccountBal.Text = CType(ds.Tables(0).Rows(0)(0).ToString, Double).ToString("0.00")
            Else
                lblAccountBal.Text = "0.00"
            End If
        Else
            lblAccountBal.Text = "0.00"
        End If
    End Sub
End Class