Imports System.Data.SqlClient
Public Class assetVendorAdd

    Dim DataBaseClass As New DatabaseAccesClass
    Dim retrievedID As Integer
    Dim logedInUserID As Integer = My.Settings.userID
    Dim databaseAccessObject As New DatabaseAccesClass
    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
    Dim originalVName As String

    Private Sub assetVendorAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'For Displaying the GridView
        vendorData.Font = New Font("Gadugi", 10)
        vendorData.DataSource = getVendorsData()
        vendorData.Columns(0).Visible = False
        vendorData.Columns(2).Width = 130
        '*****************************

        'Initializing the Form
        disableBtn(updateBtn)
        '*********************


    End Sub

    'Function For getting the Vendor Data
    Private Function getVendorsData() As DataTable

        Dim dt As New DataTable

        dt = databaseAccessObject.SelectMethode("SELECT ID, VendorID as [Vendor ID], VendorName as [Vendor Name] FROM db_owner.tbl_asset_vendor WHERE VendorName LIKE'%" + vendorSearch.Text + "%' and Status = 1")

        Return dt

    End Function
    '*************************************

    'Enabel and Disable btns Functions
    Private Sub disableBtn(someBtn As Button)
        someBtn.Enabled = False
        someBtn.BackColor = Color.LightGray
    End Sub
    Private Sub enableBtn(someBtn As Button)
        someBtn.Enabled = True
        someBtn.BackColor = Color.DarkRed
    End Sub

    Private Sub vendorSearch_TextChanged(sender As Object, e As EventArgs) Handles vendorSearch.TextChanged

        'For Displaying the GridView
        vendorData.Font = New Font("Gadugi", 10)
        vendorData.DataSource = getVendorsData()
        vendorData.Columns(0).Visible = False
        vendorData.Columns(2).Width = 130
        '*****************************

    End Sub

    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click


        Dim dt As New DataTable

        If (vendorIdTextField.TextLength <> 0 And vendorNameTextField.TextLength <> 0) Then

            dt = databaseAccessObject.SelectMethode("Select VendorName FROM db_owner.tbl_asset_vendor")
            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("VendorName").ToString()).ToLower = (vendorNameTextField.Text).ToLower Then
                    MessageBox.Show("Vendor already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim today As Date = Date.Now
            Dim query As String = String.Empty
            query &= "INSERT INTO db_owner.tbl_asset_vendor (VendorID, VendorName, Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
            query &= "VALUES (@VendorID, @VendorName, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@VendorID", vendorIdTextField.Text.ToString())
                    .Parameters.AddWithValue("@VendorName", vendorNameTextField.Text)
                    .Parameters.AddWithValue("@Status", 1)
                    .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                    .Parameters.AddWithValue("@CreateDate", today)
                    .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                    .Parameters.AddWithValue("@RevisionDate", today)
                End With
                conn.Open()
                comm.ExecuteNonQuery()

                vendorIdTextField.Clear()
                vendorNameTextField.Clear()

                vendorData.DataSource = getVendorsData()
                conn.Close()

            End Using
        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)



        End If
        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        vendorSearch.Text = String.Empty

        'For Displaying the GridView
        vendorData.Font = New Font("Gadugi", 10)
        vendorData.DataSource = getVendorsData()
        vendorData.Columns(0).Visible = False
        vendorData.Columns(2).Width = 130
        '*****************************

    End Sub

    Private Sub vendorData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles vendorData.CellClick

        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        If (i >= 0 AndAlso i < vendorData.Rows.Count - 1) Then
            disableBtn(submitBtn)
            enableBtn(updateBtn)


            selectedRow = vendorData.Rows(i)
            retrievedID = selectedRow.Cells(0).Value.ToString()
            vendorIdTextField.Text = selectedRow.Cells(1).Value.ToString()
            vendorNameTextField.Text = selectedRow.Cells(2).Value.ToString()
            originalVName = vendorNameTextField.Text
        End If


    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click

        vendorIdTextField.Clear()
        vendorNameTextField.Clear()

        vendorSearch.Text = String.Empty

        'For Displaying the GridView
        vendorData.Font = New Font("Gadugi", 10)
        vendorData.DataSource = getVendorsData()
        vendorData.Columns(0).Visible = False
        vendorData.Columns(2).Width = 130
        '*****************************
        disableBtn(updateBtn)
        enableBtn(submitBtn)

    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click

        Dim today As Date = Date.Now
        Dim dt As New DataTable

        If (vendorIdTextField.TextLength <> 0 And vendorNameTextField.TextLength <> 0) Then

            dt = databaseAccessObject.SelectMethode("Select VendorName FROM db_owner.tbl_asset_vendor")
            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("VendorName").ToString()).ToLower = (vendorNameTextField.Text).ToLower And originalVName.ToLower <> (vendorNameTextField.Text).ToLower Then
                    MessageBox.Show("Vendor already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()



            Try

                conn.Open()

                myCommand.CommandText = "Update db_owner.tbl_asset_vendor Set VendorID = '" & vendorIdTextField.Text & "', VendorName = '" & vendorNameTextField.Text & "' ,RevisionUserID = '" & logedInUserID & "',RevisionDate = '" & today & "' where (ID = '" & retrievedID & "')"
                rows = myCommand.ExecuteNonQuery()

            Catch ex As SqlException


                ' handle error
                Console.Write("Unable to Add")


            Finally
                vendorIdTextField.Clear()
                vendorNameTextField.Clear()

                'For Displaying the GridView
                vendorData.Font = New Font("Gadugi", 10)
                vendorData.DataSource = getVendorsData()
                vendorData.Columns(0).Visible = False
                vendorData.Columns(2).Width = 130
                '*****************************

                conn.Close()

            End Try

        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub
End Class