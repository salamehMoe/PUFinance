<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class insertVendor
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
        Me.vendorSubTitle = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.vendorIdTextField = New System.Windows.Forms.TextBox()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.vendorNameTextField = New System.Windows.Forms.TextBox()
        Me.vendorData = New System.Windows.Forms.DataGridView()
        Me.vendorSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.updateBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.vendorGroupBox = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.vendorTitle = New System.Windows.Forms.Label()
        CType(Me.vendorData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.vendorGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'vendorSubTitle
        '
        Me.vendorSubTitle.AutoSize = True
        Me.vendorSubTitle.Font = New System.Drawing.Font("Gadugi", 13.0!)
        Me.vendorSubTitle.Location = New System.Drawing.Point(9, 30)
        Me.vendorSubTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.vendorSubTitle.MaximumSize = New System.Drawing.Size(250, 0)
        Me.vendorSubTitle.Name = "vendorSubTitle"
        Me.vendorSubTitle.Size = New System.Drawing.Size(239, 42)
        Me.vendorSubTitle.TabIndex = 0
        Me.vendorSubTitle.Text = "Fill the below information to add a vendor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(14, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 17)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Vendor Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Vendor ID"
        '
        'vendorIdTextField
        '
        Me.vendorIdTextField.ForeColor = System.Drawing.Color.DarkRed
        Me.vendorIdTextField.Location = New System.Drawing.Point(14, 100)
        Me.vendorIdTextField.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.vendorIdTextField.Multiline = True
        Me.vendorIdTextField.Name = "vendorIdTextField"
        Me.vendorIdTextField.Size = New System.Drawing.Size(276, 40)
        Me.vendorIdTextField.TabIndex = 11
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(15, 274)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(275, 50)
        Me.submitBtn.TabIndex = 10
        Me.submitBtn.Text = "SUBMIT"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'vendorNameTextField
        '
        Me.vendorNameTextField.ForeColor = System.Drawing.Color.DarkRed
        Me.vendorNameTextField.Location = New System.Drawing.Point(14, 165)
        Me.vendorNameTextField.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.vendorNameTextField.Multiline = True
        Me.vendorNameTextField.Name = "vendorNameTextField"
        Me.vendorNameTextField.Size = New System.Drawing.Size(276, 40)
        Me.vendorNameTextField.TabIndex = 16
        '
        'vendorData
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Gadugi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vendorData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.vendorData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.vendorData.BackgroundColor = System.Drawing.Color.White
        Me.vendorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.vendorData.Location = New System.Drawing.Point(385, 142)
        Me.vendorData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.vendorData.Name = "vendorData"
        Me.vendorData.ReadOnly = True
        Me.vendorData.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Gadugi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vendorData.Size = New System.Drawing.Size(275, 340)
        Me.vendorData.TabIndex = 18
        '
        'vendorSearch
        '
        Me.vendorSearch.Location = New System.Drawing.Point(385, 103)
        Me.vendorSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.vendorSearch.Name = "vendorSearch"
        Me.vendorSearch.Size = New System.Drawing.Size(152, 34)
        Me.vendorSearch.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(382, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Name"
        '
        'updateBtn
        '
        Me.updateBtn.BackColor = System.Drawing.Color.DarkRed
        Me.updateBtn.Enabled = False
        Me.updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.updateBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.updateBtn.Location = New System.Drawing.Point(15, 328)
        Me.updateBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.updateBtn.Name = "updateBtn"
        Me.updateBtn.Size = New System.Drawing.Size(275, 50)
        Me.updateBtn.TabIndex = 21
        Me.updateBtn.Text = "UPDATE"
        Me.updateBtn.UseVisualStyleBackColor = False
        '
        'cancelBtn
        '
        Me.cancelBtn.BackColor = System.Drawing.Color.DarkRed
        Me.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.cancelBtn.Location = New System.Drawing.Point(14, 382)
        Me.cancelBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(275, 50)
        Me.cancelBtn.TabIndex = 23
        Me.cancelBtn.Text = "CANCEL"
        Me.cancelBtn.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gadugi", 13.0!)
        Me.Label4.Location = New System.Drawing.Point(381, 30)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(224, 21)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Search for a certain Vendor"
        '
        'vendorGroupBox
        '
        Me.vendorGroupBox.Controls.Add(Me.Button1)
        Me.vendorGroupBox.Controls.Add(Me.vendorSubTitle)
        Me.vendorGroupBox.Controls.Add(Me.Label4)
        Me.vendorGroupBox.Controls.Add(Me.submitBtn)
        Me.vendorGroupBox.Controls.Add(Me.cancelBtn)
        Me.vendorGroupBox.Controls.Add(Me.vendorIdTextField)
        Me.vendorGroupBox.Controls.Add(Me.Label1)
        Me.vendorGroupBox.Controls.Add(Me.updateBtn)
        Me.vendorGroupBox.Controls.Add(Me.Label2)
        Me.vendorGroupBox.Controls.Add(Me.Label3)
        Me.vendorGroupBox.Controls.Add(Me.vendorNameTextField)
        Me.vendorGroupBox.Controls.Add(Me.vendorSearch)
        Me.vendorGroupBox.Controls.Add(Me.vendorData)
        Me.vendorGroupBox.Location = New System.Drawing.Point(35, 87)
        Me.vendorGroupBox.Name = "vendorGroupBox"
        Me.vendorGroupBox.Size = New System.Drawing.Size(721, 506)
        Me.vendorGroupBox.TabIndex = 25
        Me.vendorGroupBox.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(543, 104)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 34)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'vendorTitle
        '
        Me.vendorTitle.AutoSize = True
        Me.vendorTitle.Font = New System.Drawing.Font("Gadugi", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vendorTitle.ForeColor = System.Drawing.Color.DarkRed
        Me.vendorTitle.Location = New System.Drawing.Point(27, 51)
        Me.vendorTitle.Name = "vendorTitle"
        Me.vendorTitle.Size = New System.Drawing.Size(242, 45)
        Me.vendorTitle.TabIndex = 26
        Me.vendorTitle.Text = "Vendor Insert"
        '
        'insertVendor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1284, 646)
        Me.Controls.Add(Me.vendorTitle)
        Me.Controls.Add(Me.vendorGroupBox)
        Me.Font = New System.Drawing.Font("Gadugi", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.Name = "insertVendor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "insertVendor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.vendorData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.vendorGroupBox.ResumeLayout(False)
        Me.vendorGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents vendorSubTitle As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents vendorIdTextField As System.Windows.Forms.TextBox
    Friend WithEvents submitBtn As System.Windows.Forms.Button
    Friend WithEvents vendorNameTextField As System.Windows.Forms.TextBox
    Friend WithEvents vendorData As System.Windows.Forms.DataGridView
    Friend WithEvents vendorSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents updateBtn As System.Windows.Forms.Button
    Friend WithEvents cancelBtn As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents vendorGroupBox As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents vendorTitle As Label
End Class
