Public Partial Class login
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim cm As New OleDb.OleDbCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Globals.SetTimeoutMessage(TimeOutMessage)
    End Sub
    Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Session("TID") = txteJamaatID.Text
        Dim controller As New MemberController
        Dim member As MemberInfo = controller.GetAllMembers().Find(Function(item) item.UserAccountType.ToUpper = drpAccountType.SelectedValue.ToUpper And item.EjamaatID = txteJamaatID.Text)
        If Not member Is Nothing AndAlso member.Status.ToLower = "active" Then
            If member.Password = txtPassword.Text Then
                Globals.LoggedInUserType = AccountType.Member
                Globals.UserAccountType = DirectCast([Enum].Parse(GetType(UserAccountType), drpAccountType.SelectedValue), UserAccountType)
                If Not member.IsFirstLogin() Then
                    Response.Redirect(("homemember.aspx?TD=" + Session("TID")).ToString().Resolve)
                Else
                    Response.Redirect("changepassword.aspx".Resolve)
                End If
            Else
                lblMissing.Visible = True
                lblMissing.Text = "** You are not registered member for " + drpAccountType.SelectedItem.Text
            End If
        Else
            lblMissing.Visible = True
            lblMissing.Text = "** You are not registered member for " + drpAccountType.SelectedItem.Text
        End If
    End Sub
End Class