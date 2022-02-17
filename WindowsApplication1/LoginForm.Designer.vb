<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginForm
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
        Me.loginBtn = New System.Windows.Forms.Button()
        Me.userNameField = New System.Windows.Forms.TextBox()
        Me.rememberCheckBox = New System.Windows.Forms.CheckBox()
        Me.userLoginLabel = New System.Windows.Forms.Label()
        Me.contactlabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.passwordField = New System.Windows.Forms.MaskedTextBox()
        Me.exitBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'loginBtn
        '
        Me.loginBtn.BackColor = System.Drawing.Color.DarkRed
        Me.loginBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loginBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.loginBtn.Location = New System.Drawing.Point(12, 261)
        Me.loginBtn.Name = "loginBtn"
        Me.loginBtn.Size = New System.Drawing.Size(276, 50)
        Me.loginBtn.TabIndex = 4
        Me.loginBtn.Text = "LOG IN"
        Me.loginBtn.UseVisualStyleBackColor = False
        '
        'userNameField
        '
        Me.userNameField.ForeColor = System.Drawing.Color.DarkRed
        Me.userNameField.Location = New System.Drawing.Point(12, 124)
        Me.userNameField.Multiline = True
        Me.userNameField.Name = "userNameField"
        Me.userNameField.Size = New System.Drawing.Size(276, 40)
        Me.userNameField.TabIndex = 1
        '
        'rememberCheckBox
        '
        Me.rememberCheckBox.AutoSize = True
        Me.rememberCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.rememberCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.rememberCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rememberCheckBox.Font = New System.Drawing.Font("Gadugi", 12.0!)
        Me.rememberCheckBox.ForeColor = System.Drawing.SystemColors.GrayText
        Me.rememberCheckBox.Location = New System.Drawing.Point(12, 232)
        Me.rememberCheckBox.Name = "rememberCheckBox"
        Me.rememberCheckBox.Size = New System.Drawing.Size(114, 23)
        Me.rememberCheckBox.TabIndex = 3
        Me.rememberCheckBox.Text = "Remeber me"
        Me.rememberCheckBox.UseVisualStyleBackColor = True
        '
        'userLoginLabel
        '
        Me.userLoginLabel.AutoSize = True
        Me.userLoginLabel.Font = New System.Drawing.Font("Gadugi", 13.0!)
        Me.userLoginLabel.ForeColor = System.Drawing.SystemColors.GrayText
        Me.userLoginLabel.Location = New System.Drawing.Point(8, 44)
        Me.userLoginLabel.MaximumSize = New System.Drawing.Size(310, 0)
        Me.userLoginLabel.Name = "userLoginLabel"
        Me.userLoginLabel.Size = New System.Drawing.Size(286, 42)
        Me.userLoginLabel.TabIndex = 5
        Me.userLoginLabel.Text = "Provide your Username and password to access the application"
        '
        'contactlabel
        '
        Me.contactlabel.AutoSize = True
        Me.contactlabel.Font = New System.Drawing.Font("Gadugi", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contactlabel.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.contactlabel.Location = New System.Drawing.Point(82, 349)
        Me.contactlabel.MaximumSize = New System.Drawing.Size(150, 0)
        Me.contactlabel.Name = "contactlabel"
        Me.contactlabel.Size = New System.Drawing.Size(143, 42)
        Me.contactlabel.TabIndex = 6
        Me.contactlabel.Text = "Please contact the IT department if you had any issue"
        Me.contactlabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Password"
        '
        'passwordField
        '
        Me.passwordField.ForeColor = System.Drawing.Color.DarkRed
        Me.passwordField.Location = New System.Drawing.Point(12, 186)
        Me.passwordField.MaximumSize = New System.Drawing.Size(267, 40)
        Me.passwordField.MinimumSize = New System.Drawing.Size(276, 40)
        Me.passwordField.Name = "passwordField"
        Me.passwordField.Size = New System.Drawing.Size(276, 40)
        Me.passwordField.TabIndex = 2
        Me.passwordField.UseSystemPasswordChar = True
        '
        'exitBtn
        '
        Me.exitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.exitBtn.FlatAppearance.BorderSize = 0
        Me.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exitBtn.Image = Global.FinanceStockApp.My.Resources.Resources.cancel
        Me.exitBtn.Location = New System.Drawing.Point(273, 12)
        Me.exitBtn.Name = "exitBtn"
        Me.exitBtn.Size = New System.Drawing.Size(15, 15)
        Me.exitBtn.TabIndex = 0
        Me.exitBtn.UseVisualStyleBackColor = True
        '
        'loginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.exitBtn
        Me.ClientSize = New System.Drawing.Size(300, 400)
        Me.Controls.Add(Me.passwordField)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.contactlabel)
        Me.Controls.Add(Me.userLoginLabel)
        Me.Controls.Add(Me.rememberCheckBox)
        Me.Controls.Add(Me.userNameField)
        Me.Controls.Add(Me.loginBtn)
        Me.Controls.Add(Me.exitBtn)
        Me.Font = New System.Drawing.Font("Gadugi", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Gray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.Name = "loginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents exitBtn As System.Windows.Forms.Button
    Friend WithEvents loginBtn As System.Windows.Forms.Button
    Friend WithEvents userNameField As System.Windows.Forms.TextBox
    Friend WithEvents rememberCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents userLoginLabel As System.Windows.Forms.Label
    Friend WithEvents contactlabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents passwordField As System.Windows.Forms.MaskedTextBox

End Class
