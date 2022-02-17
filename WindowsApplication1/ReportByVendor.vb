Public Class ReportByVendor

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

    Private Sub ByVendorReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Gets available Items
        getItems()
        '******************

        'Displays the gridView
        vendorGrid.DataSource = getAllItems()
        vendorGrid.Columns(1).Width = 150
        vendorGrid.Columns(2).Width = 150
        vendorGrid.Columns(4).Width = 150
        vendorGrid.Columns(0).Visible = False
        vendorGrid.Columns(9).Visible = False

        For i As Integer = 0 To vendorGrid.Rows.Count - 2
            vendorGrid.Rows(i).Cells(6).Value = Math.Round(vendorGrid.Rows(i).Cells(6).Value, 2)
            vendorGrid.Rows(i).Cells(7).Value = Math.Round(vendorGrid.Rows(i).Cells(7).Value, 2)

        Next

        Dim btn As New DataGridViewButtonColumn
        btn.HeaderText = ""
        btn.Text = ""
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True

        vendorGrid.Columns.Insert(0, btn)
        vendorGrid.Columns(0).Width = 20

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

        dt = dataBaseObject.SelectMethode("Select ItemName from db_owner.tbl_Item where Status = 1")

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

        dt = dataBaseObject.SelectMethode("Select db_owner.tbl_transaction.ID,db_owner.tbl_transaction.ReferanceNumber as [Transaction ID],
                                           db_owner.tbl_transaction.VendorName as [Vendor],db_owner.tbl_Item.ItemID as [Inventory ID],
                                           db_owner.tbl_transactioned_items.ItemName as [Item Name], db_owner.tbl_transactioned_items.Quantity,
                                           db_owner.tbl_transactioned_items.UnitAvgCost as [Unit Cost],db_owner.tbl_transactioned_items.TotalCost as [Total],
                                           db_owner.tbl_transaction.DateCreated as [Date],db_owner.tbl_transactioned_items.ItemID
                                           from db_owner.tbl_transaction,db_owner.tbl_transactioned_Items,db_owner.tbl_Item
                                           where ( db_owner.tbl_transactioned_items.TransactionName = 'Purchase' and db_owner.tbl_transaction.ID = db_owner.tbl_transactioned_Items.TransactionID 
                                           and db_owner.tbl_transactioned_items.ItemName LIKE '%" & selectedItemBox.Text & "%' and db_owner.tbl_Item.ID = db_owner.tbl_transactioned_items.ItemID
                                           and db_owner.tbl_transactioned_items.Status = 1)")


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

    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        theTotalQty = 0
        theTotalPrice = 0

        vendorGrid.DataSource = getAllItems()
        vendorGrid.Columns(1).Width = 150
        vendorGrid.Columns(2).Width = 150
        vendorGrid.Columns(4).Width = 150
        vendorGrid.Columns(10).Visible = False

        For i As Integer = 0 To vendorGrid.Rows.Count - 2
            vendorGrid.Rows(i).Cells(6).Value = Math.Round(vendorGrid.Rows(i).Cells(6).Value, 2)
            vendorGrid.Rows(i).Cells(7).Value = Math.Round(vendorGrid.Rows(i).Cells(7).Value, 2)

        Next




    End Sub

    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click
        dt.Rows.Add(Nothing, "TOTAL", "", Nothing, "", theTotalQty, Nothing, theTotalPrice)
        vendorGrid.Columns.RemoveAt(1)
        vendorGrid.Columns.RemoveAt(9)

        'Displays the gridView
        vendorGrid.DataSource = dt
        '************************

        loadingPanel.Visible = True
        extractToExcell.DATAGRIDVIEW_TO_EXCEL(vendorGrid)
        loadingPanel.Visible = False

        vendorGrid.DataSource = False
        vendorGrid.DataSource = getAllItems()
        vendorGrid.Columns(1).Width = 150
        vendorGrid.Columns(2).Width = 150
        vendorGrid.Columns(4).Width = 150
        vendorGrid.Columns(10).Visible = False

        For i As Integer = 0 To vendorGrid.Rows.Count - 2
            vendorGrid.Rows(i).Cells(6).Value = Math.Round(vendorGrid.Rows(i).Cells(6).Value, 2)
            vendorGrid.Rows(i).Cells(7).Value = Math.Round(vendorGrid.Rows(i).Cells(7).Value, 2)

        Next
        vendorGrid.Columns(1).Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        theTotalQty = 0
        theTotalPrice = 0
        selectedItemBox.Text = String.Empty
        itemIDLabel.Text = "-"

        vendorGrid.DataSource = getAllItems()
        vendorGrid.Columns(1).Width = 150
        vendorGrid.Columns(2).Width = 150
        vendorGrid.Columns(4).Width = 150
        vendorGrid.Columns(10).Visible = False
        'vendorGrid.Columns(0).Visible = False

        For i As Integer = 0 To vendorGrid.Rows.Count - 2
            vendorGrid.Rows(i).Cells(6).Value = Math.Round(vendorGrid.Rows(i).Cells(6).Value, 2)
            vendorGrid.Rows(i).Cells(7).Value = Math.Round(vendorGrid.Rows(i).Cells(7).Value, 2)

        Next


    End Sub

    Private Sub vendorGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles vendorGrid.CellContentClick
        'MessageBox.Show(e.RowIndex & " __ " & vendorGrid.Rows.Count - 2)

        If e.RowIndex = vendorGrid.Rows.Count - 1 Then
            Exit Sub
        End If
        Dim theSelected As Integer = 0
        theSelected = vendorGrid.Rows(e.RowIndex).Cells(1).Value
        My.Settings.fromAllTrans = True
        My.Settings.selectedTransaction = theSelected
        My.Settings.Save()
        Dim refNumber As String = vendorGrid.Rows(e.RowIndex).Cells(2).Value


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

        End If

    End Sub

    Private Sub vendorGrid_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles vendorGrid.CellPainting

        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso e.RowIndex < vendorGrid.Rows.Count - 1 Then
            If TypeOf vendorGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then

                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                Dim bmpFind As Bitmap = My.Resources.view
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 2, e.CellBounds.Top + 3)
                e.Handled = True

            End If
        End If

    End Sub
End Class