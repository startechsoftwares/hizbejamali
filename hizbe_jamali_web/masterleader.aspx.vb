Partial Public Class masterleader
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
        lblMissing.Visible = False
        If IsPostBack = False Then
            cboxRights.Items.Add("Full Access")
            cboxRights.Items.Add("Limited Access")
        End If
        lblLogged.Text = Session("TID")
        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0).ToString
        Call DatagridUpdate()
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
        con.Close()
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
            da = New OleDb.OleDbDataAdapter("SELECT * FROM GroupLeader WHERE Ejamaat='" & row.Cells(2).Text & "'", con)
            ds = New DataSet
            da.Fill(ds)
            txtNameshort.Text = ds.Tables(0).Rows(0)(0)
            txtNamefull.Text = ds.Tables(0).Rows(0)(1)
            txtEjamaat.Text = ds.Tables(0).Rows(0)(2)
            txtPW.Text = ds.Tables(0).Rows(0)(3).ToString
            cboxRights.SelectedIndex = cboxRights.Items.IndexOf(cboxRights.Items.FindByValue(ds.Tables(0).Rows(0)(4).ToString))
            ModalPopupExtender1.Show()
        End If


        If e.CommandName = "Delete" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            da = New OleDb.OleDbDataAdapter("SELECT Account_Name FROM JournalEntry WHERE Leader_Name='" & row.Cells(3).Text & "'", con)
            ds = New DataSet
            If da.Fill(ds) Then
                lblMissing.Text = "Member cannot be deleted as it has accounting transactions"
                lblMissing.Visible = True
            Else
                cm.CommandText = "DELETE * FROM GroupLeader WHERE Ejamaat='" & row.Cells(2).Text & "'"
                cm.ExecuteNonQuery()
                Call ClearAll()
                Call DatagridUpdate()
                lblMissing.Visible = False
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
        txtNamefull.Text = ""
        txtNameshort.Text = ""
    End Sub
    Private Sub DatagridUpdate()
        'da = New OleDb.OleDbDataAdapter("SELECT * FROM GroupLeader ORDER BY Name", con)
        'ds = New DataSet
        'da.Fill(ds)
        ''GridView2.DataSource = New MemberInfo().GetAllMembers(UserType.All).FindAll(Function(item) item.MemberType <> "")
        GridView2.DataSource = New MemberInfo().GetAllLeaders()
        GridView2.DataBind()

    End Sub
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ModalPopupExtender1.Show()
        Call ClearAll()
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        con.Open()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM GroupLeader WHERE Ejamaat='" & txtEjamaat.Text & "'", con)
        ds = New DataSet
        If da.Fill(ds) Then
            cm.CommandText = "UPDATE GroupLeader SET Name='" & txtNameshort.Text & "', OName='" & txtNamefull.Text & "', MPW='" & txtPW.Text & "', Type='" & cboxRights.Text & "' WHERE  Ejamaat='" & txtEjamaat.Text & "'"
            cm.ExecuteNonQuery()
            cm.CommandText = "UPDATE PartyLedger SET MPW='" & txtPW.Text & "' WHERE Ejamaat='" & txtEjamaat.Text & "'"
            cm.ExecuteNonQuery()
            Call DatagridUpdate()
            lblMissing.Visible = False
            Call ClearAll()
        Else
            If txtNameshort.Text = "" Or txtNamefull.Text = "" Then
                lblMissing.Visible = True
                ModalPopupExtender1.Show()
            Else
                cm.CommandText = "INSERT INTO GroupLeader (Name,OName,Ejamaat,MPW,Type) VALUES ('" & txtNameshort.Text & "','" & txtNamefull.Text & "','" & txtEjamaat.Text & "','" & txtPW.Text & "', '" & cboxRights.Text & "')"
                cm.ExecuteNonQuery()
                cm.CommandText = "UPDATE PartyLedger SET MPW='" & txtPW.Text & "' WHERE Ejamaat='" & txtEjamaat.Text & "'"
                cm.ExecuteNonQuery()
                Call DatagridUpdate()
                lblMissing.Visible = False
                Call ClearAll()
            End If
        End If
        con.Close()


    End Sub

End Class