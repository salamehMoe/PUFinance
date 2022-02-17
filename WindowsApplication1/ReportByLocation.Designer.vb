<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportByLocation
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
        Me.itemIDLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.selectedItemBox = New System.Windows.Forms.ComboBox()
        Me.printingDoc = New System.Windows.Forms.GroupBox()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.totalPrice = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.totalQty = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.locationGrid = New System.Windows.Forms.DataGridView()
        Me.printBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.printingDoc.SuspendLayout()
        Me.loadingPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.locationGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inventory ID"
        '
        'itemIDLabel
        '
        Me.itemIDLabel.AutoSize = True
        Me.itemIDLabel.Location = New System.Drawing.Point(135, 74)
        Me.itemIDLabel.Name = "itemIDLabel"
        Me.itemIDLabel.Size = New System.Drawing.Size(15, 19)
        Me.itemIDLabel.TabIndex = 1
        Me.itemIDLabel.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Inventory Name"
        '
        'selectedItemBox
        '
        Me.selectedItemBox.FormattingEnabled = True
        Me.selectedItemBox.Location = New System.Drawing.Point(139, 108)
        Me.selectedItemBox.Name = "selectedItemBox"
        Me.selectedItemBox.Size = New System.Drawing.Size(202, 27)
        Me.selectedItemBox.TabIndex = 3
        '
        'printingDoc
        '
        Me.printingDoc.Controls.Add(Me.loadingPanel)
        Me.printingDoc.Controls.Add(Me.Panel2)
        Me.printingDoc.Controls.Add(Me.Panel1)
        Me.printingDoc.Controls.Add(Me.locationGrid)
        Me.printingDoc.Location = New System.Drawing.Point(16, 141)
        Me.printingDoc.Name = "printingDoc"
        Me.printingDoc.Size = New System.Drawing.Size(909, 579)
        Me.printingDoc.TabIndex = 224
        Me.printingDoc.TabStop = False
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.DarkRed
        Me.loadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.loadingPanel.Controls.Add(Me.Label4)
        Me.loadingPanel.Controls.Add(Me.Label5)
        Me.loadingPanel.Location = New System.Drawing.Point(454, 301)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(329, 76)
        Me.loadingPanel.TabIndex = 228
        Me.loadingPanel.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Gadugi", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 35)
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
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.totalPrice)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Location = New System.Drawing.Point(281, 48)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(287, 29)
        Me.Panel2.TabIndex = 26
        '
        'totalPrice
        '
        Me.totalPrice.AutoSize = True
        Me.totalPrice.Location = New System.Drawing.Point(90, 5)
        Me.totalPrice.Name = "totalPrice"
        Me.totalPrice.Size = New System.Drawing.Size(15, 19)
        Me.totalPrice.TabIndex = 1
        Me.totalPrice.Text = "-"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 5)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(81, 19)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Total Price"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.totalQty)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Location = New System.Drawing.Point(6, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(239, 29)
        Me.Panel1.TabIndex = 25
        '
        'totalQty
        '
        Me.totalQty.AutoSize = True
        Me.totalQty.Location = New System.Drawing.Point(90, 5)
        Me.totalQty.Name = "totalQty"
        Me.totalQty.Size = New System.Drawing.Size(15, 19)
        Me.totalQty.TabIndex = 1
        Me.totalQty.Text = "-"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 19)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Total Qty"
        '
        'locationGrid
        '
        Me.locationGrid.AllowUserToDeleteRows = False
        Me.locationGrid.BackgroundColor = System.Drawing.Color.White
        Me.locationGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.locationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.locationGrid.Location = New System.Drawing.Point(6, 98)
        Me.locationGrid.Name = "locationGrid"
        Me.locationGrid.ReadOnly = True
        Me.locationGrid.Size = New System.Drawing.Size(832, 469)
        Me.locationGrid.TabIndex = 12
        '
        'printBtn
        '
        Me.printBtn.BackColor = System.Drawing.Color.DarkRed
        Me.printBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.printBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.printBtn.Location = New System.Drawing.Point(418, 74)
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
        Me.Button1.Location = New System.Drawing.Point(418, 108)
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
        Me.submitBtn.Location = New System.Drawing.Point(418, 40)
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
        Me.Label2.Font = New System.Drawing.Font("Gadugi", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(211, 31)
        Me.Label2.TabIndex = 228
        Me.Label2.Text = "Item By Location"
        '
        'ReportByLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1436, 658)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.printBtn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.submitBtn)
        Me.Controls.Add(Me.printingDoc)
        Me.Controls.Add(Me.selectedItemBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.itemIDLabel)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ReportByLocation"
        Me.Text = "Item By Location"
        Me.printingDoc.ResumeLayout(False)
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.locationGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents itemIDLabel As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents selectedItemBox As ComboBox
    Friend WithEvents printingDoc As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents totalPrice As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents totalQty As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents printBtn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents submitBtn As Button
    Friend WithEvents locationGrid As DataGridView
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
End Class
