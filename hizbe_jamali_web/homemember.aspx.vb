Imports System.IO
Partial Public Class homemember
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Private grdTotal As Decimal = 0
    Dim cm As New OleDb.OleDbCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Globals.RedirectUserIfLoggedOut()
            cm.Connection = con
            con.Open()
            lblLogged.Text = Session("TID")
            da = New OleDb.OleDbDataAdapter("SELECT Member_Name, [Image] FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
            ds = New DataSet
            da.Fill(ds)
            lblLogged.Text = ds.Tables(0).Rows(0)(0)

            Call DatagridUpdate()
            da = New OleDb.OleDbDataAdapter("SELECT SUM(Amount) FROM JournalEntry WHERE  Ejamaat = '" & Globals.GetSessionEJamaatID & "' AND PAIDAGAINST = '" & Globals.UserAccountType.ToString & "'", con)
            dt = New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                If Not String.IsNullOrEmpty(dt.Rows(0)(0).ToString) Then
                    lblAccountBal.Text = CType(dt.Rows(0)(0).ToString, Double).ToString("0.00")
                Else
                    lblAccountBal.Text = "0.00"
                End If
            Else
                lblAccountBal.Text = "0.00"
            End If

            ' lblAccountBal.Text = CType(lblAccountBal.Text, Double).ToString("0.00")
            litMenuLink.Text = Globals.SetLink
            con.Close()
        Catch ex As Exception
            Response.Write(ex.ToString)
        End Try

    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)

        lblName.Text = ds.Tables(0).Rows(0)(1)
        lblEjamaat.Text = ds.Tables(0).Rows(0)(6)
        lblContact.Text = ds.Tables(0).Rows(0)(3).ToString
        lblEmail.Text = ds.Tables(0).Rows(0)(4).ToString
        Dim var1 As String = ds.Tables(0).Rows(0)(2).ToString
        Image1.ImageUrl = "~/images/NoPhoto.jpg"
        Dim _image As String = ds.Tables(0).Rows(0)(7).ToString
        If String.IsNullOrEmpty(_image) Then
            Dim filename As String = Directory.GetFiles(Server.MapPath("~/images/")).ToList().Find(Function(item) item.ToString().Contains(Session("TID")))
            Image1.ImageUrl = "/images/" + Path.GetFileName(filename)
        Else
            Image1.ImageUrl = _image
        End If

        Dim groupLeaderInfo As MemberInfo = MemberInfo.GetGroupLeader(var1)
        lblLName.Text = groupLeaderInfo.MemberFullName
        lblLContact.Text = groupLeaderInfo.MobileNumber
        lblLEmail.Text = groupLeaderInfo.Email

        'Dim da3 As New OleDb.OleDbDataAdapter("SELECT * FROM GroupLeader WHERE  Name='" & var1 & "'", con)
        'Dim ds3 As New DataSet
        'da3.Fill(ds3)
        'lblLName.Text = ds3.Tables(0).Rows(0)(1).ToString

        'Dim da2 As New OleDb.OleDbDataAdapter("SELECT * FROM PartyLedger WHERE  Member_Name='" & lblLName.Text & "'", con)
        'Dim ds2 As New DataSet
        'da2.Fill(ds2)
        'lblLContact.Text = ds2.Tables(0).Rows(0)(3).ToString
        'lblLEmail.Text = ds2.Tables(0).Rows(0)(4).ToString
        'Dim var As String = ds2.Tables(0).Rows(0)(6).ToString
       
    End Sub
End Class