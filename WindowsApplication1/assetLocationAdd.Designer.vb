<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class assetLocationAdd
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
        Me.locationTitle = New System.Windows.Forms.Label()
        Me.locationGroupBox = New System.Windows.Forms.GroupBox()
        Me.vendorSubTitle = New System.Windows.Forms.Label()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.assetLocationIDField = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.assetLocationNameField = New System.Windows.Forms.TextBox()
        Me.updateBtn = New System.Windows.Forms.Button()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.nameSearch = New System.Windows.Forms.TextBox()
        Me.locationData = New System.Windows.Forms.DataGridView()
        Me.locationGroupBox.SuspendLayout()
        CType(Me.locationData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'locationTitle
        '
        Me.locationTitle.AutoSize = True
        Me.locationTitle.Font = New System.Drawing.Font("Gadugi", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.locationTitle.ForeColor = System.Drawing.Color.DarkRed
        Me.locationTitle.Location = New System.Drawing.Point(23, 26)
        Me.locationTitle.Name = "locationTitle"
        Me.locationTitle.Size = New System.Drawing.Size(262, 45)
        Me.locationTitle.TabIndex = 57
        Me.locationTitle.Text = "Location Insert"
        '
        'locationGroupBox
        '
        Me.locationGroupBox.Controls.Add(Me.vendorSubTitle)
        Me.locationGroupBox.Controls.Add(Me.cancelBtn)
        Me.locationGroupBox.Controls.Add(Me.Button1)
        Me.locationGroupBox.Controls.Add(Me.assetLocationIDField)
        Me.locationGroupBox.Controls.Add(Me.Label5)
        Me.locationGroupBox.Controls.Add(Me.Label1)
        Me.locationGroupBox.Controls.Add(Me.Label2)
        Me.locationGroupBox.Controls.Add(Me.assetLocationNameField)
        Me.locationGroupBox.Controls.Add(Me.updateBtn)
        Me.locationGroupBox.Controls.Add(Me.submitBtn)
        Me.locationGroupBox.Controls.Add(Me.Label8)
        Me.locationGroupBox.Controls.Add(Me.nameSearch)
        Me.locationGroupBox.Controls.Add(Me.locationData)
        Me.locationGroupBox.Location = New System.Drawing.Point(31, 90)
        Me.locationGroupBox.Name = "locationGroupBox"
        Me.locationGroupBox.Size = New System.Drawing.Size(768, 712)
        Me.locationGroupBox.TabIndex = 56
        Me.locationGroupBox.TabStop = False
        '
        'vendorSubTitle
        '
        Me.vendorSubTitle.AutoSize = True
        Me.vendorSubTitle.Font = New System.Drawing.Font("Gadugi", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vendorSubTitle.Location = New System.Drawing.Point(17, 30)
        Me.vendorSubTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.vendorSubTitle.MaximumSize = New System.Drawing.Size(250, 0)
        Me.vendorSubTitle.Name = "vendorSubTitle"
        Me.vendorSubTitle.Size = New System.Drawing.Size(248, 50)
        Me.vendorSubTitle.TabIndex = 28
        Me.vendorSubTitle.Text = "Fill the below information to add a Location"
        '
        'cancelBtn
        '
        Me.cancelBtn.BackColor = System.Drawing.Color.DarkRed
        Me.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.cancelBtn.Location = New System.Drawing.Point(22, 434)
        Me.cancelBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(275, 50)
        Me.cancelBtn.TabIndex = 51
        Me.cancelBtn.Text = "CANCEL"
        Me.cancelBtn.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(382, 164)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(243, 34)
        Me.Button1.TabIndex = 53
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'assetLocationIDField
        '
        Me.assetLocationIDField.ForeColor = System.Drawing.Color.DarkRed
        Me.assetLocationIDField.Location = New System.Drawing.Point(22, 121)
        Me.assetLocationIDField.Multiline = True
        Me.assetLocationIDField.Name = "assetLocationIDField"
        Me.assetLocationIDField.Size = New System.Drawing.Size(275, 40)
        Me.assetLocationIDField.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Gadugi", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(377, 30)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(198, 50)
        Me.Label5.TabIndex = 52
        Me.Label5.Text = "Search for a certain location"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(19, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 19)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Location ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(19, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 19)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Location name"
        '
        'assetLocationNameField
        '
        Me.assetLocationNameField.ForeColor = System.Drawing.Color.DarkRed
        Me.assetLocationNameField.Location = New System.Drawing.Point(22, 186)
        Me.assetLocationNameField.Multiline = True
        Me.assetLocationNameField.Name = "assetLocationNameField"
        Me.assetLocationNameField.Size = New System.Drawing.Size(275, 40)
        Me.assetLocationNameField.TabIndex = 34
        '
        'updateBtn
        '
        Me.updateBtn.BackColor = System.Drawing.Color.DarkRed
        Me.updateBtn.Enabled = False
        Me.updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.updateBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.updateBtn.Location = New System.Drawing.Point(22, 380)
        Me.updateBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.updateBtn.Name = "updateBtn"
        Me.updateBtn.Size = New System.Drawing.Size(275, 50)
        Me.updateBtn.TabIndex = 49
        Me.updateBtn.Text = "UPDATE"
        Me.updateBtn.UseVisualStyleBackColor = False
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(22, 326)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(275, 50)
        Me.submitBtn.TabIndex = 48
        Me.submitBtn.Text = "SUBMIT"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.Label8.Location = New System.Drawing.Point(378, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 19)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Name"
        '
        'nameSearch
        '
        Me.nameSearch.Location = New System.Drawing.Point(382, 121)
        Me.nameSearch.Name = "nameSearch"
        Me.nameSearch.Size = New System.Drawing.Size(243, 34)
        Me.nameSearch.TabIndex = 42
        '
        'locationData
        '
        Me.locationData.BackgroundColor = System.Drawing.Color.White
        Me.locationData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.locationData.Location = New System.Drawing.Point(382, 221)
        Me.locationData.Name = "locationData"
        Me.locationData.ReadOnly = True
        Me.locationData.Size = New System.Drawing.Size(310, 413)
        Me.locationData.TabIndex = 41
        '
        'assetLocationAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1444, 831)
        Me.Controls.Add(Me.locationTitle)
        Me.Controls.Add(Me.locationGroupBox)
        Me.Font = New System.Drawing.Font("Gadugi", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "assetLocationAdd"
        Me.Text = "Add Asset Location"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.locationGroupBox.ResumeLayout(False)
        Me.locationGroupBox.PerformLayout()
        CType(Me.locationData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents locationTitle As Label
    Friend WithEvents locationGroupBox As GroupBox
    Friend WithEvents vendorSubTitle As Label
    Friend WithEvents cancelBtn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents assetLocationIDField As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents assetLocationNameField As TextBox
    Friend WithEvents updateBtn As Button
    Friend WithEvents submitBtn As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents nameSearch As TextBox
    Friend WithEvents locationData As DataGridView
End Class
