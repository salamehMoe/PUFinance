Imports System.Data.SqlClient

Public Class assetsImported

    Dim dataBaseobj As New DatabaseAccesClass
    Dim logedInUserID As Integer = My.Settings.userID

    Dim itemsList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))

    Dim itemNameIDList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))

    Dim addedItemsIDList As List(Of KeyValuePair(Of String, String)) =
    New List(Of KeyValuePair(Of String, String))

    Dim locationList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))

    Dim vendorList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))

    Dim classList As List(Of KeyValuePair(Of String, Integer)) =
    New List(Of KeyValuePair(Of String, Integer))

    Dim retrievedItemID As Integer = -1
    Dim retrievedUserItemID As String
    Dim combinedNameID As String = String.Empty
    Dim combinedNameIDToCompare As String = String.Empty
    Dim retrievedTranIDFromList As Integer = -1
    Dim retrievedLocID As Integer = -1
    Dim retrievedVendorID As Integer = -1
    Dim theADate As Date
    Dim barcodeDt As New DataTable
    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
    Dim conn2 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
    Dim retrievedClassID As Integer = -1

    Dim theSelectedBarcode As String = String.Empty
    Dim theAssetNamePrefix As String = String.Empty
    Dim theItemName As String = String.Empty
    Dim theItemID As Integer = -1
    Dim theTransID As Integer = -1


    Dim theLocationName As String = String.Empty
    Dim theClassName As String = String.Empty
    Dim locInvOfImportedAssetDt As New DataTable


    Private Sub assetsImported_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        My.Settings.fromAssetImported = False
        My.Settings.fromAssetPurchase = False




        getUserItems()
        getImportedAssets()
        getClasses()
        getLocations()

        Dim dt As New DataTable
        dt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_imported_assets")

        For i As Integer = 0 To transactionData.Rows.Count - 1
            For j As Integer = 0 To dt.Rows.Count - 1

                If transactionData.Rows(i).Cells(11).Value = dt.Rows(j)("mainAssetID") AndAlso transactionData.Rows(i).Cells(12).Value = dt.Rows(j)("transactionID") Then

                    transactionData.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    transactionData.Rows(i).Cells(2).Value = dt.Rows(j)("className")
                    transactionData.Rows(i).Cells(13).Value = dt.Rows(j)("classID")
                    transactionData.Rows(i).Cells(8).Value = dt.Rows(j)("locationName")
                    transactionData.Rows(i).Cells(14).Value = dt.Rows(j)("locationID")

                End If

            Next


        Next


    End Sub

    Sub getLocations()
        locationCell.Items.Clear()
        locationList.Clear()

        Dim dt As New DataTable
        dt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_asset_Location where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            locationList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("LocationName").ToString(), dt.Rows(i)("ID").ToString()))
        Next


        autoCompleteLocations()
    End Sub

    Sub autoCompleteLocations()

        Dim dt As DataTable = New DataTable()

        dt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_asset_Location where Status = 1")

        Dim row As DataRow = dt.NewRow()
        dt.Rows.InsertAt(row, 0)

        locationCell.DataSource = dt
        locationCell.DisplayMember = "locationName"
        locationCell.ValueMember = "locationName"

    End Sub
    Private Sub getUserItems()

        addedItemsIDList.Clear()


        Dim dt As DataTable = New DataTable
        dt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_Item where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            addedItemsIDList.Add(New KeyValuePair(Of String, String)(dt.Rows(i)("ItemName").ToString(), dt.Rows(i)("ItemID").ToString()))

        Next

    End Sub

    'For filling the Asset Class DropBox
    Private Sub getClasses()

        assetClass.Items.Clear()
        classList.Clear()



        Dim dt As DataTable = New DataTable
        dt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_asset_class where Status = 1")



        For i = 0 To dt.Rows.Count - 1
            classList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("ClassName").ToString(), dt.Rows(i)("ID")))
        Next
        autoCompleteClasses()

    End Sub

    Sub autoCompleteClasses()

        Dim dt As DataTable = New DataTable()

        dt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_asset_class where Status = 1")

        Dim row As DataRow = dt.NewRow()
        dt.Rows.InsertAt(row, 0)

        assetClass.DataSource = dt
        assetClass.DisplayMember = "ClassName"
        assetClass.ValueMember = "ClassName"

    End Sub

    '****************************************
    Sub getImportedAssets()

        'Retrieving Item Data from Purchase

        Dim totalQty As Integer = 0
        Dim totalPrice As Decimal = 0
        Dim theImportedTransID As Integer = -1
        Dim theItemIDToCheck As Integer = -1
        Dim dt As DataTable = New DataTable()
        Dim transDT As New DataTable

        dt = dataBaseobj.SelectMethode("Select db_owner.tbl_transactioned_items.*,db_owner.tbl_transaction.* FROM db_owner.tbl_transaction,db_owner.tbl_transactioned_items
        where (db_owner.tbl_transactioned_items.import = 1 and db_owner.tbl_transactioned_items.TransactionID = db_owner.tbl_transaction.ID)")

        retrievedItemID = dt.Rows(0)("ItemID")


        transDT = dataBaseobj.SelectMethode("Select ID from db_owner.tbl_asset_transactions where (isForImported = 1)")

        'Add the New Transaction for imported Asset and gets its ID
        If transDT.Rows.Count = 0 Then

            Dim query2 As String = String.Empty
            query2 = "INSERT INTO db_owner.tbl_asset_transactions (isForImported)
                      VALUES(@isForImported)"

            Using comm2 As New SqlCommand()
                With comm2
                    .Connection = conn2
                    .CommandType = CommandType.Text
                    .CommandText = query2
                    .Parameters.AddWithValue("@isForImported", 1)
                End With
                conn2.Open()
                comm2.ExecuteNonQuery()
                conn2.Close()

            End Using

        End If
        '*****************************************************************
        transDT = dataBaseobj.SelectMethode("Select ID from db_owner.tbl_asset_transactions where (isForImported = 1)")
        theImportedTransID = transDT.Rows(0)("ID")


        For i As Integer = 0 To dt.Rows.Count - 1

            transactionData.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        Next

        For i As Integer = 0 To dt.Rows.Count - 1

            theItemIDToCheck = dt.Rows(i)("ItemID").ToString()

            For j As Integer = 0 To transactionData.Rows.Count - 1
                If theItemIDToCheck = transactionData.Rows(i).Cells(11).Value Then

                End If
            Next

            'transactionData.Rows(i).Cells(0).Value = dt.Rows(i)("ItemID").ToString()
            transactionData.Rows(i).Cells(1).Value = dt.Rows(i)("ItemName").ToString()
            transactionData.Rows(i).Cells(3).Value = dt.Rows(i)("Quantity").ToString()
            transactionData.Rows(i).Cells(4).Value = dt.Rows(i)("UnitAvgCost").ToString()
            transactionData.Rows(i).Cells(5).Value = dt.Rows(i)("TotalCost").ToString()
            'transactionData.Rows(i).Cells(8).Value = dt.Rows(i)("locationName").ToString()
            transactionData.Rows(i).Cells(9).Value = dt.Rows(i)("VendorName").ToString()
            transactionData.Rows(i).Cells(11).Value = dt.Rows(i)("ItemID").ToString()
            theADate = dt.Rows(i)("DateCreated")
            transactionData.Rows(i).Cells(7).Value = Format(theADate, "MMM d,yyyy")

            For Each pair As KeyValuePair(Of String, String) In addedItemsIDList

                Dim key As String = pair.Key
                If transactionData.Rows(i).Cells(1).Value.ToString IsNot Nothing Then
                    If key = transactionData.Rows(i).Cells(1).Value.ToString Then
                        retrievedUserItemID = pair.Value
                    End If

                End If

            Next

            transactionData.Rows(i).Cells(0).Value = retrievedUserItemID
            transactionData.Rows(i).Cells(12).Value = theImportedTransID

            theItemID = transactionData.Rows(i).Cells(11).Value
            theTransID = transactionData.Rows(i).Cells(12).Value


            barcodeDt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_asset_barcodes where ( transID = '" & theTransID & "' 
                and itemID = '" & theItemID & "')")

            transactionData.Rows(i).Cells(6).Value = barcodeDt.Rows.Count & " Barcodes Added"

            totalQty += transactionData.Rows(i).Cells(3).Value
            totalPrice += transactionData.Rows(i).Cells(5).Value



            theItemName = transactionData.Rows(i).Cells(1).Value
            '**********************************************

        Next
        '***********************************************

        'Join similar assets
        For k As Integer = transactionData.Rows.Count - 2 To 0 Step -1

            theItemIDToCheck = transactionData.Rows(k).Cells(11).Value

            For j As Integer = transactionData.Rows.Count - 2 To 0 Step -1

                If theItemIDToCheck = transactionData.Rows(j).Cells(11).Value And k <> j Then

                    Dim Qty1 As Integer = transactionData.Rows(j).Cells(3).Value
                    Dim Qty2 As Integer = transactionData.Rows(k).Cells(3).Value
                    Dim allQty As Integer = Qty1 + Qty2
                    transactionData.Rows(j).Cells(3).Value = allQty

                    Dim totalP1 As Double = transactionData.Rows(j).Cells(5).Value
                    Dim totalP2 As Double = transactionData.Rows(k).Cells(5).Value
                    Dim allTotals = totalP1 + totalP2

                    Dim theNewUPrice = allTotals / allQty
                    transactionData.Rows(j).Cells(4).Value = (Math.Round((theNewUPrice), 2)).ToString
                    transactionData.Rows(j).Cells(5).Value = (Math.Round((theNewUPrice * allQty), 2)).ToString

                    transactionData.Rows.RemoveAt(k)
                    Exit For
                End If


            Next


        Next


        '**************************************


        allItemsQty.Text = totalQty
        allItemsPrice.Text = totalPrice
    End Sub

    Private Sub transactionData_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles transactionData.EditingControlShowing

        If transactionData.CurrentCell.RowIndex <> -1 Then


            If transactionData.CurrentCell.ColumnIndex = 2 Then
                Dim combo As ComboBox = CType(e.Control, ComboBox)
                If (combo IsNot Nothing) Then
                    RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf classNameField_SelectionChangeCommitted)
                    ' Add the event handler. 
                    AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf classNameField_SelectionChangeCommitted)
                End If
            End If

            If transactionData.CurrentCell.ColumnIndex = 8 Then
                Dim combo2 As ComboBox = CType(e.Control, ComboBox)
                If (combo2 IsNot Nothing) Then
                    RemoveHandler combo2.SelectionChangeCommitted, New EventHandler(AddressOf locationNameField_SelectionChangeCommitted)
                    ' Add the event handler. 
                    AddHandler combo2.SelectionChangeCommitted, New EventHandler(AddressOf locationNameField_SelectionChangeCommitted)
                End If
            End If


        End If
    End Sub

    Private Sub transactionData_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles transactionData.CellPainting

        If e.ColumnIndex = 10 AndAlso e.RowIndex >= 0 Then
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            Dim bmpFind As Bitmap = My.Resources.close
            Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
            e.Graphics.DrawIcon(ico, e.CellBounds.Left + 5, e.CellBounds.Top + 3)
            e.Handled = True
        End If



    End Sub

    Private Sub transactionData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles transactionData.CellContentClick

        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 6 Then


            My.Settings.fromAssetImported = True
            My.Settings.fromAssetPurchase = False
            My.Settings.barcodeQty = transactionData.CurrentRow.Cells(3).Value

            Dim barcodeAdd = New barcodeForm
            Dim dt As New DataTable
            Dim theItemID As Integer = transactionData.CurrentRow.Cells(11).Value

            If transactionData.CurrentRow.Cells(11).Value <> Nothing And transactionData.CurrentRow.Cells(11).Value > 0 Then

                barcodeAdd.barcodeListBox.Items.Clear()
                barcodeAdd.barcodeList.Clear()

                Dim theTransID As Integer = -1

                theTransID = transactionData.CurrentRow.Cells(12).Value

                If theTransID > 0 Then


                    My.Settings.barcodesID = theItemID
                    My.Settings.barcodeTrans = theTransID



                    Dim dt2 As New DataTable
                    dt2 = dataBaseobj.SelectMethode("Select itemBarcode from db_owner.tbl_asset_barcodes where itemID = '" & theItemID &
                                                          "' and transID = '" & theTransID & "'")


                    If dt2.Rows.Count > 0 Then

                        For i As Integer = 0 To dt2.Rows.Count - 1

                            theSelectedBarcode = dt2.Rows(i)("itemBarcode").ToString
                            barcodeAdd.barcodeListBox.Items.Add(theSelectedBarcode)
                            barcodeAdd.barcodeList.Add(theSelectedBarcode)


                        Next

                    End If

                    If transactionData.CurrentRow.Cells(2).Value <> String.Empty Then
                        barcodeAdd.Show()
                    Else
                        MessageBox.Show("Please Select a valid Class First")
                    End If


                End If
            End If
        End If


        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 And transactionData.CurrentCell.ColumnIndex = 10 Then

            Dim selectedIndex As Integer = e.RowIndex
            Dim selectedItemId As Integer = transactionData.CurrentRow.Cells(11).Value
            Dim selectedTransId As Integer = transactionData.CurrentRow.Cells(12).Value

            Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            'Dim rows As Integer
            'Dim myCommand As SqlCommand = conn.CreateCommand()

            'Try

            '    conn.Open()


            '    myCommand.CommandText = "Update db_owner.tbl_transactioned_items Set  import = 0 
            '                                 where (ItemID = '" & selectedItemId & "' and TransactionID = '" & selectedTransId & "')"

            '    rows = myCommand.ExecuteNonQuery()

            'Catch ex As SqlException

            '    ' handle error
            '    Console.Write("Unable to Add")
            '    MessageBox.Show(ex.Message)

            'Finally

            '    conn.Close()

            'End Try



            Dim importedTransIDDt As New DataTable
            Dim theLocationInIported As Integer
            Dim getAssetIDDt As New DataTable
            Dim theRealAssetID As Integer
            Dim assetPropsFromImportedDt As New DataTable
            Dim toBeDeletedDt As New DataTable
            Dim qtyOfToBeDeleted As Integer
            Dim assetUPriceOfToBeDeleted As Decimal
            Dim totalPriceOfToBeDeleted As Decimal
            Dim locInvAssetToBeDeletedQuery As Integer

            'Checks if the Transaction for theImported is found and gets its ID

            importedTransIDDt = dataBaseobj.SelectMethode("Select ID from db_owner.tbl_asset_transactions where (isForImported = 1)")
            Dim theImportedTransID As Integer = importedTransIDDt.Rows(0)("ID")


            '******************************************************************

            'Get the Real Item ID from tbl_asset 

            getAssetIDDt = dataBaseobj.SelectMethode("Select ID from db_owner.tbl_asset 
            where (assetName = '" & transactionData.CurrentRow.Cells(1).Value & "')")

            theRealAssetID = getAssetIDDt.Rows(0)("ID")
            '****************************



            assetPropsFromImportedDt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_imported_assets where 
            (mainAssetID = '" & transactionData.CurrentRow.Cells(11).Value & "' 
            and transactionID = '" & theImportedTransID & "')")

            If assetPropsFromImportedDt.Rows.Count > 0 Then

                theLocationInIported = assetPropsFromImportedDt.Rows(0)("locationID")

            End If




            toBeDeletedDt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_location_asset_inventory 
                where (assetID = '" & theRealAssetID & "' 
                and assetLocationID =  '" & theLocationInIported & "')")

            If toBeDeletedDt.Rows.Count > 0 Then


                qtyOfToBeDeleted = (toBeDeletedDt.Rows(0)("assetQty") - transactionData.CurrentRow.Cells(3).Value)
                assetUPriceOfToBeDeleted = transactionData.CurrentRow.Cells(4).Value
                totalPriceOfToBeDeleted = qtyOfToBeDeleted * assetUPriceOfToBeDeleted




                Dim myCommandInLocInv As SqlCommand = conn.CreateCommand()

                Try
                    conn.Open()

                    myCommandInLocInv.CommandText = "Update db_owner.tbl_location_asset_inventory 
                                Set assetQty = '" & qtyOfToBeDeleted & "' ,
                                assetUnitPrice = '" & assetUPriceOfToBeDeleted & "',
                                assetTotalPrice = '" & totalPriceOfToBeDeleted & "',                          
                                Status = 1,
                                isDeleted = 1
                                where ( assetID = '" & theRealAssetID & "'
                                and assetLocationID = '" & theLocationInIported & "') "

                    locInvAssetToBeDeletedQuery = myCommandInLocInv.ExecuteNonQuery()

                Catch ex As SqlException
                    ' handle error
                    MessageBox.Show(ex.Message)

                Finally
                    conn.Close()

                End Try

            End If

            'transactionData.Rows.Clear()
            'getImportedAssets()


            'Delete barcodes

            Dim rows1 As Integer
            Dim myCommand1 As SqlCommand = conn2.CreateCommand()


            Try

                conn2.Open()

                myCommand1.CommandText = "Delete  From db_owner.tbl_asset_barcodes where (itemID = '" & selectedItemId & "' 
                and transID = '" & selectedTransId & "')"

                rows1 = myCommand1.ExecuteNonQuery()



            Catch ex As SqlException

                ' handle error
                Console.Write("Unable to Delete")


            Finally
                conn2.Close()
            End Try

            '*******************************************

            'DELETE from Imported
            Dim rows2 As Integer
            Dim myCommand2 As SqlCommand = conn2.CreateCommand()


            Try

                conn2.Open()

                myCommand2.CommandText = "Delete  From db_owner.tbl_imported_assets where (mainAssetID = '" & selectedItemId & "' 
                and transactionID = '" & selectedTransId & "')"

                rows2 = myCommand2.ExecuteNonQuery()



            Catch ex As SqlException

                ' handle error
                Console.Write("Unable to Delete")


            Finally
                conn2.Close()
            End Try

            '********************************************

            'DELETE from transactioned

            Dim rows3 As Integer
            Dim myCommand3 As SqlCommand = conn.CreateCommand()


            Try

                conn.Open()

                myCommand3.CommandText = "Delete  From db_owner.tbl_asset_transactioned where (assetID = '" & theRealAssetID & "' 
                and TransactionID = '" & selectedTransId & "')"

                rows3 = myCommand3.ExecuteNonQuery()



            Catch ex As SqlException

                ' handle error
                Console.Write("Unable to Delete")


            Finally
                conn.Close()
            End Try

            '**************************************************

            'Change row Background if Asset is already added
            Dim importedDt As New DataTable
            importedDt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_imported_assets")

            For i As Integer = 0 To transactionData.Rows.Count - 1
                For j As Integer = 0 To importedDt.Rows.Count - 1

                    If transactionData.Rows(i).Cells(11).Value = importedDt.Rows(j)("mainAssetID") AndAlso transactionData.Rows(i).Cells(12).Value = importedDt.Rows(j)("transactionID") Then

                        transactionData.Rows(i).DefaultCellStyle.BackColor = Color.LightGray

                    Else
                        transactionData.Rows(i).DefaultCellStyle.BackColor = Color.White
                    End If

                Next


            Next
            '****************************************************

        End If




    End Sub

    Private Sub locationNameField_SelectionChangeCommitted(ByVal sender2 As System.Object, ByVal e As System.EventArgs)

        If transactionData.CurrentCell.ColumnIndex = 8 Then

            Dim combo2 As ComboBox = CType(sender2, ComboBox)
            transactionData.CurrentRow.Cells(8).Value = combo2.SelectedValue

            retrievedLocID = -1

            For Each pair0 As KeyValuePair(Of String, Integer) In locationList

                Dim key0 As String = pair0.Key
                If key0 = transactionData.CurrentRow.Cells(8).Value.ToString Then
                    retrievedLocID = pair0.Value
                End If

            Next


            transactionData.CurrentRow.Cells(14).Value = retrievedLocID
        End If

    End Sub


    Private Sub classNameField_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs)


        If transactionData.CurrentCell.ColumnIndex = 2 Then


            Dim combo As ComboBox = CType(sender, ComboBox)
            transactionData.CurrentRow.Cells(2).Value = combo.SelectedValue

            retrievedClassID = 0

            For Each pair As KeyValuePair(Of String, Integer) In classList

                Dim key As String = pair.Key
                If key = transactionData.CurrentRow.Cells(2).Value.ToString Then
                    retrievedClassID = pair.Value
                End If

            Next

            transactionData.CurrentRow.Cells(13).Value = retrievedClassID


            '    Check if Item already added
            theItemName = transactionData.CurrentRow.Cells(1).Value
            theItemID = transactionData.CurrentRow.Cells(11).Value

            Dim checkNameDt As New DataTable
            checkNameDt = dataBaseobj.SelectMethode("Select assetName from db_owner.tbl_asset where (assetName = '" & theItemName & "')")


            '    ******************************

            '    Adding the Item to Asset

            If checkNameDt.Rows.Count < 1 Then


                theAssetNamePrefix = (theItemName).Substring(0, 2)

                Dim checkDt As New DataTable
                checkDt = dataBaseobj.SelectMethode("Select prefix from db_owner.tbl_asset where prefix LIKE '" & theAssetNamePrefix & "%'")

                If checkDt.Rows.Count > 0 Then

                    theAssetNamePrefix = theAssetNamePrefix + (checkDt.Rows.Count).ToString

                End If

                theAssetNamePrefix = theAssetNamePrefix.ToUpper



                Dim query As String = String.Empty
                query = "INSERT INTO db_owner.tbl_asset (assetID, assetName, AssetClass, prefix, classID, Status, CreateUserID, CreateDate,
                     RevisionUserID, RevisionDate) VALUES(@assetID, @assetName, @AssetClass, @prefix, @classID, @Status, @CreateUserID,
                     @CreateDate,@RevisionUserID, @RevisionDate)"

                Using comm As New SqlCommand()
                    With comm
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = query
                        .Parameters.AddWithValue("@assetID", theItemID)
                        .Parameters.AddWithValue("@assetName", transactionData.CurrentRow.Cells(1).Value)
                        .Parameters.AddWithValue("@AssetClass", transactionData.CurrentRow.Cells(2).Value)
                        .Parameters.AddWithValue("@classID", transactionData.CurrentRow.Cells(13).Value)
                        .Parameters.AddWithValue("@prefix", theAssetNamePrefix)
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


            End If
        End If
        '******************************************
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


        Dim getAssetIDDt As New DataTable
        Dim theImportedTransID As Integer = -1
        Dim importedTransIDDt As New DataTable
        Dim transDT2 As New DataTable
        Dim theRealAssetID As Integer = -1
        Dim alreadyAddedAssetInImportedDt As New DataTable
        Dim alreadyAddedAssetInTransactionedDt As New DataTable
        Dim locInvOfTheNewAssetDt As New DataTable


        Dim existingLocInvAssetID As Integer = -1
        Dim locInvLocationID As Integer = -1
        Dim existingLocInvAssetQty As Integer = -1
        Dim existingLocInvAssetUPrice As Double = 0
        Dim existingLocInvAssetTotalPrice As Double = 0

        Dim theOldLocInvAssetID As Integer = -1
        Dim theLocationInIported As Integer = -1
        Dim theOldLocInvQty As Integer = -1
        Dim theOldLocInvUPrice As Double = 0
        Dim theOldLocInvTotalPrice As Double = 0

        Dim theNewLocInvAssetID As Integer = -1
        Dim theNewLocInvLocationID As Integer = -1
        Dim theNewLocInvQty As Integer = -1
        Dim theNewLocInvUPrice As Double = 0
        Dim theNewLocInvTotalPrice As Double = 0
        Dim theAssetQty As Integer


        'Checks if the Transaction for theImported is found and gets its ID

        importedTransIDDt = dataBaseobj.SelectMethode("Select ID from db_owner.tbl_asset_transactions where (isForImported = 1)")
        theImportedTransID = importedTransIDDt.Rows(0)("ID")

        '******************************************************************


        'Add the New Transaction for imported Asset and gets its ID if it doesn't exist

        If importedTransIDDt.Rows.Count = 0 Then

            Dim importedTransIDQuery As String = String.Empty
            importedTransIDQuery = "INSERT INTO db_owner.tbl_asset_transactions (isForImported)
                      VALUES(@isForImported)"

            Using importedTransIDComm As New SqlCommand()
                With importedTransIDComm
                    .Connection = conn2
                    .CommandType = CommandType.Text
                    .CommandText = importedTransIDQuery
                    .Parameters.AddWithValue("@isForImported", 1)
                End With
                conn.Open()
                importedTransIDComm.ExecuteNonQuery()
                conn.Close()

            End Using

        End If


        importedTransIDDt = dataBaseobj.SelectMethode("Select ID from db_owner.tbl_asset_transactions where (isForImported = 1)")
        theImportedTransID = importedTransIDDt.Rows(0)("ID")

        '*****************************************************************

        For i As Integer = 0 To transactionData.Rows.Count - 2

            'Get the Real Item ID from tbl_asset 
            getAssetIDDt = dataBaseobj.SelectMethode("Select ID from db_owner.tbl_asset 
            where (assetName = '" & transactionData.Rows(i).Cells(1).Value & "')")
            theRealAssetID = getAssetIDDt.Rows(0)("ID")
            '****************************

            'Enter Only if theres a class and location ID
            If transactionData.Rows(i).Cells(13).Value IsNot Nothing _
                And transactionData.Rows(i).Cells(14).Value IsNot Nothing Then

                'Check if Item are already added in imported and the transactioned Items
                alreadyAddedAssetInImportedDt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_imported_assets 
                where ( transactionID = '" & transactionData.Rows(i).Cells(12).Value & "' 
                and mainAssetID = '" & transactionData.Rows(i).Cells(11).Value & "')")

                alreadyAddedAssetInTransactionedDt = dataBaseobj.SelectMethode("Select ID from db_owner.tbl_asset_transactioned
                where ( TransactionID = '" & theImportedTransID & "' and assetID = '" & theRealAssetID & "')")
                '******************************************************************

                'Get Old Asset's Props from imported tbl
                'Dim assetPropsFromImportedDt As New DataTable

                'assetPropsFromImportedDt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_imported_assets where 
                '(mainAssetID = '" & transactionData.Rows(i).Cells(11).Value & "' 
                'and transactionID = '" & theImportedTransID & "')")

                If alreadyAddedAssetInImportedDt.Rows.Count > 0 Then

                    theLocationInIported = alreadyAddedAssetInImportedDt.Rows(0)("locationID")

                End If

                '***********************************************


                'Check if the asset is already added in tbl_location_asset_inventory


                locInvOfImportedAssetDt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_location_asset_inventory 
                where (assetID = '" & theRealAssetID & "' 
                and assetLocationID = '" & theLocationInIported & "' and isDeleted <> 1)")

                MessageBox.Show(locInvOfImportedAssetDt.Rows.Count)
                locInvOfTheNewAssetDt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_location_asset_inventory 
                where (assetID = '" & theRealAssetID & "' 
                and assetLocationID = '" & transactionData.Rows(i).Cells(14).Value & "')")

                '****************************************

                'INSERTING NEW OR UPDATING IN ASSET_TRANSACTIONED AND IMPORTED_ASSETS TBLs
                If alreadyAddedAssetInImportedDt.Rows.Count = 0 And alreadyAddedAssetInTransactionedDt.Rows.Count = 0 Then

                    'Inserting NEW Asset in IMPORTED

                    Dim insertImpotertedQuery As String = String.Empty
                    insertImpotertedQuery = "INSERT INTO db_owner.tbl_imported_assets (assetID, assetName, classID, className, quantity,
                              uintAvgPrice, totalPrice, acquisationDate,locationName, vendorName, transactionID, mainAssetID,
                              locationID, Status, CreateUserID, CreateDate, RevisionUserID, RevisionDate)
                              VALUES(@assetID, @assetName, @classID, @className, @quantity, @uintAvgPrice, @totalPrice,
                              @acquisationDate,@locationName, @vendorName, @transactionID, @mainAssetID, @locationID, @Status,
                              @CreateUserID, @CreateDate,@RevisionUserID, @RevisionDate)"

                    Using insertImpotertedComm As New SqlCommand()
                        With insertImpotertedComm
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = insertImpotertedQuery
                            .Parameters.AddWithValue("@assetID", transactionData.Rows(i).Cells(0).Value)
                            .Parameters.AddWithValue("@assetName", transactionData.Rows(i).Cells(1).Value)
                            .Parameters.AddWithValue("@className", transactionData.Rows(i).Cells(2).Value)
                            .Parameters.AddWithValue("@classID", transactionData.Rows(i).Cells(13).Value)
                            .Parameters.AddWithValue("@quantity", transactionData.Rows(i).Cells(3).Value)
                            .Parameters.AddWithValue("@uintAvgPrice", transactionData.Rows(i).Cells(4).Value)
                            .Parameters.AddWithValue("@totalPrice", transactionData.Rows(i).Cells(5).Value)
                            .Parameters.AddWithValue("@acquisationDate", transactionData.Rows(i).Cells(7).Value)
                            .Parameters.AddWithValue("@locationName", transactionData.Rows(i).Cells(8).Value)
                            .Parameters.AddWithValue("@vendorName", transactionData.Rows(i).Cells(9).Value)
                            .Parameters.AddWithValue("@transactionID", transactionData.Rows(i).Cells(12).Value)
                            .Parameters.AddWithValue("@mainAssetID", transactionData.Rows(i).Cells(11).Value)
                            .Parameters.AddWithValue("@locationID", transactionData.Rows(i).Cells(14).Value)
                            .Parameters.AddWithValue("@Status", 1)
                            .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                            .Parameters.AddWithValue("@CreateDate", Today)
                            .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                            .Parameters.AddWithValue("@RevisionDate", Today)


                        End With
                        conn.Open()
                        insertImpotertedComm.ExecuteNonQuery()

                        conn.Close()

                    End Using

                    '******************************************
                    'INSERTING NEW IN ASSET_TRANSACTIONED

                    Dim insertTrasactionedQuery As String = String.Empty
                    insertTrasactionedQuery = "INSERT INTO db_owner.tbl_asset_transactioned (TransactionID, assetID, assetName,
                    assetQty, assetUnitCost, assetTotalCost, acquisationDate,assetBarcode,assetImported, Status, CreateUserID,
                    CreateDate,RevisionUserID, RevisionDate)
                    VALUES(@TransactionID, @assetID, @assetName, @assetQty, @assetUnitCost, @assetTotalCost,@acquisationDate,
                    @assetBarcode,@assetImported, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

                    Using insertTransactionedComm As New SqlCommand()
                        With insertTransactionedComm
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = insertTrasactionedQuery
                            .Parameters.AddWithValue("@TransactionID", theImportedTransID)
                            .Parameters.AddWithValue("@assetID", theRealAssetID)
                            .Parameters.AddWithValue("@assetName", transactionData.Rows(i).Cells(1).Value)
                            .Parameters.AddWithValue("@assetQty", transactionData.Rows(i).Cells(3).Value)
                            .Parameters.AddWithValue("@assetUnitCost", transactionData.Rows(i).Cells(4).Value)
                            .Parameters.AddWithValue("@assetTotalCost", transactionData.Rows(i).Cells(5).Value)
                            .Parameters.AddWithValue("@acquisationDate", transactionData.Rows(i).Cells(7).Value)
                            .Parameters.AddWithValue("@assetBarcode", transactionData.Rows(i).Cells(6).Value)
                            .Parameters.AddWithValue("@assetImported", True)
                            .Parameters.AddWithValue("@Status", 1)
                            .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                            .Parameters.AddWithValue("@CreateDate", Today)
                            .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                            .Parameters.AddWithValue("@RevisionDate", Today)


                        End With
                        conn.Open()
                        insertTransactionedComm.ExecuteNonQuery()

                        conn.Close()

                    End Using


                    'IF Asset NOT found in imported and transactioned

                ElseIf alreadyAddedAssetInImportedDt.Rows.Count > 0 And alreadyAddedAssetInTransactionedDt.Rows.Count > 0 Then

                    'UPDATING EXISTING ASSET IN IMPORTED IF ASSET ALREADY ADDED

                    Dim updateImportedQuery As Integer
                    Dim updateImporetedComm As SqlCommand = conn.CreateCommand()

                    Try
                        conn.Open()

                        updateImporetedComm.CommandText = "Update db_owner.tbl_imported_assets 
                        Set assetID = '" & transactionData.Rows(i).Cells(0).Value & "',
                        assetName = '" & transactionData.Rows(i).Cells(1).Value & "',
                        classID = '" & transactionData.Rows(i).Cells(13).Value & "',
                        className = '" & transactionData.Rows(i).Cells(2).Value & "',
                        quantity = '" & transactionData.Rows(i).Cells(3).Value & "' ,
                        uintAvgPrice = '" & transactionData.Rows(i).Cells(4).Value & "',
                        totalPrice = '" & transactionData.Rows(i).Cells(5).Value & "',
                        acquisationDate = '" & transactionData.Rows(i).Cells(7).Value & "',                        
                        vendorName = '" & transactionData.Rows(i).Cells(9).Value & "',
                        transactionID = '" & transactionData.Rows(i).Cells(12).Value & "',
                        mainAssetID = '" & transactionData.Rows(i).Cells(11).Value & "',
                        locationName = '" & transactionData.Rows(i).Cells(8).Value & "',
                        locationID = '" & transactionData.Rows(i).Cells(14).Value & "',
                        Status = 1,
                        CreateUserID = '" & logedInUserID & "',
                        CreateDate = '" & Today & "',
                        RevisionUserID = '" & logedInUserID & "',
                        RevisionDate = '" & Today & "'
                        where ( transactionID = '" & transactionData.Rows(i).Cells(12).Value & "' 
                        and mainAssetID = '" & transactionData.Rows(i).Cells(11).Value & "' ) "

                        updateImportedQuery = updateImporetedComm.ExecuteNonQuery()

                    Catch ex As SqlException
                        ' handle error
                        MessageBox.Show(ex.Message)

                    Finally
                        conn.Close()

                    End Try


                    '*********************************************


                    'UPDATE EXISTING ASSET IN asset_transactioned

                    Dim updateTransactionedQuery As Integer
                    Dim updateTransactionedComm As SqlCommand = conn.CreateCommand()

                    Try
                        conn.Open()

                        updateTransactionedComm.CommandText = "Update db_owner.tbl_asset_transactioned
                        Set TransactionID = '" & theImportedTransID & "',
                        assetID = '" & theRealAssetID & "',
                        assetName = '" & transactionData.Rows(i).Cells(1).Value & "',
                        assetQty = '" & transactionData.Rows(i).Cells(3).Value & "',
                        assetUnitCost = '" & transactionData.Rows(i).Cells(4).Value & "' ,
                        assetTotalCost = '" & transactionData.Rows(i).Cells(5).Value & "',
                        assetBarcode = '" & transactionData.Rows(i).Cells(6).Value & "',
                        assetImported = 1 ,
                        acquisationDate = '" & transactionData.Rows(i).Cells(7).Value & "',      
                        Status = 1,
                        CreateUserID = '" & logedInUserID & "',
                        CreateDate = '" & Today & "',
                        RevisionUserID = '" & logedInUserID & "',
                        RevisionDate = '" & Today & "'
                        where ( TransactionID = '" & theImportedTransID & "' 
                        and assetID = '" & theRealAssetID & "' ) "

                        updateTransactionedQuery = updateTransactionedComm.ExecuteNonQuery()

                    Catch ex As SqlException
                        ' handle error
                        MessageBox.Show(ex.Message)

                    Finally
                        conn.Close()

                    End Try




                End If
                '*************************************************


                'Update or insert NEW asset to loc_inv tbl if location is changed

                'And theLocationInIported <> -1 
                If theLocationInIported <> transactionData.Rows(i).Cells(14).Value Then

                    'INSERT NEW ASSET TO LOC_INV_TBL

                    If locInvOfTheNewAssetDt.Rows.Count = 0 Then

                        'Add assets to tbl_location_asset_inventory if itsnot found in Location_inventory tbl

                        Dim insertNewAssetToLocInvQuery As String = String.Empty
                        insertNewAssetToLocInvQuery = "INSERT INTO db_owner.tbl_location_asset_Inventory (assetID, assetName, assetQty, assetUnitPrice, assetTotalPrice,
                        assetLocationID, assetLocationName)
                        VALUES(@assetID, @assetName, @assetQty, @assetUnitPrice, @assetTotalPrice,
                        @assetLocationID, @assetLocationName)"

                        Using insertNewAssetToLocInvComm As New SqlCommand()
                            With insertNewAssetToLocInvComm
                                .Connection = conn
                                .CommandType = CommandType.Text
                                .CommandText = insertNewAssetToLocInvQuery
                                .Parameters.AddWithValue("@assetID", theRealAssetID)
                                .Parameters.AddWithValue("@assetName", transactionData.Rows(i).Cells(1).Value)
                                .Parameters.AddWithValue("@assetQty", transactionData.Rows(i).Cells(3).Value)
                                .Parameters.AddWithValue("@assetUnitPrice", transactionData.Rows(i).Cells(4).Value)
                                .Parameters.AddWithValue("@assetTotalPrice", transactionData.Rows(i).Cells(5).Value)
                                .Parameters.AddWithValue("@assetLocationID", transactionData.Rows(i).Cells(14).Value)
                                .Parameters.AddWithValue("@assetLocationName", transactionData.Rows(i).Cells(8).Value)



                            End With
                            conn.Open()
                            insertNewAssetToLocInvComm.ExecuteNonQuery()

                            conn.Close()

                        End Using

                    End If

                    '********************************************



                    If locInvOfTheNewAssetDt.Rows.Count > 0 Then

                        'Change Asset Props in New Asset Add
                        theNewLocInvAssetID = theRealAssetID
                        theNewLocInvLocationID = transactionData.Rows(i).Cells(14).Value
                        theNewLocInvQty = (locInvOfTheNewAssetDt.Rows(0)("assetQty") + transactionData.Rows(i).Cells(3).Value)
                        theNewLocInvUPrice = transactionData.Rows(i).Cells(4).Value
                        theNewLocInvTotalPrice = (theNewLocInvUPrice * theNewLocInvQty)

                        '****************************************


                        'Update The tbl_location_asset-inventory

                        Dim updateNewAssetInLocInvQuery As Integer
                        Dim updateNewAssetInLocInvComm As SqlCommand = conn.CreateCommand()

                        Try
                            conn.Open()

                            updateNewAssetInLocInvComm.CommandText = "Update db_owner.tbl_location_asset_inventory 
                            Set assetQty = '" & theNewLocInvQty & "' ,
                            assetUnitPrice = '" & theNewLocInvUPrice & "',
                            assetTotalPrice = '" & theNewLocInvTotalPrice & "',
                            Status = 1
                            where ( assetID = '" & theRealAssetID & "'
                            and assetLocationID = '" & transactionData.Rows(i).Cells(14).Value & "') "

                            updateNewAssetInLocInvQuery = updateNewAssetInLocInvComm.ExecuteNonQuery()

                        Catch ex As SqlException
                            ' handle error
                            MessageBox.Show(ex.Message)

                        Finally
                            conn.Close()

                        End Try
                    End If
                    '***************************************


                    'Update the existing Asset of imported in LOC_INV tbl
                    If locInvOfImportedAssetDt.Rows.Count > 0 Then

                        existingLocInvAssetID = locInvOfImportedAssetDt.Rows(0)("assetID")
                        existingLocInvAssetQty = (locInvOfImportedAssetDt.Rows(0)("assetQty") - transactionData.Rows(i).Cells(3).Value)
                        existingLocInvAssetUPrice = locInvOfImportedAssetDt.Rows(0)("assetUnitPrice")
                        existingLocInvAssetTotalPrice = existingLocInvAssetQty * existingLocInvAssetUPrice

                        Dim existingLocInvAssetQuery As Integer
                        Dim myCommandInLocInv As SqlCommand = conn.CreateCommand()

                        Try
                            conn.Open()

                            myCommandInLocInv.CommandText = "Update db_owner.tbl_location_asset_inventory 
                            Set assetQty = '" & existingLocInvAssetQty & "' ,
                            assetUnitPrice = '" & existingLocInvAssetUPrice & "',
                            assetTotalPrice = '" & existingLocInvAssetTotalPrice & "',                          
                            Status = 1
                            where ( assetID = '" & theRealAssetID & "'
                            and assetLocationID = '" & theLocationInIported & "') "

                            existingLocInvAssetQuery = myCommandInLocInv.ExecuteNonQuery()

                        Catch ex As SqlException
                            ' handle error
                            MessageBox.Show(ex.Message)

                        Finally
                            conn.Close()

                        End Try
                    End If
                    '*****************************************************

                    'Dim updateInventoryQuery As Integer
                    'Dim myCommandupdateInventory As SqlCommand = conn.CreateCommand()

                    'Try
                    '    conn.Open()

                    '    myCommandupdateInventory.CommandText = "Update db_owner.tbl_location_asset_inventory 
                    '        Set isDeleted = 0
                    '        where ( assetID = '" & theRealAssetID & "'
                    '        and assetLocationID = '" & theLocationInIported & "') "

                    '    updateInventoryQuery = myCommandupdateInventory.ExecuteNonQuery()

                    'Catch ex As SqlException
                    '    ' handle error
                    '    MessageBox.Show(ex.Message)

                    'Finally
                    '    conn.Close()

                    'End Try

                End If

                '*****************************************************


            Else
                'MessageBox.Show("Make sure you filled all required information at ROW " & i + 1)
            End If
            '*********************************************
        Next


        'Change row Background if Asset is already added
        Dim dt As New DataTable
        dt = dataBaseobj.SelectMethode("Select * from db_owner.tbl_imported_assets")

        For i As Integer = 0 To transactionData.Rows.Count - 1
            For j As Integer = 0 To dt.Rows.Count - 1

                If transactionData.Rows(i).Cells(11).Value = dt.Rows(j)("mainAssetID") AndAlso transactionData.Rows(i).Cells(12).Value = dt.Rows(j)("transactionID") Then

                    transactionData.Rows(i).DefaultCellStyle.BackColor = Color.LightGray
                    transactionData.Rows(i).Cells(2).Value = dt.Rows(j)("className")
                    transactionData.Rows(i).Cells(13).Value = dt.Rows(j)("classID")

                End If

            Next


        Next
        '****************************************************

    End Sub

    Private Sub transactionData_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles transactionData.DataError
        'MessageBox.Show("An error has occured. Please restart the application")
    End Sub
End Class