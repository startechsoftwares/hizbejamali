Public Class MemberInfo
    Dim mController As MemberController
    Shared sMemberController As MemberController = New MemberController
    Sub New()
        mController = New MemberController
    End Sub
    Private _accountNo As String
    Private _memberName As String
    Private _groupLeader As String
    Private _mobileNumber As String
    Private _country As String
    Private _email As String
    Private _eJamaatID As String
    Private _image As String
    Private _password As String
    Private _status As String
    Private _addedDate As DateTime
    Private _memberType As String
    Private _memberFullName As String
    Private _karbalaZiyarat As Boolean
    Private _moharramaat As Boolean
    Private _gender As String
    Private _deeni_sheaar As Boolean
    Private _coreMember As String
    Private _approved As Boolean
    Private _rejectReason As String
    Private _uaType As String
    Private _accountType As String

    Public Property AccountType As String
        Get
            Return _accountType
        End Get
        Set(value As String)
            _accountType = value
        End Set
    End Property

    Public Property UserAccountType As String
        Get
            Return _uaType
        End Get
        Set(value As String)
            _uaType = value
        End Set
    End Property
    Public Shared Function IsRejected(itsID As String) As Boolean
        Return MemberController.IsRejected(itsID)
    End Function

    Public Shared Function ConvertRejectedTextToString(itsID As String) As String
        If IsRejected(itsID) Then
            Return "Rejected"
        Else
            Return ""
        End If
    End Function

    Public Property RejectReason As String
        Get
            Return _rejectReason
        End Get
        Set(value As String)
            _rejectReason = value
        End Set
    End Property

    Public Property Approved As Boolean
        Get
            Return _approved
        End Get
        Set(value As Boolean)
            _approved = value
        End Set
    End Property

    Public Property CoreMember As String
        Get
            Return _coreMember
        End Get
        Set(value As String)
            _coreMember = value
        End Set
    End Property

    Public Property Gender As String
        Get
            Return _gender
        End Get
        Set(value As String)
            _gender = value
        End Set
    End Property

    Public Property KarbalaZiyarat As Boolean
        Get
            Return _karbalaZiyarat
        End Get
        Set(value As Boolean)
            _karbalaZiyarat = value
        End Set
    End Property

    Public Property DeeniSheaar As Boolean
        Get
            Return _deeni_sheaar
        End Get
        Set(value As Boolean)
            _deeni_sheaar = value
        End Set
    End Property

    Public Property Moharramaat As Boolean
        Get
            Return _moharramaat
        End Get
        Set(value As Boolean)
            _moharramaat = value
        End Set
    End Property

    Public Property MemberFullName As String
        Get
            Return _memberFullName
        End Get
        Set(value As String)
            _memberFullName = value
        End Set
    End Property
    Public Property MemberType As String
        Get
            Return _memberType
        End Get
        Set(value As String)
            _memberType = value
        End Set
    End Property
    Public Property AccountNo As String
        Get
            Return _accountNo
        End Get
        Set(value As String)
            _accountNo = value
        End Set
    End Property

    Public Property MemberName As String
        Get
            Return _memberName
        End Get
        Set(value As String)
            _memberName = value
        End Set
    End Property

    Public Property GroupLeader As String
        Get
            Return _groupLeader
        End Get
        Set(value As String)
            _groupLeader = value
        End Set
    End Property

    Public Property MobileNumber As String
        Get
            Return _mobileNumber
        End Get
        Set(value As String)
            _mobileNumber = value
        End Set
    End Property

    Public Property Country As String
        Get
            Return _country
        End Get
        Set(value As String)
            _country = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property EjamaatID As String
        Get
            Return _eJamaatID
        End Get
        Set(value As String)
            _eJamaatID = value
        End Set
    End Property

    Public Property Image As String
        Get
            Return _image
        End Get
        Set(value As String)
            _image = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    Public Property AddedDate As DateTime
        Get
            Return _addedDate
        End Get
        Set(value As DateTime)
            _addedDate = value
        End Set
    End Property

    Public Function GetAllMembers(userType As UserType) As List(Of MemberInfo)
        Dim members As List(Of MemberInfo) = mController.GetAllMembers()
        If userType = Hizbe_Jamali_Web.UserType.Active Or userType = Hizbe_Jamali_Web.UserType.Inactive Then
            Return members.FindAll(Function(item) item.Status = userType.ToString)
        Else
            Return members
        End If
    End Function

    Public Shared Function GetMember(ByVal eJamaatID As String) As MemberInfo
        Return sMemberController.GetAllMembers().Find(Function(item) item.EjamaatID = eJamaatID)
    End Function

    Public Shared Function GetMemberByFullName(memberFullName As String) As MemberInfo
        Return MemberController.GetMemberByFullName(memberFullName)
    End Function

    Public Shared Function LeaderType(eJamaatID As String) As AccountType
        Return MemberController.LeadersType(eJamaatID)
    End Function

    Public Sub Add()
        mController.Add(Me)
    End Sub

    Public Sub Update(oldITS As String)
        mController.Update(Me, oldITS)
    End Sub

    Public Sub ApproveMember()
        mController.ApproveMember(EjamaatID)
    End Sub

    Public Sub ChangePassword(oldPassword As String, password As String, userName As String)
        mController.ChangePassword(password, userName)
    End Sub

    Public Function IsFirstLogin() As Boolean
        Return mController.IsFirstLogin(EjamaatID)
    End Function

    Public Sub UpdateFirstLogin()
        mController.UpdateFirstLogin(EjamaatID)
    End Sub

    Public Function GetAllGroupMembers(leaderITS As String) As List(Of MemberInfo)
        Return mController.GetAllGroupMembers(leaderITS)
    End Function

    Public Function GetAllLeaders() As List(Of MemberInfo)
        Return mController.GetAllLeaders()
    End Function

    Public Shared Function GetGroupLeader(name As String) As MemberInfo
        Return MemberController.GetGroupLeader(name)
    End Function

    Public Shared Sub Reject(itsID As String, rejectReason As String)
        MemberController.Reject(itsID, rejectReason)
    End Sub

    Public Function GetUserAccountTypes(ejamaatID As String) As String()
        Return mController.GetUserAccountTypes(ejamaatID)
    End Function
