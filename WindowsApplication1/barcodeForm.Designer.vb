<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class barcodeForm
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.barcodesDisplay = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.barcodeListBox = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DarkRed
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.SystemColors.Window
        Me.Button1.Location = New System.Drawing.Point(12, 180)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 21)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "CANCEL"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Gadugi", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 31)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Insert Barcodes"
        '
        'barcodesDisplay
        '
        Me.barcodesDisplay.AutoSize = True
        Me.barcodesDisplay.Font = New System.Drawing.Font("Gadugi", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barcodesDisplay.ForeColor = System.Drawing.Color.DarkRed
        Me.barcodesDisplay.Location = New System.Drawing.Point(240, 53)
        Me.barcodesDisplay.Name = "barcodesDisplay"
        Me.barcodesDisplay.Size = New System.Drawing.Size(0, 19)
        Me.barcodesDisplay.TabIndex = 8
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DarkRed
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.SystemColors.Window
        Me.Button2.Location = New System.Drawing.Point(12, 99)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(176, 21)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "DONE"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'barcodeListBox
        '
        Me.barcodeListBox.Font = New System.Drawing.Font("Gadugi", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barcodeListBox.ForeColor = System.Drawing.Color.DarkRed
        Me.barcodeListBox.FormattingEnabled = True
        Me.barcodeListBox.ItemHeight = 14
        Me.barcodeListBox.Location = New System.Drawing.Point(218, 72)
        Me.barcodeListBox.Name = "barcodeListBox"
        Me.barcodeListBox.Size = New System.Drawing.Size(120, 186)
        Me.barcodeListBox.TabIndex = 10
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkRed
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.SystemColors.Window
        Me.Button3.Location = New System.Drawing.Point(12, 126)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(176, 21)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "DELETE"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.DarkRed
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.SystemColors.Window
        Me.Button4.Location = New System.Drawing.Point(12, 153)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(176, 21)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "REMOVE ALL"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DarkRed
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.ForeColor = System.Drawing.SystemColors.Window
        Me.Button5.Location = New System.Drawing.Point(12, 72)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(176, 21)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "GENERATE BARCODES"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'barcodeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 273)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.barcodeListBox)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.barcodesDisplay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "barcodeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "barcodeForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents barcodesDisplay As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents barcodeListBox As ListBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
