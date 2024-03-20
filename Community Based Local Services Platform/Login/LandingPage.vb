Public Class LandingPage
    Private Sub LandingPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' here you have to add the logic of checking the shared variable for current user
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
    End Sub
    Private Sub LandingPage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Ensure that the application exits when the main form is closed
        Application.Exit()
    End Sub

End Class