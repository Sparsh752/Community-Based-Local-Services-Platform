Public Class Navbar_Customer


    ' Variable to store the currently active form
    'Private activeForm As Form = Nothing

    ' Method to set the active form
    'Private Sub SetActiveForm(ByVal form As Form)
    '    activeForm = form
    'End Sub
    ' 0F2A37
    ' Method to highlight the active button
    Public Panel3 As New Panel()
    Private Sub Navbar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Highlight the Home button by default
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Panel1.BackColor = ColorTranslator.FromHtml("#0F2A37")
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1200, 700)
        Dim HomeButton As New Button()
        HomeButton.Size() = New Size(52, 30)

        HomeButton.BackColor = ColorTranslator.FromHtml("#0F2A37")
        HomeButton.Location = New Point(630, 18)
        HomeButton.Text = "Home"
        HomeButton.ForeColor = Color.White
        HomeButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        HomeButton.FlatStyle = FlatStyle.Flat
        HomeButton.FlatAppearance.BorderSize = 0
        HomeButton.Padding = New Padding(0, 0, 0, 0)
        HomeButton.TextAlign = ContentAlignment.MiddleCenter
        HomeButton.AutoSize = True

        Panel1.Controls.Add(HomeButton)
        Dim AppointmentButton As New Button()
        AppointmentButton.Size() = New Size(52, 30)
        AppointmentButton.BackColor = ColorTranslator.FromHtml("#0F2A37")
        AppointmentButton.Location = New Point(707, 18)
        AppointmentButton.Text = "Appointments"
        AppointmentButton.ForeColor = Color.White
        AppointmentButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        AppointmentButton.FlatStyle = FlatStyle.Flat
        AppointmentButton.FlatAppearance.BorderSize = 0
        AppointmentButton.Padding = New Padding(0, 0, 0, 0)
        AppointmentButton.TextAlign = ContentAlignment.MiddleCenter
        AppointmentButton.AutoSize = True

        Panel1.Controls.Add(AppointmentButton)
        Dim ProfileButton As New Button()
        ProfileButton.Size() = New Size(52, 30)
        ProfileButton.BackColor = ColorTranslator.FromHtml("#0F2A37")
        ProfileButton.Location = New Point(825, 18)
        ProfileButton.Text = "Profile"
        ProfileButton.ForeColor = Color.White
        ProfileButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        ProfileButton.FlatStyle = FlatStyle.Flat
        ProfileButton.FlatAppearance.BorderSize = 0
        ProfileButton.Padding = New Padding(0, 0, 0, 0)
        ProfileButton.TextAlign = ContentAlignment.MiddleCenter
        ProfileButton.AutoSize = True

        Panel1.Controls.Add(ProfileButton)
        Dim QueriesButton As New Button()
        QueriesButton.Size() = New Size(52, 30)
        QueriesButton.BackColor = ColorTranslator.FromHtml("#0F2A37")
        QueriesButton.Location = New Point(909, 18)
        QueriesButton.Text = "Queries"
        QueriesButton.ForeColor = Color.White
        QueriesButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        QueriesButton.FlatStyle = FlatStyle.Flat
        QueriesButton.FlatAppearance.BorderSize = 0
        QueriesButton.Padding = New Padding(0, 0, 0, 0)
        QueriesButton.TextAlign = ContentAlignment.MiddleCenter
        QueriesButton.AutoSize = True
        Panel1.Controls.Add(QueriesButton)
        AddHandler HomeButton.Click, AddressOf BtnHome_Click
        AddHandler AppointmentButton.Click, AddressOf BtnAppointment_Click
        AddHandler ProfileButton.Click, AddressOf BtnProfile_Click
        AddHandler QueriesButton.Click, AddressOf BtnQueries_Click
        Me.Controls.Add(Panel3)
        Panel3.Size = New Size(1200, 700)
        Panel3.Location = New Point(0, 0)
        Panel3.Dock = DockStyle.Fill
        Panel3.BackColor = Color.Aqua
        Panel3.Padding = New Padding(0, 0, 0, 0)

        RemovePreviousForm()

        'SetActiveForm(Homepage)
        Homepage_Customer.Margin = New Padding(0, 0, 0, 0)
        With Homepage_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Customer)
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
        With Homepage_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Customer)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub BtnAppointment_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        'SetActiveForm(Appointment)
        With Payment_Gateway
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Payment_Gateway)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub BtnProfile_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        'SetActiveForm(Profile)
        With Profile_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Profile_Customer)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub BtnQueries_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        'SetActiveForm(Queries)
        With Queries_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Queries_Customer)
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
