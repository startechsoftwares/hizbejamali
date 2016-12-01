Public Class ChangePassword1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
    End Sub

    Protected Sub cvCurrentPassword_ServerValidate(source As Object, args As ServerValidateEventArgs)
        Dim member As MemberInfo = MemberInfo.GetMember(Request.QueryString("TD"))
        Dim _returnValue As Boolean = False
        If Not member Is Nothing Then
            If member.Password = txtCurrentPassword.Text Then
                _returnValue = True
            End If
        End If
        args.IsValid = _returnValue
    End Sub
End Class