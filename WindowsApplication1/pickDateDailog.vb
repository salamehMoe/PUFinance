Public Class pickDateDailog

    Dim fromPurchase As Boolean
    Dim fromTransfer As Boolean


    Private Sub pickDateDailog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateTimePicker1.Select()
        SendKeys.Send("{F4}")
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged


        fromPurchase = My.Settings.fromPurchase
        fromTransfer = My.Settings.fromTransfer
        Dim theDate As String
        theDate = Format(DateTimePicker1.Value, "MMM d,yyyy")

        If fromPurchase And fromTransfer = False Then

            My.Settings.fromPurchase = False
            My.Settings.fromTransfer = False

            assetPurchaseTransaction.transactionData.CurrentRow.Cells(7).Value = theDate
            Me.Finalize()

        ElseIf fromPurchase = False And fromTransfer Then

            My.Settings.fromPurchase = False
            My.Settings.fromTransfer = False

            assetTransfer.transactionData.CurrentRow.Cells(7).Value = theDate
            Me.Finalize()
        End If


    End Sub


End Class