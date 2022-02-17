Public Class ReportAllTransactions

    Dim dataBaseObj As New DatabaseAccesClass
    Dim dt As New DataTable
    Dim extractToExcell As New exportdatagridviewclass
    Dim purTransaction As New purchaseTransactions

    Private Sub ReportAllTransactions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        allTransactionsGrid.DataSource = getAllTransactions()
        Dim theRefNum As String = String.Empty
        Dim theStocktext As String = String.Empty
        For i As Integer = 0 To allTransactionsGrid.Rows.Count - 2
            theRefNum = allTransactionsGrid.Rows(i).Cells(2).Value
            allTransactionsGrid.Rows(i).Cells(8).Value = Math.Round(allTransactionsGrid.Rows(i).Cells(8).Value, 2)
            If theRefNum.Contains("PCH") Then
                allTransactionsGrid.Rows(i).Cells(1).Value = "Purchase"
                'allTransactionsGrid.Rows(i).Cells(6).Value = allTransactionsGrid.Rows(i).Cells(5).Value
            ElseIf theRefNum.Contains("TRS") Then
                allTransactionsGrid.Rows(i).Cells(1).Value = "Transfer"
            ElseIf theRefNum.Contains("STK") Then
                If allTransactionsGrid.Rows(i).Cells(9).Value = "Stock-IN" Then
                    allTransactionsGrid.Rows(i).Cells(1).Value = "Stock-IN"
                Else
                    allTransactionsGrid.Rows(i).Cells(1).Value = "Stock-OUT"
                End If

            End If
        Next

        allTransactionsGrid.Columns(0).Visible = False
        allTransactionsGrid.Columns(2).Width = 130
        allTransactionsGrid.Columns(4).Width = 130
        allTransactionsGrid.Columns(5).Width = 130
        allTransactionsGrid.Columns(6).Width = 130


        allTransactionsGrid.Columns(9).Visible = False

        'Dim btn As New DataGridViewButtonColumn()
        'allTransactionsGrid.Columns.Add(btn)
        'btn.HeaderText = "test"
        'btn.Text = ""
        'btn.Name = "btn"
        'btn.UseColumnTextForButtonValue = True


        Dim btn As New DataGridViewButtonColumn
        btn.HeaderText = ""
        btn.Text = ""
        btn.Name = "btn"
        btn.UseColumnTextForButtonValue = True
        allTransactionsGrid.Columns.Insert(10, btn)

        allTransactionsGrid.Columns(10).Width = 20


    End Sub

    Function getAllTransactions()

        dt = dataBaseObj.SelectMethode("Select ID,InvoiceNumber [Status], ReferanceNumber [Transaction Number], VendorID [Vendor ID],
                                        VendorName [Vendor Name],LocationName [Transfer In Location], TransferOutLocation [Transfer Out Location],
                                        TotalQty [Total Quantity] ,TotalCost [Total Price],StockText from db_owner.tbl_transaction where Status = 1")

        Return dt


    End Function

    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click
        allTransactionsGrid.Columns.RemoveAt(allTransactionsGrid.Columns.Count - 1)
        allTransactionsGrid.Columns.RemoveAt(1)

        'For Exporting to Excel
        loadingPanel.Visible = True
        extractToExcell.DATAGRIDVIEW_TO_EXCEL(allTransactionsGrid)
        loadingPanel.Visible = False
        '************************

    End Sub

    Private Sub allTransactionsGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles allTransactionsGrid.CellContentClick


        Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then

            Dim theSelected As Integer = 0

            If (allTransactionsGrid.Rows.Count - 1) <> e.RowIndex Or (allTransactionsGrid.Rows.Count - 1) > e.RowIndex Then


                theSelected = allTransactionsGrid.Rows(e.RowIndex).Cells(1).Value
                My.Settings.fromAllTrans = True
                My.Settings.selectedTransaction = theSelected
                My.Settings.Save()

                If allTransactionsGrid.Rows(e.RowIndex).Cells(2).Value = "Purchase" Then


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
                ElseIf allTransactionsGrid.Rows(e.RowIndex).Cells(2).Value = "Transfer" Then

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
                ElseIf allTransactionsGrid.Rows(e.RowIndex).Cells(2).Value.Contains("Stock") Then


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

            End If
        End If

    End Sub

    Private Sub allTransactionsGrid_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles allTransactionsGrid.CellPainting

        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso e.RowIndex < allTransactionsGrid.Rows.Count - 1 Then
            If TypeOf allTransactionsGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then

                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                Dim bmpFind As Bitmap = My.Resources.view
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 2, e.CellBounds.Top + 3)
                e.Handled = True

            End If
        End If


    End Sub
End Class