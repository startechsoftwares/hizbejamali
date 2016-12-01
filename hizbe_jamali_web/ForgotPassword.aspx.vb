Public Class ForgotPassword
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnForgotPassword_Click(sender As Object, e As EventArgs) Handles btnForgotPassword.Click
        lblMessage.Visible = True
        lblMessage.CssClass = "error"
        If txteJamaatID.Text <> String.Empty Then
            Dim member As MemberInfo = MemberInfo.GetMember(txteJamaatID.Text)
            If Not member Is Nothing Then
                lblMessage.CssClass = "success"
                Dim mailParams As New List(Of MailParameters)
                mailParams.Add(New MailParameters() With {.ParameterName = "##name##", .ParameterValue = member.MemberName})
                mailParams.Add(New MailParameters() With {.ParameterName = "##ejamaatid##", .ParameterValue = member.EjamaatID})
                mailParams.Add(New MailParameters() With {.ParameterName = "##password##", .ParameterValue = member.Password})
                Globals.SendMail(MailType.ForgotPassword, member.Email, mailParams)
                lblMessage.Text = "Your credentials has been sent to your registered email id"
            Else
                lblMessage.Text = "You are not registered member of Hizbe Jamali"
            End If
        Else
            lblMessage.Text = "Please enter ITS ID"
        End If

    End Sub
End Class