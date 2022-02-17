Imports System.IO
Imports Microsoft.Office.Interop

Public Class exportdatagridviewclass
    Public sheetname, workbookname As String
    Public Sub DATAGRIDVIEW_TO_EXCEL(ByVal DGV As DataGridView)
        closeopenedfiles()
        Dim cell As Excel.Range
        Dim border As Excel.Borders
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer
        Dim frm As New ProgressBar()


        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("Sheet1")


        If ((DGV.Columns.Count = 0) Or (DGV.Rows.Count = 0)) Then
            Exit Sub
        End If
        'frm.ShowDialog()
        For i = 0 To DGV.RowCount - 2
            For j = 0 To DGV.ColumnCount - 1
                For k As Integer = 1 To DGV.Columns.Count
                    xlWorkSheet.Cells(1, k) = DGV.Columns(k - 1).HeaderText
                    xlWorkSheet.Cells(i + 2, j + 1) = DGV(j, i).Value.ToString()
                Next
            Next
        Next

        Dim style As Excel.Style = xlWorkSheet.Application.ActiveWorkbook.Styles.Add("NewStyle")
        style.Font.Bold = True
        style.Font.Size = 14
        'style.Font.Color = Color.White
        style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        style.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
        Dim formatRange As Excel.Range = xlWorkSheet.UsedRange
        xlWorkSheet.PageSetup.PrintTitleRows = "$1:$1"

        Dim styles0 As Excel.Style = xlWorkSheet.Application.ActiveWorkbook.Styles.Add("Style0")
        styles0.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        styles0.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        styles0.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
        styles0.Font.Size = 12
        styles0.Font.Color = Color.White

        For p = 1 To DGV.Columns.Count
            xlWorkSheet.Cells(1, p).Style = "NewStyle"
            cell = formatRange.Cells(1, p)
            border = cell.Borders
            border.LineStyle = Excel.XlLineStyle.xlContinuous
            border.Weight = 2.0
        Next

        Dim styles As Excel.Style = xlWorkSheet.Application.ActiveWorkbook.Styles.Add("Style")
        styles.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        styles.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        styles.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
        styles.Font.Size = 12
        styles.Font.Color = Color.White

        Dim styles2 As Excel.Style = xlWorkSheet.Application.ActiveWorkbook.Styles.Add("Style2")
        styles2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        styles2.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
        styles2.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Orange)
        styles2.Font.Size = 12
        styles2.Font.Color = Color.White

        For i = 0 To DGV.Rows.Count - 2
            For j = 0 To DGV.Columns.Count - 1
                If (DGV(j, i).Value.ToString() = "Urgent") Then
                    xlWorkSheet.Cells(i + 2, j + 1).Style = "Style"
                ElseIf (DGV(j, i).Value.ToString() = "Suggested") Then
                    xlWorkSheet.Cells(i + 2, j + 1).Style = "Style2"


                End If

                If i = DGV.Rows.Count - 2 And DGV.Columns(0).Name <> "ID" And DGV.Columns(1).Name <> "ID" And DGV.Columns(0).Name <> "Status" And DGV.Columns(1).Name <> "Status" And DGV.Columns(0).Name <> "Item ID" And DGV.Columns(0).Name <> "Inventory ID" Then
                    xlWorkSheet.Cells(i + 2, j + 1).Style = "Style0"
                End If

                cell = formatRange.Cells(i + 2, j + 1)
                border = cell.Borders
                border.LineStyle = Excel.XlLineStyle.xlContinuous
                border.Weight = 2

            Next
        Next

        workbookname = "Printing Report"
        sheetname = "Printing Document"
        xlApp.DisplayAlerts = False
        xlWorkSheet.Name = sheetname
        'xlWorkSheet.Name = "Printing Document"
        xlWorkSheet.Columns.EntireColumn.AutoFit()
        If Not IO.Directory.Exists(Application.StartupPath + "\PrintingDocuments") Then
            IO.Directory.CreateDirectory(Application.StartupPath + "\PrintingDocuments")
        End If
        If (Not My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\PrintingDocuments.lnk")) Then
            Dim createshrtcut As New CreateShortcutClass
            createshrtcut.CreateShortcut()
        End If
        xlWorkSheet.SaveAs(Application.StartupPath + "\PrintingDocuments\" & workbookname & ".xlsx")
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
        ExcelViewer(Application.StartupPath + "\PrintingDocuments\" & workbookname & ".xlsx")
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Private Sub ExcelViewer(ByVal fileName As String)
        Try
            Process.Start(fileName)
        Catch
        End Try
    End Sub
    Private Function FileInUse(ByVal sFile As String) As Boolean
        Dim thisFileInUse As Boolean = False
        If System.IO.File.Exists(sFile) Then
            Try
                Using f As New IO.FileStream(sFile, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                    ' thisFileInUse = False
                End Using
            Catch
                thisFileInUse = True
            End Try
        End If
        Return thisFileInUse
    End Function
    Private Sub closeopenedfiles()
        Try
            If FileInUse(Application.StartupPath + "\PrintingDocuments\" & workbookname & ".xlsx") Then
                Dim WORKING = Interaction.GetObject(Application.StartupPath + "\PrintingDocuments\" & workbookname & ".xlsx")
                If Not IsNothing(WORKING) Then
                    WORKING.close(False)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class