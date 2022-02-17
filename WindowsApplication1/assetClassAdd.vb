Imports System.Data.SqlClient
Public Class assetClassAdd

    Dim dataBaseObj As New DatabaseAccesClass
    Dim logedInUserID As Integer = My.Settings.userID
    Dim retrievedID As Integer = 0
    Dim originalGName As String
    Private Sub assetClassAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Getting Class DataGridView 
        assetClassData.DataSource = getClassData()
        assetClassData.Font = New Font("Gadugi", 11)

        assetClassData.Columns(0).Visible = False

        assetClassData.Columns(1).Width = 100
        assetClassData.Columns(2).Width = 130
        assetClassData.Columns(3).Width = 140
        assetClassData.Columns(4).Width = 140


        disableBtn(updateBtn)

        '****************************************


    End Sub

    Function getClassData()

        Dim dt As New DataTable

        dt = dataBaseObj.SelectMethode("SELECT ID,ClassID as [Class ID],ClassName as [Class Name],AssetYearsRemaining as [Rmaining Useful Years],
        AssetDaysRemaining as [Remaining Useful Days] FROM db_owner.tbl_asset_class WHERE ClassName like '%" + assetClassSearch.Text + "%' and Status = 1")

        Return dt

    End Function


    'Disabling and Enabling Buttons Functions
    Private Sub disableBtn(someBtn As Button)
        someBtn.Enabled = False
        someBtn.BackColor = Color.LightGray
    End Sub
    Private Sub enableBtn(someBtn As Button)
        someBtn.Enabled = True
        someBtn.BackColor = Color.DarkRed
    End Sub

    Private Sub assetClassSearch_TextChanged(sender As Object, e As EventArgs) Handles assetClassSearch.TextChanged

        assetClassData.DataSource = getClassData()
        assetClassData.Font = New Font("Gadugi", 11)

        assetClassData.Columns(0).Visible = False

        assetClassData.Columns(1).Width = 100
        assetClassData.Columns(2).Width = 130
        assetClassData.Columns(3).Width = 140
        assetClassData.Columns(4).Width = 140

    End Sub

    Private Sub cancelSearch_Click(sender As Object, e As EventArgs) Handles cancelSearch.Click
        assetClassSearch.Text = String.Empty
        assetClassData.DataSource = getClassData()
        assetClassData.Font = New Font("Gadugi", 11)

        assetClassData.Columns(0).Visible = False

        assetClassData.Columns(1).Width = 100
        assetClassData.Columns(2).Width = 130
        assetClassData.Columns(3).Width = 140
        assetClassData.Columns(4).Width = 140
    End Sub

    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        Dim dt As New DataTable
        dt = dataBaseObj.SelectMethode("Select ClassName FROM db_owner.tbl_asset_class")


        If (classIDTextBox.TextLength <> 0 And classNameTextBox.TextLength <> 0) Then

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("ClassName").ToString()).ToLower = (classNameTextBox.Text).ToLower Then
                    MessageBox.Show("Class already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim today As Date = Date.Now
            Dim query As String = String.Empty

            query = "INSERT INTO db_owner.tbl_asset_class (ClassID, ClassName, AssetYearsRemaining, AssetDaysRemaining, Status,CreateUserID,CreateDate,
                     RevisionUserID,RevisionDate) VALUES (@ClassID, @ClassName, @AssetYearsRemaining, @AssetDaysRemaining,
                     @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ClassID", classIDTextBox.Text.ToString())
                    .Parameters.AddWithValue("@ClassName", classNameTextBox.Text)
                    .Parameters.AddWithValue("@AssetYearsRemaining", assetYearTextBox.Text.ToString())
                    .Parameters.AddWithValue("@AssetDaysRemaining", assetDaysTextBox.Text.ToString())
                    .Parameters.AddWithValue("@Status", 1)
                    .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                    .Parameters.AddWithValue("@CreateDate", today)
                    .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                    .Parameters.AddWithValue("@RevisionDate", today)
                End With
                conn.Open()
                comm.ExecuteNonQuery()

                classIDTextBox.Clear()
                classNameTextBox.Clear()
                assetYearTextBox.Clear()
                assetDaysTextBox.Clear()

                assetClassSearch.Text = String.Empty
                assetClassData.DataSource = getClassData()
                assetClassData.Font = New Font("Gadugi", 11)

                assetClassData.Columns(0).Visible = False

                assetClassData.Columns(1).Width = 100
                assetClassData.Columns(2).Width = 130
                assetClassData.Columns(3).Width = 140
                assetClassData.Columns(4).Width = 140

                conn.Close()

            End Using
        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Sub assetClassData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles assetClassData.CellClick

        disableBtn(submitBtn)

        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        If (i >= 0 AndAlso i < assetClassData.Rows.Count - 1) Then

            enableBtn(updateBtn)
            enableBtn(cancelBtn)

            selectedRow = assetClassData.Rows(i)
            retrievedID = selectedRow.Cells(0).Value.ToString()
            classIDTextBox.Text = selectedRow.Cells(1).Value.ToString()
            classNameTextBox.Text = selectedRow.Cells(2).Value.ToString()
            assetYearTextBox.Text = selectedRow.Cells(3).Value.ToString()
            assetDaysTextBox.Text = selectedRow.Cells(4).Value.ToString()
            originalGName = selectedRow.Cells(2).Value.ToString()

        End If

    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click

        classIDTextBox.Clear()
        classNameTextBox.Clear()
        assetYearTextBox.Clear()
        assetDaysTextBox.Clear()

        assetClassSearch.Text = String.Empty
        assetClassData.DataSource = getClassData()
        assetClassData.Font = New Font("Gadugi", 11)

        assetClassData.Columns(0).Visible = False

        assetClassData.Columns(1).Width = 100
        assetClassData.Columns(2).Width = 130
        assetClassData.Columns(3).Width = 140
        assetClassData.Columns(4).Width = 140

        enableBtn(submitBtn)
        disableBtn(updateBtn)

    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click

        If (classIDTextBox.TextLength <> 0 And classNameTextBox.TextLength <> 0) Then

            Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

            Dim dt As New DataTable
            dt = dataBaseObj.SelectMethode("Select ClassName FROM db_owner.tbl_asset_class")

            For i As Integer = 0 To dt.Rows.Count - 1
                '
                If (dt.Rows(i)("ClassName").ToString()).ToLower = (classNameTextBox.Text).ToLower And originalGName.ToLower <> (classNameTextBox.Text).ToLower Then
                    MessageBox.Show("Class already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()



            Try

                conn.Open()

                myCommand.CommandText = "Update db_owner.tbl_asset_class Set ClassID = '" & classIDTextBox.Text & "', ClassName = '" & classNameTextBox.Text & "',
                AssetYearsRemaining = '" & assetYearTextBox.Text & "', AssetDaysRemaining = '" & assetDaysTextBox.Text & "',    RevisionUserID = '" & logedInUserID & "',
                RevisionDate = '" & Today & "'  where (ID = '" & retrievedID & "')"
                rows = myCommand.ExecuteNonQuery()

            Catch ex As SqlException


                ' handle error
                Console.Write("Unable to Add")


            Finally

                classIDTextBox.Clear()
                classNameTextBox.Clear()
                assetYearTextBox.Clear()
                assetDaysTextBox.Clear()

                assetClassSearch.Text = String.Empty
                assetClassData.DataSource = getClassData()
                assetClassData.Font = New Font("Gadugi", 11)

                assetClassData.Columns(0).Visible = False

                assetClassData.Columns(1).Width = 100
                assetClassData.Columns(2).Width = 130
                assetClassData.Columns(3).Width = 140
                assetClassData.Columns(4).Width = 140

                conn.Close()

            End Try

        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
        enableBtn(submitBtn)
        disableBtn(updateBtn)


    End Sub
    ''''''''''''''''''''''''''''''''''''''''''


End Class