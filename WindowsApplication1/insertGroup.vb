Imports System.Data.SqlClient
Public Class insertGroup

    Dim retrievedID As Integer
    Dim logedInUserID As Integer = My.Settings.userID
    Dim databaseAccessObject As New DatabaseAccesClass
    Dim originalGName As String


    Private Sub insertGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Disabling btns and initializing groupData 
        groupData.Font = New Font("Gadugi", 15)
        groupData.DataSource = getGroupsData()
        groupData.Columns(0).Visible = False
        groupData.Columns(1).Width = 127
        groupData.Columns(2).Width = 200

        disableBtn(updateBtn)

        '****************************************
    End Sub


    'Function for Filling the Group GridView
    Private Function getGroupsData() As DataTable

        Dim dt As New DataTable
        dt = databaseAccessObject.SelectMethode("SELECT ID, GroupCodeID as [Group ID], GroupName as [Name] FROM db_owner.tbl_group WHERE GroupName like '%" + groupSearch.Text + "%' and Status = 1")
        'If searchedText = String.Empty Then
        '    dt = databaseAccessObject.SelectMethode("SELECT ID , GroupCodeID as [Group ID], GroupName as [Name] FROM db_owner.tbl_group")

        'ElseIf searchedText <> String.Empty Then


        'End If
        Return dt

    End Function
    '****************************************

    'Submit the group data to database table
    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim dt As New DataTable
        dt = databaseAccessObject.SelectMethode("Select GroupName FROM db_owner.tbl_group")


        If (groupIDTextField.TextLength <> 0 And groupNameTextField.TextLength <> 0) Then

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("GroupName").ToString()).ToLower = (groupNameTextField.Text).ToLower Then
                    MessageBox.Show("Group already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim today As Date = Date.Now
            Dim query As String = String.Empty
            query &= "INSERT INTO db_owner.tbl_group (GroupCodeID, GroupName, Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
            query &= "VALUES (@GroupCodeID, @GrouprName, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@GroupCodeID", groupIDTextField.Text.ToString())
                    .Parameters.AddWithValue("@GrouprName", groupNameTextField.Text)
                    .Parameters.AddWithValue("@Status", 1)
                    .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                    .Parameters.AddWithValue("@CreateDate", today)
                    .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                    .Parameters.AddWithValue("@RevisionDate", today)
                End With
                conn.Open()
                comm.ExecuteNonQuery()

                groupIDTextField.Clear()
                groupNameTextField.Clear()
                groupData.DataSource = getGroupsData()
                conn.Close()

            End Using
        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub
    ''''''''''''''''''''''''''''''''''''''''''

    'After search broup field Change
    Private Sub groupSearch_TextChanged(sender As Object, e As EventArgs) Handles groupSearch.TextChanged
        groupData.DataSource = getGroupsData()
    End Sub

    'After cell click in the grid view
    Private Sub groupData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles groupData.CellClick
        disableBtn(submitBtn)

        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        If (i >= 0 AndAlso i < groupData.Rows.Count - 1) Then
            enableBtn(updateBtn)

            enableBtn(cancelBtn)
            selectedRow = groupData.Rows(i)
            retrievedID = selectedRow.Cells(0).Value.ToString()
            groupIDTextField.Text = selectedRow.Cells(1).Value.ToString()
            groupNameTextField.Text = selectedRow.Cells(2).Value.ToString()
            originalGName = selectedRow.Cells(2).Value.ToString()
        End If
    End Sub


    'After Change on GroupId and Group Name Fields
    Private Sub groupIDTextField_TextChanged(sender As Object, e As EventArgs) Handles groupIDTextField.TextChanged
        enableBtn(cancelBtn)
    End Sub

    Private Sub groupNameTextField_TextChanged(sender As Object, e As EventArgs) Handles groupNameTextField.TextChanged
        enableBtn(cancelBtn)
    End Sub
    ''''''''''''''''''''''''''''''''''''''''''''''''''''

    'Initializing Window after Cancel is clicked
    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        groupIDTextField.Clear()
        groupNameTextField.Clear()
        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub
    ''''''''''''''''''''''''''''''''''''''''''''''''

    'Update the selected record
    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        If (groupIDTextField.TextLength <> 0 And groupNameTextField.TextLength <> 0) Then

            Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            Dim dt As New DataTable
            dt = databaseAccessObject.SelectMethode("Select GroupName FROM db_owner.tbl_group")

            For i As Integer = 0 To dt.Rows.Count - 1
                '
                If (dt.Rows(i)("GroupName").ToString()).ToLower = (groupNameTextField.Text).ToLower And originalGName.ToLower <> (groupNameTextField.Text).ToLower Then
                    MessageBox.Show("Group already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()



            Try

                conn.Open()

                myCommand.CommandText = "Update db_owner.tbl_group Set GroupCodeID = '" & groupIDTextField.Text & "', GroupName = '" & groupNameTextField.Text & "', RevisionUserID = '" & logedInUserID & "', RevisionDate = '" & Today & "'  where (ID = '" & retrievedID & "')"
                rows = myCommand.ExecuteNonQuery()

            Catch ex As SqlException


                ' handle error
                Console.Write("Unable to Add")


            Finally
                groupIDTextField.Clear()
                groupNameTextField.Clear()

                groupData.DataSource = getGroupsData()
                conn.Close()

            End Try

        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub
    ''''''''''''''''''''''''''''''''''''''''''

    'Disabling and Enabling Buttons Functions
    Private Sub disableBtn(someBtn As Button)
        someBtn.Enabled = False
        someBtn.BackColor = Color.LightGray
    End Sub
    Private Sub enableBtn(someBtn As Button)
        someBtn.Enabled = True
        someBtn.BackColor = Color.DarkRed
    End Sub
    ''''''''''''''''''''''''''''''''''''''''''
    'Cancel the search and show all group data
    Private Sub cancelSearch_Click(sender As Object, e As EventArgs) Handles cancelSearch.Click
        groupSearch.Text = ""
        groupData.DataSource = getGroupsData()
    End Sub
    ''''''''''''''''''''''''''''''''''''''''''
End Class