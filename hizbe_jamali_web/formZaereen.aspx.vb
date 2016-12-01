Public Partial Class formZaereen
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Globals.RedirectUserIfLoggedOut()
        con.Open()
        cm.Connection = con
        lblMissing.Visible = False
        lblLogged.Text = Session("TID")
        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0).ToString
        da = New OleDb.OleDbDataAdapter("SELECT Name FROM GroupLeader WHERE  OName='" & lblLogged.Text & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0)

        If IsPostBack = False Then
            cboxStatus.Items.Add("Pending")
            cboxStatus.Items.Add("Approved")
            cboxStatus.Items.Add("Rejected")

            cboxMemberAdmin.Items.Add("Please Select Core Team Member's Name")
            da = New OleDb.OleDbDataAdapter("SELECT Name FROM GroupLeader ORDER BY Name", con)
            dt = New DataTable
            da.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                cboxMemberAdmin.Items.Add(dt.Rows(i).ItemArray(0).ToString)
            Next


            cboxValidity.Items.Add("No")
            cboxValidity.Items.Add("Yes")

            cboxZiyarat.Items.Add("No")
            cboxZiyarat.Items.Add("Yes")

            cboxGender.Items.Add("Please Select Gender")
            cboxGender.Items.Add("Male")
            cboxGender.Items.Add("Female")

            cboxMember.Items.Add("Please Select Member's Name")
            da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE Group_Leader='" & lblLogged.Text & "' ORDER BY Member_Name", con)
            dt = New DataTable
            da.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                cboxMember.Items.Add(dt.Rows(i).ItemArray(0).ToString)
            Next
            Call Zaereen_load()
        End If
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
    Private Sub ClearAll()
        lblTNo.Text = ""
        txtContact.Text = ""
        txtEjamaat.Text = ""
        txtName.Text = ""
        txtName.Text = ""
        txtOccupation.Text = ""
        txtAge.Text = ""
        txtAddress.Text = ""
        txtContact.Text = ""
        txtDate.Text = ""
        txtDatePP.Text = ""
        txtDependants.Text = ""
        txtExp.Text = ""
        txtIncome.Text = ""
        txtJamaa.Text = ""
        txtMedical.Text = ""
        txtNiyyat.Text = ""
        txtRemarks.Text = ""
        txtZiyarat.Text = ""
        lblAddress.Text = ""
        lblAge.Text = ""
        lblContact.Text = ""
        lblDatePP.Text = ""
        lblDependants.Text = ""
        lblEjamaat.Text = ""
        lblExp.Text = ""
        lblIncome.Text = ""
        lblJamaa.Text = ""
        lblMedical.Text = ""
        lblMissing.Text = ""
        lblName.Text = ""
        lblNiyyat.Text = ""
        lblOccupation.Text = ""
        lblRecMem.Text = ""
        lblRemAdmin.Text = ""
        lblRemarks.Text = ""
        lblTNo.Text = ""
        lblZiyaratName.Text = ""


    End Sub
    Private Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Call ClearAll()
        da = New OleDb.OleDbDataAdapter("SELECT MAX(Account_No) FROM ZaereenVerify", con)
        ds = New DataSet
        If da.Fill(ds) Then
            lblTNo.Text = ds.Tables(0).Rows(0)(0) + 1
        Else
            lblTNo.Text = 1
        End If
        txtDate.Text = Date.Today
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        con.Open()
        If cboxStatus.Text = "Pending" Then
            If lblTNo.Text = "" Or txtName.Text = "" Or txtContact.Text = "" Or cboxMember.Text = "Please Select Member's Name" Or cboxMemberAdmin.Text = "Please Select Core Team Member's Name" Or cboxGender.Text = "Please Select Gender" Then
                If txtEjamaat.Text = "" Then lblEjamaat.Text = "** ITS ID" Else lblEjamaat.Text = ""
                If txtName.Text = "" Then lblName.Text = "** Zaereen Name" Else lblName.Text = ""
                If cboxGender.Text = "Please Select Gender" Then cboxGender.Focus()
                If txtContact.Text = "" Then lblContact.Text = "** Contact No" Else lblContact.Text = ""
                If cboxMember.Text = "Please Select Member's Name" Then cboxMember.Focus()
                If cboxMemberAdmin.Text = "Please Select Core Team Member's Name" Then cboxMemberAdmin.Focus()
            Else
                da = New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & lblTNo.Text & "", con)
                ds = New DataSet
                If da.Fill(ds) Then
                    cm.CommandText = "UPDATE ZaereenVerify SET DOJ='" & txtDate.Text & "',Ejamaat='" & txtEjamaat.Text & "',Zaereen_Name='" & txtName.Text & "',Gender='" & cboxGender.Text & "',Age='" & txtAge.Text & "',Mobile='" & txtContact.Text & "',Occupation='" & txtOccupation.Text & "',RecMem='" & cboxMember.Text & "',RecMemHJ='" & cboxMemberAdmin.Text & "',Dadi='" & If((chkbxDadi.Checked), "1", "0") & "',Topi='" & If((chkbxTopi.Checked), "1", "0") & "',Rida='" & If((chkbxRida.Checked), "1", "0") & "',Moharramat='" & If((chkbxMoharramat.Checked), "1", "0") & "',Income='" & txtIncome.Text & "',Expense='" & txtExp.Text & "',Dependants='" & txtDependants.Text & "',Medical='" & txtMedical.Text & "',Jamaa='" & txtJamaa.Text & "',Niyyat='" & txtNiyyat.Text & "',OverseasZiyarat='" & cboxZiyarat.Text & "',ZiyaratName='" & txtZiyarat.Text & "',Address='" & txtAddress.Text & "',PPVal='" & cboxValidity.Text & "',PPExp='" & txtDatePP.Text & "',Remarks='" & txtRemarks.Text & "',ZStatus='" & cboxStatus.Text & "', Mobile1='" & txtContact1.Text.ToString & "', Mobile2='" & txtContact2.Text.ToString & "'  WHERE Account_No=" & lblTNo.Text & ""
                    cm.ExecuteNonQuery()
                Else
                    cm.CommandText = "INSERT INTO ZaereenVerify (Account_No,DOJ,Ejamaat,Zaereen_Name,Gender,Age,Mobile,Occupation,RecMem,RecMemHJ,Dadi,Topi,Rida,Moharramat,Income,Expense,Dependants,Medical,Jamaa,Niyyat,OverseasZiyarat,ZiyaratName,Address,PPVal,PPExp,Remarks,ZStatus,Mobile1,Mobile2) VALUES (" & lblTNo.Text & ",'" & txtDate.Text & "','" & txtEjamaat.Text & "', '" & txtName.Text & "','" & cboxGender.Text & "','" & txtAge.Text & "', '" & txtContact.Text & "','" & txtOccupation.Text & "','" & cboxMember.Text & "','" & cboxMemberAdmin.Text & "','" & If((chkbxDadi.Checked), "1", "0") & "' ,'" & If((chkbxTopi.Checked), "1", "0") & "','" & If((chkbxRida.Checked), "1", "0") & "','" & If((chkbxMoharramat.Checked), "1", "0") & "','" & txtIncome.Text & "','" & txtExp.Text & "','" & txtDependants.Text & "','" & txtMedical.Text & "','" & txtJamaa.Text & "','" & txtNiyyat.Text & "','" & cboxZiyarat.Text & "','" & txtZiyarat.Text.ToString & "','" & txtAddress.Text & "','" & cboxValidity.Text & "','" & txtDatePP.Text.ToString & "','" & txtRemarks.Text & "','" & cboxStatus.Text & "', '" & txtContact1.Text & "', '" & txtContact1.Text & "')"
                    cm.ExecuteNonQuery()
                End If
                lblMissing.Visible = False
                Call ClearAll()
            End If
        End If

        If cboxStatus.Text = "Approved" Then
            If lblTNo.Text = "" Or txtName.Text = "" Or txtEjamaat.Text = "" Or txtAge.Text = "" Or txtContact.Text = "" Or txtOccupation.Text = "" Or cboxMember.Text = "Please Select Member's Name" Or cboxMemberAdmin.Text = "Please Select Core Team Member's Name" Or cboxGender.Text = "Please Select Gender" Or txtIncome.Text = "" Or txtExp.Text = "" Or txtDependants.Text = "" Or txtMedical.Text = "" Or txtJamaa.Text = "" Or txtNiyyat.Text = "" Or txtAddress.Text = "" Or txtRemarks.Text = "" Then
                If txtEjamaat.Text = "" Then lblEjamaat.Text = "** ITS ID" Else lblEjamaat.Text = ""
                If txtName.Text = "" Then lblName.Text = "** Zaereen Name" Else lblName.Text = ""
                If cboxGender.Text = "Please Select Gender" Then cboxGender.Focus()
                If txtAge.Text = "" Then lblAge.Text = "** Age" Else lblAge.Text = ""
                If txtContact.Text = "" Then lblContact.Text = "** Contact No" Else lblContact.Text = ""
                If txtOccupation.Text = "" Then lblOccupation.Text = "** Occupation" Else lblOccupation.Text = ""
                If cboxMember.Text = "Please Select Member's Name" Then cboxMember.Focus()
                If cboxMemberAdmin.Text = "Please Select Core Team Member's Name" Then cboxMemberAdmin.Focus()
                If txtIncome.Text = "" Then lblIncome.Text = "** Total Income" Else lblIncome.Text = ""
                If txtExp.Text = "" Then lblExp.Text = "** Total Expenses" Else lblExp.Text = ""
                If txtDependants.Text = "" Then lblDependants.Text = "** No Of Dependants" Else lblDependants.Text = ""
                If txtMedical.Text = "" Then lblMedical.Text = "** Medical Fitness" Else lblMedical.Text = ""
                If txtJamaa.Text = "" Then lblJamaa.Text = "** Jamaa Raqam" Else lblJamaa.Text = ""
                If txtNiyyat.Text = "" Then lblNiyyat.Text = "** Karbala Niyyat " Else lblNiyyat.Text = ""
                If txtAddress.Text = "" Then lblAddress.Text = "** Address" Else lblAddress.Text = ""
                If txtRemarks.Text = "" Then lblRemarks.Text = "** Remarks" Else lblRemarks.Text = ""
                If cboxZiyarat.Text = "Yes" Then
                    If txtZiyarat.Text = "" Then
                        lblZiyaratName.Text = "** Ziyarat Name"
                    Else
                        lblZiyaratName.Text = ""
                    End If
                End If
                If cboxValidity.Text = "Yes" Then
                    If txtDatePP.Text = "" Then
                        lblDatePP.Text = "** PP Expiry"
                    Else
                        lblDatePP.Text = ""
                    End If
                End If
            Else
                Dim da2 As New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE Account_No=" & lblTNo.Text & "", con)
                Dim ds2 As New DataSet
                If da2.Fill(ds2) Then
                    cm.CommandText = "UPDATE ZaereenVerify SET DOJ='" & txtDate.Text & "',Ejamaat='" & txtEjamaat.Text & "',Zaereen_Name='" & txtName.Text & "',Gender='" & cboxGender.Text & "',Age='" & txtAge.Text & "',Mobile='" & txtContact.Text & "',Occupation='" & txtOccupation.Text & "',RecMem='" & cboxMember.Text & "',RecMemHJ='" & cboxMemberAdmin.Text & "',Dadi='" & If((chkbxDadi.Checked), "1", "0") & "',Topi='" & If((chkbxTopi.Checked), "1", "0") & "',Rida='" & If((chkbxRida.Checked), "1", "0") & "',Moharramat='" & If((chkbxMoharramat.Checked), "1", "0") & "',Income='" & txtIncome.Text & "',Expense='" & txtExp.Text & "',Dependants='" & txtDependants.Text & "',Medical='" & txtMedical.Text & "',Jamaa='" & txtJamaa.Text & "',Niyyat='" & txtNiyyat.Text & "',OverseasZiyarat='" & cboxZiyarat.Text & "',ZiyaratName='" & txtZiyarat.Text & "',Address='" & txtAddress.Text & "',PPVal='" & cboxValidity.Text & "',PPExp='" & txtDatePP.Text & "',Remarks='" & txtRemarks.Text & "',ZStatus='" & cboxStatus.Text & "' WHERE Account_No=" & lblTNo.Text & ""
                    cm.ExecuteNonQuery()
                Else
                    cm.CommandText = "INSERT INTO ZaereenVerify (Account_No,DOJ,Ejamaat,Zaereen_Name,Gender,Age,Mobile,Occupation,RecMem,RecMemHJ,Dadi,Topi,Rida,Moharramat,Income,Expense,Dependants,Medical,Jamaa,Niyyat,OverseasZiyarat,ZiyaratName,Address,PPVal,PPExp,Remarks,ZStatus) VALUES (" & lblTNo.Text & ",'" & txtDate.Text & "','" & txtEjamaat.Text & "', '" & txtName.Text & "','" & cboxGender.Text & "','" & txtAge.Text & "', '" & txtContact.Text & "','" & txtOccupation.Text & "','" & cboxMember.Text & "','" & cboxMemberAdmin.Text & "','" & If((chkbxDadi.Checked), "1", "0") & "' ,'" & If((chkbxTopi.Checked), "1", "0") & "','" & If((chkbxRida.Checked), "1", "0") & "','" & If((chkbxMoharramat.Checked), "1", "0") & "','" & txtIncome.Text & "','" & txtExp.Text & "','" & txtDependants.Text & "','" & txtMedical.Text & "','" & txtJamaa.Text & "','" & txtNiyyat.Text & "','" & cboxZiyarat.Text & "','" & txtZiyarat.Text.ToString & "','" & txtAddress.Text & "','" & cboxValidity.Text & "','" & txtDatePP.Text.ToString & "','" & txtRemarks.Text & "','" & cboxStatus.Text & "')"
                    cm.ExecuteNonQuery()
                End If
                lblMissing.Visible = False
                Call ClearAll()
            End If
        End If

        con.Close()
    End Sub
    Public Sub Zaereen_load()
        If String.IsNullOrEmpty(DirectCast(Session("VNO"), String)) Then
        Else
            Dim da As New OleDb.OleDbDataAdapter("SELECT * FROM ZaereenVerify WHERE  Account_No=" & Session("VNO") & "", con)
            Dim ds As New DataSet
            If da.Fill(ds) Then
                txtDate.Text = Date.Today
                lblTNo.Text = ds.Tables(0).Rows(0)(0)
                txtDate.Text = ds.Tables(0).Rows(0)(1)
                txtEjamaat.Text = ds.Tables(0).Rows(0)(2).ToString
                txtName.Text = ds.Tables(0).Rows(0)(3)
                cboxGender.Text = ds.Tables(0).Rows(0)(4)
                txtAge.Text = ds.Tables(0).Rows(0)(5).ToString
                txtContact.Text = ds.Tables(0).Rows(0)(6).ToString
                txtOccupation.Text = ds.Tables(0).Rows(0)(7).ToString
                cboxMember.Text = ds.Tables(0).Rows(0)(8).ToString
                cboxMemberAdmin.Text = ds.Tables(0).Rows(0)(9).ToString
                txtIncome.Text = ds.Tables(0).Rows(0)(14).ToString
                txtExp.Text = ds.Tables(0).Rows(0)(15).ToString
                txtDependants.Text = ds.Tables(0).Rows(0)(16).ToString
                txtMedical.Text = ds.Tables(0).Rows(0)(17).ToString
                txtJamaa.Text = ds.Tables(0).Rows(0)(18).ToString
                txtNiyyat.Text = ds.Tables(0).Rows(0)(19).ToString
                cboxZiyarat.SelectedIndex = cboxZiyarat.Items.IndexOf(cboxZiyarat.Items.FindByValue(ds.Tables(0).Rows(0)(20).ToString))
                txtZiyarat.Text = ds.Tables(0).Rows(0)(21).ToString
                txtAddress.Text = ds.Tables(0).Rows(0)(22).ToString
                cboxValidity.SelectedIndex = cboxValidity.Items.IndexOf(cboxValidity.Items.FindByValue(ds.Tables(0).Rows(0)(20).ToString))
                txtDatePP.Text = ds.Tables(0).Rows(0)(24).ToString
                txtRemarks.Text = ds.Tables(0).Rows(0)(25).ToString
                cboxStatus.Text = ds.Tables(0).Rows(0)(26).ToString
                txtContact1.Text = ds.Tables(0).Rows(0)(28).ToString
                txtContact2.Text = ds.Tables(0).Rows(0)(29).ToString
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
            End If

        End If

    End Sub
End Class