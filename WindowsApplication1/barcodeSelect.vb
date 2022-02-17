
Imports System.Data.SqlClient
Public Class barcodeSelect

    Private formRegion As Rectangle
    Private borderColor As Color = Color.DarkRed
    Private borderWidth As Integer = 1
    Dim databaseObj As New DatabaseAccesClass

    Dim theAssetID As Integer = My.Settings.theAssetID
    Dim theTransID As Integer = My.Settings.theTransID

    Dim transferBarcodes As List(Of KeyValuePair(Of String, String)) =
    New List(Of KeyValuePair(Of String, String))

    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Finalize()

    End Sub

    Private Sub barcodeSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        barcodeCheckList.DataSource = getAllAssetBarcodes()
        barcodeCheckList.Columns(0).Width = 25
        barcodeCheckList.Columns(1).Width = 90
        barcodeCheckList.Columns(2).Visible = False


        'For Form Design
        formRegion = New Rectangle(0, 0, 360, 450)
        '******************
    End Sub

    Private Sub barcodeSelect_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        'Form Design
        ControlPaint.DrawBorder(e.Graphics, formRegion, borderColor,
        borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
        ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
        borderColor, borderWidth, ButtonBorderStyle.Solid)
        '***************

    End Sub

    Function getAllAssetBarcodes()

        Dim dt As New DataTable

        dt = databaseObj.SelectMethode("Select inTransfer as [ ], itemBarcode as [Barcode], ID 
        from db_owner.tbl_asset_barcodes where (inTransfer = 0 and transID = " & theTransID & " 
        and itemID = " & theAssetID & ")")

        Return dt
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For i As Integer = 0 To barcodeCheckList.Rows.Count - 1
            barcodeCheckList.Rows(i).Cells(0).Value = 0
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim dt As New DataTable

        For i As Integer = 0 To barcodeCheckList.Rows.Count - 2

            If barcodeCheckList.Rows(i).Cells(0).Value = 1 Then

                Dim thebarcodeID As Integer = barcodeCheckList.Rows(i).Cells(2).Value

                Dim rows As Integer
                Dim myCommand As SqlCommand = conn.CreateCommand()

                Try

                    conn.Open()


                    myCommand.CommandText = "Update  db_owner.tbl_asset_Barcodes Set transfertransID = 0 
                    where (ID = '" & thebarcodeID & "')"

                    rows = myCommand.ExecuteNonQuery()

                Catch ex As SqlException

                    ' handle error

                    MessageBox.Show(ex.Message)

                Finally

                    conn.Close()

                End Try

            End If
        Next
    End Sub
End Class