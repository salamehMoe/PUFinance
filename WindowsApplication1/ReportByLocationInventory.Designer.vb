<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportByLocationInventory
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.printBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.locationDropBox = New System.Windows.Forms.ComboBox()
        Me.locationInvGrid = New System.Windows.Forms.DataGridView()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.locationInvGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.loadingPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(40, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(296, 41)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Location Inventory"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.loadingPanel)
        Me.GroupBox1.Controls.Add(Me.locationInvGrid)
        Me.GroupBox1.Location = New System.Drawing.Point(47, 196)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1105, 524)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'printBtn
        '
        Me.printBtn.BackColor = System.Drawing.Color.DarkRed
        Me.printBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.printBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.printBtn.Location = New System.Drawing.Point(219, 151)
        Me.printBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.printBtn.Name = "printBtn"
        Me.printBtn.Size = New System.Drawing.Size(166, 30)
        Me.printBtn.TabIndex = 227
        Me.printBtn.Text = "PRINT"
        Me.printBtn.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(391, 151)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 30)
        Me.Button1.TabIndex = 226
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(47, 151)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(166, 30)
        Me.submitBtn.TabIndex = 225
        Me.submitBtn.Text = "CREATE REPORT"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 89)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 224
        Me.Label2.Text = "Location"
        '
        'locationDropBox
        '
        Me.locationDropBox.FormattingEnabled = True
        Me.locationDropBox.Location = New System.Drawing.Point(47, 112)
        Me.locationDropBox.Margin = New System.Windows.Forms.Padding(4)
        Me.locationDropBox.Name = "locationDropBox"
        Me.locationDropBox.Size = New System.Drawing.Size(180, 27)
        Me.locationDropBox.TabIndex = 223
        '
        'locationInvGrid
        '
        Me.locationInvGrid.AllowUserToDeleteRows = False
        Me.locationInvGrid.BackgroundColor = System.Drawing.Color.White
        Me.locationInvGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.locationInvGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.locationInvGrid.Location = New System.Drawing.Point(32, 28)
        Me.locationInvGrid.Name = "locationInvGrid"
        Me.locationInvGrid.ReadOnly = True
        Me.locationInvGrid.Size = New System.Drawing.Size(1067, 471)
        Me.locationInvGrid.TabIndex = 13
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.DarkRed
        Me.loadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.loadingPanel.Controls.Add(Me.Label4)
        Me.loadingPanel.Controls.Add(Me.Label5)
        Me.loadingPanel.Location = New System.Drawing.Point(526, 183)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(329, 76)
        Me.loadingPanel.TabIndex = 30
        Me.loadingPanel.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(4, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "This may take a while..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 19)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Please wait for export to finish"
        '
        'ReportByLocationInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1291, 739)
        Me.Controls.Add(Me.printBtn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.submitBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.locationDropBox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ReportByLocationInventory"
        Me.Text = "Location Inventory"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.locationInvGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents printBtn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents submitBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents locationDropBox As ComboBox
    Friend WithEvents locationInvGrid As DataGridView
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
