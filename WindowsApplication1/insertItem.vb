Imports System.Data.SqlClient
Public Class insertItem

    Dim DataBaseClass As New DatabaseAccesClass
    Dim retrievedID As Integer
    Dim logedInUserID As Integer = My.Settings.userID
    Dim retrievedGroupID As Integer
    Dim sqlQuery As String
    Dim objgroupID As Integer
    Dim groupName As String
    Dim databaseAccessObject As New DatabaseAccesClass
    Dim list As List(Of KeyValuePair(Of String, Integer)) =
                   New List(Of KeyValuePair(Of String, Integer))
    Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")
    Dim originalIName As String



    Private Sub insertItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'For Displaying the grid view
        itemData.Font = New Font("Gadugi", 8)
        itemData.DataSource = getItemData("")
        itemData.Columns(0).Visible = False
        itemData.Columns(4).Width = 160
        itemData.Columns(5).Visible = False
        '******************************

        'Initializing Form
        disableBtn(updateBtn)

        'Gettig available groups into the DropDown List
        getGroups()
        '********************

    End Sub

    'Get Available groups
    Private Sub getGroups()

        itemGroupField.Items.Clear()
        list.Clear()

        Dim dt As New DataTable
        dt = databaseAccessObject.SelectMethode("Select * from db_owner.tbl_group where Status = 1")

        For i = 0 To dt.Rows.Count - 1
                    itemGroupField.Items.Add(dt.Rows(i)("GroupName").ToString())
                    list.Add(New KeyValuePair(Of String, Integer)(dt.Rows(i)("GroupName").ToString(), dt.Rows(i)("ID").ToString()))

                Next

        autoCompleteGroups()
    End Sub

    Sub autoCompleteGroups()


        Dim dt As New DataTable
        dt = databaseAccessObject.SelectMethode("Select * from db_owner.tbl_group where Status = 1")

        Dim row As DataRow = dt.NewRow()

        dt.Rows.InsertAt(row, 0)


        itemGroupField.DataSource = dt
        itemGroupField.DisplayMember = "GroupName"
        itemGroupField.ValueMember = "GroupName"


        itemGroupField.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        itemGroupField.AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub
    'Fill grid view
    Private Function getItemData(searchedText As String) As DataTable

        Dim dt As New DataTable



        If searchedText = String.Empty Then
            dt = databaseAccessObject.SelectMethode("SELECT tbl_Item.ID, tbl_Item.ItemID as [Item ID], tbl_Item.ItemName as [Item Name], tbl_Item.MinimumQty as [Minimum Quantity],
            tbl_group.GroupName as [Group Name], tbl_group.ID as [Group ID] FROM db_owner.tbl_Item, db_owner.tbl_group where (tbl_item.GroupID = tbl_group.ID and tbl_item.Status = 1)")

        ElseIf searchedText <> String.Empty Then

            dt = databaseAccessObject.SelectMethode("SELECT tbl_Item.ID, tbl_Item.ItemID as [Item ID], tbl_Item.ItemName as [Item Name], tbl_Item.MinimumQty as [Minimum Quantity],
            tbl_group.GroupName as [Group Name], tbl_group.ID as [Group ID] FROM db_owner.tbl_Item, db_owner.tbl_group where (tbl_item.GroupID = tbl_group.ID and  tbl_Item.ItemName LIKE'%" + searchedText + "%' and tbl_item.Status = 1)")
        End If
        Return dt

    End Function





    'submit to add Item
    Private Sub submitBtn_Click(sender As Object, e As EventArgs) Handles submitBtn.Click

        Dim dtGroups As New DataTable
        Dim dt As New DataTable







        If (itemIDField.TextLength <> 0 And itemNameField.TextLength <> 0 And itemGroupField.Text <> "Select Group Name" And itemMinQty.TextLength <> 0) Then

            dt = databaseAccessObject.SelectMethode("SELECT ItemName FROM db_owner.tbl_Item")

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("ItemName").ToString()).ToLower = (itemNameField.Text).ToLower Then
                    MessageBox.Show("Item already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            retrievedGroupID = 0
            For Each pair As KeyValuePair(Of String, Integer) In list

                Dim key As String = pair.Key
                If key = itemGroupField.Text Then
                    retrievedGroupID = pair.Value

                End If
            Next

            If retrievedGroupID = 0 Then
                MessageBox.Show("No Such Group Found", "Group Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            Dim today As Date = Date.Now
            Dim query As String = String.Empty
            query &= "INSERT INTO db_owner.tbl_Item (ItemID, ItemName, GroupID, MinimumQty, Status,CreateUserID,CreateDate,RevisionUserID,RevisionDate)"
            query &= "VALUES (@ItemID, @ItemName,@GroupID, @MinimumQty, @Status, @CreateUserID, @CreateDate, @RevisionUserID, @RevisionDate)"

            Using comm As New SqlCommand()
                With comm
                    .Connection = conn
                    .CommandType = CommandType.Text
                    .CommandText = query
                    .Parameters.AddWithValue("@ItemID", itemIDField.Text.ToString())
                    .Parameters.AddWithValue("@ItemName", itemNameField.Text)
                    .Parameters.AddWithValue("@GroupID", retrievedGroupID)
                    .Parameters.AddWithValue("@MinimumQty", itemMinQty.Text)
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
                itemGroupField.Text = "Select Group Name"
                itemMinQty.Clear()


                itemData.DataSource = getItemData("")
                conn.Close()

            End Using
        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)



        End If
        nameSearch.Text = ""
    End Sub

    'on search textchange
    Private Sub nameSearch_TextChanged(sender As Object, e As EventArgs) Handles nameSearch.TextChanged
        itemData.DataSource = getItemData(nameSearch.Text)
    End Sub


    'On cell click on item grid view
    Private Sub itemData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles itemData.CellClick




        Dim i As Integer
        i = e.RowIndex
        Dim selectedRow As DataGridViewRow
        Dim groupID As Integer = 0
        If (i >= 0 AndAlso i < itemData.Rows.Count - 1) Then
            disableBtn(submitBtn)
            enableBtn(updateBtn)
            selectedRow = itemData.Rows(i)
            retrievedID = selectedRow.Cells(0).Value.ToString()
            itemIDField.Text = selectedRow.Cells(1).Value.ToString()
            itemNameField.Text = selectedRow.Cells(2).Value.ToString()
            groupName = selectedRow.Cells(4).Value.ToString()
            groupID = selectedRow.Cells(5).Value.ToString()
            originalIName = itemNameField.Text

            For Each pair As KeyValuePair(Of String, Integer) In list

                Dim value As String = pair.Value
                If value = groupID Then
                    itemGroupField.Text = pair.Key

                End If
            Next

            itemMinQty.Text = selectedRow.Cells(3).Value.ToString()

        End If

        Console.WriteLine(retrievedID)
    End Sub


    'item Quantity only numbers
    Private Sub itemMinQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles itemMinQty.KeyPress
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") _
         AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub


    'Cancel btn and initialize form
    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        itemIDField.Clear()
        itemNameField.Clear()
        itemGroupField.Text = "Select Group Name"
        itemMinQty.Clear()
        enableBtn(submitBtn)
        disableBtn(updateBtn)
        nameSearch.Text = ""
    End Sub
    'Update Btn
    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click

        Dim today As Date = Date.Now
        Dim dt As New DataTable

        If (itemIDField.TextLength <> 0 And itemNameField.TextLength <> 0 And itemGroupField.Text <> "Select Group Name" And itemMinQty.TextLength <> 0) Then

            dt = databaseAccessObject.SelectMethode("SELECT ItemName FROM db_owner.tbl_Item")

            For i As Integer = 0 To dt.Rows.Count - 1
                If (dt.Rows(i)("ItemName").ToString()).ToLower = (itemNameField.Text).ToLower And originalIName.ToLower <> (itemNameField.Text).ToLower Then
                    MessageBox.Show("Item already exist !", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            retrievedGroupID = 0
            For Each pair As KeyValuePair(Of String, Integer) In list

                Dim key As String = pair.Key
                If key = itemGroupField.Text Then
                    retrievedGroupID = pair.Value

                End If
            Next

            If retrievedGroupID = 0 Then


                MessageBox.Show("No Such Group Found", "Group Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If

            Dim rows As Integer
            Dim myCommand As SqlCommand = conn.CreateCommand()
            Console.Write(" THE RETRIEVEDID " & retrievedGroupID & " AND THE ID " & retrievedID)
            Try

                conn.Open()

                myCommand.CommandText = "Update db_owner.tbl_item Set ItemID = '" & itemIDField.Text & "', itemName = '" & itemNameField.Text & "' , GroupID = '" & retrievedGroupID & "'  , MinimumQty = '" & itemMinQty.Text & "',RevisionUserID = '" & logedInUserID & "',RevisionDate = '" & today & "' where (ID = '" & retrievedID & "')"
                rows = myCommand.ExecuteNonQuery()

            Catch ex As SqlException


                ' handle error
                Console.Write("Unable to Add")


            Finally
                itemIDField.Clear()
                itemNameField.Clear()
                itemGroupField.Text = "Select Group Name"
                itemMinQty.Clear()
                conn.Close()
                itemData.DataSource = getItemData("")


            End Try

        Else
            MessageBox.Show("You have to fill all fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If

        enableBtn(submitBtn)
        disableBtn(updateBtn)
        nameSearch.Text = ""
    End Sub

    'cancel Search
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        nameSearch.Text = ""
        itemData.DataSource = getItemData("")
    End Sub

    'Enable and disable Btns
    Private Sub disableBtn(someBtn As Button)
        someBtn.Enabled = False
        someBtn.BackColor = Color.LightGray
    End Sub
    Private Sub enableBtn(someBtn As Button)
        someBtn.Enabled = True
        someBtn.BackColor = Color.DarkRed
    End Sub


End Class