Imports System.Data.SqlClient
Public Class assetLocationAdd

    Dim retrievedID As Integer
    Dim logedInUserID As Integer = My.Settings.userID
    Dim databaseAccessObject As New DatabaseAccesClass
    Dim originalLName As String

    Private Sub assetLocationAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'For Displaying the gridview
        locationData.Font = New Font("Gadugi", 10)
        locationData.DataSource = getLocationsData()
        locationData.Columns(0).Visible = False
        locationData.Columns(1).Width = 130
        locationData.Columns(2).Width = 130
        '***************************

        'For Initializin the Form
        disableBtn(updateBtn)

        '************************

    End Sub

    Private Function getLocationsData() As DataTable

        Dim dt As New DataTable

        dt = databaseAccessObject.SelectMethode("Select ID, LocationID as [Location ID], LocationName as [Location Name]
        from db_owner.tbl_asset_Location where Status = 1 and LocationName LIKE  '%" & nameSearch.Text & "%'")

        Return dt

    End Function

    'Enable and disable btns Finctions
    Private Sub disableBtn(someBtn As Button)
        someBtn.Enabled = False
        someBtn.BackColor = Color.LightGray
    End Sub
    Private Sub enableBtn(someBtn As Button)
        someBtn.Enabled = True
        someBtn.BackColor = Color.DarkRed
    End Sub

    Private Sub nameSearch_TextChanged(sender As Object, e As EventArgs) Handles nameSearch.TextChanged


        'For Displaying the gridview
        locationData.Font = New Font("Gadugi", 10)
        locationData.DataSource = getLocationsData()
        locationData.Columns(0).Visible = False
        locationData.Columns(1).Width = 130
        locationData.Columns(2).Width = 130
        '***************************


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        nameSearch.Text = String.Empty
        'For Displaying the gridview
        locationData.Font = New Font("Gadugi", 10)
        locationData.DataSource = getLocationsData()
        locationData.Columns(0).Visible = False
        locationData.Columns(1).Width = 130
        locationData.Columns(2).Width = 130
        '***************************
    End Sub

    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        Dim dt As New DataTable
        dt = databaseAccessObject.SelectMethode("Select LocationName from db_owner.tbl_asset_location")



        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
        If (assetLocationIDField.TextLength <> 0 And assetLocationNameField.TextLength <> 0) Then

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("LocationName").ToString()).ToLower = (assetLocationNameField.Text).ToLower Then
                    MessageBox.Show("Location already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim today As Date = Date.Now
            Dim query As String = String.Empty
            query &= "INSERT INTO db_owner.tbl_asset_location (LocationID, LocationName, Status, CreateUserID, CreateDate, RevisionUserID, RevisionDate)"
            query &= "VALUES (@LocationID, @LocationName, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@LocationID", assetLocationIDField.Text.ToString())
                    .Parameters.AddWithValue("@LocationName", assetLocationNameField.Text)
                    .Parameters.AddWithValue("@Status", 1)
                    .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                    .Parameters.AddWithValue("@CreateDate", today)
                    .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                    .Parameters.AddWithValue("@RevisionDate", today)
                End With
                conn.Open()
                comm.ExecuteNonQuery()

                nameSearch.Text = String.Empty
                'For Displaying the gridview
                locationData.Font = New Font("Gadugi", 10)
                locationData.DataSource = getLocationsData()
                locationData.Columns(0).Visible = False
                locationData.Columns(1).Width = 130
                locationData.Columns(2).Width = 130
                '***************************

                conn.Close()

            End Using
        Else
            MessageBox.Show("Make Sure you Entered Valid Values", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        assetLocationIDField.Clear()
        assetLocationNameField.Clear()

        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click

        assetLocationIDField.Clear()
        assetLocationNameField.Clear()

        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub

    Private Sub locationData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles locationData.CellClick

        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        If (i >= 0 AndAlso i < locationData.Rows.Count - 1) Then
            disableBtn(submitBtn)
            enableBtn(updateBtn)

            selectedRow = locationData.Rows(i)
            retrievedID = selectedRow.Cells(0).Value.ToString()
            assetLocationIDField.Text = selectedRow.Cells(1).Value.ToString()
            assetLocationNameField.Text = selectedRow.Cells(2).Value.ToString()

            originalLName = selectedRow.Cells(2).Value.ToString()

        End If

    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click


        Dim dt As New DataTable

        If (assetLocationIDField.TextLength <> 0 And assetLocationNameField.TextLength <> 0) Then

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("LocationName").ToString()).ToLower = (assetLocationNameField.Text).ToLower And originalLName.ToLower <> (assetLocationNameField.Text).ToLower Then
                    MessageBox.Show("Location already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()



            Try

                conn.Open()

                myCommand.CommandText = "Update db_owner.tbl_asset_Location Set LocationID = '" & assetLocationIDField.Text & "',
                LocationName = '" & assetLocationNameField.Text & "', RevisionUserID = '" & logedInUserID & "', RevisionDate = '" & Today & "'
                where (ID = '" & retrievedID & "')"
                rows = myCommand.ExecuteNonQuery()

            Catch ex As SqlException


                ' handle error
                Console.Write("Unable to Add")


            Finally
                assetLocationIDField.Clear()
                assetLocationNameField.Clear()


                'For Displaying the gridview
                locationData.Font = New Font("Gadugi", 10)
                locationData.DataSource = getLocationsData()
                locationData.Columns(0).Visible = False
                locationData.Columns(1).Width = 130
                locationData.Columns(2).Width = 130
                '***************************

                conn.Close()

            End Try

        Else
            MessageBox.Show("Make sure you Entered Valid Values", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub
End Class