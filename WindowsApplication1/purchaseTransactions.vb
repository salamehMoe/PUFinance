Imports System.Data.SqlClient

Public Class purchaseTransactions

    'Variables
    Dim today As Date = Date.Now
    Shared random As New Random()
    Dim logedInUserID As Integer = My.Settings.userID
    Dim selectedTransaction As String = My.Settings.selectedTransaction
    Dim fromAllTrans As Boolean = My.Settings.fromAllTrans
    Dim retrievedItemID As Integer = 0
    Dim retrievedItemNameID As String
    Dim generatedReferanceNum As Integer
    Dim retrievedTranID As Integer = 0
    Dim retrievedTranTypeID As Integer = 0
    Dim retrievedLocID As Integer = 0
    Dim retrievedVendorID As Integer = 0
    Dim isComplete As Boolean = True
    Dim isEnteredToGP As Boolean = False
    Dim currencyChosen As String = "$"
    Dim calculatedTotalQty As Double = 0
    Dim calculatedTotalCost As Double = 0
    Dim retrievedTotalQty As Integer = 0
    Dim retrievedTotalPrice As Double = 0
    Dim retrievedUserItemID As String
    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
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
    Dim cnt As Integer = 0
    Dim itemsExist As Boolean = False
    Dim toBeUpdated As Boolean = False
    Dim theItemID As Integer = 0
    Dim theItemName As String = String.Empty
    Dim theItemQuantity As Integer = 0
    Dim theItemUnitprice As Decimal = 0
    Dim theItemTotalPrice As Decimal = 0
    Dim databaseObject As New DatabaseAccesClass
    Dim theCalculatedInventoryItemQty As Integer = 0
    Dim theCalculatedInventoryItemAvgPrice As Decimal = 0
    Dim theCalculatedInventoryItemTotalPrice As Decimal = 0
    Dim theStatusText As String = "InComplete"
    Dim theSearchStatus As String = ""
    Dim toBeDeleted As Boolean = False
    Dim toBeImported As Boolean = False


    '*****************************************


    Private Sub purchaseTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load


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
        generateIDS()
        getLocations()
        getItems()
        getTypes()
        getVendors()
        getUserItems()
        ''''''''''''''''''''''''''''''''''''

        'Get all Transactions and displaying them in gridView

        purchaseTransaGrid.DataSource = getPurchaseTransa()
        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90
        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False

        '''''''''''''''''''''
        If fromAllTrans = True And selectedTransaction <> -1 Then
            retrieveTransItems(selectedTransaction)

            My.Settings.fromAllTrans = False
            My.Settings.selectedTransaction = -1
            My.Settings.Save()
        End If
    End Sub

    'get the purchase Transaction from the database 
    Function getPurchaseTransa()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next
        Dim dtPurchaseTransactions As New DataTable

        dtPurchaseTransactions = databaseObject.SelectMethode("SELECT ReferanceNumber, VendorName as [Vendor] ,InvoiceNumber as [Invoice Number],
            DateCreated as [Date],LocationName as [Location], EnteryStatus, EnteredToGP, Currancy, TotalQty, TotalCost, ID,VendorID, StatusText [Status]
            FROM db_owner.tbl_transaction where (TransactionID = '" & retrievedTranTypeID & "' and Status = 1)")

        Return dtPurchaseTransactions
    End Function
    '**********************************
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

    Private Sub getUserItems()

        addedItemsIDList.Clear()


        Dim dt As DataTable = New DataTable
        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_Item where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            addedItemsIDList.Add(New KeyValuePair(Of String, String)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ItemID").ToString()))



        Next





    End Sub
    Private Sub getItems()

        inventoryNameField.Items.Clear()
        itemsList.Clear()


        Dim dt As DataTable = New DataTable
        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_Item where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            itemsList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ID").ToString()))



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

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_vendor where Status = 1 ")
        For i = 0 To dt.Rows.Count - 1
            vendorList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("VendorName").ToString(), dt.Rows(i)("ID").ToString()))

        Next

        autoCompleteVendors()

    End Sub


    Sub autoCompleteItems()

        Dim dt As DataTable = New DataTable()

        dt = databaseObject.SelectMethode("Select ItemName from db_owner.tbl_Item where Status = 1")

        Dim row As DataRow = dt.NewRow()
                dt.Rows.InsertAt(row, 0)

                inventoryNameField.DataSource = dt
                inventoryNameField.DisplayMember = "ItemName"
                inventoryNameField.ValueMember = "ItemName"

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
    Sub autoCompleteVendors()

        Dim dt As DataTable = New DataTable()

        dt = databaseObject.SelectMethode("Select VendorName from db_owner.tbl_vendor where Status = 1")
        Dim row As DataRow = dt.NewRow()

                dt.Rows.InsertAt(row, 0)


                vendorNameField.DataSource = dt
                vendorNameField.DisplayMember = "VendorName"
                vendorNameField.ValueMember = "VendorName"


                vendorNameField.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                vendorNameField.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    '*******************************************

    'Generating referance Number
    Private Sub generateIDS()

        Dim genratedNum As Integer = random.Next(100, 1000)
        Dim secondGeneratedNum As Integer = random.Next(1, 10000)
        generatedReferanceNum = secondGeneratedNum * genratedNum
        referanceLabel.Text = "PCH" + Convert.ToString(generatedReferanceNum)



    End Sub

    '*********************************




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


    'Initialize all fields
    Sub clearFields()

        generateIDS()
        invoiceField.Text = ""
        statusLabel.Text = "-"
        locationDropBox.Text = ""
        dateCreatedField.Value = today
        vendorIDLabel.Text = "-"
        vendorNameField.Text = ""
        currencyField.Text = "US Dollars"
        gpCheckBox.Checked = False
        transactionData.Rows.Clear()
        transactionData.AllowUserToAddRows = True
        allItemsPrice.Text = 0
        allItemsQty.Text = 0

    End Sub
    ''''''''''''''''''''''''

    'Retrieve the Vendor ID of selected vendor from vendorNameField and changing the transaction completion status accordingly
    Private Sub vendorNameField_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles vendorNameField.SelectedIndexChanged


        retrievedVendorID = 0

        For Each pair As KeyValuePair(Of String, Integer) In vendorList

            Dim key As String = pair.Key
            If key = vendorNameField.Text Then
                retrievedVendorID = pair.Value
                If isEnteredToGP = True Then
                    If invoiceField.Text <> String.Empty Then
                        isComplete = True
                        statusLabel.Text = "Complete"
                        theStatusText = "Complete"
                    Else

                        isComplete = False
                        statusLabel.Text = "InComplete"
                        theStatusText = "InComplete"

                    End If


                End If
            End If
        Next
        If vendorNameField.Text = String.Empty Or isEnteredToGP = False Or invoiceField.Text = String.Empty Then
            isComplete = False
            statusLabel.Text = "InComplete"
            theStatusText = "InComplete"

        End If
        vendorIDLabel.Text = retrievedVendorID

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            updateTransactions()

            purchaseTransaGrid.DataSource = getPurchaseTransa()
            purchaseTransaGrid.Columns(1).Width = 90
            purchaseTransaGrid.Columns(2).Width = 120
            purchaseTransaGrid.Columns(3).Width = 87
            purchaseTransaGrid.Columns(4).Width = 90

            purchaseTransaGrid.Columns(0).Visible = False
            purchaseTransaGrid.Columns(5).Visible = False
            purchaseTransaGrid.Columns(6).Visible = False
            purchaseTransaGrid.Columns(7).Visible = False
            purchaseTransaGrid.Columns(8).Visible = False
            purchaseTransaGrid.Columns(9).Visible = False
            purchaseTransaGrid.Columns(10).Visible = False
            purchaseTransaGrid.Columns(11).Visible = False

        End Try
    End Sub

    'get Selected Location ID on location TextChange
    Private Sub locationDropBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles locationDropBox.SelectedIndexChanged
        retrievedLocID = 0
        For Each pair As KeyValuePair(Of String, Integer) In locationList

            Dim key As String = pair.Key
            If key = locationDropBox.Text Then
                retrievedLocID = pair.Value
            End If
        Next

    End Sub


    'On Search Click
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        purchaseTransaGrid.DataSource = getSearchedPurchasedTransa()

        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90

        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False

    End Sub

    ''''''''''''''''''''''''''''''''''''''
    'For purchase Transaction Search
    Function getSearchedPurchasedTransa()


        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next

        If completeCheckBox.Checked = True Then
            theSearchStatus = "Complete"
        ElseIf InCompleteCheckBox.Checked = True Then
            theSearchStatus = "InComplete"
        End If

        Dim dtPurchaseTransactions As New DataTable

        dtPurchaseTransactions = databaseObject.SelectMethode("SELECT ReferanceNumber, VendorName as [Name] ,InvoiceNumber as [Invoice Number],
        DateCreated as [Date],LocationName as [Location],
        EnteryStatus , EnteredToGP, Currancy, TotalQty, TotalCost, ID,VendorID,StatusText as [Status] FROM db_owner.tbl_transaction where (TransactionID = '" & retrievedTranTypeID & "'
        and InvoiceNumber LIKE '%" & searchInvoice.Text & "%' and VendorName LIKE '%" & searchVendor.Text &
        "%' and LocationName LIKE '%" & searchLocation.Text & "%' and Status = 1) ")


        Return dtPurchaseTransactions
    End Function

    'search Purchase transaction when search location field text is changed
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles searchLocation.TextChanged
        purchaseTransaGrid.DataSource = getSearchedPurchasedTransa()

        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90

        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False


    End Sub
    '*************************************************

    'Retrieving transaction when date in the search is modified 
    Function getSearchedPurchasedTransaWithDate()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next

        If completeCheckBox.Checked = True Then
            theSearchStatus = "Complete"
        ElseIf InCompleteCheckBox.Checked = True Then
            theSearchStatus = "InComplete"

        End If

        Dim dtPurchaseTransactions As New DataTable

        dtPurchaseTransactions = databaseObject.SelectMethode("SELECT ReferanceNumber, VendorName as [Name] ,InvoiceNumber as [Invoice Number],
        DateCreated as [Date],LocationName as [Location],
        EnteryStatus , EnteredToGP, Currancy, TotalQty, TotalCost, ID,VendorID,
        StatusText as [Status] FROM db_owner.tbl_transaction where (TransactionID = '" & retrievedTranTypeID & "'
        and InvoiceNumber LIKE '%" & searchInvoice.Text & "%' and VendorName LIKE '%" & searchVendor.Text &
        "%' and LocationName LIKE '%" & searchLocation.Text & "%' and DateCreated = '" & searchDate.Value & "' and Status = 1)")

        ' 

        Return dtPurchaseTransactions
    End Function

    Private Sub searchDate_ValueChanged(sender As Object, e As EventArgs) Handles searchDate.ValueChanged

        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithDate()

        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90

        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False

    End Sub
    '***************************************************

    'search Purchase transaction when search Vendor field text is changed
    Private Sub searchReferance_TextChanged(sender As Object, e As EventArgs) Handles searchVendor.TextChanged

        purchaseTransaGrid.DataSource = getSearchedPurchasedTransa()
        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90

        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False

    End Sub

    'search Purchase transaction when search Invoice field text is changed
    Private Sub searchInvoice_TextChanged(sender As Object, e As EventArgs) Handles searchInvoice.TextChanged
        purchaseTransaGrid.DataSource = getSearchedPurchasedTransa()
        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90

        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Cancel Search BTN CLICK
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        purchaseTransaGrid.DataSource = getPurchaseTransa()
        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90

        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False

        searchLocation.Text = ""
        searchInvoice.Text = ""
        searchVendor.Text = ""
    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Cell Click on the Purchase Transaction GridView and fill the fields
    Private Sub purchaseTransaGrid_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles purchaseTransaGrid.CellClick


        locationDropBox.Enabled = False
        Dim i As Integer
        i = e.RowIndex

        Dim selectedRow As DataGridViewRow
        Dim curr As String
        Dim theID As Integer

        If (i >= 0 And i < purchaseTransaGrid.Rows.Count - 1) Then


            selectedRow = purchaseTransaGrid.Rows(i)

            referanceLabel.Text = selectedRow.Cells(0).Value.ToString()
            invoiceField.Text = selectedRow.Cells(2).Value.ToString()
            dateCreatedField.Value = selectedRow.Cells(3).Value.ToString()
            locationDropBox.Text = selectedRow.Cells(4).Value.ToString()
            vendorIDLabel.Text = selectedRow.Cells(11).Value.ToString()
            vendorNameField.Text = selectedRow.Cells(1).Value.ToString()


            If selectedRow.Cells(5).Value = True Then

                statusLabel.Text = "Complete"
            ElseIf selectedRow.Cells(5).Value = False Then

                statusLabel.Text = "InComplete"
            End If
            gpCheckBox.Checked = selectedRow.Cells(6).Value.ToString()
            currencyField.Text = selectedRow.Cells(7).Value.ToString()






            If currencyField.Text = "US Dollars" Then
                curr = "$ "
            Else
                curr = "L.L "
            End If
            allItemsQty.Text = "0"
            allItemsPrice.Text = "0"
            Dim qty As String = selectedRow.Cells(8).Value.ToString()

            Dim currPrice As Decimal = 0

            If curr = "L.L " Then

                currPrice = (selectedRow.Cells(9).Value.ToString() * 1500)

            Else
                currPrice = selectedRow.Cells(9).Value.ToString()
            End If

            'pri = curr + currPrice

            allItemsQty.Text = qty
            allItemsPrice.Text = (Math.Round((currPrice), 2)).ToString

            theID = selectedRow.Cells(10).Value
            retrievedTranID = theID

            calculatedTotalQty = selectedRow.Cells(8).Value
            calculatedTotalCost = selectedRow.Cells(9).Value

            toBeUpdated = True
            fillTheTransactionItems(theID)

            transactionData.Columns(2).ReadOnly = True
            transactionData.Rows(transactionData.Rows.Count - 1).Cells(2).ReadOnly = False


        Else

        End If
    End Sub


    '''''''''''''''''''''''''''''''''''''''''''
    'Accessing Transaction's Items from other classes
    Sub retrieveTransItems(selectedTransaction As String)
        Dim i As Integer
        For j As Integer = 0 To purchaseTransaGrid.Rows.Count - 2
            If purchaseTransaGrid.Rows(j).Cells(10).Value = selectedTransaction Then
                i = j

            End If
        Next

        locationDropBox.Enabled = False

        Dim selectedRow As DataGridViewRow
        Dim curr As String
        Dim theID As Integer

        If (i >= 0 And i < purchaseTransaGrid.Rows.Count - 1) Then


            selectedRow = purchaseTransaGrid.Rows(i)

            referanceLabel.Text = selectedRow.Cells(0).Value.ToString()
            invoiceField.Text = selectedRow.Cells(2).Value.ToString()
            dateCreatedField.Value = selectedRow.Cells(3).Value.ToString()
            locationDropBox.Text = selectedRow.Cells(4).Value.ToString()
            vendorIDLabel.Text = selectedRow.Cells(11).Value.ToString()
            vendorNameField.Text = selectedRow.Cells(1).Value.ToString()


            If selectedRow.Cells(5).Value = True Then

                statusLabel.Text = "Complete"
            ElseIf selectedRow.Cells(5).Value = False Then

                statusLabel.Text = "InComplete"
            End If
            gpCheckBox.Checked = selectedRow.Cells(6).Value.ToString()
            currencyField.Text = selectedRow.Cells(7).Value.ToString()






            If currencyField.Text = "US Dollars" Then
                curr = "$ "
            Else
                curr = "L.L "
            End If
            allItemsQty.Text = "0"
            allItemsPrice.Text = "0"
            Dim qty As String = selectedRow.Cells(8).Value.ToString()

            Dim currPrice As Decimal = 0

            If curr = "L.L " Then

                currPrice = (selectedRow.Cells(9).Value.ToString() * 1500)

            Else
                currPrice = selectedRow.Cells(9).Value.ToString()
            End If

            'pri = curr + currPrice

            allItemsQty.Text = qty
            allItemsPrice.Text = (currPrice).ToString

            theID = selectedRow.Cells(10).Value
            retrievedTranID = theID

            calculatedTotalQty = selectedRow.Cells(8).Value
            calculatedTotalCost = selectedRow.Cells(9).Value

            fillTheTransactionItems(theID)
            toBeUpdated = True

        Else

        End If
    End Sub

    '*********************************************

    'Fill datagridView with transaction ITEMS
    Sub fillTheTransactionItems(theID)
        'Get the TransactionID and the totals from the ReferanceNumber
        transactionData.Rows.Clear()

        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select db_owner.tbl_transactioned_items.*, db_owner.tbl_item.ItemID [itemSecID] from db_owner.tbl_transactioned_items, db_owner.tbl_item where 
             (db_owner.tbl_transactioned_items.TransactionID = '" & theID & "' and db_owner.tbl_transactioned_items.Status = 1 
              and db_owner.tbl_transactioned_items.ItemID = db_owner.tbl_item.ID)")

        If currencyChosen = "L" Then
            For i = 0 To dt.Rows.Count - 1

                transactionData.Rows.Add(New String() {Nothing, dt.Rows(i)("itemSecID").ToString(), dt.Rows(i)("ItemName").ToString(),
                                         dt.Rows(i)("Quantity").ToString(), Math.Round((dt.Rows(i)("UnitAvgCost") * 1500), 2),
                                         Math.Round((dt.Rows(i)("TotalCost") * 1500), 2), Nothing, dt.Rows(i)("ItemID").ToString(), dt.Rows(i)("import").ToString()})


            Next
        Else
            For i = 0 To dt.Rows.Count - 1

                transactionData.Rows.Add(New String() {Nothing, dt.Rows(i)("itemSecID").ToString(), dt.Rows(i)("ItemName").ToString(),
                                         dt.Rows(i)("Quantity").ToString(), Math.Round(dt.Rows(i)("UnitAvgCost"), 2),
                                         Math.Round(dt.Rows(i)("TotalCost"), 2), Nothing, dt.Rows(i)("ItemID").ToString(), dt.Rows(i)("import").ToString()})

            Next
        End If





    End Sub
    '''''''''''''''''''''''''''''''''''''''''''

    'Chenge isEnteredToGP value after ckeckbox change and change completion status accordingly
    Private Sub gpCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles gpCheckBox.CheckedChanged
        If gpCheckBox.Checked = True Then
            isEnteredToGP = True
            If vendorIDLabel.Text <> 0 And vendorIDLabel.Text <> "-" And invoiceField.Text <> String.Empty Then
                isComplete = True
                statusLabel.Text = "Complete"
                theStatusText = "Complete"
            Else
                isComplete = False
                statusLabel.Text = "InComplete"
                theStatusText = "InComplete"

            End If

        ElseIf gpCheckBox.Checked = False Then
            isEnteredToGP = False
            statusLabel.Text = "InComplete"
            theStatusText = "Complete"
        End If
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''

    'Calculating total and avarage Price on totalPrice onclick
    Private Sub totalPrice_PreviewKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs)
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

                If transactionData.Rows(i).Cells(7).Value = Nothing Then
                    alreadyAdded = True
                End If

            Next



            If textBox.Text <> String.Empty And transactionData.CurrentRow.Cells(7).Value <> Nothing Then
                updatedUnitPrice = textBox.Text







                currentItemID = transactionData.CurrentRow.Cells(7).Value
                updatedQty = transactionData.CurrentRow.Cells(3).Value
                'updatedTotalPrice = transactionData.CurrentRow.Cells(5).Value
                updatedTotalPrice = transactionData.CurrentRow.Cells(3).Value * updatedUnitPrice
                currentIndex = transactionData.CurrentRow.Index
                transactionData.CurrentRow.Cells(5).Value = updatedTotalPrice
                transactionTotalQuantity = 0
                transactionTotalPrice = 0

                For i As Integer = 0 To transactionData.Rows.Count - 2
                    If transactionData.Rows(i).Cells(7).Value.ToString <> String.Empty Then



                        If currentItemID = transactionData.Rows(i).Cells(7).Value And currentIndex <> i Then
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
    '********************************

    'on Items'Name GridView textChange
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
        transactionData.CurrentRow.Cells(7).Value = retrievedItemID

        Dim j As Integer
        For j = 0 To transactionData.Rows.Count - 1
            For Each pair As KeyValuePair(Of String, String) In addedItemsIDList

                Dim key As String = pair.Key
                If transactionData.Rows(j).Cells(2).Value.ToString IsNot Nothing Then

                    If key = transactionData.Rows(j).Cells(2).Value.ToString Then
                        retrievedUserItemID = pair.Value
                    End If

                End If

            Next

            transactionData.Rows(j).Cells(1).Value = retrievedUserItemID
        Next

    End Sub
    '''''''''''''''''''''''''''''''''''''''''''
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
        End If


    End Sub
    '''''''''''''''''''''''''''''''''''''''''''
    'Allow or disallow to add new rows to datagridview
    Private Sub transactionData_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles transactionData.UserAddedRow
        transactionData.AllowUserToAddRows = False


    End Sub
    '''''''''''''''''''''''''''''''''''''''''''
    'Btn Clicks in the DatagridView
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

                'transactionData.AllowUserToAddRows = True
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



                currentItemID = transactionData.CurrentRow.Cells(7).Value
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
                    If transactionData.Rows(i).Cells(7).Value <> Nothing Then


                        'If currentItemID = transactionData.Rows(i).Cells(7).Value And currentIndex <> i Then
                        '    transactionData.Rows(i).Cells(3).Value += updatedQty
                        '    transactionData.Rows(i).Cells(4).Value = (transactionData.Rows(i).Cells(4).Value + updatedUnitPrice) / 2
                        '    transactionData.Rows(i).Cells(5).Value = transactionData.Rows(i).Cells(3).Value * transactionData.Rows(i).Cells(4).Value
                        '    foundItem = True
                        'End If

                        If currentItemID = transactionData.Rows(i).Cells(7).Value And currentIndex <> i Then
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
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 6 Then

            If transactionData.CurrentRow.Cells(7).Value IsNot Nothing And
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

                transactionData.CurrentRow.Cells(7).Value = Nothing
                transactionData.CurrentRow.Cells(2).Value = Nothing
                transactionData.CurrentRow.Cells(3).Value = Nothing
                transactionData.CurrentRow.Cells(4).Value = Nothing
                transactionData.CurrentRow.Cells(5).Value = Nothing

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
    '''''''''''''''''''''''''''''''''''''''''''
    'Updating Transaction after selection
    Sub updateTheTransaction()

        Dim dt As DataTable = New DataTable
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_transaction Set InvoiceNumber = '" & invoiceField.Text & "', LocationID = '" & retrievedLocID & "',
            VendorID = '" & vendorIDLabel.Text & "', VendorName = '" & vendorNameField.Text & "', TotalQty = '" & allItemsQty.Text & "', TotalCost = '" & allItemsPrice.Text & "',
            EnteryStatus = '" & isComplete & "', StatusText = '" & theStatusText & "', LocationName = '" & locationDropBox.Text & "', EnteredToGP = '" & isEnteredToGP & "', Currancy = '" & currencyField.Text &
            "', RevisionUserID = '" & logedInUserID & "',RevisionDate = '" & today & "',DateCreated = '" & dateCreatedField.Value & "'  where (ID = '" & retrievedTranID & "')"

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

            myCommand1.CommandText = "Delete  From db_owner.tbl_transactioned_items where (TransactionID = '" & retrievedTranID & "')"

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
    '''''''''''''''''''''''''''''''''''''''''''
    'Update the Inventory Location after items change
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

        For i As Integer = 0 To fDt.Rows.Count - 1

            Dim tempName = fDt.Rows(i)("ItemName").ToString
            itemIDToReduce = fDt.Rows(i)("ItemID").ToString
            itemQtyToReduce = fDt.Rows(i)("Quantity").ToString
            itemUnitPriceToReduce = fDt.Rows(i)("UnitAvgCost").ToString
            itemTotalPriceToReduce = fDt.Rows(i)("TotalCost").ToString
            itemLocationIDToReduce = retrievedLocID

            Dim sDt As New DataTable
            sDt = databaseObject.SelectMethode("Select ItemID, ItemQty, ItemAvgPrice, ItemTotalPrice 
            from db_owner.tbl_location_inventory where ( ItemID = '" & itemIDToReduce & "' and LocationID = '" & itemLocationIDToReduce & "')")

            theItemID = itemIDToReduce

            theCalculatedInventoryItemQty = (sDt.Rows(0)("ItemQty").ToString - itemQtyToReduce)
            If theCalculatedInventoryItemQty = 0 Then

                theCalculatedInventoryItemAvgPrice = itemUnitPriceToReduce


            ElseIf theCalculatedInventoryItemQty <> 0 Then
                theCalculatedInventoryItemAvgPrice = (sDt.Rows(0)("ItemAvgPrice").ToString + itemUnitPriceToReduce) / 2
                'theCalculatedInventoryItemAvgPrice = theCalculatedInventoryItemTotalPrice / theCalculatedInventoryItemQty
            End If


            'theCalculatedInventoryItemQty = (sDt.Rows(0)("ItemQty").ToString - itemQtyToReduce)
            theCalculatedInventoryItemTotalPrice = (sDt.Rows(0)("ItemTotalPrice").ToString() - itemTotalPriceToReduce)
            If theCalculatedInventoryItemQty <> 0 Then
                theCalculatedInventoryItemAvgPrice = theCalculatedInventoryItemTotalPrice / theCalculatedInventoryItemQty

            Else
                theCalculatedInventoryItemAvgPrice = 0
            End If

            'theCalculatedInventoryItemTotalPrice = (theCalculatedInventoryItemQty * theCalculatedInventoryItemAvgPrice)

            updateLocationInventory()
        Next

    End Sub

    'Submit entered data
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
            If vendorIDLabel.Text = "-" Or vendorNameField.Text = String.Empty Or gpCheckBox.Checked = False Or invoiceField.Text = String.Empty Then
                isComplete = False
                statusLabel.Text = "InComplete"
                theStatusText = "InComplete"
            End If

            If isComplete = True Then
                statusLabel.Text = "Complete"
                theStatusText = "Complete"
            End If

            If gpCheckBox.Checked Then
                isEnteredToGP = True
            ElseIf gpCheckBox.Checked <> True Then
                isEnteredToGP = False

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

                'MessageBox.Show(" THE TOTALS " & totQty & " AND " & totPrice)
                'MessageBox.Show("ADDING TOTAL " & totPrice)

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
        Dim query As String = String.Empty
        query &= "INSERT INTO db_owner.tbl_transaction (InvoiceNumber,TransactionID,LocationID,VendorID,VendorName,TotalQty,TotalCost,ReferanceNumber,DateCreated,EnteryStatus,LocationName,"
        query &= "EnteredToGP,Status,StatusText,CreateUserID,CreateDate,RevisionUserID,RevisionDate,Currancy)"
        query &= "VALUES (@InvoiceNumber, @TransactionID, @LocationID, @VendorID, @VendorName, @TotalQty, @TotalCost, @ReferanceNumber, @DateCreated, @EnteryStatus, @LocationName,"
        query &= "@EnteredToGP, @Status, @StatusText, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate,@Currancy)"

        Using comm As New SqlCommand()
            With comm
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = query
                .Parameters.AddWithValue("@InvoiceNumber", invoiceField.Text)
                .Parameters.AddWithValue("@TransactionID", retrievedTranTypeID)
                .Parameters.AddWithValue("@LocationID", retrievedLocID)
                .Parameters.AddWithValue("@VendorID", vendorIDLabel.Text)
                .Parameters.AddWithValue("@VendorName", vendorNameField.Text)
                .Parameters.AddWithValue("@TotalQty", allItemsQty.Text)
                .Parameters.AddWithValue("@TotalCost", allItemsPrice.Text)
                .Parameters.AddWithValue("@ReferanceNumber", referanceLabel.Text)
                .Parameters.AddWithValue("@DateCreated", dateCreatedField.Value)
                .Parameters.AddWithValue("@EnteryStatus", isComplete)
                .Parameters.AddWithValue("@LocationName", locationDropBox.Text)
                .Parameters.AddWithValue("@EnteredToGP", isEnteredToGP)
                .Parameters.AddWithValue("@Status", 1)
                .Parameters.AddWithValue("@StatusText", theStatusText)
                .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                .Parameters.AddWithValue("@CreateDate", today)
                .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                .Parameters.AddWithValue("@RevisionDate", today)
                .Parameters.AddWithValue("@Currancy", currencyField.Text)
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
    'Enter Items in Transactioned Items
    Private Sub insertIntoItems()

        'Get the TransactionID and the totals from the ReferanceNumber

        Dim dt As DataTable = New DataTable

        dt = databaseObject.SelectMethode("Select * from db_owner.tbl_transaction where (ReferanceNumber = '" & referanceLabel.Text & "' and Status = 1)")
        retrievedTranID = dt.Rows(0)("ID").ToString()
        retrievedTotalQty = dt.Rows(0)("TotalQty")
        retrievedTotalPrice = dt.Rows(0)("TotalCost")



        ''''''''''''''''''''''''''''''''''''''''''''''''''



        If transactionData.Rows.Count = 0 Then
            deleteEmptyTransaction()
            Exit Sub
        End If
        Dim i As Integer
        'If transactionData.Rows(i).Cells(7).Value.ToString IsNot Nothing Then
        If toBeDeleted = True Then
            For i = 0 To transactionData.Rows.Count - 1


                If transactionData.Rows(i).Cells(7).Value.ToString IsNot Nothing Then


                    theItemID = transactionData.Rows(i).Cells(7).Value
                    theItemName = transactionData.Rows(i).Cells(2).Value
                    theItemQuantity = transactionData.Rows(i).Cells(3).Value
                    theItemUnitprice = transactionData.Rows(i).Cells(4).Value
                    theItemTotalPrice = transactionData.Rows(i).Cells(5).Value
                    toBeImported = transactionData.Rows(i).Cells(8).Value

                    'transactionData.Rows(i).Cells(0).Value = retrievedItemID

                    If currencyChosen = "L" Then

                        theItemTotalPrice = (theItemTotalPrice / 1500)
                        theItemUnitprice = (theItemUnitprice / 1500)
                    End If

                    Dim query As String = String.Empty
                    query &= "INSERT INTO db_owner.tbl_transactioned_items (TransactionID,ItemID,ItemName,Quantity,"
                    query &= "UnitAvgCost,TotalCost, VendorID,VendorName,TransactionName,import,Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
                    query &= "VALUES (@TransactionID, @ItemID, @ItemName,@Quantity, @UnitAvgCost, @TotalCost,@VendorID,@VendorName,"
                    query &= "@TransactionName, @import, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

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
                            .Parameters.AddWithValue("@VendorID", vendorIDLabel.Text)
                            .Parameters.AddWithValue("@VendorName", vendorNameField.Text)
                            .Parameters.AddWithValue("@TransactionName", "Purchase")
                            .Parameters.AddWithValue("@import", toBeImported)
                            .Parameters.AddWithValue("@Status", 1)
                            .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                            .Parameters.AddWithValue("@CreateDate", today)
                            .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                            .Parameters.AddWithValue("@RevisionDate", today)
                        End With

                        conn.Open()
                        comm.ExecuteNonQuery()
                        conn.Close()
                        If theItemUnitprice = 0 Then
                            isComplete = False
                            statusLabel.Text = "InComplete"
                            theStatusText = "InComplete"
                        End If

                    End Using
                End If

                Dim sDt As New DataTable
                sDt = databaseObject.SelectMethode("Select ItemQty, ItemAvgPrice, ItemTotalPrice, LocationID, ItemID 
                                               From db_owner.tbl_location_inventory 
                                               Where (LocationID ='" & retrievedLocID &
                                                   "' And ItemID = '" & theItemID & "')")
                If sDt.Rows.Count = 0 Then
                    addToTheInventory()
                Else

                    'MessageBox.Show(" 1 " & theCalculatedInventoryItemQty & " 2 " & theCalculatedInventoryItemTotalPrice & " 3 " & theCalculatedInventoryItemAvgPrice)

                    theCalculatedInventoryItemQty = 0
                    theCalculatedInventoryItemAvgPrice = 0
                    theCalculatedInventoryItemTotalPrice = 0


                    theCalculatedInventoryItemQty = sDt.Rows(0)("ItemQty").ToString() + theItemQuantity
                    theCalculatedInventoryItemTotalPrice = (sDt.Rows(0)("ItemTotalPrice").ToString() + theItemTotalPrice)
                    theCalculatedInventoryItemAvgPrice = theCalculatedInventoryItemTotalPrice / theCalculatedInventoryItemQty

                    updateLocationInventory()


                End If


            Next
            toBeDeleted = False
        Else
            For i = 0 To transactionData.Rows.Count - 2


                If transactionData.Rows(i).Cells(7).Value.ToString IsNot Nothing Then


                    theItemID = transactionData.Rows(i).Cells(7).Value
                    theItemName = transactionData.Rows(i).Cells(2).Value
                    theItemQuantity = transactionData.Rows(i).Cells(3).Value
                    theItemUnitprice = transactionData.Rows(i).Cells(4).Value
                    theItemTotalPrice = transactionData.Rows(i).Cells(5).Value
                    toBeImported = transactionData.Rows(i).Cells(8).Value

                    'transactionData.Rows(i).Cells(0).Value = retrievedItemID

                    If currencyChosen = "L" Then

                        theItemTotalPrice = (theItemTotalPrice / 1500)
                        theItemUnitprice = (theItemUnitprice / 1500)
                    End If

                    Dim query As String = String.Empty
                    query &= "INSERT INTO db_owner.tbl_transactioned_items (TransactionID,ItemID,ItemName,Quantity,"
                    query &= "UnitAvgCost,TotalCost, VendorID,VendorName,TransactionName, import,Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
                    query &= "VALUES (@TransactionID, @ItemID, @ItemName,@Quantity, @UnitAvgCost, @TotalCost,@VendorID,@VendorName,"
                    query &= "@TransactionName, @import, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

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
                            .Parameters.AddWithValue("@VendorID", vendorIDLabel.Text)
                            .Parameters.AddWithValue("@VendorName", vendorNameField.Text)
                            .Parameters.AddWithValue("@TransactionName", "Purchase")
                            .Parameters.AddWithValue("@import", toBeImported)
                            .Parameters.AddWithValue("@Status", 1)
                            .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                            .Parameters.AddWithValue("@CreateDate", today)
                            .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                            .Parameters.AddWithValue("@RevisionDate", today)
                        End With

                        conn.Open()
                        comm.ExecuteNonQuery()
                        conn.Close()
                        If theItemUnitprice = 0 Then
                            isComplete = False
                            statusLabel.Text = "InComplete"
                            theStatusText = "InComplete"
                        End If

                    End Using
                End If

                Dim sDt As New DataTable
                sDt = databaseObject.SelectMethode("Select ItemQty, ItemAvgPrice, ItemTotalPrice, LocationID, ItemID 
                                               From db_owner.tbl_location_inventory 
                                               Where (LocationID ='" & retrievedLocID &
                                                   "' And ItemID = '" & theItemID & "')")
                If sDt.Rows.Count = 0 Then
                    addToTheInventory()
                Else
                    theCalculatedInventoryItemQty = 0
                    theCalculatedInventoryItemAvgPrice = 0
                    theCalculatedInventoryItemTotalPrice = 0


                    theCalculatedInventoryItemQty = sDt.Rows(0)("ItemQty").ToString() + theItemQuantity
                    theCalculatedInventoryItemTotalPrice = (sDt.Rows(0)("ItemTotalPrice").ToString() + theItemTotalPrice)
                    theCalculatedInventoryItemAvgPrice = theCalculatedInventoryItemTotalPrice / theCalculatedInventoryItemQty

                    updateLocationInventory()


                End If


            Next
        End If



        If isComplete = True Then
                statusLabel.Text = "Complete"
                theStatusText = "Complete"
            End If

            updateTransactions()
            clearFields()


            purchaseTransaGrid.DataSource = getPurchaseTransa()

            purchaseTransaGrid.Columns(1).Width = 90
            purchaseTransaGrid.Columns(2).Width = 120
            purchaseTransaGrid.Columns(3).Width = 87
            purchaseTransaGrid.Columns(4).Width = 90

            purchaseTransaGrid.Columns(0).Visible = False
            purchaseTransaGrid.Columns(5).Visible = False
            purchaseTransaGrid.Columns(6).Visible = False
            purchaseTransaGrid.Columns(7).Visible = False
            purchaseTransaGrid.Columns(8).Visible = False
            purchaseTransaGrid.Columns(9).Visible = False
            purchaseTransaGrid.Columns(10).Visible = False
            purchaseTransaGrid.Columns(11).Visible = False


        'End If

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    ' Add Entered Items to the Locations Inventory
    Sub addToTheInventory()
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
                    .Parameters.AddWithValue("@LocationID", retrievedLocID)
                    .Parameters.AddWithValue("@LocationName", locationDropBox.Text)

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


    'Update the Locations Inventory after updating items
    Sub updateLocationInventory()

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim rows As Integer
        Dim myCommand As SqlCommand = conn.CreateCommand()

        Try

            conn.Open()

            myCommand.CommandText = "Update db_owner.tbl_location_inventory Set ItemQty = '" & theCalculatedInventoryItemQty & "',
            ItemAvgPrice = '" & theCalculatedInventoryItemAvgPrice & "', ItemTotalPrice = '" & theCalculatedInventoryItemTotalPrice & "', LocationID = '" & retrievedLocID & "',
            LocationName = '" & locationDropBox.Text & "' where(ItemID = '" & theItemID & "' and LocationID = '" & retrievedLocID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try
    End Sub

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

            myCommand.CommandText = "Update db_owner.tbl_transaction Set TotalQty = '" & allItemsQty.Text & "', TotalCost = '" & allItemsPrice.Text & "', 
            EnteryStatus = '" & isComplete & "', StatusText = '" & theStatusText & "'  where (ID = '" & retrievedTranID & "')"
            rows = myCommand.ExecuteNonQuery()

        Catch ex As SqlException

            ' handle error
            Console.Write("Unable to Add")

        Finally

            conn.Close()

        End Try


    End Sub


    'Cancel OnClick
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        locationDropBox.Enabled = True
        retrievedTranID = 0
        toBeUpdated = False
        clearFields()
    End Sub

    'Retrieve data with searched fields
    Function getSearchedPurchasedTransaWithChecks()

        For Each pair As KeyValuePair(Of String, Integer) In typeList

            Dim key As String = pair.Key
            If key.Contains("Pur") Or key.Contains("pur") Then
                retrievedTranTypeID = pair.Value

            End If
        Next

        If completeCheckBox.Checked = True Then
            theSearchStatus = "Complete"
        ElseIf InCompleteCheckBox.Checked = True Then
            theSearchStatus = "InComplete"

        End If

        Dim dtPurchaseTransactions As New DataTable

        dtPurchaseTransactions = databaseObject.SelectMethode("SELECT ReferanceNumber, VendorName as [Name] ,InvoiceNumber as [Invoice Number],
        DateCreated as [Date],LocationName as [Location],
        EnteryStatus , EnteredToGP, Currancy, TotalQty, TotalCost, ID,VendorID,StatusText as [Status] FROM db_owner.tbl_transaction where (TransactionID = '" & retrievedTranTypeID & "'
        and InvoiceNumber LIKE '%" & searchInvoice.Text & "%' and VendorName LIKE '%" & searchVendor.Text &
        "%' and LocationName LIKE '%" & searchLocation.Text & "%' and StatusText = '" & theSearchStatus & "' and Status = 1)")
        ' 

        Return dtPurchaseTransactions
    End Function
    '**********************************

    'Display the transaction data after check boxes ticked
    Private Sub completeCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles completeCheckBox.CheckedChanged

        InCompleteCheckBox.Checked = False

        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithChecks()
        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90

        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False

    End Sub

    Private Sub InCompleteCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles InCompleteCheckBox.CheckedChanged


        completeCheckBox.Checked = False
        purchaseTransaGrid.DataSource = getSearchedPurchasedTransaWithChecks()
        purchaseTransaGrid.Columns(1).Width = 90
        purchaseTransaGrid.Columns(2).Width = 120
        purchaseTransaGrid.Columns(3).Width = 87
        purchaseTransaGrid.Columns(4).Width = 90

        purchaseTransaGrid.Columns(0).Visible = False
        purchaseTransaGrid.Columns(5).Visible = False
        purchaseTransaGrid.Columns(6).Visible = False
        purchaseTransaGrid.Columns(7).Visible = False
        purchaseTransaGrid.Columns(8).Visible = False
        purchaseTransaGrid.Columns(9).Visible = False
        purchaseTransaGrid.Columns(10).Visible = False
        purchaseTransaGrid.Columns(11).Visible = False
    End Sub

    '******************************************************

    'Deleting Transaction
    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click

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
            (LocationID = '" & retrievedLocID & "' and ItemID = '" & theItemID & "')")

            theCalculatedInventoryItemQty = sDt.Rows(0)("ItemQty").ToString - theItemQuantity
            theCalculatedInventoryItemAvgPrice = sDt.Rows(0)("ItemAvgPrice").ToString
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

            myCommand.CommandText = "Delete From db_owner.tbl_transactioned_items where (TransactionID = '" & retrievedTranID & "')"

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
    End Sub

    'Delete the selected transaction
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

            purchaseTransaGrid.DataSource = getPurchaseTransa()
            purchaseTransaGrid.Columns(1).Width = 90
            purchaseTransaGrid.Columns(2).Width = 120
            purchaseTransaGrid.Columns(3).Width = 87
            purchaseTransaGrid.Columns(4).Width = 90

            purchaseTransaGrid.Columns(0).Visible = False
            purchaseTransaGrid.Columns(5).Visible = False
            purchaseTransaGrid.Columns(6).Visible = False
            purchaseTransaGrid.Columns(7).Visible = False
            purchaseTransaGrid.Columns(8).Visible = False
            purchaseTransaGrid.Columns(9).Visible = False
            purchaseTransaGrid.Columns(10).Visible = False
            purchaseTransaGrid.Columns(11).Visible = False

        End Try
        retrievedTranID = 0
    End Sub
    '**********************************************

    'Calculate the total price of Item after quantity or unit price change
    Private Sub transactionData_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles transactionData.CurrentCellDirtyStateChanged



        Dim calculatedTotal As Decimal = (transactionData.CurrentRow.Cells(3).Value * transactionData.CurrentRow.Cells(4).Value)
        transactionData.CurrentRow.Cells(5).Value = calculatedTotal

        Dim totalQty As Integer = 0
        Dim totalPrices As Decimal = 0

        For i As Integer = 0 To transactionData.Rows.Count - 1


            totalQty += transactionData.Rows(i).Cells(3).Value
            totalPrices += transactionData.Rows(i).Cells(5).Value

        Next


        'allItemsQty.Text = totalQty
        'allItemsPrice.Text = totalPrices
        itemsExist = True


    End Sub

    Private Sub invoiceField_TextChanged(sender As Object, e As EventArgs) Handles invoiceField.TextChanged
        If vendorNameField.Text <> String.Empty And gpCheckBox.Checked <> False Or invoiceField.Text <> String.Empty Then
            isComplete = True
            statusLabel.Text = "Complete"
            theStatusText = "Complete"
        Else
            isComplete = False
            statusLabel.Text = "InComplete"
            theStatusText = "InComplete"
        End If
    End Sub

    Private Sub currencyField_SelectedIndexChanged(sender As Object, e As EventArgs) Handles currencyField.SelectedIndexChanged
        If currencyField.Text = "US Dollars" Then
            currencyChosen = "$"
        Else
            currencyChosen = "L"
        End If
    End Sub




    '*********************************************************************

End Class