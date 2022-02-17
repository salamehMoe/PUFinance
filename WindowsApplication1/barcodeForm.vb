
Imports System.Data.SqlClient
Public Class barcodeForm


    Public barcodeList As New List(Of String)
    Dim selectedItem As String
    Dim selectedItemIndex As Integer = -1

    Dim theTranID As Integer = -1
    Dim dataBaseObj As New DatabaseAccesClass
    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
    Dim conn2 As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
    Dim fromDelete As Boolean = False


    Private Sub barcodeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'If barcodeList.Count > 0 Then


        '    For i As Integer = 0 To barcodeList.Count

        '        barcodeListBox.Items.Add(barcodeList(i))

        '    Next
        'End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        barcodeList.Clear()
        barcodeListBox.Items.Clear()
        selectedItemIndex = -1
        Me.Finalize()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        theTranID = My.Settings.barcodeTrans


        'Me.Finalize()
        'Exit Sub
        If fromDelete = False Then

            Dim dt As New DataTable



            For i As Integer = 0 To barcodeListBox.Items.Count - 1

                dt = dataBaseObj.SelectMethode("Select * from db_owner.tbl_asset_barcodes where ( transID = '" & theTranID & "' 
                and itemID = '" & My.Settings.barcodesID & "' and itemBarcode = '" & barcodeListBox.Items(i) & "')")

                If dt.Rows.Count <= 0 Then

                    Dim query As String = String.Empty
                    query = "INSERT INTO db_owner.tbl_asset_barcodes (transID, itemID, itemBarcode,inTransfer)
                         VALUES(@transID, @itemID, @itemBarcode, @inTransfer)"

                    Using comm As New SqlCommand()
                        With comm
                            .Connection = conn
                            .CommandType = CommandType.Text
                            .CommandText = query
                            .Parameters.AddWithValue("@transID", My.Settings.barcodeTrans)
                            .Parameters.AddWithValue("@itemID", My.Settings.barcodesID)
                            .Parameters.AddWithValue("@itemBarcode", barcodeListBox.Items(i))
                            .Parameters.AddWithValue("@inTransfer", False)

                        End With
                        conn.Open()
                        comm.ExecuteNonQuery()

                        conn.Close()

                    End Using

                End If

            Next

        ElseIf fromDelete = True Then

            fromDelete = False

        End If

        If My.Settings.fromAssetImported Then
            assetsImported.transactionData.CurrentRow.Cells(6).Value = barcodeListBox.Items.Count & " Barcodes Added"
        ElseIf My.Settings.fromAssetPurchase Then
            assetPurchaseTransaction.transactionData.CurrentRow.Cells(6).Value = barcodeListBox.Items.Count & " Barcodes Added"
        End If

        barcodeListBox.Items.Clear()
        selectedItemIndex = -1


        Me.Finalize()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If selectedItemIndex <> -1 Then

            Dim rows1 As Integer
            Dim myCommand1 As SqlCommand = conn2.CreateCommand()


            Try

                conn2.Open()

                myCommand1.CommandText = "Delete  From db_owner.tbl_asset_barcodes where (itemID = '" & My.Settings.barcodesID & "' 
                and itemBarcode = '" & barcodeListBox.Items(selectedItemIndex) & "')"

                rows1 = myCommand1.ExecuteNonQuery()



            Catch ex As SqlException

                ' handle error
                Console.Write("Unable to Delete")


            Finally
                conn2.Close()
            End Try

            barcodeList.RemoveAt(selectedItemIndex)
            barcodeListBox.Items.RemoveAt(selectedItemIndex)

        End If

        selectedItemIndex = -1

        fromDelete = True

    End Sub

    Private Sub barcodeListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles barcodeListBox.SelectedIndexChanged

        selectedItem = barcodeListBox.SelectedItem
        selectedItemIndex = barcodeListBox.SelectedIndex
        'MessageBox.Show(selectedItemIndex)
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click



        For i As Integer = 0 To barcodeListBox.Items.Count - 1

            Dim rows1 As Integer
            Dim myCommand1 As SqlCommand = conn2.CreateCommand()


            Try

                conn2.Open()

                myCommand1.CommandText = "Delete  From db_owner.tbl_asset_barcodes where (transID = '" & My.Settings.barcodeTrans & "' 
                and itemBarcode = '" & barcodeListBox.Items(i) & "')"

                rows1 = myCommand1.ExecuteNonQuery()



            Catch ex As SqlException

                ' handle error
                Console.Write("Unable to Delete")


            Finally
                conn2.Close()
            End Try

        Next


        barcodeList.Clear()
        barcodeListBox.Items.Clear()


        fromDelete = True

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

        If barcodeListBox.Items.Count > 0 Then

            barcodeListBox.Items.Clear()


            Dim rows1 As Integer
            Dim myCommand1 As SqlCommand = conn.CreateCommand()


            Try

                conn.Open()

                myCommand1.CommandText = "Delete  From db_owner.tbl_asset_barcodes where (transID = '" & My.Settings.barcodeTrans & "' 
                and itemID = '" & My.Settings.barcodesID & "')"

                rows1 = myCommand1.ExecuteNonQuery()



            Catch ex As SqlException

                ' handle error
                Console.Write("Unable to Delete")


            Finally
                conn.Close()
            End Try

        End If
        Dim theQty As Integer = My.Settings.barcodeQty
        Dim maxBar As Integer = 0

        If theQty = 0 Then
            MessageBox.Show("Please Enter a valied Quantity")
        End If

        'MessageBox.Show("THE ID " & My.Settings.barcodesID)
        For i As Integer = 1 To theQty

            Dim idDt As New DataTable
            idDt = dataBaseObj.SelectMethode("Select ID from db_owner.tbl_asset_barcodes 
            where(itemID = '" & My.Settings.barcodesID & "')")

            'MessageBox.Show("THE LENGTH of idDt" & idDt.Rows.Count & " with " & My.Settings.barcodesID)

            Dim dt As New DataTable
            dt = dataBaseObj.SelectMethode("Select MAX(noPrfxBarcode) as [barcode] from db_owner.tbl_asset_barcodes
            where(itemID = '" & My.Settings.barcodesID & "')")

            If idDt.Rows.Count > 0 Then

                If maxBar <= dt.Rows(0)("barcode") Then
                    maxBar = dt.Rows(0)("barcode") + 1
                Else
                    maxBar = 10000
                End If

            Else
                maxBar = 10000
            End If


            Dim dt2 As New DataTable

            If My.Settings.fromAssetImported And My.Settings.fromAssetPurchase = False Then

                dt2 = dataBaseObj.SelectMethode("Select prefix from db_owner.tbl_asset 
                where (assetID = '" & My.Settings.barcodesID & "')")

            ElseIf My.Settings.fromAssetPurchase And My.Settings.fromAssetImported = False Then

                dt2 = dataBaseObj.SelectMethode("Select prefix from db_owner.tbl_asset 
                where (ID = '" & My.Settings.barcodesID & "')")

            End If



                Dim prefix As String = dt2.Rows(0)("prefix")

                Dim theWholeBarcode As String = prefix + "-" + maxBar.ToString
                Dim query As String = String.Empty
                query = "INSERT INTO db_owner.tbl_asset_barcodes (transID, itemID, itemBarcode,noPrfxBarcode, inTransfer)
                             VALUES(@transID, @itemID, @itemBarcode, @noPrfxBarcode, @inTransfer)"

                Using comm As New SqlCommand()
                    With comm
                        .Connection = conn
                        .CommandType = CommandType.Text
                        .CommandText = query
                    .Parameters.AddWithValue("@transID", My.Settings.barcodeTrans)
                    .Parameters.AddWithValue("@itemID", My.Settings.barcodesID)
                        .Parameters.AddWithValue("@itemBarcode", theWholeBarcode)
                        .Parameters.AddWithValue("@noPrfxBarcode", maxBar)
                        .Parameters.AddWithValue("@inTransfer", False)

                    End With
                    conn.Open()
                    comm.ExecuteNonQuery()

                    conn.Close()

                End Using

                barcodeListBox.Items.Add(theWholeBarcode)
        Next

    End Sub
End Class