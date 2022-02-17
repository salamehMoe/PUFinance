<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fixedAstHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AssetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImortFromInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisposalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.AddToolStripMenuItem, Me.TransactionsToolStripMenuItem, Me.ReportsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1166, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.HomeToolStripMenuItem.Text = "Home"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClassToolStripMenuItem, Me.AssetToolStripMenuItem, Me.VendorToolStripMenuItem, Me.LocationToolStripMenuItem})
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'ClassToolStripMenuItem
        '
        Me.ClassToolStripMenuItem.Name = "ClassToolStripMenuItem"
        Me.ClassToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ClassToolStripMenuItem.Text = "Class"
        '
        'AssetToolStripMenuItem
        '
        Me.AssetToolStripMenuItem.Name = "AssetToolStripMenuItem"
        Me.AssetToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.AssetToolStripMenuItem.Text = "Asset"
        '
        'VendorToolStripMenuItem
        '
        Me.VendorToolStripMenuItem.Name = "VendorToolStripMenuItem"
        Me.VendorToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.VendorToolStripMenuItem.Text = "Vendor"
        '
        'LocationToolStripMenuItem
        '
        Me.LocationToolStripMenuItem.Name = "LocationToolStripMenuItem"
        Me.LocationToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.LocationToolStripMenuItem.Text = "Location"
        '
        'TransactionsToolStripMenuItem
        '
        Me.TransactionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseToolStripMenuItem, Me.ImortFromInventoryToolStripMenuItem, Me.TransferToolStripMenuItem, Me.DisposalToolStripMenuItem})
        Me.TransactionsToolStripMenuItem.Name = "TransactionsToolStripMenuItem"
        Me.TransactionsToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
        Me.TransactionsToolStripMenuItem.Text = "Transactions"
        '
        'PurchaseToolStripMenuItem
        '
        Me.PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        Me.PurchaseToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.PurchaseToolStripMenuItem.Text = "Purchase"
        '
        'ImortFromInventoryToolStripMenuItem
        '
        Me.ImortFromInventoryToolStripMenuItem.Name = "ImortFromInventoryToolStripMenuItem"
        Me.ImortFromInventoryToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ImortFromInventoryToolStripMenuItem.Text = "Imort From Inventory"
        '
        'TransferToolStripMenuItem
        '
        Me.TransferToolStripMenuItem.Name = "TransferToolStripMenuItem"
        Me.TransferToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.TransferToolStripMenuItem.Text = "Transfer"
        '
        'DisposalToolStripMenuItem
        '
        Me.DisposalToolStripMenuItem.Name = "DisposalToolStripMenuItem"
        Me.DisposalToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.DisposalToolStripMenuItem.Text = "Disposal"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'fixedAstHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1166, 681)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "fixedAstHome"
        Me.Text = "Fixed Asset Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransactionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AssetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VendorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LocationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImortFromInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TransferToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisposalToolStripMenuItem As ToolStripMenuItem
End Class
