Public Class ReportByLocation

    'Varaibles
    Dim dataBaseObject As New DatabaseAccesClass
    Dim extractToExcell As New exportdatagridviewclass

    Dim itemsList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))

    Dim theTotalQty As Integer = 0
    Dim theTotalPrice As Decimal = 0
    Dim retrievedItemID As Integer = 0
    Dim dt As New DataTable
    '*******************

    Private Sub InventoryByItemReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Gets available Items
        getItems()
        '******************


        'Displays the gridView
        locationGrid.DataSource = getAllItems()
        locationGrid.Columns(2).Width = 200
        locationGrid.Columns(0).Width = 150
        locationGrid.Columns(6).Visible = False

        For i As Integer = 0 To locationGrid.Rows.Count - 2
            locationGrid.Rows(i).Cells(4).Value = Math.Round(locationGrid.Rows(i).Cells(4).Value, 2)
            locationGrid.Rows(i).Cells(5).Value = Math.Round(locationGrid.Rows(i).Cells(5).Value, 2)

        Next

        '************************


    End Sub

    'Gets available Items and adds them to a listview
    Sub getItems()

        selectedItemBox.Items.Clear()
        itemsList.Clear()


        Dim dt As DataTable = New DataTable
        dt = dataBaseObject.SelectMethode("Select * from db_owner.tbl_Item where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            itemsList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ID").ToString()))

        Next

        autoCompleteItems()

    End Sub

    Sub autoCompleteItems()

        Dim dt As DataTable = New DataTable()

        dt = dataBaseObject.SelectMethode("Select ItemName from db_owner.tbl_Item where Status = 1 ")

        Dim row As DataRow = dt.NewRow()
        dt.Rows.InsertAt(row, 0)

        selectedItemBox.DataSource = dt
        selectedItemBox.DisplayMember = "ItemName"
        selectedItemBox.ValueMember = "ItemName"

    End Sub

    '*****************************************************

    'Gets All Item according the selected radioButton and the selectedItem
    Function getAllItems()

        theTotalQty = 0
        theTotalPrice = 0

        dt = dataBaseObject.SelectMethode("Select db_owner.tbl_location_inventory.LocationName as [Location], db_owner.tbl_Item.ItemID as [Item ID],
                                              db_owner.tbl_location_inventory.ItemName as [Item Name],
                                              db_owner.tbl_location_inventory.ItemQty as [Quantity], db_owner.tbl_location_inventory.ItemAvgPrice as [Avarage Cost],
                                              db_owner.tbl_location_inventory.itemTotalPrice [Total], db_owner.tbl_location_inventory.ItemID 
                                              from db_owner.tbl_location_inventory,db_owner.tbl_Item where (db_owner.tbl_location_inventory.ItemName LIKE '%" & selectedItemBox.Text & "%' 
                                              and db_owner.tbl_location_inventory.ItemID = db_owner.tbl_Item.ID)")


        'Gets the Totals of the displayed Items
        For i As Integer = 0 To dt.Rows.Count - 1

            theTotalQty = theTotalQty + dt.Rows(i)("Quantity").ToString()
            theTotalPrice = theTotalPrice + dt.Rows(i)("Total").ToString()

            totalQty.Text = theTotalQty.ToString
            totalPrice.Text = "$ " + theTotalPrice.ToString

        Next



        '******************************************
        Return dt

    End Function

    Private Sub selectedItemBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selectedItemBox.SelectedIndexChanged
        'gets the Item ID from the Listview after selecting an Item
        For Each pair As KeyValuePair(Of String, Integer) In itemsList

            Dim key As String = pair.Key
            If key = selectedItemBox.Text Then
                retrievedItemID = pair.Value
            End If

        Next

        itemIDLabel.Text = retrievedItemID
        '************************************************************
    End Sub

    'Creates the Report According to selected Item
    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        theTotalQty = 0
        theTotalPrice = 0

        locationGrid.DataSource = getAllItems()

        locationGrid.Columns(2).Width = 200
        locationGrid.Columns(0).Width = 150
        locationGrid.Columns(6).Visible = False

        For i As Integer = 0 To locationGrid.Rows.Count - 2
            locationGrid.Rows(i).Cells(4).Value = Math.Round(locationGrid.Rows(i).Cells(4).Value, 2)
            locationGrid.Rows(i).Cells(5).Value = Math.Round(locationGrid.Rows(i).Cells(5).Value, 2)

        Next


    End Sub
    '**********************************************

    'Initializes the Form On Cancel Clicked
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        theTotalQty = 0
        theTotalPrice = 0
        selectedItemBox.Text = String.Empty
        itemIDLabel.Text = "-"
        locationGrid.DataSource = getAllItems()

        locationGrid.Columns(2).Width = 200
        locationGrid.Columns(0).Width = 150
        locationGrid.Columns(6).Visible = False

        For i As Integer = 0 To locationGrid.Rows.Count - 2
            locationGrid.Rows(i).Cells(4).Value = Math.Round(locationGrid.Rows(i).Cells(4).Value, 2)
            locationGrid.Rows(i).Cells(5).Value = Math.Round(locationGrid.Rows(i).Cells(5).Value, 2)

        Next

    End Sub
    '******************************************

    'Exports the result Gridview to Excel
    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click
        dt.Rows.Add("TOTAL", "", "", theTotalQty, Nothing, theTotalPrice)

        'Displays the gridView
        locationGrid.DataSource = dt
        locationGrid.Columns(2).Width = 200
        locationGrid.Columns(0).Width = 150

        '************************
        locationGrid.Columns.RemoveAt(6)
        loadingPanel.Visible = True
        extractToExcell.DATAGRIDVIEW_TO_EXCEL(locationGrid)
        loadingPanel.Visible = False
        locationGrid.DataSource = getAllItems()
        locationGrid.Columns(2).Width = 200
        locationGrid.Columns(0).Width = 150
        locationGrid.Columns(6).Visible = False

        For i As Integer = 0 To locationGrid.Rows.Count - 2
            locationGrid.Rows(i).Cells(4).Value = Math.Round(locationGrid.Rows(i).Cells(4).Value, 2)
            locationGrid.Rows(i).Cells(5).Value = Math.Round(locationGrid.Rows(i).Cells(5).Value, 2)

        Next
    End Sub


    '*************************************
End Class