End Class

Public Class MemberJournal
    Dim contri As Integer
    Dim controller As MemberJournalController
    Private _jvno As String
    Private _addeddate As DateTime
    Private _accountname As String
    Private _narration As String
    Private _leadername As String
    Private _fcy As String
    Private _eJamaatID As String
    Private _amount As Integer
    Private _totalAmount As Integer

    Public Property JVNo As String
        Get
            Return _jvno
        End Get
        Set(value As String)
            _jvno = value
        End Set
    End Property

    Public Property AddedDate As DateTime
        Get
            Return _addeddate
        End Get
        Set(value As DateTime)
            _addeddate = value
        End Set
    End Property

    Public Property Membername As String
        Get
            Return _accountname
        End Get
        Set(value As String)
            _accountname = value
        End Set
    End Property

    Public Property Narration As String
        Get
            Return _narration
        End Get
        Set(value As String)
            _narration = value
        End Set
    End Property

    Public Property Leadername As String
        Get
            Return _leadername
        End Get
        Set(value As String)
            _leadername = value
        End Set
    End Property

    Public Property CurrencyName As String
        Get
            Return _fcy
        End Get
        Set(value As String)
            _fcy = value
        End Set
    End Property

    Public Property eJamaatID As String
        Get
            Return _eJamaatID
        End Get
        Set(value As String)
            _eJamaatID = value
        End Set
    End Property

    Public Property Amount As Integer
        Get
            Return _amount
        End Get
        Set(value As Integer)
            _amount = value
        End Set
    End Property

    Public Property TotalAmount As Integer
        Get
            Return _totalAmount
        End Get
        Set(value As Integer)
            _totalAmount = value
        End Set
    End Property

    Sub New()
        controller = New MemberJournalController
    End Sub

    Public Shared Function GetTotalContribution(userName As String) As Integer
        Return MemberJournalController.GetTotalContribution(userName)
    End Function

    Public Function SearchRangeByGroupLeader(glName As String, fromDate As String, toDate As String) As List(Of MemberJournal)
        Return controller.SearchRangeByGroupLeader(glName, fromDate, toDate)
    End Function
