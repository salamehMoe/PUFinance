
Imports System.Data.SqlClient
Public Class stockTransaction

    'Variables
    Dim today As Date = Date.Now
    Shared random As New Random()
    Dim logedInUserID As Integer = My.Settings.userID

    Dim retrievedItemID As Integer = 0
    Dim generatedReferanceNum As Integer
    Dim retrievedTranID As Integer = 0
    Dim retrievedTranTypeID As Integer = 0
    Dim retrievedLocID As Integer = 0

    Dim calculatedTotalQty As Double = 0
    Dim calculatedTotalCost As Double = 0
    Dim retrievedTotalQty As Integer = 0
    Dim retrievedTotalPrice As Double = 0
    Dim retrievedUserItemID As String


    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

    Dim locationList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))

    Dim itemsList As List(Of KeyValuePair(Of String, String)) =
                      New List(Of KeyValuePair(Of String, String))

    Dim typeList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))

    Dim addedItemsIDList As List(Of KeyValuePair(Of String, String)) =
    New List(Of KeyValuePair(Of String, String))

    Dim cnt As Integer = 0
    Dim itemsExist As Boolean = False
    Dim toBeUpdated As Boolean = False


    Dim theItemID As Integer = 0
    Dim theItemName As String = String.Empty
    Dim theItemQuantity As Integer = 0
    Dim theItemUnitprice As Decimal = 0
    Dim theItemTotalPrice As Decimal = 0
    Dim databaseObject As New DatabaseAccesClass
    Dim selectedTransaction As Integer = My.Settings.selectedTransaction
    Dim fromAllTrans As Boolean = My.Settings.fromAllTrans

    Dim theCalculatedInventoryItemQty As Integer = 0
    Dim theCalculatedInventoryItemAvgPrice As Decimal = 0
    Dim theCalculatedInventoryItemTotalPrice As Decimal = 0

    Dim stockType As Boolean = True
    Dim stockText As String = String.Empty
    Dim calculatedAvgPrice As Decimal = 0
    Dim theTempWholeQuantity As Integer = 0
    Dim retrievedStockID As Integer = 0
    Dim updateComplete As Boolean = True

    '**********************************************

    Private Sub stockTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Font color and size of the gridview and groupBox
        GroupBox1.ForeColor = Color.DarkRed
        transactionData.Font = New Font("Gadugi", 7)
        stockTransaGrid.Font = New Font("Gadugi", 7)
        '************************************************'

        'Initializing fields
        allItemsQty.Text = "0"
        allItemsPrice.Text = "0"

        '''''''''''''''''''''''''''''''

        'Retrieving saved data from database
        generateIDS()
        getLocations()
        getTypes()
        ''''''''''''''''''''''''''''''''''''

        'Get all Transactions

        stockTransaGrid.DataSource = getStockTransa()
        stockTransaGrid.Columns(3).Width = 87
        stockTransaGrid.Columns(0).Visible = False
        stockTransaGrid.Columns(2).Visible = False
        stockTransaGrid.Columns(7).Visible = False



        '''''''''''''''''''''
        If fromAllTrans = True And selectedTransaction <> -1 Then
            retrieveTransItems(selectedTransaction)

            My.Settings.fromAllTrans = False
            My.Settings.selectedTransaction = -1
            My.Settings.Save()
        End If
        getUserItems()
    End Sub

    Private Sub getUserItems()

        addedItemsIDList.Clear()


        Dim dt As DataTable = New DataTable
        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_Item where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            addedItemsIDList.Add(New KeyValuePair(Of String, String)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ItemID").ToString()))

        Next

    End Sub

    Sub retrieveTransItems(selectedTransaction As Integer)

        locationDropBox.Enabled = False
        stockIn.Enabled = False
        stockOut.Enabled = False

        Dim i As Integer
        For j As Integer = 0 To stockTransaGrid.Rows.Count - 2
            If stockTransaGrid.Rows(j).Cells(7).Value = selectedTransaction Then
                i = j

            End If
        Next
        Dim selectedRow As DataGridViewRow
        Dim theID As Integer

        If (i >= 0 And i < stockTransaGrid.Rows.Count - 1) Then


            selectedRow = stockTransaGrid.Rows(i)


            referanceLabel.Text = selectedRow.Cells(0).Value.ToString()
            dateCreatedField.Value = selectedRow.Cells(6).Value.ToString()
            locationDropBox.Text = selectedRow.Cells(1).Value.ToString()

            stockType = selectedRow.Cells(2).Value.ToString()

            allItemsQty.Text = "0"
            allItemsPrice.Text = "0"

            'Assigning totals to the total Labels below the gridview
            Dim qty As String = selectedRow.Cells(4).Value.ToString()
            Dim currPrice As Decimal = selectedRow.Cells(5).Value.ToString()

            allItemsQty.Text = qty
            allItemsPrice.Text = currPrice

            theID = selectedRow.Cells(7).Value
            retrievedTranID = theID

            'Getting totals to use in some function
            calculatedTotalQty = selectedRow.Cells(4).Value
            calculatedTotalCost = selectedRow.Cells(5).Value
            '**************************************
            If stockType = True Then
                stockIn.Checked = True
                stockOut.Checked = False
            Else
                stockIn.Checked = False
                stockOut.Checked = True
            End If

            'Fill the transactiongrid view with the selected transaction Items
            fillTheTransactionItems(theID)
            'setting the toBeUpdated so items and the transactions could be updated after selecting some specific transaction
            toBeUpdated = True

        Else



            'clearFields()
        End If

    End Sub
    'Forcing some fields to only accept numbers

    Private Sub qtyField_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") _
         AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
    Private Sub priceField_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ChrW(8))
    End Sub

    'Generate referance Number
    Private Sub generateIDS()

        Dim genratedNum As Integer = random.Next(100, 1000)
        Dim secondGeneratedNum As Integer = random.Next(1, 10000)
        generatedReferanceNum = secondGeneratedNum * genratedNum
        referanceLabel.Text = "STK" + Convert.ToString(generatedReferanceNum)

    End Sub
    '****************************

    'get Availabe locations, Items and types
    Private Sub getLocations()

        locationDropBox.Items.Clear()
        locationList.Clear()



        Dim dt As DataTable = New DataTable


        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_location where Status = 1")
        For i = 0 To dt.Rows.Count - 1
            locationList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("Name").ToString(), dt.Rows(i)("ID").ToString()))

        Next


        autoCompleteLocations()
    End Sub

    Sub autoCompleteLocations()

        Dim dt As DataTable = New DataTable()


        dt = databaseObject.SelectMethode("Select Name from db_owner.tbl_location where Status = 1")
        Dim row As DataRow = dt.NewRow()

        dt.Rows.InsertAt(row, 0)


        locationDropBox.DataSource = dt
        locationDropBox.DisplayMember = "Name"
        locationDropBox.ValueMember = "Name"


        locationDropBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        locationDropBox.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    Private Sub getItems()

        checkEnteredIds()

        'inventoryNameField.Items.Clear()
        itemsList.Clear()


        Dim dt As New DataTable
        If stockOut.Checked = True Then
            dt = databaseObject.SelectMethode("Select ItemID, ItemName from db_owner.tbl_location_inventory where ( LocationID = '" & retrievedLocID & "' and ItemQty > 0 )")


            For i = 0 To dt.Rows.Count - 1
                If itemsList.Contains(New KeyValuePair(Of String, String)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ItemID").ToString())) Then
                    'Don't ADD
                Else

                    itemsList.Add(New KeyValuePair(Of String, String)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ItemID").ToString()))
                End If


            Next
        Else
            dt = databaseObject.SelectMethode("Select  DISTINCT ID, ItemName from db_owner.tbl_Item where Status = 1")


            For i = 0 To dt.Rows.Count - 1

                If itemsList.Contains(New KeyValuePair(Of String, String)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ID").ToString())) Then
                    'Don't ADD
                Else

                    itemsList.Add(New KeyValuePair(Of String, String)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ID").ToString()))
                End If


            Next
        End If


        autoCompleteItems()

    End Sub

    Sub autoCompleteItems()



        Dim dt As New DataTable
        If stockOut.Checked Then
            dt = databaseObject.SelectMethode("Select  DISTINCT ItemID, ItemName from db_owner.tbl_location_inventory 
            where ( LocationID = '" & retrievedLocID & "' and ItemQty > 0)")

        Else
            dt = databaseObject.SelectMethode("Select  DISTINCT ID, ItemName from db_owner.tbl_Item where Status = 1")

        End If

        Dim row As DataRow = dt.NewRow()
        dt.Rows.InsertAt(row, 0)
        inventoryNameField.DataSource = dt
        inventoryNameField.DisplayMember = "ItemName"
        inventoryNameField.ValueMember = "ItemName"

    End Sub

    Private Sub getTypes()

        typeList.Clear()


        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_transactionCode")
        For i = 0 To dt.Rows.Count - 1
            typeList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("TransactionName").ToString(), dt.Rows(i)("ID").ToString()))

        Next

    End Sub


    'fill the fields with available Transactions
    Function getStockTransa()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedTranTypeID = pair.Value

            End If
        Next
        Dim dt As New DataTable


        dt = databaseObject.SelectMethode("SELECT ReferanceNumber,
            LocationName as [Location],StockStatus,StockText as [Stock],TotalQty, TotalCost,DateCreated as [Date], ID
            FROM db_owner.tbl_transaction where (TransactionID = '" & retrievedTranTypeID & "' and Status = 1)")

        Return dt
    End Function




    'Check if selected Values are valid
    Sub checkEnteredIds()

        retrievedLocID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationList

            Dim key As String = pair.Key
            If key = locationDropBox.Text Then
                retrievedLocID = pair.Value
            End If
        Next



    End Sub

    'Initialize all fields
    Sub clearFields()

        generateIDS()
        locationDropBox.Text = ""
        dateCreatedField.Value = today
        transactionData.Rows.Clear()
        allItemsPrice.Text = 0
        allItemsQty.Text = 0

    End Sub

    'Delete Transaction if it doesn't have items
    Sub deleteEmptyTransaction()

        Console.WriteLine("DELETING")
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()


        Try

            conn.Open()

            myCommand.CommandText = "Delete From db_owner.tbl_transaction where (ID = '" & retrievedTranID & "')"

            rows = myCommand.ExecuteNonQuery()



        Catch ex As SqlException


            ' handle error
            Console.Write("Unable to Delete")


        Finally
            clearFields()


            conn.Close()

            updateTransactions()

            stockTransaGrid.DataSource = getStockTransa()

            stockTransaGrid.Columns(3).Width = 87

            stockTransaGrid.Columns(0).Visible = False
            stockTransaGrid.Columns(2).Visible = False
            stockTransaGrid.Columns(7).Visible = False

        End Try
    End Sub

    'Update the Transaction after editing in Items 
    Sub updateTransactions()


        Dim referanceNumToBeDeleted As String = referanceLabel.Text
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_transaction Set TotalQty = '" & allItemsQty.Text & "', TotalCost = '" & allItemsPrice.Text & "', 
              where (ID = '" & retrievedTranID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Add")

        Finally

            conn.Close()

        End Try


    End Sub

    'Change StockType after radio btns checked
    Private Sub stockIn_CheckedChanged(sender As Object, e As EventArgs) Handles stockIn.CheckedChanged
        stockType = True
    End Sub

    Private Sub stockOut_CheckedChanged(sender As Object, e As EventArgs) Handles stockOut.CheckedChanged
        stockType = False
        'Get Items if stock Out
        getItems()
    End Sub
    '*************************************

    'Get LocationID after selecting a Location
    Private Sub locationDropBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles locationDropBox.SelectedIndexChanged
        retrievedLocID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationList

            Dim key As String = pair.Key
            If key = locationDropBox.Text Then
                retrievedLocID = pair.Value
            End If
        Next
        getItems()


    End Sub
    '*****************************************

    'Search BTn Clicked
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        stockTransaGrid.DataSource = getSearchedStockTransa()

        stockTransaGrid.Columns(0).Visible = False
        stockTransaGrid.Columns(3).Visible = False
        stockTransaGrid.Columns(7).Visible = False
    End Sub
    '***************************

    'Retrieved Data according to searched Fields
    Function getSearchedStockTransa()


        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedTranTypeID = pair.Value

            End If
        Next



        Dim dt As New DataTable

        dt = databaseObject.SelectMethode("Select ReferanceNumber,
            DateCreated as [Date], LocationName As [Location], StockStatus, StockText As [Stock], TotalQty, TotalCost, ID
            From db_owner.tbl_transaction Where (TransactionID = '" & retrievedTranTypeID & "' and LocationName LIKE '%" & searchLocation.Text & "%' and Status = 1) ")


        Return dt
    End Function
    '********************************************

    'On searchLocation textChange
    Private Sub searchLocation_TextChanged(sender As Object, e As EventArgs) Handles searchLocation.TextChanged

        stockTransaGrid.DataSource = getSearchedStockTransa()
        stockTransaGrid.Columns(0).Visible = False
        stockTransaGrid.Columns(3).Visible = False
        stockTransaGrid.Columns(7).Visible = False

    End Sub
    '************************************

    'The search function while date is changed
    Function getSearchedStockTransaWithDate()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedTranTypeID = pair.Value

            End If
        Next

        Dim dt As New DataTable

        dt = databaseObject.SelectMethode("Select ReferanceNumber,
            DateCreated as [Date], LocationName As [Location], StockStatus, StockText As [Stock], TotalQty, TotalCost, ID
            From db_owner.tbl_transaction Where (TransactionID = '" & retrievedTranTypeID & "'
            and DateCreated = '" & searchDate.Value & "' and Status = 1)")

        Return dt

    End Function
    '************************************

    'On searchDate change
    Private Sub searchDate_ValueChanged(sender As Object, e As EventArgs) Handles searchDate.ValueChanged

        stockTransaGrid.DataSource = getSearchedStockTransaWithDate()
        stockTransaGrid.Columns(0).Visible = False
        stockTransaGrid.Columns(3).Visible = False
        stockTransaGrid.Columns(7).Visible = False

    End Sub
    '************************************

    'cancel the search, initialize fields and gridView
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        stockTransaGrid.DataSource = getStockTransa()
        stockTransaGrid.Columns(3).Width = 87
        stockTransaGrid.Columns(0).Visible = False
        stockTransaGrid.Columns(2).Visible = False
        stockTransaGrid.Columns(7).Visible = False

        searchLocation.Text = String.Empty

    End Sub
    '************************************

    'Fill Form OnStock cell Click
    Private Sub stockTransaGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles stockTransaGrid.CellClick
        locationDropBox.Enabled = False
        stockIn.Enabled = False
        stockOut.Enabled = False
        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        Dim theID As Integer

        If (i >= 0 And i < stockTransaGrid.Rows.Count - 1) Then


            selectedRow = stockTransaGrid.Rows(i)

            referanceLabel.Text = selectedRow.Cells(0).Value.ToString()
            dateCreatedField.Value = selectedRow.Cells(6).Value.ToString()
            locationDropBox.Text = selectedRow.Cells(1).Value.ToString()

            stockType = selectedRow.Cells(2).Value.ToString()

            allItemsQty.Text = "0"
            allItemsPrice.Text = "0"

            'Assigning totals to the total Labels below the gridview
            Dim qty As String = selectedRow.Cells(4).Value.ToString()
            Dim currPrice As Decimal = selectedRow.Cells(5).Value.ToString()

            allItemsQty.Text = qty
            allItemsPrice.Text = Math.Round(currPrice, 2)

            theID = selectedRow.Cells(7).Value
            retrievedTranID = theID

            'Getting totals to use in some function
            calculatedTotalQty = selectedRow.Cells(4).Value
            calculatedTotalCost = selectedRow.Cells(5).Value
            '**************************************
            If stockType = True Then
                stockIn.Checked = True
                stockOut.Checked = False
            Else
                stockIn.Checked = False
                stockOut.Checked = True
            End If

            'Fill the transactiongrid view with the selected transaction Items
            fillTheTransactionItems(theID)
            'setting the toBeUpdated so items and the transactions could be updated after selecting some specific transaction
            toBeUpdated = True

            transactionData.Columns(2).ReadOnly = True
            transactionData.Rows(transactionData.Rows.Count - 1).Cells(2).ReadOnly = False

        Else

            'clearFields()
        End If
    End Sub

    'Fill the transactiongrid view with the selected transaction Items
    Sub fillTheTransactionItems(theID)

        'Get the TransactionID and the totals from the ReferanceNumber
        transactionData.Rows.Clear()

        Dim dt As DataTable = New DataTable

        'dt = databaseObject.SelectMethode("Select * from db_owner.tbl_transactioned_items where (TransactionID = '" & theID & "' and Status = 1)")
        dt = databaseObject.SelectMethode("Select  db_owner.tbl_Item.ItemID as [itemID],db_owner.tbl_transactioned_items.ItemName as [ItemNAme] ,db_owner.tbl_transactioned_items.Quantity as [Qty],
                        db_owner.tbl_transactioned_items.UnitAvgCost as [uAvgCost], db_owner.tbl_transactioned_items.TotalCost as [tCost],
                        db_owner.tbl_transactioned_items.ItemID as [theID] from db_owner.tbl_transactioned_items, db_owner.tbl_Item 
                        where (db_owner.tbl_transactioned_items.TransactionID = '" & theID & "' and db_owner.tbl_transactioned_items.ItemID = db_owner.tbl_Item.ID)")

        For i = 0 To dt.Rows.Count - 1

            transactionData.Rows.Add(New String() {Nothing, dt.Rows(i)("itemID").ToString(), dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("Qty").ToString(),
                    Math.Round(dt.Rows(i)("uAvgCost"), 2), Math.Round(dt.Rows(i)("tCost"), 2), Nothing, dt.Rows(i)("theID").ToString()})

        Next

    End Sub
    '*******************************************************

    Sub updateTheTransaction()

        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_transaction where (ReferanceNumber = '" & referanceLabel.Text & "' and Status = 1)")

        If dt.Rows.Count > 0 Then


            retrievedTranID = dt.Rows(0)("ID").ToString()

            'Check for excess or missing qtys of some items 
            getQtyAndItemIDToUpdate(retrievedTranID)

            'Check If Qty is Available in the Selected Location

            Dim theLocID As Integer = 0
            Dim theLocationName As String = String.Empty

            Dim userItemID As Integer = 0
            Dim InventoryLocationItemQty As Integer = 0
            Dim userItemQty As Integer = 0
            Dim userItemName As String = String.Empty

            retrievedStockID = 0
            For Each pair As KeyValuePair(Of String, Integer) In typeList

                Dim key As String = pair.Key
                If key.Contains("St") Or key.Contains("st") Then
                    retrievedStockID = pair.Value
                End If
            Next
            theLocID = retrievedLocID
            theLocationName = locationDropBox.Text
            'If stockType = True Then
            '    theLocID = retrievedLocID
            '    theLocationName = locationDropBox.Text

            'ElseIf stockType = False Then
            '    theLocID = retrievedStockID
            '    theLocationName = "Stock"

            'End If

            If stockType = False Then



                For i As Integer = 0 To transactionData.Rows.Count - 2
                    If transactionData.Rows(i).Cells(7).Value <> Nothing Then

                        userItemID = transactionData.Rows(i).Cells(7).Value
                        userItemQty = transactionData.Rows(i).Cells(3).Value
                        userItemName = transactionData.Rows(i).Cells(2).Value
                        Dim preTrDt As New DataTable
                        preTrDt = databaseObject.SelectMethode("Select Quantity from db_owner.tbl_transactioned_items where (ItemID = '" & userItemID & "' 
                      and TransactionID = '" & retrievedTranID & "' and Status)")

                        Dim lDt As New DataTable
                        lDt = databaseObject.SelectMethode("Select ItemQty from db_owner.tbl_location_inventory where( LocationID = '" & theLocID & "' and ItemID = '" & userItemID & "')")

                        If preTrDt.Rows.Count > 0 Then
                            InventoryLocationItemQty = preTrDt.Rows(0)("Quantity") + lDt.Rows(0)("ItemQty")


                            If InventoryLocationItemQty < userItemQty Then
                                MessageBox.Show("The quantity entered for " & userItemName & " exceeds the available in " & theLocationName)
                                updateComplete = False
                                Exit Sub

                            End If
                        Else

                            userItemID = transactionData.Rows(i).Cells(7).Value
                            userItemQty = transactionData.Rows(i).Cells(3).Value
                            userItemName = transactionData.Rows(i).Cells(2).Value


                            InventoryLocationItemQty = lDt.Rows(0)("ItemQty")
                            If InventoryLocationItemQty < userItemQty Then
                                MessageBox.Show("The quantity entered for " & userItemName & " exceeds the available in " & theLocationName)
                                updateComplete = False
                                Exit Sub

                            End If



                        End If
                    End If
                Next
            End If


            '**************************************************'
            '    'Get the TransactionID and the totals from the ReferanceNumber

            Dim dt2 As DataTable = New DataTable
            Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()

            Try

                conn.Open()

                myCommand.CommandText = "Update db_owner.tbl_transaction Set
            TotalQty = '" & allItemsQty.Text & "', TotalCost = '" & allItemsPrice.Text & "',
            RevisionUserID = '" & logedInUserID & "',RevisionDate = '" & today & "',
            DateCreated = '" & dateCreatedField.Value & "' where (ID = '" & retrievedTranID & "')"

                rows = myCommand.ExecuteNonQuery()

            Catch ex As SqlException

                ' handle error
                Console.Write("Unable to Add")

            Finally

                conn.Close()

            End Try

            'Insert the Items in the Selected TRansaction
            insertIntoItems()
        End If
    End Sub

    'function for Updating Transaction Items and Location Inventory
    Sub getQtyAndItemIDToUpdate(retrievedTranID)

        Dim dt As New DataTable
        Dim theItemQty As Integer = 0
        Dim theItemID As Integer = 0
        Dim theTranID As String = ""
        Dim theItemAvgPrice As Decimal = 0
        Dim oldItem As Boolean = False
        Dim itemIndex As Integer = -1
        Dim itemToBeCheckedFound As Boolean = False


        dt = databaseObject.SelectMethode("Select Quantity , ItemID, TransactionID, UnitAvgCost 
                            From db_owner.tbl_transactioned_Items Where (db_owner.tbl_transactioned_Items.TransactionID = '" & retrievedTranID & "' and Status = 1)")


        For l = 0 To dt.Rows.Count - 2

            itemToBeCheckedFound = False
            Dim itemIdToBeCheckedValue = dt.Rows(l)("ItemID").ToString()
            Dim itemToBeCheckedQty = dt.Rows(l)("Quantity").ToString()
            Dim itemToBeCheckedUnitPrice = dt.Rows(l)("UnitAvgCost").ToString()

            'Check if transaction  
            For j As Integer = 0 To transactionData.Rows.Count - 2
                If itemIdToBeCheckedValue = transactionData.Rows(j).Cells(7).Value.ToString() Then
                    itemToBeCheckedFound = True
                    Exit For
                End If
            Next

            If itemToBeCheckedFound = False Then

                deleteTheNotFoundItem(itemIdToBeCheckedValue, retrievedTranID, itemToBeCheckedQty, itemToBeCheckedUnitPrice)
            End If
        Next

    End Sub


    Sub deleteTheNotFoundItem(theItemID, retrievedTranID, itemToBeCheckedQty, itemToBeCheckedUnitPrice)

        'Update the location Inventory from Stock or out of Stock after removing some Items
        retrievedStockID = 0
        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedStockID = pair.Value
            End If
        Next

        Dim theLocID As Integer = retrievedLocID
        Dim theLocationName As String = locationDropBox.Text

        Dim invDt As New DataTable

        Dim orignalItemQty As Integer = 0
        Dim originalTotalPrice As Decimal = 0
        Dim totalCostInItem As Decimal = 0

        ' Get the current QTY of items from the location_inventory
        invDt = databaseObject.SelectMethode("Select ItemQty,ItemAvgPrice from db_owner.tbl_location_inventory where ( itemID = '" & theItemID & "'
        and LocationID = '" & theLocID & "')")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Add the previous qty and calculate the new total of item to the current qty in the location_inventory
        If invDt.Rows.Count > 0 Then


            orignalItemQty = invDt.Rows(0)("ItemQty").ToString
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' Update the qty and the total of item in the location_inventory
            Dim newlItemQty As Integer = orignalItemQty - itemToBeCheckedQty
            Dim newTotalPrice As Decimal = (newlItemQty * invDt.Rows(0)("ItemAvgPrice").ToString)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''Update the location_inventory of the LOCATIONOUT with the new QTYs and Total
            Dim conn3 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
            Dim rows3 As Integer
            Dim myCommand3 As SqlCommand = conn3.CreateCommand()

            Try

                conn3.Open()

                myCommand3.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & newlItemQty & "'
                , itemTotalPrice = '" & newTotalPrice & "' where (LocationID = '" & theLocID & "'
                and ItemID = '" & theItemID & "')"

                rows3 = myCommand3.ExecuteNonQuery()

            Catch ex As SqlException

                '    ' handle error
                Console.Write("Unable to Add")

            Finally

                conn3.Close()

            End Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            ''If stockType = True Then
            ''    theLocID = retrievedStockID

            ''ElseIf stockType = False Then
            'theLocID = retrievedLocID

            ''End If
            'Dim invDt2 As New DataTable
            'orignalItemQty = 0
            'originalTotalPrice = 0
            'totalCostInItem = 0

            '' Get the current QTY of items from the location_inventory
            'invDt2 = databaseObject.SelectMethode("Select ItemQty,ItemAvgPrice from db_owner.tbl_location_inventory where ( itemID = '" & theItemID & "'
            'and LocationID = '" & theLocID & "')")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''Add the previous qty and calculate the new total of item to the current qty in the location_inventory
            'orignalItemQty = invDt2.Rows(0)("ItemQty").ToString
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '' Update the qty and the total of item in the location_inventory
            'newlItemQty = orignalItemQty - itemToBeCheckedQty
            'newTotalPrice = (newlItemQty * invDt.Rows(0)("ItemAvgPrice").ToString)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''Update the location_inventory of the LOCATIONOUT with the new QTYs and Total
            'Dim conn4 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
            'Dim rows4 As Integer
            'Dim myCommand4 As SqlCommand = conn4.CreateCommand()

            'Try

            '    conn4.Open()

            '    myCommand4.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & newlItemQty & "'
            '        , itemTotalPrice = '" & newTotalPrice & "' where (LocationID = '" & theLocID & "'
            '        and ItemID = '" & theItemID & "')"

            '    rows4 = myCommand4.ExecuteNonQuery()

            'Catch ex As SqlException

            '    '    ' handle error
            '    Console.Write("Unable to Add")

            'Finally

            '    conn4.Close()

            'End Try


            Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()


            Try

                conn.Open()

                myCommand.CommandText = "Delete From db_owner.tbl_transactioned_items where (TransactionID = '" & retrievedTranID & "' and ItemID = '" & theItemID & "')"

                rows = myCommand.ExecuteNonQuery()



            Catch ex As SqlException


                ' handle error
                Console.Write("Unable to Delete")


            Finally
                clearFields()


                conn.Close()

            End Try

        End If


    End Sub

    'Update the Inventory Location after items change, Get Qtys of already added Items, and new items qty...
    Sub reduceTheItemInventoryQuantities()

        Dim itemIDToReduce As Integer = 0
        Dim itemQtyToReduce As Integer = 0
        Dim itemUnitPriceToReduce As Decimal = 0
        Dim itemTotalPriceToReduce As Decimal = 0
        Dim itemLocationIDToReduce As Integer = 0

        Dim fDt As New DataTable
        fDt = databaseObject.SelectMethode("Select tbl_transactioned_Items.ItemID, tbl_transactioned_Items.ItemName, tbl_transactioned_Items.Quantity,
        tbl_transactioned_Items.UnitAvgCost,tbl_transactioned_Items.TotalCost
        from db_owner.tbl_transactioned_Items
        where(tbl_transactioned_Items.TransactionID = '" & retrievedTranID & "' and Status = 1)")

        retrievedStockID = 0
        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedStockID = pair.Value
            End If
        Next

        Dim theLocID As Integer = 0
        Dim theLocationName As String = ""

        If stockType = True Then
            theLocID = retrievedLocID

        ElseIf stockType = False Then
            theLocID = retrievedStockID

        End If
        For i As Integer = 0 To fDt.Rows.Count - 1

            Dim tempName = fDt.Rows(i)("ItemName").ToString
            itemIDToReduce = fDt.Rows(i)("ItemID").ToString
            itemQtyToReduce = fDt.Rows(i)("Quantity").ToString
            itemUnitPriceToReduce = fDt.Rows(i)("UnitAvgCost").ToString
            itemTotalPriceToReduce = fDt.Rows(i)("TotalCost").ToString

            itemLocationIDToReduce = theLocID

            Dim sDt As New DataTable
            sDt = databaseObject.SelectMethode("Select ItemID, ItemQty, ItemAvgPrice, ItemTotalPrice 
            from db_owner.tbl_location_inventory where ( ItemID = '" & itemIDToReduce & "' and LocationID = '" & itemLocationIDToReduce & "')")

            theItemID = itemIDToReduce

            theCalculatedInventoryItemQty = (sDt.Rows(0)("ItemQty").ToString - itemQtyToReduce)
            If theCalculatedInventoryItemQty = 0 Then

                theCalculatedInventoryItemAvgPrice = itemUnitPriceToReduce


            ElseIf theCalculatedInventoryItemQty <> 0 Then
                theCalculatedInventoryItemAvgPrice = (sDt.Rows(0)("ItemAvgPrice").ToString + itemUnitPriceToReduce) / 2
            End If

            theCalculatedInventoryItemTotalPrice = (theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice)
            'Update the Items' Qtys in the location Inventory of that Transaction
            updateLocationInventory()
        Next

    End Sub

    'Function for Updating the Items' Qtys in the location Inventory of that Transaction
    Sub updateLocationInventory()

        retrievedStockID = 0

        For Each pair As KeyValuePair(Of String, Integer) In typeList
            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedStockID = pair.Value
            End If
        Next

        Dim theLocID As Integer = 0
        Dim theLocationName As String = locationDropBox.Text
        theLocID = retrievedLocID



        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & theCalculatedInventoryItemQty & "',
            ItemAvgPrice = '" & theCalculatedInventoryItemAvgPrice & "', ItemTotalPrice = '" & theCalculatedInventoryItemTotalPrice & "', LocationID = '" & theLocID & "',
            LocationName = '" & theLocationName & "' where(ItemID = '" & theItemID & "' and LocationID = '" & theLocID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try
    End Sub

    'Function for Inserting The Items in the transaction
    Private Sub insertIntoItems()
        'Get the TransactionID and the totals from the ReferanceNumber
        Dim isOldItem As Boolean = False
        Dim dt As DataTable = New DataTable
        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_transaction where (ReferanceNumber = '" & referanceLabel.Text & "' and Status = 1 )")

        If dt.Rows.Count > 0 Then
            retrievedTranID = dt.Rows(0)("ID").ToString()
            retrievedTotalQty = dt.Rows(0)("TotalQty")
            retrievedTotalPrice = dt.Rows(0)("TotalCost")
        End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''


        'Delete the transaction if it has no Items
        If transactionData.Rows.Count = 1 Then
            deleteEmptyTransaction()
            Exit Sub
        End If
        '******************************************

        'Check if the Added Item is added new from Update 
        For i As Integer = 0 To transactionData.Rows.Count - 2
            If transactionData.Rows(i).Cells(7).Value.ToString <> Nothing Then


                isOldItem = False

                theItemID = transactionData.Rows(i).Cells(7).Value
                theItemName = transactionData.Rows(i).Cells(2).Value
                theItemQuantity = transactionData.Rows(i).Cells(3).Value
                theItemUnitprice = transactionData.Rows(i).Cells(4).Value
                theItemTotalPrice = transactionData.Rows(i).Cells(5).Value

                retrievedStockID = 0

                For Each pair As KeyValuePair(Of String, Integer) In typeList

                    Dim key As String = pair.Key
                    If key.Contains("St") Or key.Contains("st") Then
                        retrievedStockID = pair.Value
                    End If
                Next

                Dim theLocID As Integer = 0
                Dim theLocationName As String = ""

                theLocID = retrievedLocID
                theLocationName = locationDropBox.Text


                'Check if the added item is already added to the inventory in the specified Location

                Dim sDt As New DataTable
                sDt = databaseObject.SelectMethode("Select ItemQty, ItemAvgPrice, ItemTotalPrice, LocationID, ItemID 
                                               From db_owner.tbl_location_inventory 
                                               Where (LocationID ='" & theLocID &
                                               "' And ItemID = '" & theItemID & "')")

                Dim theNewQty As Integer
                'If Item is not added to the specific location we add it, else it is updated
                If sDt.Rows.Count = 0 Then
                    addToTheInventory()
                Else

                    Dim preTransQty As New DataTable
                    preTransQty = databaseObject.SelectMethode("Select Quantity from db_owner.tbl_transactioned_items 
                          where ( TransactionID = '" & retrievedTranID & "' and ItemID = '" & theItemID & "' and Status = 1)")

                    Dim thePrevTransQty As Integer = 0
                    If preTransQty.Rows.Count > 0 Then

                        isOldItem = True
                        thePrevTransQty = preTransQty.Rows(0)("Quantity")

                    End If

                    ' thePrevTransQty
                    theCalculatedInventoryItemQty = 0
                    theCalculatedInventoryItemAvgPrice = 0
                    theCalculatedInventoryItemTotalPrice = 0

                    If toBeUpdated = False Then
                        If stockType = False Then

                            theNewQty = sDt.Rows(0)("ItemQty").ToString() - theItemQuantity
                            theCalculatedInventoryItemQty = theNewQty

                        ElseIf stockType = True Then

                            theNewQty = sDt.Rows(0)("ItemQty").ToString() + theItemQuantity
                            theCalculatedInventoryItemQty = theNewQty


                        End If



                    Else


                        If stockType = False Then
                            theNewQty = sDt.Rows(0)("ItemQty").ToString() + thePrevTransQty
                            theCalculatedInventoryItemQty = theNewQty - theItemQuantity
                        ElseIf stockType = True Then
                            theNewQty = sDt.Rows(0)("ItemQty").ToString() - thePrevTransQty
                            theCalculatedInventoryItemQty = theNewQty + theItemQuantity
                        End If


                    End If

                    theCalculatedInventoryItemAvgPrice = theItemUnitprice '(sDt.Rows(0)("ItemAvgPrice").ToString() + theItemUnitprice) / 2
                    theCalculatedInventoryItemTotalPrice = theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice

                    updateLocationInventory()


                End If

                'If stockType = True Then
                '    theLocID = retrievedLocID

                'ElseIf stockType = False Then
                '    theLocID = retrievedStockID

                'End If

                'theCalculatedInventoryItemQty = 0
                'theCalculatedInventoryItemAvgPrice = 0
                'theCalculatedInventoryItemTotalPrice = 0

                ''Update the Item Qty if its changed in the tbl_transactioned_items
                'Dim preTransQty2 As New DataTable
                'preTransQty2 = databaseObject.SelectMethode("Select Quantity from db_owner.tbl_transactioned_items 
                '              where ( TransactionID = '" & retrievedTranID & "' and ItemID = '" & theItemID & "')")

                'Dim thePrevTransQty2 As Integer = 0
                'If preTransQty2.Rows.Count > 0 Then
                '    thePrevTransQty2 = preTransQty2.Rows(0)("Quantity")
                'End If



                'Dim sDt2 As New DataTable
                'sDt2 = databaseObject.SelectMethode("Select ItemQty, ItemAvgPrice, ItemTotalPrice, LocationID, ItemID 
                '                                   From db_owner.tbl_location_inventory 
                '                                   Where (LocationID ='" & theLocID &
                '                                   "' And ItemID = '" & theItemID & "')")

                'theNewQty = sDt2.Rows(0)("ItemQty").ToString() + thePrevTransQty2
                'theCalculatedInventoryItemQty = theNewQty - theItemQuantity
                'theCalculatedInventoryItemAvgPrice = sDt2.Rows(0)("ItemAvgPrice").ToString()
                'theCalculatedInventoryItemTotalPrice = theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice

                'updateTheOutLocation(theLocID)

                'If transaction is being updated
                If toBeUpdated = True And isOldItem = True Then
                    Dim rows As Integer
                    Dim myCommand As SqlCommand = conn.CreateCommand()

                    Try

                        conn.Open()

                        myCommand.CommandText = "Update db_owner.tbl_transactioned_items Set ItemID = '" & theItemID & "',
                    ItemName = '" & theItemName & "', Quantity = '" & theItemQuantity & "', UnitAvgCost = '" & theItemUnitprice & "'
                    ,TotalCost = '" & theItemTotalPrice & "' where(ItemID = '" & theItemID & "' and TransactionID = '" & retrievedTranID & "')"
                        rows = myCommand.ExecuteNonQuery()

                    Catch ex As SqlException

                        ' handle error
                        MessageBox.Show(ex.Message)

                    Finally

                        conn.Close()

                    End Try
                    '***********************************

                    'If Items are being added as new
                Else
                    Dim query As String = String.Empty
                    query &= "INSERT INTO db_owner.tbl_transactioned_items (TransactionID,ItemID,ItemName,Quantity,"
                    query &= "UnitAvgCost,TotalCost,TransactionName,Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
                    query &= "VALUES (@TransactionID, @ItemID, @ItemName,@Quantity, @UnitAvgCost, @TotalCost,"
                    query &= "@TransactionName, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

                    Using comm As New SqlCommand()
                        With comm
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = query
                            .Parameters.AddWithValue("@TransactionID", retrievedTranID)
                            .Parameters.AddWithValue("@ItemID", theItemID)
                            .Parameters.AddWithValue("@ItemName", theItemName)
                            .Parameters.AddWithValue("@Quantity", theItemQuantity)
                            .Parameters.AddWithValue("@UnitAvgCost", theItemUnitprice)
                            .Parameters.AddWithValue("@TotalCost", theItemTotalPrice)
                            .Parameters.AddWithValue("@TransactionName", "Stock")
                            .Parameters.AddWithValue("@Status", 1)
                            .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                            .Parameters.AddWithValue("@CreateDate", today)
                            .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                            .Parameters.AddWithValue("@RevisionDate", today)
                        End With

                        conn.Open()
                        comm.ExecuteNonQuery()
                        conn.Close()


                    End Using



                End If
                '***********************************************************************


            End If

        Next


        'Update the transaction after adding, deleting, and updating its Items
        updateTransactions()
        clearFields()


        stockTransaGrid.DataSource = getStockTransa()

        stockTransaGrid.Columns(3).Width = 87

        stockTransaGrid.Columns(0).Visible = False
        stockTransaGrid.Columns(2).Visible = False
        stockTransaGrid.Columns(7).Visible = False




    End Sub

    'Update the LocationInventory after change in the Items
    Sub updateTheOutLocation(theLocID)




        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & theCalculatedInventoryItemQty & "',
            ItemAvgPrice = '" & theCalculatedInventoryItemAvgPrice & "', ItemTotalPrice = '" & theCalculatedInventoryItemTotalPrice & "', LocationID = '" & theLocID & "'
            where(ItemID = '" & theItemID & "' and LocationID = '" & theLocID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try
    End Sub
    '******************************************************

    'function for adding new Items to the Inventory
    Sub addToTheInventory()

        Dim theLocID As Integer = 0
        Dim theLocationName As String = ""

        retrievedStockID = 0
        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedStockID = pair.Value
            End If
        Next


        theLocID = retrievedLocID
        theLocationName = locationDropBox.Text


        Using conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            Dim query As String = String.Empty
            query &= "INSERT INTO db_owner.tbl_location_inventory (LocationID,LocationName,ItemID,ItemName,"
            query &= "ItemQty,ItemAvgPrice,ItemTotalPrice)"
            query &= "VALUES (@LocationID, @LocationName, @ItemID,@ItemName, @ItemQty, @ItemAvgPrice, @ItemTotalPrice)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@LocationID", theLocID)
                    .Parameters.AddWithValue("@LocationName", theLocationName)
                    .Parameters.AddWithValue("@ItemID", theItemID)
                    .Parameters.AddWithValue("@ItemName", theItemName)
                    .Parameters.AddWithValue("@ItemQty", theItemQuantity)
                    .Parameters.AddWithValue("@ItemAvgPrice", theItemUnitprice)
                    .Parameters.AddWithValue("@ItemTotalPrice", theItemTotalPrice)
                End With

                conn.Open()
                comm.ExecuteNonQuery()
                conn.Close()


            End Using



        End Using
    End Sub
    '*********************************************


    'on Items'Name GridView textChange
    Private Sub inventoryNameField_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim combo As ComboBox = CType(sender, ComboBox)
        transactionData.CurrentRow.Cells(2).Value = combo.SelectedValue

        retrievedItemID = 0

        For Each pair As KeyValuePair(Of String, String) In itemsList

            Dim key As String = pair.Key
            If key = transactionData.CurrentRow.Cells(2).Value.ToString Then
                retrievedItemID = pair.Value
            End If

        Next
        transactionData.CurrentRow.Cells(7).Value = retrievedItemID

        If retrievedItemID <> 0 Then

            'If stockType = False Then
            getAvgPrice(retrievedItemID)

            'End If

            transactionData.CurrentRow.Cells(4).Value = calculatedAvgPrice
        End If

        Dim j As Integer
        For j = 0 To transactionData.Rows.Count - 1
            For Each pair As KeyValuePair(Of String, String) In addedItemsIDList

                Dim key As String = pair.Key
                If key = transactionData.Rows(j).Cells(2).Value.ToString Then
                    retrievedUserItemID = pair.Value
                End If
            Next

            transactionData.Rows(j).Cells(1).Value = retrievedUserItemID
        Next

    End Sub

    Private Sub transactionData_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles transactionData.EditingControlShowing

        If transactionData.CurrentCell.RowIndex <> -1 Then

            If transactionData.CurrentCell.ColumnIndex = 2 Then
                Dim combo As ComboBox = CType(e.Control, ComboBox)
                If (combo IsNot Nothing) Then

                    RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf inventoryNameField_SelectionChangeCommitted)
                    ' Add the event handler. 
                    AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf inventoryNameField_SelectionChangeCommitted)

                End If

            End If

            If transactionData.CurrentCell.ColumnIndex = 4 Or transactionData.CurrentCell.ColumnIndex = 5 Then

                Dim priceTextBox As TextBox = e.Control
                If (priceTextBox IsNot Nothing) Then
                    RemoveHandler priceTextBox.TextChanged, New EventHandler(AddressOf price_CheckforDecimal)
                    AddHandler priceTextBox.TextChanged, New EventHandler(AddressOf price_CheckforDecimal)
                End If

                Dim textBox As TextBox = e.Control
                RemoveHandler textBox.KeyPress, New KeyPressEventHandler(AddressOf priceField_KeyPress)
                AddHandler textBox.KeyPress, New KeyPressEventHandler(AddressOf priceField_KeyPress)




            End If
            If transactionData.CurrentCell.ColumnIndex = 4 Then


                Dim qtyField As TextBox = e.Control
                ' If (qtyField IsNot Nothing) Then
                RemoveHandler qtyField.PreviewKeyDown, New PreviewKeyDownEventHandler(AddressOf totalPrice_PreviewKeyDown)
                AddHandler qtyField.PreviewKeyDown, New PreviewKeyDownEventHandler(AddressOf totalPrice_PreviewKeyDown)
                'RemoveHandler qtyField.TextChanged, New EventHandler(AddressOf updatePrices)
                'AddHandler qtyField.TextChanged, New EventHandler(AddressOf updatePrices)
                'End If


            End If
        End If


    End Sub


    Private Sub totalPrice_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)

        Dim textBox As TextBox = CType(sender, TextBox)
        Dim updatedUnitPrice As Decimal
        Dim alreadyAdded As Boolean

        Dim updatedQty As Integer = 0
        If textBox.Text <> String.Empty And transactionData.CurrentRow.Cells(7).Value <> Nothing Then

            For i As Integer = 0 To transactionData.Rows.Count - 1

                If transactionData.Rows(i).Cells(7).Value = Nothing Then
                    alreadyAdded = True
                End If

            Next

            Dim transactionTotalQuantity As Integer = 0
            Dim transactionTotalPrice As Decimal = 0
            Dim currentItemID As Integer = 0


            Dim updatedTotalPrice As Decimal = 0
            Dim currentIndex As Integer = -1
            Dim foundItem As Boolean = False




            If e.KeyCode = Keys.Tab Then

                updatedQty = transactionData.CurrentRow.Cells(3).Value
                transactionData.CurrentRow.Cells(5).Value = textBox.Text * transactionData.CurrentRow.Cells(3).Value
                currentItemID = transactionData.CurrentRow.Cells(7).Value
                updatedUnitPrice = textBox.Text
                updatedTotalPrice = transactionData.CurrentRow.Cells(5).Value
                currentIndex = transactionData.CurrentRow.Index

                'MessageBox.Show(" BEFORE UPDATE : QTY " & updatedQty & " Total " & updatedTotalPrice & " UnitPrice " & updatedUnitPrice)

                For i As Integer = 0 To transactionData.Rows.Count - 2
                    If transactionData.Rows(i).Cells(7).Value.ToString <> Nothing Then

                        If currentItemID = transactionData.Rows(i).Cells(7).Value And currentIndex <> i Then



                            transactionData.Rows(i).Cells(3).Value += updatedQty
                            updatedQty = transactionData.Rows(i).Cells(3).Value

                            'transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(4).Value * transactionData.Rows(i).Cells(3).Value
                            updatedTotalPrice = transactionData.Rows(i).Cells(5).Value + updatedTotalPrice
                            transactionData.Rows(i).Cells(5).Value = (Math.Round((transactionData.Rows(i).Cells(5).Value), 2)).ToString

                            'transactionData.Rows(i).Cells(4).Value = (transactionData.Rows(i).Cells(4).Value + updatedUnitPrice) / 2
                            'transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(3).Value * transactionData.Rows(i).Cells(4).Value

                            updatedQty = transactionData.Rows(i).Cells(4).Value + updatedQty
                            updatedUnitPrice = updatedTotalPrice / (updatedQty - 1)

                            transactionData.Rows(i).Cells(4).Value = updatedUnitPrice
                            transactionData.Rows(i).Cells(4).Value = (Math.Round((transactionData.Rows(i).Cells(4).Value), 2)).ToString
                            transactionData.Rows(i).Cells(5).Value = updatedTotalPrice





                            foundItem = True
                        End If

                    End If

                Next
                If foundItem = True Then
                    transactionData.Rows.RemoveAt(currentIndex)

                End If

                If alreadyAdded = False Then
                    transactionData.Rows.Add("", "", "", Nothing, Nothing, Nothing, "")
                End If


            End If
        End If

        allItemsQty.Text = String.Empty
        allItemsPrice.Text = String.Empty


        Dim totQty As Integer = 0
        Dim totPrice As Decimal = 0

        For i As Integer = 0 To transactionData.Rows.Count - 2

            totQty += transactionData.Rows(i).Cells(3).Value
            totPrice += transactionData.Rows(i).Cells(5).Value


        Next

        allItemsQty.Text = totQty
        allItemsPrice.Text = totPrice
    End Sub

    'Validate entered Price in datagridview
    Private Sub price_CheckforDecimal(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim textBox As TextBox = CType(sender, TextBox)
        cnt = 0
        For Each c As Char In textBox.Text
            If c = "." Then
                cnt += 1
            End If
        Next
        If cnt > 1 Then
            MessageBox.Show("Make sure you entered a valid Price", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            textBox.Text = ""
        End If


    End Sub

    'Add new Row after an item is added to the gridview
    Private Sub transactionData_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles transactionData.UserAddedRow
        transactionData.AllowUserToAddRows = False

    End Sub
    '**************************************************

    'On btn click in the gridView
    Private Sub transactionData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles transactionData.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        Dim alreadyAdded As Boolean = False
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 0 Then
            If transactionData.CurrentRow.Cells(7).Value IsNot Nothing And
                transactionData.CurrentRow.Cells(2).Value IsNot Nothing And
                transactionData.CurrentRow.Cells(3).Value IsNot Nothing Then

                If transactionData.CurrentRow.Cells(4).Value Is Nothing Or transactionData.CurrentRow.Cells(4).Value = 0 Then
                    transactionData.CurrentRow.Cells(4).Value = 0
                End If
                'If transactionData.CurrentRow.Cells(5).Value Is Nothing Or transactionData.CurrentRow.Cells(5).Value = 0 Then
                Dim calculatedTotal As Decimal = (transactionData.CurrentRow.Cells(3).Value * transactionData.CurrentRow.Cells(4).Value)
                transactionData.CurrentRow.Cells(5).Value = calculatedTotal
                'End If

                For i As Integer = 0 To transactionData.Rows.Count - 1

                    If transactionData.Rows(i).Cells(7).Value = Nothing Then
                        alreadyAdded = True
                    End If

                Next

                If alreadyAdded = False Then
                    transactionData.AllowUserToAddRows = True

                End If

                Dim transactionTotalQuantity As Integer = 0
                Dim transactionTotalPrice As Decimal = 0
                Dim currentItemID As Integer = 0
                Dim updatedQty As Integer = 0
                Dim updatedUnitPrice As Decimal = 0
                Dim updatedTotalPrice As Decimal = 0
                Dim currentIndex As Integer = -1
                Dim foundItem As Boolean = False



                updatedQty = transactionData.CurrentRow.Cells(3).Value
                transactionData.CurrentRow.Cells(5).Value = transactionData.CurrentRow.Cells(4).Value * transactionData.CurrentRow.Cells(3).Value
                currentItemID = transactionData.CurrentRow.Cells(7).Value
                updatedUnitPrice = transactionData.CurrentRow.Cells(4).Value
                updatedTotalPrice = transactionData.CurrentRow.Cells(5).Value
                currentIndex = transactionData.CurrentRow.Index

                'MessageBox.Show(" BEFORE UPDATE : QTY " & updatedQty & " Total " & updatedTotalPrice & " UnitPrice " & updatedUnitPrice)

                For i As Integer = 0 To transactionData.Rows.Count - 2
                    If transactionData.Rows(i).Cells(7).Value.ToString <> Nothing Then

                        If currentItemID = transactionData.Rows(i).Cells(7).Value And currentIndex <> i Then



                            transactionData.Rows(i).Cells(3).Value += updatedQty
                            updatedQty = transactionData.Rows(i).Cells(3).Value

                            'transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(4).Value * transactionData.Rows(i).Cells(3).Value
                            updatedTotalPrice = transactionData.Rows(i).Cells(5).Value + updatedTotalPrice
                            transactionData.Rows(i).Cells(5).Value = (Math.Round((transactionData.Rows(i).Cells(5).Value), 2)).ToString

                            'transactionData.Rows(i).Cells(4).Value = (transactionData.Rows(i).Cells(4).Value + updatedUnitPrice) / 2
                            'transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(3).Value * transactionData.Rows(i).Cells(4).Value

                            updatedQty = transactionData.Rows(i).Cells(4).Value + updatedQty
                            updatedUnitPrice = updatedTotalPrice / (updatedQty - 1)

                            transactionData.Rows(i).Cells(4).Value = updatedUnitPrice
                            transactionData.Rows(i).Cells(4).Value = (Math.Round((transactionData.Rows(i).Cells(4).Value), 2)).ToString
                            transactionData.Rows(i).Cells(5).Value = updatedTotalPrice





                            foundItem = True
                        End If

                    End If

                Next
                If foundItem = True Then
                    transactionData.Rows.RemoveAt(currentIndex)

                End If

                allItemsQty.Text = String.Empty
                allItemsPrice.Text = String.Empty


                Dim totQty As Integer = 0
                Dim totPrice As Decimal = 0

                For i As Integer = 0 To transactionData.Rows.Count - 2

                    totQty += transactionData.Rows(i).Cells(3).Value
                    totPrice += transactionData.Rows(i).Cells(5).Value


                Next

                allItemsQty.Text = totQty
                allItemsPrice.Text = totPrice
                itemsExist = True
            Else

                MessageBox.Show("Make sure all required fields for the Inventory are filled", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 6 Then

            If transactionData.CurrentRow.Cells(7).Value IsNot Nothing And
                    transactionData.CurrentRow.Cells(2).Value IsNot Nothing And
                    transactionData.CurrentRow.Cells(3).Value IsNot Nothing Then

                Dim index As Integer = transactionData.CurrentCell.RowIndex
                transactionData.Rows.RemoveAt(index)
                transactionData.AllowUserToAddRows = False
                Dim transactionTotalQuantity As Integer = 0
                Dim transactionTotalPrice As Decimal = 0


                allItemsQty.Text = String.Empty
                allItemsPrice.Text = String.Empty


                Dim totQty As Integer = 0
                Dim totPrice As Decimal = 0

                For i As Integer = 0 To transactionData.Rows.Count - 2

                    totQty += transactionData.Rows(i).Cells(3).Value
                    totPrice += transactionData.Rows(i).Cells(5).Value


                Next

                allItemsQty.Text = totQty
                allItemsPrice.Text = totPrice

                itemsExist = True
            Else

                transactionData.CurrentRow.Cells(7).Value = Nothing
                transactionData.CurrentRow.Cells(2).Value = Nothing
                transactionData.CurrentRow.Cells(3).Value = Nothing
                transactionData.CurrentRow.Cells(4).Value = Nothing
                transactionData.CurrentRow.Cells(5).Value = Nothing
                'MessageBox.Show("Can't delete an empty row ", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        End If
    End Sub
    '***************************

    'For Adding icons to the Btns in the gridview
    Private Sub transactionData_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles transactionData.CellPainting
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            Dim bmpFind As Bitmap = My.Resources.add
            Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
            e.Graphics.DrawIcon(ico, e.CellBounds.Left + 32, e.CellBounds.Top + 3)
            e.Handled = True
        End If

        If e.ColumnIndex = 6 AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            Dim bmpFind As Bitmap = My.Resources.close
            Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
            e.Graphics.DrawIcon(ico, e.CellBounds.Left + 5, e.CellBounds.Top + 3)
            e.Handled = True
        End If

    End Sub
    '********************************************

    ' Initializing after Cancel Btn Click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        toBeUpdated = False
        transactionData.AllowUserToAddRows = True
        locationDropBox.Enabled = True
        stockIn.Enabled = True
        stockOut.Enabled = True
        retrievedTranID = 0

        clearFields()
    End Sub


    'Delete the whole Transaction after delete Btn Clicked
    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
        Dim theLocID As Integer = 0
        Dim theLocationName As String = String.Empty

        retrievedStockID = 0
        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedStockID = pair.Value
            End If
        Next
        theLocID = retrievedLocID
        theLocationName = locationDropBox.Text

        'getting totals to update the locationInventory
        For i As Integer = 0 To transactionData.Rows.Count - 2

            theItemID = transactionData.Rows(i).Cells(7).Value
            theItemQuantity = transactionData.Rows(i).Cells(3).Value
            theItemUnitprice = transactionData.Rows(i).Cells(4).Value
            theItemTotalPrice = transactionData.Rows(i).Cells(5).Value

            Dim sDt As New DataTable
            sDt = databaseObject.SelectMethode("Select ItemID, ItemQty,ItemAvgPrice, ItemTotalPrice from db_owner.tbl_location_inventory where
                (LocationID = '" & theLocID & "' and ItemID = '" & theItemID & "')")

            theCalculatedInventoryItemQty = sDt.Rows(0)("ItemQty").ToString - theItemQuantity
            theCalculatedInventoryItemAvgPrice = sDt.Rows(0)("ItemAvgPrice").ToString
            theCalculatedInventoryItemTotalPrice = (theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice)


            updateLocationInventory()

            '    If stockType = True Then
            '        theLocID = retrievedLocID

            '    ElseIf stockType = False Then
            '        theLocID = retrievedStockID

            '    End If

            '    theCalculatedInventoryItemQty = 0
            '    theCalculatedInventoryItemAvgPrice = 0
            '    theCalculatedInventoryItemTotalPrice = 0

            '    Dim sDt2 As New DataTable
            '    sDt2 = databaseObject.SelectMethode("Select ItemQty, ItemAvgPrice, ItemTotalPrice, LocationID, ItemID 
            '                                       From db_owner.tbl_location_inventory 
            '                                       Where (LocationID ='" & theLocID &
            '                                       "' And ItemID = '" & theItemID & "')")

            '    theCalculatedInventoryItemQty = sDt2.Rows(0)("ItemQty").ToString() + theItemQuantity
            '    theCalculatedInventoryItemAvgPrice = sDt2.Rows(0)("ItemAvgPrice").ToString()
            '    theCalculatedInventoryItemTotalPrice = theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice

            '    updateTheOutLocation(theLocID)

        Next





        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()


        Try

            conn.Open()

            myCommand.CommandText = "Delete From db_owner.tbl_transactioned_items where (TransactionID = '" & retrievedTranID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Delete")


        Finally
            clearFields()

            conn.Close()

        End Try
        deleteTheTransaction()

        locationDropBox.Enabled = True
        stockIn.Enabled = True
        stockOut.Enabled = True

    End Sub

    'The Delete Transaction function
    Sub deleteTheTransaction()
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()
            myCommand.CommandText = "Delete From db_owner.tbl_transaction where (ID = '" & retrievedTranID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException


            ' handle error
            Console.Write("Unable to Delete")


        Finally
            clearFields()


            conn.Close()

            updateTransactions()

            stockTransaGrid.DataSource = getStockTransa()


            stockTransaGrid.Columns(3).Width = 87

            stockTransaGrid.Columns(0).Visible = False
            stockTransaGrid.Columns(2).Visible = False
            stockTransaGrid.Columns(7).Visible = False

        End Try
        retrievedTranID = 0
        '    removeFromLocationInventory()
    End Sub
    '********************************

    'On cell text change to calculate the total Price and get the AVG Price, and update the totals below the gridView
    Private Sub transactionData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles transactionData.CurrentCellDirtyStateChanged

        Dim calculatedTotal As Decimal = (transactionData.CurrentRow.Cells(3).Value * transactionData.CurrentRow.Cells(4).Value)
        transactionData.CurrentRow.Cells(5).Value = calculatedTotal

        Dim totalQty As Integer = 0
        Dim totalPrices As Decimal = 0

        For i As Integer = 0 To transactionData.Rows.Count - 1


            totalQty += transactionData.Rows(i).Cells(3).Value


            totalPrices += transactionData.Rows(i).Cells(5).Value

        Next


        allItemsQty.Text = totalQty
        allItemsPrice.Text = totalPrices
        itemsExist = True


    End Sub
    '*****************************************************

    'On save Transaction btn clicked
    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        If locationDropBox.Text <> String.Empty Then

            checkEnteredIds()

            If stockType = True Then
                stockText = "Stock-IN"
            ElseIf stockType = False Then
                stockText = "Stock-OUT"
            End If
            If retrievedLocID = 0 Then
                MessageBox.Show("Make sure you entered a valid Location", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If


            If itemsExist = False Then
                MessageBox.Show("You Have to add at least one Item to the Above Transaction",
          "Invalid Transaction", MessageBoxButtons.OK,
           MessageBoxIcon.Warning)
                Exit Sub

            End If

            If toBeUpdated Then

                updateTheTransaction()
                toBeUpdated = False

                If updateComplete = True Then
                    clearFields()
                End If

                locationDropBox.Enabled = True
                Exit Sub

            End If

            insertIntoTransactions()
        Else
            MessageBox.Show("Make Sure You Filled All Required Fields",
                            "Invalid Fields", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        ''''''''''''''''''''''''''''''''''''
        retrievedTranID = 0

    End Sub

    'Add the Transaction
    Private Sub insertIntoTransactions()

        'Retrieving Location and Type ID
        retrievedTranTypeID = 0
        retrievedLocID = 0



        For Each pair As KeyValuePair(Of String, Integer) In locationList

            Dim key As String = pair.Key
            If key = locationDropBox.Text Then
                retrievedLocID = pair.Value

            End If
        Next

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedTranTypeID = pair.Value

            End If
        Next

        'Check If Qty is Available in the Selected Location
        '**************************************************'

        Dim theLocID As Integer = 0
        Dim theLocationName As String = String.Empty
        Dim userItemID As Integer = 0
        Dim InventoryLocationItemQty As Integer = 0
        Dim userItemQty As Integer = 0
        Dim userItemName As String = String.Empty




        theLocationName = locationDropBox.Text
        theLocID = retrievedLocID



        'CHECK QTY AVAILABLE IN THE SELECTED LOCATION
        If stockType = False Then

            For i As Integer = 0 To transactionData.Rows.Count - 2

                userItemID = transactionData.Rows(i).Cells(7).Value
                userItemQty = transactionData.Rows(i).Cells(3).Value
                userItemName = transactionData.Rows(i).Cells(2).Value

                Dim lDt As New DataTable
                lDt = databaseObject.SelectMethode("Select ItemQty from db_owner.tbl_location_inventory where( LocationID = '" & theLocID & "' and ItemID = '" & userItemID & "')")

                InventoryLocationItemQty = lDt.Rows(0)("ItemQty").ToString
                If InventoryLocationItemQty < userItemQty Then
                    MessageBox.Show("The quantity entered for " & userItemName & " exceeds the available in " & theLocationName)
                    Exit Sub

                End If

            Next


        End If

        '**************************************************'


        'Adding Transaction to database

        Dim query As String = String.Empty
        query &= "INSERT INTO db_owner.tbl_transaction (TransactionID,LocationID,StockStatus,StockText,TotalQty,TotalCost,ReferanceNumber,DateCreated,LocationName,"
        query &= "Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
        query &= "VALUES (@TransactionID, @LocationID,@StockStatus,@StockText, @TotalQty, @TotalCost, @ReferanceNumber, @DateCreated,  @LocationName,"
        query &= "@Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

        Using comm As New SqlCommand()
            With comm
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@TransactionID", retrievedTranTypeID)
                .Parameters.AddWithValue("@LocationID", retrievedLocID)
                .Parameters.AddWithValue("@StockStatus", stockType)
                .Parameters.AddWithValue("@StockText", stockText)
                .Parameters.AddWithValue("@TotalQty", allItemsQty.Text)
                .Parameters.AddWithValue("@TotalCost", allItemsPrice.Text)
                .Parameters.AddWithValue("@ReferanceNumber", referanceLabel.Text)
                .Parameters.AddWithValue("@DateCreated", dateCreatedField.Value)
                .Parameters.AddWithValue("@LocationName", locationDropBox.Text)
                .Parameters.AddWithValue("@Status", 1)
                .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                .Parameters.AddWithValue("@CreateDate", today)
                .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                .Parameters.AddWithValue("@RevisionDate", today)
            End With
            conn.Open()
            comm.ExecuteNonQuery()
            conn.Close()

        End Using
        '''''''''''''''''''''''''''''''''

        If itemsExist Then
            insertIntoItems()
        End If

    End Sub

    'get the AvgPrice of an Item
    Sub getAvgPrice(itemID)
        Dim dt As New DataTable
        Dim allPrices As Decimal = 0

        retrievedStockID = 0
        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("St") Or key.Contains("st") Then
                retrievedStockID = pair.Value
            End If
        Next

        Dim theLocID As Integer = retrievedLocID
        Dim theLocationName As String = locationDropBox.Text



        dt = databaseObject.SelectMethode("Select ItemAvgPrice , ItemQty 
                            From db_owner.tbl_location_inventory Where (LocationID = '" & theLocID & "' and ItemID = '" & itemID & "')")

        For i = 0 To dt.Rows.Count - 1
            allPrices += dt.Rows(i)("ItemAvgPrice")
            theTempWholeQuantity += dt.Rows(i)("ItemQty")

        Next
        calculatedAvgPrice = allPrices
    End Sub

    'For Errors in the gridView
    Private Sub transactionData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles transactionData.DataError

    End Sub
End Class