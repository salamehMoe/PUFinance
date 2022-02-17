
Public Class HomeIndex

    Dim dataBaseObject As New DatabaseAccesClass


    Private Sub HomeIndex_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Finalize()

    End Sub

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click

        If Me.ActiveMdiChild IsNot Home Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then

                    MdiChild.Close()
                End If
            Next

        End If

        Dim inventoryIndex = New Home()
        inventoryIndex.Show()
        Me.Finalize()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Me.ActiveMdiChild IsNot Home Then
            For Each MdiChild In Me.MdiChildren
                If MdiChild Is ActiveMdiChild Then
                    MdiChild.Close()
                End If
            Next

        End If

        Dim fixedAstHome = New fixedAstHome()
        fixedAstHome.Show()
        Me.Finalize()

    End Sub
End Class