<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class insertItem
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.itemIDField = New System.Windows.Forms.TextBox()
        Me.vendorSubTitle = New System.Windows.Forms.Label()
        Me.itemNameField = New System.Windows.Forms.TextBox()
        Me.itemGroupField = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.itemMinQty = New System.Windows.Forms.TextBox()
        Me.itemData = New System.Windows.Forms.DataGridView()
        Me.nameSearch = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.updateBtn = New System.Windows.Forms.Button()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.itemGroupBox = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.itemTitle = New System.Windows.Forms.Label()
        CType(Me.itemData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.itemGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(20, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 19)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Item Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(20, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 19)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Item ID"
        '
        'itemIDField
        '
        Me.itemIDField.ForeColor = System.Drawing.Color.DarkRed
        Me.itemIDField.Location = New System.Drawing.Point(23, 132)
        Me.itemIDField.Multiline = True
        Me.itemIDField.Name = "itemIDField"
        Me.itemIDField.Size = New System.Drawing.Size(275, 40)
        Me.itemIDField.TabIndex = 20
        '
        'vendorSubTitle
        '
        Me.vendorSubTitle.AutoSize = True
        Me.vendorSubTitle.Font = New System.Drawing.Font("Gadugi", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vendorSubTitle.Location = New System.Drawing.Point(18, 41)
        Me.vendorSubTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.vendorSubTitle.MaximumSize = New System.Drawing.Size(250, 0)
        Me.vendorSubTitle.Name = "vendorSubTitle"
        Me.vendorSubTitle.Size = New System.Drawing.Size(248, 50)
        Me.vendorSubTitle.TabIndex = 17
        Me.vendorSubTitle.Text = "Fill the below information to add an Item"
        '
        'itemNameField
        '
        Me.itemNameField.ForeColor = System.Drawing.Color.DarkRed
        Me.itemNameField.Location = New System.Drawing.Point(23, 197)
        Me.itemNameField.Multiline = True
        Me.itemNameField.Name = "itemNameField"
        Me.itemNameField.Size = New System.Drawing.Size(275, 40)
        Me.itemNameField.TabIndex = 23
        '
        'itemGroupField
        '
        Me.itemGroupField.FormattingEnabled = True
        Me.itemGroupField.Location = New System.Drawing.Point(23, 262)
        Me.itemGroupField.MaximumSize = New System.Drawing.Size(382, 0)
        Me.itemGroupField.Name = "itemGroupField"
        Me.itemGroupField.Size = New System.Drawing.Size(275, 32)
        Me.itemGroupField.TabIndex = 24
        Me.itemGroupField.Text = "Select Group Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.Label3.Location = New System.Drawing.Point(20, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 19)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Group Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.Label4.Location = New System.Drawing.Point(20, 297)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 19)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Minimum Quantity"
        '
        'itemMinQty
        '
        Me.itemMinQty.ForeColor = System.Drawing.Color.DarkRed
        Me.itemMinQty.Location = New System.Drawing.Point(23, 319)
        Me.itemMinQty.Multiline = True
        Me.itemMinQty.Name = "itemMinQty"
        Me.itemMinQty.Size = New System.Drawing.Size(275, 40)
        Me.itemMinQty.TabIndex = 27
        '
        'itemData
        '
        Me.itemData.BackgroundColor = System.Drawing.Color.White
        Me.itemData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.itemData.Location = New System.Drawing.Point(358, 134)
        Me.itemData.Name = "itemData"
        Me.itemData.ReadOnly = True
        Me.itemData.Size = New System.Drawing.Size(505, 477)
        Me.itemData.TabIndex = 29
        '
        'nameSearch
        '
        Me.nameSearch.Location = New System.Drawing.Point(358, 94)
        Me.nameSearch.Name = "nameSearch"
        Me.nameSearch.Size = New System.Drawing.Size(224, 34)
        Me.nameSearch.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.Label5.Location = New System.Drawing.Point(354, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 19)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Item Name"
        '
        'cancelBtn
        '
        Me.cancelBtn.BackColor = System.Drawing.Color.DarkRed
        Me.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.cancelBtn.Location = New System.Drawing.Point(24, 507)
        Me.cancelBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(275, 50)
        Me.cancelBtn.TabIndex = 37
        Me.cancelBtn.Text = "CANCEL"
        Me.cancelBtn.UseVisualStyleBackColor = False
        '
        'updateBtn
        '
        Me.updateBtn.BackColor = System.Drawing.Color.DarkRed
        Me.updateBtn.Enabled = False
        Me.updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.updateBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.updateBtn.Location = New System.Drawing.Point(23, 453)
        Me.updateBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.updateBtn.Name = "updateBtn"
        Me.updateBtn.Size = New System.Drawing.Size(275, 50)
        Me.updateBtn.TabIndex = 35
        Me.updateBtn.Text = "UPDATE"
        Me.updateBtn.UseVisualStyleBackColor = False
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(23, 399)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(275, 50)
        Me.submitBtn.TabIndex = 34
        Me.submitBtn.Text = "SUBMIT"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Gadugi", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(353, 41)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(243, 25)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Search For a certain Item"
        '
        'itemGroupBox
        '
        Me.itemGroupBox.Controls.Add(Me.Button1)
        Me.itemGroupBox.Controls.Add(Me.vendorSubTitle)
        Me.itemGroupBox.Controls.Add(Me.Label7)
        Me.itemGroupBox.Controls.Add(Me.itemIDField)
        Me.itemGroupBox.Controls.Add(Me.cancelBtn)
        Me.itemGroupBox.Controls.Add(Me.Label1)
        Me.itemGroupBox.Controls.Add(Me.Label2)
        Me.itemGroupBox.Controls.Add(Me.updateBtn)
        Me.itemGroupBox.Controls.Add(Me.itemNameField)
        Me.itemGroupBox.Controls.Add(Me.submitBtn)
        Me.itemGroupBox.Controls.Add(Me.itemGroupField)
        Me.itemGroupBox.Controls.Add(Me.Label5)
        Me.itemGroupBox.Controls.Add(Me.Label3)
        Me.itemGroupBox.Controls.Add(Me.nameSearch)
        Me.itemGroupBox.Controls.Add(Me.Label4)
        Me.itemGroupBox.Controls.Add(Me.itemData)
        Me.itemGroupBox.Controls.Add(Me.itemMinQty)
        Me.itemGroupBox.Location = New System.Drawing.Point(54, 113)
        Me.itemGroupBox.Name = "itemGroupBox"
        Me.itemGroupBox.Size = New System.Drawing.Size(895, 661)
        Me.itemGroupBox.TabIndex = 39
        Me.itemGroupBox.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(588, 92)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(275, 34)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'itemTitle
        '
        Me.itemTitle.AutoSize = True
        Me.itemTitle.Font = New System.Drawing.Font("Gadugi", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.itemTitle.ForeColor = System.Drawing.Color.DarkRed
        Me.itemTitle.Location = New System.Drawing.Point(46, 38)
        Me.itemTitle.Name = "itemTitle"
        Me.itemTitle.Size = New System.Drawing.Size(196, 45)
        Me.itemTitle.TabIndex = 39
        Me.itemTitle.Text = "Item Insert"
        '
        'insertItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1444, 882)
        Me.Controls.Add(Me.itemTitle)
        Me.Controls.Add(Me.itemGroupBox)
        Me.Font = New System.Drawing.Font("Gadugi", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "insertItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Item"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.itemData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.itemGroupBox.ResumeLayout(False)
        Me.itemGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents itemIDField As System.Windows.Forms.TextBox
    Friend WithEvents vendorSubTitle As System.Windows.Forms.Label
    Friend WithEvents itemNameField As System.Windows.Forms.TextBox
    Friend WithEvents itemGroupField As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents itemMinQty As System.Windows.Forms.TextBox
    Friend WithEvents itemData As System.Windows.Forms.DataGridView
    Friend WithEvents nameSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cancelBtn As System.Windows.Forms.Button
    Friend WithEvents updateBtn As System.Windows.Forms.Button
    Friend WithEvents submitBtn As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents itemGroupBox As GroupBox
    Friend WithEvents itemTitle As Label
    Friend WithEvents Button1 As Button
End Class
