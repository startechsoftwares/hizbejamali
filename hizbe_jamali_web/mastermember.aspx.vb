Imports System.IO
Partial Public Class mastermember
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        Globals.RedirectUserIfLoggedOut()
        con.Open()
        cm.Connection = con
        If IsPostBack = False Then
            cboxStatus1.Items.Add("Active")
            cboxStatus1.Items.Add("Inactive")
            cboxStatus1.Items.Add("Pending Approval")
            cboxStatus1.Items.Add("Show All Records")

            Dim leaders As List(Of MemberInfo) = New MemberInfo().GetAllLeaders()
            drpLeaders.DataSource = leaders
            drpLeaders.DataTextField = "MemberName"
            drpLeaders.DataValueField = "EjamaatID"
            drpLeaders.DataBind()

            drpLeaders.SelectedValue = Globals.GetSessionEJamaatID
            Dim account As AccountType = MemberInfo.LeaderType(Globals.GetSessionEJamaatID)
            Select Case account
                Case AccountType.Member
                    plcErrorMessage.Visible = True
                    lnkDashBoard.NavigateUrl = "~/homemember.aspx?TD=" + Globals.GetSessionEJamaatID
                Case AccountType.Administrator
                    plcMainContent.Visible = True
                Case AccountType.GroupLeader
                    plcErrorMessage.Visible = True
                    lnkDashBoard.NavigateUrl = "~/homeadmin1.aspx?TD=" + Globals.GetSessionEJamaatID
            End Select
            lblMissing.Visible = False
            lblLogged.Text = Session("TID")
            da = New OleDb.OleDbDataAdapter("SELECT Group_Leader FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
            ds = New DataSet
            da.Fill(ds)
            lblLogged.Text = ds.Tables(0).Rows(0)(0).ToString
            FillMembers(drpLeaders.SelectedItem.Text, cboxStatus1.SelectedValue, drpUserType.SelectedValue)
        End If

        con.Close()
    End Sub
    Public Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        FillMembers(drpLeaders.SelectedItem.Text, cboxStatus1.SelectedValue, drpUserType.SelectedValue)
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
            con.Open()
            cm.ExecuteNonQuery()

            Call Status()
            lblMissing.Visible = False
            con.Close()
        End If
    End Sub
    Public Sub Status()
        da = New OleDb.OleDbDataAdapter("SELECT Name FROM GroupLeader WHERE Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet

        If cboxStatus1.Text = "Active" Then
            If da.Fill(ds) Then
                da = New OleDb.OleDbDataAdapter("SELECT Ejamaat, Member_Name, Mobile FROM PartyLedger WHERE Status='Active' AND Group_Leader='" & drpLeaders.SelectedItem.Text & "' ORDER BY Member_Name", con)
                ds = New DataSet
                da.Fill(ds)
                GridView2.DataSource = ds
                GridView2.DataBind()
                da = New OleDb.OleDbDataAdapter("SELECT COUNT(Status) AS cnt FROM Partyledger WHERE Status='Active' AND Group_Leader='" & drpLeaders.SelectedItem.Text & "'", con)
                ds = New DataSet
                da.Fill(ds)
                lblMissing.Text = "Total No of Records Found:- " & ds.Tables(0).Rows(0)(0)
                lblMissing.Visible = True
            Else
                lblMissing.Text = "No records found"
                lblMissing.Visible = True
            End If
        End If


        If cboxStatus1.Text = "Inactive" Then
            If da.Fill(ds) Then
                da = New OleDb.OleDbDataAdapter("SELECT Ejamaat, Member_Name, Mobile FROM PartyLedger WHERE Status='Inactive' AND Group_Leader='" & drpLeaders.SelectedItem.Text & "' ORDER BY Member_Name", con)
                ds = New DataSet
                da.Fill(ds)
                GridView2.DataSource = ds
                GridView2.DataBind()
                da = New OleDb.OleDbDataAdapter("SELECT COUNT(Status) AS cnt FROM Partyledger WHERE Status='Inactive' AND Group_Leader='" & drpLeaders.SelectedItem.Text & "'", con)
                ds = New DataSet
                da.Fill(ds)
                lblMissing.Text = "Total No of Records Found:- " & ds.Tables(0).Rows(0)(0)
                lblMissing.Visible = True
            Else
                lblMissing.Text = "No records found"
                lblMissing.Visible = True
            End If
        End If

        If cboxStatus1.Text = "Pending Approval" Then
            If da.Fill(ds) Then
                da = New OleDb.OleDbDataAdapter("SELECT Ejamaat, Member_Name, Mobile FROM PartyLedger WHERE Approved=False AND CoreMember='" & drpLeaders.SelectedItem.Text & "' ORDER BY Member_Name", con)
                ds = New DataSet
                da.Fill(ds)
                GridView2.DataSource = ds
                GridView2.DataBind()
                da = New OleDb.OleDbDataAdapter("SELECT COUNT(Status) AS cnt FROM Partyledger WHERE Approved=False AND CoreMember='" & drpLeaders.SelectedItem.Text & "'", con)
                ds = New DataSet
                da.Fill(ds)
                lblMissing.Text = "Total No of Records Found:- " & ds.Tables(0).Rows(0)(0)
                lblMissing.Visible = True
            Else
                lblMissing.Text = "No records found"
                lblMissing.Visible = True
            End If
        End If

        If cboxStatus1.Text = "Show All Records" Then
            If da.Fill(ds) Then
                da = New OleDb.OleDbDataAdapter("SELECT Ejamaat, Member_Name, Mobile FROM PartyLedger WHERE Group_Leader='" & drpLeaders.SelectedItem.Text & "' ORDER BY Member_Name", con)
                ds = New DataSet
                da.Fill(ds)
                GridView2.DataSource = ds
                GridView2.DataBind()
                da = New OleDb.OleDbDataAdapter("SELECT COUNT(Status) AS cnt FROM Partyledger WHERE Group_Leader='" & drpLeaders.SelectedItem.Text & "'", con)
                ds = New DataSet
                da.Fill(ds)
                lblMissing.Text = "Total No of Records Found:- " & ds.Tables(0).Rows(0)(0)
                lblMissing.Visible = True
            Else
                lblMissing.Text = "No records found"
                lblMissing.Visible = True
            End If
        End If

    End Sub

    Protected Sub drpLeaders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles drpLeaders.SelectedIndexChanged
        Dim member As List(Of MemberInfo) = New MemberInfo().GetAllLeaders()
        cboxStatus1.Items.Clear()
        'If member.Exists(Function(item) item.MemberType = "Full Access" And item.EjamaatID = drpLeaders.SelectedValue) Then
        If drpLeaders.SelectedValue = Globals.GetSessionEJamaatID Then
            cboxStatus1.Items.Add("Active")
            cboxStatus1.Items.Add("Inactive")
            cboxStatus1.Items.Add("Pending Approval")
            cboxStatus1.Items.Add("Show All Records")
        Else
            cboxStatus1.Items.Add("Active")
            cboxStatus1.Items.Add("Inactive")
            cboxStatus1.Items.Add("Show All Records")
        End If
        cboxStatus1.SelectedValue = "Active"

    End Sub

    Protected Sub btnEdit_Command(sender As Object, e As CommandEventArgs)
        AddMember.EjamaatID = e.CommandName
        ModalPopupExtender1.Show()
        ucAddMember.Page_Load(sender, e)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        AddMember.EjamaatID = String.Empty
        AddMember.IsNewMemberClicked = True
        ModalPopupExtender1.Show()
        ucAddMember.Page_Load(sender, e)
    End Sub

    Protected Sub btnSearchMember_Click(sender As Object, e As EventArgs)
        FillMembers(drpLeaders.SelectedItem.Text, cboxStatus1.SelectedValue, drpUserType.SelectedValue)
        
    End Sub


    Public Sub FillMembers(leaderName As String, status As String, userType As String)
        Dim query As String = String.Empty
        Dim memberSeachStatus As String = String.Empty
        Dim isCoreMember As Boolean = False
        If drpLeaders.SelectedValue = Globals.GetSessionEJamaatID Then
            isCoreMember = True
        End If
        If (isCoreMember And status = "Pending Approval") Then
            query = "SELECT Ejamaat, Member_Name, Mobile FROM PartyLedger WHERE Approved=False AND CoreMember='" & drpLeaders.SelectedItem.Text & "' and Ejamaat IN (select ITSID from UserAccountType where AccountType = '" + userType + "') ORDER BY Member_Name"
        ElseIf status = "Show All Records" Then
            query = "SELECT Ejamaat, Member_Name, Mobile FROM PartyLedger WHERE Group_Leader='" & drpLeaders.SelectedItem.Text & "' and Ejamaat IN (select ITSID from UserAccountType where AccountType = '" + userType + "') ORDER BY Member_Name"
        Else
            query = "SELECT Ejamaat, Member_Name, Mobile FROM PartyLedger WHERE Status='" + status + "' AND Group_Leader='" & drpLeaders.SelectedItem.Text & "' and Ejamaat IN (select ITSID from UserAccountType where AccountType = '" + userType + "') ORDER BY Member_Name"
        End If
        Dim dt As New DataTable
        Dim adapter As New OleDb.OleDbDataAdapter(query, Globals.DatabaseConnection.ConnectionString)
        adapter.Fill(dt)
        GridView2.DataSource = dt
        GridView2.DataBind()
        lblMissing.Visible = True
        lblMissing.Text = "Total Members are: " & dt.Rows.Count.ToString
    End Sub
End Class