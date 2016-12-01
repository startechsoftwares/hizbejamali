Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        If Not Server.GetLastError().Message.ToLower().Contains("file does not exist") Then
            Dim params As New List(Of MailParameters)
            params.Add(New MailParameters() With {.ParameterName = "##errordate##", .ParameterValue = Globals.GetLocalTime})
            params.Add(New MailParameters() With {.ParameterName = "##shortmessage##", .ParameterValue = Server.GetLastError().Message})
            params.Add(New MailParameters() With {.ParameterName = "##longmessage##", .ParameterValue = Server.GetLastError().ToString})
            params.Add(New MailParameters() With {.ParameterName = "##domain##", .ParameterValue = HttpContext.Current.Request.ServerVariables("SERVER_NAME").ToString})
            If (Not Globals.GetSessionEJamaatID Is Nothing) Then
                params.Add(New MailParameters() With {.ParameterName = "##user##", .ParameterValue = MemberInfo.GetMember(Globals.GetSessionEJamaatID).MemberFullName})
            Else
                params.Add(New MailParameters() With {.ParameterName = "##user##", .ParameterValue = "No user found"})
            End If
            Globals.SendMail(MailType.ErrorOccured, "helpdesk@startechsoftwares.com", params)
        End If

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class