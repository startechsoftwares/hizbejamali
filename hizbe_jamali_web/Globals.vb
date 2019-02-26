Imports System.Net
Imports System.Collections
Imports System.Data.OleDb
Imports System.Net.Mail
Imports System.Runtime.CompilerServices
Imports System.IO

Public Class Globals
    Private Shared con As New OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("\App_Data\HizbeJamali.mdb"))
    Public Shared ReadOnly Property DatabaseConnection As OleDbConnection
        Get
            Return con
        End Get
    End Property
    Public Shared Function SetLink() As String
        If Globals.UserAccountType = UserAccountType.Foster Then
            Return "<li><a class='menulink' href='foster.aspx'>Fostership Info</a></li>"
        Else
            Return "<li><a class='menulink' href='zaereen.aspx'>Zaereen Info</a></li>"
        End If
    End Function
    Public Shared Sub FillCountries(drop As DropDownList)
        drop.Items.Clear()
        drop.Items.Add("India")
        drop.Items.Add("UAE")
        drop.Items.Add("Kuwait")
        drop.Items.Add("Saudi Arabia")
        drop.Items.Add("Qatar")
        drop.Items.Add("United States")
        drop.Items.Add("United Kingdom")
        drop.Items.Add("Dares Salaam")
    End Sub

    Public Shared Function GetLocalTime() As DateTime
        Dim ist = New DateTime()
        Dim zoneId As String = "India Standard Time"
        Dim tzi As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(zoneId)
        ist = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi)
        Return ist
    End Function

    Public Shared ReadOnly Property GetSessionEJamaatID As String
        Get
            Dim _eJamaatID As String = String.Empty
            If (Not HttpContext.Current.Session("TID") Is Nothing) Then
                _eJamaatID = HttpContext.Current.Session("TID")
            End If
            Return _eJamaatID
        End Get
    End Property
    Public Shared Property LoggedInUserType As AccountType
        Get
            If Not HttpContext.Current.Session("loggedInUserType") Is Nothing Then
                Return DirectCast([Enum].Parse(GetType(AccountType), HttpContext.Current.Session("loggedInUserType").ToString()), AccountType)
            Else
                Return AccountType.Member
            End If
        End Get
        Set(value As AccountType)
            HttpContext.Current.Session("loggedInUserType") = value
        End Set
    End Property

    Public Shared Property UserAccountType As UserAccountType
        Get
            If Not HttpContext.Current.Session("UserAccountType") Is Nothing Then
                Return DirectCast([Enum].Parse(GetType(UserAccountType), HttpContext.Current.Session("UserAccountType").ToString()), UserAccountType)
            Else
                Return UserAccountType.KUN
            End If
        End Get
        Set(value As UserAccountType)
            HttpContext.Current.Session("UserAccountType") = value
        End Set
    End Property

    Public Shared Sub SetTimeoutMessage(label As System.Web.UI.WebControls.Label)
        If Not HttpContext.Current.Session("timeout-message") Is Nothing Then
            label.Text = HttpContext.Current.Session("timeout-message")
            label.Visible = True
            HttpContext.Current.Session("timeout-message") = Nothing
        End If
    End Sub

    Public Shared Sub RedirectUserIfLoggedOut()
        Dim _return As String = String.Empty
        If (HttpContext.Current.Session("TID") Is Nothing) Then
            HttpContext.Current.Session("timeout-message") = "Your session was timed-out, Please login again."
            HttpContext.Current.Response.Redirect("login.aspx")
        End If
    End Sub

    Private Shared ReadOnly Property EmailTemplatePath As String
        Get
            Return HttpContext.Current.Server.MapPath("emailtemplates/")
        End Get
    End Property

    Public Shared Function GetBodyContent(mailType As MailType) As String
        Dim domain As String = HttpContext.Current.Request.ServerVariables("SERVER_NAME")
        Dim path As String = EmailTemplatePath + "/" + mailType.ToString() + ".txt"
        Dim bodyContent As String = String.Empty
        With New StreamReader(path)
            bodyContent = .ReadToEnd
            .Close()
        End With
        Return bodyContent.Replace("##domain##", domain)
    End Function

    Public Shared Function GetSubject(mailType As MailType) As String
        Dim subjectContent As String = String.Empty
        Select Case mailType
            Case Hizbe_Jamali_Web.MailType.ForgotPassword
                subjectContent = "Password Reminder Hizb-e-Jamali"
            Case Hizbe_Jamali_Web.MailType.NewRegistration
                subjectContent = "New member registration awaiting Approval"
            Case Hizbe_Jamali_Web.MailType.RegistrationApprovalToMember
                subjectContent = "Welcome to Hizb-e-Jamali"
            Case Hizbe_Jamali_Web.MailType.RegistrationApprovalToGroupLeader
                subjectContent = "New Member joined in your group - Hizb-e-Jamali"
            Case Hizbe_Jamali_Web.MailType.PasswordChange
                subjectContent = "Password change request"
            Case Hizbe_Jamali_Web.MailType.PaymentReceipt
                subjectContent = "Payment receipt for Hizb-e-Jamali Contribution"
            Case Hizbe_Jamali_Web.MailType.ErrorOccured
                subjectContent = "Error occured on Hizb-e-Jamali website"
            Case Hizbe_Jamali_Web.MailType.RejectMemberToCoreMember
                subjectContent = "Member rejection completed successfully"
            Case Hizbe_Jamali_Web.MailType.RejectMemberToGroupLeader
                subjectContent = "Member registration has been Rejected"
        End Select
        Return subjectContent
    End Function

    Public Shared Sub SendMail(ByVal mailType As MailType, email As String, ByVal mailParameters As List(Of MailParameters), ejamaatID As String)
        Dim bodyContent As String = GetBodyContent(mailType)
        Dim member As New MemberController
        For Each param As MailParameters In mailParameters
            If bodyContent.ToLower().Contains(param.ParameterName.ToLower) Then
                bodyContent = bodyContent.Replace(param.ParameterName.ToLower, param.ParameterValue)
            End If
        Next
        Dim mail As MailMessage = New MailMessage("helpdesk@smartshab.com", email)
        mail.From = New MailAddress("helpdesk@smartshab.com", "Team Hizb-e-Jamali")
        If member.hasSelfReceipt(ejamaatID) Then
            Dim currentUserEmail As String = member.GetAllMembers().Where(Function(s) s.EjamaatID = ejamaatID).FirstOrDefault().Email
            If currentUserEmail <> String.Empty Then
                mail.CC.Add(currentUserEmail)
            End If
        End If
        mail.Body = bodyContent
        mail.IsBodyHtml = True
        mail.Priority = MailPriority.High
        mail.Subject = GetSubject(mailType)
        Dim smtp As New SmtpClient With {
            .Host = "mail.smartshab.com",
            .Port = 25,
            .Credentials = New System.Net.NetworkCredential("helpdesk@smartshab.com", "Maula@52.53$")
        }
        smtp.Send(mail)
    End Sub

    Public Shared Sub SendMail(ByVal mailType As MailType, email As String, ByVal mailParameters As List(Of MailParameters))
        Dim bodyContent As String = GetBodyContent(mailType)
        For Each param As MailParameters In mailParameters
            If bodyContent.ToLower().Contains(param.ParameterName.ToLower) Then
                bodyContent = bodyContent.Replace(param.ParameterName.ToLower, param.ParameterValue)
            End If
        Next
        Dim mail As MailMessage = New MailMessage("helpdesk@smartshab.com", email)
        mail.From = New MailAddress("helpdesk@smartshab.com", "Team Hizb-e-Jamali")
        mail.Body = bodyContent
        mail.IsBodyHtml = True
        mail.Priority = MailPriority.High
        mail.Subject = GetSubject(mailType)
        Dim smtp As New SmtpClient With {
            .Host = "mail.smartshab.com",
            .Port = 25,
            .Credentials = New System.Net.NetworkCredential("helpdesk@smartshab.com", "Maula@52.53$")   
        }
        smtp.Send(mail)
    End Sub

