Imports System.Data.SqlClient

Public Class assetPurchaseTransaction

    Dim logedInUserID As Integer = My.Settings.userID

    Dim databaseObject As New DatabaseAccesClass
    Dim locationList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))
    Dim itemsList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))
    Dim typeList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))
    Dim vendorList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))
    Dim addedItemsIDList As List(Of KeyValuePair(Of String, String)) =
    New List(Of KeyValuePair(Of String, String))


    Dim retrievedTranTypeID As Integer = -1
    Dim retrievedLocID As Integer = -1
    Dim retrievedVendorID As Integer = -1
    Dim retrievedItemID As Integer = -1
    Dim retrievedUserItemID As String = String.Empty
    Dim cnt As Integer = 0
    Dim retrievedTranID As Integer = 0

    Dim theCalculatedInventoryItemQty As Integer = 0
    Dim theCalculatedInventoryItemAvgPrice As Decimal = 0
    Dim theCalculatedInventoryItemTotalPrice As Decimal = 0
    Dim retrievedTotalQty As Integer = 0
    Dim retrievedTotalPrice As Double = 0

    Dim theAssetID As Integer = 0
    Dim theAssetName As String = String.Empty
    Dim theAssetQuantity As Integer = 0
    Dim theAssetUnitprice As Decimal = 0
    Dim theAssetTotalPrice As Decimal = 0
    Dim theAssetBarcode As String = String.Empty
    Dim theAssetAcquisationDate As Date
    Dim currencyChosen As String = "$"
    Dim calculatedTotalQty As Double = 0
    Dim calculatedTotalCost As Double = 0
    Dim theTranID As Integer = -1
    Dim theItemBarcodeID As Integer = -1
    Dim theItemTransID As Integer = -1
    Dim theDate As String = String.Empty




    Dim isComplete As Boolean = True
    Dim itemsExist As Boolean = False
    Dim toBeUpdated As Boolean = False
    Dim toBeDeleted As Boolean = False





    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

    Private Sub assetPurchaseTransaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        My.Settings.fromAssetImported = False
        My.Settings.fromAssetPurchase = False
        For i As Integer = 0 To transactionData.Rows.Count - 1
            transactionData.Rows(i).Cells(6).Value = "Add Barcodes"
        Next


        'Setting dropdown boxes to prevent user from editing
        currencyField.DropDownStyle = ComboBoxStyle.DropDownList
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Font color and size for the gridview and groupBox
        GroupBox1.ForeColor = Color.DarkRed
        transactionData.Font = New Font("Gadugi", 8)
        purchaseTransaGrid.Font = New Font("Gadugi", 8)
        ''''''''''''''''''''''''''''''''''''''''''''''''''

        'Initializing fields
        statusLabel.Text = "-"
        allItemsQty.Text = "0"
        allItemsPrice.Text = "0"
        '''''''''''''''''''''''''''''''

        'Retrieving saved data from database

        getLocations()
        getItems()
        getTypes()
        getVendors()
        getUserItems()
        ''''''''''''''''''''''''''''''''''''

        'Get all Transactions and displaying them in gridView
        purchaseTransaGrid.Rows.Clear()
        purchaseTransaGrid.DataSource = getPurchaseTransa()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False


        '''''''''''''''''''''
        theDate = Format(Today, "MMM d,yyyy")

        transactionData.Rows(transactionData.Rows.Count - 1).Cells(7).Value = theDate
        'If fromAllTrans = True And selectedTransaction <> -1 Then
        '    retrieveTransItems(selectedTransaction)

        '    My.Settings.fromAllTrans = False
        '    My.Settings.selectedTransaction = -1
        '    My.Settings.Save()
        'End If
    End Sub


    Function getPurchaseTransa()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next
        Dim dtPurchaseTransactions As New DataTable

        dtPurchaseTransactions = databaseObject.SelectMethode("Select ID,locationName As [Location], VendorName As [Vendor],
            totalQty as [Total Qty], totalPrice as [TotalPrice],locationID, vendorID,currancy,acquisationDate,compStatus
            FROM db_owner.tbl_asset_transactions where (isForImported IS NULL )")
        'where (ID = '" & retrievedTranTypeID & "' and Status = 1)

        Return dtPurchaseTransactions

    End Function


    '**********************************

    'Retrieving saved data from database

    Private Sub getLocations()


        locationDropBox.Items.Clear()
        locationList.Clear()



        Dim dt As DataTable = New DataTable


        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset_Location where Status = 1")
        For i = 0 To dt.Rows.Count - 1
            locationList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("LocationName").ToString(), dt.Rows(i)("ID").ToString()))

        Next


        autoCompleteLocations()
    End Sub
    Private Sub getUserItems()

        addedItemsIDList.Clear()


        Dim dt As DataTable = New DataTable
        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            addedItemsIDList.Add(New KeyValuePair(Of String, String)(dt.Rows(i)("assetName").ToString(), dt.Rows(i)("assetID").ToString()))



        Next





    End Sub
    Private Sub getItems()
        inventoryNameField.Items.Clear()
        itemsList.Clear()


        Dim dt As DataTable = New DataTable
        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            itemsList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("assetName").ToString(), dt.Rows(i)("ID").ToString()))
        Next

        autoCompleteItems()

    End Sub
    Private Sub getTypes()
        typeList.Clear()


        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_transactionCode where Status = 1")
        For i = 0 To dt.Rows.Count - 1
            typeList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("TransactionName").ToString(), dt.Rows(i)("ID").ToString()))

        Next

    End Sub
    Private Sub getVendors()



        vendorNameField.Items.Clear()
        vendorList.Clear()

        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset_vendor where Status = 1 ")



        For i = 0 To dt.Rows.Count - 1
            vendorList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("VendorName").ToString(), dt.Rows(i)("ID").ToString()))
        Next

        autoCompleteVendors()

    End Sub

    Sub autoCompleteItems()

        Dim dt As DataTable = New DataTable()

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset where Status = 1")

        Dim row As DataRow = dt.NewRow()
        dt.Rows.InsertAt(row, 0)

        inventoryNameField.DataSource = dt
        inventoryNameField.DisplayMember = "assetName"
        inventoryNameField.ValueMember = "assetName"
    End Sub
    Sub autoCompleteLocations()

        Dim dt As DataTable = New DataTable()


        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset_Location where Status = 1")
        Dim row As DataRow = dt.NewRow()

        dt.Rows.InsertAt(row, 0)


        locationDropBox.DataSource = dt
        locationDropBox.DisplayMember = "LocationName"
        locationDropBox.ValueMember = "LocationName"


        locationDropBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        locationDropBox.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub
    Sub autoCompleteVendors()

        Dim dt As DataTable = New DataTable()

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset_vendor where Status = 1")
        Dim row As DataRow = dt.NewRow()

        dt.Rows.InsertAt(row, 0)


        vendorNameField.DataSource = dt
        vendorNameField.DisplayMember = "VendorName"
        vendorNameField.ValueMember = "VendorName"


        vendorNameField.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        vendorNameField.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    '******************************************

    'Force fields to accept only numbers

    Private Sub qtyField_KeyPress(sender As Object, e As KeyPressEventArgs)
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") _
         AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub priceField_KeyPress(sender As Object, e As KeyPressEventArgs)

        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Or e.KeyChar = ChrW(8))
    End Sub

    '***************************************


    'Initialize all fields

    Sub clearFields()

        statusLabel.Text = "-"
        locationDropBox.Text = ""
        dateCreatedField.Value = Today
        vendorIDLabel.Text = "-"
        vendorNameField.Text = ""
        currencyField.Text = "US Dollars"
        transactionData.Rows.Clear()
        transactionData.AllowUserToAddRows = True
        allItemsPrice.Text = 0
        allItemsQty.Text = 0

    End Sub
    '***********************

    'check if some values are valid
    Sub checkEnteredIds()

        retrievedLocID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationList

            Dim key As String = pair.Key
            If key = locationDropBox.Text Then
                retrievedLocID = pair.Value
            End If
        Next


        retrievedVendorID = 0
        For Each pair As KeyValuePair(Of String, Integer) In vendorList

            Dim key As String = pair.Key
            If key = vendorNameField.Text Then
                retrievedVendorID = pair.Value

            End If
        Next
        vendorIDLabel.Text = retrievedVendorID
    End Sub
    '**************************************

    'Retrieve the Vendor ID of selected vendor from vendorNameField and changing the transaction completion status accordingly
    Private Sub vendorNameField_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles vendorNameField.SelectedIndexChanged


        retrievedVendorID = 0

        For Each pair As KeyValuePair(Of String, Integer) In vendorList

            Dim key As String = pair.Key
            If key = vendorNameField.Text Then
                retrievedVendorID = pair.Value
            End If

        Next

        If retrievedVendorID > 0 And retrievedLocID > 0 Then

            isComplete = True
            statusLabel.Text = "Complete"

        Else
            isComplete = False
            statusLabel.Text = "InComplete"
        End If

        vendorIDLabel.Text = retrievedVendorID

    End Sub

    '***********************************


    'Calculating total and avarage Price on totalPrice onclick
    Private Sub totalPrice_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)

        If transactionData.CurrentCell.ColumnIndex <> 5 And transactionData.CurrentCell.ColumnIndex <> 6 _
                                And transactionData.CurrentCell.ColumnIndex <> 7 Then


            Dim textBox As TextBox = CType(sender, TextBox)

            Dim updatedUnitPrice As Decimal
            Dim alreadyAdded As Boolean
            Dim transactionTotalQuantity As Integer = 0
            Dim transactionTotalPrice As Decimal = 0
            Dim currentItemID As Integer = 0
            Dim updatedQty As Integer = 0

            Dim updatedTotalPrice As Decimal = 0
            Dim currentIndex As Integer = -1
            Dim foundItem As Boolean = False

            If e.KeyCode = Keys.Tab Then
                For i As Integer = 0 To transactionData.Rows.Count - 1

                    If transactionData.Rows(i).Cells(9).Value = Nothing Then
                        alreadyAdded = True
                    End If

                Next



                If textBox.Text <> String.Empty And transactionData.CurrentRow.Cells(9).Value <> Nothing Then
                    updatedUnitPrice = textBox.Text


                    currentItemID = transactionData.CurrentRow.Cells(9).Value
                    updatedQty = transactionData.CurrentRow.Cells(3).Value
                    'updatedTotalPrice = transactionData.CurrentRow.Cells(5).Value
                    updatedTotalPrice = transactionData.CurrentRow.Cells(3).Value * updatedUnitPrice
                    currentIndex = transactionData.CurrentRow.Index
                    transactionData.CurrentRow.Cells(5).Value = updatedTotalPrice
                    transactionTotalQuantity = 0
                    transactionTotalPrice = 0

                    For i As Integer = 0 To transactionData.Rows.Count - 2
                        If transactionData.Rows(i).Cells(9).Value.ToString <> String.Empty Then



                            If currentItemID = transactionData.Rows(i).Cells(9).Value And currentIndex <> i Then
                                transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(4).Value * transactionData.Rows(i).Cells(3).Value
                                updatedTotalPrice = transactionData.Rows(i).Cells(5).Value + updatedTotalPrice
                                transactionData.Rows(i).Cells(5).Value = (Math.Round((transactionData.Rows(i).Cells(5).Value), 2)).ToString
                                'updatedTotalPrice = transactionData.Rows(i).Cells(5).Value

                                transactionData.Rows(i).Cells(3).Value += updatedQty

                                updatedQty = transactionData.Rows(i).Cells(3).Value
                                'transactionData.Rows(i).Cells(4).Value = (transactionData.Rows(i).Cells(4).Value + updatedUnitPrice) / 2
                                'transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(3).Value * transactionData.Rows(i).Cells(4).Value

                                transactionData.Rows(i).Cells(4).Value = updatedTotalPrice / updatedQty
                                transactionData.Rows(i).Cells(4).Value = (Math.Round((transactionData.Rows(i).Cells(4).Value), 2)).ToString
                                updatedUnitPrice = transactionData.Rows(i).Cells(4).Value
                                transactionData.Rows(i).Cells(5).Value = updatedUnitPrice * updatedQty
                                transactionData.Rows(i).Cells(5).Value = (Math.Round((transactionData.Rows(i).Cells(5).Value), 2)).ToString
                                updatedTotalPrice = updatedTotalPrice - transactionData.Rows(i).Cells(5).Value
                                foundItem = True
                            End If
                            transactionTotalQuantity += transactionData.Rows(i).Cells(3).Value
                            transactionTotalPrice += transactionData.Rows(i).Cells(5).Value
                        End If
                    Next

                    If foundItem = True Then

                        transactionData.Rows(currentIndex).Cells(3).Value = 0
                        transactionData.Rows(currentIndex).Cells(5).Value = 0
                        transactionData.Rows.RemoveAt(currentIndex)

                    End If

                    If alreadyAdded = False Then
                        theDate = Format(Today, "MMM d,yyyy")
                        transactionData.Rows.Add("", "", "", Nothing, Nothing, Nothing, "Add Barcodes", theDate, Nothing, Nothing)
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

        End If
    End Sub

    'Get asset ID after selecting Item
    Private Sub inventoryNameField_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim combo As ComboBox = CType(sender, ComboBox)
        transactionData.CurrentRow.Cells(2).Value = combo.SelectedValue

        retrievedItemID = 0

        For Each pair As KeyValuePair(Of String, Integer) In itemsList

            Dim key As String = pair.Key
            If key = transactionData.CurrentRow.Cells(2).Value.ToString Then
                retrievedItemID = pair.Value
            End If

        Next

        transactionData.CurrentRow.Cells(9).Value = retrievedItemID

        Dim j As Integer
        For j = 0 To transactionData.Rows.Count - 1
            For Each pair As KeyValuePair(Of String, String) In addedItemsIDList

                Dim key As String = pair.Key
                If transactionData.Rows(j).Cells(2).Value.ToString IsNot Nothing Then

                    If key = transactionData.Rows(j).Cells(2).Value.ToString Then

                        retrievedUserItemID = pair.Value

                        My.Settings.barcodesID = retrievedItemID
                        My.Settings.barcodeTrans = retrievedTranID

                    End If

                End If

            Next

            transactionData.Rows(j).Cells(1).Value = retrievedUserItemID
        Next



    End Sub
    '****************************************

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

    '****************************************

    'Force date field to accept only numbers and /

    Private Sub dateField_KeyPress(sender As Object, e As KeyPressEventArgs)

        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "/" Or e.KeyChar = ChrW(8))
    End Sub
    '*****************************************

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
                Dim textBox As TextBox = e.Control

                'RemoveHandler textBox.KeyDown, New KeyEventHandler(AddressOf totalPrice_keyDown)
                'AddHandler textBox.KeyDown, New KeyEventHandler(AddressOf totalPrice_keyDown)

                RemoveHandler textBox.PreviewKeyDown, New PreviewKeyDownEventHandler(AddressOf totalPrice_PreviewKeyDown)
                AddHandler textBox.PreviewKeyDown, New PreviewKeyDownEventHandler(AddressOf totalPrice_PreviewKeyDown)

            End If

            If transactionData.CurrentCell.ColumnIndex = 3 Then


                Dim qtyField As TextBox = e.Control


                If (qtyField IsNot Nothing) Then
                    RemoveHandler qtyField.KeyPress, New KeyPressEventHandler(AddressOf qtyField_KeyPress)
                    AddHandler qtyField.KeyPress, New KeyPressEventHandler(AddressOf qtyField_KeyPress)

                    'RemoveHandler qtyField.TextChanged, New EventHandler(AddressOf updatePrices)
                    'AddHandler qtyField.TextChanged, New EventHandler(AddressOf updatePrices)
                End If


            End If

            If transactionData.CurrentCell.ColumnIndex = 7 Then


                Dim dateField As TextBox = e.Control


                If (qtyField IsNot Nothing) Then
                    RemoveHandler dateField.KeyPress, New KeyPressEventHandler(AddressOf dateField_KeyPress)
                    AddHandler dateField.KeyPress, New KeyPressEventHandler(AddressOf dateField_KeyPress)

                    'RemoveHandler qtyField.TextChanged, New EventHandler(AddressOf updatePrices)
                    'AddHandler qtyField.TextChanged, New EventHandler(AddressOf updatePrices)
                End If


            End If
        End If



    End Sub
    '********************************

    'Btn Clicks in the DatagridView
    Private Sub transactionData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles transactionData.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)
        Dim alreadyAdded As Boolean = False
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 0 Then
            If transactionData.CurrentRow.Cells(9).Value IsNot Nothing And
                transactionData.CurrentRow.Cells(2).Value IsNot Nothing And
                transactionData.CurrentRow.Cells(3).Value IsNot Nothing Then



                If transactionData.CurrentRow.Cells(4).Value Is Nothing Or transactionData.CurrentRow.Cells(4).Value = 0 Then
                    transactionData.CurrentRow.Cells(4).Value = 0
                End If
                'If transactionData.CurrentRow.Cells(5).Value Is Nothing Or transactionData.CurrentRow.Cells(5).Value = 0 Then
                Dim calculatedTotal As Decimal = (transactionData.CurrentRow.Cells(3).Value * transactionData.CurrentRow.Cells(4).Value)
                transactionData.CurrentRow.Cells(5).Value = calculatedTotal
                'End If

                'transactionData.AllowUserToAddRows = True
                For i As Integer = 0 To transactionData.Rows.Count - 1

                    If transactionData.Rows(i).Cells(9).Value = Nothing Then
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



                currentItemID = transactionData.CurrentRow.Cells(9).Value
                updatedQty = transactionData.CurrentRow.Cells(3).Value
                updatedUnitPrice = transactionData.CurrentRow.Cells(4).Value
                updatedTotalPrice = transactionData.CurrentRow.Cells(5).Value
                currentIndex = transactionData.CurrentRow.Index

                'Dim singleItemID As Integer = 0
                'Dim singleItemQty As Integer = 0
                'Dim singleItemPrice As Decimal = 0
                'singleItemID = transactionData.Rows(i).Cells(1).Value
                'For j As Integer = 0 To transactionData.Rows.Count - 1
                '    If singleItemID = transactionData.Rows(j).Cells(1).Value Then
                '        singleItemQty += transactionData.Rows(j).Cells(1).Value
                '        singleItemPrice += transactionData.Rows(j).Cells(1).Value
                '    End If
                'Next


                For i As Integer = 0 To transactionData.Rows.Count - 2
                    If transactionData.Rows(i).Cells(9).Value <> Nothing Then


                        'If currentItemID = transactionData.Rows(i).Cells(7).Value And currentIndex <> i Then
                        '    transactionData.Rows(i).Cells(3).Value += updatedQty
                        '    transactionData.Rows(i).Cells(4).Value = (transactionData.Rows(i).Cells(4).Value + updatedUnitPrice) / 2
                        '    transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(3).Value * transactionData.Rows(i).Cells(4).Value
                        '    foundItem = True
                        'End If

                        If currentItemID = transactionData.Rows(i).Cells(9).Value And currentIndex <> i Then
                            transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(4).Value * transactionData.Rows(i).Cells(3).Value
                            updatedTotalPrice = transactionData.Rows(i).Cells(5).Value + updatedTotalPrice
                            transactionData.Rows(i).Cells(5).Value = (Math.Round((transactionData.Rows(i).Cells(5).Value), 2)).ToString
                            'updatedTotalPrice = transactionData.Rows(i).Cells(5).Value

                            transactionData.Rows(i).Cells(3).Value += updatedQty

                            updatedQty = transactionData.Rows(i).Cells(3).Value
                            'transactionData.Rows(i).Cells(4).Value = (transactionData.Rows(i).Cells(4).Value + updatedUnitPrice) / 2
                            'transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(3).Value * transactionData.Rows(i).Cells(4).Value

                            transactionData.Rows(i).Cells(4).Value = updatedTotalPrice / updatedQty
                            transactionData.Rows(i).Cells(4).Value = (Math.Round((transactionData.Rows(i).Cells(4).Value), 2)).ToString
                            updatedUnitPrice = transactionData.Rows(i).Cells(4).Value
                            transactionData.Rows(i).Cells(5).Value = updatedUnitPrice * updatedQty
                            transactionData.Rows(i).Cells(5).Value = (Math.Round((transactionData.Rows(i).Cells(5).Value), 2)).ToString
                            foundItem = True
                        End If

                        'transactionTotalQuantity += transactionData.Rows(i).Cells(3).Value
                        'transactionTotalPrice += transactionData.Rows(i).Cells(5).Value
                    End If
                Next
                If foundItem = True Then
                    transactionData.Rows(currentIndex).Cells(3).Value = 0
                    transactionData.Rows(currentIndex).Cells(5).Value = 0
                    transactionData.Rows.RemoveAt(currentIndex)

                End If

                'allItemsQty.Text = transactionTotalQuantity
                'allItemsPrice.Text = transactionTotalPrice
                itemsExist = True
            Else

                MessageBox.Show("Make sure all required fields for the Inventory are filled", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        End If


        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 7 Then

            My.Settings.fromPurchase = True
            My.Settings.fromTransfer = False
            Dim pickerForm = New pickDateDailog
            pickerForm.Show()


        End If

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 6 Then


            My.Settings.fromAssetImported = False
            My.Settings.fromAssetPurchase = True

            Dim barcodeAdd = New barcodeForm
            Dim dt As New DataTable
            Dim theItemID As Integer = transactionData.CurrentRow.Cells(9).Value
            Dim theSelectedBarcode As String
            My.Settings.barcodeQty = transactionData.CurrentRow.Cells(3).Value




            If transactionData.CurrentRow.Cells(9).Value = Nothing Then

                MessageBox.Show("Please Select an Item first")
                Exit Sub

            Else

                barcodeAdd.barcodeListBox.Items.Clear()
                barcodeAdd.barcodeList.Clear()

                Dim theTransID As Integer = -1

                theItemTransID = retrievedTranID
                If retrievedTranID > 0 Then

                    theTransID = retrievedTranID

                Else


                    dt = databaseObject.SelectMethode("Select MAX(ID) as [ID] from db_owner.tbl_asset_transactions")

                    If dt.Rows.Count - 1 = 0 Then

                        theTransID = 0
                    Else
                        theTransID = dt.Rows(0)("ID") + 1
                    End If



                End If

                My.Settings.barcodesID = theItemID
                My.Settings.barcodeTrans = theTransID



                Dim dt2 As New DataTable
                dt2 = databaseObject.SelectMethode("Select itemBarcode from db_owner.tbl_asset_barcodes where itemID = '" & theItemID &
                                                      "' and transID = '" & theTransID & "'")


                If dt2.Rows.Count > 0 Then

                    For i As Integer = 0 To dt2.Rows.Count - 1

                        theSelectedBarcode = dt2.Rows(i)("itemBarcode").ToString
                        barcodeAdd.barcodeListBox.Items.Add(theSelectedBarcode)
                        barcodeAdd.barcodeList.Add(theSelectedBarcode)


                    Next

                End If

                barcodeAdd.Show()

            End If
        End If

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 8 Then



            theItemBarcodeID = transactionData.CurrentRow.Cells(9).Value
            theItemTransID = retrievedTranID


            deleteBarcodesOfOneItem()
            If transactionData.CurrentRow.Cells(9).Value IsNot Nothing And
                    transactionData.CurrentRow.Cells(2).Value IsNot Nothing And
                    transactionData.CurrentRow.Cells(3).Value IsNot Nothing Then

                toBeDeleted = True

                Dim index As Integer = transactionData.CurrentCell.RowIndex
                transactionData.Rows.RemoveAt(index)
                transactionData.AllowUserToAddRows = False
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

                transactionData.CurrentRow.Cells(9).Value = Nothing
                transactionData.CurrentRow.Cells(2).Value = Nothing
                transactionData.CurrentRow.Cells(3).Value = Nothing
                transactionData.CurrentRow.Cells(4).Value = Nothing
                transactionData.CurrentRow.Cells(5).Value = Nothing

            End If


        End If



    End Sub

    'Delet Barcodes of a deleted single Item

    Sub deleteBarcodesOfOneItem()

        Dim rows1 As Integer
        Dim myCommand1 As SqlCommand = conn.CreateCommand()


        Try

            conn.Open()

            myCommand1.CommandText = "Delete  From db_owner.tbl_asset_barcodes where (itemID = '" & theItemBarcodeID & "' 
                and transID = '" & theItemTransID & "')"

            rows1 = myCommand1.ExecuteNonQuery()



        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Delete")


        Finally
            conn.Close()
        End Try

    End Sub

    '************************************

    Private Sub transactionData_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles transactionData.UserAddedRow
        transactionData.AllowUserToAddRows = False
    End Sub

    'For Datagridview Btns Pics
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

        If e.ColumnIndex = 7 AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            Dim bmpFind As Bitmap = My.Resources.cal
            Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
            e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 5)
            e.Handled = True

        End If


    End Sub
    '**********************************

    'Updating Transaction after selection
    Sub updateTheTransaction()

        Dim dt As DataTable = New DataTable
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()




            myCommand.CommandText = "Update db_owner.tbl_asset_transactions Set  transactionType = 'Purchase', transactionTypeID = '" & retrievedTranTypeID & "',
            locationID = '" & retrievedLocID & "', locationName = '" & locationDropBox.Text & "',
            vendorID = '" & vendorIDLabel.Text & "', vendorName = '" & vendorNameField.Text & "', currancy = '" & currencyField.Text & "',
            totalQty = '" & allItemsQty.Text & "', totalprice = '" & allItemsPrice.Text & "',compStatus = '" & isComplete & "',
            acquisationDate = '" & dateCreatedField.Value & "',Status = 1, RevisionUserID = '" & logedInUserID & "',
            RevisionDate = '" & Today & "' where (ID = '" & retrievedTranID & "')"

            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Add")
            MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try


        reduceTheItemInventoryQuantities()

        Dim conn3 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows1 As Integer
        Dim myCommand1 As SqlCommand = conn3.CreateCommand()


        Try

            conn3.Open()

            myCommand1.CommandText = "Delete  From db_owner.tbl_asset_transactioned where (TransactionID = '" & retrievedTranID & "')"

            rows1 = myCommand1.ExecuteNonQuery()



        Catch ex As SqlException


            ' handle error
            Console.Write("Unable to Delete")


        Finally
            insertIntoItems()
            'clearFields()


            'conn.Close()
            'enableBtn(submitBtn)

            ''updateTransactions()
            'initAllWindow()

        End Try
        'conn2.Close()



    End Sub
    '*****************************************************

    'Update the Inventory Location after items change
    Sub reduceTheItemInventoryQuantities()

        Dim assetIDToReduce As Integer = 0
        Dim assetQtyToReduce As Integer = 0
        Dim assetUnitPriceToReduce As Decimal = 0
        Dim assetTotalPriceToReduce As Decimal = 0
        Dim assetLocationIDToReduce As Integer = 0

        Dim fDt As New DataTable
        fDt = databaseObject.SelectMethode("Select assetID, assetName, assetQty, assetUnitCost, assetTotalCost
        from db_owner.tbl_asset_transactioned where(TransactionID = '" & retrievedTranID & "' and Status = 1)")

        For i As Integer = 0 To fDt.Rows.Count - 1

            Dim tempName = fDt.Rows(i)("assetName").ToString
            assetIDToReduce = fDt.Rows(i)("assetID").ToString
            assetQtyToReduce = fDt.Rows(i)("assetQty").ToString
            assetUnitPriceToReduce = fDt.Rows(i)("assetUnitCost").ToString
            assetTotalPriceToReduce = fDt.Rows(i)("assetTotalCost").ToString
            assetLocationIDToReduce = retrievedLocID

            Dim sDt As New DataTable
            sDt = databaseObject.SelectMethode("Select assetID, assetQty, assetUnitPrice, assetTotalPrice 
            from db_owner.tbl_location_asset_Inventory where ( assetID = '" & assetIDToReduce & "' and assetLocationID = '" & assetLocationIDToReduce & "')")

            theAssetID = assetIDToReduce

            theCalculatedInventoryItemQty = (sDt.Rows(0)("assetQty").ToString - assetQtyToReduce)
            If theCalculatedInventoryItemQty = 0 Then

                theCalculatedInventoryItemAvgPrice = assetUnitPriceToReduce


            ElseIf theCalculatedInventoryItemQty <> 0 Then
                theCalculatedInventoryItemAvgPrice = (sDt.Rows(0)("assetUnitPrice").ToString + assetUnitPriceToReduce) / 2
                'theCalculatedInventoryItemAvgPrice = theCalculatedInventoryItemTotalPrice / theCalculatedInventoryItemQty
            End If


            'theCalculatedInventoryItemQty = (sDt.Rows(0)("ItemQty").ToString - itemQtyToReduce)
            theCalculatedInventoryItemTotalPrice = (sDt.Rows(0)("assetTotalPrice").ToString() - assetTotalPriceToReduce)
            If theCalculatedInventoryItemQty <> 0 Then
                theCalculatedInventoryItemAvgPrice = theCalculatedInventoryItemTotalPrice / theCalculatedInventoryItemQty

            Else
                theCalculatedInventoryItemAvgPrice = 0
            End If

            'theCalculatedInventoryItemTotalPrice = (theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice)

            updateLocationInventory()
        Next

    End Sub
    '********************************************

    'On submit btn click
    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click




        If locationDropBox.Text <> String.Empty And vendorNameField.Text <> String.Empty Then

            checkEnteredIds()

            If retrievedLocID = 0 Then
                MessageBox.Show("Make sure you entered a valid Location", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If


            If vendorNameField.Text <> String.Empty Then

                If retrievedVendorID = 0 Then

                    MessageBox.Show("Make sure you entered a valid Vendor", "Invalid Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub

                End If

            End If
            If vendorIDLabel.Text = "-" Or vendorNameField.Text = String.Empty Then
                isComplete = False
                statusLabel.Text = "InComplete"
            End If

            If isComplete = True Then
                statusLabel.Text = "Complete"
            End If


            If transactionData.Rows.Count > 1 Then
                itemsExist = True
            End If
            If itemsExist = False Then
                MessageBox.Show("You Have to add at least one Item to the Above Transaction",
          "Invalid Transaction", MessageBoxButtons.OK,
           MessageBoxIcon.Warning)
                Exit Sub

            End If

            Dim totQty As Integer = 0
            Dim totPrice As Decimal = 0

            For i As Integer = 0 To transactionData.Rows.Count - 2

                totQty += transactionData.Rows(i).Cells(3).Value
                totPrice += transactionData.Rows(i).Cells(5).Value



            Next

            allItemsQty.Text = totQty
            allItemsPrice.Text = totPrice

            If toBeUpdated Then

                updateTheTransaction()
                toBeUpdated = False
                clearFields()
                locationDropBox.Enabled = True
                Exit Sub

            End If

            insertIntoTransactions()
        Else
            MessageBox.Show("Make Sure You Filled All Required Fields",
                            "Invalid Fields", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        ''''''''''''''''''''''''''''''''''''

        updateBarcodesID()

        retrievedTranID = 0

    End Sub
    '*******************************************

    'Updating the transID (Only 0) in Barcode table

    Sub updateBarcodesID()

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_asset_barcodes Set transID = '" & retrievedTranID & "'
            where(transID = 0 )"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try

    End Sub
    '**********************************************
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
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next




        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Adding Transaction to database

        'If currencyChosen = "L" Then
        '    Dim priceInDollars As Double = allItemsPrice.Text
        '    allItemsPrice.Text = priceInDollars / 1500

        'End If

        If statusLabel.Text = "Complete" Then

            isComplete = 1
        Else
            isComplete = 0
        End If

        Dim query As String = String.Empty
        query = "INSERT INTO db_owner.tbl_asset_transactions (transactionType, transactionTypeID, locationID, locationName, vendorID, vendorName, currancy,
         totalQty, totalPrice, compStatus, acquisationDate, Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)
         VALUES(@transactionType, @transactionTypeID, @locationID, @locationName, @vendorID, @vendorName, @currancy, @totalQty, @totalPrice, @compStatus,
         @acquisationDate, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

        Using comm As New SqlCommand()
            With comm
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@transactionType", "Purchase")
                .Parameters.AddWithValue("@transactionTypeID", retrievedTranTypeID)
                .Parameters.AddWithValue("@locationID", retrievedLocID)
                .Parameters.AddWithValue("@locationName", locationDropBox.Text)
                .Parameters.AddWithValue("@vendorID", vendorIDLabel.Text)
                .Parameters.AddWithValue("@vendorName", vendorNameField.Text)
                .Parameters.AddWithValue("@currancy", currencyField.Text)
                .Parameters.AddWithValue("@totalQty", allItemsQty.Text)
                .Parameters.AddWithValue("@totalPrice", allItemsPrice.Text)
                .Parameters.AddWithValue("@compStatus", isComplete)
                .Parameters.AddWithValue("@acquisationDate", dateCreatedField.Value)
                .Parameters.AddWithValue("@Status", 1)
                .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                .Parameters.AddWithValue("@CreateDate", Today)
                .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                .Parameters.AddWithValue("@RevisionDate", Today)

            End With
            conn.Open()
            comm.ExecuteNonQuery()

            conn.Close()


        End Using
        '''''''''''''''''''''''''''''''''

        Dim dt As New DataTable
        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset_transactions 
            where (ID = (SELECT MAX(ID)  from db_owner.tbl_asset_transactions) and Status = 1)")

        retrievedTranID = dt.Rows(0)("ID").ToString()
        retrievedTotalQty = dt.Rows(0)("totalQty")
        retrievedTotalPrice = dt.Rows(0)("totalPrice")

        If itemsExist Then
            insertIntoItems()
        End If

    End Sub
    '*********************************************


    'Enter Items in Transactioned Items
    Private Sub insertIntoItems()

        'Get the TransactionID and the totals from the ReferanceNumber
        'Dim mDt As New DataTable
        'mDt = databaseObject.SelectMethode("SELECT MAX(ID) as [ID] from db_owner.tbl_asset_transactions")
        'Dim maxID = mDt.Rows(0)("ID").ToString()

        'Dim dt As DataTable = New DataTable

        'dt = databaseObject.SelectMethode("Select * from db_owner.tbl_asset_transactions where (ID ='" & maxID & "' and Status = 1)")

        'If dt.Rows.Count - 1 > 0 Then

        '    retrievedTranID = dt.Rows(0)("ID").ToString()
        '    retrievedTotalQty = dt.Rows(0)("totalQty")
        '    retrievedTotalPrice = dt.Rows(0)("totalPrice")
        'Else

        '    retrievedTranID = 0
        '    retrievedTotalQty = 0
        '    retrievedTotalPrice = 0

        'End If




        '************************************************



        If transactionData.Rows.Count = 0 Then
            deleteEmptyTransaction()
            Exit Sub
        End If
        Dim i As Integer
        'If transactionData.Rows(i).Cells(7).Value.ToString IsNot Nothing Then
        If toBeDeleted = True Then
            For i = 0 To transactionData.Rows.Count - 1


                If transactionData.Rows(i).Cells(9).Value.ToString IsNot Nothing Then


                    theAssetID = transactionData.Rows(i).Cells(9).Value
                    theAssetName = transactionData.Rows(i).Cells(2).Value
                    theAssetQuantity = transactionData.Rows(i).Cells(3).Value
                    theAssetUnitprice = transactionData.Rows(i).Cells(4).Value
                    theAssetTotalPrice = transactionData.Rows(i).Cells(5).Value

                    If transactionData.Rows(i).Cells(6).Value <> Nothing Then

                        theAssetBarcode = transactionData.Rows(i).Cells(6).Value
                    Else
                        theAssetBarcode = 0
                    End If

                    If transactionData.Rows(i).Cells(7).Value <> Nothing Then

                        'theAssetAcquisationDate = Convert.ToDateTime(transactionData.Rows(i).Cells(7).Value)
                        theAssetAcquisationDate = DateTime.Parse(transactionData.Rows(i).Cells(7).Value)
                        'theAssetAcquisationDate = Convert.ToDateTime(theAssetAcquisationDate)
                    Else
                        theAssetAcquisationDate = Format(Today, "MMM d,yyyy")
                    End If



                    'transactionData.Rows(i).Cells(0).Value = retrievedItemID

                    If currencyChosen = "L" Then

                        theAssetTotalPrice = (theAssetTotalPrice / 1500)
                        theAssetUnitprice = (theAssetUnitprice / 1500)
                    End If

                    Dim query As String = String.Empty
                    query = "INSERT INTO db_owner.tbl_asset_transactioned (TransactionID, assetID, assetName, assetQty, assetUnitCost, assetTotalCost,
                             assetBarcode, assetImported, assetDisposed,acquisationDate, Status, CreateUserID, CreateDate, RevisionUserID, RevisionDate)
                             VALUES (@TransactionID, @assetID, @assetName,@assetQty, @assetUnitCost, @assetTotalCost,@assetBarcode,@assetImported,
                             @assetDisposed,@acquisationDate, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

                    Using comm As New SqlCommand()
                        With comm
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = query
                            .Parameters.AddWithValue("@TransactionID", retrievedTranID)
                            .Parameters.AddWithValue("@assetID", theAssetID)
                            .Parameters.AddWithValue("@assetName", theAssetName)
                            .Parameters.AddWithValue("@assetQty", theAssetQuantity)
                            .Parameters.AddWithValue("@assetUnitCost", theAssetUnitprice)
                            .Parameters.AddWithValue("@assetTotalCost", theAssetTotalPrice)
                            .Parameters.AddWithValue("@assetBarcode", theAssetBarcode)
                            .Parameters.AddWithValue("@acquisationDate", theAssetAcquisationDate)
                            .Parameters.AddWithValue("@assetImported", 0)
                            .Parameters.AddWithValue("@assetDisposed", 0)
                            .Parameters.AddWithValue("@Status", 1)
                            .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                            .Parameters.AddWithValue("@CreateDate", Today)
                            .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                            .Parameters.AddWithValue("@RevisionDate", Today)
                        End With

                        conn.Open()
                        comm.ExecuteNonQuery()
                        conn.Close()
                        If theAssetUnitprice = 0 Then
                            isComplete = False
                            statusLabel.Text = "InComplete"
                        End If

                    End Using
                End If

                Dim sDt As New DataTable
                sDt = databaseObject.SelectMethode("Select assetQty, assetUnitPrice, assetTotalPrice, assetLocationID, assetID 
                                               From db_owner.tbl_location_asset_Inventory 
                                               Where (assetLocationID ='" & retrievedLocID & "'
                                               And assetID = '" & theAssetID & "')")
                If sDt.Rows.Count = 0 Then
                    addToTheInventory()
                Else

                    'MessageBox.Show(" 1 " & theCalculatedInventoryItemQty & " 2 " & theCalculatedInventoryItemTotalPrice & " 3 " & theCalculatedInventoryItemAvgPrice)

                    theCalculatedInventoryItemQty = 0
                    theCalculatedInventoryItemAvgPrice = 0
                    theCalculatedInventoryItemTotalPrice = 0


                    theCalculatedInventoryItemQty = sDt.Rows(0)("assetQty").ToString() + theAssetQuantity
                    theCalculatedInventoryItemTotalPrice = (sDt.Rows(0)("assetTotalPrice").ToString() + theAssetTotalPrice)
                    theCalculatedInventoryItemAvgPrice = theCalculatedInventoryItemTotalPrice / theCalculatedInventoryItemQty

                    updateLocationInventory()


                End If


            Next
            toBeDeleted = False
        Else
            For i = 0 To transactionData.Rows.Count - 2


                If transactionData.Rows(i).Cells(9).Value.ToString IsNot Nothing Then


                    theAssetID = transactionData.Rows(i).Cells(9).Value
                    theAssetName = transactionData.Rows(i).Cells(2).Value
                    theAssetQuantity = transactionData.Rows(i).Cells(3).Value
                    theAssetUnitprice = transactionData.Rows(i).Cells(4).Value
                    theAssetTotalPrice = transactionData.Rows(i).Cells(5).Value

                    If transactionData.Rows(i).Cells(6).Value <> Nothing Then

                        theAssetBarcode = transactionData.Rows(i).Cells(6).Value
                    Else
                        theAssetBarcode = 0
                    End If

                    'MessageBox.Show(transactionData.Rows(i).Cells(7).Value)

                    Dim theDateValue As String = transactionData.Rows(i).Cells(7).Value
                    If theDateValue = Nothing Then

                        theAssetAcquisationDate = Format(Today, "MMM d,yyyy")
                    ElseIf theDateValue.Contains("Select a date") Then

                        theAssetAcquisationDate = Format(Today, "MMM d,yyyy")

                        'theAssetAcquisationDate = Convert.ToDateTime(transactionData.Rows(i).Cells(7).Value)
                        'theAssetAcquisationDate = Convert.ToDateTime(theAssetAcquisationDate)


                    Else

                        Dim theDate As String = transactionData.Rows(i).Cells(7).Value.ToString

                        theAssetAcquisationDate = DateTime.Parse(theDate)

                    End If

                    'transactionData.Rows(i).Cells(0).Value = retrievedItemID

                    If currencyChosen = "L" Then

                        theAssetTotalPrice = (theAssetTotalPrice / 1500)
                        theAssetUnitprice = (theAssetUnitprice / 1500)
                    End If

                    Dim query As String = String.Empty
                    query = "INSERT INTO db_owner.tbl_asset_transactioned (TransactionID, assetID, assetName, assetQty, assetUnitCost, assetTotalCost,
                             assetBarcode, assetImported, assetDisposed,acquisationDate, Status, CreateUserID, CreateDate, RevisionUserID, RevisionDate)
                             VALUES (@TransactionID, @assetID, @assetName,@assetQty, @assetUnitCost, @assetTotalCost,@assetBarcode,@assetImported,
                             @assetDisposed, @acquisationDate, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

                    Using comm As New SqlCommand()
                        With comm
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = query
                            .Parameters.AddWithValue("@TransactionID", retrievedTranID)
                            .Parameters.AddWithValue("@assetID", theAssetID)
                            .Parameters.AddWithValue("@assetName", theAssetName)
                            .Parameters.AddWithValue("@assetQty", theAssetQuantity)
                            .Parameters.AddWithValue("@assetUnitCost", theAssetUnitprice)
                            .Parameters.AddWithValue("@assetTotalCost", theAssetTotalPrice)
                            .Parameters.AddWithValue("@assetBarcode", theAssetBarcode)
                            .Parameters.AddWithValue("@assetImported", 0)
                            .Parameters.AddWithValue("@assetDisposed", 0)
                            .Parameters.AddWithValue("@acquisationDate", theAssetAcquisationDate)
                            .Parameters.AddWithValue("@Status", 1)
                            .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                            .Parameters.AddWithValue("@CreateDate", Today)
                            .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                            .Parameters.AddWithValue("@RevisionDate", Today)
                        End With

                        conn.Open()
                        comm.ExecuteNonQuery()
                        conn.Close()
                        If theAssetUnitprice = 0 Then
                            isComplete = False
                            statusLabel.Text = "InComplete"
                        End If

                    End Using
                End If

                Dim sDt As New DataTable
                sDt = databaseObject.SelectMethode("Select assetQty, assetUnitPrice, assetTotalPrice, assetLocationID, assetID 
                                               From db_owner.tbl_location_asset_Inventory 
                                               Where (assetLocationID ='" & retrievedLocID &
                                                   "' And assetID = '" & theAssetID & "')")
                If sDt.Rows.Count = 0 Then
                    addToTheInventory()
                Else
                    theCalculatedInventoryItemQty = 0
                    theCalculatedInventoryItemAvgPrice = 0
                    theCalculatedInventoryItemTotalPrice = 0


                    theCalculatedInventoryItemQty = sDt.Rows(0)("assetQty").ToString() + theAssetQuantity
                    theCalculatedInventoryItemTotalPrice = (sDt.Rows(0)("assetTotalPrice").ToString() + theAssetTotalPrice)
                    theCalculatedInventoryItemAvgPrice = theCalculatedInventoryItemTotalPrice / theCalculatedInventoryItemQty

                    updateLocationInventory()


                End If


            Next
        End If



        If isComplete = True Then
            statusLabel.Text = "Complete"
        End If

        updateTransactions()
        clearFields()


        purchaseTransaGrid.DataSource = getPurchaseTransa()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False


        'End If

    End Sub

    '*************************************************************

    ' Add Entered Items to the Locations Inventory
    Sub addToTheInventory()
        Using conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            Dim query As String = String.Empty
            query = "INSERT INTO db_owner.tbl_location_asset_Inventory (assetLocationID,assetLocationName,assetID,assetName,
                     assetQty,assetUnitPrice,assetTotalPrice)
                     VALUES (@assetLocationID, @assetLocationName, @assetID,@assetName, @assetQty, @assetUnitPrice, @assetTotalPrice)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@assetLocationID", retrievedLocID)
                    .Parameters.AddWithValue("@assetLocationName", locationDropBox.Text)
                    .Parameters.AddWithValue("@assetID", theAssetID)
                    .Parameters.AddWithValue("@assetName", theAssetName)
                    .Parameters.AddWithValue("@assetQty", theAssetQuantity)
                    .Parameters.AddWithValue("@assetUnitPrice", theAssetUnitprice)
                    .Parameters.AddWithValue("@assetTotalPrice", theAssetTotalPrice)

                End With

                conn.Open()
                comm.ExecuteNonQuery()
                conn.Close()


            End Using



        End Using
    End Sub

    '***********************************

    'Update the Locations Inventory after updating items
    Sub updateLocationInventory()

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_location_asset_inventory Set assetQty = '" & theCalculatedInventoryItemQty & "',
            assetUnitPrice = '" & theCalculatedInventoryItemAvgPrice & "', assetTotalPrice = '" & theCalculatedInventoryItemTotalPrice & "', assetLocationID = '" & retrievedLocID & "',
            assetLocationName = '" & locationDropBox.Text & "' where(assetID = '" & theAssetID & "' and assetLocationID = '" & retrievedLocID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try

    End Sub
    '**************************************

    'Update the Transaction after editing in Items 
    Private Sub updateTransactions()

        If currencyChosen = "L" Then
            Dim liraCurrancy As Double = (allItemsPrice.Text / 1500)
            allItemsPrice.Text = liraCurrancy
        End If

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_asset_transactions Set totalQty = '" & allItemsQty.Text & "', totalPrice = '" & allItemsPrice.Text & "', 
            compStatus = '" & isComplete & "',  locationID = '" & retrievedLocID & "', LocationName = '" & locationDropBox.Text & "', currancy = '" & currencyField.Text &
            "', VendorID = '" & vendorIDLabel.Text & "', VendorName = '" & vendorNameField.Text & "', acquisationDate = '" & dateCreatedField.Text & "'  where (ID = '" & retrievedTranID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Add")

        Finally

            conn.Close()

        End Try


    End Sub

    '*********************************************

    'OnCancel Click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        locationDropBox.Enabled = True
        retrievedTranID = 0
        toBeUpdated = False
        clearFields()
    End Sub
    '***********************************

    'Retrieve data with searched fields
    Function getSearchedPurchasedTransaWithChecks()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next

        Dim dtPurchaseTransactions As New DataTable

        If completeCheckBox.Checked = True And InCompleteCheckBox.Checked = False Then

            dtPurchaseTransactions = databaseObject.SelectMethode("Select ID, locationName As [Location], VendorName As [Vendor],
            totalQty as [Total Qty], totalPrice as [Total Price],locationID, vendorID,currancy,acquisationDate,compStatus
            From db_owner.tbl_asset_transactions where (transactionTypeID = '" & retrievedTranTypeID & "'
            and VendorName LIKE '%" & searchVendor.Text & "%' and LocationName LIKE '%" & searchLocation.Text & "%' and compStatus = 1 and Status = 1)")
        ElseIf InCompleteCheckBox.Checked = True And completeCheckBox.Checked = False Then
            dtPurchaseTransactions = databaseObject.SelectMethode("Select ID, locationName As [Location], VendorName As [Vendor],
            totalQty as [Total Qty], totalPrice as [Total Price],locationID, vendorID,currancy,acquisationDate,compStatus
            From db_owner.tbl_asset_transactions where (transactionTypeID = '" & retrievedTranTypeID & "'
            and VendorName LIKE '%" & searchVendor.Text & "%' and LocationName LIKE '%" & searchLocation.Text & "%' and compStatus = 0 and Status = 1)")

        ElseIf (completeCheckBox.Checked = True And InCompleteCheckBox.Checked = True) Or (completeCheckBox.Checked = False And InCompleteCheckBox.Checked = False) Then
            dtPurchaseTransactions = databaseObject.SelectMethode("Select ID, locationName As [Location], VendorName As [Vendor],
            totalQty as [Total Qty], totalPrice as [Total Price],locationID, vendorID,currancy,acquisationDate,compStatus
            From db_owner.tbl_asset_transactions where (transactionTypeID = '" & retrievedTranTypeID & "'
            and VendorName LIKE '%" & searchVendor.Text & "%' and LocationName LIKE '%" & searchLocation.Text & "%' and Status = 1)")
        End If




        ' 

        Return dtPurchaseTransactions
    End Function
    '**********************************

    'Display the transaction data after check boxes ticked
    Private Sub completeCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles completeCheckBox.CheckedChanged

        InCompleteCheckBox.Checked = False

        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithChecks()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False


    End Sub

    Private Sub InCompleteCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles InCompleteCheckBox.CheckedChanged


        completeCheckBox.Checked = False
        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithChecks()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False

    End Sub
    '**************************************

    'Delete a Transaction
    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click

        Dim dt As New DataTable
        dt = databaseObject.SelectMethode("Select assetID, assetQty,assetUnitCost, assetTotalCost, assetBarcode, acquisationDate from db_owner.tbl_asset_transactioned where
        (TransactionID = '" & retrievedTranID & "' and Status = 1)")
        For i As Integer = 0 To dt.Rows.Count - 1

            theAssetID = dt.Rows(i)("assetID").ToString
            theAssetQuantity = dt.Rows(i)("assetQty").ToString
            theAssetUnitprice = dt.Rows(i)("assetUnitCost").ToString
            theAssetTotalPrice = dt.Rows(i)("assetTotalCost").ToString
            theAssetBarcode = dt.Rows(i)("assetBarcode").ToString
            theAssetAcquisationDate = dt.Rows(i)("acquisationDate").ToString

            Dim sDt As New DataTable
            sDt = databaseObject.SelectMethode("Select assetID, assetQty,assetUnitPrice, assetTotalPrice from db_owner.tbl_location_asset_Inventory where
            (assetLocationID = '" & retrievedLocID & "' and assetID = '" & theAssetID & "')")

            theCalculatedInventoryItemQty = sDt.Rows(0)("assetQty").ToString - theAssetQuantity
            theCalculatedInventoryItemAvgPrice = sDt.Rows(0)("assetUnitPrice").ToString
            theCalculatedInventoryItemTotalPrice = (theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice)


            'Update the location Inventory after before deleting items
            updateLocationInventory()
        Next


        'delete Items in the selected transaction
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()


        Try

            conn.Open()

            myCommand.CommandText = "Delete From db_owner.tbl_asset_transactioned where (TransactionID = '" & retrievedTranID & "')"

            rows = myCommand.ExecuteNonQuery()



        Catch ex As SqlException


            ' handle error
            Console.Write("Unable to Delete")


        Finally
            clearFields()


            conn.Close()

        End Try
        'Delete the selected transaction
        deleteTheTransaction()
        locationDropBox.Enabled = True

        deleteBarcodes()
    End Sub


    '******************************************************

    'Delete the selected transaction
    Sub deleteTheTransaction()
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()
            myCommand.CommandText = "Delete From db_owner.tbl_asset_transactions where (ID = '" & retrievedTranID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException


            ' handle error
            Console.Write("Unable to Delete")


        Finally
            clearFields()
            conn.Close()

            updateTransactions()

            purchaseTransaGrid.DataSource = getPurchaseTransa()
            purchaseTransaGrid.Columns(0).Visible = False
            purchaseTransaGrid.Columns(5).Visible = False
            purchaseTransaGrid.Columns(6).Visible = False
            purchaseTransaGrid.Columns(7).Visible = False
            purchaseTransaGrid.Columns(8).Visible = False
            purchaseTransaGrid.Columns(9).Visible = False


        End Try
        retrievedTranID = 0
    End Sub
    '********************************************

    'Delete Transaction if it doesn't have items
    Sub deleteEmptyTransaction()

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()


        Try

            conn.Open()

            myCommand.CommandText = "Delete From db_owner.tbl_asset_transactions where (ID = '" & retrievedTranID & "')"

            rows = myCommand.ExecuteNonQuery()



        Catch ex As SqlException


            ' handle error
            Console.Write("Unable to Delete")


        Finally
            clearFields()


            conn.Close()

            updateTransactions()

            purchaseTransaGrid.DataSource = getPurchaseTransa()
            purchaseTransaGrid.Columns(0).Visible = False
            purchaseTransaGrid.Columns(5).Visible = False
            purchaseTransaGrid.Columns(6).Visible = False
            purchaseTransaGrid.Columns(7).Visible = False
            purchaseTransaGrid.Columns(8).Visible = False
            purchaseTransaGrid.Columns(9).Visible = False

        End Try
    End Sub
    '****************************************

    'Delete deleted Transaction barcode
    Sub deleteBarcodes()

        Dim rows1 As Integer
        Dim myCommand1 As SqlCommand = conn.CreateCommand()


        Try

            conn.Open()

            myCommand1.CommandText = "Delete  From db_owner.tbl_asset_barcodes where (transID = '" & theTranID & "')"
            rows1 = myCommand1.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Delete")


        Finally
            conn.Close()
        End Try


    End Sub

    '*********************************
    'OnClick on currancy field
    Private Sub currencyField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles currencyField.SelectedIndexChanged
        If currencyField.Text = "US Dollars" Then
            currencyChosen = "$"
        Else
            currencyChosen = "L"
        End If
    End Sub

    '********************************

    'get LocationID after selecting location
    Private Sub locationDropBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles locationDropBox.SelectedIndexChanged


        retrievedLocID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationList

            Dim key As String = pair.Key
            If key = locationDropBox.Text Then
                retrievedLocID = pair.Value
            End If
        Next

        If retrievedVendorID > 0 And retrievedLocID > 0 Then

            isComplete = True
            statusLabel.Text = "Complete"

        Else
            isComplete = False
            statusLabel.Text = "InComplete"
        End If
    End Sub
    '**********************************************

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'purchaseTransaGrid.DataSource = getSearchedPurchasedTransa()
        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithChecks()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
    End Sub

    'For purchase Transaction Search
    Function getSearchedPurchasedTransa()


        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next

        'If completeCheckBox.Checked = True Then
        '    theSearchStatus = "Complete"
        'ElseIf InCompleteCheckBox.Checked = True Then
        '    theSearchStatus = "InComplete"
        'End If

        Dim dtPurchaseTransactions As New DataTable

        'dtPurchaseTransactions = databaseObject.SelectMethode("SELECT ReferanceNumber, VendorName as [Name] ,InvoiceNumber as [Invoice Number],
        'DateCreated as [Date],LocationName as [Location],
        'EnteryStatus , EnteredToGP, Currancy, TotalQty, TotalCost, ID,VendorID,StatusText as [Status] FROM db_owner.tbl_transaction where (TransactionID = '" & retrievedTranTypeID & "'
        'and InvoiceNumber LIKE '%" & searchInvoice.Text & "%' and VendorName LIKE '%" & searchVendor.Text &
        '"%' and LocationName LIKE '%" & searchLocation.Text & "%' and Status = 1) ")


        Return dtPurchaseTransactions
    End Function

    '*******************************************

    'Search on searchlocation textchange
    Private Sub searchLocation_TextChanged(sender As Object, e As EventArgs) Handles searchLocation.TextChanged
        'purchaseTransaGrid.DataSource = getSearchedPurchasedTransa()
        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithChecks()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
    End Sub

    '*******************************************

    'Retrieving transaction when date in the search is modified 
    Function getSearchedPurchasedTransaWithDate()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next

        Dim dtPurchaseTransactions As New DataTable

        If completeCheckBox.Checked = True And InCompleteCheckBox.Checked = False Then

            dtPurchaseTransactions = databaseObject.SelectMethode("Select ID, locationName As [Location], VendorName As [Vendor],
            totalQty as [Total Qty], totalPrice as [Total Price],locationID, vendorID,currancy,acquisationDate,compStatus
            From db_owner.tbl_asset_transactions where (transactionTypeID = '" & retrievedTranTypeID & "'
            and VendorName LIKE '%" & searchVendor.Text & "%' and LocationName LIKE '%" & searchLocation.Text & "%' and compStatus = 1
            and acquisationDate = '" & searchDate.Value & "'and Status = 1)")

        ElseIf InCompleteCheckBox.Checked = True And completeCheckBox.Checked = False Then

            dtPurchaseTransactions = databaseObject.SelectMethode("Select ID, locationName As [Location], VendorName As [Vendor],
            totalQty as [Total Qty], totalPrice as [Total Price],locationID, vendorID,currancy,acquisationDate,compStatus
            From db_owner.tbl_asset_transactions where (transactionTypeID = '" & retrievedTranTypeID & "'
            and VendorName LIKE '%" & searchVendor.Text & "%' and LocationName LIKE '%" & searchLocation.Text & "%' and compStatus = 0
            and acquisationDate = '" & searchDate.Value & "' and Status = 1)")

        ElseIf (completeCheckBox.Checked = True And InCompleteCheckBox.Checked = True) Or (completeCheckBox.Checked = False And InCompleteCheckBox.Checked = False) Then

            dtPurchaseTransactions = databaseObject.SelectMethode("Select ID, locationName As [Location], VendorName As [Vendor],
            totalQty as [Total Qty], totalPrice as [Total Price],locationID, vendorID,currancy,acquisationDate,compStatus
            From db_owner.tbl_asset_transactions where (transactionTypeID = '" & retrievedTranTypeID & "'
            and VendorName LIKE '%" & searchVendor.Text & "%' and LocationName LIKE '%" & searchLocation.Text & "%'
            and acquisationDate = '" & searchDate.Value & "' and Status = 1)")

        End If

        Return dtPurchaseTransactions
    End Function
    '*********************************************

    'Search when DateField is changeed
    Private Sub searchDate_ValueChanged(sender As Object, e As EventArgs) Handles searchDate.ValueChanged

        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithDate()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False

    End Sub
    '************************************

    'Cancel Search BTN CLICK
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        purchaseTransaGrid.DataSource = getPurchaseTransa()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False

        searchLocation.Text = ""
        completeCheckBox.Checked = False
        InCompleteCheckBox.Checked = False
        searchVendor.Text = ""
    End Sub

    Private Sub purchaseTransaGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles purchaseTransaGrid.CellClick

        locationDropBox.Enabled = False
        Dim i As Integer
        i = e.RowIndex

        Dim selectedRow As DataGridViewRow
        Dim curr As String
        Dim theID As Integer

        If (i >= 0 And i < purchaseTransaGrid.Rows.Count - 1) Then


            selectedRow = purchaseTransaGrid.Rows(i)

            dateCreatedField.Value = selectedRow.Cells(8).Value.ToString()
            locationDropBox.Text = selectedRow.Cells(1).Value.ToString()
            vendorIDLabel.Text = selectedRow.Cells(6).Value.ToString()
            vendorNameField.Text = selectedRow.Cells(2).Value.ToString()
            currencyField.Text = selectedRow.Cells(7).Value.ToString()
            'statusLabel.Text = selectedRow.Cells(8).Value.ToString()
            retrievedLocID = selectedRow.Cells(5).Value.ToString()


            If selectedRow.Cells(9).Value = True Then

                statusLabel.Text = "Complete"
            ElseIf selectedRow.Cells(8).Value = False Then

                statusLabel.Text = "InComplete"
            End If


            If currencyField.Text = "US Dollars" Then
                curr = "$ "
            Else
                curr = "L.L "
            End If

            allItemsQty.Text = "0"
            allItemsPrice.Text = "0"

            Dim qty As String = selectedRow.Cells(3).Value.ToString()

            Dim currPrice As Decimal = 0

            If curr = "L.L " Then

                currPrice = (selectedRow.Cells(4).Value.ToString() * 1500)

            Else
                currPrice = selectedRow.Cells(4).Value.ToString()
            End If

            'pri = curr + currPrice

            allItemsQty.Text = qty
            allItemsPrice.Text = (Math.Round((currPrice), 2)).ToString

            theID = selectedRow.Cells(0).Value
            retrievedTranID = theID
            theTranID = theID
            calculatedTotalQty = selectedRow.Cells(3).Value
            calculatedTotalCost = selectedRow.Cells(4).Value

            toBeUpdated = True
            fillTheTransactionItems(theID)

            transactionData.Columns(2).ReadOnly = True
            transactionData.Rows(transactionData.Rows.Count - 1).Cells(2).ReadOnly = False


        Else

        End If

    End Sub
    '***********************************************

    'Fill datagridView with transaction ITEMS
    Sub fillTheTransactionItems(theID)
        'Get the TransactionID and the totals from the ReferanceNumber
        transactionData.Rows.Clear()

        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select db_owner.tbl_asset_transactioned.*, db_owner.tbl_asset.assetID [itemSecID] from db_owner.tbl_asset_transactioned,
             db_owner.tbl_asset where (db_owner.tbl_asset_transactioned.TransactionID = '" & theID & "'
             and db_owner.tbl_asset_transactioned.Status = 1 
             and db_owner.tbl_asset_transactioned.assetID = db_owner.tbl_asset.ID)")

        Dim theDate As String



        If currencyChosen = "L" Then

            For i = 0 To dt.Rows.Count - 1
                theDate = Format(dt.Rows(i)("acquisationDate"), "MMM d,yyyy")
                transactionData.Rows.Add(New String() {Nothing, dt.Rows(i)("itemSecID").ToString(), dt.Rows(i)("assetName").ToString(),
                                         dt.Rows(i)("assetQty").ToString(), Math.Round((dt.Rows(i)("assetUnitCost") * 1500), 2),
                                         Math.Round((dt.Rows(i)("assetTotalCost") * 1500), 2), dt.Rows(i)("assetBarcode").ToString(), theDate,
                                         Nothing, dt.Rows(i)("assetID").ToString()})


            Next

        Else

            For i = 0 To dt.Rows.Count - 1
                theDate = Format(dt.Rows(i)("acquisationDate"), "MMM d,yyyy")
                transactionData.Rows.Add(New String() {Nothing, dt.Rows(i)("itemSecID").ToString(), dt.Rows(i)("assetName").ToString(),
                                         dt.Rows(i)("assetQty").ToString(), Math.Round((dt.Rows(i)("assetUnitCost")), 2),
                                         Math.Round((dt.Rows(i)("assetTotalCost")), 2), dt.Rows(i)("assetBarcode").ToString(), theDate,
                                         Nothing, dt.Rows(i)("assetID").ToString()})

            Next

        End If





    End Sub

    Private Sub searchVendor_TextChanged(sender As Object, e As EventArgs) Handles searchVendor.TextChanged

        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithChecks()
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False

    End Sub
    '*****************************************************


End Class