<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class stockTransaction
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
        Me.currancyLabel = New System.Windows.Forms.Label()
        Me.stockTransaGrid = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.searchDate = New System.Windows.Forms.DateTimePicker()
        Me.searchLocation = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.allItemsQty = New System.Windows.Forms.Label()
        Me.deleteBtn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.allItemsPrice = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.transactionData = New System.Windows.Forms.DataGridView()
        Me.dateCreatedField = New System.Windows.Forms.DateTimePicker()
        Me.referanceLabel = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.locationDropBox = New System.Windows.Forms.ComboBox()
        Me.stockOut = New System.Windows.Forms.RadioButton()
        Me.stockIn = New System.Windows.Forms.RadioButton()
        Me.addNewrecord = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.invID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inventoryNameField = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.qtyField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemUnitPriceField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridDeleteBtn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.genratedInventory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.stockTransaGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.transactionData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'stockTransaGrid
        '
        Me.stockTransaGrid.BackgroundColor = System.Drawing.Color.White
        Me.stockTransaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.stockTransaGrid.GridColor = System.Drawing.SystemColors.GrayText
        Me.stockTransaGrid.Location = New System.Drawing.Point(878, 230)
        Me.stockTransaGrid.Name = "stockTransaGrid"
        Me.stockTransaGrid.ReadOnly = True
        Me.stockTransaGrid.Size = New System.Drawing.Size(420, 530)
        Me.stockTransaGrid.TabIndex = 217
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 19)
        Me.Label7.TabIndex = 182
        Me.Label7.Text = "Location"
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
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkRed
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.SystemColors.Window
        Me.Button3.Location = New System.Drawing.Point(79, 144)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 29)
        Me.Button3.TabIndex = 189
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Gadugi", 16.0!)
        Me.Label14.Location = New System.Drawing.Point(29, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(181, 26)
        Me.Label14.TabIndex = 219
        Me.Label14.Text = "Stock Transaction"
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
        Me.searchDate.Size = New System.Drawing.Size(312, 25)
        Me.searchDate.TabIndex = 184
        '
        'searchLocation
        '
        Me.searchLocation.Location = New System.Drawing.Point(6, 106)
        Me.searchLocation.Name = "searchLocation"
        Me.searchLocation.Size = New System.Drawing.Size(312, 25)
        Me.searchLocation.TabIndex = 180
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkRed
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.Window
        Me.Button2.Location = New System.Drawing.Point(6, 144)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 29)
        Me.Button2.TabIndex = 181
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = False
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
        'deleteBtn
        '
        Me.deleteBtn.BackColor = System.Drawing.Color.DarkRed
        Me.deleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.deleteBtn.Location = New System.Drawing.Point(34, 176)
        Me.deleteBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.Size = New System.Drawing.Size(231, 30)
        Me.deleteBtn.TabIndex = 223
        Me.deleteBtn.Text = "DELETE TRANSACTION"
        Me.deleteBtn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.currancyLabel)
        Me.Panel2.Controls.Add(Me.allItemsPrice)
        Me.Panel2.Location = New System.Drawing.Point(703, 758)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(169, 27)
        Me.Panel2.TabIndex = 221
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.allItemsQty)
        Me.Panel1.Location = New System.Drawing.Point(400, 758)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(177, 27)
        Me.Panel1.TabIndex = 220
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.searchLocation)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.searchDate)
        Me.GroupBox1.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(878, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 178)
        Me.GroupBox1.TabIndex = 218
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transaction Search"
        '
        'transactionData
        '
        Me.transactionData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.transactionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.transactionData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.addNewrecord, Me.invID, Me.inventoryNameField, Me.qtyField, Me.itemUnitPriceField, Me.itemTotalPrice, Me.gridDeleteBtn, Me.genratedInventory})
        Me.transactionData.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.transactionData.Location = New System.Drawing.Point(34, 229)
        Me.transactionData.Name = "transactionData"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.transactionData.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.transactionData.Size = New System.Drawing.Size(838, 531)
        Me.transactionData.TabIndex = 208
        '
        'dateCreatedField
        '
        Me.dateCreatedField.CalendarForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarMonthBackground = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTitleBackColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTitleForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTrailingForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.dateCreatedField.Location = New System.Drawing.Point(287, 174)
        Me.dateCreatedField.Name = "dateCreatedField"
        Me.dateCreatedField.Size = New System.Drawing.Size(273, 25)
        Me.dateCreatedField.TabIndex = 207
        '
        'referanceLabel
        '
        Me.referanceLabel.AutoSize = True
        Me.referanceLabel.Font = New System.Drawing.Font("Gadugi", 10.0!, System.Drawing.FontStyle.Bold)
        Me.referanceLabel.Location = New System.Drawing.Point(166, 104)
        Me.referanceLabel.Name = "referanceLabel"
        Me.referanceLabel.Size = New System.Drawing.Size(14, 18)
        Me.referanceLabel.TabIndex = 205
        Me.referanceLabel.Text = "-"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label43.Location = New System.Drawing.Point(283, 152)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(37, 17)
        Me.Label43.TabIndex = 204
        Me.Label43.Text = "Date"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label37.Location = New System.Drawing.Point(283, 100)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(60, 17)
        Me.Label37.TabIndex = 199
        Me.Label37.Text = "Location"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label36.Location = New System.Drawing.Point(30, 104)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(121, 17)
        Me.Label36.TabIndex = 198
        Me.Label36.Text = "Referance Number"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(758, 176)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 30)
        Me.Button1.TabIndex = 222
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(586, 176)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(166, 30)
        Me.submitBtn.TabIndex = 210
        Me.submitBtn.Text = "SAVE TRANSACTION"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'locationDropBox
        '
        Me.locationDropBox.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.locationDropBox.ForeColor = System.Drawing.Color.DarkRed
        Me.locationDropBox.FormattingEnabled = True
        Me.locationDropBox.Location = New System.Drawing.Point(287, 122)
        Me.locationDropBox.Name = "locationDropBox"
        Me.locationDropBox.Size = New System.Drawing.Size(273, 24)
        Me.locationDropBox.TabIndex = 206
        '
        'stockOut
        '
        Me.stockOut.AutoSize = True
        Me.stockOut.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.stockOut.Location = New System.Drawing.Point(34, 150)
        Me.stockOut.Name = "stockOut"
        Me.stockOut.Size = New System.Drawing.Size(89, 21)
        Me.stockOut.TabIndex = 224
        Me.stockOut.Text = "Stock-Out"
        Me.stockOut.UseVisualStyleBackColor = True
        '
        'stockIn
        '
        Me.stockIn.AutoSize = True
        Me.stockIn.Checked = True
        Me.stockIn.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.stockIn.Location = New System.Drawing.Point(34, 126)
        Me.stockIn.Name = "stockIn"
        Me.stockIn.Size = New System.Drawing.Size(77, 21)
        Me.stockIn.TabIndex = 225
        Me.stockIn.TabStop = True
        Me.stockIn.Text = "Stock-In"
        Me.stockIn.UseVisualStyleBackColor = True
        '
        'addNewrecord
        '
        Me.addNewrecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addNewrecord.HeaderText = "Add Item"
        Me.addNewrecord.Name = "addNewrecord"
        Me.addNewrecord.Text = ""
        Me.addNewrecord.UseColumnTextForButtonValue = True
        Me.addNewrecord.Width = 80
        '
        'invID
        '
        Me.invID.HeaderText = "Inventory ID"
        Me.invID.Name = "invID"
        Me.invID.Width = 120
        '
        'inventoryNameField
        '
        Me.inventoryNameField.HeaderText = "Inventory Name"
        Me.inventoryNameField.Name = "inventoryNameField"
        Me.inventoryNameField.Width = 150
        '
        'qtyField
        '
        Me.qtyField.HeaderText = "Quantity"
        Me.qtyField.Name = "qtyField"
        Me.qtyField.Width = 150
        '
        'itemUnitPriceField
        '
        Me.itemUnitPriceField.HeaderText = "Unit Price"
        Me.itemUnitPriceField.Name = "itemUnitPriceField"
        Me.itemUnitPriceField.Width = 150
        '
        'itemTotalPrice
        '
        Me.itemTotalPrice.HeaderText = "Total price"
        Me.itemTotalPrice.Name = "itemTotalPrice"
        Me.itemTotalPrice.ReadOnly = True
        Me.itemTotalPrice.Width = 120
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
        Me.genratedInventory.Visible = False
        Me.genratedInventory.Width = 120
        '
        'stockTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1436, 874)
        Me.Controls.Add(Me.stockIn)
        Me.Controls.Add(Me.stockOut)
        Me.Controls.Add(Me.stockTransaGrid)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.deleteBtn)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.transactionData)
        Me.Controls.Add(Me.dateCreatedField)
        Me.Controls.Add(Me.referanceLabel)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.submitBtn)
        Me.Controls.Add(Me.locationDropBox)
        Me.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "stockTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Transactions"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.stockTransaGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.transactionData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents currancyLabel As Label
    Friend WithEvents stockTransaGrid As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents searchDate As DateTimePicker
    Friend WithEvents searchLocation As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents allItemsQty As Label
    Friend WithEvents deleteBtn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents allItemsPrice As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents transactionData As DataGridView
    Friend WithEvents dateCreatedField As DateTimePicker
    Friend WithEvents referanceLabel As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents submitBtn As Button
    Friend WithEvents locationDropBox As ComboBox
    Friend WithEvents stockOut As RadioButton
    Friend WithEvents stockIn As RadioButton
    Friend WithEvents addNewrecord As DataGridViewButtonColumn
    Friend WithEvents invID As DataGridViewTextBoxColumn
    Friend WithEvents inventoryNameField As DataGridViewComboBoxColumn
    Friend WithEvents qtyField As DataGridViewTextBoxColumn
    Friend WithEvents itemUnitPriceField As DataGridViewTextBoxColumn
    Friend WithEvents itemTotalPrice As DataGridViewTextBoxColumn
    Friend WithEvents gridDeleteBtn As DataGridViewButtonColumn
    Friend WithEvents genratedInventory As DataGridViewTextBoxColumn
End Class
