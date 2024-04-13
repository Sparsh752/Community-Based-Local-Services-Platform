Public Class Navbar_Admin
    ' Method to highlight the active button
    Public Panel3 As New Panel()
    Public line As New Panel()
    Private Sub Navbar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        line.BackColor = ColorTranslator.FromHtml("#F9754B")
        line.Size = New Size(52, 2)
        line.Location = New Point(954, 47)
        Panel1.Controls.Add(line)
        SessionManager.Panel3 = Panel3
        ' Highlight the Home button by default
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Panel1.BackColor = ColorTranslator.FromHtml("#0F2A37")

        Dim NotificationButton As New Button()
        NotificationButton.Size() = New Size(52, 30)
        NotificationButton.BackColor = ColorTranslator.FromHtml("#0F2A37")
        NotificationButton.Location = New Point(49, 18)
        NotificationButton.Text = "Notifications"
        NotificationButton.ForeColor = Color.White
        NotificationButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        NotificationButton.FlatStyle = FlatStyle.Flat
        NotificationButton.FlatAppearance.BorderSize = 0
        NotificationButton.Padding = New Padding(0, 0, 0, 0)
        NotificationButton.TextAlign = ContentAlignment.MiddleCenter
        NotificationButton.AutoSize = True

        Panel1.Controls.Add(NotificationButton)


        Dim NotificationIcon As New PictureBox With {
            .BackgroundImage = My.Resources.Resource1.notification_icon,
            .Location = New Point(155, 25),
            .Name = "NotificationIcon",
            .Size = New Size(17, 18),
            .TabIndex = 1,
            .TabStop = False
        }
        Panel1.Controls.Add(NotificationIcon)

        Dim NotificationBadge As New PictureBox With {
            .BackgroundImage = My.Resources.Resource1.notification_badge,
            .Location = New Point(168, 20),
            .Name = "NotificationIcon",
            .Size = New Size(7, 7),
            .TabIndex = 1,
            .TabStop = False
        }

        Panel1.Controls.Add(NotificationBadge)
        NotificationBadge.BringToFront()
        NotificationBadge.Visible = False

        Dim HomeButton As New Button()
        HomeButton.Size() = New Size(52, 30)

        HomeButton.BackColor = ColorTranslator.FromHtml("#0F2A37")
        HomeButton.Location = New Point(951, 18)
        HomeButton.Text = "Home"
        HomeButton.ForeColor = Color.White
        HomeButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        HomeButton.FlatStyle = FlatStyle.Flat
        HomeButton.FlatAppearance.BorderSize = 0
        HomeButton.Padding = New Padding(0, 0, 0, 0)
        HomeButton.TextAlign = ContentAlignment.MiddleCenter
        HomeButton.AutoSize = True

        Panel1.Controls.Add(HomeButton)

        AddHandler HomeButton.Click, AddressOf BtnHome_Click
        Me.Controls.Add(Panel3)
        Panel3.Size = New Size(1200, 700)
        Panel3.Location = New Point(0, 0)
        Panel3.BackColor = Color.Aqua
        Panel3.Padding = New Padding(0, 0, 0, 0)

        RemovePreviousForm()

        'SetActiveForm(Homepage)
        Homepage_Admin.Margin = New Padding(0, 0, 0, 0)
        With Homepage_Admin
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Admin)
            .BringToFront()
            .Show()
        End With
    End Sub
    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub



    Private Sub BtnHome_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        'SetActiveForm(Homepage)
        With Homepage_Admin
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Admin)
            .BringToFront()
            .Show()
        End With

    End Sub
    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        ' here you have add the logic of reverting the state of shared variable for cureent user to null
        ' Whoever is doing the bankend part will do this part.

        Me.Hide()

        Dim form As New LandingPage()
        form.Show()

    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Ensure that the application exits when the main form is closed
        Application.Exit()
    End Sub
End Class