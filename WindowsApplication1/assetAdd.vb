Imports System.Data.SqlClient

Public Class assetAdd



    Dim DataBaseClass As New DatabaseAccesClass
    Dim retrievedID As Integer
    Dim logedInUserID As Integer = My.Settings.userID
    Dim retrievedClassID As Integer
    Dim sqlQuery As String
    Dim objgroupID As Integer
    Dim className As String
    Dim databaseAccessObject As New DatabaseAccesClass
    Dim list As List(Of KeyValuePair(Of String, Integer)) =
                       New List(Of KeyValuePair(Of String, Integer))
    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
    Dim originalIName As String

    Private Sub addAsset_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Gettig available groups into the DropDown List
        getClasses()
        '********************

        'For Displaying the grid view
        itemData.Font = New Font("Gadugi", 8)
        itemData.DataSource = getItemData()
        itemData.Columns(0).Visible = False
        '******************************

        'Initializing Form
        disableBtn(updateBtn)




    End Sub

    ' Get Classes
    Sub getClasses()

        itemClassField.Items.Clear()
        list.Clear()

        Dim dt As New DataTable
        dt = databaseAccessObject.SelectMethode("Select * from db_owner.tbl_asset_class where Status = 1")

        For i = 0 To dt.Rows.Count - 1
            itemClassField.Items.Add(dt.Rows(i)("ClassName").ToString())
            list.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("ClassName").ToString(), dt.Rows(i)("ID").ToString()))

        Next

        autoCompleteClasses()

    End Sub


    Sub autoCompleteClasses()


        Dim dt As New DataTable
        dt = databaseAccessObject.SelectMethode("Select * from db_owner.tbl_asset_class where Status = 1")

        Dim row As DataRow = dt.NewRow()

        dt.Rows.InsertAt(row, 0)


        itemClassField.DataSource = dt
        itemClassField.DisplayMember = "ClassName"
        itemClassField.ValueMember = "ClassName"


        itemClassField.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        itemClassField.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub
    Private Function getItemData() As DataTable

        Dim dt As New DataTable



        dt = databaseAccessObject.SelectMethode("SELECT tbl_asset.ID, tbl_asset.assetID as [Asset ID], tbl_asset.assetName as [Asset Name],
            tbl_asset.AssetClass as [Class Name] FROM db_owner.tbl_asset, db_owner.tbl_asset_class 
            where (tbl_asset.classID = tbl_asset_class.ID and  tbl_asset.assetName LIKE'%" + nameSearch.Text + "%' and tbl_asset.Status = 1)")
        Return dt

    End Function

    'Enable and disable Btns
    Private Sub disableBtn(someBtn As Button)
        someBtn.Enabled = False
        someBtn.BackColor = Color.LightGray
    End Sub
    Private Sub enableBtn(someBtn As Button)
        someBtn.Enabled = True
        someBtn.BackColor = Color.DarkRed
    End Sub

    Private Sub nameSearch_TextChanged(sender As Object, e As EventArgs) Handles nameSearch.TextChanged

        'For Displaying the grid view
        itemData.Font = New Font("Gadugi", 8)
        itemData.DataSource = getItemData()
        itemData.Columns(0).Visible = False
        '******************************

        'Initializing Form
        disableBtn(updateBtn)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        nameSearch.Text = String.Empty

        'For Displaying the grid view
        itemData.Font = New Font("Gadugi", 8)
        itemData.DataSource = getItemData()
        itemData.Columns(0).Visible = False
        '******************************

        'Initializing Form
        disableBtn(updateBtn)
        enableBtn(submitBtn)
    End Sub

    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        Dim dtGroups As New DataTable
        Dim dt As New DataTable
        Dim theAssetNamePrefix As String = String.Empty


        If (itemIDField.TextLength <> 0 And itemNameField.TextLength <> 0 And itemClassField.Text <> String.Empty) Then

            theAssetNamePrefix = (itemNameField.Text).Substring(0, 2)

            Dim checkDt As New DataTable
            checkDt = databaseAccessObject.SelectMethode("Select prefix from db_owner.tbl_asset where prefix LIKE '" & theAssetNamePrefix & "%'")

            If checkDt.Rows.Count > 0 Then

                theAssetNamePrefix = theAssetNamePrefix + (checkDt.Rows.Count).ToString

            End If

            theAssetNamePrefix = theAssetNamePrefix.ToUpper
            dt = databaseAccessObject.SelectMethode("SELECT assetName FROM db_owner.tbl_asset")

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("assetName").ToString()).ToLower = (itemNameField.Text).ToLower Then
                    MessageBox.Show("Item already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            retrievedClassID = 0
            For Each pair As KeyValuePair(Of String, Integer) In list

                Dim key As String = pair.Key
                If key = itemClassField.Text Then
                    retrievedClassID = pair.Value

                End If
            Next

            If retrievedClassID = 0 Then
                MessageBox.Show("No Such Class Found", "Class Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            Dim today As Date = Date.Now
            Dim query As String = String.Empty
            query &= "INSERT INTO db_owner.tbl_asset (assetID, assetName, AssetClass, classID, prefix, Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
            query &= "VALUES (@assetID, @assetName,@AssetClass,@classID, @prefix, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@assetID", itemIDField.Text.ToString())
                    .Parameters.AddWithValue("@assetName", itemNameField.Text)
                    .Parameters.AddWithValue("@AssetClass", itemClassField.Text)
                    .Parameters.AddWithValue("@classID", retrievedClassID)
                    .Parameters.AddWithValue("@prefix", theAssetNamePrefix)
                    .Parameters.AddWithValue("@Status", 1)
                    .Parameters.AddWithValue("@CreateUserID", logedInUserID)
                    .Parameters.AddWithValue("@CreateDate", today)
                    .Parameters.AddWithValue("@RevisionUserID", logedInUserID)
                    .Parameters.AddWithValue("@RevisionDate", today)
                End With
                conn.Open()
                comm.ExecuteNonQuery()

                itemIDField.Clear()
                itemNameField.Clear()
                itemClassField.Text = "Select Class Name"

                itemData.DataSource = getItemData()
                conn.Close()

            End Using
        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)



        End If
        nameSearch.Text = String.Empty

    End Sub

    Private Sub itemData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles itemData.CellClick

        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        Dim classID As Integer = 0
        If (i >= 0 AndAlso i < itemData.Rows.Count - 1) Then
            disableBtn(submitBtn)
            enableBtn(updateBtn)
            selectedRow = itemData.Rows(i)
            retrievedID = selectedRow.Cells(0).Value.ToString()
            itemIDField.Text = selectedRow.Cells(1).Value.ToString()
            itemNameField.Text = selectedRow.Cells(2).Value.ToString()
            className = selectedRow.Cells(3).Value.ToString()

            retrievedClassID = 0
            For Each pair As KeyValuePair(Of String, Integer) In list

                Dim key As String = pair.Key
                If key = itemClassField.Text Then
                    retrievedClassID = pair.Value

                End If
            Next

            classID = retrievedClassID
            itemClassField.Text = className
            originalIName = selectedRow.Cells(2).Value.ToString()



        End If

    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click


        Dim today As Date = Date.Now
        Dim dt As New DataTable

        If (itemIDField.TextLength <> 0 And itemNameField.TextLength <> 0 And itemClassField.Text <> String.Empty) Then

            dt = databaseAccessObject.SelectMethode("SELECT assetName FROM db_owner.tbl_asset")

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("assetName").ToString()).ToLower = (itemNameField.Text).ToLower And originalIName.ToLower <> (itemNameField.Text).ToLower Then
                    MessageBox.Show("Item already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            retrievedClassID = 0
            For Each pair As KeyValuePair(Of String, Integer) In list

                Dim key As String = pair.Key
                If key = itemClassField.Text Then
                    retrievedClassID = pair.Value

                End If
            Next

            If retrievedClassID = 0 Then


                MessageBox.Show("No Such Class Found", "Class Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()
            'Console.Write(" THE RETRIEVEDID " & retrievedGroupID & " AND THE ID " & retrievedID)
            Try

                conn.Open()

                myCommand.CommandText = "Update db_owner.tbl_asset Set assetID = '" & itemIDField.Text & "', assetName = '" & itemNameField.Text & "' ,
                classID = '" & retrievedClassID & "',AssetClass = '" & itemClassField.Text & "',RevisionUserID = '" & logedInUserID & "',RevisionDate = '" & today & "' where (ID = '" & retrievedID & "')"
                rows = myCommand.ExecuteNonQuery()

            Catch ex As SqlException


                ' handle error
                Console.Write("Unable to Add")


            Finally
                itemIDField.Clear()
                itemNameField.Clear()
                itemClassField.Text = "Select Class Name"
                conn.Close()

                itemData.Font = New Font("Gadugi", 8)
                itemData.DataSource = getItemData()
                itemData.Columns(0).Visible = False


            End Try

        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        enableBtn(submitBtn)
        disableBtn(updateBtn)
        nameSearch.Text = String.Empty

    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click

        itemIDField.Clear()
        itemNameField.Clear()
        itemClassField.Text = "Select Class Name"
        conn.Close()

        itemData.Font = New Font("Gadugi", 8)
        itemData.DataSource = getItemData()
        itemData.Columns(0).Visible = False

        enableBtn(submitBtn)
        disableBtn(updateBtn)
        nameSearch.Text = String.Empty

    End Sub
End Class