End Class

Public Class FostershipInfo
    Dim controller As FostershipController
    Shared sController As FostershipController = New FostershipController()
    Sub New()
        controller = New FostershipController
    End Sub

    Private _itsID As String
    Private _FullName As String
    Private _ContactNumber As String
    Private _Country As String
    Private _Address As String
    Private _EmailAddress As String
    Private _Photo As String
    Private _TotalFosterAmount As Integer
    Private _TotalRecurringAmount As Integer
    Private _AddedDate As DateTime
    Private FosterGroupID As Integer
    Private FosterAmount As Integer
    
    Public Property ITSID As String
        Get
            Return _itsID
        End Get
        Set(value As String)
            _itsID = value
        End Set
    End Property

    Public Property FullName As String
        Get
            Return _FullName
        End Get
        Set(value As String)
            _FullName = value
        End Set
    End Property
    Public Property ContactNumber As String
        Get
            Return _ContactNumber
        End Get
        Set(value As String)
            _ContactNumber = value
        End Set
    End Property

    Public Property Country As String
        Get
            Return _Country
        End Get
        Set(value As String)
            _Country = value
        End Set
    End Property

    Public Property Address As String
        Get
            Return _Address
        End Get
        Set(value As String)
            _Address = value
        End Set
    End Property

    Public Property EmailAddress As String
        Get
            Return _EmailAddress
        End Get
        Set(value As String)
            _EmailAddress = value
        End Set
    End Property

    Public Property Photo As String
        Get
            Return _Photo
        End Get
        Set(value As String)
            _Photo = value
        End Set
    End Property
    
    Public Property TotalFosterAmount As Integer
        Get
            Return _TotalFosterAmount
        End Get
        Set(value As Integer)
            _TotalFosterAmount = value
        End Set
    End Property

    Public Property TotalRecurringAmount As Integer
        Get
            Return _TotalRecurringAmount
        End Get
        Set(value As Integer)
            _TotalRecurringAmount = value
        End Set
    End Property

    Public Property AddedDate As DateTime
        Get
            Return _AddedDate
        End Get
        Set(value As DateTime)
            _AddedDate = value
        End Set
    End Property

    Public Function GetAllFosteredMumineens() As List(Of FostershipInfo)
        Return controller.GetAllFosteredMumineens()
    End Function

    Public Function GetAllFosterGroups() As DataTable
        Return controller.GetAllFosterGroups()
    End Function

    Public Function GetAllFosterItems() As DataTable
        Return controller.GetAllFosterItems()
    End Function

    Public Function GetAllUserFosterItems(itsID As String) As DataTable
        Return controller.GetUserFosterItems(itsID)
    End Function

    Public Function GetAllUserFosterGroups(itsID As String) As DataTable
        Return controller.GetUserFosterAmountByGroup(itsID)
    End Function

    Public Shared Function GetTotalAmountSpentOnFostership() As Integer
        Return FostershipController.GetTotalAmountSpentOnFostership()
    End Function

End Class

Public Class FostershipItemBreakupInfo
    Dim controller As FostershipItemBreakupController
    Shared sController As New FostershipItemBreakupController
    Sub New()
        controller = New FostershipItemBreakupController
    End Sub

    Private ITSID As String
    Private FosterItem As String
    Private FosterStatus As String
    Private FosterAmount As Integer
    Private Remark As String

End Class
