Partial Public Class foster
    Inherits System.Web.UI.Page
    Public con As New OleDb.OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("App_Data\HizbeJamali.mdb"))
    Dim da As New OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Private grdTotal As Decimal = 0
    Dim cm As New OleDb.OleDbCommand

    Dim foster As New FostershipInfo
    Shared fosterItems As New DataTable
    Shared userFosterItems As DataTable
    Shared userFosterGroup As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Globals.RedirectUserIfLoggedOut()
        cm.Connection = con
        con.Open()

        lblLogged.Text = Session("TID")

        da = New OleDb.OleDbDataAdapter("SELECT Member_Name FROM PartyLedger WHERE  Ejamaat='" & Session("TID") & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblLogged.Text = ds.Tables(0).Rows(0)(0)

        da = New OleDb.OleDbDataAdapter("SELECT SUM(Amount) FROM JournalEntry WHERE  Account_Name = '" & lblLogged.Text & "'", con)
        ds = New DataSet
        da.Fill(ds)
        lblAccountBal.Text = ds.Tables(0).Rows(0)(0).ToString

        Call DatagridUpdate()
        lblTotal.Text = FostershipInfo.GetTotalAmountSpentOnFostership().ToString("N")

        con.Close()
        litMenuLink.Text = Globals.SetLink
    End Sub
    Private Sub DatagridUpdate()
        grdFoster.DataSource = foster.GetAllFosteredMumineens
        grdFoster.DataBind()
    End Sub
    Public Sub grdFoster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdFoster.PageIndexChanging
        grdFoster.PageIndex = e.NewPageIndex
        grdFoster.DataBind()
    End Sub
    Public Sub grdFoster_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdFoster.RowCommand
        fosterItems = foster.GetAllFosterItems()
        userFosterItems = foster.GetAllUserFosterItems(e.CommandName)
        userFosterGroup = foster.GetAllUserFosterGroups(e.CommandName)
        rptFosterGroups.DataSource = foster.GetAllFosterGroups
        rptFosterGroups.DataBind()
        ModalPopupExtender1.Show()
    End Sub

    Protected Sub rptFosterGroups_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim groupID As HiddenField = CType(e.Item.FindControl("hdnGroupID"), HiddenField)
        Dim itemRepeater As Repeater = CType(e.Item.FindControl("rptFosterItems"), Repeater)
        Dim dataTable As DataTable = fosterItems.Select("GroupID=" & groupID.Value).CopyToDataTable()
        Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
        For Each rows As DataRow In userFosterGroup.Rows
            Dim label As Label = CType(e.Item.FindControl("lblTotal"), Label)
            If row("GroupID") = rows("GroupID") Then
                label.Text = SetAmount(rows("Total").ToString)
                If rows("Total") = "0" Then
                    label.Text = "Available"
                End If
            Else
                If label.Text = String.Empty Then
                    label.Text = "Available"
                End If
            End If
        Next
        itemRepeater.DataSource = dataTable
        itemRepeater.DataBind()
    End Sub

    Public Shared Function SetAmount(amount As String) As String
        If amount <> String.Empty Then
            Return "Rs " & amount
        Else
            Return ""
        End If
    End Function

    Protected Sub rptFosterItems_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim row As DataRowView = CType(e.Item.DataItem, DataRowView)
        For Each rows As DataRow In userFosterItems.Rows
            Dim labelAmount As Label = CType(e.Item.FindControl("lblAmount"), Label)
            If row("ItemID") = rows("ItemID") Then
                labelAmount.Text = SetAmount(rows("Amount").ToString)
                If Convert.ToInt32(rows("Amount")) = 0 Then
                    labelAmount.Text = rows("Status").ToString
                End If
            Else
                If labelAmount.Text = String.Empty Then
                    labelAmount.Text = "Available"
                End If
            End If
        Next
    End Sub

    Protected Function GetFormattedITSID(its As String) As String
        If Not its = "0" Then
            Return its
        Else
            Return "No"
        End If
    End Function
End Class