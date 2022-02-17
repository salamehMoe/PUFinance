<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class purchaseTransactions
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.deleteBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.currancyLabel = New System.Windows.Forms.Label()
        Me.allItemsPrice = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.allItemsQty = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.completeCheckBox = New System.Windows.Forms.CheckBox()
        Me.InCompleteCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.searchLocation = New System.Windows.Forms.TextBox()
        Me.searchInvoice = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.searchVendor = New System.Windows.Forms.TextBox()
        Me.searchDate = New System.Windows.Forms.DateTimePicker()
        Me.purchaseTransaGrid = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.invoiceField = New System.Windows.Forms.TextBox()
        Me.locationDropBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.vendorNameField = New System.Windows.Forms.ComboBox()
        Me.vendorIDLabel = New System.Windows.Forms.Label()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.currencyField = New System.Windows.Forms.ComboBox()
        Me.transactionData = New System.Windows.Forms.DataGridView()
        Me.dateCreatedField = New System.Windows.Forms.DateTimePicker()
        Me.referanceLabel = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.gpCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.addNewrecord = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.InvID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inventoryNameField = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.qtyField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemUnitPriceField = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemTotalPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridDeleteBtn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.genratedInventory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.impItem = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.purchaseTransaGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.transactionData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'deleteBtn
        '
        Me.deleteBtn.BackColor = System.Drawing.Color.DarkRed
        Me.deleteBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.deleteBtn.Location = New System.Drawing.Point(11, 163)
        Me.deleteBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.deleteBtn.Name = "deleteBtn"
        Me.deleteBtn.Size = New System.Drawing.Size(231, 30)
        Me.deleteBtn.TabIndex = 197
        Me.deleteBtn.Text = "DELETE TRANSACTION"
        Me.deleteBtn.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(698, 162)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 30)
        Me.Button1.TabIndex = 196
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.currancyLabel)
        Me.Panel2.Controls.Add(Me.allItemsPrice)
        Me.Panel2.Location = New System.Drawing.Point(556, 789)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(169, 27)
        Me.Panel2.TabIndex = 195
        '
        'currancyLabel
        '
        Me.currancyLabel.AutoSize = True
        Me.currancyLabel.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.currancyLabel.Location = New System.Drawing.Point(4, 6)
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
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.allItemsQty)
        Me.Panel1.Location = New System.Drawing.Point(316, 789)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(177, 27)
        Me.Panel1.TabIndex = 194
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(522, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 19)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Vendor ID"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Gadugi", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(236, 28)
        Me.Label14.TabIndex = 193
        Me.Label14.Text = "Purchase Transaction"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkRed
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.SystemColors.Window
        Me.Button3.Location = New System.Drawing.Point(397, 138)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 29)
        Me.Button3.TabIndex = 189
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'completeCheckBox
        '
        Me.completeCheckBox.AutoSize = True
        Me.completeCheckBox.Location = New System.Drawing.Point(10, 137)
        Me.completeCheckBox.Name = "completeCheckBox"
        Me.completeCheckBox.Size = New System.Drawing.Size(95, 23)
        Me.completeCheckBox.TabIndex = 192
        Me.completeCheckBox.Text = "Complete"
        Me.completeCheckBox.UseVisualStyleBackColor = True
        '
        'InCompleteCheckBox
        '
        Me.InCompleteCheckBox.AutoSize = True
        Me.InCompleteCheckBox.Location = New System.Drawing.Point(120, 137)
        Me.InCompleteCheckBox.Name = "InCompleteCheckBox"
        Me.InCompleteCheckBox.Size = New System.Drawing.Size(108, 23)
        Me.InCompleteCheckBox.TabIndex = 193
        Me.InCompleteCheckBox.Text = "InComplete"
        Me.InCompleteCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.InCompleteCheckBox)
        Me.GroupBox1.Controls.Add(Me.completeCheckBox)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.searchLocation)
        Me.GroupBox1.Controls.Add(Me.searchInvoice)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.searchVendor)
        Me.GroupBox1.Controls.Add(Me.searchDate)
        Me.GroupBox1.Location = New System.Drawing.Point(785, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(533, 178)
        Me.GroupBox1.TabIndex = 189
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transaction Search"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(323, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 19)
        Me.Label7.TabIndex = 182
        Me.Label7.Text = "Location"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(152, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 19)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "Invoice Number"
        '
        'searchLocation
        '
        Me.searchLocation.Location = New System.Drawing.Point(327, 101)
        Me.searchLocation.Name = "searchLocation"
        Me.searchLocation.Size = New System.Drawing.Size(136, 29)
        Me.searchLocation.TabIndex = 180
        '
        'searchInvoice
        '
        Me.searchInvoice.Location = New System.Drawing.Point(156, 102)
        Me.searchInvoice.Name = "searchInvoice"
        Me.searchInvoice.Size = New System.Drawing.Size(162, 29)
        Me.searchInvoice.TabIndex = 187
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkRed
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.Window
        Me.Button2.Location = New System.Drawing.Point(324, 138)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 29)
        Me.Button2.TabIndex = 181
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 19)
        Me.Label12.TabIndex = 186
        Me.Label12.Text = "Vendor"
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
        'searchVendor
        '
        Me.searchVendor.Location = New System.Drawing.Point(10, 102)
        Me.searchVendor.Name = "searchVendor"
        Me.searchVendor.Size = New System.Drawing.Size(136, 29)
        Me.searchVendor.TabIndex = 185
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
        Me.searchDate.Size = New System.Drawing.Size(312, 29)
        Me.searchDate.TabIndex = 184
        '
        'purchaseTransaGrid
        '
        Me.purchaseTransaGrid.BackgroundColor = System.Drawing.Color.White
        Me.purchaseTransaGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.purchaseTransaGrid.GridColor = System.Drawing.SystemColors.GrayText
        Me.purchaseTransaGrid.Location = New System.Drawing.Point(785, 216)
        Me.purchaseTransaGrid.Name = "purchaseTransaGrid"
        Me.purchaseTransaGrid.ReadOnly = True
        Me.purchaseTransaGrid.Size = New System.Drawing.Size(530, 572)
        Me.purchaseTransaGrid.TabIndex = 177
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(522, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Currancy"
        '
        'invoiceField
        '
        Me.invoiceField.Location = New System.Drawing.Point(264, 58)
        Me.invoiceField.Name = "invoiceField"
        Me.invoiceField.Size = New System.Drawing.Size(249, 29)
        Me.invoiceField.TabIndex = 174
        '
        'locationDropBox
        '
        Me.locationDropBox.ForeColor = System.Drawing.Color.DarkRed
        Me.locationDropBox.FormattingEnabled = True
        Me.locationDropBox.Location = New System.Drawing.Point(264, 109)
        Me.locationDropBox.Name = "locationDropBox"
        Me.locationDropBox.Size = New System.Drawing.Size(249, 27)
        Me.locationDropBox.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(522, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 19)
        Me.Label5.TabIndex = 111
        Me.Label5.Text = "Vendor Name"
        '
        'vendorNameField
        '
        Me.vendorNameField.ForeColor = System.Drawing.Color.DarkRed
        Me.vendorNameField.FormattingEnabled = True
        Me.vendorNameField.Location = New System.Drawing.Point(526, 74)
        Me.vendorNameField.Name = "vendorNameField"
        Me.vendorNameField.Size = New System.Drawing.Size(227, 27)
        Me.vendorNameField.TabIndex = 112
        '
        'vendorIDLabel
        '
        Me.vendorIDLabel.AutoSize = True
        Me.vendorIDLabel.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vendorIDLabel.Location = New System.Drawing.Point(607, 33)
        Me.vendorIDLabel.Name = "vendorIDLabel"
        Me.vendorIDLabel.Size = New System.Drawing.Size(15, 19)
        Me.vendorIDLabel.TabIndex = 110
        Me.vendorIDLabel.Text = "-"
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(526, 162)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(166, 30)
        Me.submitBtn.TabIndex = 96
        Me.submitBtn.Text = "SAVE TRANSACTION"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'currencyField
        '
        Me.currencyField.ForeColor = System.Drawing.Color.DarkRed
        Me.currencyField.FormattingEnabled = True
        Me.currencyField.Items.AddRange(New Object() {"US Dollars", "L.L"})
        Me.currencyField.Location = New System.Drawing.Point(600, 105)
        Me.currencyField.Name = "currencyField"
        Me.currencyField.Size = New System.Drawing.Size(153, 27)
        Me.currencyField.TabIndex = 93
        Me.currencyField.Text = "US Dollars"
        '
        'transactionData
        '
        Me.transactionData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.transactionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.transactionData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.addNewrecord, Me.InvID, Me.inventoryNameField, Me.qtyField, Me.itemUnitPriceField, Me.itemTotalPrice, Me.gridDeleteBtn, Me.genratedInventory, Me.impItem})
        Me.transactionData.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.transactionData.Location = New System.Drawing.Point(7, 216)
        Me.transactionData.Name = "transactionData"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        Me.transactionData.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.transactionData.Size = New System.Drawing.Size(769, 573)
        Me.transactionData.TabIndex = 60
        '
        'dateCreatedField
        '
        Me.dateCreatedField.CalendarForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarMonthBackground = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTitleBackColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTitleForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.CalendarTrailingForeColor = System.Drawing.Color.DarkRed
        Me.dateCreatedField.Location = New System.Drawing.Point(264, 161)
        Me.dateCreatedField.Name = "dateCreatedField"
        Me.dateCreatedField.Size = New System.Drawing.Size(249, 29)
        Me.dateCreatedField.TabIndex = 59
        '
        'referanceLabel
        '
        Me.referanceLabel.AutoSize = True
        Me.referanceLabel.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.referanceLabel.Location = New System.Drawing.Point(143, 91)
        Me.referanceLabel.Name = "referanceLabel"
        Me.referanceLabel.Size = New System.Drawing.Size(15, 19)
        Me.referanceLabel.TabIndex = 54
        Me.referanceLabel.Text = "-"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(260, 139)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(41, 19)
        Me.Label43.TabIndex = 51
        Me.Label43.Text = "Date"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(260, 34)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(120, 19)
        Me.Label41.TabIndex = 49
        Me.Label41.Text = "Invoice Number"
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = True
        Me.statusLabel.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusLabel.Location = New System.Drawing.Point(67, 117)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(13, 17)
        Me.statusLabel.TabIndex = 48
        Me.statusLabel.Text = "-"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(7, 116)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(63, 19)
        Me.Label38.TabIndex = 47
        Me.Label38.Text = "Status : "
        '
        'gpCheckBox
        '
        Me.gpCheckBox.AutoSize = True
        Me.gpCheckBox.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCheckBox.Location = New System.Drawing.Point(526, 134)
        Me.gpCheckBox.Name = "gpCheckBox"
        Me.gpCheckBox.Size = New System.Drawing.Size(123, 23)
        Me.gpCheckBox.TabIndex = 46
        Me.gpCheckBox.Text = "Entered to GP"
        Me.gpCheckBox.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(260, 87)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(68, 19)
        Me.Label37.TabIndex = 45
        Me.Label37.Text = "Location"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(7, 91)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(140, 19)
        Me.Label36.TabIndex = 44
        Me.Label36.Text = "Referance Number"
        '
        'addNewrecord
        '
        Me.addNewrecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addNewrecord.HeaderText = "Add Item"
        Me.addNewrecord.Name = "addNewrecord"
        Me.addNewrecord.Text = ""
        Me.addNewrecord.UseColumnTextForButtonValue = True
        Me.addNewrecord.Visible = False
        Me.addNewrecord.Width = 80
        '
        'InvID
        '
        Me.InvID.HeaderText = "Inventory ID"
        Me.InvID.Name = "InvID"
        Me.InvID.ReadOnly = True
        Me.InvID.Width = 120
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
        Me.qtyField.Width = 80
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
        'impItem
        '
        Me.impItem.HeaderText = "Imported"
        Me.impItem.Name = "impItem"
        Me.impItem.Width = 80
        '
        'purchaseTransactions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1392, 836)
        Me.Controls.Add(Me.deleteBtn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.purchaseTransaGrid)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.invoiceField)
        Me.Controls.Add(Me.vendorNameField)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.vendorIDLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.submitBtn)
        Me.Controls.Add(Me.currencyField)
        Me.Controls.Add(Me.transactionData)
        Me.Controls.Add(Me.dateCreatedField)
        Me.Controls.Add(Me.locationDropBox)
        Me.Controls.Add(Me.referanceLabel)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.gpCheckBox)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "purchaseTransactions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Transaction"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.purchaseTransaGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.transactionData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents deleteBtn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents currancyLabel As Label
    Friend WithEvents allItemsPrice As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents allItemsQty As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents completeCheckBox As CheckBox
    Friend WithEvents InCompleteCheckBox As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents searchLocation As TextBox
    Friend WithEvents searchInvoice As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents searchVendor As TextBox
    Friend WithEvents searchDate As DateTimePicker
    Friend WithEvents purchaseTransaGrid As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents invoiceField As TextBox
    Friend WithEvents locationDropBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents vendorNameField As ComboBox
    Friend WithEvents vendorIDLabel As Label
    Friend WithEvents submitBtn As Button
    Friend WithEvents currencyField As ComboBox
    Friend WithEvents transactionData As DataGridView
    Friend WithEvents dateCreatedField As DateTimePicker
    Friend WithEvents referanceLabel As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents statusLabel As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents gpCheckBox As CheckBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents addNewrecord As DataGridViewButtonColumn
    Friend WithEvents InvID As DataGridViewTextBoxColumn
    Friend WithEvents inventoryNameField As DataGridViewComboBoxColumn
    Friend WithEvents qtyField As DataGridViewTextBoxColumn
    Friend WithEvents itemUnitPriceField As DataGridViewTextBoxColumn
    Friend WithEvents itemTotalPrice As DataGridViewTextBoxColumn
    Friend WithEvents gridDeleteBtn As DataGridViewButtonColumn
    Friend WithEvents genratedInventory As DataGridViewTextBoxColumn
    Friend WithEvents impItem As DataGridViewCheckBoxColumn
End Class
