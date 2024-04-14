Imports Community_Based_Local_Services_Platform.Display_Services

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
    Public line As New Panel()

    Private Sub Navbar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        line.BackColor = ColorTranslator.FromHtml("#F9754B")
        line.Size = New Size(52, 2)
        line.Location = New Point(632, 47)
        Panel1.Controls.Add(line)
        ' Highlight the Home button by default
        SessionManager.Panel3 = Panel3
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Panel1.BackColor = ColorTranslator.FromHtml("#0F2A37")
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1200, 700)


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

        ' Add Panel3 to the form
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
    Private Sub BtnHome_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        line.Size = New Size(52, 2)
        line.Location = New Point(632, 47)
        ' Load the default services on Homepage_Customer form
        Dim homepageForm As New Homepage_Customer()
        homepageForm.TopLevel = False
        homepageForm.Dock = DockStyle.Fill
        Panel3.Controls.Add(homepageForm)
        homepageForm.BringToFront()
        homepageForm.Show()

    End Sub

    Private Sub BtnAppointment_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        'SetActiveForm(Appointment)
        line.Size = New Size(110, 2)
        line.Location = New Point(707, 47)
        With AppointmentList_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_Customer)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub BtnProfile_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        'SetActiveForm(Profile)
        line.Size = New Size(60, 2)
        line.Location = New Point(825, 47)
        With Profile_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Profile_Customer)

            'retrieve data

            ' Dim loadQuery As String = "SELECT email, location, mobileNumber,address FROM ContactDetails WHERE BINARY userID='" & SessionManager.userID & "'"
            Dim loadQuery As String = "SELECT CD.email, CD.location, CD.mobileNumber, CD.address, U.userName " &
                          "FROM ContactDetails CD " &
                          "JOIN Users U ON CD.userID = U.userID " &
                          "WHERE BINARY CD.userID='" & SessionManager.userID & "'"

            Using connection As New MySqlConnection(SessionManager.connectionString)
                Using command As New MySqlCommand(loadQuery, connection)
                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()

                        If reader.Read() Then

                            Dim cus_email As String = reader("email").ToString()
                            Dim cus_location As String = reader("location").ToString()
                            Dim cus_mobile As String = reader("mobileNumber").ToString()
                            Dim cus_address As String = reader("address").ToString()
                            Dim cus_username As String = reader("userName").ToString()



                            ' Set the retrieved values to the corresponding textboxes
                            Profile_Customer.email_tb.Text = cus_email
                            Profile_Customer.location_tb.Text = cus_location
                            Profile_Customer.contact_tb.Text = cus_mobile
                            Profile_Customer.address_tb.Text = cus_address
                            Profile_Customer.customerName_tb.Text = cus_username

                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using



            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub BtnQueries_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        'SetActiveForm(Queries)
        line.Size = New Size(70, 2)
        line.Location = New Point(909, 47)
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

    ' Method to handle navigation to SP_profile form
    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If SessionManager.Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            SessionManager.Panel3.Controls.Clear()
        End If
    End Sub

    Public Sub ViewDetails_Click(sender As Object, e As EventArgs)
        Dim provider As Display_Services.ServiceProvider = DirectCast(DirectCast(sender, Button).Tag, Display_Services.ServiceProvider)

        Dim spProfileForm As New SP_profile(provider.Name, provider.Location, provider.TimeSlots, provider.ServiceName, 5)
        spProfileForm.TopLevel = False
        spProfileForm.FormBorderStyle = FormBorderStyle.None
        spProfileForm.Dock = DockStyle.Fill
        spProfileForm.AutoScroll = True

        RemovePreviousForm()
        spProfileForm.Margin = New Padding(0, 0, 0, 0)
        With spProfileForm
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(spProfileForm)
            .BringToFront()
            .Show()
        End With

    End Sub

    Public Sub PictureBox_Click(sender As Object, e As EventArgs)
        Dim provider As Display_Services.ServiceProvider = DirectCast(DirectCast(sender, PictureBox).Tag, ServiceProvider)
        ' Open the SP_profile form and pass the provider details
        Dim spProfileForm As New SP_profile(provider.Name, provider.Location, provider.TimeSlots, provider.ServiceName, 5)
        spProfileForm.TopLevel = False
        spProfileForm.FormBorderStyle = FormBorderStyle.None
        spProfileForm.Dock = DockStyle.Fill
        spProfileForm.AutoScroll = True

        RemovePreviousForm()
        spProfileForm.Margin = New Padding(0, 0, 0, 0)
        With spProfileForm
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(spProfileForm)
            .BringToFront()
            .Show()
        End With
    End Sub

    ' Event handler for Label click
    Public Sub Label_Click(sender As Object, e As EventArgs)
        Dim provider As Display_Services.ServiceProvider = DirectCast(DirectCast(sender, Label).Tag, ServiceProvider)
        ' Open the SP_profile form and pass the provider details
        Dim spProfileForm As New SP_profile(provider.Name, provider.Location, provider.TimeSlots, provider.ServiceName, 5)
        spProfileForm.TopLevel = False
        spProfileForm.FormBorderStyle = FormBorderStyle.None
        spProfileForm.Dock = DockStyle.Fill
        spProfileForm.AutoScroll = True

        RemovePreviousForm()
        spProfileForm.Margin = New Padding(0, 0, 0, 0)
        With spProfileForm
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(spProfileForm)
            .BringToFront()
            .Show()
        End With
    End Sub

End Class
