<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class assetsImported
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.currancyLabel = New System.Windows.Forms.Label()
        Me.allItemsPrice = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.allItemsQty = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.transactionData = New System.Windows.Forms.DataGridView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.InvID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inventoryNameField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assetClass = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.qtyField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemUnitPriceField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barcode = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.acqDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.locationCell = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.vendorCell = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridDeleteBtn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.genratedInventory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tranID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.classID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LocID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.transactionData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.currancyLabel)
        Me.Panel2.Controls.Add(Me.allItemsPrice)
        Me.Panel2.Location = New System.Drawing.Point(564, 614)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(132, 29)
        Me.Panel2.TabIndex = 242
        '
        'currancyLabel
        '
        Me.currancyLabel.AutoSize = True
        Me.currancyLabel.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currancyLabel.Location = New System.Drawing.Point(2, 3)
        Me.currancyLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.currancyLabel.Name = "currancyLabel"
        Me.currancyLabel.Size = New System.Drawing.Size(69, 16)
        Me.currancyLabel.TabIndex = 173
        Me.currancyLabel.Text = "Total Price"
        '
        'allItemsPrice
        '
        Me.allItemsPrice.AutoSize = True
        Me.allItemsPrice.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.allItemsPrice.Location = New System.Drawing.Point(75, 3)
        Me.allItemsPrice.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.allItemsPrice.Name = "allItemsPrice"
        Me.allItemsPrice.Size = New System.Drawing.Size(15, 16)
        Me.allItemsPrice.TabIndex = 171
        Me.allItemsPrice.Text = "0"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.allItemsQty)
        Me.Panel1.Location = New System.Drawing.Point(345, 614)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(138, 29)
        Me.Panel1.TabIndex = 241
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Total Quantity"
        '
        'allItemsQty
        '
        Me.allItemsQty.AutoSize = True
        Me.allItemsQty.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.allItemsQty.Location = New System.Drawing.Point(100, 3)
        Me.allItemsQty.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.allItemsQty.Name = "allItemsQty"
        Me.allItemsQty.Size = New System.Drawing.Size(15, 16)
        Me.allItemsQty.TabIndex = 172
        Me.allItemsQty.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Gadugi", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(9, 63)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(239, 28)
        Me.Label14.TabIndex = 240
        Me.Label14.Text = "Imported Transaction"
        '
        'transactionData
        '
        Me.transactionData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.transactionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.transactionData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InvID, Me.inventoryNameField, Me.assetClass, Me.qtyField, Me.itemUnitPriceField, Me.itemTotalPrice, Me.barcode, Me.acqDate, Me.locationCell, Me.vendorCell, Me.gridDeleteBtn, Me.genratedInventory, Me.tranID, Me.classID, Me.LocID})
        Me.transactionData.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.transactionData.Location = New System.Drawing.Point(13, 100)
        Me.transactionData.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.transactionData.Name = "transactionData"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.transactionData.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.transactionData.Size = New System.Drawing.Size(1179, 515)
        Me.transactionData.TabIndex = 232
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DarkRed
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ForeColor = System.Drawing.SystemColors.Window
        Me.Button5.Location = New System.Drawing.Point(1016, 66)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(176, 28)
        Me.Button5.TabIndex = 243
        Me.Button5.Text = "SAVE"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'InvID
        '
        Me.InvID.HeaderText = "Asset ID"
        Me.InvID.Name = "InvID"
        Me.InvID.ReadOnly = True
        Me.InvID.Width = 90
        '
        'inventoryNameField
        '
        Me.inventoryNameField.HeaderText = "Asset"
        Me.inventoryNameField.Name = "inventoryNameField"
        Me.inventoryNameField.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.inventoryNameField.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.inventoryNameField.Width = 120
        '
        'assetClass
        '
        Me.assetClass.HeaderText = "Class"
        Me.assetClass.Name = "assetClass"
        Me.assetClass.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.assetClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'qtyField
        '
        Me.qtyField.HeaderText = "Quantity"
        Me.qtyField.Name = "qtyField"
        Me.qtyField.ReadOnly = True
        '
        'itemUnitPriceField
        '
        Me.itemUnitPriceField.HeaderText = "Unit Price"
        Me.itemUnitPriceField.Name = "itemUnitPriceField"
        Me.itemUnitPriceField.ReadOnly = True
        '
        'itemTotalPrice
        '
        Me.itemTotalPrice.HeaderText = "Total price"
        Me.itemTotalPrice.Name = "itemTotalPrice"
        Me.itemTotalPrice.ReadOnly = True
        '
        'barcode
        '
        Me.barcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.barcode.HeaderText = "Barcode"
        Me.barcode.Name = "barcode"
        Me.barcode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.barcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.barcode.Width = 140
        '
        'acqDate
        '
        Me.acqDate.HeaderText = "Acquisation Date"
        Me.acqDate.Name = "acqDate"
        Me.acqDate.ReadOnly = True
        Me.acqDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.acqDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.acqDate.Width = 120
        '
        'locationCell
        '
        Me.locationCell.HeaderText = "Location"
        Me.locationCell.Name = "locationCell"
        Me.locationCell.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.locationCell.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.locationCell.Width = 140
        '
        'vendorCell
        '
        Me.vendorCell.HeaderText = "Vendor"
        Me.vendorCell.Name = "vendorCell"
        Me.vendorCell.ReadOnly = True
        '
        'gridDeleteBtn
        '
        Me.gridDeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gridDeleteBtn.HeaderText = ""
        Me.gridDeleteBtn.Name = "gridDeleteBtn"
        Me.gridDeleteBtn.Width = 25
        '
        'genratedInventory
        '
        Me.genratedInventory.HeaderText = "Inventory ID"
        Me.genratedInventory.Name = "genratedInventory"
        Me.genratedInventory.ReadOnly = True
        Me.genratedInventory.Width = 120
        '
        'tranID
        '
        Me.tranID.HeaderText = "TranID"
        Me.tranID.Name = "tranID"
        Me.tranID.ReadOnly = True
        '
        'classID
        '
        Me.classID.HeaderText = "Class ID"
        Me.classID.Name = "classID"
        '
        'LocID
        '
        Me.LocID.HeaderText = "LocID"
        Me.LocID.Name = "LocID"
        '
        'assetsImported
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1261, 672)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.transactionData)
        Me.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "assetsImported"
        Me.Text = "Assets Imported"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.transactionData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents currancyLabel As Label
    Friend WithEvents allItemsPrice As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents allItemsQty As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents transactionData As DataGridView
    Friend WithEvents Button5 As Button
    Friend WithEvents InvID As DataGridViewTextBoxColumn
    Friend WithEvents inventoryNameField As DataGridViewTextBoxColumn
    Friend WithEvents assetClass As DataGridViewComboBoxColumn
    Friend WithEvents qtyField As DataGridViewTextBoxColumn
    Friend WithEvents itemUnitPriceField As DataGridViewTextBoxColumn
    Friend WithEvents itemTotalPrice As DataGridViewTextBoxColumn
    Friend WithEvents barcode As DataGridViewButtonColumn
    Friend WithEvents acqDate As DataGridViewTextBoxColumn
    Friend WithEvents locationCell As DataGridViewComboBoxColumn
    Friend WithEvents vendorCell As DataGridViewTextBoxColumn
    Friend WithEvents gridDeleteBtn As DataGridViewButtonColumn
    Friend WithEvents genratedInventory As DataGridViewTextBoxColumn
    Friend WithEvents tranID As DataGridViewTextBoxColumn
    Friend WithEvents classID As DataGridViewTextBoxColumn
    Friend WithEvents LocID As DataGridViewTextBoxColumn
End Class
