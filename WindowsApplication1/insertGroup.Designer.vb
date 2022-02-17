<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class insertGroup
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
        Me.groupNameTextField = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.groupIDTextField = New System.Windows.Forms.TextBox()
        Me.vendorSubTitle = New System.Windows.Forms.Label()
        Me.groupData = New System.Windows.Forms.DataGridView()
        Me.groupSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.updateBtn = New System.Windows.Forms.Button()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.cancelSearch = New System.Windows.Forms.Button()
        Me.groupGroupBox = New System.Windows.Forms.GroupBox()
        Me.groupTitle = New System.Windows.Forms.Label()
        CType(Me.groupData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupNameTextField
        '
        Me.groupNameTextField.ForeColor = System.Drawing.Color.DarkRed
        Me.groupNameTextField.Location = New System.Drawing.Point(13, 176)
        Me.groupNameTextField.Multiline = True
        Me.groupNameTextField.Name = "groupNameTextField"
        Me.groupNameTextField.Size = New System.Drawing.Size(276, 40)
        Me.groupNameTextField.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gadugi", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(13, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Group Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Group ID"
        '
        'groupIDTextField
        '
        Me.groupIDTextField.ForeColor = System.Drawing.Color.DarkRed
        Me.groupIDTextField.Location = New System.Drawing.Point(13, 113)
        Me.groupIDTextField.Multiline = True
        Me.groupIDTextField.Name = "groupIDTextField"
        Me.groupIDTextField.Size = New System.Drawing.Size(276, 40)
        Me.groupIDTextField.TabIndex = 20
        '
        'vendorSubTitle
        '
        Me.vendorSubTitle.AutoSize = True
        Me.vendorSubTitle.Font = New System.Drawing.Font("Gadugi", 13.0!)
        Me.vendorSubTitle.Location = New System.Drawing.Point(9, 39)
        Me.vendorSubTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.vendorSubTitle.MaximumSize = New System.Drawing.Size(250, 0)
        Me.vendorSubTitle.Name = "vendorSubTitle"
        Me.vendorSubTitle.Size = New System.Drawing.Size(239, 42)
        Me.vendorSubTitle.TabIndex = 17
        Me.vendorSubTitle.Text = "Fill the below information to add a group"
        '
        'groupData
        '
        Me.groupData.BackgroundColor = System.Drawing.Color.White
        Me.groupData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.groupData.Location = New System.Drawing.Point(357, 153)
        Me.groupData.Name = "groupData"
        Me.groupData.ReadOnly = True
        Me.groupData.Size = New System.Drawing.Size(370, 410)
        Me.groupData.TabIndex = 30
        '
        'groupSearch
        '
        Me.groupSearch.Location = New System.Drawing.Point(357, 113)
        Me.groupSearch.Name = "groupSearch"
        Me.groupSearch.Size = New System.Drawing.Size(224, 34)
        Me.groupSearch.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(354, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Group Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gadugi", 13.0!)
        Me.Label4.Location = New System.Drawing.Point(353, 39)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(216, 21)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Search for a certain Group"
        '
        'cancelBtn
        '
        Me.cancelBtn.BackColor = System.Drawing.Color.DarkRed
        Me.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.cancelBtn.Location = New System.Drawing.Point(16, 458)
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
        Me.updateBtn.Location = New System.Drawing.Point(16, 404)
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
        Me.submitBtn.Location = New System.Drawing.Point(16, 350)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(275, 50)
        Me.submitBtn.TabIndex = 34
        Me.submitBtn.Text = "SUBMIT"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'cancelSearch
        '
        Me.cancelSearch.BackColor = System.Drawing.Color.DarkRed
        Me.cancelSearch.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cancelSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelSearch.ForeColor = System.Drawing.SystemColors.Window
        Me.cancelSearch.Location = New System.Drawing.Point(587, 113)
        Me.cancelSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cancelSearch.Name = "cancelSearch"
        Me.cancelSearch.Size = New System.Drawing.Size(140, 35)
        Me.cancelSearch.TabIndex = 38
        Me.cancelSearch.Text = "CANCEL"
        Me.cancelSearch.UseVisualStyleBackColor = False
        '
        'groupGroupBox
        '
        Me.groupGroupBox.Controls.Add(Me.vendorSubTitle)
        Me.groupGroupBox.Controls.Add(Me.cancelSearch)
        Me.groupGroupBox.Controls.Add(Me.groupIDTextField)
        Me.groupGroupBox.Controls.Add(Me.cancelBtn)
        Me.groupGroupBox.Controls.Add(Me.Label1)
        Me.groupGroupBox.Controls.Add(Me.Label2)
        Me.groupGroupBox.Controls.Add(Me.updateBtn)
        Me.groupGroupBox.Controls.Add(Me.groupNameTextField)
        Me.groupGroupBox.Controls.Add(Me.submitBtn)
        Me.groupGroupBox.Controls.Add(Me.groupData)
        Me.groupGroupBox.Controls.Add(Me.Label4)
        Me.groupGroupBox.Controls.Add(Me.groupSearch)
        Me.groupGroupBox.Controls.Add(Me.Label3)
        Me.groupGroupBox.Location = New System.Drawing.Point(124, 122)
        Me.groupGroupBox.Name = "groupGroupBox"
        Me.groupGroupBox.Size = New System.Drawing.Size(816, 586)
        Me.groupGroupBox.TabIndex = 39
        Me.groupGroupBox.TabStop = False
        '
        'groupTitle
        '
        Me.groupTitle.AutoSize = True
        Me.groupTitle.Font = New System.Drawing.Font("Gadugi", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupTitle.ForeColor = System.Drawing.Color.DarkRed
        Me.groupTitle.Location = New System.Drawing.Point(119, 60)
        Me.groupTitle.Name = "groupTitle"
        Me.groupTitle.Size = New System.Drawing.Size(225, 45)
        Me.groupTitle.TabIndex = 40
        Me.groupTitle.Text = "Group Insert"
        '
        'insertGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1444, 882)
        Me.Controls.Add(Me.groupTitle)
        Me.Controls.Add(Me.groupGroupBox)
        Me.Font = New System.Drawing.Font("Gadugi", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "insertGroup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "insertGroup"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.groupData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupGroupBox.ResumeLayout(False)
        Me.groupGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents groupNameTextField As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents groupIDTextField As System.Windows.Forms.TextBox
    Friend WithEvents vendorSubTitle As System.Windows.Forms.Label
    Friend WithEvents groupData As System.Windows.Forms.DataGridView
    Friend WithEvents groupSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cancelBtn As System.Windows.Forms.Button
    Friend WithEvents updateBtn As System.Windows.Forms.Button
    Friend WithEvents submitBtn As System.Windows.Forms.Button
    Friend WithEvents cancelSearch As Button
    Friend WithEvents groupGroupBox As GroupBox
    Friend WithEvents groupTitle As Label
End Class
