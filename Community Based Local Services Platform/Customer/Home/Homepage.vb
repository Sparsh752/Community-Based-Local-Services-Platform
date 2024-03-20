Public Class Homepage
    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' here you have to add the logic of checking the shared variable for current user
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class