Imports Org.BouncyCastle.Asn1.Ocsp
Imports System.IO

Public Class TransactionComplete_SP
    Private CustomerName As String
    Private CustomerAddress As String
    Private CustomerPhone As String
    Private ServiceName As String
    Private Price As String
    Private BookedSlot As String
    Private ServiceLocation As String

    Private ReviewSubmitted As Boolean = False
    Public selectedRating As Double = 0.0

    Private _serviceProviderName As String
    Private _serviceLocation As String
    Private _phoneNo As String
    Private _slotDate As String
    Private _transactionID As String
    Private _transactionType As String
    Private _serviceName As String
    Private _servicePrice As String

    Private chatPanel As New Panel()
    Private Sub TransactionComplete_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CustomerName = "Customer XYZ"
        CustomerAddress = "123 Example St, City"
        CustomerPhone = "123-456-7890"
        ServiceName = "Example Service"
        Price = "$50"
        BookedSlot = "Monday, 9:00 AM"
        ServiceLocation = "Example Location"

        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None

        Label5.Text = CustomerName
        Label6.Text = CustomerAddress
        Label7.Text = CustomerPhone
        Label8.Text = ServiceName
        Label9.Text = Price
        Label10.Text = BookedSlot
        Label11.Text = ServiceLocation

        Star1.Size = New Size(20, 20)
        Star1.BackgroundImageLayout = ImageLayout.Stretch
        Star1.BackColor = Me.BackColor
        Star1.FlatStyle = FlatStyle.Flat
        Star1.FlatAppearance.BorderSize = 0
        Star2.Size = New Size(20, 20)
        Star2.BackgroundImageLayout = ImageLayout.Stretch
        Star2.BackColor = Me.BackColor
        Star2.FlatStyle = FlatStyle.Flat
        Star2.FlatAppearance.BorderSize = 0
        Star3.Size = New Size(20, 20)
        Star3.BackgroundImageLayout = ImageLayout.Stretch
        Star3.BackColor = Me.BackColor
        Star3.FlatStyle = FlatStyle.Flat
        Star3.FlatAppearance.BorderSize = 0
        Star4.Size = New Size(20, 20)
        Star4.BackgroundImageLayout = ImageLayout.Stretch
        Star4.BackColor = Me.BackColor
        Star4.FlatStyle = FlatStyle.Flat
        Star4.FlatAppearance.BorderSize = 0
        Star5.Size = New Size(20, 20)
        Star5.BackgroundImageLayout = ImageLayout.Stretch
        Star5.BackColor = Me.BackColor
        Star5.FlatStyle = FlatStyle.Flat
        Star5.FlatAppearance.BorderSize = 0

        Star1.BackgroundImage = My.Resources.Resource1.star_uncolored
        Star2.BackgroundImage = My.Resources.Resource1.star_uncolored
        Star3.BackgroundImage = My.Resources.Resource1.star_uncolored
        Star4.BackgroundImage = My.Resources.Resource1.star_uncolored
        Star5.BackgroundImage = My.Resources.Resource1.star_uncolored

        Panel1.BorderStyle = BorderStyle.FixedSingle

        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.BackColor = Me.BackColor
        RichTextBox1.Font = New Font("Bahnschrift", 12, FontStyle.Regular)

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        CheckIfReviewGiven()

        Fetch_Appointment_Details()

        LoadChatPanel()

    End Sub

    Private Sub LoadChatPanel()

        chatPanel.Location = New Point(687, 125)
        chatPanel.Size = New Size(437, 490)
        chatPanel.BorderStyle = BorderStyle.FixedSingle
        chatPanel.BackColor = Color.White

        Me.Controls.Add(chatPanel)

        With ChatBox
            .TopLevel = False
            .Dock = DockStyle.Fill
            chatPanel.Controls.Add(ChatBox)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub Star1_Click(sender As Object, e As EventArgs) Handles Star1.Click
        selectedRating = 1.0
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star3.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star4.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star5.BackgroundImage = My.Resources.Resource1.star_uncolored
        End If
    End Sub

    Private Sub Star2_Click(sender As Object, e As EventArgs) Handles Star2.Click
        selectedRating = 2.0
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_colored
            Star3.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star4.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star5.BackgroundImage = My.Resources.Resource1.star_uncolored
        End If
    End Sub

    Private Sub Star3_Click(sender As Object, e As EventArgs) Handles Star3.Click
        selectedRating = 3.0
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_colored
            Star3.BackgroundImage = My.Resources.Resource1.star_colored
            Star4.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star5.BackgroundImage = My.Resources.Resource1.star_uncolored
        End If
    End Sub

    Private Sub Star4_Click(sender As Object, e As EventArgs) Handles Star4.Click
        selectedRating = 4.0
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_colored
            Star3.BackgroundImage = My.Resources.Resource1.star_colored
            Star4.BackgroundImage = My.Resources.Resource1.star_colored
            Star5.BackgroundImage = My.Resources.Resource1.star_uncolored
        End If
    End Sub

    Private Sub Star5_Click(sender As Object, e As EventArgs) Handles Star5.Click
        selectedRating = 5.0
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_colored
            Star3.BackgroundImage = My.Resources.Resource1.star_colored
            Star4.BackgroundImage = My.Resources.Resource1.star_colored
            Star5.BackgroundImage = My.Resources.Resource1.star_colored
        End If
    End Sub

    Private Sub RemovePreviousForm()
        For Each ctrl As Control In Panel3.Controls
            If TypeOf ctrl Is Form Then
                ' Remove the first control (form) from Panel5
                Dim formCtrl As Form = DirectCast(ctrl, Form)
                formCtrl.Close()
            End If
        Next
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If

    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        RemovePreviousForm()
        For Each ctrl As Control In chatPanel.Controls
            If TypeOf ctrl Is Form Then
                Dim formCtrl As Form = DirectCast(ctrl, Form)
                formCtrl.Close()
            End If
        Next
        Me.Close()

        With AppointmentList_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_SP)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub GenerateReceiptDetails()
        Dim query = "SELECT appointments.appointmentID, 
                serviceproviders.serviceProviderName, 
                serviceTypes.serviceTypeName, 
                serviceAreas.location,
                contactDetails.mobileNumber,
                serviceAreaTimeslots.timeslotDate,
                serviceAreaTimeslots.startTime, 
                payments.paymentID,
                payments.paymentDateTime,
                payments.paymentMode,
                services.price,
                services.serviceID 
                FROM appointments 
                JOIN payments
                ON appointments.appointmentID = payments.appointmentID
                JOIN serviceproviders 
                ON appointments.serviceProviderID = serviceproviders.serviceProviderID 
                JOIN serviceAreaTimeslots 
                ON appointments.areaTimeslotID = serviceAreaTimeslots.areaTimeslotID 
                JOIN contactDetails 
                ON contactDetails.UserID = serviceproviders.userID
                JOIN serviceAreas 
                ON serviceAreas.areaID = serviceAreaTimeslots.areaID
                JOIN services
                ON services.serviceTypeID = serviceAreaTimeslots.serviceTypeID
                AND services.serviceProviderID = serviceAreaTimeslots.serviceProviderID 
                JOIN serviceTypes 
                ON serviceAreaTimeslots.serviceTypeID = serviceTypes.serviceID 
                WHERE appointments.appointmentID = @appointmentID;"

        Using connection As New MySqlConnection(SessionManager.connectionString)

            connection.Open()

            Using command As New MySqlCommand(query, connection)

                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)

                Using reader As MySqlDataReader = command.ExecuteReader()

                    Dim labels As New List(Of String)()

                    If reader.Read() Then

                        _serviceProviderName = reader("serviceProviderName").ToString()
                        _servicePrice = reader("price").ToString()
                        _phoneNo = reader("mobileNumber").ToString()
                        _serviceLocation = reader("location").ToString()
                        _slotDate = reader("timeslotDate").ToString()
                        _serviceName = reader("serviceTypeName")
                        _transactionID = reader("paymentID") & "  " & reader("paymentDateTime")
                        _transactionType = reader("paymentMode")

                    End If
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        GenerateReceiptDetails()

        Dim pdfGenerator As New PdfGenerator()
        Dim currentDirectory As String = AppDomain.CurrentDomain.BaseDirectory

        Dim pdfName As String = "TransactionReceipt_" & SessionManager.appointmentID.ToString() & ".pdf"

        Dim filePath As String = Path.Combine(currentDirectory, pdfName)
        pdfGenerator.GeneratePDF(filePath, _serviceProviderName, _serviceLocation, _phoneNo, _slotDate, "", _transactionID, _transactionType, _serviceName, _servicePrice) ' Assuming your PdfGenerator class has support for custom page size
        If File.Exists(filePath) Then
            Dim edgePath As String = "C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"
            Process.Start(edgePath, """" & filePath & """")
        Else
            Console.WriteLine("PDF file does not exist.")
        End If
    End Sub

    Private Sub CheckIfReviewGiven()
        Dim query As String = "SELECT rating, reviewText 
            FROM reviews WHERE appointmentID = @appointmentID AND givenByID = @givenByID;"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                command.Parameters.AddWithValue("@givenByID", SessionManager.sp_userID)

                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then

                        Dim rating As Integer = reader.GetInt32("rating")
                        Dim reviewText As String = reader.GetString("reviewText")
                        ReviewSubmitted = True

                        Label12.Text = "Given Rating"
                        Label13.Text = "Given Review"

                        Button2.Hide()
                        RichTextBox1.Text = reviewText

                        RichTextBox1.ReadOnly = True
                        If rating >= 1 Then
                            Star1.BackgroundImage = My.Resources.Resource1.star_colored
                        End If
                        If rating >= 2 Then
                            Star2.BackgroundImage = My.Resources.Resource1.star_colored
                        End If
                        If rating >= 3 Then
                            Star3.BackgroundImage = My.Resources.Resource1.star_colored
                        End If
                        If rating >= 4 Then
                            Star4.BackgroundImage = My.Resources.Resource1.star_colored
                        End If
                        If rating >= 5 Then
                            Star5.BackgroundImage = My.Resources.Resource1.star_colored
                        End If

                    Else
                        ReviewSubmitted = False
                    End If
                End Using
            End Using
        End Using

    End Sub

    Private Sub UpdateRatingReview()
        Dim updateQuery As String = "INSERT INTO 
            reviews (appointmentID, rating, givenForID, givenByID, reviewText, reviewDate)
            VALUES (@appointmentID, @rating,@givenForID, @givenByID, @review, CURDATE());"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()
            Using command As New MySqlCommand(updateQuery, connection)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                command.Parameters.AddWithValue("@rating", selectedRating)
                command.Parameters.AddWithValue("@givenForID", SessionManager.customerID)
                command.Parameters.AddWithValue("@givenByID", SessionManager.sp_userID)
                command.Parameters.AddWithValue("@review", RichTextBox1.Text)

                command.ExecuteNonQuery()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Review updated.")
                Else
                    MessageBox.Show("Couldn't update review.")
                End If
            End Using
        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        UpdateRatingReview()

        If Not String.IsNullOrEmpty(RichTextBox1.Text.Trim()) Then
            RemovePreviousForm()
            For Each ctrl As Control In chatPanel.Controls
                If TypeOf ctrl Is Form Then
                    Dim formCtrl As Form = DirectCast(ctrl, Form)
                    formCtrl.Close()
                End If
            Next
            Me.Close()
            With AppointmentList_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(AppointmentList_SP)
                .BringToFront()
                .Show()
            End With
        Else
            MessageBox.Show("Please enter some text in the review box.")
        End If

    End Sub

    Private Sub Fetch_Appointment_Details()

        ' Query to retrieve customer's ID based on email and password
        Dim query As String = "SELECT 
            users.userName AS CustomerName, 
            contactDetails.location AS CustomerAddress, 
            contactDetails.mobileNumber AS CustomerPhone, 
            serviceTypes.serviceTypeName AS ServiceName, 
            services.price AS Price, 
            CONCAT(serviceAreaTimeslots.timeslotDate, ' ', serviceAreaTimeslots.startTime) AS BookedSlot, 
            serviceAreas.location AS ServiceLocation
        FROM 
            appointments 
        JOIN 
            users ON appointments.customerID = users.userID 
        JOIN 
            contactDetails ON users.userID = contactDetails.userID 
        JOIN 
            serviceproviders ON appointments.serviceProviderID = serviceproviders.serviceProviderID 
        JOIN 
            serviceAreaTimeslots ON appointments.areaTimeslotID = serviceAreaTimeslots.areaTimeslotID 
        JOIN 
            services ON serviceAreaTimeslots.serviceTypeID = services.serviceTypeID 
        JOIN 
            serviceTypes ON services.serviceTypeID = serviceTypes.serviceID 
        JOIN 
            serviceAreas ON serviceAreaTimeslots.areaID = serviceAreas.areaID 
        WHERE 
            appointments.serviceProviderID = @serviceProviderID
            AND appointments.appointmentID = @appointmentID;"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                command.Parameters.AddWithValue("@serviceProviderID", SessionManager.spID)

                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    If reader.Read() Then

                        CustomerName = reader("CustomerName").ToString()
                        CustomerAddress = reader("CustomerAddress").ToString()
                        CustomerPhone = reader("CustomerPhone").ToString()
                        ServiceName = reader("ServiceName").ToString()
                        Price = reader("Price").ToString()
                        BookedSlot = reader("BookedSlot").ToString()
                        ServiceLocation = reader("ServiceLocation").ToString()

                        Label5.Text = CustomerName
                        Label6.Text = CustomerAddress
                        Label7.Text = CustomerPhone
                        Label8.Text = ServiceName
                        Label9.Text = Price
                        Label10.Text = BookedSlot
                        Label11.Text = ServiceLocation

                    End If

                    reader.Close()
                Catch ex As Exception
                    MessageBox.Show("Error " & ex.Message)
                End Try
            End Using
        End Using

    End Sub


    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class