Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Community_Based_Local_Services_Platform.AppointmentList_Customer
Public Class InProgressPaymentNotDone

    Private chatPanel As New Panel()
    Public _serviceID As String
    Public Sub CheckOrGenerateOTP(appointmentID As Integer)
        Dim checkQuery As String = "SELECT otpCode 
            FROM OTPs 
            WHERE appointmentID = @appointmentID"

        Dim insertQuery As String = "INSERT INTO OTPs (appointmentID, otpCode, otpExpiration) 
            VALUES (@appointmentID, @otp, ADDTIME(NOW(), '00:15:00'))"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()

            Using checkCommand As New MySqlCommand(checkQuery, connection)
                checkCommand.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)

                Dim existingOTP As String = checkCommand.ExecuteScalar()?.ToString()

                If Not String.IsNullOrEmpty(existingOTP) Then
                    OTP_box.Text = existingOTP
                Else
                    Dim random As New Random()
                    Dim newOTP As Integer = random.Next(1000, 9999)

                    Using insertCommand As New MySqlCommand(insertQuery, connection)
                        insertCommand.Parameters.AddWithValue("@appointmentID", appointmentID)
                        insertCommand.Parameters.AddWithValue("@otp", newOTP)
                        insertCommand.ExecuteNonQuery()
                        OTP_box.Text = newOTP.ToString()
                    End Using
                End If
            End Using

            connection.Close()
        End Using
    End Sub

    Private Sub Appointmentdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = BorderStyle.None

        OTP_box.ReadOnly = True
        OTP_box.BackColor = Me.BackColor

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        CheckOrGenerateOTP(SessionManager.appointmentID)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RemovePreviousForm()

        Dim str As String = "Reschedule"
        Dim appointmentBookingForm As New Appointment_booking(str, serviceID:=_serviceID) ' need to get serviceID in this form

        With appointmentBookingForm
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(appointmentBookingForm)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim currentDateTime As DateTime = DateTime.Now
        Dim restrictedTimeString As String = Booked_slot_tb.Text
        Dim restrictedDateTime As DateTime

        If DateTime.TryParse(restrictedTimeString, restrictedDateTime) Then
            ' Check if the current date is past the restricted date
            If currentDateTime.Date > restrictedDateTime.Date OrElse (currentDateTime.Date = restrictedDateTime.Date AndAlso currentDateTime.TimeOfDay >= restrictedDateTime.TimeOfDay) Then
                ' If past the restricted date and time, proceed to show the Payment_Gateway form
                ' Remove any previous form
                RemovePreviousForm()
                With Payment_Gateway
                    .TopLevel = False
                    .Dock = DockStyle.Fill
                    Panel3.Controls.Add(Payment_Gateway)
                    .BringToFront()
                    .Show()
                End With
            Else
                MessageBox.Show("Button click is not allowed yet.")
            End If
        Else

            MessageBox.Show("Error parsing TextBox value to DateTime.")
        End If
    End Sub

    Private Sub UpdateAppointment()
        Dim updateQuery As String = "UPDATE appointments " &
                            "SET appointmentStatus = 'Canceled' " &
                            "WHERE appointmentID = @appointmentID"

        ' Create a new connection object
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()
            ' Create a new command object with the query and connection
            Using command As New MySqlCommand(updateQuery, connection)
                ' Set the parameter value for AppointmentID
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                ' Execute the command and get the number of rows affected
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Appointment status updated successfully.")
                Else
                    MessageBox.Show("No appointment found or status already updated.")
                End If
            End Using
        End Using

        SendCancelNotification()

    End Sub

    Function SendCancelNotification()
        Using connection As New MySqlConnection(SessionManager.connectionString)
            Dim getuserIDfromsID = "Select userID from serviceproviders WHERE serviceProviderID = @SID"
            Dim command As New MySqlCommand(getuserIDfromsID, connection)
            command.Parameters.AddWithValue("@SID", SessionManager.spID)
            connection.Open()
            Dim SPuserID As String = command.ExecuteScalar().ToString()
            Dim getuserName = "Select userName from users WHERE userID = @UID"
            Dim command2 As New MySqlCommand(getuserName, connection)
            command2.Parameters.AddWithValue("@UID", SessionManager.customerID)
            Dim userName As String = command2.ExecuteScalar().ToString()

            Dim getDateTime = "SELECT
            serviceAreaTimeslots.startTime, 
            serviceAreaTimeslots.timeslotDate,
            serviceTypes.serviceTypeName, 
            serviceAreas.location
            FROM appointments 
            JOIN serviceAreaTimeslots 
            ON appointments.areaTimeslotID = serviceAreaTimeslots.areaTimeslotID 
            JOIN serviceTypes 
            ON serviceAreaTimeslots.serviceTypeID = serviceTypes.serviceID 
            JOIN serviceAreas 
            ON serviceAreaTimeslots.areaID = serviceAreas.areaID 
            WHERE appointments.appointmentID = @appointmentID;"

            Dim comm As New MySqlCommand(getDateTime, connection)
            comm.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)

            Dim _service As String = ""
            Dim combinedDateTime As String = ""


            Using reader As MySqlDataReader = comm.ExecuteReader()

                While reader.Read()

                    _service = (reader("serviceTypeName").ToString())
                    Dim startTime As String = reader("startTime").ToString()
                    Dim timeslotDate As String = CType(reader("timeslotDate"), Date).ToString("dd-MMM-yyyy")
                    combinedDateTime = $"{timeslotDate} {startTime}"

                End While

            End Using

            Dim notifmsg As String = "The appointment by " & userName & " for " & _service & " on " & combinedDateTime & " was Canceled."
            Dim notificationquery As String = "Insert into notifications (notificationMessage, notificationDateTime, userID) values (@notifmsg, NOW(), @UID)"
            Dim command3 As New MySqlCommand(notificationquery, connection)
            command3.Parameters.AddWithValue("@notifmsg", notifmsg)
            command3.Parameters.AddWithValue("@UID", SessionManager.sp_userID)
            'MessageBox.Show(notifmsg)
            command3.ExecuteNonQuery()
            Dim emailofServiceP = "Select email from users WHERE userID = @SID"
            Dim command4 As New MySqlCommand(emailofServiceP, connection)
            command4.Parameters.AddWithValue("@SID", SessionManager.sp_userID)
            Dim emailSP As String = command4.ExecuteScalar().ToString()
            Dim email_sender As New EmailSender()
            email_sender.SendEmail(emailSP, notifmsg)

        End Using

    End Function

    Private Sub UpdateCancelationAmount()

        Dim query =
        "INSERT INTO cancelledAppointments (cancellationTime, refundAmount, appointmentID)
        SELECT 
            NOW() AS cancellationTime,
            CASE
                WHEN TIMESTAMPDIFF(HOUR, NOW(), CONCAT(DATE(serviceAreaTimeslots.timeslotDate), ' ', serviceAreaTimeslots.startTime)) >= 48 THEN appointments.bookingAdvance
                WHEN TIMESTAMPDIFF(HOUR, NOW(), CONCAT(DATE(serviceAreaTimeslots.timeslotDate), ' ', serviceAreaTimeslots.startTime)) < 24 THEN 0
                ELSE ((TIMESTAMPDIFF(HOUR, NOW(), CONCAT(DATE(serviceAreaTimeslots.timeslotDate), ' ', serviceAreaTimeslots.startTime)) - 24) / 25.0) * appointments.bookingAdvance
            END AS refundAmount,
            appointments.appointmentID
        FROM 
            appointments
        INNER JOIN 
            serviceAreaTimeslots ON appointments.areaTimeslotID = serviceAreaTimeslots.areaTimeslotID
        WHERE 
            appointments.appointmentID = @appointmentID;
"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()

            Using command As New MySqlCommand(query, connection)

                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                command.ExecuteScalar()

            End Using
            connection.Close()
        End Using

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to cancel the appointment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            UpdateAppointment()
            UpdateCancelationAmount()
            RemovePreviousForm()
            Me.Close()
            With AppointmentList_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(AppointmentList_Customer)
                .BringToFront()
                .Show()
            End With
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
        With AppointmentList_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_Customer)
            .BringToFront()
            .Show()
        End With
    End Sub

End Class