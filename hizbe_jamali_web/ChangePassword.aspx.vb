Public Class ChangePassword
    Inherits System.Web.UI.Page
    Dim member_user As MemberInfo
    Dim accountType As AccountType
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Globals.RedirectUserIfLoggedOut()
            member_user = MemberInfo.GetMember(Globals.GetSessionEJamaatID)
            lblLogged.Text = member_user.MemberName
            'Response.Write("UserAccountType: " + (Globals.UserAccountType = UserAccountType.Foster).ToString)
            If Not member_user Is Nothing Then
                accountType = Globals.LoggedInUserType
                Select Case accountType
                    Case Hizbe_Jamali_Web.AccountType.Administrator
                        rowLoggedAs.Visible = True
                        rowGroupLeader.Visible = True
                        lblLeader.Text = member_user.GroupLeader
                        plcAdmin.Visible = True
                    Case Hizbe_Jamali_Web.AccountType.GroupLeader
                        plcGroupLeader.Visible = True
                        rowGroupLeader.Visible = True
                        lblLeader.Text = member_user.MemberName
                    Case Hizbe_Jamali_Web.AccountType.Member
                        plcMember.Visible = True
                        rowLoggedAs.Visible = True
                        rowAccountBalance.Visible = True
                        lblLogged.Text = member_user.MemberFullName
                        lblAccountBal.Text = MemberJournal.GetTotalContribution(member_user.MemberFullName)
                End Select
                If member_user.IsFirstLogin() Then
                    txtCurrentPassword.Attributes.Add("placeholder", "Your ITS ID is your current password")
                    plcAdmin.Visible = False
                    plcGroupLeader.Visible = False
                    plcMember.Visible = False
                Else
                    litMenuLink.Text = Globals.SetLink
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try
    End Sub

    Protected Sub btnChangePassword_Click(sender As Object, e As EventArgs)
        Try
            If Page.IsValid Then
                Dim member As MemberInfo = MemberInfo.GetMember(Globals.GetSessionEJamaatID)

                member.ChangePassword(txtCurrentPassword.Text, txtNewPassword.Text, Globals.GetSessionEJamaatID)
                If member.IsFirstLogin() Then
                    member.UpdateFirstLogin()
                End If
                lblMessage.CssClass = "success"
                Dim params As New List(Of MailParameters)
                params.Add(New MailParameters() With {.ParameterName = "##name##", .ParameterValue = member.MemberName})
                params.Add(New MailParameters() With {.ParameterName = "##ejamaatid##", .ParameterValue = member.EjamaatID})
                params.Add(New MailParameters() With {.ParameterName = "##password##", .ParameterValue = txtNewPassword.Text})
                Globals.SendMail(MailType.PasswordChange, member.Email, params)
                lblMessage.Text = "Password has been changed successfully"
                lblMessage.Visible = True
            End If
        Catch ex As Exception
            lblMessage.CssClass = "error"
            lblMessage.Text = ex.ToString
            lblMessage.Visible = True
        End Try
    End Sub

    Protected Sub cvCurrentPassword_ServerValidate(source As Object, args As ServerValidateEventArgs)
        Dim member As MemberInfo = MemberInfo.GetMember(Globals.GetSessionEJamaatID)
        Dim _returnValue As Boolean = False
        If Not member Is Nothing Then
            If member.Password = txtCurrentPassword.Text Then
                _returnValue = True
            End If
        End If
        args.IsValid = _returnValue
    End Sub

    Protected Sub btnSkipChangePassword_Click(sender As Object, e As EventArgs)
        Select Case accountType
            Case Hizbe_Jamali_Web.AccountType.Administrator
                Response.Redirect("homeadmin.aspx?TD=" + member_user.EjamaatID)
            Case Hizbe_Jamali_Web.AccountType.GroupLeader
                Response.Redirect("homeadmin1.aspx?TD=" + member_user.EjamaatID)
            Case Hizbe_Jamali_Web.AccountType.Member
                Response.Redirect("homemember.aspx?TD=" + member_user.EjamaatID)
        End Select
    End Sub

End Class