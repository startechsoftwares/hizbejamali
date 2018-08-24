Imports System.Data
Imports System.Data.OleDb
Imports Hizbe_Jamali_Web

Public Class MemberController
    Public Function GetAllMembers() As List(Of MemberInfo)
        Dim _list As New List(Of MemberInfo)
        Dim query As String = "SELECT UAT.ACCOUNTTYPE, P.ACCOUNT_NO, P.MEMBER_NAME, G.Name AS ShortName, P.GROUP_LEADER, P.MOBILE, P.EMAIL, P.COUNTRY, P.EJAMAAT, P.IMAGE, P.MPW, P.STATUS, P.AddedDate, G.TYPE as MemberType, P.Gender, P.DeeniSheear, P.KarbalaZiyaarat, P.Moharramaat, P.CoreMember, P.Approved, P.RejectReason FROM ((PARTYLEDGER P LEFT OUTER JOIN GROUPLEADER G ON P.EJAMAAT = G.EJAMAAT) INNER JOIN UserAccountType UAT ON P.EJAMAAT = UAT.ITSID)"
        With New OleDbDataAdapter(query, Globals.DatabaseConnection)
            Dim dt As New DataTable
            .Fill(dt)
            For Each row As DataRow In dt.Rows
                Dim memberInfo As New MemberInfo
                memberInfo.EjamaatID = row("Ejamaat").ToString
                memberInfo.MemberFullName = row("Member_Name").ToString
                memberInfo.MemberName = row("ShortName").ToString
                memberInfo.Password = row("MPW").ToString
                memberInfo.Email = row("Email").ToString
                memberInfo.AccountNo = row("Account_No").ToString
                memberInfo.Country = row("Country").ToString
                memberInfo.GroupLeader = row("Group_Leader").ToString
                memberInfo.Image = row("Image").ToString
                memberInfo.MobileNumber = row("Mobile").ToString
                memberInfo.Status = row("Status").ToString
                memberInfo.MemberType = row("MemberType").ToString
                memberInfo.Gender = row("Gender").ToString
                memberInfo.KarbalaZiyarat = Convert.ToBoolean(row("KarbalaZiyaarat"))
                memberInfo.Moharramaat = Convert.ToBoolean(row("Moharramaat"))
                memberInfo.DeeniSheaar = Convert.ToBoolean(row("DeeniSheear"))
                memberInfo.CoreMember = row("CoreMember").ToString
                memberInfo.Approved = row("Approved").ToString
                memberInfo.RejectReason = row("RejectReason").ToString
                memberInfo.UserAccountType = row("AccountType").ToString

                If Not String.IsNullOrEmpty(row("AddedDate").ToString()) Then
                    memberInfo.AddedDate = row("AddedDate").ToString
                Else
                    memberInfo.AddedDate = DateTime.Now
                End If
                _list.Add(memberInfo)
            Next
        End With
        Return _list
    End Function

    Public Function GetUserAccountTypes(ejamaatID As String) As String()
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Dim dt As New DataTable
        Dim accountType As String = String.Empty
        With New OleDbDataAdapter("SELECT ACCOUNTTYPE FROM USERACCOUNTTYPE WHERE ITSID = @EjamaatID", connection.ConnectionString)
            .SelectCommand.CommandType = CommandType.Text
            .SelectCommand.Parameters.AddWithValue("@EjamaatID", ejamaatID)
            .Fill(dt)
            If dt.Rows.Count > 1 Then
                accountType = dt.Rows(0)(0).ToString() + "," + dt.Rows(1)(0).ToString
            ElseIf dt.Rows.Count > 0 Then
                accountType = dt.Rows(0)(0).ToString()
            End If
        End With
        Return accountType.Split(",")
    End Function

    Public Function IsFirstLogin(eJamaatID As String) As Boolean
        Dim query As String = "SELECT ISFIRSTLOGIN FROM PARTYLEDGER WHERE EJAMAAT = @ejamaatid"
        Dim _returnValue As Boolean = False
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Try
            connection.Open()
            With New OleDbCommand
                .Connection = connection
                .CommandText = query
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ejamaatid", eJamaatID)
                _returnValue = Convert.ToBoolean(.ExecuteScalar())
            End With
            connection.Close()
        Catch ex As Exception
        Finally
            connection.Close()
        End Try
        Return _returnValue
    End Function

    Public Sub ToggleSelfReceipt(eJamaatID As String)
        Dim query As String = "update groupleader set SelfReceipt = switch(selfreceipt = 1, 0, selfreceipt = 0, 1) where ejamaat = @ejamaatid"
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Try
            connection.Open()
            With New OleDbCommand
                .Connection = connection
                .CommandText = query
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ejamaatid", eJamaatID)
                .ExecuteNonQuery()
            End With
            connection.Close()
        Catch ex As Exception
        Finally
            connection.Close()
        End Try
    End Sub

    Public Function hasSelfReceipt(ejamaatID As String) As Boolean
        Dim query As String = "select selfreceipt from groupleader where ejamaat = @ejamaatid"
        Dim _returnValue As Boolean = False
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Try
            connection.Open()
            With New OleDbCommand
                .Connection = connection
                .CommandText = query
                .CommandType = CommandType.Text
                .Parameters.AddWithValue("@ejamaatid", ejamaatID)
                _returnValue = Convert.ToBoolean(.ExecuteScalar())
            End With
            connection.Close()
        Catch ex As Exception
        Finally
            connection.Close()
        End Try
        Return _returnValue
    End Function

    Public Sub UpdateFirstLogin(eJamaatID As String)
        Dim query As String = "UPDATE PARTYLEDGER SET ISFIRSTLOGIN=0 WHERE EJAMAAT = @ejamaatid"
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Try
            connection.Open()
            With New OleDbCommand
                .Connection = connection
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@ejamaatid", eJamaatID)
                .ExecuteNonQuery()
            End With
            connection.Close()
        Catch ex As Exception
        Finally
            connection.Close()
        End Try

    End Sub

    Public Shared Sub Reject(itsID As String, rejectReason As String)
        Dim query As String = "UPDATE PARTYLEDGER SET REJECTREASON = @REJECTREASON WHERE EJAMAAT = @ITSID"
        Dim oledb As OleDbConnection = Globals.DatabaseConnection
        oledb.Open()
        With New OleDbCommand
            .Connection = oledb
            .CommandText = query
            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@RejectReason", rejectReason)
            .Parameters.AddWithValue("@ITSID", itsID)
            .ExecuteNonQuery()
            oledb.Close()
        End With
    End Sub

    Public Shared Function IsRejected(itsID As String)
        Dim query As String = "SELECT COUNT(*) FROM PARTYLEDGER WHERE EJAMAAT = @ITSID AND REJECTREASON <> ''"
        Dim oledb As OleDbConnection = Globals.DatabaseConnection
        Dim rejectedCount = 0
        oledb.Open()
        With New OleDbCommand
            .Connection = oledb
            .CommandText = query
            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@ITSID", itsID)
            rejectedCount = Convert.ToInt32(.ExecuteScalar)
            oledb.Close()
        End With
        Return rejectedCount > 0
    End Function

    Public Sub Add(info As MemberInfo)
        Dim query As String = "INSERT INTO PartyLedger (Member_Name,Group_Leader,Mobile,Email,Country,Ejamaat,[Image],MPW,Status,AddedDate,Gender,KarbalaZiyaarat,Moharramaat,DeeniSheear,CoreMember,Approved) " &
                              "VALUES (@Member_Name,@Group_Leader,@Mobile,@Email,@Country,@Ejamaat,@Image,@MPW,@Status,DATE(),@Gender,@Karbala,@Moharramaat,@DeeniSheaar,@CoreMember,@Approved)"
        Dim oledb As OleDbConnection = Globals.DatabaseConnection
        oledb.Open()
        With New OleDbCommand
            .Connection = oledb
            .CommandText = query
            .Parameters.AddWithValue("@Member_Name", info.MemberName)
            .Parameters.AddWithValue("@Group_Leader", info.GroupLeader)
            .Parameters.AddWithValue("@Mobile", info.MobileNumber)
            .Parameters.AddWithValue("@Email", info.Email)
            .Parameters.AddWithValue("@Country", info.Country)
            .Parameters.AddWithValue("@Ejamaat", info.EjamaatID)
            .Parameters.AddWithValue("@Image", info.Image)
            .Parameters.AddWithValue("@MPW", info.Password)
            .Parameters.AddWithValue("@Status", info.Status)
            .Parameters.AddWithValue("@Gender", info.Gender)
            .Parameters.AddWithValue("@Karbala", info.KarbalaZiyarat)
            .Parameters.AddWithValue("@Moharramaat", info.Moharramaat)
            .Parameters.AddWithValue("@DeeniSheaar", info.DeeniSheaar)
            .Parameters.AddWithValue("@CoreMember", info.CoreMember)
            .Parameters.AddWithValue("@Approved", info.Approved)
            .ExecuteNonQuery()
            oledb.Close()
        End With
    End Sub


    Public Shared Sub TagUserAccount(itsID As String, accountType As String)
        Dim insertQuery As String = String.Empty
        Dim accounts As String() = accountType.Split(",")
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        connection.Open()
        If accounts.Length > 1 Then
            With New OleDbCommand()
                .Connection = connection
                .CommandText = "DELETE FROM USERACCOUNTTYPE WHERE ITSID='" + itsID + "'"
                .ExecuteNonQuery()
                .CommandText = "INSERT INTO USERACCOUNTTYPE VALUES ('" & accounts(0).ToUpper & "', '" & itsID & "')"
                .ExecuteNonQuery()
                .CommandText = "INSERT INTO USERACCOUNTTYPE VALUES ('" & accounts(1).ToUpper & "', '" & itsID & "')"
                .ExecuteNonQuery()
            End With
        Else
            With New OleDbCommand()
                .Connection = connection
                .CommandText = "DELETE FROM USERACCOUNTTYPE WHERE ITSID='" + itsID + "'"
                .ExecuteNonQuery()
                .CommandText = "INSERT INTO USERACCOUNTTYPE VALUES ('" & accounts(0).ToUpper & "', '" & itsID & "')"
                .Connection = connection
                .ExecuteNonQuery()
            End With
        End If
        connection.Close()
    End Sub

    Public Sub ApproveMember(itsID As String)
        Dim query As String = "UPDATE PartyLedger SET Approved=True, RejectReason='', Status='Active' WHERE EJAMAAT = @ITSID"
        Dim oledb As OleDbConnection = Globals.DatabaseConnection
        oledb.Open()
        With New OleDbCommand
            .CommandType = CommandType.Text
            .Connection = oledb
            .CommandText = query
            .Parameters.AddWithValue("@ITSID", itsID)
            .ExecuteNonQuery()
            oledb.Close()
        End With
    End Sub

    Public Sub Update(info As MemberInfo, oldITS As String)
        Dim oledb As OleDbConnection = Globals.DatabaseConnection
        Try
            Dim query As String = "UPDATE PartyLedger SET MEMBER_NAME = @Member_Name, GROUP_LEADER = @Group_Leader, MOBILE = @Mobile, EMAIL = @Email, COUNTRY = @Country, EJAMAAT = @Ejamaat, [IMAGE] = @Image, GENDER = @Gender, KarbalaZiyaarat = @Karbala, Moharramaat = @Moharramaat, DeeniSheear = @DeeniSheear, Status = @Status WHERE EJAMAAT = @OldITSID"
            oledb.Open()
            With New OleDbCommand
                .Connection = oledb
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@Member_Name", info.MemberName)
                .Parameters.AddWithValue("@Group_Leader", info.GroupLeader)
                .Parameters.AddWithValue("@Mobile", info.MobileNumber)
                .Parameters.AddWithValue("@Email", info.Email)
                .Parameters.AddWithValue("@Country", info.Country)
                .Parameters.AddWithValue("@Ejamaat", info.EjamaatID)
                .Parameters.AddWithValue("@Image", info.Image)
                .Parameters.AddWithValue("@Gender", info.Gender)
                .Parameters.AddWithValue("@Karbala", info.KarbalaZiyarat)
                .Parameters.AddWithValue("@Moharramaat", info.Moharramaat)
                .Parameters.AddWithValue("@DeeniSheear", info.DeeniSheaar)
                .Parameters.AddWithValue("@Status", info.Status)
                .Parameters.AddWithValue("@OldITSID", oldITS)
                .ExecuteNonQuery()
                oledb.Close()
            End With
        Catch ex As Exception
            HttpContext.Current.Response.Write(ex.ToString)
        Finally
            oledb.Close()
        End Try

    End Sub

    Public Shared Function LeadersType(eJamaatID As String) As AccountType
        Dim accountType As AccountType
        With New OleDbDataAdapter("SELECT SWITCH(TYPE='LIMITED ACCESS', 'GroupLeader', TYPE='FULL ACCESS','Administrator') AS LeaderType FROM GROUPLEADER WHERE EJAMAAT = '" & eJamaatID & "'", Globals.DatabaseConnection)
            Dim dt As New DataTable
            .Fill(dt)
            If (dt.Rows.Count > 0) Then
                accountType = DirectCast([Enum].Parse(GetType(AccountType), dt.Rows(0)("LeaderType")), AccountType)
            Else
                accountType = Hizbe_Jamali_Web.AccountType.Member
            End If
        End With
        Return accountType
    End Function

    Public Sub ChangePassword(password As String, eJamaatID As String)
        Dim query As String = "UPDATE PARTYLEDGER SET MPW=@Password WHERE Ejamaat=@Ejamaat"
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Try
            connection.Open()
            With New OleDbCommand
                .CommandType = CommandType.Text
                .CommandText = query
                .Connection = connection
                .Parameters.AddWithValue("@Password", password)
                .Parameters.AddWithValue("@Ejamaat", eJamaatID)
                .ExecuteNonQuery()
                connection.Close()
            End With
        Catch ex As Exception
        Finally
            connection.Close()
        End Try
    End Sub

    Public Function GetAllGroupMembers(leaderITS As String) As List(Of MemberInfo)
        Dim query As String = "SELECT ACCOUNT_NO, MEMBER_NAME, GROUP_LEADER, MOBILE, EMAIL, COUNTRY, EJAMAAT, IMAGE, MPW, STATUS, COREMEMBER, KARBALAZIYAARAT, DEENISHEEAR, MOHARRAMAAT, GENDER, APPROVED, U.ACCOUNTTYPE FROM PARTYLEDGER P INNER JOIN USERACCOUNTTYPE U ON P.EJAMAAT = U.ITSID WHERE GROUP_LEADER IN (SELECT NAME FROM GROUPLEADER WHERE EJAMAAT=@ITS) ORDER BY MEMBER_NAME"
        Dim ds As New DataSet
        Dim _groupMembers As New List(Of MemberInfo)
        With New OleDbDataAdapter(query, Globals.DatabaseConnection)
            .SelectCommand.Parameters.AddWithValue("@ITS", leaderITS)
            .Fill(ds)
            For Each row As DataRow In ds.Tables(0).Rows
                Dim member As New MemberInfo
                member.AccountNo = row.ItemArray(0).ToString()
                member.MemberFullName = row.ItemArray(1).ToString()
                member.GroupLeader = row.ItemArray(2).ToString()
                member.MobileNumber = row.ItemArray(3).ToString()
                member.Email = row.ItemArray(4).ToString()
                member.Country = row.ItemArray(5).ToString()
                member.EjamaatID = row.ItemArray(6).ToString()
                member.Image = row.ItemArray(7).ToString()
                member.Password = row.ItemArray(8).ToString()
                member.Status = row.ItemArray(9).ToString()
                member.CoreMember = row.ItemArray(10).ToString
                member.KarbalaZiyarat = Convert.ToBoolean(row.ItemArray(11))
                member.DeeniSheaar = Convert.ToBoolean(row.ItemArray(12))
                member.Moharramaat = Convert.ToBoolean(row.ItemArray(13))
                member.Gender = row.ItemArray(14).ToString
                member.Approved = row.ItemArray(15).ToString
                member.AccountType = row.ItemArray(16).ToString
                _groupMembers.Add(member)
            Next
        End With
        Return _groupMembers
    End Function

    Public Shared Function GetMemberByFullName(memberFullName As String) As MemberInfo
        Dim query As String = "SELECT EJAMAAT, EMAIL, GROUP_LEADER, Member_Name FROM PARTYLEDGER WHERE MEMBER_NAME = @MEMBERNAME"
        Dim ds As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Dim _members As New MemberInfo
        With New OleDbDataAdapter(query, connection)
            .SelectCommand.Parameters.AddWithValue("@MEMBERNAME", memberFullName)
            .Fill(ds)
            _members.MemberFullName = ds.Rows(0)("Member_Name").ToString
            _members.GroupLeader = ds.Rows(0)("Group_Leader").ToString
            _members.EjamaatID = ds.Rows(0)("Ejamaat").ToString
            _members.Email = ds.Rows(0)("Email").ToString
        End With
        Return _members
    End Function

    Public Function GetAllLeaders() As List(Of MemberInfo)
        Dim query As String = "SELECT PL.MEMBER_NAME AS MEMBER_FULLNAME, GL.Name AS MEMBER_NAME, GL.EJAMAAT, GL.TYPE, PL.EMAIL, GL.MPW as [PASSWORD] FROM GROUPLEADER GL INNER JOIN PARTYLEDGER PL ON GL.EJAMAAT = PL.EJAMAAT"
        Dim dt As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Dim _members As New List(Of MemberInfo)
        With New OleDbDataAdapter(query, connection)
            .Fill(dt)
            For Each row As DataRow In dt.Rows
                Dim _member As New MemberInfo
                _member.MemberName = row("Member_Name").ToString
                _member.MemberFullName = row("Member_FullName").ToString
                _member.Email = row("Email").ToString
                _member.EjamaatID = row("Ejamaat").ToString
                _member.MemberType = row("Type").ToString
                _member.Password = row("Password").ToString
                _members.Add(_member)
            Next
        End With
        Return _members
    End Function

    Public Shared Function GetMemberInfoByType(itsID As String, type As AccountType) As MemberInfo
        Dim member As New MemberInfo
        If type = AccountType.Member Then
            member = New MemberInfo().GetAllMembers(UserType.Active).Find(Function(item) item.MemberType = String.Empty)
        ElseIf type = AccountType.GroupLeader Then
            member = New MemberInfo().GetAllMembers(UserType.Active).Find(Function(item) item.MemberType = "Limited Access")
        ElseIf type = AccountType.Administrator Then
            member = New MemberInfo().GetAllMembers(UserType.Active).Find(Function(item) item.MemberType = "Full Access")
        End If
        Return member
    End Function

    Public Shared Function GetGroupLeader(name As String) As MemberInfo
        Dim _member As New MemberInfo
        Dim query As String = "SELECT PL.MEMBER_NAME AS MEMBER_FULLNAME, GL.Name AS MEMBER_NAME, GL.EJAMAAT, GL.TYPE, PL.EMAIL, PL.Mobile as MobileNumber FROM GROUPLEADER GL INNER JOIN PARTYLEDGER PL ON GL.EJAMAAT = PL.EJAMAAT WHERE GL.NAME = '" + name + "'"
        Dim dt As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        With New OleDbDataAdapter(query, connection)
            .Fill(dt)
            Dim row As DataRow = dt.Rows(0)
            _member.MemberName = row("Member_Name").ToString
            _member.MemberFullName = row("Member_FullName").ToString
            _member.Email = row("Email").ToString
            _member.EjamaatID = row("Ejamaat").ToString
            _member.MemberType = row("Type").ToString
            _member.MobileNumber = row("MobileNumber").ToString
        End With
        Return _member
    End Function

