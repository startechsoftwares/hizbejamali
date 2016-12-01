Imports System.IO
Partial Public Class repzaereenverify
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Public Wrap As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
        con.Open()
        cm.Connection = con
        Call DatagridUpdate()
        lblMissing.Visible = False

        If IsPostBack = False Then
            cboxStatusZ.Items.Add("Pending")
            cboxStatusZ.Items.Add("Approved")
            cboxStatusZ.Items.Add("Rejected")
            cboxStatusZ.Items.Add("Travelled")
            cboxStatusZ.Items.Add("Show All Records")

            cboxStatus.Items.Add("Pending")
            cboxStatus.Items.Add("Approved")
            cboxStatus.Items.Add("Rejected")
            cboxStatus.Items.Add("Travelled")
            cboxTravelled.Items.Add("Pending")
            cboxTravelled.Items.Add("Hizbe Jamali")
            cboxTravelled.Items.Add("Amatullah Trust")
            cboxTravelled.Items.Add("Himself")
        End If

        lblLogged.Text = Session("TID")
        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0).ToString

        Call TotalRecords()
        lblremarks.Text = ""

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

        If e.CommandName = "Select" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            lblTNo.Text = row.Cells(3).Text.ToString
            da = New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & lblTNo.Text & "", con)
            ds = New DataSet
            da.Fill(ds)
            txtDate.Text = ds.Tables(0).Rows(0)(1)
            txtEjamaat.Text = ds.Tables(0).Rows(0)(2).ToString
            txtName.Text = ds.Tables(0).Rows(0)(3)
            txtGender.Text = ds.Tables(0).Rows(0)(4)
            txtAge.Text = ds.Tables(0).Rows(0)(5).ToString
            txtContact.Text = ds.Tables(0).Rows(0)(6).ToString
            txtOccupation.Text = ds.Tables(0).Rows(0)(7).ToString
            txtRecMem.Text = ds.Tables(0).Rows(0)(8).ToString
            txtRecMemHJ.Text = ds.Tables(0).Rows(0)(9).ToString
            txtIncome.Text = ds.Tables(0).Rows(0)(14).ToString
            txtExp.Text = ds.Tables(0).Rows(0)(15).ToString
            txtDependants.Text = ds.Tables(0).Rows(0)(16).ToString
            txtMedical.Text = ds.Tables(0).Rows(0)(17).ToString
            txtJama.Text = ds.Tables(0).Rows(0)(18).ToString
            txtNiyyat.Text = ds.Tables(0).Rows(0)(19).ToString
            txtZiyarat.Text = ds.Tables(0).Rows(0)(20).ToString
            txtZiyaratName.Text = ds.Tables(0).Rows(0)(21).ToString
            txtAddress.Text = ds.Tables(0).Rows(0)(22).ToString
            txtPPVal.Text = ds.Tables(0).Rows(0)(23).ToString
            txtPPExp.Text = ds.Tables(0).Rows(0)(24).ToString
            txtRemarks.Text = ds.Tables(0).Rows(0)(25).ToString
            cboxStatus.Text = ds.Tables(0).Rows(0)(26).ToString
            txtSanction.Text = ds.Tables(0).Rows(0)(27).ToString
            txtContact1.Text = ds.Tables(0).Rows(0)(28).ToString
            txtContact2.Text = ds.Tables(0).Rows(0)(29).ToString
            cboxTravelled.SelectedIndex = cboxTravelled.Items.IndexOf(cboxTravelled.Items.FindByValue(ds.Tables(0).Rows(0)(30).ToString))
            Dim da1 As New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & lblTNo.Text & " AND Dadi='1'", con)
            Dim ds1 As New DataSet
            If da1.Fill(ds1) Then
                chkbxDadi.Checked = True
            Else
                chkbxDadi.Checked = False
            End If
            Dim da2 As New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & lblTNo.Text & " AND Topi='1'", con)
            Dim ds2 As New DataSet
            If da2.Fill(ds2) Then
                chkbxTopi.Checked = True
            Else
                chkbxTopi.Checked = False
            End If
            Dim da3 As New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & lblTNo.Text & " AND Rida='1'", con)
            Dim ds3 As New DataSet
            If da3.Fill(ds3) Then
                chkbxRida.Checked = True
            Else
                chkbxRida.Checked = False
            End If
            Dim da4 As New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & lblTNo.Text & " AND Moharramat='1'", con)
            Dim ds4 As New DataSet
            If da4.Fill(ds4) Then
                chkbxMoharramat.Checked = True
            Else
                chkbxMoharramat.Checked = False
            End If

            Dim da5 As New OleDb.OleDbDataAdapter("SELECT Mobile FROM PartyLedger WHERE Member_Name='" & txtRecMem.Text & "'", con)
            Dim ds5 As New DataSet
            If da5.Fill(ds5) Then
                txtContactMember.Text = ds5.Tables(0).Rows(0)(0).ToString
               
            End If

            Dim da6 As New OleDb.OleDbDataAdapter("SELECT Mobile FROM PartyLedger WHERE Group_Leader='" & txtRecMemHJ.Text & "' AND MPW <> '' ", con)
            Dim ds6 As New DataSet
            If da6.Fill(ds6) Then
                txtContactLeader.Text = ds6.Tables(0).Rows(0)(0).ToString
            End If

            ModalPopupExtender1.Show()
        End If


        If e.CommandName = "Delete" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            da = New OleDb.OleDbDataAdapter("SELECT Account_Name FROM JournalEntry WHERE Account_Name='" & row.Cells(5).Text & "'", con)
            ds = New DataSet
            If da.Fill(ds) Then
                lblMissing.Text = "Zaereen cannot be deleted as it has accounting transactions"
                lblMissing.Visible = True
            Else
                cm.CommandText = "DELETE * FROM ZaereenVerify WHERE Account_No=" & row.Cells(3).Text & " "
                cm.ExecuteNonQuery()
                Call ClearAll()
                Call DatagridUpdate()
                lblMissing.Visible = False
            End If

        End If

        If e.CommandName = "Edit" Then
            Dim idx As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GridView2.Rows(idx)
            Session("VNO") = row.Cells(3).Text.ToString
            da = New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & Session("VNO") & "", con)
            ds = New DataSet

            If da.Fill(ds) Then
                Response.Redirect("formZaereen.aspx?VNOID=" + Session("VNO") + "")
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
        txtName.Text = ""
        txtOccupation.Text = ""
        txtRemarks.Text = ""
        txtComment.Text = ""
        txtAge.Text = ""
    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT Account_No,DOJ, Zaereen_Name, Age FROM ZaereenVerify ORDER BY Account_No DESC", con)
        ds = New DataSet
        da.Fill(ds)
        GridView2.DataSource = ds
        GridView2.DataBind()

    End Sub
    Private Sub TotalRecords()
        If cboxStatusZ.Text = "Pending" Then
            da = New OleDb.OleDbDataAdapter("SELECT COUNT(ZStatus) AS cnt FROM ZaereenVerify WHERE ZStatus='Pending'", con)
            ds = New DataSet
            da.Fill(ds)
            lblMissing.Text = "Total No of Records Found:- " & ds.Tables(0).Rows(0)(0)
            lblMissing.Visible = True
            da = New OleDb.OleDbDataAdapter("SELECT Account_No,DOJ, Zaereen_Name, Age FROM ZaereenVerify WHERE ZStatus='Pending' ORDER BY Account_No DESC", con)
            ds = New DataSet
            da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()
        End If

        If cboxStatusZ.Text = "Approved" Then
            da = New OleDb.OleDbDataAdapter("SELECT SUM(AmtSanction) FROM ZaereenVerify WHERE ZStatus='Approved'", con)
            ds = New DataSet

            If da.Fill(ds) Then
                Dim num As Integer
                num = ds.Tables(0).Rows(0)(0).ToString
                lblMissing.Text = "Total amount Approved for Zaereen:-" & num.ToString("N")
                lblMissing.Visible = True
                da = New OleDb.OleDbDataAdapter("SELECT Account_No,DOJ, Zaereen_Name, Age FROM ZaereenVerify WHERE ZStatus='Approved' ORDER BY Account_No DESC", con)
                ds = New DataSet
                da.Fill(ds)
                GridView2.DataSource = ds
                GridView2.DataBind()
            End If
        End If

        If cboxStatusZ.Text = "Rejected" Then
            da = New OleDb.OleDbDataAdapter("SELECT COUNT(ZStatus) AS cnt FROM ZaereenVerify WHERE ZStatus='Rejected'", con)
            ds = New DataSet
            da.Fill(ds)
            lblMissing.Text = "Total No of Records Found:- " & ds.Tables(0).Rows(0)(0)
            lblMissing.Visible = True
            da = New OleDb.OleDbDataAdapter("SELECT Account_No,DOJ, Zaereen_Name, Age FROM ZaereenVerify WHERE ZStatus='Rejected' ORDER BY Account_No DESC", con)
            ds = New DataSet
            da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()
        End If

        If cboxStatusZ.Text = "Travelled" Then
            da = New OleDb.OleDbDataAdapter("SELECT COUNT(ZStatus) AS cnt FROM ZaereenVerify WHERE ZStatus='Travelled'", con)
            ds = New DataSet
            da.Fill(ds)
            lblMissing.Text = "Total No of Records Found:- " & ds.Tables(0).Rows(0)(0)
            lblMissing.Visible = True
            da = New OleDb.OleDbDataAdapter("SELECT Account_No,DOJ, Zaereen_Name, Age FROM ZaereenVerify WHERE ZStatus='Travelled' ORDER BY Account_No DESC", con)
            ds = New DataSet
            da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()
        End If

        If cboxStatusZ.Text = "Show All Records" Then
            da = New OleDb.OleDbDataAdapter("SELECT COUNT(ZStatus) AS cnt FROM ZaereenVerify", con)
            ds = New DataSet
            da.Fill(ds)
            lblMissing.Text = "Total No of Records Found:- " & ds.Tables(0).Rows(0)(0)
            lblMissing.Visible = True
            da = New OleDb.OleDbDataAdapter("SELECT Account_No,DOJ, Zaereen_Name, Age FROM ZaereenVerify ORDER BY Account_No DESC", con)
            ds = New DataSet
            da.Fill(ds)
            GridView2.DataSource = ds
            GridView2.DataBind()
        End If





    End Sub
    Private Sub cboxStatusZ_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxStatusZ.SelectedIndexChanged
        Call TotalRecords()
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        con.Open()
        If cboxStatus.Text = "Travelled" Then
            If lblTNo.Text = "" Or txtName.Text = "" Or txtEjamaat.Text = "" Or txtAge.Text = "" Or txtContact.Text = "" Or txtOccupation.Text = "" Or txtRecMem.Text = "" Or txtRecMemHJ.Text = "" Or txtGender.Text = "" Or txtIncome.Text = "" Or txtExp.Text = "" Or txtDependants.Text = "" Or txtMedical.Text = "" Or txtJama.Text = "" Or txtNiyyat.Text = "" Or txtAddress.Text = "" Or txtRemarks.Text = "" Or txtSanction.Text = "" Or cboxTravelled.Text = "Pending" Then
                lblremarks.Text = "** All feilds are mandatory to mark as Travelled"
                ModalPopupExtender1.Show()
            Else
                cm.CommandText = "UPDATE ZaereenVerify SET ZStatus='" & cboxStatus.Text & "', Travel='" & cboxTravelled.Text & "' WHERE Account_No=" & lblTNo.Text & ""
                cm.ExecuteNonQuery()
                lblremarks.Text = ""
                Call TotalRecords()
            End If

        ElseIf cboxStatus.Text = "Pending" Then
            cm.CommandText = "UPDATE ZaereenVerify SET ZStatus='" & cboxStatus.Text & "' WHERE Account_No=" & lblTNo.Text & ""
            cm.ExecuteNonQuery()
            Call TotalRecords()

        ElseIf cboxStatus.Text = "Approved" Then
            If lblTNo.Text = "" Or txtName.Text = "" Or txtEjamaat.Text = "" Or txtAge.Text = "" Or txtContact.Text = "" Or txtOccupation.Text = "" Or txtRecMem.Text = "" Or txtRecMemHJ.Text = "" Or txtGender.Text = "" Or txtIncome.Text = "" Or txtExp.Text = "" Or txtDependants.Text = "" Or txtMedical.Text = "" Or txtJama.Text = "" Or txtNiyyat.Text = "" Or txtAddress.Text = "" Or txtRemarks.Text = "" Or txtSanction.Text = "" Then
                lblremarks.Text = "** All feilds are mandatory to mark as Approved"
                txtSanction.Enabled = True
                ModalPopupExtender1.Show()
            Else
                cm.CommandText = "UPDATE ZaereenVerify SET ZStatus='" & cboxStatus.Text & "', AmtSanction='" & txtSanction.Text & "' WHERE Account_No=" & lblTNo.Text & ""
                cm.ExecuteNonQuery()
                lblremarks.Text = ""
                Call TotalRecords()
            End If

        ElseIf cboxStatus.Text = "Rejected" Then
            If txtComment.Text = "" Then
                txtComment.Focus()
                lblremarks.Text = "** Please enter reason for Rejection"
                ModalPopupExtender1.Show()
            Else
                cm.CommandText = "UPDATE ZaereenVerify SET ZStatus='" & cboxStatus.Text & "', Remarks='" & txtComment.Text & "' WHERE Account_No=" & lblTNo.Text & ""
                cm.ExecuteNonQuery()
                txtComment.Text = ""
                lblremarks.Text = ""
                Call TotalRecords()
            End If

        End If

        con.Close()
    End Sub
    Private Sub Approved()
        If lblTNo.Text = "" Or txtName.Text = "" Or txtEjamaat.Text = "" Or txtAge.Text = "" Or txtContact.Text = "" Or txtOccupation.Text = "" Or txtRecMem.Text = "" Or txtRecMemHJ.Text = "" Or txtGender.Text = "" Or txtIncome.Text = "" Or txtExp.Text = "" Or txtDependants.Text = "" Or txtMedical.Text = "" Or txtJama.Text = "" Or txtNiyyat.Text = "" Or txtAddress.Text = "" Or txtRemarks.Text = "" Or txtSanction.Text = "" Then
            ModalPopupExtender1.Show()
        End If
    End Sub
    Private Sub btnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim sw As StringWriter = New StringWriter
        Dim hw As HtmlTextWriter = New HtmlTextWriter(sw)
        GridView2.AllowPaging = False
        Call TotalRecords()
        GridView2.RenderControl(hw)
        Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
        Response.Write(style)
        Response.Output.Write(sw.ToString)
        Response.Flush()
        Response.End()
    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)


    End Sub
End Class