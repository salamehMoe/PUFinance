<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class assetClassAdd
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
        Me.groupTitle = New System.Windows.Forms.Label()
        Me.groupGroupBox = New System.Windows.Forms.GroupBox()
        Me.assetDaysTextBox = New System.Windows.Forms.TextBox()
        Me.assetYearTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.vendorSubTitle = New System.Windows.Forms.Label()
        Me.cancelSearch = New System.Windows.Forms.Button()
        Me.classIDTextBox = New System.Windows.Forms.TextBox()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.updateBtn = New System.Windows.Forms.Button()
        Me.classNameTextBox = New System.Windows.Forms.TextBox()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.assetClassData = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.assetClassSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.groupGroupBox.SuspendLayout()
        CType(Me.assetClassData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupTitle
        '
        Me.groupTitle.AutoSize = True
        Me.groupTitle.Font = New System.Drawing.Font("Gadugi", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupTitle.ForeColor = System.Drawing.Color.DarkRed
        Me.groupTitle.Location = New System.Drawing.Point(38, 26)
        Me.groupTitle.Name = "groupTitle"
        Me.groupTitle.Size = New System.Drawing.Size(205, 45)
        Me.groupTitle.TabIndex = 42
        Me.groupTitle.Text = "Class Insert"
        '
        'groupGroupBox
        '
        Me.groupGroupBox.Controls.Add(Me.assetDaysTextBox)
        Me.groupGroupBox.Controls.Add(Me.assetYearTextBox)
        Me.groupGroupBox.Controls.Add(Me.Label7)
        Me.groupGroupBox.Controls.Add(Me.Label6)
        Me.groupGroupBox.Controls.Add(Me.Label5)
        Me.groupGroupBox.Controls.Add(Me.vendorSubTitle)
        Me.groupGroupBox.Controls.Add(Me.cancelSearch)
        Me.groupGroupBox.Controls.Add(Me.classIDTextBox)
        Me.groupGroupBox.Controls.Add(Me.cancelBtn)
        Me.groupGroupBox.Controls.Add(Me.Label1)
        Me.groupGroupBox.Controls.Add(Me.Label2)
        Me.groupGroupBox.Controls.Add(Me.updateBtn)
        Me.groupGroupBox.Controls.Add(Me.classNameTextBox)
        Me.groupGroupBox.Controls.Add(Me.submitBtn)
        Me.groupGroupBox.Controls.Add(Me.assetClassData)
        Me.groupGroupBox.Controls.Add(Me.Label4)
        Me.groupGroupBox.Controls.Add(Me.assetClassSearch)
        Me.groupGroupBox.Controls.Add(Me.Label3)
        Me.groupGroupBox.Location = New System.Drawing.Point(43, 88)
        Me.groupGroupBox.Name = "groupGroupBox"
        Me.groupGroupBox.Size = New System.Drawing.Size(1052, 586)
        Me.groupGroupBox.TabIndex = 41
        Me.groupGroupBox.TabStop = False
        '
        'assetDaysTextBox
        '
        Me.assetDaysTextBox.ForeColor = System.Drawing.Color.DarkRed
        Me.assetDaysTextBox.Location = New System.Drawing.Point(185, 308)
        Me.assetDaysTextBox.Multiline = True
        Me.assetDaysTextBox.Name = "assetDaysTextBox"
        Me.assetDaysTextBox.Size = New System.Drawing.Size(104, 40)
        Me.assetDaysTextBox.TabIndex = 43
        '
        'assetYearTextBox
        '
        Me.assetYearTextBox.ForeColor = System.Drawing.Color.DarkRed
        Me.assetYearTextBox.Location = New System.Drawing.Point(18, 308)
        Me.assetYearTextBox.Multiline = True
        Me.assetYearTextBox.Name = "assetYearTextBox"
        Me.assetYearTextBox.Size = New System.Drawing.Size(104, 40)
        Me.assetYearTextBox.TabIndex = 42
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 24)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Years"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(181, 281)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 24)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Days"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 238)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 24)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Useful Life :"
        '
        'vendorSubTitle
        '
        Me.vendorSubTitle.AutoSize = True
        Me.vendorSubTitle.Font = New System.Drawing.Font("Gadugi", 15.0!)
        Me.vendorSubTitle.Location = New System.Drawing.Point(9, 30)
        Me.vendorSubTitle.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.vendorSubTitle.MaximumSize = New System.Drawing.Size(250, 0)
        Me.vendorSubTitle.Name = "vendorSubTitle"
        Me.vendorSubTitle.Size = New System.Drawing.Size(239, 48)
        Me.vendorSubTitle.TabIndex = 17
        Me.vendorSubTitle.Text = "Fill the below information to add a Class"
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
        'classIDTextBox
        '
        Me.classIDTextBox.ForeColor = System.Drawing.Color.DarkRed
        Me.classIDTextBox.Location = New System.Drawing.Point(13, 113)
        Me.classIDTextBox.Multiline = True
        Me.classIDTextBox.Name = "classIDTextBox"
        Me.classIDTextBox.Size = New System.Drawing.Size(276, 40)
        Me.classIDTextBox.TabIndex = 20
        '
        'cancelBtn
        '
        Me.cancelBtn.BackColor = System.Drawing.Color.DarkRed
        Me.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.cancelBtn.Location = New System.Drawing.Point(13, 498)
        Me.cancelBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(275, 50)
        Me.cancelBtn.TabIndex = 37
        Me.cancelBtn.Text = "CANCEL"
        Me.cancelBtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 15.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 24)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Class ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Gadugi", 15.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 24)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Class Name"
        '
        'updateBtn
        '
        Me.updateBtn.BackColor = System.Drawing.Color.DarkRed
        Me.updateBtn.Enabled = False
        Me.updateBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.updateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.updateBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.updateBtn.Location = New System.Drawing.Point(13, 444)
        Me.updateBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.updateBtn.Name = "updateBtn"
        Me.updateBtn.Size = New System.Drawing.Size(275, 50)
        Me.updateBtn.TabIndex = 35
        Me.updateBtn.Text = "UPDATE"
        Me.updateBtn.UseVisualStyleBackColor = False
        '
        'classNameTextBox
        '
        Me.classNameTextBox.ForeColor = System.Drawing.Color.DarkRed
        Me.classNameTextBox.Location = New System.Drawing.Point(13, 183)
        Me.classNameTextBox.Multiline = True
        Me.classNameTextBox.Name = "classNameTextBox"
        Me.classNameTextBox.Size = New System.Drawing.Size(276, 40)
        Me.classNameTextBox.TabIndex = 23
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(13, 390)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(275, 50)
        Me.submitBtn.TabIndex = 34
        Me.submitBtn.Text = "SUBMIT"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'assetClassData
        '
        Me.assetClassData.BackgroundColor = System.Drawing.Color.White
        Me.assetClassData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.assetClassData.Location = New System.Drawing.Point(357, 153)
        Me.assetClassData.Name = "assetClassData"
        Me.assetClassData.ReadOnly = True
        Me.assetClassData.Size = New System.Drawing.Size(560, 410)
        Me.assetClassData.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gadugi", 15.0!)
        Me.Label4.Location = New System.Drawing.Point(353, 39)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(225, 24)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Search for a certain Class"
        '
        'assetClassSearch
        '
        Me.assetClassSearch.Location = New System.Drawing.Point(357, 113)
        Me.assetClassSearch.Name = "assetClassSearch"
        Me.assetClassSearch.Size = New System.Drawing.Size(224, 34)
        Me.assetClassSearch.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gadugi", 15.0!)
        Me.Label3.Location = New System.Drawing.Point(353, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 24)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Class Name"
        '
        'assetClassAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1444, 882)
        Me.Controls.Add(Me.groupTitle)
        Me.Controls.Add(Me.groupGroupBox)
        Me.Font = New System.Drawing.Font("Gadugi", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "assetClassAdd"
        Me.Text = "Asset Class"
        Me.groupGroupBox.ResumeLayout(False)
        Me.groupGroupBox.PerformLayout()
        CType(Me.assetClassData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents groupTitle As Label
    Friend WithEvents groupGroupBox As GroupBox
    Friend WithEvents assetDaysTextBox As TextBox
    Friend WithEvents assetYearTextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents vendorSubTitle As Label
    Friend WithEvents cancelSearch As Button
    Friend WithEvents classIDTextBox As TextBox
    Friend WithEvents cancelBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents updateBtn As Button
    Friend WithEvents classNameTextBox As TextBox
    Friend WithEvents submitBtn As Button
    Friend WithEvents assetClassData As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents assetClassSearch As TextBox
    Friend WithEvents Label3 As Label
End Class