End Class

Public Class MemberJournalController
    Public Shared Function GetTotalContribution(userName As String) As Integer
        Dim _contri As Integer = 0
        Dim query As String = "SELECT SUM(Amount) FROM JournalEntry WHERE  Account_Name = @Account_Name"
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        connection.Open()
        With New OleDbCommand(query, connection)
            .CommandType = CommandType.Text
            .Parameters.AddWithValue("@Account_Name", userName)
            Dim objScalar As Object = .ExecuteScalar()
            If Not IsDBNull(objScalar) Then
                _contri = Convert.ToInt32(objScalar)
            End If
            connection.Close()
        End With
        Return _contri
    End Function

    Public Function SearchRangeByGroupLeader(GLName As String, fromDate As String, fromTo As String) As List(Of MemberJournal)
        Dim _member As New List(Of MemberJournal)
        Dim query As String = "SELECT JVNo, DOJ, Account_Name, Narration, FCY, Amount, Sign, ejamaat FROM journalentry where DOJ between #" + fromDate + "# and #" + fromTo + "# and Leader_Name = '" + GLName + "' and account_name <> 'Cash Account' order by JVNo desc"
        Dim dt As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        With New OleDbDataAdapter(query, connection)
            .Fill(dt)
            For Each row As DataRow In dt.Rows
                Dim member As New MemberJournal
                member.JVNo = row("JVNo").ToString
                member.Membername = row("account_name").ToString
                member.AddedDate = Convert.ToDateTime(row("doj"))
                member.eJamaatID = row("ejamaat").ToString
                member.Narration = row("narration").ToString
                member.CurrencyName = row("fcy").ToString
                member.Amount = Convert.ToInt32(row("amount"))
                _member.Add(member)
            Next
        End With
        Return _member
    End Function
