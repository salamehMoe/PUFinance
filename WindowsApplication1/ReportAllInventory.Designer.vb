<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportAllInventory
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportAllInventory))
        Me.printPreviewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.printDialog = New System.Drawing.Printing.PrintDocument()
        Me.printBtn = New System.Windows.Forms.Button()
        Me.printingDoc = New System.Windows.Forms.GroupBox()
        Me.loadingPanel = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.allInventoryGrid = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.printingDoc.SuspendLayout()
        Me.loadingPanel.SuspendLayout()
        CType(Me.allInventoryGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'printBtn
        '
        Me.printBtn.BackColor = System.Drawing.Color.DarkRed
        Me.printBtn.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.printBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printBtn.ForeColor = System.Drawing.SystemColors.Window
        Me.printBtn.Location = New System.Drawing.Point(17, 60)
        Me.printBtn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.printBtn.Name = "printBtn"
        Me.printBtn.Size = New System.Drawing.Size(166, 30)
        Me.printBtn.TabIndex = 228
        Me.printBtn.Text = "PRINT"
        Me.printBtn.UseVisualStyleBackColor = False
        '
        'printingDoc
        '
        Me.printingDoc.Controls.Add(Me.loadingPanel)
        Me.printingDoc.Controls.Add(Me.allInventoryGrid)
        Me.printingDoc.Location = New System.Drawing.Point(18, 107)
        Me.printingDoc.Name = "printingDoc"
        Me.printingDoc.Size = New System.Drawing.Size(1188, 579)
        Me.printingDoc.TabIndex = 229
        Me.printingDoc.TabStop = False
        '
        'loadingPanel
        '
        Me.loadingPanel.BackColor = System.Drawing.Color.DarkRed
        Me.loadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.loadingPanel.Controls.Add(Me.Label4)
        Me.loadingPanel.Controls.Add(Me.Label5)
        Me.loadingPanel.Location = New System.Drawing.Point(422, 221)
        Me.loadingPanel.Name = "loadingPanel"
        Me.loadingPanel.Size = New System.Drawing.Size(329, 76)
        Me.loadingPanel.TabIndex = 26
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
        'allInventoryGrid
        '
        Me.allInventoryGrid.AllowUserToDeleteRows = False
        Me.allInventoryGrid.BackgroundColor = System.Drawing.Color.White
        Me.allInventoryGrid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.allInventoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.allInventoryGrid.Location = New System.Drawing.Point(25, 54)
        Me.allInventoryGrid.Name = "allInventoryGrid"
        Me.allInventoryGrid.ReadOnly = True
        Me.allInventoryGrid.Size = New System.Drawing.Size(1117, 471)
        Me.allInventoryGrid.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(290, 31)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Report for All Inventory"
        '
        'Timer1
        '
        Me.Timer1.Interval = 300
        '
        'ReportAllInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1436, 874)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.printBtn)
        Me.Controls.Add(Me.printingDoc)
        Me.Font = New System.Drawing.Font("Gadugi", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ReportAllInventory"
        Me.Text = "Warehouse Items"
        Me.printingDoc.ResumeLayout(False)
        Me.loadingPanel.ResumeLayout(False)
        Me.loadingPanel.PerformLayout()
        CType(Me.allInventoryGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents printPreviewDialog As PrintPreviewDialog
    Friend WithEvents printDialog As Printing.PrintDocument
    Friend WithEvents printBtn As Button
    Friend WithEvents printingDoc As GroupBox
    Friend WithEvents allInventoryGrid As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents loadingPanel As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