End Class

Public Class MailParameters
    Public _parameterName As String
    Public _parameterValue As String
    Public Property ParameterName As String
        Get
            Return _parameterName
        End Get
        Set(value As String)
            _parameterName = value
        End Set
    End Property

    Public Property ParameterValue As String
        Get
            Return _parameterValue
        End Get
        Set(value As String)
            _parameterValue = value
        End Set
    End Property

    'Public Shared Function PageAuthorization(type As AccountType, errorPlaceHolder As PlaceHolder, mainContentPlaceHolder As PlaceHolder, dashBoardLink As HyperLink)
    '    Dim account As AccountType = MemberInfo.LeaderType(Globals.GetSessionEJamaatID)
    '    If account = AccountType.Member Then
    '        Select Case account
    '            Case AccountType.Member
    '                errorPlaceHolder.Visible = True
    '                dashBoardLink.NavigateUrl = "~/homemember.aspx?TD=" + Globals.GetSessionEJamaatID
    '            Case AccountType.Administrator
    '                errorPlaceHolder.Visible = True
    '                dashBoardLink.NavigateUrl = "~/homeadmin.aspx?TD=" + Globals.GetSessionEJamaatID
    '            Case AccountType.GroupLeader
    '                plcMainContent.Visible = True
    '        End Select
    'End Function
End Class
Public Module Extensions
    <Extension()>
    Function Nulls(Of T)(ByVal stringValue As Object) As T
        Dim obj As Object
        Dim t_ReturnValue As Type = GetType(T)
        If (String.IsNullOrEmpty(stringValue)) Then
            If (t_ReturnValue Is GetType(String)) Then
                obj = String.Empty
                Return CType(obj, T)
            ElseIf t_ReturnValue Is GetType(Integer) Then
                obj = -1
                Return CType(obj, T)
            End If
        End If
    End Function

    <Extension()>
    Function Resolve(stringValue As Object) As String
        Return TryCast(HttpContext.Current.Handler, Page).ResolveUrl("~/" + stringValue)
    End Function
End Module