Public Class ReportAllInventory

    Dim dataBaseObject As New DatabaseAccesClass
    Dim extractToExcell As New exportdatagridviewclass
    Dim dt0 As New DataTable
    Dim theTranID As String

    Private Sub AllInventoryReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Varaibles
        Dim theItemID As Integer = 0
        Dim totalQty As Integer = 0
        Dim totalAvgPrice As Decimal = 0
        Dim totalPrice As Decimal = 0
        Dim theItemStatus As String = String.Empty
        Dim theMinimumQty As Integer = 0
        Dim theHalfPercent As Decimal = 0
        Dim theThreeQurterPercent As Decimal = 0
        Dim locName As String = "Ware"
        Dim locName2 As String = "ware"
        '*********************************

        dt0 = dataBaseObject.SelectMethode("Select ID from db_owner.tbl_location where (Name LIKE '%" & locName & "%' or Name LIKE '%" & locName2 & "%' and Status = 1)")
        theTranID = dt0.Rows(0)("ID").ToString

        'For Displaying the gridview
        allInventoryGrid.DataSource = getAllInventoryData()
        allInventoryGrid.Columns(1).Width = 200
        allInventoryGrid.Columns(4).Width = 120
        allInventoryGrid.Columns(8).Visible = False

        '*******************************

        'Loop For calculating Totals
        For i As Integer = 0 To allInventoryGrid.Rows.Count - 2

            theItemID = allInventoryGrid.Rows(i).Cells(8).Value
            totalQty = 0
            totalAvgPrice = 0
            totalPrice = 0

            Dim foundItemCount As Integer = 0
            For j As Integer = 0 To allInventoryGrid.Rows.Count - 2

                If theItemID = allInventoryGrid.Rows(j).Cells(8).Value Then

                    foundItemCount = foundItemCount + 1
                    totalQty = totalQty + allInventoryGrid.Rows(j).Cells(2).Value.ToString
                    totalAvgPrice = totalAvgPrice + allInventoryGrid.Rows(j).Cells(3).Value.ToString
                End If

            Next

            allInventoryGrid.Rows(i).Cells(2).Value = totalQty
            allInventoryGrid.Rows(i).Cells(3).Value = Math.Round((totalAvgPrice / foundItemCount), 2)
            allInventoryGrid.Rows(i).Cells(4).Value = Math.Round((totalQty * allInventoryGrid.Rows(i).Cells(3).Value), 2)
            allInventoryGrid.Rows(i).Cells(6).Value = totalQty - allInventoryGrid.Rows(i).Cells(5).Value
            '*********************************************

            'For Checking the Status of Item

            theMinimumQty = allInventoryGrid.Rows(i).Cells(5).Value
            theHalfPercent = theMinimumQty / 2
            theThreeQurterPercent = theMinimumQty * 1.2

            If totalQty > theThreeQurterPercent Then
                theItemStatus = "Over"
            ElseIf totalQty < theThreeQurterPercent AndAlso totalQty >= theMinimumQty Then
                theItemStatus = "Safe"
            ElseIf totalQty > theHalfPercent AndAlso totalQty < theMinimumQty Then
                theItemStatus = "Suggested"
            ElseIf totalQty <= theHalfPercent Then
                theItemStatus = "Urgent"
            End If

            allInventoryGrid.Rows(i).Cells(7).Style.BackColor = Color.Red
            allInventoryGrid.Rows(i).Cells(7).Value = theItemStatus
            '************************************


        Next

        'For Removing duplicate Items

        For intI = allInventoryGrid.Rows.Count - 1 To 0 Step -1
            For intJ = intI - 1 To 0 Step -1
                If allInventoryGrid.Rows(intI).Cells(8).Value = allInventoryGrid.Rows(intJ).Cells(8).Value Then
                    allInventoryGrid.Rows.RemoveAt(intI)
                    Exit For
                End If
            Next
        Next
        '*****************************

    End Sub

    Private Sub allInventoryGrid_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles allInventoryGrid.CellFormatting

        'For Changing cell Background according to status
        For j As Integer = 0 To allInventoryGrid.Rows.Count - 2
            If allInventoryGrid.Rows(j).Cells(7).Value = "Urgent" Then
                allInventoryGrid.Rows(j).Cells(7).Style.BackColor = Color.Red
                allInventoryGrid.Rows(j).Cells(7).Style.ForeColor = Color.White
            ElseIf allInventoryGrid.Rows(j).Cells(7).Value = "Suggested" Then
                allInventoryGrid.Rows(j).Cells(7).Style.BackColor = Color.Orange
                allInventoryGrid.Rows(j).Cells(7).Style.ForeColor = Color.White
            Else
                allInventoryGrid.Rows(j).Cells(7).Style.BackColor = Color.White

            End If
        Next
        '*************************************************
    End Sub

    Function getAllInventoryData()

        'For Getting all Items available in the Inventory

        Dim dt As New DataTable

        dt = dataBaseObject.SelectMethode(" Select db_owner.tbl_Item.ItemID [Item ID], db_owner.tbl_location_inventory.ItemName [Name],
                                            db_owner.tbl_location_inventory.ItemQty [Quantity Available],
                                            db_owner.tbl_location_inventory.ItemAvgPrice [Avg Unit Cost], 
                                            db_owner.tbl_location_inventory.itemTotalPrice [Total Cost],
                                            db_owner.tbl_Item.MinimumQty [Minimum Stock],
                                            db_owner.tbl_location_inventory.ItemID [Differance], db_owner.tbl_location_inventory.ItemID [Status],
                                            db_owner.tbl_location_inventory.ItemID [Item ID]
                                            from db_owner.tbl_location_inventory,db_owner.tbl_Item 
                                            where ( db_owner.tbl_Item.ID = db_owner.tbl_Location_inventory.ItemID and db_owner.tbl_location_inventory.LocationID = '" & theTranID & "' )")




        Return dt

        '***********************************************
    End Function

    Private Sub printBtn_Click(sender As Object, e As EventArgs) Handles printBtn.Click
        allInventoryGrid.Columns.RemoveAt(8)
        'For Exporting to Excel
        loadingPanel.Visible = True
        extractToExcell.DATAGRIDVIEW_TO_EXCEL(allInventoryGrid)
        loadingPanel.Visible = False
        '************************

    End Sub


End Class