Imports System.IO
Partial Public Class homeadmin
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Private grdTotal As Decimal = 0
    Dim cm As New OleDb.OleDbCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
        cm.Connection = con
        con.Open()
        Call DatagridUpdate()

        Dim account As AccountType = MemberInfo.LeaderType(Globals.GetSessionEJamaatID)
        Select Case account
            Case AccountType.Member
                plcErrorMessage.Visible = True
                lnkDashBoard.NavigateUrl = "~/homemember.aspx?TD=" + Globals.GetSessionEJamaatID
            Case AccountType.Administrator
                plcMainContent.Visible = True
            Case AccountType.GroupLeader
                plcErrorMessage.Visible = True
                lnkDashBoard.NavigateUrl = "~/homeadmin1.aspx?TD=" + Globals.GetSessionEJamaatID
        End Select

        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0)
        da = New OleDb.OleDbDataAdapter("SELECT Name FROM GroupLeader WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            lblLeader.Text = ds.Tables(0).Rows(0)(0)
        Else
            lblLeader.Text = String.Empty
        End If
        con.Close()
    End Sub
    Private Sub DatagridUpdate()
        da = New OleDb.OleDbDataAdapter("SELECT * FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblName.Text = ds.Tables(0).Rows(0)(1)
        lblEjamaat.Text = ds.Tables(0).Rows(0)(6)
        lblContact.Text = ds.Tables(0).Rows(0)(3).ToString
        lblEmail.Text = ds.Tables(0).Rows(0)(4).ToString
        Image1.ImageUrl = "~/images/NoPhoto.jpg"
        Dim _image As String = ds.Tables(0).Rows(0)(7).ToString
        If String.IsNullOrEmpty(_image) Then
            Dim filename As String = Directory.GetFiles(Server.MapPath("~/images/")).ToList().Find(Function(item) item.ToString().Contains(Session("TID")))
            Image1.ImageUrl = "/images/" + Path.GetFileName(filename)
        Else
            Image1.ImageUrl = _image
        End If
    End Sub
End Class