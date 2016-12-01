Imports System.IO
Partial Public Class mastermember1
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Dim _allGroupMembers As New List(Of MemberInfo)
    Dim member As New MemberInfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
        con.Open()
        cm.Connection = con

        If IsPostBack = False Then
            member = MemberInfo.GetMember(Globals.GetSessionEJamaatID)
            lblLogged.Text = member.GroupLeader
            Call DatagridUpdate()
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
        End If
        con.Close()
    End Sub
    Public Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        DatagridUpdate()
    End Sub
   
    Public Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim idx As Integer = Convert.ToInt32(e.RowIndex)
        Dim row As GridViewRow = GridView2.Rows(idx)
        da = New OleDb.OleDbDataAdapter("SELECT Account_Name FROM JournalEntry WHERE Account_Name='" & row.Cells(3).Text & "'", con)
        ds = New DataSet
        If da.Fill(ds) Then
            lblMissing.Text = "Member cannot be deleted as it has accounting transactions"
            lblMissing.Visible = True
        Else
            cm.CommandText = "DELETE * FROM PartyLedger WHERE Ejamaat='" & row.Cells(2).Text & "'"
            cm.ExecuteNonQuery()
            Call DatagridUpdate()
            lblMissing.Visible = False
        End If
    End Sub
    Public Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
    End Sub
    
    Public Sub DatagridUpdate()
        _allGroupMembers = member.GetAllGroupMembers(Globals.GetSessionEJamaatID).FindAll(Function(item) item.Approved = True And item.AccountType = drpUserType.SelectedValue)
        Dim _list As List(Of MemberInfo)
        If Not cboxStatus1.SelectedValue = "All" Then
            _list = _allGroupMembers.FindAll(Function(item) item.Status = cboxStatus1.SelectedValue)
        Else
            _list = _allGroupMembers
        End If
        GridView2.DataSource = _list
        GridView2.DataBind()
        lblMissing.Visible = True
        lblMissing.Text = "Total members are: " + _list.Count.ToString
    End Sub
    
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        AddMember.EjamaatID = String.Empty
        AddMember.IsNewMemberClicked = True
        ModalPopupExtender1.Show()
        ucAddMember.Page_Load(sender, e)
    End Sub

    Protected Sub btnEdit_Command(sender As Object, e As CommandEventArgs)
        AddMember.EjamaatID = e.CommandName
        ModalPopupExtender1.Show()
        ucAddMember.Page_Load(sender, e)
    End Sub

    Protected Sub btnSearchMember_Click(sender As Object, e As EventArgs)
        DatagridUpdate()
    End Sub
End Class