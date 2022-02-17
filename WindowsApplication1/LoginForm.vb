
Imports System.Data.SqlClient
Public Class loginForm
    Private borderColor As Color = Color.DarkRed
    Private borderWidth As Integer = 1
    Private formRegion As Rectangle
    Dim retrievedID As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'For Form Design
        formRegion = New Rectangle(0, 0, 300, 400)
        '******************

        'retrieve user and Pass if Saved before
        If My.Settings.checked = True Then

            userNameField.Text = My.Settings.username
            passwordField.Text = My.Settings.password
            rememberCheckBox.Checked = True

        Else

            userNameField.Text = ""
            passwordField.Text = ""
            rememberCheckBox.Checked = False
        End If
        '*************************************
    End Sub

    Private Sub Form1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        'Form Design
        ControlPaint.DrawBorder(e.Graphics, formRegion, borderColor, _
        borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, _
        ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, _
        borderColor, borderWidth, ButtonBorderStyle.Solid)
        '***************
    End Sub

    'On "X" Clicked
    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        Close()

    End Sub
    '*******************

    'After Login Pressed
    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        Dim conn As New SqlConnection("Data Source=GENAPPSSERVER;Initial Catalog= FinanceDB;User ID = sa ; Password=Pu@2016S75#!; Max Pool Size=5000000;")

        'Checks if User and Pass are found and are correct
        If userNameField.Text <> String.Empty And passwordField.Text <> String.Empty Then

            Dim command As New SqlCommand("SELECT * FROM db_owner.tbl_users WHERE UserName = @UserName and Password = @Password", conn)
            Dim adapter As New SqlDataAdapter(command)

            command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userNameField.Text
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = passwordField.Text

            Dim table As New DataTable()

            adapter.Fill(table)
            If table.Rows.Count() > 0 Then


                retrievedID = table.Rows(0).Item("ID").ToString
                My.Settings.userID = retrievedID

                'Save the User and Password if rember me is Checked
                If rememberCheckBox.Checked = True Then
                    My.Settings.checked = True
                    My.Settings.username = userNameField.Text
                    My.Settings.password = passwordField.Text
                    My.Settings.Save()

                Else
                    My.Settings.checked = False
                    My.Settings.username = ""
                    My.Settings.password = ""
                    My.Settings.Save()

                End If
                '*************************************************

                'NAvigate to index if Access is Allowed
                Dim index = New HomeIndex()
                index.Show()
                Me.Finalize()


            ElseIf table.Rows.Count() <= 0 Then
                MsgBox("Invalid Username or Password. Make sure you entered the right credentials")
            End If
            '********************************************

            conn.Close()

            'If Any field is empty
        ElseIf userNameField.Text = String.Empty Or passwordField.Text = String.Empty Then
                MessageBox.Show("Make sure you filled the required fields", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        '********************


    End Sub

    Private Sub loginForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            loginBtn_Click(sender, e)
        End If
    End Sub
End Class
