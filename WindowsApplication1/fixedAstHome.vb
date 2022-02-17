Public Class fixedAstHome
    Private Sub fixedAstHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        If Me.ActiveMdiChild IsNot HomeIndex Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        'HomeIndex.MdiParent = Me
        'HomeIndex.Size = Me.Size
        'HomeIndex.WindowState = FormWindowState.Maximized
        'HomeIndex.Show()
    End Sub

    Private Sub ClassToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot assetClassAdd Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        assetClassAdd.MdiParent = Me
        assetClassAdd.Size = Me.Size
        assetClassAdd.WindowState = FormWindowState.Maximized
        assetClassAdd.Show()

    End Sub

    Private Sub AssetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssetToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot assetAdd Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        assetAdd.MdiParent = Me
        assetAdd.Size = Me.Size
        assetAdd.WindowState = FormWindowState.Maximized
        assetAdd.Show()

    End Sub

    Private Sub VendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendorToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot assetVendorAdd Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        assetVendorAdd.MdiParent = Me
        assetVendorAdd.Size = Me.Size
        assetVendorAdd.WindowState = FormWindowState.Maximized
        assetVendorAdd.Show()

    End Sub

    Private Sub LocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot assetLocationAdd Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        assetLocationAdd.MdiParent = Me
        assetLocationAdd.Size = Me.Size
        assetLocationAdd.WindowState = FormWindowState.Maximized
        assetLocationAdd.Show()

    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot assetPurchaseTransaction Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        assetPurchaseTransaction.MdiParent = Me
        assetPurchaseTransaction.Size = Me.Size
        assetPurchaseTransaction.WindowState = FormWindowState.Maximized
        assetPurchaseTransaction.Show()

    End Sub

    Private Sub ImortFromInventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImortFromInventoryToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot assetsImported Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        assetsImported.MdiParent = Me
        assetsImported.Size = Me.Size
        assetsImported.WindowState = FormWindowState.Maximized
        assetsImported.Show()

    End Sub

    Private Sub TransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot assetTransfer Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        assetTransfer.MdiParent = Me
        assetTransfer.Size = Me.Size
        assetTransfer.WindowState = FormWindowState.Maximized
        assetTransfer.Show()


    End Sub

    Private Sub DisposalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisposalToolStripMenuItem.Click



    End Sub

End Class