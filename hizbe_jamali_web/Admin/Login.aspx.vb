Public Class Login1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub
    Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim member As MemberInfo = MemberInfo.GetMember(txteJamaatID.Text)
        If Not member Is Nothing Then
            Dim type As AccountType = MemberInfo.LeaderType(txteJamaatID.Text)
            Session("TID") = member.EjamaatID
            If type <> AccountType.Member Then
                If member.Password = txtPassword.Text Then
                    Globals.LoggedInUserType = type
                    If Not member.IsFirstLogin() Then
                        Select Case type
                            Case AccountType.Administrator
                                Response.Redirect("/homeadmin.aspx?TD=" + txteJamaatID.Text)
                            Case AccountType.GroupLeader
                                Response.Redirect("/homeadmin1.aspx?TD=" + txteJamaatID.Text)
                        End Select
                    Else
                        Response.Redirect("/changepassword.aspx")
                    End If
                Else
                    lblMissing.Visible = True
                End If
            Else
                lblMissing.Visible = True
            End If
        Else
            lblMissing.Visible = True
        End If


        'If txtTeacher.Text = "20406920" And txtTeacherPW.Text = "qf5152" Then
        '    da = New OleDb.OleDbDataAdapter("SELECT * FROM PartyLedger WHERE Ejamaat='20406920' AND MPW ='qf5152'", con)
        '    ds = New DataSet
        '    If da.Fill(ds) Then
        '        Response.Redirect("homeadmin1.aspx?TD=" + Session("TID") + "")
        '    Else
        '        lblMissing.Visible = True
        '        MainView.ActiveViewIndex = 1
        '    End If
        'ElseIf txtTeacher.Text = "30389395" Or txtTeacher.Text = "30389634" Or txtTeacher.Text = "30370202" Or txtTeacher.Text = "30391176" Or txtTeacher.Text = "30389077" Then
        '    da = New OleDb.OleDbDataAdapter("SELECT * FROM PartyLedger WHERE Ejamaat='" & Session("TID") & "' AND MPW ='" & txtTeacherPW.Text & "'", con)
        '    ds = New DataSet
        '    If da.Fill(ds) Then
        '        Response.Redirect("homeadmin.aspx?TD=" + Session("TID") + "")
        '    Else
        '        lblMissing.Visible = True
        '        MainView.ActiveViewIndex = 1
        '    End If
        '    lblMissing.Visible = True
        'End If


        'da = New OleDb.OleDbDataAdapter("SELECT * FROM GroupLeader WHERE Ejamaat='" & txteJamaatID.Text & "' AND MPW='" & txtPassword.Text & "' AND Type='Full Access'", con)
        'ds = New DataSet
        'da.Fill(ds)

        'If ds.Tables(0).Rows.Count > 0 Then
        '    Response.Redirect("/homeadmin.aspx?TD=" + Session("TID") + "")
        'Else
        '    lblMissing.Visible = True
        'End If

        'Dim da1 As New OleDb.OleDbDataAdapter("SELECT * FROM GroupLeader WHERE Ejamaat='" & txtTeacher.Text & "' AND MPW='" & txtTeacherPW.Text & "' AND Type='Limited Access'", con)
        'Dim ds1 As New DataSet
        'If da1.Fill(ds1) Then
        '    Response.Redirect("homeadmin1.aspx?TD=" + Session("TID") + "")
        'Else
        '    lblMissing.Visible = True
        '    MainView.ActiveViewIndex = 1
        'End If

    End Sub

End Class