End Class

Public Class FostershipController
    Public Function GetAllFosteredMumineens() As List(Of FostershipInfo)
        Dim _members As New List(Of FostershipInfo)
        Dim query As String = "SELECT FL.ITSID, FULLNAME, CONTACTNUMBER, COUNTRY, ADDRESS, EMAILADDRESS, PHOTO, TOTALRECURRINGAMOUNT, ADDEDDATE, SUM(fb.Amount) as TOTALFOSTERAMOUNT FROM (FOSTERLEDGER FL inner join fosterbreakupitems fb on FL.ITSID = fb.ITSID) group by FL.ITSID, FULLNAME, CONTACTNUMBER, COUNTRY, ADDRESS, EMAILADDRESS, PHOTO, TOTALRECURRINGAMOUNT, ADDEDDATE"
        Dim dt As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        With New OleDbDataAdapter(query, connection)
            .Fill(dt)
            For Each row As DataRow In dt.Rows
                Dim _member As New FostershipInfo
                _member.ITSID = row("ITSID").ToString
                _member.FullName = row("FullName").ToString
                _member.ContactNumber = row("ContactNumber").ToString
                _member.Country = row("Country").ToString
                _member.Address = row("Address").ToString
                _member.EmailAddress = row("EmailAddress").ToString
                _member.Photo = row("Photo").ToString
                _member.TotalFosterAmount = Convert.ToInt32(row("TotalFosterAmount"))
                _member.TotalRecurringAmount = Convert.ToInt32(row("TotalRecurringAmount"))
                _member.AddedDate = Convert.ToDateTime(row("AddedDate"))
                _members.Add(_member)
            Next
        End With
        Return _members
    End Function

    Public Function GetAllFosterGroups() As DataTable
        Dim query As String = "SELECT GROUPID, GROUPNAME FROM FOSTERITEMGROUP"
        Dim dt As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Dim adap As New OleDbDataAdapter(query, connection)
        adap.Fill(dt)
        Return dt
    End Function

    Public Function GetUserFosterAmountByGroup(itsID As String) As DataTable
        Dim query As String = "SELECT FG.GROUPID, FG.GROUPNAME, SUM(FB.AMOUNT) AS TOTAL FROM ((FOSTERITEMGROUP FG LEFT JOIN FOSTERITEMS F ON FG.GROUPID = F.GROUPID) LEFT JOIN FOSTERBREAKUPITEMS  FB ON F.ID = FB.FOSTERITEMID)  WHERE FB.ITSID = " & itsID & " GROUP BY FG.GROUPID, FG.GROUPNAME"
        Dim dt As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Dim adap As New OleDbDataAdapter(query, connection)
        adap.Fill(dt)
        Return dt
    End Function

    Public Function GetAllFosterItems() As DataTable
        Dim query As String = "SELECT fg.GroupID, fg.GroupName, fi.ID as ItemID, fi.ItemName FROM FosterItemGroup fg INNER JOIN FosterItems fi ON fg.GroupID = fi.GroupID"
        Dim dt As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Dim adap As New OleDbDataAdapter(query, connection)
        adap.Fill(dt)
        Return dt
    End Function

    Public Function GetUserFosterItems(itsID As String) As DataTable
        Dim query As String = "SELECT fi.ID as ITEMID, AMOUNT, REMARK, fb.Status FROM FOSTERITEMS FI INNER JOIN FOSTERBREAKUPITEMS FB ON FI.ID = FB.FOSTERITEMID WHERE FB.ITSID = " & itsID
        Dim dt As New DataTable
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Dim adap As New OleDbDataAdapter(query, connection)
        adap.Fill(dt)
        Return dt
    End Function



    Public Shared Function GetTotalAmountSpentOnFostership() As Integer
        Dim _amount As Integer
        Dim query As String = "SELECT SUM(AMOUNT) FROM FOSTERBREAKUPITEMS"
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        With New OleDbCommand
            .Connection = connection
            .CommandType = CommandType.Text
            .CommandText = query
            connection.Open()
            Dim reader As OleDbDataReader = .ExecuteReader
            reader.Read()
            If reader.HasRows Then
                _amount = CType(reader.GetValue(0), Integer)
            End If
        End With
        connection.Close()
        Return _amount
    End Function
