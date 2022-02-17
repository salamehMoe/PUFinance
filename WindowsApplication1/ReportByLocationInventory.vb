Public Class ReportByLocationInventory

    Dim dbObject As New DatabaseAccesClass
    Dim dt As New DataTable
    Dim locationList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))
    Dim exportToExcell As New exportdatagridviewclass
    Private Sub ReportByLocationInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getLocations()

    End Sub

    'Get All Available Locatons
    Sub getLocations()

        locationDropBox.Items.Clear()
        locationList.Clear()

        Dim dt As DataTable = New DataTable

        dt = dbObject.SelectMethode("Select * from db_owner.tbl_location where Name <> 'Warehouse' or Name <> 'warehouse' and Status = 1")
        For i = 0 To dt.Rows.Count - 1
            locationList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("Name").ToString(), dt.Rows(i)("ID").ToString()))
        Next

        autoCompleteLocations()
    End Sub

    Sub autoCompleteLocations()

        Dim dt As DataTable = New DataTable()

        dt = dbObject.SelectMethode("Select Name from db_owner.tbl_location where Name <> 'Warehouse' or Name <> 'warehouse' and Status = 1")
        Dim row As DataRow = dt.NewRow()

        dt.Rows.InsertAt(row, 0)


        locationDropBox.DataSource = dt
        locationDropBox.DisplayMember = "Name"
        locationDropBox.ValueMember = "Name"


        locationDropBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        locationDropBox.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub
    '*****************************
    Function getTheInvLocation()
        dt = dbObject.SelectMethode("Select db_owner.tbl_item.ItemID as [Inventory ID], db_owner.tbl_location_inventory.ItemName as [Inventory Name], db_owner.tbl_location_inventory.ItemQty as [Quantity],
                                     db_owner.tbl_location_inventory.ItemAvgPrice as [Avarage Price], db_owner.tbl_location_inventory.itemTotalPrice as [Total],
                                     db_owner.tbl_location_inventory.ItemID from db_owner.tbl_location_inventory, db_owner.tbl_Item  
                                     where (db_owner.tbl_location_inventory.LocationName Like '%" & locationDropBox.Text & "%' and db_owner.tbl_location_inventory.ItemID = db_owner.tbl_Item.ID)")

        Return dt
    End Function

    Private Sub locationDropBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles locationDropBox.SelectedIndexChanged

    End Sub

    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click
        locationInvGrid.DataSource = getTheInvLocation()
        locationInvGrid.Columns(0).Width = 120
        locationInvGrid.Columns(1).Width = 150
        locationInvGrid.Columns(2).Width = 120
        locationInvGrid.Columns(3).Width = 150
        locationInvGrid.Columns(5).Visible = False

        For i As Integer = 0 To locationInvGrid.Rows.Count - 2
            locationInvGrid.Rows(i).Cells(3).Value = Math.Round(locationInvGrid.Rows(i).Cells(3).Value, 2)
            locationInvGrid.Rows(i).Cells(4).Value = Math.Round(locationInvGrid.Rows(i).Cells(4).Value, 2)

        Next
    End Sub

    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click
        locationInvGrid.Columns.RemoveAt(5)
        loadingPanel.Visible = True
        exportToExcell.DATAGRIDVIEW_TO_EXCEL(locationInvGrid)
        loadingPanel.Visible = False
    End Sub
End Class