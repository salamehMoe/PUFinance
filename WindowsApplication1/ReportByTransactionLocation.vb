Public Class ReportByTransactionLocation

    'Varaibles
    Dim dataBaseObject As New DatabaseAccesClass
    Dim locationList As List(Of KeyValuePair(Of String, Integer)) =
                      New List(Of KeyValuePair(Of String, Integer))
    Dim theTotalQty As Integer = 0
    Dim theTotalPrice As Decimal = 0
    Dim exportToExcell As New exportdatagridviewclass
    Dim dt As New DataTable
    '***********************************
    Private Sub reportByLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AutoScroll = True
        'Get All Available Locatons
        getLocations()
        'Display the datagridview
        byLocationGrid.DataSource = getByLocationData()
        byLocationGrid.Columns(0).Width = 120
        byLocationGrid.Columns(1).Width = 120
        byLocationGrid.Columns(2).Width = 200
        byLocationGrid.Columns(3).Width = 120
        byLocationGrid.Columns(4).Width = 120
        byLocationGrid.Columns(8).Visible = False
        byLocationGrid.Columns(10).Visible = False
        '***************************

        theTotalQty = 0
        theTotalPrice = 0

        'Change Location to Stock if type is Stock_IN


        For i As Integer = 0 To byLocationGrid.Rows.Count - 2
            byLocationGrid.Rows(i).Cells(6).Value = Math.Round(byLocationGrid.Rows(i).Cells(6).Value, 2)
            byLocationGrid.Rows(i).Cells(5).Value = Math.Round(byLocationGrid.Rows(i).Cells(5).Value, 2)

            Next

        'Dim btn As New DataGridViewButtonColumn()
        'byLocationGrid.Columns.Add(btn)
        'btn.HeaderText = ""
        'btn.Text = ""
        'btn.Name = "btn"
        'btn.UseColumnTextForButtonValue = True

        Dim btn As New DataGridViewButtonColumn
        btn.HeaderText = ""
        btn.Text = ""
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
        byLocationGrid.Columns.Insert(0, btn)

        byLocationGrid.Columns(0).Width = 20


        '*************************************


    End Sub

    'Get All Available Locatons
    Sub getLocations()

        locationDropBox.Items.Clear()
        locationList.Clear()

        Dim dt As DataTable = New DataTable

        dt = dataBaseObject.SelectMethode("Select * from db_owner.tbl_location where Status = 1")
        For i = 0 To dt.Rows.Count - 1
            locationList.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("Name").ToString(), dt.Rows(i)("ID").ToString()))
        Next

        autoCompleteLocations()
    End Sub

    Sub autoCompleteLocations()

        Dim dt As DataTable = New DataTable()

        dt = dataBaseObject.SelectMethode("Select Name from db_owner.tbl_location where Status = 1")
        Dim row As DataRow = dt.NewRow()

        dt.Rows.InsertAt(row, 0)


        locationDropBox.DataSource = dt
        locationDropBox.DisplayMember = "Name"
        locationDropBox.ValueMember = "Name"


        locationDropBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        locationDropBox.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub
    '*****************************

    'Get all Items Sorted by Location
    Function getByLocationData()

        theTotalQty = 0
        theTotalPrice = 0

        dt = dataBaseObject.SelectMethode(" Select db_owner.tbl_transaction.ReferanceNumber [Status], db_owner.tbl_Item.ItemID as [Inventory ID],
                                            db_owner.tbl_transactioned_items.ItemName [Inventory Name], db_owner.tbl_transaction.CreateDate [Date],
                                            db_owner.tbl_transactioned_Items.Quantity, db_owner.tbl_transactioned_items.UnitAvgCost [Avg Unit Cost],
                                            db_owner.tbl_transactioned_items.TotalCost [Total],db_owner.tbl_transaction.LocationName [Destination],
                                            db_owner.tbl_transaction.ID,db_owner.tbl_transactioned_items.TransactionName [Type],db_owner.tbl_transactioned_items.ItemID [Inventory ID]
                                            from db_owner.tbl_transaction,db_owner.tbl_transactioned_items,db_owner.tbl_Item
                                            where ( db_owner.tbl_transaction.ID = db_owner.tbl_transactioned_items.TransactionID
                                            and (db_owner.tbl_transaction.LocationName LIKE '%" & locationDropBox.Text & "%' or
                                            db_owner.tbl_transaction.TransferInLocation Like '%" & locationDropBox.Text & "%' or
                                            db_owner.tbl_transaction.TransferOutLocation Like '%" & locationDropBox.Text & "%') 
                                            and db_owner.tbl_Item.ID = db_owner.tbl_transactioned_items.ItemID and db_owner.tbl_transactioned_items.Status = 1)")


        'Calculate the Totals of Items
        For i As Integer = 0 To dt.Rows.Count - 1

            theTotalQty = theTotalQty + dt.Rows(i)("Quantity").ToString()
            theTotalPrice = theTotalPrice + dt.Rows(i)("Total").ToString()

            totalQty.Text = theTotalQty.ToString
            totalPrice.Text = "$ " + theTotalPrice.ToString

        Next
        '********************************************

        Return dt
    End Function


    'Initialize the form after Cancel Clicked
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        locationDropBox.Text = String.Empty

        byLocationGrid.DataSource = False
        byLocationGrid.DataSource = getByLocationData()
        byLocationGrid.Columns(1).Width = 120
        byLocationGrid.Columns(2).Width = 120
        byLocationGrid.Columns(3).Width = 200
        byLocationGrid.Columns(4).Width = 120
        byLocationGrid.Columns(5).Width = 120
        byLocationGrid.Columns(9).Visible = False
        byLocationGrid.Columns(11).Visible = False



        For i As Integer = 0 To byLocationGrid.Rows.Count - 2
            byLocationGrid.Rows(i).Cells(7).Value = Math.Round(byLocationGrid.Rows(i).Cells(7).Value, 2)
            byLocationGrid.Rows(i).Cells(6).Value = Math.Round(byLocationGrid.Rows(i).Cells(6).Value, 2)

        Next




    End Sub
    '*****************************************

    'Display DatagridView after createReport btn clicked
    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click



        byLocationGrid.DataSource = False
        byLocationGrid.DataSource = getByLocationData()
        byLocationGrid.Columns(1).Width = 120
        byLocationGrid.Columns(2).Width = 120
        byLocationGrid.Columns(3).Width = 200
        byLocationGrid.Columns(4).Width = 120
        byLocationGrid.Columns(5).Width = 120
        byLocationGrid.Columns(9).Visible = False
        byLocationGrid.Columns(11).Visible = False

        For i As Integer = 0 To byLocationGrid.Rows.Count - 2
            byLocationGrid.Rows(i).Cells(6).Value = Math.Round(byLocationGrid.Rows(i).Cells(6).Value, 2)
            byLocationGrid.Rows(i).Cells(7).Value = Math.Round(byLocationGrid.Rows(i).Cells(7).Value, 2)

        Next

    End Sub



    'Export grid view to Excel
    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click

        theTotalQty = 0
        theTotalPrice = 0

        For i As Integer = 0 To dt.Rows.Count - 1

            theTotalQty = theTotalQty + dt.Rows(i)("Quantity").ToString()
            theTotalPrice = theTotalPrice + dt.Rows(i)("Total").ToString()

            totalQty.Text = theTotalQty.ToString
            totalPrice.Text = "$ " + theTotalPrice.ToString

        Next
        dt.Rows.Add("TOTAL", Nothing, "", Nothing, theTotalQty, Nothing, theTotalPrice, "", False)
        byLocationGrid.Columns.RemoveAt(9)
        byLocationGrid.Columns.RemoveAt(10)

        'Displays the gridView
        byLocationGrid.DataSource = dt
        '************************
        loadingPanel.Visible = True
        exportToExcell.DATAGRIDVIEW_TO_EXCEL(byLocationGrid)
        loadingPanel.Visible = False
        byLocationGrid.Rows(byLocationGrid.Rows.Count - 2).Visible = False



        'MessageBox.Show(byLocationGrid.Rows(byLocationGrid.Rows.Count - 2).Cells(1).Value)

        'dt = New DataTable
        byLocationGrid.DataSource = False
        byLocationGrid.DataSource = getByLocationData()
        byLocationGrid.Columns(1).Width = 120
        byLocationGrid.Columns(2).Width = 120
        byLocationGrid.Columns(3).Width = 200
        byLocationGrid.Columns(4).Width = 120
        byLocationGrid.Columns(5).Width = 120
        byLocationGrid.Columns(9).Visible = False
        byLocationGrid.Columns(11).Visible = False

        For i As Integer = 0 To byLocationGrid.Rows.Count - 2
            byLocationGrid.Rows(i).Cells(6).Value = Math.Round(byLocationGrid.Rows(i).Cells(6).Value, 2)
            byLocationGrid.Rows(i).Cells(7).Value = Math.Round(byLocationGrid.Rows(i).Cells(7).Value, 2)

        Next


    End Sub
    '*********************************

    'set the locationlabel to selectedlocation from the location DropBox
    Private Sub locationDropBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles locationDropBox.SelectedIndexChanged
        selectedLocation.Text = locationDropBox.Text
    End Sub


    Private Sub byLocationGrid_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles byLocationGrid.CellPainting

        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso e.RowIndex < byLocationGrid.Rows.Count - 1 Then
            If TypeOf byLocationGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then

                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                Dim bmpFind As Bitmap = My.Resources.view
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 2, e.CellBounds.Top + 3)
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub byLocationGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles byLocationGrid.CellContentClick

        Dim theSelected As Integer = 0

        theSelected = byLocationGrid.Rows(e.RowIndex).Cells(9).Value
        My.Settings.fromAllTrans = True
        My.Settings.selectedTransaction = theSelected
        My.Settings.Save()
        Dim refNumber As String = byLocationGrid.Rows(e.RowIndex).Cells(1).Value

        If refNumber.Contains("PCH") Then

            If Me.ActiveMdiChild IsNot purchaseTransactions Then
                For Each MdiChild In Me.MdiChildren
                    If MdiChild Is ActiveMdiChild Then
                        MdiChild.Close()
                    End If
                Next

            End If

            purchaseTransactions.MdiParent = MdiParent
            purchaseTransactions.Left = 0
            purchaseTransactions.Top = 0
            purchaseTransactions.Size = Me.Size
            purchaseTransactions.WindowState = FormWindowState.Normal
            purchaseTransactions.Show()
            Me.Close()

        ElseIf refNumber.Contains("TRS") Then

            If Me.ActiveMdiChild IsNot transferTransactions Then
                For Each MdiChild In Me.MdiChildren
                    If MdiChild Is ActiveMdiChild Then
                        MdiChild.Close()
                    End If
                Next

            End If

            transferTransactions.MdiParent = MdiParent
            transferTransactions.Left = 0
            transferTransactions.Top = 0
            transferTransactions.Size = Me.Size
            transferTransactions.WindowState = FormWindowState.Normal
            transferTransactions.Show()
            Me.Close()
        ElseIf refNumber.Contains("STK") Then


            If Me.ActiveMdiChild IsNot stockTransaction Then
                For Each MdiChild In Me.MdiChildren
                    If MdiChild Is ActiveMdiChild Then
                        MdiChild.Close()
                    End If
                Next

            End If

            stockTransaction.MdiParent = MdiParent
            stockTransaction.Left = 0
            stockTransaction.Top = 0
            stockTransaction.Size = Me.Size
            stockTransaction.WindowState = FormWindowState.Normal
            stockTransaction.Show()
            Me.Close()
        End If

    End Sub

End Class