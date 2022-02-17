Imports System.Data.SqlClient
Public Class insertLocation

    Dim retrievedID As Integer
    Dim logedInUserID As Integer = My.Settings.userID
    Dim databaseAccessObject As New DatabaseAccesClass
    Dim originalLName As String


    Private Sub insertLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'For Displaying the gridview
        locationData.Font = New Font("Gadugi", 10)
        locationData.DataSource = getLocationsData("")
        locationData.Columns(0).Visible = False
        locationData.Columns(1).Width = 130
        locationData.Columns(2).Width = 145
        locationData.Columns(4).Width = 70
        '***************************

        'For Initializin the Form
        disableBtn(updateBtn)

        '************************

    End Sub

    'Fill GridView
    Private Function getLocationsData(searchedText As String) As DataTable

        Dim dt As New DataTable


        If searchedText = String.Empty Then

            dt = databaseAccessObject.SelectMethode("Select ID, LocationCodeID as [Location ID], Name as [Location Name], Block, Floor from db_owner.tbl_location where Status = 1")

        ElseIf searchedText <> String.Empty Then

            dt = databaseAccessObject.SelectMethode("Select ID, LocationCodeID as [Location ID], Name as [Location Name], Block, Floor from db_owner.tbl_location WHERE Name LIKE'%" + searchedText + "%' and Status = 1")
        End If
        Return dt

    End Function

    'Submit Btn to Insert Location
    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        Dim dt As New DataTable
        dt = databaseAccessObject.SelectMethode("Select Name from db_owner.tbl_location")



        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        If (locationIDField.TextLength <> 0 And locationNameField.TextLength <> 0 And locationBlockField.TextLength <> 0 And locationFloorField.TextLength <> 0) Then

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("Name").ToString()).ToLower = (locationNameField.Text).ToLower Then
                    MessageBox.Show("Location already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim today As Date = Date.Now
            Dim query As String = String.Empty
            query &= "INSERT INTO db_owner.tbl_location (LocationCodeID, Name, Block, Floor, Status, CreateUserID, CreateDate, RevisionUserID, RevisionDate)"
            query &= "VALUES (@LocationCodeID, @Name, @Block, @Floor, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@LocationCodeID", locationIDField.Text.ToString())
                    .Parameters.AddWithValue("@Name", locationNameField.Text)
                    .Parameters.AddWithValue("@Block", locationBlockField.Text.ToString())
                    .Parameters.AddWithValue("@Floor", locationFloorField.Text)
                    .Parameters.AddWithValue("@Status", 1)
                    .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                    .Parameters.AddWithValue("@CreateDate", today)
                    .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                    .Parameters.AddWithValue("@RevisionDate", today)
                End With
                conn.Open()
                comm.ExecuteNonQuery()

                locationIDField.Clear()
                locationNameField.Clear()
                locationBlockField.Clear()
                locationFloorField.Clear()

                locationData.DataSource = getLocationsData("")
                conn.Close()

            End Using
        Else
            MessageBox.Show("Make Sure you Entered Valid Values", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub

    'on NameSearch textChange
    Private Sub nameSearch_TextChanged(sender As Object, e As EventArgs) Handles nameSearch.TextChanged
        locationData.DataSource = getLocationsData(nameSearch.Text)
    End Sub

    'On cell click in gridview
    Private Sub locationData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles locationData.CellClick




        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        If (i >= 0 AndAlso i < locationData.Rows.Count - 1) Then
            disableBtn(submitBtn)
            enableBtn(updateBtn)

            selectedRow = locationData.Rows(i)
            retrievedID = selectedRow.Cells(0).Value.ToString()
            locationIDField.Text = selectedRow.Cells(1).Value.ToString()
            locationNameField.Text = selectedRow.Cells(2).Value.ToString()
            locationBlockField.Text = selectedRow.Cells(3).Value.ToString()
            locationFloorField.Text = selectedRow.Cells(4).Value.ToString()
            originalLName = locationFloorField.Text
        End If



    End Sub


    'Cancel btn and initialize form
    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click

        locationIDField.Clear()
        locationNameField.Clear()
        locationBlockField.Clear()
        locationFloorField.Clear()

        enableBtn(submitBtn)
        disableBtn(updateBtn)
    End Sub

    'Update the selected location
    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click

        Dim dt As New DataTable

        If (locationIDField.TextLength <> 0 And locationNameField.TextLength <> 0 And locationBlockField.TextLength <> 0 And locationFloorField.TextLength <> 0) Then

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("Name").ToString()).ToLower = (locationNameField.Text).ToLower And originalLName.ToLower <> (locationNameField.Text).ToLower Then
                    MessageBox.Show("Location already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()



            Try

                conn.Open()

                myCommand.CommandText = "Update db_owner.tbl_location Set LocationCodeID = '" & locationIDField.Text & "', Name = '" & locationNameField.Text & "', Block = '" & locationBlockField.Text & "', Floor = '" & locationFloorField.Text & "', RevisionUserID = '" & logedInUserID & "', RevisionDate = '" & Today & "'  where (ID = '" & retrievedID & "')"
                rows = myCommand.ExecuteNonQuery()

            Catch ex As SqlException


                ' handle error
                Console.Write("Unable to Add")


            Finally
                locationIDField.Clear()
                locationNameField.Clear()
                locationBlockField.Clear()
                locationFloorField.Clear()

                locationData.DataSource = getLocationsData("")
                conn.Close()

            End Try

        Else
            MessageBox.Show("Make sure you Entered Valid Values", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        enableBtn(submitBtn)
        disableBtn(updateBtn)
    End Sub


    'Clear the Search
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nameSearch.Text = ""
        locationData.DataSource = getLocationsData("")
    End Sub

    'Enable and disable btns Finctions
    Private Sub disableBtn(someBtn As Button)
        someBtn.Enabled = False
        someBtn.BackColor = Color.LightGray
    End Sub
    Private Sub enableBtn(someBtn As Button)
        someBtn.Enabled = True
        someBtn.BackColor = Color.DarkRed
    End Sub

    Private Sub locationGroupBox_Enter(sender As Object, e As EventArgs) Handles locationGroupBox.Enter

    End Sub
End Class