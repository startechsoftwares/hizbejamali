Public Partial Class mastertravel
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

        lblLogged.Text = Session("TID")
        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0)
        da = New OleDb.OleDbDataAdapter("SELECT Name FROM GroupLeader WHERE  OName='" & lblLogged.Text & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0)
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
            lblAccountCode.Text = row.Cells(2).Text.ToString
            da = New OleDb.OleDbDataAdapter("SELECT * FROM SupplierLedger WHERE Account_No=" & lblAccountCode.Text & "", con)
            ds = New DataSet
            da.Fill(ds)
            txtSupplierName.Text = ds.Tables(0).Rows(0)(1)
            txtContact.Text = ds.Tables(0).Rows(0)(2)
            txtTelephone.Text = ds.Tables(0).Rows(0)(3)
            txtFax.Text = ds.Tables(0).Rows(0)(4).ToString
            txtMobile.Text = ds.Tables(0).Rows(0)(5)
            txtAddress.Text = ds.Tables(0).Rows(0)(6)
            txtEmail.Text = ds.Tables(0).Rows(0)(7)
            ModalPopupExtender1.Show()
        End If


        If e.CommandName = "Delete" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            da = New OleDb.OleDbDataAdapter("SELECT Account_Name FROM JournalEntry WHERE Account_Name=" & row.Cells(3).Text & "", con)
            ds = New DataSet
            If da.Fill(ds) Then
                lblMissing.Text = "Member cannot be deleted as it has accounting transactions"
                lblMissing.Visible = True
            Else
                cm.CommandText = "DELETE * FROM SupplierLedger WHERE Account_No=" & row.Cells(2).Text & ""
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
        lblAccountCode.Text = ""
        txtAddress.Text = ""
        txtContact.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        txtMobile.Text = ""
        txtSupplierName.Text = ""
        txtTelephone.Text = ""

    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT Account_No, Supplier_Name, Contact,Mobile FROM SupplierLedger", con)
        ds = New DataSet
        da.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()

    End Sub
    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        da = New OleDb.OleDbDataAdapter("SELECT MAX(Account_No) FROM SupplierLedger", con)
        ds = New DataSet
        If da.Fill(ds) Then
            lblAccountCode.Text = ds.Tables(0).Rows(0)(0) + 1
            ModalPopupExtender1.Show()
        Else
            lblAccountCode.Text = 1
            ModalPopupExtender1.Show()
        End If
        txtAddress.Text = ""
        txtContact.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        txtMobile.Text = ""
        txtSupplierName.Text = ""
        txtTelephone.Text = ""
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        con.Open()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM SupplierLedger WHERE Account_No=" & lblAccountCode.Text & "", con)
        ds = New DataSet
        If da.Fill(ds) Then
            cm.CommandText = "DELETE * FROM SupplierLedger WHERE Account_No=" & lblAccountCode.Text & ""
            cm.ExecuteNonQuery()
            cm.CommandText = "INSERT INTO SupplierLedger (Account_No,Supplier_Name,Contact,TelNo,FaxNo,Mobile,Address,Email) VALUES (" & lblAccountCode.Text & ",'" & txtSupplierName.Text & "', '" & txtContact.Text & "','" & txtTelephone.Text & "', '" & txtFax.Text & "', '" & txtMobile.Text & "','" & txtAddress.Text & "', '" & txtEmail.Text & "')"
            cm.ExecuteNonQuery()
            Call DatagridUpdate()
            lblMissing.Visible = False
            Call ClearAll()
        Else
            If txtSupplierName.Text = "" Then
                lblMissing.Visible = True
                ModalPopupExtender1.Show()
            Else
                cm.CommandText = "INSERT INTO SupplierLedger (Account_No,Supplier_Name,Contact,TelNo,FaxNo,Mobile,Address,Email) VALUES (" & lblAccountCode.Text & ",'" & txtSupplierName.Text & "', '" & txtContact.Text & "','" & txtTelephone.Text & "', '" & txtFax.Text & "', '" & txtMobile.Text & "','" & txtAddress.Text & "', '" & txtEmail.Text & "')"
                cm.ExecuteNonQuery()
                Call DatagridUpdate()
                lblMissing.Visible = False
                Call ClearAll()
            End If
        End If
        con.Close()


    End Sub
End Class