Public Class Forgot
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
                Dim mailParam1 As New MailParameters
                mailParam1.ParameterName = "##name##"
                mailParam1.ParameterValue = member.MemberName

                Dim mailParam2 As New MailParameters
                mailParam2.ParameterName = "##ejamaatid##"
                mailParam2.ParameterValue = member.EjamaatID

                Dim mailParam3 As New MailParameters
                mailParam3.ParameterName = "##password##"
                mailParam3.ParameterValue = member.Password

                mailParams.AddRange(New MailParameters() {mailParam1, mailParam2, mailParam3})
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