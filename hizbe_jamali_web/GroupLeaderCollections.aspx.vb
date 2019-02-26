Public Class GroupLeaderCollections
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim _global As New MemberInfo
            drpGroupLeaders.DataSource = _global.GetAllLeaders()
            drpGroupLeaders.DataTextField = "MemberFullName"
            drpGroupLeaders.DataValueField = "MemberName"
            drpGroupLeaders.DataBind()
        End If
    End Sub

    Protected Sub btnGroupLeaderCollections_Click(sender As Object, e As EventArgs) Handles btnGroupLeaderCollections.Click
        Dim allCollections As List(Of MemberJournal) = New MemberJournal().SearchRangeByGroupLeader(drpGroupLeaders.SelectedValue, Convert.ToDateTime(txtFromDate.Text).ToString("MM/dd/yyyy"), Convert.ToDateTime(txtToDate.Text).ToString("MM/dd/yyyy"))
        grdGroupLeaderCollections.DataSource = allCollections
        grdGroupLeaderCollections.DataBind
        plcCollectionRow.Visible = allCollections.Count > 0
        lblTotal.Text = allCollections.Sum(Function(f) f.Amount)
        lblTotalKun.Text = allCollections.Where(Function(x) x.PaidAgainst.ToLower = "kun").Sum(Function(s) s.Amount)
        lblTotalFoster.Text = allCollections.Where(Function(x) x.PaidAgainst.ToLower = "foster").Sum(Function(s) s.Amount)
    End Sub
End Class