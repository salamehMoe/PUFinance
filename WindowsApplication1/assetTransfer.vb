
Imports System.Data.SqlClient

Public Class assetTransfer

    'Variables
    Dim today As Date = Date.Now
    Shared random As New Random()
    Dim sqlQuery As String
    Dim logedInUserID As Integer = My.Settings.userID
    Dim selectedTransaction As Integer = My.Settings.selectedTransaction
    Dim fromAllTrans As Boolean = My.Settings.fromAllTrans
    Dim retrievedAssetID As Integer = 0
    Dim generatedReferanceNum As Integer
    Dim retrievedTranID As Integer = 0
    Dim retrievedTranTypeID As Integer = 0
    Dim retrievedLocINID As Integer = 0
    Dim retrievedLocOUTID As Integer = 0
    Dim retrievedUserItemID As String

    Dim isComplete As Boolean = True
    Dim isCompleteStatusText As String = "-"

    Dim calculatedTotalQty As Double = 0
    Dim calculatedTotalCost As Double = 0
    Dim retrievedTotalQty As Integer = 0
    Dim retrievedTotalPrice As Double = 0


    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

    Dim locationINList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))

    Dim locationOUTList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))


    Dim itemsList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))

    Dim typeList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))

    Dim addedItemsIDList As List(Of KeyValuePair(Of String, String)) =
    New List(Of KeyValuePair(Of String, String))

    Dim cnt As Integer = 0
    Dim itemsExist As Boolean = False
    Dim toBeUpdated As Boolean = False
    Dim databaseObject As New DatabaseAccesClass
    Dim calculatedAvgPrice As Decimal = 0
    Dim theTempWholeQuantity As Integer = 0
    Dim invalidQty = False

    Dim allQty As Integer = 0
    Dim theUpdatedQuantity As Integer = 0
    Dim unitPrice As Decimal = 0
    Dim updatedTotalCost As Decimal = 0
    Dim unitQtyForUpdating As Integer = 0
    Dim inventoryToUseForDelete As Integer = 0
    Dim totalItemsQuantity As Integer = 0
    Dim QtyNotEqual As Boolean = False

    Dim theItemID As Integer = 0
    Dim theItemQuantity As Integer = 0
    Dim theItemUnitprice As Decimal = 0
    Dim theItemTotalPrice As Decimal = 0
    Dim theCalculatedInventoryItemQty As Integer = 0
    Dim theCalculatedInventoryItemAvgPrice As Decimal = 0
    Dim theCalculatedInventoryItemTotalPrice As Decimal = 0
    Dim theCalculatedInventoryItemTotalPrice2 As Decimal = 0

    Dim theCalculatedInventoryItemQty2 As Integer = 0

    Dim theTransID As Integer
    Dim theAssetID As Integer
    Dim theBarcodeCount As Integer

    Private Sub assetTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        'Setting dropdown boxes to prevent user from editing
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Font color and size for the gridview and groupBox
        GroupBox1.ForeColor = Color.DarkRed
        transactionData.Font = New Font("Gadugi", 7)
        transferTransaGrid.Font = New Font("Gadugi", 7)
        ''''''''''''''''''''''''''''''''''''''''''''''''''

        'Initializing fields

        allItemsQty.Text = "0"
        allItemsPrice.Text = "0"

        '''''''''''''''''''''''''''''''

        'Retrieving saved data from database
        getLocationsIN()
        getLocationsOUT()
        getTypes()
        ''''''''''''''''''''''''''''''''''''

        'Get all Transactions

        transferTransaGrid.DataSource = getTransferTransa()
        transferTransaGrid.Columns(0).Width = 70
        transferTransaGrid.Columns(1).Width = 100
        transferTransaGrid.Columns(2).Width = 80
        transferTransaGrid.Columns(5).Visible = False
        transferTransaGrid.Columns(6).Visible = False
        transferTransaGrid.Columns(7).Visible = False
        transferTransaGrid.Columns(8).Visible = False
        transferTransaGrid.Columns(9).Visible = False
        transferTransaGrid.Columns(10).Visible = False
        transferTransaGrid.Columns(11).Visible = False


        '''''''''''''''''''''

        If fromAllTrans = True And selectedTransaction <> -1 Then
            retrieveTransItems(selectedTransaction)

            My.Settings.fromAllTrans = False
            My.Settings.selectedTransaction = -1
            My.Settings.Save()
        End If

        getUserItems()

        For i As Integer = 0 To transactionData.Rows.Count - 1
            transactionData.Rows(i).Cells(6).Value = "Add Barcodes"
            transactionData.Rows(i).Cells(7).Value = "Select Date"
        Next
    End Sub


    'func to get Transfer Transactions
    Function getTransferTransa()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Tra") Or key.Contains("tra") Then
                retrievedTranTypeID = pair.Value

            End If
        Next
        Dim dtTransferTransactions As New DataTable

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Using cmd As New SqlCommand("SELECT ReferanceNumber as [Referance Number] ,DelivaryNumber as [Delivary Number], DateCreated as [Date],TransferOutLocation as [From],
                                     TransferInLocation as [To], EnteryStatus, Currancy, TotalQty, TotalCost, ID,ReceivedBy,ApprovedBy,StatusText as [Status] FROM db_owner.tbl_transaction
                                     where (TransactionID = '" & retrievedTranTypeID & "')", conn)

            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.HasRows Then


            End If
            dtTransferTransactions.Load(reader)

            conn.Close()

        End Using

        Return dtTransferTransactions
    End Function
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


    'Retrieving saved data from database
    Private Sub getLocationsIN()

        transferInDropBox.Items.Clear()
        locationINList.Clear()


        Using conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
            conn.Open()
            sqlQuery = "Select * from db_owner.tbl_asset_location"
            Using comm As SqlCommand = New SqlCommand(sqlQuery, conn)
                Dim rs As SqlDataReader = comm.ExecuteReader
                Dim dt As DataTable = New DataTable
                dt.Load(rs)

                For i = 0 To dt.Rows.Count - 1
                    locationINList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("LocationName").ToString(), dt.Rows(i)("ID").ToString()))

                Next


            End Using
        End Using
        conn.Close()
        autoCompleteLocationsIN()
    End Sub

    Private Sub getLocationsOUT()

        transferOutDropBox.Items.Clear()
        locationOUTList.Clear()


        Using conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
            conn.Open()
            sqlQuery = "Select * from db_owner.tbl_asset_location"
            Using comm As SqlCommand = New SqlCommand(sqlQuery, conn)
                Dim rs As SqlDataReader = comm.ExecuteReader
                Dim dt As DataTable = New DataTable
                dt.Load(rs)

                For i = 0 To dt.Rows.Count - 1
                    locationOUTList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("LocationName").ToString(), dt.Rows(i)("ID").ToString()))

                Next


            End Using
        End Using
        conn.Close()
        autoCompleteLocationsOUT()
    End Sub

    Private Sub getItems()

        checkEnteredIds()
        itemsList.Clear()


        Dim dt As New DataTable
        dt = databaseObject.SelectMethode("Select assetID, assetName from db_owner.tbl_location_asset_inventory where ( assetLocationID = '" & retrievedLocOUTID & "' and assetQty > 0)")


        For i = 0 To dt.Rows.Count - 1
            If itemsList.Contains(New KeyValuePair(Of String, Integer)(dt.Rows(i)("assetName").ToString(), dt.Rows(i)("assetID").ToString())) Then
                'Don't ADD
            Else

                itemsList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("assetName").ToString(), dt.Rows(i)("assetID").ToString()))
            End If


        Next

        conn.Close()

        autoCompleteItems()

    End Sub
    Private Sub getTypes()

        typeList.Clear()

        Using conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
            conn.Open()
            sqlQuery = "Select * from db_owner.tbl_transactionCode"
            Using comm As SqlCommand = New SqlCommand(sqlQuery, conn)
                Dim rs As SqlDataReader = comm.ExecuteReader
                Dim dt As DataTable = New DataTable
                dt.Load(rs)

                For i = 0 To dt.Rows.Count - 1
                    typeList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("TransactionName").ToString(), dt.Rows(i)("ID").ToString()))

                Next

            End Using
        End Using

        conn.Close()

    End Sub

    Private Sub getUserItems()

        addedItemsIDList.Clear()


        Dim dt As DataTable = New DataTable
        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_Asset where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            addedItemsIDList.Add(New KeyValuePair(Of String, String)(dt.Rows(i)("AssetName").ToString(), dt.Rows(i)("assetID").ToString()))



        Next





    End Sub
    Sub autoCompleteItems()

        Dim dt As New DataTable
        dt = databaseObject.SelectMethode("Select  DISTINCT assetID, assetName from db_owner.tbl_location_asset_inventory where ( assetLocationID = '" & retrievedLocOUTID & "' and assetQty > 0)")

        inventoryNameField.DataSource = dt
        inventoryNameField.DisplayMember = "assetName"
        inventoryNameField.ValueMember = "assetName"


    End Sub



    Sub autoCompleteLocationsIN()
        Dim constr As String = "Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;"
        Using con As SqlConnection = New SqlConnection(constr)
            Using sda As SqlDataAdapter = New SqlDataAdapter("Select LocationName from db_owner.tbl_asset_location", con)

                Dim dt As DataTable = New DataTable()
                sda.Fill(dt)


                Dim row As DataRow = dt.NewRow()

                dt.Rows.InsertAt(row, 0)


                transferInDropBox.DataSource = dt
                transferInDropBox.DisplayMember = "LocationName"
                transferInDropBox.ValueMember = "LocationName"


                transferInDropBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                transferInDropBox.AutoCompleteSource = AutoCompleteSource.ListItems


            End Using
        End Using
    End Sub

    Sub autoCompleteLocationsOUT()
        Dim constr As String = "Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;"
        Using con As SqlConnection = New SqlConnection(constr)
            Using sda As SqlDataAdapter = New SqlDataAdapter("Select LocationName from db_owner.tbl_asset_location", con)

                Dim dt As DataTable = New DataTable()
                sda.Fill(dt)


                Dim row As DataRow = dt.NewRow()

                dt.Rows.InsertAt(row, 0)


                transferOutDropBox.DataSource = dt
                transferOutDropBox.DisplayMember = "LocationName"
                transferOutDropBox.ValueMember = "LocationName"


                transferOutDropBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                transferOutDropBox.AutoCompleteSource = AutoCompleteSource.ListItems


            End Using
        End Using
    End Sub





    'Check Validity of inserted Fields
    Sub checkEnteredIds()

        retrievedLocINID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationINList

            Dim key As String = pair.Key
            If key = transferInDropBox.Text Then
                retrievedLocINID = pair.Value
            End If
        Next
        retrievedLocOUTID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationOUTList

            Dim key As String = pair.Key
            If key = transferOutDropBox.Text Then
                retrievedLocOUTID = pair.Value
            End If
        Next



    End Sub


    'Initialize all fields
    Sub clearFields()

        DelivaryNumber.Text = ""
        dateCreatedField.Value = today
        transactionData.Rows.Clear()
        allItemsPrice.Text = 0
        allItemsQty.Text = 0
        recievedByField.Text = ""
        approvedByField.Text = ""
        transferInDropBox.Text = ""
        transferOutDropBox.Text = ""
        statusLabel.Text = "-"


    End Sub
    ''''''''''''''''''''''''

    'Delete Transaction if it doesn't have items
    Sub deleteEmptyTransaction()

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

            '
            updateTransactions()

            transferTransaGrid.DataSource = getTransferTransa()

        End Try
    End Sub

    'On datagridView TextChange
    Private Sub locationDropBox_SelectedIndexChanged(sender As Object, e As EventArgs)

        retrievedLocINID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationINList

            Dim key As String = pair.Key
            If key = transferInDropBox.Text Then
                retrievedLocINID = pair.Value
            End If
        Next

        retrievedLocOUTID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationOUTList

            Dim key As String = pair.Key
            If key = transferOutDropBox.Text Then
                retrievedLocOUTID = pair.Value
            End If
        Next

    End Sub




    ''''''''''''''''''''''''''''''''''''''''''''''''''

    ';Function Called after Change in the DATE search Fields to get Transaction
    Function getSearchedPurchasedTransaWithDate()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Tra") Or key.Contains("tra") Then
                retrievedTranTypeID = pair.Value

            End If
        Next



        Dim dtPurchaseTransactions As New DataTable

        dtPurchaseTransactions = databaseObject.SelectMethode("SELECT ReferanceNumber As [Referance Number] ,DelivaryNumber As [Delivary Number],
                                 DateCreated As [Date],TransferOutLocation As [From],
                                 TransferInLocation As [To], EnteryStatus, Currancy, TotalQty, TotalCost, ID, ReceivedBy, ApprovedBy,EnteryStatus,StatusText as [Status]
                                 From db_owner.tbl_transaction where (TransactionID = '" & retrievedTranTypeID & "'
                                 and DelivaryNumber LIKE '%" & searchDelivary.Text & "%' and TransferOutLocation LIKE '%" & TransferFrom.Text &
                                 "%' and TransferInLocation LIKE '%" & TransferTo.Text & "%' and DateCreated = '" & searchDate.Value & "' and Status = 1)")

        ' 

        Return dtPurchaseTransactions
    End Function


    Sub allSearchFields()

        transferTransaGrid.DataSource = getSearchedPurchasedTransa()
        transferTransaGrid.Columns(0).Width = 70
        transferTransaGrid.Columns(1).Width = 100
        transferTransaGrid.Columns(2).Width = 80

        transferTransaGrid.Columns(5).Visible = False
        transferTransaGrid.Columns(6).Visible = False
        transferTransaGrid.Columns(7).Visible = False
        transferTransaGrid.Columns(8).Visible = False
        transferTransaGrid.Columns(9).Visible = False
        transferTransaGrid.Columns(10).Visible = False
        transferTransaGrid.Columns(12).Visible = False


    End Sub
    'On Search Click
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        allSearchFields()


    End Sub

    ''''''''''''''''''''''''''''''''''''''
    'For purchase Transaction Search called after search field change
    Function getSearchedPurchasedTransa()

        For Each pair As KeyValuePair(Of String, Integer) In typeList
            Dim key As String = pair.Key
            If key = "Transafer" Then
                retrievedTranTypeID = pair.Value
            End If
        Next

        Dim dtPurchaseTransactions As New DataTable

        dtPurchaseTransactions = databaseObject.SelectMethode("SELECT ReferanceNumber As [Referance Number] ,DelivaryNumber As [Delivary Number],
                                 DateCreated As [Date],TransferOutLocation As [From],
                                 TransferInLocation As [To], EnteryStatus, Currancy, TotalQty, TotalCost, ID, ReceivedBy, ApprovedBy,
                                 EnteryStatus,StatusText as [Status]
                                 From db_owner.tbl_transaction where (TransactionID = '" & retrievedTranTypeID & "'
                                 and DelivaryNumber LIKE '%" & searchDelivary.Text & "%' and TransferOutLocation LIKE '%" & TransferFrom.Text &
                                 "%' and TransferInLocation LIKE '%" & TransferTo.Text & "%' and Status = 1) ")

        Return dtPurchaseTransactions
    End Function


    'On retrievedBy search Field text Change
    Private Sub recievedBySearch_TextChanged(sender As Object, e As EventArgs) Handles TransferFrom.TextChanged
        allSearchFields()

    End Sub
    '*****************************************

    'On approvedBy search Field text Change
    Private Sub approvedBySearch_TextChanged(sender As Object, e As EventArgs) Handles TransferTo.TextChanged
        allSearchFields()
    End Sub

    'On date search Field text Change
    Private Sub searchDate_ValueChanged(sender As Object, e As EventArgs) Handles searchDate.ValueChanged

        transferTransaGrid.DataSource = getSearchedPurchasedTransaWithDate()

        transferTransaGrid.Columns(0).Width = 70
        transferTransaGrid.Columns(1).Width = 100
        transferTransaGrid.Columns(2).Width = 80
        transferTransaGrid.Columns(5).Visible = False
        transferTransaGrid.Columns(6).Visible = False
        transferTransaGrid.Columns(7).Visible = False
        transferTransaGrid.Columns(8).Visible = False
        transferTransaGrid.Columns(9).Visible = False
        transferTransaGrid.Columns(10).Visible = False
        transferTransaGrid.Columns(11).Visible = False
        transferTransaGrid.Columns(12).Visible = False


    End Sub


    Private Sub searchInvoice_TextChanged(sender As Object, e As EventArgs) Handles searchDelivary.TextChanged
        allSearchFields()
    End Sub

    'Cancel Search BTN CLICK
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        allSearchFields()
        TransferFrom.Text = ""
        TransferTo.Text = ""
        searchDelivary.Text = ""
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Cell Click on the Purchase Transaction GridView
    Private Sub purchaseTransaGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles transferTransaGrid.CellClick



        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        Dim theID As Integer

        If (i >= 0 And i < transferTransaGrid.Rows.Count - 1) Then


            selectedRow = transferTransaGrid.Rows(i)


            DelivaryNumber.Text = selectedRow.Cells(1).Value.ToString()
            dateCreatedField.Value = selectedRow.Cells(2).Value.ToString()
            transferInDropBox.Text = selectedRow.Cells(4).Value.ToString()
            transferOutDropBox.Text = selectedRow.Cells(3).Value.ToString()
            recievedByField.Text = selectedRow.Cells(10).Value.ToString()
            approvedByField.Text = selectedRow.Cells(11).Value.ToString()
            If selectedRow.Cells(5).Value.ToString() = True Then
                statusLabel.Text = "Complete"
            Else
                statusLabel.Text = "Incomplete"
            End If



            allItemsQty.Text = "0"
            allItemsPrice.Text = "0"

            Dim currPrice As Decimal = 0


            currPrice = selectedRow.Cells(8).Value.ToString()


            Dim qty As String = selectedRow.Cells(7).Value.ToString()

            allItemsQty.Text = qty
            allItemsPrice.Text = Math.Round(currPrice, 2)



            theID = selectedRow.Cells(9).Value
            retrievedTranID = theID

            calculatedTotalQty = selectedRow.Cells(7).Value
            calculatedTotalCost = selectedRow.Cells(8).Value


            fillTheTransactionItems(theID)
            toBeUpdated = True

            transactionData.Columns(2).ReadOnly = True
            transactionData.Rows(transactionData.Rows.Count - 1).Cells(2).ReadOnly = False

        Else



            'clearFields()
        End If
        transferInDropBox.Enabled = False
        transferOutDropBox.Enabled = False

    End Sub

    Sub retrieveTransItems(selectedTransaction As Integer)
        Dim i As Integer
        For j As Integer = 0 To transferTransaGrid.Rows.Count - 2
            If transferTransaGrid.Rows(j).Cells(9).Value = selectedTransaction Then
                i = j

            End If
        Next
        Dim selectedRow As DataGridViewRow
        Dim theID As Integer

        If (i >= 0 And i < transferTransaGrid.Rows.Count - 1) Then


            selectedRow = transferTransaGrid.Rows(i)


            DelivaryNumber.Text = selectedRow.Cells(1).Value.ToString()
            dateCreatedField.Value = selectedRow.Cells(2).Value.ToString()
            transferInDropBox.Text = selectedRow.Cells(4).Value.ToString()
            transferOutDropBox.Text = selectedRow.Cells(3).Value.ToString()
            recievedByField.Text = selectedRow.Cells(10).Value.ToString()
            approvedByField.Text = selectedRow.Cells(11).Value.ToString()
            If selectedRow.Cells(5).Value.ToString() = True Then
                statusLabel.Text = "Complete"
            Else
                statusLabel.Text = "Incomplete"
            End If








            allItemsQty.Text = "0"
            allItemsPrice.Text = "0"

            Dim currPrice As Decimal = 0


            currPrice = selectedRow.Cells(8).Value.ToString()


            Dim qty As String = selectedRow.Cells(7).Value.ToString()

            allItemsQty.Text = qty
            allItemsPrice.Text = (currPrice).ToString


            theID = selectedRow.Cells(9).Value
            retrievedTranID = theID

            calculatedTotalQty = selectedRow.Cells(7).Value
            calculatedTotalCost = selectedRow.Cells(8).Value


            fillTheTransactionItems(theID)
            toBeUpdated = True


        Else



            'clearFields()
        End If
        transferInDropBox.Enabled = False
        transferOutDropBox.Enabled = False
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''
    'Fill datagridView with transaction ITEMS
    Sub fillTheTransactionItems(theID)
        'Get the TransactionID and the totals from the ReferanceNumber
        transactionData.Rows.Clear()



        Dim count As Integer = 0
        Using conn2 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
            conn2.Open()
            sqlQuery = "Select  db_owner.tbl_Item.ItemID as [itemID],db_owner.tbl_transactioned_items.ItemName as [ItemNAme] ,db_owner.tbl_transactioned_items.Quantity as [Qty],
                        db_owner.tbl_transactioned_items.UnitAvgCost as [uAvgCost], db_owner.tbl_transactioned_items.TotalCost as [tCost],
                        db_owner.tbl_transactioned_items.ItemID as [theID] from db_owner.tbl_transactioned_items, db_owner.tbl_Item 
                        where (db_owner.tbl_transactioned_items.TransactionID = '" & theID & "' and db_owner.tbl_transactioned_items.ItemID = db_owner.tbl_Item.ID)"
            Using comm As SqlCommand = New SqlCommand(sqlQuery, conn2)
                Dim rs As SqlDataReader = comm.ExecuteReader
                Dim dt As DataTable = New DataTable
                dt.Load(rs)
                Dim itemName As String = ""

                For i = 0 To dt.Rows.Count - 1

                    transactionData.Rows.Add(New String() {Nothing, dt.Rows(i)("itemID").ToString(), dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("Qty").ToString(),
                    Math.Round(dt.Rows(i)("uAvgCost"), 2), Math.Round(dt.Rows(i)("tCost"), 2), Nothing, dt.Rows(i)("theID").ToString()})


                Next



            End Using
        End Using

        'conn.Close()
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''

    '''''''''''''''''''''''''''''''''''''''''''

    'Get the AvgPrice of the Item selected
    Sub getAvgPrice(itemID)
        Dim dt As New DataTable
        Dim allPrices As Decimal = 0

        dt = databaseObject.SelectMethode("Select assetUnitPrice , assetQty 
                            From db_owner.tbl_location_asset_inventory Where (assetLocationID = '" & retrievedLocOUTID & "' and assetID = '" & itemID & "')")

        For i = 0 To dt.Rows.Count - 1
            allPrices += dt.Rows(i)("assetUnitPrice")
            theTempWholeQuantity += dt.Rows(i)("assetQty")

        Next

        calculatedAvgPrice = allPrices / (dt.Rows.Count)

    End Sub
    'on Items'Name GridView textChange
    Private Sub inventoryNameField_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim combo As ComboBox = CType(sender, ComboBox)
        transactionData.CurrentRow.Cells(2).Value = combo.SelectedValue

        retrievedAssetID = 0

        For Each pair As KeyValuePair(Of String, Integer) In itemsList

            Dim key As String = pair.Key
            If key = transactionData.CurrentRow.Cells(2).Value.ToString Then
                retrievedAssetID = pair.Value
            End If

        Next
        transactionData.CurrentRow.Cells(9).Value = retrievedAssetID

        If retrievedAssetID <> 0 Then
            getAvgPrice(retrievedAssetID)

            transactionData.CurrentRow.Cells(4).Value = calculatedAvgPrice

            'transactionData.CurrentRow.Cells(3).Value = theTempWholeQuantity
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


        getAssetsBarcode()

        MessageBox.Show(" THE AssetID ID " & retrievedAssetID & " THE TRANS ID " & retrievedTranID)

        Dim dt As New DataTable
        dt = databaseObject.SelectMethode("Select acquisationDate from db_owner.tbl_asset_transactioned 
                     WHERE ( TransactionID = '" & theTransID & "' and assetID = '" & retrievedAssetID & "')")

        Dim theAssetAcquisationDate As String
        theAssetAcquisationDate = Format(dt.Rows(0)("acquisationDate"), "MMM d,yyyy")

        transactionData.CurrentRow.Cells(7).Value = theAssetAcquisationDate
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''

    'Get Assets Barcode after selecting an asset

    Sub getAssetsBarcode()

        Dim dt As New DataTable


        dt = databaseObject.SelectMethode("Select ID from db_owner.tbl_asset_transactions 
        Where (LocationID = '" & retrievedLocOUTID & "' OR transferOUTLocationID = '" & retrievedLocOUTID & "')")



        For i As Integer = 0 To dt.Rows.Count - 1
            theTransID = dt.Rows(i)("ID")

            Dim dt2 As New DataTable
            dt2 = databaseObject.SelectMethode("Select assetID from db_owner.tbl_asset_transactioned 
            where (TransactionID = '" & theTransID & "' and assetID = '" & retrievedAssetID & "')")

            theAssetID = dt2.Rows(i)("assetID")

            'MessageBox.Show("THE INDEX " & i & " THE LOC ID " & retrievedLocOUTID & " THE TRANSID " & theTransID & " THE ASSET ID " & theAssetID)


        Next


    End Sub
    '*******************************************
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
    '''''''''''''''''''''''''''''''''''''''''''
    'For Checking Quantities
    Private Sub qty_check(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim textBox As TextBox = CType(sender, TextBox)

        If textBox.Text <> String.Empty Then

            theBarcodeCount = textBox.Text


            If textBox.Text > theTempWholeQuantity Then
                MessageBox.Show("The Quantity entered for the following Item exceeds the available : " & theTempWholeQuantity)
                textBox.Text = String.Empty
            End If
        End If


    End Sub
    '*******************************************

    'For Handeling dataGridView text Change and validations
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

            'Check Available Qty on qtyfield textChange
            If transactionData.CurrentCell.ColumnIndex = 3 Then

                Dim qtyTextBox As TextBox = e.Control
                If (qtyTextBox IsNot Nothing) Then
                    RemoveHandler qtyTextBox.TextChanged, New EventHandler(AddressOf qty_check)
                    AddHandler qtyTextBox.TextChanged, New EventHandler(AddressOf qty_check)
                End If

                Dim textBox As TextBox = e.Control
                RemoveHandler textBox.KeyPress, New KeyPressEventHandler(AddressOf qtyField_KeyPress)
                AddHandler textBox.KeyPress, New KeyPressEventHandler(AddressOf qtyField_KeyPress)

                Dim textBox2 As TextBox = e.Control

                RemoveHandler textBox2.PreviewKeyDown, New PreviewKeyDownEventHandler(AddressOf totalPrice_PreviewKeyDown)
                AddHandler textBox2.PreviewKeyDown, New PreviewKeyDownEventHandler(AddressOf totalPrice_PreviewKeyDown)
            End If
            '**********************************************
        End If

    End Sub
    '''''''''''''''''''''''''''''''''''''''''''
    Private Sub totalPrice_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)

        Dim updatedUnitPrice As Decimal
        Dim alreadyAdded As Boolean

        Dim updatedQty As Integer = 0
        If textBox.Text <> String.Empty And transactionData.CurrentRow.Cells(7).Value <> Nothing Then

            If e.KeyCode = Keys.Tab Then



                For i As Integer = 0 To transactionData.Rows.Count - 1

                    If transactionData.Rows(i).Cells(7).Value = Nothing Then
                        alreadyAdded = True
                    End If

                Next
                updatedQty = textBox.Text

                Dim transactionTotalQuantity As Integer = 0
                Dim transactionTotalPrice As Decimal = 0
                Dim currentItemID As Integer = 0


                Dim updatedTotalPrice As Decimal = 0
                Dim currentIndex As Integer = -1
                Dim foundItem As Boolean = False

                currentItemID = transactionData.CurrentRow.Cells(9).Value
                updatedUnitPrice = transactionData.CurrentRow.Cells(4).Value
                updatedTotalPrice = transactionData.CurrentRow.Cells(5).Value
                currentIndex = transactionData.CurrentRow.Index

                'MessageBox.Show(currentItemID & " - " & updatedQty & " - " & updatedTotalPrice & " - " & currentIndex & " - " & updatedUnitPrice)

                For i As Integer = 0 To transactionData.Rows.Count - 2
                    If transactionData.Rows(i).Cells(9).Value.ToString <> String.Empty Then


                        If currentItemID = transactionData.Rows(i).Cells(9).Value And currentIndex <> i Then
                            transactionData.Rows(i).Cells(3).Value += updatedQty
                            'transactionData.Rows(i).Cells(4).Value = (transactionData.Rows(i).Cells(4).Value + updatedUnitPrice) / 2
                            transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(3).Value * transactionData.Rows(i).Cells(4).Value
                            foundItem = True
                        End If

                        transactionTotalQuantity += transactionData.Rows(i).Cells(3).Value
                        transactionTotalPrice += transactionData.Rows(i).Cells(5).Value
                    End If
                Next
                If foundItem = True Then
                    transactionData.Rows.RemoveAt(currentIndex)

                End If

                If alreadyAdded = False Then
                    transactionData.Rows.Add("", "", "", Nothing, Nothing, Nothing, "Add Barcodes", "Select Date", "", "")

                End If

                'MessageBox.Show("THE New SIZE " & transactionData.Rows.Count)
            End If
        End If






    End Sub

    'Set Asset Barcode to selected Asset

    Sub updateAssetBarcodes()


        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()


            myCommand.CommandText = "Update TOP (" & theBarcodeCount & ") db_owner.tbl_asset_Barcodes Set inTransfer = 1 
            where (transID = '" & theTransID & "' and itemID = '" & theAssetID & "')"

            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error

            MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try

    End Sub
    '***********************************

    'Allow or disallow to add new rows to datagridview
    Private Sub transactionData_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles transactionData.UserAddedRow
        transactionData.AllowUserToAddRows = False


    End Sub
    '''''''''''''''''''''''''''''''''''''''''''
    'Btn Click in the DatagridView
    Private Sub transactionData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles transactionData.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)
        Dim currentItemID As Integer = 0
        Dim updatedQty As Integer = 0
        Dim updatedUnitPrice As Decimal = 0
        Dim updatedTotalPrice As Decimal = 0
        Dim currentIndex As Integer = -1
        Dim foundItem As Boolean = False
        Dim alreadyAdded As Boolean = False

        If transactionData.CurrentRow.Cells(9).Value <> Nothing Then


            currentItemID = transactionData.CurrentRow.Cells(9).Value
            updatedQty = transactionData.CurrentRow.Cells(3).Value
            updatedUnitPrice = transactionData.CurrentRow.Cells(4).Value
            updatedTotalPrice = transactionData.CurrentRow.Cells(5).Value
            currentIndex = transactionData.CurrentRow.Index

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 0 Then
                If transactionData.CurrentRow.Cells(7).Value IsNot Nothing And
                    transactionData.CurrentRow.Cells(2).Value IsNot Nothing And
                    transactionData.CurrentRow.Cells(3).Value IsNot Nothing Then

                    If transactionData.CurrentRow.Cells(4).Value Is Nothing Or transactionData.CurrentRow.Cells(4).Value = 0 Then
                        transactionData.CurrentRow.Cells(4).Value = 0
                    End If
                    If transactionData.CurrentRow.Cells(5).Value Is Nothing Or transactionData.CurrentRow.Cells(5).Value = 0 Then
                        Dim calculatedTotal As Decimal = (transactionData.CurrentRow.Cells(3).Value * transactionData.CurrentRow.Cells(4).Value)
                        transactionData.CurrentRow.Cells(5).Value = calculatedTotal
                    End If

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

                    For i As Integer = 0 To transactionData.Rows.Count - 2
                        If transactionData.Rows(i).Cells(7).Value <> Nothing Then


                            If currentItemID = transactionData.Rows(i).Cells(7).Value And currentIndex <> i Then

                                transactionData.Rows(i).Cells(3).Value += updatedQty
                                transactionData.Rows(i).Cells(4).Value = (transactionData.Rows(i).Cells(4).Value + updatedUnitPrice) / 2
                                transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(3).Value * transactionData.Rows(i).Cells(4).Value
                                foundItem = True
                            End If

                            transactionTotalQuantity += transactionData.Rows(i).Cells(3).Value
                            transactionTotalPrice += transactionData.Rows(i).Cells(5).Value

                        End If
                    Next

                    If foundItem = True Then

                        transactionData.Rows.RemoveAt(currentIndex)

                    End If
                    allItemsQty.Text = transactionTotalQuantity
                    allItemsPrice.Text = transactionTotalPrice
                    itemsExist = True
                Else

                    MessageBox.Show("Make sure all required fields for the Inventory are filled", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 8 Then

                If transactionData.CurrentRow.Cells(7).Value IsNot Nothing And
                        transactionData.CurrentRow.Cells(2).Value IsNot Nothing And
                        transactionData.CurrentRow.Cells(3).Value IsNot Nothing Then

                    Dim index As Integer = transactionData.CurrentCell.RowIndex
                    transactionData.Rows.RemoveAt(index)
                    transactionData.AllowUserToAddRows = False
                    'transactionData.AllowUserToAddRows = True
                    Dim transactionTotalQuantity As Integer = 0
                    Dim transactionTotalPrice As Decimal = 0

                    For i As Integer = 0 To transactionData.Rows.Count - 1

                        transactionTotalQuantity += transactionData.Rows(i).Cells(3).Value
                        transactionTotalPrice += transactionData.Rows(i).Cells(5).Value

                    Next
                    allItemsQty.Text = transactionTotalQuantity
                    allItemsPrice.Text = transactionTotalPrice
                    itemsExist = True
                Else

                    transactionData.CurrentRow.Cells(7).Value = Nothing
                    transactionData.CurrentRow.Cells(2).Value = Nothing
                    transactionData.CurrentRow.Cells(3).Value = Nothing
                    transactionData.CurrentRow.Cells(4).Value = Nothing
                    transactionData.CurrentRow.Cells(5).Value = Nothing
                End If

            End If

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 7 Then

                My.Settings.fromPurchase = False
                My.Settings.fromTransfer = True

                Dim pickerForm = New pickDateDailog
                pickerForm.Show()

            End If

            If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
               e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 6 Then

                My.Settings.theAssetID = theAssetID
                My.Settings.theTransID = theTransID

                Dim barcodeSelecting = New barcodeSelect
                barcodeSelecting.Show()

            End If

        End If
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''
    'For Btn ICON
    Private Sub transactionData_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles transactionData.CellPainting

        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            Dim bmpFind As Bitmap = My.Resources.add
            Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
            e.Graphics.DrawIcon(ico, e.CellBounds.Left + 5, e.CellBounds.Top + 3)
            e.Handled = True
        End If

        If e.ColumnIndex = 8 AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            Dim bmpFind As Bitmap = My.Resources.close
            Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
            e.Graphics.DrawIcon(ico, e.CellBounds.Left + 5, e.CellBounds.Top + 3)
            e.Handled = True
        End If


    End Sub
    '''''''''''''''''''''''''''''''''''''''''''
    'Updating Transaction after selection
    Sub updateTheTransaction()
        '    'Get the TransactionID and the totals from the ReferanceNumber

        If recievedByField.Text <> String.Empty And approvedByField.Text <> String.Empty And DelivaryNumber.Text <> String.Empty Then
            isComplete = True
            isCompleteStatusText = "Complete"
            statusLabel.Text = "Complete"
        Else
            isComplete = False
            isCompleteStatusText = "InComplete"
            statusLabel.Text = "InComplete"
        End If

        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_transaction where (ReferanceNumber = SOMEVALUE and Status = 1)")
        retrievedTranID = dt.Rows(0)("ID").ToString()


        getQtyAndItemIDToUpdate(retrievedTranID)

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()



        Try
            conn.Open()
            myCommand.CommandText = "Update db_owner.tbl_transaction Set DelivaryNumber = '" & DelivaryNumber.Text & "',
                                     TotalQty = '" & allItemsQty.Text & "',TotalCost = '" & allItemsPrice.Text & "',
                                     EnteryStatus = '" & isComplete & "', StatusText = '" & isCompleteStatusText & "',
                                     ReceivedBy = '" & recievedByField.Text & "', ApprovedBy = '" & approvedByField.Text & "',
                                     RevisionUserID = '" & logedInUserID & "',RevisionDate = '" & today & "',DateCreated = '" & dateCreatedField.Value & "'
                                     where (ID = '" & retrievedTranID & "')"


            rows = myCommand.ExecuteNonQuery()


        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Add")

        Finally

            transferTransaGrid.DataSource = getTransferTransa()
            transferTransaGrid.Columns(0).Width = 70
            transferTransaGrid.Columns(1).Width = 100
            transferTransaGrid.Columns(2).Width = 80
            transferTransaGrid.Columns(5).Visible = False
            transferTransaGrid.Columns(6).Visible = False
            transferTransaGrid.Columns(7).Visible = False
            transferTransaGrid.Columns(8).Visible = False
            transferTransaGrid.Columns(9).Visible = False
            transferTransaGrid.Columns(10).Visible = False
            transferTransaGrid.Columns(11).Visible = False

            conn.Close()

        End Try



    End Sub
    '''''''''''''''''''''''''''''''''''''''''''

    'Get The Qty and Item ID to Update to check if any Item should be deleted
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


            For j As Integer = 0 To transactionData.Rows.Count - 2
                If itemIdToBeCheckedValue = transactionData.Rows(j).Cells(7).Value.ToString() Then

                    itemToBeCheckedFound = True

                    Exit For

                End If
            Next

            'check if Item is still present in the gridview, otherwise delete it
            If itemToBeCheckedFound = False Then
                deleteTheNotFoundItem(itemIdToBeCheckedValue, retrievedTranID, itemToBeCheckedQty, itemToBeCheckedUnitPrice)

            End If
            '*******************************************************************
        Next

        For j As Integer = 0 To transactionData.Rows.Count - 2
            If transactionData.Rows(j).Cells(7).Value.ToString <> String.Empty Then


                dt = databaseObject.SelectMethode("Select Quantity , ItemID, TransactionID, UnitAvgCost 
                            From db_owner.tbl_transactioned_Items Where (db_owner.tbl_transactioned_Items.TransactionID = '" & retrievedTranID & "' and Status = 1)")

                For i = 0 To dt.Rows.Count - 1
                    oldItem = False
                    theItemQty = dt.Rows(i)("Quantity").ToString()
                    theItemID = dt.Rows(i)("ItemID").ToString()
                    theTranID = dt.Rows(i)("TransactionID").ToString()
                    theItemAvgPrice = dt.Rows(i)("UnitAvgCost").ToString()


                    If transactionData.Rows(j).Cells(7).Value.ToString() = theItemID Then

                        itemIndex = j
                        'If Item is already present --> Update the Transaction,location Inventory
                        updateTheItemsTransTransaction(theItemQty, theItemID, theTranID, theItemAvgPrice, itemIndex)
                        oldItem = True
                        Exit For


                    End If
                    Dim isFound As Boolean = False

                Next

                If oldItem = False Then
                    Dim itemName As String = transactionData.Rows(j).Cells(2).Value.ToString()
                    insertAsNewItem(transactionData.Rows(j).Cells(3).Value.ToString(), transactionData.Rows(j).Cells(7).Value.ToString(),
                theTranID, transactionData.Rows(j).Cells(4).Value.ToString(), itemName)

                End If
            End If

        Next
        Exit Sub
    End Sub

    'Insert as new item if not Update or if a new Item is present in the gridview
    Sub insertAsNewItem(theItemQty, theItemID, theTranID, theItemAvgPrice, itemName)
        'Adding Transaction to database
        Dim connecti As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        Dim newItemTotalPrice As Decimal = theItemQty * theItemAvgPrice




        Dim query As String = String.Empty
        query &= "INSERT INTO db_owner.tbl_transactioned_items (TransactionID,ItemID,ItemName,Quantity,"
        query &= "UnitAvgCost,TotalCost,TransactionName,Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
        query &= "VALUES (@TransactionID, @ItemID, @ItemName,@Quantity, @UnitAvgCost, @TotalCost,"
        query &= "@TransactionName, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

        Using comm As New SqlCommand()
            With comm
                .Connection = connecti
                .CommandType = CommandType.Text
                .CommandText = query

                .Parameters.AddWithValue("@TransactionID", retrievedTranID)
                .Parameters.AddWithValue("@ItemID", theItemID)
                .Parameters.AddWithValue("@ItemName", itemName)
                .Parameters.AddWithValue("@Quantity", theItemQty)
                .Parameters.AddWithValue("@UnitAvgCost", theItemAvgPrice)
                .Parameters.AddWithValue("@TotalCost", newItemTotalPrice)
                .Parameters.AddWithValue("@TransactionName", "Transfer")

                .Parameters.AddWithValue("@Status", 1)
                .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                .Parameters.AddWithValue("@CreateDate", today)
                .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                .Parameters.AddWithValue("@RevisionDate", today)
            End With

            connecti.Open()
            comm.ExecuteNonQuery()
            connecti.Close()


        End Using

        'update the Location_inventory after a new item is added
        updateItemQtyInInventory(retrievedTranID, theItemID, itemName, theItemQty, theItemAvgPrice)

    End Sub
    '****************************************************************************

    'Function for updating existing Items if changed on the gridview
    Sub updateTheItemsTransTransaction(theItemQty, theItemID, theTranID, theItemAvgPrice, itemIndex)

        Dim invDt As New DataTable
        Dim orignalItemQty As Integer = 0
        Dim originalTotalPrice As Decimal = 0
        Dim totalCostInItem As Decimal = 0

        ' Get the current QTY of items from the location_inventory
        invDt = databaseObject.SelectMethode("Select ItemQty from db_owner.tbl_location_inventory where ( itemID = '" & theItemID & "'
        and LocationID = '" & retrievedLocOUTID & "')")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Add the previous qty and calculate the new total of item to the current qty in the location_inventory
        orignalItemQty = invDt.Rows(0)("ItemQty").ToString + theItemQty
        originalTotalPrice = orignalItemQty * theItemAvgPrice
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''


        'Update the transactioned_items with the new added values in the gridview

        totalCostInItem = transactionData.Rows(itemIndex).Cells(5).Value.ToString()


        ' Update the qty and the total of item in the location_inventory
        Dim newlItemQty As Integer = orignalItemQty - transactionData.Rows(itemIndex).Cells(3).Value.ToString()
        Dim newTotalPrice As Decimal = newlItemQty * transactionData.Rows(itemIndex).Cells(4).Value.ToString()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Update the location_inventory of the LOCATIONOUT with the new QTYs and Total
        Dim conn3 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        Dim rows3 As Integer
        Dim myCommand3 As SqlCommand = conn3.CreateCommand()

        Try

            conn3.Open()

            myCommand3.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & newlItemQty & "'
                , itemTotalPrice = '" & newTotalPrice & "' where (LocationID = '" & retrievedLocOUTID & "'
                and ItemID = '" & theItemID & "')"

            rows3 = myCommand3.ExecuteNonQuery()

        Catch ex As SqlException

            '    ' handle error
            Console.Write("Unable to Add")

        Finally

            conn3.Close()

        End Try


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Update the location_inventory of the LOCATION IN with the new QTYs and Total

        'Get the current QTY in the LOCATION IN

        Dim invInDt As New DataTable
        invInDt = databaseObject.SelectMethode("Select itemQty from db_owner.tbl_location_inventory where (ItemID = '" &
                                                   transactionData.Rows(itemIndex).Cells(7).Value.ToString() & "' and LocationID = '" & retrievedLocINID & "')")

        ''''''''''''''''''''''''''''''''''''''''

        Dim theNewItemQty As Integer = 0
        Dim newTotal As Decimal = 0

        'Get the QTY
        Dim itemDt As New DataTable
        itemDt = databaseObject.SelectMethode("Select Quantity from db_owner.tbl_transactioned_items where (ItemID = '" &
                                                   transactionData.Rows(itemIndex).Cells(7).Value.ToString() & "' and TransactionID = '" & theTranID & "' and Status = 1)")

        Dim itemQtyInTransaction As Integer = itemDt.Rows(0)("Quantity").ToString()
        theNewItemQty = invInDt.Rows(0)("itemQty").ToString() - itemQtyInTransaction

        theNewItemQty = theNewItemQty + transactionData.Rows(itemIndex).Cells(3).Value.ToString
        newTotal = (theNewItemQty * transactionData.Rows(itemIndex).Cells(4).Value.ToString())

        Dim conn4 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        Dim rows4 As Integer
        Dim myCommand4 As SqlCommand = conn4.CreateCommand()

        Try

            conn4.Open()

            myCommand4.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & theNewItemQty & "'
                , itemTotalPrice = '" & newTotal & "' where ( LocationID = '" & retrievedLocINID & "'
                and ItemID = '" & transactionData.Rows(itemIndex).Cells(7).Value.ToString() & "')"

            rows4 = myCommand4.ExecuteNonQuery()

        Catch ex As SqlException

            '    ' handle error
            Console.Write("Unable to Add")

        Finally

            conn4.Close()

        End Try


        Dim conn2 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        Dim rows2 As Integer
        Dim myCommand2 As SqlCommand = conn2.CreateCommand()

        Try

            conn2.Open()

            myCommand2.CommandText = "Update db_owner.tbl_transactioned_items Set Quantity = '" & transactionData.Rows(itemIndex).Cells(3).Value.ToString() & "'
                , TotalCost = '" & totalCostInItem & "' where (db_owner.tbl_transactioned_items.TransactionID = '" & theTranID & "'
                and db_owner.tbl_transactioned_items.ItemID = '" & transactionData.Rows(itemIndex).Cells(7).Value.ToString() & "')"

            rows2 = myCommand2.ExecuteNonQuery()

        Catch ex As SqlException

            '    ' handle error
            Console.Write("Unable to Add")

        Finally

            conn2.Close()

        End Try


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''


    End Sub
    '**************************************************
    Function getItemQtyFromInventory(selectedItemID As String) As Integer

        Dim dt As New DataTable
        Dim allQTY As Integer = 0

        'dt = databaseObject.SelectMethode("Select tbl_transactioned_Items.Quantity , tbl_transaction.LocationID 
        '                    From db_owner.tbl_transactioned_Items, db_owner.tbl_transaction Where (db_owner.tbl_transactioned_Items.TransactionID = db_owner.tbl_transaction.ID
        '                          And db_owner.tbl_transaction.LocationID = '" & retrievedLocOUTID & "' and ItemID = '" & selectedItemID & "' and TransactionName = 'Purchase')")

        dt = databaseObject.SelectMethode("Select ItemQty from db_owner.tbl_location_inventory where(LocationID = '" & retrievedLocOUTID & "' and ItemID = '" & selectedItemID & "')")
        'For i = 0 To dt.Rows.Count - 1
        'locationDropBox.Items.Add(dt.Rows(i)("Name").ToString())
        allQTY = dt.Rows(0)("ItemQty").ToString()

        'Next

        Return allQTY
    End Function


    'Function to Delete Item after "X" pressed om the gridView,Update the qtys on location_inventory
    Sub deleteTheNotFoundItem(theItemID, retrievedTranID, itemToBeCheckedQty, itemToBeCheckedUnitPrice)

        MessageBox.Show("inside the delete ")
        Dim invDt As New DataTable

        Dim orignalItemQty As Integer = 0
        Dim originalTotalPrice As Decimal = 0
        Dim totalCostInItem As Decimal = 0

        ' Get the current QTY of items from the location_inventory
        invDt = databaseObject.SelectMethode("Select ItemQty,ItemAvgPrice from db_owner.tbl_location_inventory where ( itemID = '" & theItemID & "'
        and LocationID = '" & retrievedLocOUTID & "')")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Add the previous qty and calculate the new total of item to the current qty in the location_inventory
        orignalItemQty = invDt.Rows(0)("ItemQty").ToString
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ' Update the qty and the total of item in the location_inventory
        Dim newlItemQty As Integer = orignalItemQty + itemToBeCheckedQty
        Dim newTotalPrice As Decimal = (newlItemQty * invDt.Rows(0)("ItemAvgPrice").ToString)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Update the location_inventory of the LOCATIONOUT with the new QTYs and Total
        Dim conn3 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        Dim rows3 As Integer
        Dim myCommand3 As SqlCommand = conn3.CreateCommand()

        Try

            conn3.Open()

            myCommand3.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & newlItemQty & "'
                , itemTotalPrice = '" & newTotalPrice & "' where (LocationID = '" & retrievedLocOUTID & "'
                and ItemID = '" & theItemID & "')"

            rows3 = myCommand3.ExecuteNonQuery()

        Catch ex As SqlException

            '    ' handle error
            Console.Write("Unable to Add")

        Finally

            conn3.Close()

        End Try

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim invDt2 As New DataTable
        orignalItemQty = 0
        originalTotalPrice = 0
        totalCostInItem = 0

        ' Get the current QTY of items from the location_inventory
        invDt2 = databaseObject.SelectMethode("Select ItemQty,ItemAvgPrice from db_owner.tbl_location_inventory where ( itemID = '" & theItemID & "'
        and LocationID = '" & retrievedLocINID & "')")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Add the previous qty and calculate the new total of item to the current qty in the location_inventory
        orignalItemQty = invDt2.Rows(0)("ItemQty").ToString
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ' Update the qty and the total of item in the location_inventory
        newlItemQty = orignalItemQty - itemToBeCheckedQty
        newTotalPrice = (newlItemQty * invDt.Rows(0)("ItemAvgPrice").ToString)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Update the location_inventory of the LOCATIONOUT with the new QTYs and Total
        Dim conn4 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        Dim rows4 As Integer
        Dim myCommand4 As SqlCommand = conn4.CreateCommand()

        Try

            conn4.Open()

            myCommand4.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & newlItemQty & "'
                , itemTotalPrice = '" & newTotalPrice & "' where (LocationID = '" & retrievedLocINID & "'
                and ItemID = '" & theItemID & "')"

            rows4 = myCommand4.ExecuteNonQuery()

        Catch ex As SqlException

            '    ' handle error
            Console.Write("Unable to Add")

        Finally

            conn4.Close()

        End Try


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


    End Sub

    'Check if the Quantity entered by the user is available in the location Inventory
    Sub checkItemQuantity()

        Dim selectedItemID As String
        Dim itemQuantity As Integer = 0
        Dim itemQtyFromInventory As Integer = 0
        Dim theQtyDifferance As Integer = 0

        For i As Integer = 0 To transactionData.Rows.Count - 2
            If transactionData.Rows(i).Cells(7).Value.ToString <> String.Empty Then


                totalItemsQuantity = 0
                selectedItemID = transactionData.Rows(i).Cells(7).Value.ToString()

                itemQtyFromInventory = getItemQtyFromInventory(selectedItemID)
                For j As Integer = 0 To transactionData.Rows.Count - 2

                    If selectedItemID = transactionData.Rows(j).Cells(7).Value.ToString() Then

                        totalItemsQuantity = transactionData.Rows(j).Cells(3).Value.ToString()
                        'totalItemsQuantity += itemQuantity

                    End If
                    theQtyDifferance = totalItemsQuantity - itemQtyFromInventory


                    If totalItemsQuantity > itemQtyFromInventory And toBeUpdated = False Then
                        invalidQty = True

                        MessageBox.Show("The Quantity entered for  " & transactionData.Rows(i).Cells(2).Value.ToString() & " exceeds the available in  " & transferOutDropBox.Text)
                        Exit Sub
                    End If
                Next
            End If

        Next



    End Sub
    '*******************************************

    'Update the Qtys after an Item is removed or updated
    Sub checkNewAndOldQty()

        Dim dt As New DataTable

        Dim itemID As Integer = 0
        Dim itemNewQty As Integer = 0
        Dim itemOldQty As Integer = 0
        Dim itemName As String = ""
        Dim itemTotalQty As Integer = 0
        Dim theQtyInGrid As Integer = 0



        For i As Integer = 0 To transactionData.Rows.Count - 2
            If transactionData.Rows(i).Cells(7).Value.ToString <> String.Empty Then


                theQtyInGrid = 0
                itemID = transactionData.Rows(i).Cells(7).Value
                theQtyInGrid = transactionData.Rows(i).Cells(3).Value


                itemTotalQty = 0
                itemOldQty = 0


                dt = databaseObject.SelectMethode("Select tbl_transactioned_Items.Quantity, tbl_transactioned_Items.ItemName 
                                               From db_owner.tbl_transactioned_Items, db_owner.tbl_transaction 
                                               Where (tbl_transactioned_Items.TransactionID ='" & retrievedTranID &
                                                   "' And db_owner.tbl_transaction.LocationID = '" & retrievedLocOUTID &
                                                   "' and tbl_transactioned_Items.ItemID = '" & itemID & "' and db_owner.tbl_transactioned_Items.Status = 1)")



                For j As Integer = 0 To dt.Rows.Count - 1

                    itemOldQty += dt.Rows(j)("Quantity").ToString()
                    itemName = dt.Rows(j)("ItemName").ToString()


                Next


                itemTotalQty = getItemQtyFromInventory(itemID) + itemOldQty

                'MessageBox.Show("The Total Quantity Available " & itemTotalQty & " THE QTY IN THE GRID " & theQtyInGrid)

                If theQtyInGrid > itemTotalQty Then

                    'MessageBox.Show(" The Quantity entered  for " & itemName & " exceeds the available in  " & transferOutDropBox.Text)
                    QtyNotEqual = True
                    Exit Sub

                End If
            End If

        Next







    End Sub
    '************************************************
    'On SaveTRANSACTION BTN CLICK
    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        isComplete = False
        invalidQty = False


        If transferInDropBox.Text <> String.Empty And transferOutDropBox.Text <> String.Empty Then

            If transactionData.Rows.Count < 2 Then
                MessageBox.Show("You Have to add at least one Item to the Above Transaction",
          "Invalid Transaction", MessageBoxButtons.OK,
           MessageBoxIcon.Warning)
                Exit Sub
            End If

            If transactionData.Rows.Count - 1 = 0 Then

                deleteNoQtyItem()
                Exit Sub
            End If
            checkEnteredIds()

            If retrievedLocINID = 0 Then
                MessageBox.Show("Make sure you entered a valid Location", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If retrievedLocOUTID = 0 Then
                MessageBox.Show("Make sure you entered a valid Location", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If




            If transferInDropBox.Text = transferOutDropBox.Text Then
                MessageBox.Show("Invalid Transfer Locations")
                Exit Sub
            End If
            checkItemQuantity()

            If invalidQty = True Then
                If toBeUpdated = False Then
                    MessageBox.Show("Please check the Quantities entered")
                    Exit Sub
                End If
            End If
            If toBeUpdated = True Then
                checkNewAndOldQty()
                'Exit Sub
                If QtyNotEqual Then
                    QtyNotEqual = False
                    MessageBox.Show("Please check the Quantities entered")
                    Exit Sub
                End If
                'If invalidQty = True Then
                '    checkNewAndOldQty()
                '    


                updateTheTransaction()
                toBeUpdated = False
                clearFields()

                transferInDropBox.Enabled = True
                transferOutDropBox.Enabled = True

                Exit Sub
            End If

            If recievedByField.Text <> String.Empty And approvedByField.Text <> String.Empty And DelivaryNumber.Text <> String.Empty Then
                isComplete = True
                isCompleteStatusText = "Complete"
                statusLabel.Text = "Complete"
            Else
                isComplete = False
                isCompleteStatusText = "InComplete"
                statusLabel.Text = "InComplete"
            End If

            insertIntoTransactions()
        Else
            'Console.Write("IN ELSE")
            MessageBox.Show("Make Sure You Filled All Required Fields ",
                            "Invalid Fields", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        ''''''''''''''''''''''''''''''''''''


        transferInDropBox.Enabled = True
        transferOutDropBox.Enabled = True
        statusLabel.Text = "-"
    End Sub
    '******************************

    'Insert a new Transaction after save transaction clicked, called only if the transaction doesn't exist
    Private Sub insertIntoTransactions()

        'Retrieving Location and Type ID
        retrievedTranTypeID = 0
        retrievedLocINID = 0
        retrievedLocOUTID = 0



        For Each pair As KeyValuePair(Of String, Integer) In locationINList

            Dim key As String = pair.Key
            If key = transferInDropBox.Text Then
                retrievedLocINID = pair.Value

            End If
        Next

        For Each pair As KeyValuePair(Of String, Integer) In locationOUTList

            Dim key As String = pair.Key
            If key = transferOutDropBox.Text Then
                retrievedLocOUTID = pair.Value

            End If
        Next

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Tra") Or key.Contains("tra") Then
                retrievedTranTypeID = pair.Value

            End If
        Next


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Adding Transaction to database

        Dim query As String = String.Empty
        query &= "INSERT INTO db_owner.tbl_transaction (TransactionID,ReferanceNumber,DelivaryNumber,TransferInLocationID,TransferOutLocationID,TotalQty,TotalCost,EnteryStatus,"
        query &= "StatusText,DateCreated,TransferInLocation,TransferOutLocation,ReceivedBy,ApprovedBy,Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate,LocationName)"
        query &= "VALUES (@TransactionID, @ReferanceNumber, @DelivaryNumber, @TransferInLocationID, @TransferOutLocationID, @TotalQty, @TotalCost,@EnteryStatus,@StatusText, @DateCreated,"
        query &= "@TransferInLocation, @TransferOutLocation,@ReceivedBy,@ApprovedBy, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate,@LocationName)"

        Using comm As New SqlCommand()
            With comm
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = query

                .Parameters.AddWithValue("@TransactionID", retrievedTranTypeID)
                .Parameters.AddWithValue("@DelivaryNumber", DelivaryNumber.Text)
                .Parameters.AddWithValue("@TransferInLocationID", retrievedLocINID)
                .Parameters.AddWithValue("@TransferOutLocationID", retrievedLocOUTID)
                .Parameters.AddWithValue("@TotalQty", allItemsQty.Text)
                .Parameters.AddWithValue("@TotalCost", allItemsPrice.Text)
                .Parameters.AddWithValue("@DateCreated", dateCreatedField.Value)
                .Parameters.AddWithValue("@TransferInLocation", transferInDropBox.Text)
                .Parameters.AddWithValue("@TransferOutLocation", transferOutDropBox.Text)
                .Parameters.AddWithValue("@EnteryStatus", isComplete)
                .Parameters.AddWithValue("@StatusText", isCompleteStatusText)
                .Parameters.AddWithValue("@ReceivedBy", recievedByField.Text)
                .Parameters.AddWithValue("@ApprovedBy", approvedByField.Text)
                .Parameters.AddWithValue("@Status", 1)
                .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                .Parameters.AddWithValue("@CreateDate", today)
                .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                .Parameters.AddWithValue("@RevisionDate", today)
                .Parameters.AddWithValue("@LocationName", transferInDropBox.Text)
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
    '********************************************
    'Enter Items in Transactioned Items
    Private Sub insertIntoItems()

        'Get the TransactionID and the totals from the ReferanceNumber

        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_transaction where (ReferanceNumber = SOME VALUE and Status = 1)")
        retrievedTranID = dt.Rows(0)("ID").ToString()
        retrievedTotalQty = dt.Rows(0)("TotalQty")
        retrievedTotalPrice = dt.Rows(0)("TotalCost")


        ''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim inventoryID As Integer = 0
        Dim inventoryName As String = String.Empty
        Dim itemQuantity As Integer = 0
        Dim itemUnitprice As Decimal = 0
        Dim itemTotalPrice As Decimal = 0

        If transactionData.Rows.Count = 1 Then
            deleteEmptyTransaction()
            Exit Sub
        End If
        Dim i As Integer

        For i = 0 To transactionData.Rows.Count - 2
            If transactionData.Rows(i).Cells(7).Value <> Nothing Then



                inventoryID = transactionData.Rows(i).Cells(7).Value
                inventoryName = transactionData.Rows(i).Cells(2).Value
                itemQuantity = transactionData.Rows(i).Cells(3).Value
                itemUnitprice = transactionData.Rows(i).Cells(4).Value
                itemTotalPrice = (itemQuantity * itemUnitprice)

                transactionData.Rows(i).Cells(0).Value = retrievedAssetID



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
                        .Parameters.AddWithValue("@ItemID", inventoryID)
                        .Parameters.AddWithValue("@ItemName", inventoryName)
                        .Parameters.AddWithValue("@Quantity", itemQuantity)
                        .Parameters.AddWithValue("@UnitAvgCost", itemUnitprice)
                        .Parameters.AddWithValue("@TotalCost", itemTotalPrice)
                        .Parameters.AddWithValue("@TransactionName", "Transfer")

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

                updateItemQtyInInventory(retrievedTranID, inventoryID, inventoryName, itemQuantity, itemUnitprice)
            End If
        Next
        'Exit Sub


        updateTransactions()
        clearFields()


        transferTransaGrid.DataSource = getTransferTransa()

        transferTransaGrid.Columns(0).Width = 70
        transferTransaGrid.Columns(1).Width = 100
        transferTransaGrid.Columns(2).Width = 80

        transferTransaGrid.Columns(5).Visible = False
        transferTransaGrid.Columns(6).Visible = False
        transferTransaGrid.Columns(7).Visible = False
        transferTransaGrid.Columns(8).Visible = False
        transferTransaGrid.Columns(9).Visible = False
        transferTransaGrid.Columns(10).Visible = False
        transferTransaGrid.Columns(11).Visible = False




    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    'Function to get the avarage item Price from Purchase
    Function getItemUnitPriceFromPurchase(selectedItemID As String) As Integer

        Dim dt As New DataTable
        Dim allAvgCost As Decimal = 0

        dt = databaseObject.SelectMethode("Select ItemAvgPrice 
                            From db_owner.tbl_location_inventory Where (db_owner.tbl_location_Inventory.LocationID = '" & retrievedLocOUTID & "'
                            and ItemID = '" & selectedItemID & "')")

        For i = 0 To dt.Rows.Count - 1
            'locationDropBox.Items.Add(dt.Rows(i)("Name").ToString())
            allAvgCost += dt.Rows(i)("ItemAvgPrice").ToString()

        Next

        Return allAvgCost
    End Function
    '*******************************************


    Sub insertNewItemInInventory(retrievedTranID As String, inventoryID As String, itemName As String, itemQuantity As Integer, itemUnitPrice As Decimal, totalOriginal As Decimal)

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
                    .Parameters.AddWithValue("@LocationID", retrievedLocINID)
                    .Parameters.AddWithValue("@LocationName", transferInDropBox.Text)

                    .Parameters.AddWithValue("@ItemID", inventoryID)
                    .Parameters.AddWithValue("@ItemName", itemName)
                    .Parameters.AddWithValue("@ItemQty", itemQuantity)
                    .Parameters.AddWithValue("@ItemAvgPrice", itemUnitPrice)
                    .Parameters.AddWithValue("@ItemTotalPrice", totalOriginal)

                End With

                conn.Open()
                comm.ExecuteNonQuery()
                conn.Close()


            End Using



        End Using

    End Sub


    'Adding the transfered items to the LOcation INventory..
    Sub updateItemQtyInInventory(retrievedTranID As String, inventoryID As String, inventoryName As String, itemQuantity As Integer, itemUnitPrice As Decimal)

        allQty = getItemQtyFromInventory(inventoryID)
        theUpdatedQuantity = allQty - itemQuantity
        unitPrice = (getItemUnitPriceFromPurchase(inventoryID) + itemUnitPrice) / 2
        updatedTotalCost = theUpdatedQuantity * unitPrice

        inventoryToUseForDelete = inventoryID
        unitQtyForUpdating = itemQuantity
        Dim totalOriginal = itemQuantity * itemUnitPrice

        Dim itemFound As Boolean = False

        Dim sDt As New DataTable
        sDt = databaseObject.SelectMethode("Select ItemID, LocationID from db_owner.tbl_location_inventory")

        For i As Integer = 0 To sDt.Rows.Count - 1
            If sDt.Rows(i)("ItemID") = inventoryID And sDt.Rows(i)("LocationID") = retrievedLocINID Then
                itemFound = True
            End If
        Next

        If itemFound = False Then
            'If the item is new
            insertNewItemInInventory(retrievedTranID, inventoryID, inventoryName, itemQuantity, itemUnitPrice, totalOriginal)
        ElseIf itemFound = True Then
            'if item exists --> to be updated
            updateExistingItemInInventory(retrievedTranID, inventoryID, inventoryName, itemQuantity, itemUnitPrice, totalOriginal)
        End If

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try
            conn.Open()
            myCommand.CommandText = "Update  db_owner.tbl_location_inventory Set ItemQty = '" & theUpdatedQuantity & "',
            ItemAvgPrice = '" & unitPrice & "', ItemTotalPrice = '" & updatedTotalCost & "'  where (LocationID = '" & retrievedLocOUTID &
            "' and ItemID = '" & inventoryID & "' )"
            rows = myCommand.ExecuteNonQuery()
        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Add")

        Finally

            conn.Close()

        End Try

        Dim theItemTotalPrice As Decimal = itemQuantity * itemUnitPrice

    End Sub


    'Update existing Item in the Inventory
    Sub updateExistingItemInInventory(retrievedTranID As String, inventoryID As Integer, inventoryName As String, itemQuantity As Integer, itemUnitPrice As Decimal, totalOriginal As Decimal)


        Dim dt As New DataTable
        Dim theItemWholeQuantity As Integer = 0


        dt = databaseObject.SelectMethode("Select ItemQty from db_owner.tbl_location_inventory where(LocationID = '" & retrievedLocINID & "' and ItemID = '" & inventoryID & "')")
        For i = 0 To dt.Rows.Count - 1
            'locationDropBox.Items.Add(dt.Rows(i)("Name").ToString())
            theItemWholeQuantity += dt.Rows(i)("ItemQty").ToString()

        Next


        Dim theQtyToBeUpdated = theItemWholeQuantity + itemQuantity
        Dim theUnitPriceToBeUpdated = (getItemUnitPriceFromPurchase(inventoryID) + itemUnitPrice) / 2
        Dim theTotalCostToBeUpdated = theUpdatedQuantity * unitPrice

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update  db_owner.tbl_location_inventory Set ItemQty = '" & theQtyToBeUpdated & "',
            ItemAvgPrice = '" & theUnitPriceToBeUpdated & "', ItemTotalPrice = '" & theTotalCostToBeUpdated & "'  
            where (LocationID = '" & retrievedLocINID & "' and ItemID = '" & inventoryID & "' )"

            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Add")

        Finally

            conn.Close()

        End Try

    End Sub
    ' Add Entered Items to the Locations Inventory
    Sub addToTheInventory(theItemID As Integer, theItemName As String, theItemQuantity As Integer, theItemUnitprice As Decimal, theItemTotalPrice As Decimal)
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
                    .Parameters.AddWithValue("@LocationID", retrievedLocINID)
                    .Parameters.AddWithValue("@LocationName", transferInDropBox.Text)

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


    'if the Item Qty is 0 Delete the Item from transfer transaction
    Sub deleteNoQtyItem()

        transferInDropBox.Enabled = True
        transferOutDropBox.Enabled = True

        Dim dt As New DataTable
        dt = databaseObject.SelectMethode("Select ItemID, Quantity,UnitAvgCost, TotalCost from db_owner.tbl_transactioned_Items where
        (TransactionID = '" & retrievedTranID & "' and Status = 1)")
        For i As Integer = 0 To dt.Rows.Count - 1

            theItemID = dt.Rows(i)("ItemID").ToString
            theItemQuantity = dt.Rows(i)("Quantity").ToString
            theItemUnitprice = dt.Rows(i)("UnitAvgCost").ToString
            theItemTotalPrice = dt.Rows(i)("TotalCost").ToString

            Dim sDt As New DataTable
            sDt = databaseObject.SelectMethode("Select ItemID, ItemQty,ItemAvgPrice, ItemTotalPrice from db_owner.tbl_location_inventory where
            (LocationID = '" & retrievedLocINID & "' and ItemID = '" & theItemID & "')")

            theCalculatedInventoryItemQty = sDt.Rows(0)("ItemQty").ToString - theItemQuantity
            theCalculatedInventoryItemQty2 = sDt.Rows(0)("ItemQty").ToString + theItemQuantity
            theCalculatedInventoryItemAvgPrice = sDt.Rows(0)("ItemAvgPrice").ToString
            theCalculatedInventoryItemTotalPrice = (theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice)
            theCalculatedInventoryItemTotalPrice2 = (theCalculatedInventoryItemQty2 * theCalculatedInventoryItemAvgPrice)


            updateLocationInventory()
            Dim sDt2 As New DataTable
            sDt2 = databaseObject.SelectMethode("Select ItemID, ItemQty,ItemAvgPrice, ItemTotalPrice from db_owner.tbl_location_inventory where
            (LocationID = '" & retrievedLocOUTID & "' and ItemID = '" & theItemID & "')")


            theCalculatedInventoryItemQty2 = sDt.Rows(0)("ItemQty").ToString + theItemQuantity
            theCalculatedInventoryItemAvgPrice = sDt.Rows(0)("ItemAvgPrice").ToString
            theCalculatedInventoryItemTotalPrice2 = (theCalculatedInventoryItemQty2 * theCalculatedInventoryItemAvgPrice)

            updateLocationInventory2()
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
    End Sub
    'Update the Transaction after editing in Items 
    Private Sub updateTransactions()



        'Dim referanceNumToBeDeleted As String = referanceLabel.Text
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_transaction Set TotalQty = '" & allItemsQty.Text & "', TotalCost = '" & allItemsPrice.Text & "',
            EnteryStatus = '" & isComplete & "',  where (ID = '" & retrievedTranID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Add")

        Finally

            conn.Close()

        End Try


    End Sub

    'Initialize after Cancel is clicked
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        toBeUpdated = False
        clearFields()
        transferInDropBox.Enabled = True
        transferOutDropBox.Enabled = True
        statusLabel.Text = "-"
    End Sub

    'Get the Items from the location selected from the transferOut dropbox
    Private Sub transferOutDropBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles transferOutDropBox.SelectedIndexChanged
        transactionData.Rows.Clear()
        transactionData.AllowUserToAddRows = True
        getItems()

    End Sub
    '******************************************

    'For handeling errors in the gridview
    Private Sub transactionData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles transactionData.DataError

    End Sub
    '**************************************

    'Calculate the totals after cell text change
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
    '*********************************************

    'CAlled after delete transaction btn is called to delete all selected transaction item and the transaction
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        deleteNoQtyItem()
        statusLabel.Text = "-"
    End Sub
    '******************************************

    'update the location_inventory of Location IN/OUT after somr change or adding in the Items
    Sub updateLocationInventory()

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & theCalculatedInventoryItemQty & "',
            ItemAvgPrice = '" & theCalculatedInventoryItemAvgPrice & "', ItemTotalPrice = '" & theCalculatedInventoryItemTotalPrice & "'
            where(ItemID = '" & theItemID & "' and LocationID = '" & retrievedLocINID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            'MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try
    End Sub
    '****************************************************
    'update the location_inventory of Location OUT/IN after somr change or adding in the Items
    Sub updateLocationInventory2()


        Dim tDt As New DataTable
        tDt = databaseObject.SelectMethode("Select ItemID, ItemQty,ItemAvgPrice, ItemTotalPrice from db_owner.tbl_location_inventory where
            (LocationID = '" & retrievedLocOUTID & "' and ItemID = '" & theItemID & "')")

        theCalculatedInventoryItemQty2 = tDt.Rows(0)("ItemQty").ToString + theItemQuantity
        theCalculatedInventoryItemAvgPrice = tDt.Rows(0)("ItemAvgPrice").ToString
        theCalculatedInventoryItemTotalPrice = (theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice)


        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & theCalculatedInventoryItemQty2 & "',
            ItemAvgPrice = '" & theCalculatedInventoryItemAvgPrice & "', ItemTotalPrice = '" & theCalculatedInventoryItemTotalPrice2 & "'
            where(ItemID = '" & theItemID & "' and LocationID = '" & retrievedLocOUTID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            'MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try
    End Sub

    'Called After delete btn is clicked and all items of the selected transactions are deleted
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

            transferTransaGrid.DataSource = getTransferTransa()
            transferTransaGrid.Columns(0).Width = 70
            transferTransaGrid.Columns(1).Width = 100
            transferTransaGrid.Columns(2).Width = 80
            transferTransaGrid.Columns(5).Visible = False
            transferTransaGrid.Columns(6).Visible = False
            transferTransaGrid.Columns(7).Visible = False
            transferTransaGrid.Columns(8).Visible = False
            transferTransaGrid.Columns(9).Visible = False
            transferTransaGrid.Columns(10).Visible = False
            transferTransaGrid.Columns(11).Visible = False

        End Try
        retrievedTranID = 0
    End Sub


    'Handle Error in the gridview
    Private Sub transferTransaGrid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles transferTransaGrid.DataError

    End Sub



    '***************************************

End Class