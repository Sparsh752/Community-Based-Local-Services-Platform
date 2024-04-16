Imports System.Reflection.Emit

Public Class PendingRequest_SP
    Private Sub PendingAcceptOrReject_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 700)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White

        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Location = New Point(400, 100)
        Panel1.Size = New Size(380, 410)

        Label1.Text = "Customer XYZ"
        Label2.Text = "Brahmaputra Hostel, IIT Guwahati Guwahati, Assam"
        Label3.Text = "987456789"

        Label4.Text = "Service"
        Label5.Text = "Interior Design"
        Label6.Text = "Booked Slot"
        Label7.Text = "23-Mar-2024  09:00 AM"
        Label8.Text = "Price"
        Label9.Text = "Rs. 15000"


        Label1.Location = New Point(450, 130)
        Label2.Location = New Point(450, 180)
        Label3.Location = New Point(450, 210)
        Label4.Location = New Point(450, 240)
        Label5.Location = New Point(450, 260)
        Label6.Location = New Point(450, 300)
        Label7.Location = New Point(450, 320)
        Label8.Location = New Point(450, 350)
        Label9.Location = New Point(450, 380)

        Button1.BackColor = ColorTranslator.FromHtml("#F9754B")
        Button1.Text = "Accept"
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Width = 120
        Button1.Height = 30
        Button1.ForeColor = Color.White
        Button1.Font = New Font("Bahnschrift Light", 9, FontStyle.Bold)

        Button2.BackColor = ColorTranslator.FromHtml("#F9754B")
        Button2.Text = "Reject"
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Width = 120
        Button2.Height = 30
        Button2.ForeColor = Color.White
        Button2.Font = New Font("Bahnschrift Light", 9, FontStyle.Bold)

        Button1.Location = New Point(450, 430)
        Button2.Location = New Point(600, 430)

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        Dim query As String = "SELECT appointments.appointmentID, 
            users.userName, serviceTypes.serviceTypeName, 
            CONCAT(serviceAreaTimeslots.timeslotDate, ' ', serviceAreaTimeslots.startTime) AS BookedSlot, 
            appointments.appointmentStatus, 
            serviceAreas.location, 
            appointments.bookingAdvance, 
            contactDetails.mobileNumber
            FROM appointments 
            JOIN users  
            ON appointments.customerID = users.userID 
            JOIN serviceproviders 
            ON appointments.serviceProviderID = serviceproviders.serviceProviderID 
            JOIN serviceAreaTimeslots 
            ON appointments.areaTimeslotID = serviceAreaTimeslots.areaTimeslotID 
            JOIN serviceTypes 
            ON serviceAreaTimeslots.serviceTypeID = serviceTypes.serviceID 
            JOIN serviceAreas 
            ON serviceAreaTimeslots.areaID = serviceAreas.areaID 
            JOIN contactDetails 
            ON contactDetails.userID = appointments.customerID 
            WHERE appointments.serviceProviderID = @spID
            AND appointments.appointmentID = @appointmentID;"


        ' Create a new connection object
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()
            ' Create a new command object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Set the parameter value for UserID
                command.Parameters.AddWithValue("@spID", SessionManager.spID)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                ' Execute the command and get the data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Read the data

                    ' Check if data is available
                    If reader.Read() Then
                        ' Populate RichTextBox controls with fetched data
                        Label1.Text = reader("userName").ToString()
                        Label5.Text = reader("serviceTypeName").ToString()
                        Label9.Text = reader("bookingAdvance").ToString()
                        Label7.Text = reader("BookedSlot").ToString()
                        Label2.Text = reader("location").ToString()
                        Label3.Text = reader("mobileNumber").ToString()

                    Else
                        MessageBox.Show("Appointment not found.")
                    End If


                End Using
            End Using

            ' Close connection
            connection.Close()
        End Using

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

    Private Sub UpdateAppointment()
        Dim updateQuery As String = "UPDATE appointments " &
                            "SET appointmentStatus = 'Scheduled' " &
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
        SendAcceptNotification()
    End Sub

    Private Sub UpdateAppointment1()
        Dim updateQuery As String = "UPDATE appointments " &
                            "SET appointmentStatus = 'Rejected' " &
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
                command.ExecuteNonQuery()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Appointment status updated successfully.")
                Else
                    MessageBox.Show("No appointment found or status already updated.")
                End If
            End Using
        End Using
        SendRejectNotification()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        UpdateAppointment()
        RemovePreviousForm()
        With AppointmentList_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_SP)
            .BringToFront()
            .Show()
        End With
        'MessageBox.Show("Appointment Booked!")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UpdateAppointment1()
        RemovePreviousForm()
        With AppointmentList_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_SP)
            .BringToFront()
            .Show()
        End With
        'MessageBox.Show("Appointment Rejected!")
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        RemovePreviousForm()

        With AppointmentList_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_SP)
            .BringToFront()
            .Show()
        End With
    End Sub

    Function SendRejectNotification()
        Using connection As New MySqlConnection(SessionManager.connectionString)
            Dim getcustomeruid = "Select customerID from appointments where appointmentID = @appointmentID"
            connection.Open()
            Dim command As New MySqlCommand(getcustomeruid, connection)
            command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
            Dim uid As String = command.ExecuteScalar().ToString()
            Dim getusername = "Select userName from users where userID = @uid"
            Dim command1 As New MySqlCommand(getusername, connection)
            command1.Parameters.AddWithValue("@uid", SessionManager.userID)
            Dim username As String = command1.ExecuteScalar().ToString()

            Dim notifmsg As String = "Your appointment has been rejected by " & username & "."
            Dim insertnotif = "Insert into notifications (userID, notificationMessage, notificationDateTime) values (@uid, @notifmsg, NOW())"
            Dim command2 As New MySqlCommand(insertnotif, connection)
            command2.Parameters.AddWithValue("@uid", uid)
            command2.Parameters.AddWithValue("@notifmsg", notifmsg)
            command2.ExecuteNonQuery()
            Dim email = "Select email from users where userID = @uid"
            Dim command3 As New MySqlCommand(email, connection)
            command3.Parameters.AddWithValue("@uid", uid)
            Dim emailid As String = command3.ExecuteScalar().ToString()
            Dim email_sender As New EmailSender()
            'MessageBox.Show(emailid)
            email_sender.SendEmail(emailid, notifmsg)

        End Using
    End Function

    Function SendAcceptNotification()
        Using connection As New MySqlConnection(SessionManager.connectionString)
            Dim getcustomeruid = "Select customerID from appointments where appointmentID = @appointmentID"
            connection.Open()
            Dim command As New MySqlCommand(getcustomeruid, connection)
            command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
            Dim uid As String = command.ExecuteScalar().ToString()
            Dim getusername = "Select userName from users where userID = @uid"
            Dim command1 As New MySqlCommand(getusername, connection)
            command1.Parameters.AddWithValue("@uid", SessionManager.userID)
            Dim username As String = command1.ExecuteScalar().ToString()

            Dim notifmsg As String = "Your appointment has been accepted by " & username & "."
            Dim insertnotif = "Insert into notifications (userID, notificationMessage, notificationDateTime) values (@uid, @notifmsg, NOW())"
            Dim command2 As New MySqlCommand(insertnotif, connection)
            command2.Parameters.AddWithValue("@uid", uid)
            command2.Parameters.AddWithValue("@notifmsg", notifmsg)
            command2.ExecuteNonQuery()
            Dim email = "Select email from users where userID = @uid"
            Dim command3 As New MySqlCommand(email, connection)
            command3.Parameters.AddWithValue("@uid", uid)
            Dim emailid As String = command3.ExecuteScalar().ToString()
            Dim email_sender As New EmailSender()
            'MessageBox.Show(emailid)
            email_sender.SendEmail(emailid, notifmsg)

        End Using
    End Function

End Class