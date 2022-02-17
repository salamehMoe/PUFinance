<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReportByTransactionLocation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportByTransactionLocation))
        Me.locationDropBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.byLocationGrid = New System.Windows.Forms.DataGridView()
        Me.printBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.submitBtn = New System.Windows.Forms.Button()
        Me.printingDoc = New System.Windows.Forms.GroupBox()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.selectedLocation = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.totalPrice = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.totalQty = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.printDialog = New System.Drawing.Printing.PrintDocument()
        Me.printPreviewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.byLocationGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.printingDoc.SuspendLayout()
        Me.loadingPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'locationDropBox
        '
        Me.locationDropBox.FormattingEnabled = True
        Me.locationDropBox.Location = New System.Drawing.Point(24, 76)
        Me.locationDropBox.Margin = New System.Windows.Forms.Padding(4)
        Me.locationDropBox.Name = "locationDropBox"
        Me.locationDropBox.Size = New System.Drawing.Size(180, 27)
        Me.locationDropBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Location"
        '
        'byLocationGrid
        '
        Me.byLocationGrid.AllowUserToDeleteRows = False
        Me.byLocationGrid.BackgroundColor = System.Drawing.Color.White
        Me.byLocationGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.byLocationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.byLocationGrid.Location = New System.Drawing.Point(6, 98)
        Me.byLocationGrid.Name = "byLocationGrid"
        Me.byLocationGrid.ReadOnly = True
        Me.byLocationGrid.Size = New System.Drawing.Size(1240, 471)
        Me.byLocationGrid.TabIndex = 12
        '
        'printBtn
        '
        Me.printBtn.BackColor = System.Drawing.Color.DarkRed
        Me.printBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.printBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.printBtn.Location = New System.Drawing.Point(196, 115)
        Me.printBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.printBtn.Name = "printBtn"
        Me.printBtn.Size = New System.Drawing.Size(166, 30)
        Me.printBtn.TabIndex = 222
        Me.printBtn.Text = "PRINT"
        Me.printBtn.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(368, 115)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 30)
        Me.Button1.TabIndex = 221
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'submitBtn
        '
        Me.submitBtn.BackColor = System.Drawing.Color.DarkRed
        Me.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.submitBtn.Location = New System.Drawing.Point(24, 115)
        Me.submitBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.submitBtn.Name = "submitBtn"
        Me.submitBtn.Size = New System.Drawing.Size(166, 30)
        Me.submitBtn.TabIndex = 220
        Me.submitBtn.Text = "CREATE REPORT"
        Me.submitBtn.UseVisualStyleBackColor = False
        '
        'printingDoc
        '
        Me.printingDoc.Controls.Add(Me.loadingPanel)
        Me.printingDoc.Controls.Add(Me.selectedLocation)
        Me.printingDoc.Controls.Add(Me.Label2)
        Me.printingDoc.Controls.Add(Me.Panel2)
        Me.printingDoc.Controls.Add(Me.Panel1)
        Me.printingDoc.Controls.Add(Me.byLocationGrid)
        Me.printingDoc.Location = New System.Drawing.Point(18, 150)
        Me.printingDoc.Name = "printingDoc"
        Me.printingDoc.Size = New System.Drawing.Size(1321, 579)
        Me.printingDoc.TabIndex = 223
        Me.printingDoc.TabStop = False
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.DarkRed
        Me.loadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.loadingPanel.Controls.Add(Me.Label4)
        Me.loadingPanel.Controls.Add(Me.Label5)
        Me.loadingPanel.Location = New System.Drawing.Point(450, 370)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(329, 76)
        Me.loadingPanel.TabIndex = 29
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
        'selectedLocation
        '
        Me.selectedLocation.AutoSize = True
        Me.selectedLocation.Location = New System.Drawing.Point(9, 69)
        Me.selectedLocation.Name = "selectedLocation"
        Me.selectedLocation.Size = New System.Drawing.Size(15, 19)
        Me.selectedLocation.TabIndex = 28
        Me.selectedLocation.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 19)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Selected Location"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.totalPrice)
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Location = New System.Drawing.Point(157, 63)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(329, 29)
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
        Me.Panel1.Location = New System.Drawing.Point(157, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 29)
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
        'printPreviewDialog
        '
        Me.printPreviewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.printPreviewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.printPreviewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.printPreviewDialog.Enabled = True
        Me.printPreviewDialog.Icon = CType(resources.GetObject("printPreviewDialog.Icon"), System.Drawing.Icon)
        Me.printPreviewDialog.Name = "printPreviewDialog"
        Me.printPreviewDialog.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Gadugi", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(276, 31)
        Me.Label3.TabIndex = 224
        Me.Label3.Text = "Location's Transaction"
        '
        'ReportByTransactionLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1436, 874)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.printingDoc)
        Me.Controls.Add(Me.printBtn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.submitBtn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.locationDropBox)
        Me.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ReportByTransactionLocation"
        Me.Text = "Report Transactions Of Location"
        CType(Me.byLocationGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.printingDoc.ResumeLayout(False)
        Me.printingDoc.PerformLayout()
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents locationDropBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents byLocationGrid As DataGridView
    Friend WithEvents printBtn As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents submitBtn As Button
    Friend WithEvents printingDoc As GroupBox
    Friend WithEvents selectedLocation As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents totalPrice As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents totalQty As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents printDialog As Printing.PrintDocument
    Friend WithEvents printPreviewDialog As PrintPreviewDialog
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
End Class
