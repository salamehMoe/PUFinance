Public Class CreateShortcutClass
    Public Sub CreateShortcut()
        Dim wsh As Object = CreateObject("WScript.Shell")
        wsh = CreateObject("WScript.Shell")
        Dim MyShortcut, DesktopPath
        ' Read desktop path using WshSpecialFolders object
        DesktopPath = wsh.SpecialFolders("Desktop")
        ' Create a shortcut object on the desktop
        MyShortcut = wsh.CreateShortcut(DesktopPath & "\PrintingDocuments.lnk")
        ' Set shortcut object properties and save it
        MyShortcut.TargetPath = wsh.ExpandEnvironmentStrings(Application.StartupPath + "\PrintingDocuments")
        'Save the shortcut
        MyShortcut.Save()
    End Sub
End Class