End Class

Public Class ZaereenLedgerController
    Public Shared Function GetLastAccountNo() As Integer
        Dim query As String = "select max(account_no) from zaereenledger"
        Dim connection As OleDbConnection = Globals.DatabaseConnection
        Dim accountNo As Integer
        With New OleDbCommand
            .Connection = connection
            .CommandType = CommandType.Text
            .CommandText = query
            connection.Open()
            Dim reader As OleDbDataReader = .ExecuteReader
            reader.Read()
            accountNo = CType(reader.GetValue(0), Integer)
            connection.Close()
        End With
        Return accountNo
    End Function
    Public Sub Add(dt As DataTable)
        Dim lastAccountNo As Integer = GetLastAccountNo()
        Dim iCount As Integer = 1
        For Each row As DataRow In dt.Rows
            Dim query As New StringBuilder
            query.Append("insert into zaereenledger (account_no, zaereen_name, age, ejamaat, mobile, occupation, address, tripexp, status, doj) values (")
            query.Append((lastAccountNo + iCount).ToString() + ",")
            query.Append("'" + row("name") + "',")
            If Not String.IsNullOrEmpty(row("Age")) Then
                query.Append("'" + row("age").ToString + "',")
            Else
                query.Append("'',")
            End If
            If Not String.IsNullOrEmpty(row("Its")) Then
                query.Append("'" + row("Its").ToString + "',")
            Else
                query.Append("'',")
            End If
            If Not String.IsNullOrEmpty(row("mobile")) Then
                query.Append("'" + row("mobile").ToString + "',")
            Else
                query.Append("'',")
            End If

            query.Append("'" + row("occupation").ToString().Replace("""", "").Replace("'", "") + "',")
            query.Append("'" + row("place").ToString().Replace("""", "").Replace("'", "") + "',")
            query.Append(row("paid by hj").ToString + ",")
            query.Append("'" + row("financial status").ToString().Replace("""", "").Replace("'", "") + "',")
            query.Append(row("Journey Date").ToString + ")")

            Dim connection As OleDbConnection = Globals.DatabaseConnection
            With New OleDbCommand
                .Connection = connection
                .CommandType = CommandType.Text
                .CommandText = query.ToString
                connection.Open()
                .ExecuteNonQuery()
                connection.Close()
            End With
            iCount += 1
        Next

    End Sub
End Class

Public Class FostershipItemBreakupController

End Class