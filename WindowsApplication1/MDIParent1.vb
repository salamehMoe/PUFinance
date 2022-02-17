Imports System.Windows.Forms

Public Class Home

    Dim dataBasObject As New DatabaseAccesClass

    Private m_ChildFormNumber As Integer

    ' Multiple Navigation Btns
    Private Sub FileMenu_Click(sender As Object, e As EventArgs) Handles FileMenu.Click

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

    Private Sub ContentsToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub IndexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IndexToolStripMenuItem.Click
        If Me.ActiveMdiChild IsNot transferTransactions Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        transferTransactions.MdiParent = Me
        transferTransactions.Size = Me.Size
        transferTransactions.WindowState = FormWindowState.Maximized
        transferTransactions.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot stockTransaction Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If
        stockTransaction.MdiParent = Me
        stockTransaction.Size = Me.Size
        stockTransaction.WindowState = FormWindowState.Maximized
        stockTransaction.Show()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If Me.ActiveMdiChild IsNot HomeIndex Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        InventoryHome.MdiParent = Me
        InventoryHome.Size = Me.Size
        InventoryHome.WindowState = FormWindowState.Maximized
        InventoryHome.Show()


    End Sub

    Private Sub ByLocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByLocationToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot ReportByTransactionLocation Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        ReportByTransactionLocation.MdiParent = Me
        ReportByTransactionLocation.Size = Me.Size
        ReportByTransactionLocation.WindowState = FormWindowState.Maximized
        ReportByTransactionLocation.Show()


    End Sub

    Private Sub AllInventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllInventoryToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot ReportAllInventory Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        ReportAllInventory.MdiParent = Me
        ReportAllInventory.Size = Me.Size
        ReportAllInventory.WindowState = FormWindowState.Maximized
        ReportAllInventory.Show()

    End Sub

    Private Sub InventoryByItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryByItemToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot ReportByLocation Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        ReportByLocation.MdiParent = Me
        ReportByLocation.Size = Me.Size
        ReportByLocation.WindowState = FormWindowState.Maximized
        ReportByLocation.Show()

    End Sub

    Private Sub VendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VendorToolStripMenuItem.Click
        If Me.ActiveMdiChild IsNot insertVendor Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        insertVendor.MdiParent = Me
        insertVendor.Size = Me.Size
        insertVendor.WindowState = FormWindowState.Normal
        insertVendor.Show()

    End Sub

    Private Sub LocationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationToolStripMenuItem.Click
        If Me.ActiveMdiChild IsNot insertLocation Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        insertLocation.MdiParent = Me
        insertLocation.Size = Me.Size
        insertLocation.WindowState = FormWindowState.Normal
        insertLocation.Show()

    End Sub

    Private Sub ItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemToolStripMenuItem.Click
        If Me.ActiveMdiChild IsNot insertItem Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        insertItem.MdiParent = Me
        insertItem.Size = Me.Size
        insertItem.WindowState = FormWindowState.Normal
        insertItem.Show()

    End Sub

    Private Sub GroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GroupToolStripMenuItem.Click
        If Me.ActiveMdiChild IsNot insertGroup Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        insertGroup.MdiParent = Me
        insertGroup.Left = 0
        insertGroup.Top = 0
        insertGroup.Size = Me.Size
        insertGroup.WindowState = FormWindowState.Normal
        insertGroup.Show()
    End Sub

    Private Sub ByVendorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ByVendorToolStripMenuItem.Click
        If Me.ActiveMdiChild IsNot ReportByVendor Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        ReportByVendor.MdiParent = Me
        ReportByVendor.Left = 0
        ReportByVendor.Top = 0
        ReportByVendor.Size = Me.Size
        ReportByVendor.WindowState = FormWindowState.Normal
        ReportByVendor.Show()
    End Sub

    Private Sub AllTransactionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllTransactionsToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot ReportAllTransactions Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        ReportAllTransactions.MdiParent = Me
        ReportAllTransactions.Left = 0
        ReportAllTransactions.Top = 0
        ReportAllTransactions.Size = Me.Size
        ReportAllTransactions.WindowState = FormWindowState.Normal
        ReportAllTransactions.Show()

    End Sub

    Private Sub LocationInventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationInventoryToolStripMenuItem.Click

        If Me.ActiveMdiChild IsNot ReportByLocationInventory Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        ReportByLocationInventory.MdiParent = Me
        ReportByLocationInventory.Left = 0
        ReportByLocationInventory.Top = 0
        ReportByLocationInventory.Size = Me.Size
        ReportByLocationInventory.WindowState = FormWindowState.Normal
        ReportByLocationInventory.Show()

    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseToolStripMenuItem.Click
        If Me.ActiveMdiChild IsNot purchaseTransactions Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        purchaseTransactions.MdiParent = Me
        purchaseTransactions.Size = Me.Size
        purchaseTransactions.WindowState = FormWindowState.Maximized
        purchaseTransactions.Show()
    End Sub



    '**********************************************


End Class
