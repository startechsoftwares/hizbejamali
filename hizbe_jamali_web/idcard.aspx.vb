Imports System.Collections.Generic
Imports System.IO

Public Class IdCardData
    Private _its As String
    Public Property ITS As String
        Get
            Return _its
        End Get
        Set(value As String)
            _its = value
        End Set
    End Property
    Private _name As String
    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property
    Private _age As Integer
    Public Property Age As Integer
        Get
            Return _age
        End Get
        Set(value As Integer)
            _age = value
        End Set
    End Property
    Private _mobileNumber As String
    Public Property MobileNumber As String
        Get
            Return _mobileNumber
        End Get
        Set(value As String)
            _mobileNumber = value
        End Set
    End Property
    Private _city As String
    Public Property City As String
        Get
            Return _city
        End Get
        Set(value As String)
            _city = value
        End Set
    End Property
    Private _glname As String
    Public Property GroupLeaderName As String
        Get
            Return _glname
        End Get
        Set(value As String)
            _glname = value
        End Set
    End Property

    Private _glmobile As String
    Public Property GroupLeaderMobileNumber As String
        Get
            Return _glmobile
        End Get
        Set(value As String)
            _glmobile = value
        End Set
    End Property

End Class
Public Class idcard
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.QueryString("type") Is Nothing Then
            plcCardType1.Visible = Request.QueryString("type") = "1"
            plcCardType2.Visible = Request.QueryString("type") = "2"
        Else
            plcCardType1.Visible = False
            plcCardType2.Visible = False
            plcError.Visible = True
            lblError.Text = "Url is invalid append (?type=1 or ?type=2) at the end of the url for processing idcards"
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs)
        If fuZaereenList.HasFile Then
            Dim idCardList As New List(Of IdCardData)
            Dim reader As New StreamReader(fuZaereenList.PostedFile.InputStream)
            While Not reader.EndOfStream
                Dim rowValue() As String = reader.ReadLine().Split(",")
                Dim id As New IdCardData
                id.Name = rowValue(0)
                id.Age = rowValue(1)
                id.MobileNumber = rowValue(2)
                id.ITS = String.Empty
                If (rowValue.Length > 3 AndAlso rowValue(3) <> String.Empty) Then
                    id.ITS = rowValue(3)
                End If
                If txtGLName.Text <> String.Empty Then
                    id.GroupLeaderName = txtGLName.Text
                End If
                If txtGLNumber.Text <> String.Empty Then
                    id.GroupLeaderMobileNumber = txtGLNumber.Text
                End If
                idCardList.Add(id)
            End While
            rptIdCard.DataSource = idCardList
            rptIdCard.DataBind()
        End If
    End Sub

    Protected Sub btnCardType2_Click(sender As Object, e As EventArgs)
        If fupCardType2.HasFile Then
            Dim idCardList As New List(Of IdCardData)
            Dim reader As New StreamReader(fupCardType2.PostedFile.InputStream)
            While Not reader.EndOfStream
                Dim rowValue() As String = reader.ReadLine().Split(",")
                Dim id As New IdCardData
                id.Name = rowValue(0)
                id.City = rowValue(1)
                id.MobileNumber = rowValue(2)
                idCardList.Add(id)
            End While
            dtlCard2.DataSource = idCardList
            dtlCard2.DataBind()
        End If
    End Sub
End Class