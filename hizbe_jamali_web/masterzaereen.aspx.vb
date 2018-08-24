Imports System.IO
Partial Public Class masterzaereen
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
        Call DatagridUpdate()
        lblMissing.Visible = False

        lblLogged.Text = Session("TID")
        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0)
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
            lblTNo.Text = row.Cells(2).Text.ToString
            txtEjamaat.Text = row.Cells(3).Text.ToString
            da = New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenLedger WHERE Ejamaat='" & txtEjamaat.Text & "'", con)
            ds = New DataSet
            da.Fill(ds)
            txtName.Text = ds.Tables(0).Rows(0)(1)
            txtAge.Text = ds.Tables(0).Rows(0)(2)
            txtEjamaat.Text = ds.Tables(0).Rows(0)(3)
            txtContact.Text = ds.Tables(0).Rows(0)(4)
            txtDate.Text = ds.Tables(0).Rows(0)(5)
            If Not String.IsNullOrEmpty(ds.Tables(0).Rows(0)(6)) Then
                txtTripDays.Text = ds.Tables(0).Rows(0)(6)
            End If
            txtOccupation.Text = ds.Tables(0).Rows(0)(7)
            txtAddress.Text = ds.Tables(0).Rows(0)(8).ToString
            txtTripExp.Text = ds.Tables(0).Rows(0)(9)
            txtRemarks.Text = ds.Tables(0).Rows(0)(11).ToString
            txtStatus.Text = ds.Tables(0).Rows(0)(12).ToString
            ModalPopupExtender1.Show()
        End If


        If e.CommandName = "Delete" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            da = New OleDb.OleDbDataAdapter("SELECT Account_Name FROM JournalEntry WHERE Account_Name='" & row.Cells(4).Text & "'", con)
            ds = New DataSet
            If da.Fill(ds) Then
                lblMissing.Text = "Zaereen cannot be deleted as it has accounting transactions"
                lblMissing.Visible = True
            Else
                cm.CommandText = "DELETE * FROM ZaereenLedger WHERE Ejamaat='" & row.Cells(3).Text & "'"
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
        lblTNo.Text = ""
        txtContact.Text = ""
        txtEjamaat.Text = ""
        txtName.Text = ""
        txtAddress.Text = ""
        txtDate.Text = ""
        txtName.Text = ""
        txtOccupation.Text = ""
        txtRemarks.Text = ""
        txtStatus.Text = ""
        txtTripDays.Text = ""
        txtTripExp.Text = ""
        txtAge.Text = ""
    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT Account_No,Zaereen_Name, Ejamaat, TripExp, DOJ FROM ZaereenLedger ORDER BY Account_No DESC", con)
        ds = New DataSet
        da.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()

    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        con.Open()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenLedger WHERE Account_No=" & lblTNo.Text & "", con)
        ds = New DataSet
        If da.Fill(ds) Then
            cm.CommandText = "DELETE * FROM ZaereenLedger WHERE Account_No=" & lblTNo.Text & ""
            cm.ExecuteNonQuery()
            cm.CommandText = "INSERT INTO ZaereenLedger (Account_No,Zaereen_Name,Age,Ejamaat,Mobile,DOJ,Trip,Occupation,Address,TripExp,Remarks,Status) VALUES (" & lblTNo.Text & ", '" & txtName.Text & "','" & txtAge.Text & "', '" & txtEjamaat.Text & "','" & txtContact.Text & "', '" & txtDate.Text & "', '" & txtTripDays.Text & "','" & txtOccupation.Text & "','" & txtAddress.Text & "','" & txtTripExp.Text & "', '" & txtRemarks.Text & "', '" & txtStatus.Text & "')"
            cm.ExecuteNonQuery()
            Call DatagridUpdate()
            lblMissing.Visible = False
            Call ClearAll()
        Else
            If txtName.Text = "" Or txtEjamaat.Text = "" Or txtContact.Text = "" Then
                lblMissing.Visible = True
            Else
                cm.CommandText = "INSERT INTO ZaereenLedger (Account_No,Zaereen_Name,Age,Ejamaat,Mobile,DOJ,Trip,Occupation,Address,TripExp,Remarks,Status) VALUES (" & lblTNo.Text & ", '" & txtName.Text & "','" & txtAge.Text & "', '" & txtEjamaat.Text & "','" & txtContact.Text & "', '" & txtDate.Text & "', '" & txtTripDays.Text & "','" & txtOccupation.Text & "','" & txtAddress.Text & "','" & txtTripExp.Text & "', '" & txtRemarks.Text & "', '" & txtStatus.Text & "')"
                cm.ExecuteNonQuery()
                Call DatagridUpdate()
                lblMissing.Visible = False
                Call ClearAll()
            End If
        End If

        con.Close()
    End Sub
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        da = New OleDb.OleDbDataAdapter("SELECT MAX(Account_No) FROM ZaereenLedger", con)
        ds = New DataSet
        If da.Fill(ds) Then
            lblTNo.Text = ds.Tables(0).Rows(0)(0) + 1
            ModalPopupExtender1.Show()
        Else
            lblTNo.Text = 1
            ModalPopupExtender1.Show()
        End If
        txtContact.Text = ""
        txtEjamaat.Text = ""
        txtName.Text = ""
        txtAddress.Text = ""
        txtDate.Text = ""
        txtName.Text = ""
        txtOccupation.Text = ""
        txtRemarks.Text = ""
        txtStatus.Text = ""
        txtTripDays.Text = ""
        txtTripExp.Text = ""
        txtAge.Text = ""
    End Sub
End Class