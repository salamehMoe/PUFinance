<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocationInventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllTransactionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByLocationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryByItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ByVendorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.AddToolStripMenuItem, Me.HelpMenu, Me.ReportsToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1106, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(52, 20)
        Me.FileMenu.Text = "Home"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VendorToolStripMenuItem, Me.LocationToolStripMenuItem, Me.GroupToolStripMenuItem, Me.ItemToolStripMenuItem})
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'VendorToolStripMenuItem
        '
        Me.VendorToolStripMenuItem.Name = "VendorToolStripMenuItem"
        Me.VendorToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.VendorToolStripMenuItem.Text = "Vendor"
        '
        'LocationToolStripMenuItem
        '
        Me.LocationToolStripMenuItem.Name = "LocationToolStripMenuItem"
        Me.LocationToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LocationToolStripMenuItem.Text = "Location"
        '
        'GroupToolStripMenuItem
        '
        Me.GroupToolStripMenuItem.Name = "GroupToolStripMenuItem"
        Me.GroupToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.GroupToolStripMenuItem.Text = "Group"
        '
        'ItemToolStripMenuItem
        '
        Me.ItemToolStripMenuItem.Name = "ItemToolStripMenuItem"
        Me.ItemToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ItemToolStripMenuItem.Text = "Item"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PurchaseToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(86, 20)
        Me.HelpMenu.Text = "Transactions"
        '
        'PurchaseToolStripMenuItem
        '
        Me.PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        Me.PurchaseToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.PurchaseToolStripMenuItem.Text = "Purchase"
        '
        'IndexToolStripMenuItem
        '
        Me.IndexToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
        Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.IndexToolStripMenuItem.Text = "Transfer"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.SearchToolStripMenuItem.Text = "Stock"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllInventoryToolStripMenuItem, Me.LocationInventoryToolStripMenuItem, Me.AllTransactionsToolStripMenuItem, Me.ByLocationToolStripMenuItem, Me.InventoryByItemToolStripMenuItem, Me.ByVendorToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'AllInventoryToolStripMenuItem
        '
        Me.AllInventoryToolStripMenuItem.Name = "AllInventoryToolStripMenuItem"
        Me.AllInventoryToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.AllInventoryToolStripMenuItem.Text = "All Inventory"
        '
        'LocationInventoryToolStripMenuItem
        '
        Me.LocationInventoryToolStripMenuItem.Name = "LocationInventoryToolStripMenuItem"
        Me.LocationInventoryToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.LocationInventoryToolStripMenuItem.Text = "Location Inventory"
        '
        'AllTransactionsToolStripMenuItem
        '
        Me.AllTransactionsToolStripMenuItem.Name = "AllTransactionsToolStripMenuItem"
        Me.AllTransactionsToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.AllTransactionsToolStripMenuItem.Text = "All Transactions"
        '
        'ByLocationToolStripMenuItem
        '
        Me.ByLocationToolStripMenuItem.Name = "ByLocationToolStripMenuItem"
        Me.ByLocationToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ByLocationToolStripMenuItem.Text = "Location's Transactions"
        '
        'InventoryByItemToolStripMenuItem
        '
        Me.InventoryByItemToolStripMenuItem.Name = "InventoryByItemToolStripMenuItem"
        Me.InventoryByItemToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.InventoryByItemToolStripMenuItem.Text = "Item by Location"
        '
        'ByVendorToolStripMenuItem
        '
        Me.ByVendorToolStripMenuItem.Name = "ByVendorToolStripMenuItem"
        Me.ByVendorToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ByVendorToolStripMenuItem.Text = "Item by Vendor"
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1106, 665)
        Me.Controls.Add(Me.MenuStrip)
        Me.Font = New System.Drawing.Font("Gadugi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home Page"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ByLocationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryByItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VendorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LocationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GroupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ByVendorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AllTransactionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LocationInventoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem As ToolStripMenuItem
End Class
