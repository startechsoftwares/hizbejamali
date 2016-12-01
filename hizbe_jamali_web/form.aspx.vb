Partial Public Class form
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    'Dim da As New OleDb.OleDbDataAdapter
    'Dim ds As New DataSet
    'Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Dim info As New List(Of MemberInfo)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Globals.RedirectUserIfLoggedOut()
        con.Open()
        cm.Connection = con
        info = New MemberInfo().GetAllLeaders()
        If Not IsPostBack Then
            drpGroupLeaders.DataSource = info

            drpGroupLeaders.DataTextField = "MemberName"
            drpGroupLeaders.DataValueField = "MemberFullName"
            drpGroupLeaders.DataBind()

            drpCountry.Items.Add("India")
            drpCountry.Items.Add("UAE")
            drpCountry.Items.Add("Kuwait")
            drpCountry.Items.Add("Saudi Arabia")
            drpCountry.Items.Add("Qatar")
            drpCountry.Items.Add("United States")
            drpCountry.Items.Add("United Kingdom")
            drpCountry.Items.Add("Dares Salaam")
        End If
        'lblDuplicate.Visible = False
        con.Close()
    End Sub
    'Private Sub ClearAll()
    '    txtEjamaatAJ.Text = ""
    '    txtEmailAJ.Text = ""
    '    txtMemberNameAJ.Text = ""
    '    txtMobileAJ.Text = ""
    'End Sub
    'Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
    '    con.Open()
    '    da = New OleDb.OleDbDataAdapter("SELECT * FROM Partyledger WHERE Ejamaat='" & txtEjamaatAJ.Text & "'", con)
    '    ds = New DataSet
    '    If da.Fill(ds) Then
    '        If txtMemberNameAJ.Text = "" Or txtEjamaatAJ.Text = "" Or txtMobileAJ.Text = "" Or cboxGrpLeaderAJ.Text = "Please Select Group Leader" Or cboxCountryAJ.Text = "Please Select Country" Then
    '            If txtEjamaatAJ.Text = "" Then lblEjamaat.Text = "** Please enter valid ITS ID" Else lblEjamaat.Text = ""
    '            If txtMemberNameAJ.Text = "" Then lblMember.Text = "** Please enter your full name" Else lblMember.Text = ""
    '            If txtMobileAJ.Text = "" Then lblMobile.Text = "** Please enter mobile number" Else lblMobile.Text = ""
    '            If cboxGrpLeaderAJ.Text = "Please Select Group Leader" Then lblLeader.Text = "** Please select your Group Leader" Else lblLeader.Text = ""
    '            If cboxCountryAJ.Text = "Please Select Country" Then lblCountry.Text = "** Please select valid Country" Else lblCountry.Text = ""
    '        Else
    '            lblCountry.Text = ""
    '            lblEjamaat.Text = ""
    '            lblLeader.Text = ""
    '            lblMember.Text = ""
    '            lblMobile.Text = ""
    '            lblDuplicate.Visible = True
    '            lblDuplicate.Text = "Member already registered with Hizbe Jamali"
    '        End If
    '    Else
    '        If txtMemberNameAJ.Text = "" Or txtEjamaatAJ.Text = "" Or txtMobileAJ.Text = "" Or cboxGrpLeaderAJ.Text = "Please Select Group Leader" Or cboxCountryAJ.Text = "Please Select Country" Then
    '            If txtEjamaatAJ.Text = "" Then lblEjamaat.Text = "** Please enter valid ITS ID" Else lblEjamaat.Text = ""
    '            If txtMemberNameAJ.Text = "" Then lblMember.Text = "** Please enter your full name" Else lblMember.Text = ""
    '            If txtMobileAJ.Text = "" Then lblMobile.Text = "** Please enter mobile number" Else lblMobile.Text = ""
    '            If cboxGrpLeaderAJ.Text = "Please Select Group Leader" Then lblLeader.Text = "** Please select your Group Leader" Else lblLeader.Text = ""
    '            If cboxCountryAJ.Text = "Please Select Country" Then lblCountry.Text = "** Please select valid Country" Else lblCountry.Text = ""
    '        Else
    '            lblCountry.Text = ""
    '            lblEjamaat.Text = ""
    '            lblLeader.Text = ""
    '            lblMember.Text = ""
    '            lblMobile.Text = ""
    '            cm.CommandText = "INSERT INTO PartyLedger (Member_Name,Group_Leader,Mobile,Email,Country,Ejamaat,Status) VALUES ('" & txtMemberNameAJ.Text & "','" & cboxGrpLeaderAJ.Text & "', '" & txtMobileAJ.Text & "','" & txtEmailAJ.Text & "', '" & cboxCountryAJ.Text & "', '" & txtEjamaatAJ.Text & "', 'Active')"
    '            cm.ExecuteNonQuery()
    '            Call ClearAll()
    '        End If
    '    End If
    '    con.Close()

    'End Sub

    'Private Sub txtMemberNameAJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemberNameAJ.TextChanged
    '    'txtMemberNameAJ.Text = StrConv(txtMemberNameAJ.Text, VbStrConv.ProperCase)
    'End Sub

    Protected Sub btnAddMember_Click(sender As Object, e As EventArgs) Handles btnAddMember.Click
        'Try
        '    Dim info As New MemberInfo
        '    info.MemberName = txtMemberName.Text
        '    info.GroupLeader = drpGroupLeaders.SelectedItem.Text
        '    info.MobileNumber = txtMobileNumber.Text
        '    info.Email = txtEmailId.Text
        '    info.Country = drpCountry.SelectedItem.Text
        '    info.EjamaatID = txteJamaatID.Text
        '    fuProfile.PostedFile.SaveAs(Server.MapPath("~/images/" + fuProfile.PostedFile.FileName))
        '    info.Image = "/images/" + fuProfile.PostedFile.FileName
        '    info.Password = txteJamaatID.Text.Trim()
        '    info.Status = "Inactive"
        '    info.Add()

        '    Dim groupLeaderInfo = MemberInfo.GetMemberByFullName(drpGroupLeaders.SelectedValue)
        '    Dim mailParams As New List(Of MailParameters)
        '    mailParams.Add(New MailParameters() With {.ParameterName = "##name##", .ParameterValue = groupLeaderInfo.MemberFullName})
        '    mailParams.Add(New MailParameters() With {.ParameterName = "##new_member_name##", .ParameterValue = txtMemberName.Text})
        '    mailParams.Add(New MailParameters() With {.ParameterName = "##new_member_ejamaatid##", .ParameterValue = txteJamaatID.Text})
        '    mailParams.Add(New MailParameters() With {.ParameterName = "##new_member_password##", .ParameterValue = txteJamaatID.Text.Trim})
        '    mailParams.Add(New MailParameters() With {.ParameterName = "##new_member_mobile##", .ParameterValue = txtMobileNumber.Text})
        '    mailParams.Add(New MailParameters() With {.ParameterName = "##new_member_email##", .ParameterValue = txtEmailId.Text})
        '    Globals.SendMail(MailType.IndividualNewRegistration, groupLeaderInfo.Email, mailParams, txteJamaatID.Text)
        '    lblMessage.Text = "Registration successful, your respective group leader will scrutinize your membership details, and upon activation you will be able to login to the website"
        '    lblMessage.CssClass = "success"
        'Catch ex As Exception
        '    lblMessage.Text = ex.ToString
        '    lblMessage.CssClass = "error"
        'End Try

    End Sub
End Class