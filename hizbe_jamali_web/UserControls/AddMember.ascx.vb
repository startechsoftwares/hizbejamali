Imports Hizbe_Jamali_Web
Imports System.IO

Public Class AddMember
    Inherits System.Web.UI.UserControl
    Dim accountType As AccountType = MemberInfo.LeaderType(Globals.GetSessionEJamaatID)
    Public Shared _itsID As String = String.Empty
    Shared _isNewMemberClicked As Boolean
    Private Shared _ejamaatID As String
    Public Event MemberAddClick As EventHandler
    Public Shared Property EjamaatID As String
        Get
            Return _ejamaatID
        End Get
        Set(value As String)
            _ejamaatID = value
        End Set
    End Property
    Public Shared Property IsNewMemberClicked As Boolean
        Get
            Return _isNewMemberClicked
        End Get
        Set(value As Boolean)
            _isNewMemberClicked = value
        End Set
    End Property
    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If EjamaatID <> String.Empty Then
            Globals.RedirectUserIfLoggedOut()
            Dim members As New MemberInfo
            Dim leaders As List(Of MemberInfo) = members.GetAllLeaders()
            Globals.FillCountries(drpCountry)

            Select Case accountType
                Case Hizbe_Jamali_Web.AccountType.GroupLeader
                    drpCoreLeaders.DataSource = leaders.FindAll(Function(item) item.MemberType = "Full Access")
                    drpCoreLeaders.DataTextField = "MemberName"
                    drpCoreLeaders.DataValueField = "EjamaatID"
                    drpCoreLeaders.DataBind()
                    lblLeaderType.Text = "Core Member"
                Case Hizbe_Jamali_Web.AccountType.Administrator
                    drpCoreLeaders.DataSource = leaders
                    drpCoreLeaders.DataTextField = "MemberName"
                    drpCoreLeaders.DataValueField = "EjamaatID"
                    drpCoreLeaders.DataBind()
                    lblLeaderType.Text = "Group Leader"
            End Select
            
            Dim selectedITSUser As MemberInfo = MemberInfo.GetMember(EjamaatID)
            plcCoreMember.Visible = (selectedITSUser.Approved = False)
            txteJamaatID.Text = selectedITSUser.EjamaatID
            txtEmailId.Text = selectedITSUser.Email
            txtMemberName.Text = selectedITSUser.MemberFullName
            txtMobileNumber.Text = selectedITSUser.MobileNumber
            drpCountry.Text = selectedITSUser.Country
            rdDeeniSheear.Items.FindByValue(selectedITSUser.DeeniSheaar).Selected = True
            rdStatus.Items.FindByValue(selectedITSUser.Status).Selected = True
            rdStatus.Enabled = True
            If Not String.IsNullOrEmpty(selectedITSUser.Gender) Then
                rdGender.Items.FindByValue(selectedITSUser.Gender).Selected = True
            Else
                rdGender.SelectedIndex = 0
            End If

            rdKarbalaZiyaarat.Items.FindByValue(selectedITSUser.KarbalaZiyarat).Selected = True
            rdMoharramaat.Items.FindByValue(selectedITSUser.Moharramaat).Selected = True
            Select Case accountType
                Case Hizbe_Jamali_Web.AccountType.Administrator
                    drpCoreLeaders.Items.FindByText(selectedITSUser.GroupLeader).Selected = True
            End Select
            imgProfile.ImageUrl = selectedITSUser.Image
            If String.IsNullOrEmpty(selectedITSUser.Image) Then
                Dim filename As String = Directory.GetFiles(Server.MapPath("~/images/")).ToList().Find(Function(item) item.ToString().Contains(EjamaatID))
                If Not String.IsNullOrEmpty(filename) Then
                    imgProfile.ImageUrl = "/images/" + Path.GetFileName(filename)
                Else
                    imgProfile.ImageUrl = "/images/NoPhoto.jpg"
                End If
            End If
            Dim accountTypes As String() = members.GetUserAccountTypes(EjamaatID)
            chkBoxUserType.ClearSelection()
            For Each item As ListItem In chkBoxUserType.Items
                For Each type As String In accountTypes
                    If item.Value.ToUpper = type.ToUpper Then
                        item.Selected = True
                    End If
                Next
            Next

            btnAddMember.Text = "Update Member"
            _itsID = EjamaatID
            EjamaatID = String.Empty
        ElseIf IsNewMemberClicked Then
            plcCoreMember.Visible = False
            _itsID = String.Empty
            Dim leaders As List(Of MemberInfo) = New MemberInfo().GetAllLeaders
            Globals.FillCountries(drpCountry)
            rdDeeniSheear.SelectedIndex = 0
            rdGender.SelectedIndex = 0
            rdKarbalaZiyaarat.SelectedIndex = 1
            rdMoharramaat.SelectedIndex = 1
            
            txteJamaatID.Text = ""
            txtEmailId.Text = ""
            txtMemberName.Text = ""
            txtMobileNumber.Text = ""
            txtRejectReason.Text = ""
            imgProfile.ImageUrl = "/images/NoPhoto.jpg"
            btnAddMember.Text = "Add Member"
            Select Case accountType
                Case Hizbe_Jamali_Web.AccountType.GroupLeader
                    drpCoreLeaders.DataSource = leaders.FindAll(Function(item) item.MemberType = "Full Access")
                    drpCoreLeaders.DataTextField = "MemberName"
                    drpCoreLeaders.DataValueField = "EjamaatID"
                    drpCoreLeaders.DataBind()
                    lblLeaderType.Text = "Core Member"
                    rdStatus.SelectedIndex = 1
                    rdStatus.Enabled = False
                Case Hizbe_Jamali_Web.AccountType.Administrator
                    drpCoreLeaders.DataSource = leaders
                    drpCoreLeaders.DataTextField = "MemberName"
                    drpCoreLeaders.DataValueField = "EjamaatID"
                    drpCoreLeaders.DataBind()
                    lblLeaderType.Text = "Group Leader"
                    rdStatus.SelectedIndex = 0
                    rdStatus.Enabled = True
            End Select
            IsNewMemberClicked = False
        End If

    End Sub

    Protected Sub btnAddMember_Click(sender As Object, e As EventArgs) Handles btnAddMember.Click
        Dim info As New MemberInfo
        info.Country = drpCountry.SelectedItem.Text
        info.EjamaatID = txteJamaatID.Text
        info.Email = txtEmailId.Text

        If fuProfile.HasFile Then
            fuProfile.PostedFile.SaveAs(Server.MapPath("~/images/" + fuProfile.PostedFile.FileName))
            info.Image = "/images/" + fuProfile.PostedFile.FileName
        Else
            info.Image = imgProfile.ImageUrl
        End If
        info.MemberName = txtMemberName.Text
        info.MobileNumber = txtMobileNumber.Text
        info.KarbalaZiyarat = Convert.ToBoolean(rdKarbalaZiyaarat.SelectedValue)
        info.Moharramaat = Convert.ToBoolean(rdMoharramaat.SelectedValue)
        info.DeeniSheaar = Convert.ToBoolean(rdDeeniSheear.SelectedValue)
        info.Gender = rdGender.SelectedValue
        info.Status = rdStatus.SelectedValue
        Dim _groupLeader As MemberInfo = MemberInfo.GetMember(Globals.GetSessionEJamaatID)
        Dim selectedAccountTypes As String = String.Empty
        For Each item As ListItem In chkBoxUserType.Items
            If item.Selected Then
                selectedAccountTypes += item.Value + ","

            End If
        Next
        If _itsID = String.Empty Then
            Dim _password As String = String.Empty
            Dim _coreMember As String = String.Empty
            Dim _groupL As String = String.Empty
            Dim _coreMemberITSID As String = String.Empty
            'Dim _guid As Guid
            Select Case accountType
                Case Hizbe_Jamali_Web.AccountType.Administrator
                    info.GroupLeader = drpCoreLeaders.SelectedItem.Text
                    info.Status = "Active"
                    info.Approved = True
                    info.CoreMember = String.Empty
                    '_guid = Guid.NewGuid
                    '_password = _guid.ToString.Substring(0, _guid.ToString().IndexOf("-") - 1)
                    info.Password = txteJamaatID.Text
                    info.Add()
                    _coreMember = _groupLeader.MemberName
                    _groupL = drpCoreLeaders.SelectedItem.Text
                    _coreMemberITSID = Globals.GetSessionEJamaatID
                    'ApprovalNewMembershipMail()

                Case Hizbe_Jamali_Web.AccountType.GroupLeader
                    info.Status = "Inactive"
                    info.Approved = False
                    info.GroupLeader = _groupLeader.MemberName
                    info.CoreMember = drpCoreLeaders.SelectedItem.Text
                    '_guid = Guid.NewGuid
                    '_password = _guid.ToString.Substring(0, _guid.ToString().IndexOf("-") - 1)
                    info.Password = txteJamaatID.Text
                    info.Add()
                    _coreMember = drpCoreLeaders.SelectedItem.Text
                    _groupL = _groupLeader.MemberName
                    _coreMemberITSID = drpCoreLeaders.SelectedValue
            End Select

            Dim mailParams As New List(Of MailParameters)
            mailParams.Add(New MailParameters() With {.ParameterName = "##coremember##", .ParameterValue = _coreMember})
            mailParams.Add(New MailParameters() With {.ParameterName = "##groupleader##", .ParameterValue = _groupL})
            mailParams.Add(New MailParameters() With {.ParameterName = "##memberfullname##", .ParameterValue = txtMemberName.Text})
            mailParams.Add(New MailParameters() With {.ParameterName = "##contactnumber##", .ParameterValue = txtMobileNumber.Text})
            mailParams.Add(New MailParameters() With {.ParameterName = "##email##", .ParameterValue = txtEmailId.Text})
            mailParams.Add(New MailParameters() With {.ParameterName = "##country##", .ParameterValue = drpCountry.SelectedItem.Text})
            mailParams.Add(New MailParameters() With {.ParameterName = "##itsid##", .ParameterValue = txteJamaatID.Text})
            mailParams.Add(New MailParameters() With {.ParameterName = "##password##", .ParameterValue = txteJamaatID.Text})
            Globals.SendMail(MailType.NewRegistration, MemberInfo.GetMember(_coreMemberITSID).Email, mailParams)

        Else
            Select Case accountType
                Case Hizbe_Jamali_Web.AccountType.Administrator
                    info.GroupLeader = drpCoreLeaders.SelectedItem.Text
                Case Hizbe_Jamali_Web.AccountType.GroupLeader
                    info.GroupLeader = _groupLeader.MemberName
            End Select
            info.Update(txteJamaatID.Text)
            Dim btn As Button = CType(sender, Button)
            If btn.ID = "btnApproveMember" Then
                info.ApproveMember()
                ApprovalNewMembershipMail()
            End If
        End If
        MemberController.TagUserAccount(txteJamaatID.Text, selectedAccountTypes.Trim(","))
        If Request.RawUrl = "/mastermember.aspx" Then
            Dim _leader As String = DirectCast(Me.Page, mastermember).drpLeaders.SelectedItem.Text
            Dim _status As String = DirectCast(Me.Page, mastermember).cboxStatus1.SelectedValue
            Dim _userType As String = DirectCast(Me.Page, mastermember).drpUserType.SelectedValue
            DirectCast(Me.Page, mastermember).FillMembers(_leader, _status, _userType)
        ElseIf Request.RawUrl = "/mastermember1.aspx" Then
            DirectCast(Me.Page, mastermember1).DatagridUpdate()
        End If
        ModalPopupExtender1.Hide()
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs)
        ModalPopupExtender1.Hide()
    End Sub

    Protected Sub btnRejectNow_Click(sender As Object, e As EventArgs) Handles btnRejectNow.Click
        MemberInfo.Reject(txteJamaatID.Text, txtRejectReason.Text)
        'REJECTION MAIL COPY FOR CORE MEMBER
        Dim member As MemberInfo = MemberInfo.GetMember(Globals.GetSessionEJamaatID)
        Dim mailParams1 As New List(Of MailParameters)
        mailParams1.Add(New MailParameters() With {.ParameterName = "##name##", .ParameterValue = member.MemberName})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##itsid##", .ParameterValue = txteJamaatID.Text})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##fullname##", .ParameterValue = txtMemberName.Text})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##contactnumber##", .ParameterValue = txtMobileNumber.Text})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##email##", .ParameterValue = txtEmailId.Text})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##rejectreason##", .ParameterValue = txtRejectReason.Text})
        Globals.SendMail(MailType.RejectMemberToCoreMember, member.Email, mailParams1)

        'REJECTION MAIL COPY FOR GROUP LEADER
        Dim _groupLeader As MemberInfo = MemberInfo.GetMember(drpCoreLeaders.SelectedValue)
        Dim mailParams2 As New List(Of MailParameters)
        mailParams2.Add(New MailParameters() With {.ParameterName = "##name##", .ParameterValue = _groupLeader.MemberName})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##itsid##", .ParameterValue = txteJamaatID.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##fullname##", .ParameterValue = txtMemberName.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##contactnumber##", .ParameterValue = txtMobileNumber.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##email##", .ParameterValue = txtEmailId.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##rejectreason##", .ParameterValue = txtRejectReason.Text})
        Globals.SendMail(MailType.RejectMemberToGroupLeader, _groupLeader.Email, mailParams2)

        ModalPopupExtender1.Hide()
    End Sub

    Private Sub ApprovalNewMembershipMail()
        Dim member As MemberInfo = MemberInfo.GetMember(txteJamaatID.Text)
        Dim _groupleader As MemberInfo = MemberInfo.GetMember(drpCoreLeaders.SelectedValue)
        Dim _coreMember As MemberInfo = MemberInfo.GetMember(Globals.GetSessionEJamaatID)

        Dim mailParams As New List(Of MailParameters)
        mailParams.Add(New MailParameters() With {.ParameterName = "##name##", .ParameterValue = _groupleader.MemberName})
        mailParams.Add(New MailParameters() With {.ParameterName = "##memberfullname##", .ParameterValue = txtMemberName.Text})
        mailParams.Add(New MailParameters() With {.ParameterName = "##membercontactnumber##", .ParameterValue = txtMobileNumber.Text})
        mailParams.Add(New MailParameters() With {.ParameterName = "##memberemail##", .ParameterValue = txtEmailId.Text})
        mailParams.Add(New MailParameters() With {.ParameterName = "##membercountry##", .ParameterValue = drpCountry.SelectedItem.Text})
        mailParams.Add(New MailParameters() With {.ParameterName = "##itsid##", .ParameterValue = txteJamaatID.Text})
        mailParams.Add(New MailParameters() With {.ParameterName = "##password##", .ParameterValue = member.Password})
        Globals.SendMail(MailType.RegistrationApprovalToGroupLeader, _groupleader.Email, mailParams)

        Dim mailParams1 As New List(Of MailParameters)
        mailParams1.Add(New MailParameters() With {.ParameterName = "##name##", .ParameterValue = txtMemberName.Text})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##itsid##", .ParameterValue = txteJamaatID.Text})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##password##", .ParameterValue = member.Password})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##groupleaderfullname##", .ParameterValue = _groupleader.MemberFullName})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##groupleadercontactnumber##", .ParameterValue = _groupleader.MobileNumber})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##groupleaderemail##", .ParameterValue = _groupleader.Email})
        mailParams1.Add(New MailParameters() With {.ParameterName = "##groupleaderitsid##", .ParameterValue = drpCoreLeaders.SelectedValue})
        Globals.SendMail(MailType.RegistrationApprovalToMember, txtEmailId.Text, mailParams1)

        Dim mailParams2 As New List(Of MailParameters)
        mailParams2.Add(New MailParameters() With {.ParameterName = "##coremember##", .ParameterValue = _coreMember.MemberName})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##groupleader##", .ParameterValue = _groupleader.MemberName})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##memberfullname##", .ParameterValue = txtMemberName.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##contactnumber##", .ParameterValue = txtMobileNumber.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##email##", .ParameterValue = txtEmailId.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##country##", .ParameterValue = drpCountry.SelectedItem.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##itsid##", .ParameterValue = txteJamaatID.Text})
        mailParams2.Add(New MailParameters() With {.ParameterName = "##password##", .ParameterValue = txteJamaatID.Text})
        Globals.SendMail(MailType.NewRegistration, _coreMember.Email, mailParams2)
    End Sub
End Class