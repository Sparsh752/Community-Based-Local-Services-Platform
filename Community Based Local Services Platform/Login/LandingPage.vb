Public Class LandingPage

    Dim standardFont As New Font("Montserrat", 11, FontStyle.Regular)
    Dim standardColor As Color = ColorTranslator.FromHtml("#F1F1F1")
    Private Sub LandingPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' here you have to add the logic of checking the shared variable for current user

        Panel3.BackColor = Color.White

        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        Me.Size = New Size(1200, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Label1.BackColor = ColorTranslator.FromHtml("#0F2A37")
        Label1.Size = New Size(593, 700)
        Label1.Location = New Point(0, 0)

        LoginLabel.BackColor = standardColor
        LoginLabel.Size = New Size(473, 490)
        LoginLabel.Location = New Point(661, 98)

        CustomerButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        CustomerButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        CustomerButton.Size = New Size(180, 50)
        CustomerButton.Location = New Point(807, 436)
        CustomerButton.FlatAppearance.BorderSize = 0
        CustomerButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        SPButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        SPButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        SPButton.Size = New Size(180, 50)
        SPButton.Location = New Point(807, 325)
        SPButton.FlatAppearance.BorderSize = 0
        SPButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        AdminButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        AdminButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        AdminButton.Size = New Size(180, 50)
        AdminButton.Location = New Point(807, 214)
        AdminButton.FlatAppearance.BorderSize = 0
        AdminButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        PictureBox1.Size = New Size(200, 200)
        PictureBox1.Location = New Point(200, 200)
        PictureBox1.BackColor = ColorTranslator.FromHtml("#0F2A37")

        Label7.Text = "Community Based Local Services Platform"
        Label7.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        Label7.BackColor = ColorTranslator.FromHtml("#0F2A37")
        Label7.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label7.Size = New Size(593, 147)
        Label7.Location = New Point(0, 382)
    End Sub
    Private Sub LandingPage_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Ensure that the application exits when the main form is closed
        Application.Exit()
    End Sub

    Private Sub CustomerButton_Click(sender As Object, e As EventArgs) Handles CustomerButton.Click
        SessionManager.userType = "Customer"

        Dim loginForm As New LoginPage()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub SPButton_Click(sender As Object, e As EventArgs) Handles SPButton.Click
        SessionManager.userType = "Service Provider"

        Dim loginForm As New LoginPage()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub AdminButton_Click(sender As Object, e As EventArgs) Handles AdminButton.Click
        SessionManager.userType = "Admin"

        Dim loginForm As New LoginPage()
        loginForm.Show()
        Me.Hide()
    End Sub
End Class