<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class assetTransfer
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
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.approvedByField = New System.Windows.Forms.TextBox()
        Me.recievedByField = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.transferInDropBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.transferOutDropBox = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.currancyLabel = New System.Windows.Forms.Label()
        Me.allItemsPrice = New System.Windows.Forms.Label()
        Me.transferTransaGrid = New System.Windows.Forms.DataGridView()
        Me.DelivaryNumber = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Locations = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TransferTo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TransferFrom = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.searchDelivary = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.searchDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.allItemsQty = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.transactionData = New System.Windows.Forms.DataGridView()
        Me.dateCreatedField = New System.Windows.Forms.DateTimePicker()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.addNewrecord = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.invID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inventoryNameField = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.qtyField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemUnitPriceField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.assetBarcode = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.acqDate = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.gridDeleteBtn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.genratedInventory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.transferTransaGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.transactionData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.statusLabel.Location = New System.Drawing.Point(330, 222)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(14, 17)
        Me.statusLabel.TabIndex = 260
        Me.statusLabel.Text = "-"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(261, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 259
        Me.Label4.Text = "Status : "
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DarkRed
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.SystemColors.Window
        Me.Button4.Location = New System.Drawing.Point(12, 211)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(210, 30)
        Me.Button4.TabIndex = 258
        Me.Button4.Text = "DELETE TRANSACTION"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'approvedByField
        '
        Me.approvedByField.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.approvedByField.Location = New System.Drawing.Point(566, 164)
        Me.approvedByField.Name = "approvedByField"
        Me.approvedByField.Size = New System.Drawing.Size(230, 25)
        Me.approvedByField.TabIndex = 257
        '
        'recievedByField
        '
        Me.recievedByField.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.recievedByField.Location = New System.Drawing.Point(566, 111)
        Me.recievedByField.Name = "recievedByField"
        Me.recievedByField.Size = New System.Drawing.Size(230, 25)
        Me.recievedByField.TabIndex = 256
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(560, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 255
        Me.Label3.Text = "Received By"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(560, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 17)
        Me.Label5.TabIndex = 254
        Me.Label5.Text = "Approved By"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(8, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 17)
        Me.Label8.TabIndex = 252
        Me.Label8.Text = "Transfer-IN"
        '
        'transferInDropBox
        '
        Me.transferInDropBox.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.transferInDropBox.ForeColor = System.Drawing.Color.DarkRed
        Me.transferInDropBox.FormattingEnabled = True
        Me.transferInDropBox.Location = New System.Drawing.Point(12, 106)
        Me.transferInDropBox.Name = "transferInDropBox"
        Me.transferInDropBox.Size = New System.Drawing.Size(210, 24)
        Me.transferInDropBox.TabIndex = 253
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(8, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 17)
        Me.Label2.TabIndex = 250
        Me.Label2.Text = "Transfer-OUT"
        '
        'transferOutDropBox
        '
        Me.transferOutDropBox.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.transferOutDropBox.ForeColor = System.Drawing.Color.DarkRed
        Me.transferOutDropBox.FormattingEnabled = True
        Me.transferOutDropBox.Location = New System.Drawing.Point(12, 161)
        Me.transferOutDropBox.Name = "transferOutDropBox"
        Me.transferOutDropBox.Size = New System.Drawing.Size(210, 24)
        Me.transferOutDropBox.TabIndex = 251
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.currancyLabel)
        Me.Panel2.Controls.Add(Me.allItemsPrice)
        Me.Panel2.Location = New System.Drawing.Point(517, 754)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(153, 27)
        Me.Panel2.TabIndex = 248
        '
        'currancyLabel
        '
        Me.currancyLabel.AutoSize = True
        Me.currancyLabel.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currancyLabel.Location = New System.Drawing.Point(3, 6)
        Me.currancyLabel.Name = "currancyLabel"
        Me.currancyLabel.Size = New System.Drawing.Size(69, 16)
        Me.currancyLabel.TabIndex = 173
        Me.currancyLabel.Text = "Total Price"
        '
        'allItemsPrice
        '
        Me.allItemsPrice.AutoSize = True
        Me.allItemsPrice.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.allItemsPrice.Location = New System.Drawing.Point(70, 6)
        Me.allItemsPrice.Name = "allItemsPrice"
        Me.allItemsPrice.Size = New System.Drawing.Size(15, 16)
        Me.allItemsPrice.TabIndex = 171
        Me.allItemsPrice.Text = "0"
        '
        'transferTransaGrid
        '
        Me.transferTransaGrid.BackgroundColor = System.Drawing.Color.White
        Me.transferTransaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.transferTransaGrid.GridColor = System.Drawing.SystemColors.GrayText
        Me.transferTransaGrid.Location = New System.Drawing.Point(834, 269)
        Me.transferTransaGrid.Name = "transferTransaGrid"
        Me.transferTransaGrid.ReadOnly = True
        Me.transferTransaGrid.Size = New System.Drawing.Size(443, 484)
        Me.transferTransaGrid.TabIndex = 243
        '
        'DelivaryNumber
        '
        Me.DelivaryNumber.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.DelivaryNumber.Location = New System.Drawing.Point(265, 111)
        Me.DelivaryNumber.Name = "DelivaryNumber"
        Me.DelivaryNumber.Size = New System.Drawing.Size(273, 25)
        Me.DelivaryNumber.TabIndex = 242
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Gadugi", 16.0!)
        Me.Label14.Location = New System.Drawing.Point(7, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(207, 26)
        Me.Label14.TabIndex = 246
        Me.Label14.Text = "Transfer Transaction"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(831, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.TabIndex = 245
        Me.Label6.Text = "Transactions"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Locations)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TransferTo)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TransferFrom)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.searchDelivary)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.searchDate)
        Me.GroupBox1.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(834, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(443, 209)
        Me.GroupBox1.TabIndex = 244
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transaction Search"
        '
        'Locations
        '
        Me.Locations.AutoSize = True
        Me.Locations.Location = New System.Drawing.Point(6, 85)
        Me.Locations.Name = "Locations"
        Me.Locations.Size = New System.Drawing.Size(66, 17)
        Me.Locations.TabIndex = 194
        Me.Locations.Text = "Locations"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(152, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 19)
        Me.Label7.TabIndex = 193
        Me.Label7.Text = "To"
        '
        'TransferTo
        '
        Me.TransferTo.Location = New System.Drawing.Point(156, 139)
        Me.TransferTo.Name = "TransferTo"
        Me.TransferTo.Size = New System.Drawing.Size(162, 25)
        Me.TransferTo.TabIndex = 192
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 19)
        Me.Label10.TabIndex = 191
        Me.Label10.Text = "From"
        '
        'TransferFrom
        '
        Me.TransferFrom.Location = New System.Drawing.Point(10, 139)
        Me.TransferFrom.Name = "TransferFrom"
        Me.TransferFrom.Size = New System.Drawing.Size(136, 25)
        Me.TransferFrom.TabIndex = 190
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkRed
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.SystemColors.Window
        Me.Button3.Location = New System.Drawing.Point(82, 174)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 29)
        Me.Button3.TabIndex = 189
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(267, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(128, 19)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "Delivary Number"
        '
        'searchDelivary
        '
        Me.searchDelivary.Location = New System.Drawing.Point(271, 46)
        Me.searchDelivary.Name = "searchDelivary"
        Me.searchDelivary.Size = New System.Drawing.Size(162, 25)
        Me.searchDelivary.TabIndex = 187
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkRed
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.Window
        Me.Button2.Location = New System.Drawing.Point(9, 174)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 29)
        Me.Button2.TabIndex = 181
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 19)
        Me.Label9.TabIndex = 183
        Me.Label9.Text = "Date"
        '
        'searchDate
        '
        Me.searchDate.CalendarForeColor = System.Drawing.Color.DarkRed
        Me.searchDate.CalendarMonthBackground = System.Drawing.Color.DarkRed
        Me.searchDate.CalendarTitleBackColor = System.Drawing.Color.DarkRed
        Me.searchDate.CalendarTitleForeColor = System.Drawing.Color.DarkRed
        Me.searchDate.CalendarTrailingForeColor = System.Drawing.Color.DarkRed
        Me.searchDate.Location = New System.Drawing.Point(6, 46)
        Me.searchDate.Name = "searchDate"
        Me.searchDate.Size = New System.Drawing.Size(255, 25)
        Me.searchDate.TabIndex = 184
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.allItemsQty)
        Me.Panel1.Location = New System.Drawing.Point(357, 754)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(154, 27)
        Me.Panel1.TabIndex = 247
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Total Quantity"
        '
        'allItemsQty
        '
        Me.allItemsQty.AutoSize = True
        Me.allItemsQty.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.allItemsQty.Location = New System.Drawing.Point(91, 5)
        Me.allItemsQty.Name = "allItemsQty"
        Me.allItemsQty.Size = New System.Drawing.Size(15, 16)
        Me.allItemsQty.TabIndex = 172
        Me.allItemsQty.Text = "0"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(723, 211)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(73, 30)
        Me.Button1.TabIndex = 249
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'transactionData
        '
        Me.transactionData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.transactionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.transactionData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.addNewrecord, Me.invID, Me.inventoryNameField, Me.qtyField, Me.itemUnitPriceField, Me.itemTotalPrice, Me.assetBarcode, Me.acqDate, Me.gridDeleteBtn, Me.genratedInventory})
        Me.transactionData.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.transactionData.Location = New System.Drawing.Point(12, 269)
        Me.transactionData.Name = "transactionData"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.transactionData.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.transactionData.Size = New System.Drawing.Size(816, 485)
        Me.transactionData.TabIndex = 240
        '
        'dateCreatedField
        '
        Me.dateCreatedField.CalendarForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarMonthBackground = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTitleBackColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTitleForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTrailingForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.dateCreatedField.Location = New System.Drawing.Point(265, 166)
        Me.dateCreatedField.Name = "dateCreatedField"
        Me.dateCreatedField.Size = New System.Drawing.Size(273, 25)
        Me.dateCreatedField.TabIndex = 239
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label43.Location = New System.Drawing.Point(261, 144)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(37, 17)
        Me.Label43.TabIndex = 237
        Me.Label43.Text = "Date"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label41.Location = New System.Drawing.Point(261, 87)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(111, 17)
        Me.Label41.TabIndex = 236
        Me.Label41.Text = "Delivary Number"
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(566, 211)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(151, 30)
        Me.submitBtn.TabIndex = 241
        Me.submitBtn.Text = "SAVE TRANSACTION"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'addNewrecord
        '
        Me.addNewrecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addNewrecord.HeaderText = ""
        Me.addNewrecord.Name = "addNewrecord"
        Me.addNewrecord.Text = ""
        Me.addNewrecord.UseColumnTextForButtonValue = True
        Me.addNewrecord.Width = 25
        '
        'invID
        '
        Me.invID.HeaderText = "Asset ID"
        Me.invID.Name = "invID"
        '
        'inventoryNameField
        '
        Me.inventoryNameField.HeaderText = "Asset Name"
        Me.inventoryNameField.Name = "inventoryNameField"
        '
        'qtyField
        '
        Me.qtyField.HeaderText = "Quantity"
        Me.qtyField.Name = "qtyField"
        Me.qtyField.Width = 80
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
        'assetBarcode
        '
        Me.assetBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.assetBarcode.HeaderText = "Barcodes"
        Me.assetBarcode.Name = "assetBarcode"
        Me.assetBarcode.ReadOnly = True
        Me.assetBarcode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.assetBarcode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.assetBarcode.Width = 140
        '
        'acqDate
        '
        Me.acqDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.acqDate.HeaderText = "Acquisation Date"
        Me.acqDate.Name = "acqDate"
        Me.acqDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.acqDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        Me.genratedInventory.HeaderText = "Asset ID"
        Me.genratedInventory.Name = "genratedInventory"
        Me.genratedInventory.ReadOnly = True
        Me.genratedInventory.Visible = False
        Me.genratedInventory.Width = 120
        '
        'assetTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1311, 864)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.approvedByField)
        Me.Controls.Add(Me.recievedByField)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.transferInDropBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.transferOutDropBox)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.transferTransaGrid)
        Me.Controls.Add(Me.DelivaryNumber)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.transactionData)
        Me.Controls.Add(Me.dateCreatedField)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.submitBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "assetTransfer"
        Me.Text = "assetTransfer"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.transferTransaGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.transactionData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents statusLabel As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents approvedByField As TextBox
    Friend WithEvents recievedByField As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents transferInDropBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents transferOutDropBox As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents currancyLabel As Label
    Friend WithEvents allItemsPrice As Label
    Friend WithEvents transferTransaGrid As DataGridView
    Friend WithEvents DelivaryNumber As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Locations As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TransferTo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TransferFrom As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents searchDelivary As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents searchDate As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents allItemsQty As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents transactionData As DataGridView
    Friend WithEvents dateCreatedField As DateTimePicker
    Friend WithEvents Label43 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents submitBtn As Button
    Friend WithEvents addNewrecord As DataGridViewButtonColumn
    Friend WithEvents invID As DataGridViewTextBoxColumn
    Friend WithEvents inventoryNameField As DataGridViewComboBoxColumn
    Friend WithEvents qtyField As DataGridViewTextBoxColumn
    Friend WithEvents itemUnitPriceField As DataGridViewTextBoxColumn
    Friend WithEvents itemTotalPrice As DataGridViewTextBoxColumn
    Friend WithEvents assetBarcode As DataGridViewButtonColumn
    Friend WithEvents acqDate As DataGridViewButtonColumn
    Friend WithEvents gridDeleteBtn As DataGridViewButtonColumn
    Friend WithEvents genratedInventory As DataGridViewTextBoxColumn
End Class
