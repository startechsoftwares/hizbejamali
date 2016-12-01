Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Hizbe_Jamali_Web

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
<Script.Services.ScriptService> _
Public Class GlobalServices
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Function IsCurrentPasswordValid(eJamaatID As String, currentPassword As String) As Boolean
        Dim member As MemberInfo = MemberInfo.GetMember(eJamaatID)
        Dim _returnValue As Boolean = False
        If Not member Is Nothing Then
            If member.Password = currentPassword Then
                _returnValue = True
            End If
        End If
        Return _returnValue
    End Function

    <WebMethod()> _
    Public Function IsUserExists(ejamaatID As String) As Boolean
        Dim member As MemberInfo = MemberInfo.GetMember(ejamaatID)
        Return Not member Is Nothing
    End Function
End Class