Imports System.Globalization
Imports System.IO

Public Class Appointment_booking

    Private appointmentType As String
    Private selectedLocation As String
    Private selectedDate As DateTime
    Private selectedTimeSlot As String
    Private advancepayment As Decimal

    Private serviceID As String
    Private serviceProviderID As String
    Private serviceTypeID As String
    Private serviceName As String
    Private userID As String = SessionManager.userID
    Private loadingForm As Boolean = True ' Flag to track form loading

    Dim startTime As TimeSpan
    Dim endTime As TimeSpan


    Dim buttonWidth As Integer = 75
    Dim buttonHeight As Integer = 30
    Dim buttonSpacing As Integer = 100
    Dim hourFormat As String = "HH:mm:ss" ' Time format in the database


    ' Constructor to accept the string parameter
    Public Sub New(ByVal str As String)
        InitializeComponent()
        appointmentType = str
    End Sub
    Public Sub New(ByVal str As String, serviceID As String)
        InitializeComponent()
        appointmentType = str
        Me.serviceID = serviceID
    End Sub

    Private Sub Appointment_booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)


        If (appointmentType = "Reschedule") Then
            Button10.Text = "Reschedule"
            Label1.Text = "Reschedule Appointment"
        Else
            Button10.Text = "Proceed to Pay"
            Label1.Text = "Book Appointment"
        End If


        ' Fetch service name and service provider name from the database
        Dim serviceProviderName As String = ""
        GetServiceProviderID(serviceID)

        FetchServiceProviderTiming(serviceProviderID)

        GetServiceProviderName(serviceProviderID, serviceProviderName)

        ' Display service name and service provider name in a label
        Label2.Text = serviceName & ", " & serviceProviderName

        ' Fetch all locations for the given service ID and populate them in the combobox dropdown
        FetchLocations(serviceTypeID, serviceName, serviceProviderID)

        ' Select the first item in the ComboBox
        ComboBox1.SelectedIndex = 0

        Dim minimumNoticeHours As Integer = GetMinimumNoticeHours(serviceProviderID)

        ' Set the minimum date of the DateTimePicker
        DateTimePicker1.MinDate = DateTime.Now.AddHours(minimumNoticeHours)

        ' Set loadingForm flag to false after initial setup
        loadingForm = False

    End Sub

    Private Function GetMinimumNoticeHours(serviceProviderID As String) As Integer
        Dim query As String = "SELECT minimumNoticeHours FROM serviceproviders WHERE serviceProviderID = @ServiceProviderID"
        Dim minimumNoticeHours As Integer = 0

        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceProviderID", serviceProviderID)
                connection.Open()
                Dim result As Object = command.ExecuteScalar()
                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    minimumNoticeHours = Convert.ToInt32(result)
                End If
            End Using
        End Using

        Return minimumNoticeHours
    End Function

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    Private Function GetServiceProviderID(serviceID As String) As String

        Dim query As String = "SELECT * FROM services WHERE serviceID = @ServiceID"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceID", serviceID)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        serviceProviderID = reader("serviceProviderID").ToString()
                        serviceName = reader("serviceName").ToString()
                        serviceTypeID = reader("serviceTypeID").ToString()
                    End If
                End Using
            End Using
        End Using
    End Function

    Private Function GetServiceProviderName(serviceID As String, ByRef serviceProviderName As String) As String

        Dim query As String = "SELECT * FROM serviceproviders WHERE serviceProviderID = @ServiceProviderID"
        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceProviderID", serviceProviderID)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        serviceProviderName = reader("serviceProviderName").ToString()
                    End If
                End Using
            End Using
        End Using
    End Function


    Private Sub FetchServiceProviderTiming(serviceProviderID As String)
        ' Fetch start and end time of the service provider for the selected day of the week from the database
        Dim query As String = "SELECT * FROM workHours AS wh WHERE wh.serviceProviderID = @ServiceProviderID"
        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceProviderID", serviceProviderID)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        startTime = reader.GetTimeSpan(reader.GetOrdinal("startTime"))
                        endTime = reader.GetTimeSpan(reader.GetOrdinal("endTime"))
                    End If
                End Using
            End Using
        End Using
    End Sub


    Private Sub FetchLocations(serviceTypeID As String, serviceName As String, serviceProviderID As String)
        ' Clear existing items in ComboBox1
        ComboBox1.Items.Clear()

        ' HashSet to store unique locations
        Dim uniqueLocations As New HashSet(Of String)()

        ' Query to fetch locations based on serviceTypeID, serviceName, and serviceProviderID
        Dim query As String = "SELECT sa.location " &
                          "FROM services AS s " &
                          "INNER JOIN serviceAreas AS sa ON s.areaID = sa.areaID " &
                          "WHERE s.serviceTypeID = @ServiceTypeID " &
                          "AND s.serviceName = @ServiceName " &
                          "AND s.serviceProviderID = @ServiceProviderID"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceTypeID", serviceTypeID)
                command.Parameters.AddWithValue("@ServiceName", serviceName)
                command.Parameters.AddWithValue("@ServiceProviderID", serviceProviderID)
                connection.Open()
                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Add location to HashSet if it's unique
                        Dim location As String = reader("location").ToString()
                        If Not uniqueLocations.Contains(location) Then
                            ComboBox1.Items.Add(location)
                            uniqueLocations.Add(location)
                        End If
                    End While
                End Using
            End Using
        End Using
    End Sub



    Private Function CheckAppointmentExists(serviceID As Integer, startTime As TimeSpan, location As String, timeslotDate As DateTime, appointmentStatus As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM appointments AS a " &
                          "INNER JOIN serviceAreaTimeslots AS sat ON a.areaTimeslotID = sat.areaTimeslotID " &
                          "INNER JOIN serviceAreas AS sa ON sat.areaID = sa.areaID " &
                          "WHERE a.serviceID = @ServiceID " &
                          "AND sat.startTime = @StartTime " &
                          "AND sa.location = @Location " &
                          "AND DATE(sat.timeslotDate) = @TimeslotDate " &
                          "AND a.appointmentStatus = @AppointmentStatus"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceID", serviceID)
                command.Parameters.AddWithValue("@StartTime", startTime.ToString("hh\:mm\:ss")) ' Convert TimeSpan to string in HH:mm:ss format
                command.Parameters.AddWithValue("@Location", location)
                command.Parameters.AddWithValue("@TimeslotDate", timeslotDate.Date) ' Extract date part
                command.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus)
                connection.Open()
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                Return count > 0
            End Using
        End Using
    End Function




    Private Function GetServicePrice(serviceID As String) As Decimal
        ' Retrieve the price of the service from the database using the service ID
        Dim query As String = "SELECT price FROM services WHERE serviceID = @ServiceID"
        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@ServiceID", serviceID)
                connection.Open()
                Dim price As Object = command.ExecuteScalar()
                If price IsNot Nothing AndAlso Not Convert.IsDBNull(price) Then
                    Return Convert.ToDecimal(price)
                Else
                    Return 0 ' Return 0 if price not found (handle appropriately in your application)
                End If
            End Using
        End Using
    End Function


    Private Sub DisplayButtons(selectedDate As DateTime)

        Dim morningButtons As New List(Of Button)()
        Dim afternoonButtons As New List(Of Button)()
        Dim eveningButtons As New List(Of Button)()
        Dim nightButtons As New List(Of Button)()

        ' Determine currentTime based on selectedDate and current time or fetched startTime
        Dim currentTime As TimeSpan
        If selectedDate.Date = Date.Today Then
            ' If selectedDate is today, set currentTime to present time + 1 hour
            currentTime = DateTime.Now.AddHours(1).TimeOfDay
        Else
            ' If selectedDate is not today, set currentTime to fetched startTime
            currentTime = startTime
        End If

        'Dim verticalPosition As Integer = 350 ' Initial vertical position

        Do While currentTime <= endTime
            Dim button As New Button()

            button.Text = TimeSpanToDateTime(selectedDate, currentTime).ToString("hh tt") ' Display hour in 12-hour format
            button.Width = buttonWidth
            button.Height = buttonHeight

            button.Font = New Font("Bahnschrift Light", 10, FontStyle.Regular)
            button.ForeColor = Color.Black
            button.BackColor = Color.White
            button.FlatStyle = FlatStyle.Flat


            ' Determine the time period (morning, afternoon, evening, night) and set the horizontal position accordingly
            If currentTime.Hours < 12 Then
                button.Left = 150 + (morningButtons.Count * buttonSpacing) ' Morning
                button.Top = 350
                morningButtons.Add(button)
            ElseIf currentTime.Hours < 17 Then
                button.Left = 150 + (afternoonButtons.Count * buttonSpacing) ' Afternoon
                button.Top = 400
                afternoonButtons.Add(button)
            ElseIf currentTime.Hours < 20 Then
                button.Left = 150 + (eveningButtons.Count * buttonSpacing) ' Evening
                button.Top = 450
                eveningButtons.Add(button)
            Else
                button.Left = 150 + (nightButtons.Count * buttonSpacing) ' Night
                button.Top = 500
                nightButtons.Add(button)
            End If


            Dim location As String = If(ComboBox1.SelectedItem IsNot Nothing, ComboBox1.SelectedItem.ToString(), "")

            ' Check if an appointment exists for the selected location, date, and start time
            Dim appointmentExists As Boolean = CheckAppointmentExists(serviceID, currentTime, location, selectedDate, "Scheduled")

            ' Set button state based on appointment existence
            button.Enabled = Not appointmentExists

            ' Add button click event handler
            AddHandler button.Click, AddressOf Button_Click

            'button.Top = verticalPosition ' Set the vertical position of buttons
            Me.Controls.Add(button)


            ' Move to the next hour
            currentTime = currentTime.Add(New TimeSpan(1, 0, 0))

            '' Update the vertical position for the next row
            'If currentTime.Hours = 12 OrElse currentTime.Hours = 17 OrElse currentTime.Hours = 20 Then
            '    verticalPosition += 50 ' Increase vertical position for the next row
            'End If
        Loop
    End Sub

    ' Helper function to convert TimeSpan to DateTime with a specific date
    Private Function TimeSpanToDateTime(selectedDate As DateTime, time As TimeSpan) As DateTime
        ' Combine selectedDate with the time component from the TimeSpan
        Dim dateTimeWithTime As DateTime = selectedDate.Date.Add(time)
        Return dateTimeWithTime
    End Function

    Function SendRescheduleNotification()
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

            Dim notifmsg As String = "The appointment by " & userName & " for " & _service & " on " & combinedDateTime & " was Rescheduled."
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

    Private Sub RescheduleAppointment(appointmentID As Integer, newDate As DateTime, newTime As String, newLocation As String)
        'MessageBox.Show(appointmentID & " " & newDate & " " & newTime & " " & newLocation)
        ' Define the SQL query to update the appointment details
        Dim query As String =
            "UPDATE appointments AS a " &
            "JOIN serviceAreaTimeslots AS sat ON a.areaTimeslotID = sat.areaTimeslotID " &
            "JOIN serviceAreas AS sa ON sat.areaID = sa.areaID " &
            "SET sat.timeslotDate = @NewDate, sat.startTime = @NewTime, sa.location = @NewLocation " &
            "WHERE a.appointmentID = @appointmentID"


        ' Create a new SQL connection
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()

            ' Create a new SQL command
            Using command As New MySqlCommand(query, connection)
                ' Set the parameters for the new date, time, location, and appointment ID
                command.Parameters.AddWithValue("@NewDate", newDate)
                command.Parameters.AddWithValue("@NewTime", newTime)
                command.Parameters.AddWithValue("@NewLocation", newLocation)
                command.Parameters.AddWithValue("@AppointmentID", appointmentID)

                ' Execute the SQL command to update the appointment details
                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                ' Check if any rows were affected (updated)
                If rowsAffected > 0 Then
                    ' Appointment details updated successfully
                    MessageBox.Show("Appointment rescheduled successfully.")
                Else
                    ' No rows were affected, possibly due to invalid appointment ID
                    MessageBox.Show("Failed to reschedule appointment. Please check the appointment ID.")
                End If
            End Using
        End Using

        SendRescheduleNotification()

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a location before selecting a time slot.", "Select Location", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Check if a time slot is selected
        If selectedTimeSlot Is Nothing Then
            MessageBox.Show("Please select a time slot before proceeding with payment.", "Select Time Slot", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Close()

        If appointmentType = "Reschedule" Then
            Dim currentDateTime = Date.Now

            ' Combine selected date and time
            Dim selectedDateTime = selectedDate.Date + TimeSpan.Parse(selectedTimeSlot)

            'MessageBox.Show(selectedDate & " " & selectedTimeSlot)

            ' Check if the selected date and time are in the past
            If selectedDateTime <= currentDateTime Then
                'MessageBox.Show("Selected date and time cannot be in the past. Please select a future date and time for rescheduling.")
            Else

                RescheduleAppointment(appointmentID, selectedDate, selectedTimeSlot, selectedLocation)
                RemovePreviousForm()
                'MessageBox.Show("Reschedule request sent.")
                With AppointmentList_Customer
                    .TopLevel = False
                    .Dock = DockStyle.Fill
                    Panel3.Controls.Add(AppointmentList_Customer)
                    .BringToFront()
                    .Show()
                End With
            End If
        Else
            RemovePreviousForm()

            With Payment_Gateway
                .TopLevel = False
                .Dock = DockStyle.Fill
                .serviceID = serviceID
                .Price = advancepayment.ToString()
                .serviceLocation = selectedLocation
                .selectedDate = selectedDate
                .selectedTimeSlot = selectedTimeSlot
                .serviceProviderID = serviceProviderID
                .serviceTypeID = serviceTypeID
                Panel3.Controls.Add(Payment_Gateway)
                .BringToFront()
                .Show()
            End With
        End If

    End Sub

    Private Function GetServiceID(serviceTypeID As String, serviceName As String, serviceProviderID As String, location As String) As String
        ' Check if serviceTypeID, serviceName, and serviceProviderID are not empty
        If Not String.IsNullOrEmpty(serviceTypeID) AndAlso Not String.IsNullOrEmpty(serviceName) AndAlso Not String.IsNullOrEmpty(serviceProviderID) Then
            ' Query to find the serviceID based on location, serviceTypeID, serviceName, and serviceProviderID
            Dim query As String = "SELECT s.serviceID " &
                              "FROM services AS s " &
                              "INNER JOIN serviceAreas AS sa ON s.areaID = sa.areaID " &
                              "WHERE s.serviceTypeID = @ServiceTypeID " &
                              "AND s.serviceName = @ServiceName " &
                              "AND s.serviceProviderID = @ServiceProviderID " &
                              "AND sa.location = @Location"

            Using connection As New MySqlConnection(SessionManager.connectionString)
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ServiceTypeID", serviceTypeID)
                    command.Parameters.AddWithValue("@ServiceName", serviceName)
                    command.Parameters.AddWithValue("@ServiceProviderID", serviceProviderID)
                    command.Parameters.AddWithValue("@Location", location)
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        ' Return the serviceID as string
                        Return result.ToString()
                    End If
                End Using
            End Using
        End If

        ' If serviceID is not found, return an empty string
        Return ""
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        ' Check if nothing is selected in ComboBox1 (index is -1)
        If ComboBox1.SelectedIndex = -1 Then
            ' Set selectedLocation to Nothing
            selectedLocation = Nothing
        Else
            ' Clear existing buttons
            ClearButtons()

            ' Get the selected location from ComboBox1
            selectedLocation = ComboBox1.SelectedItem.ToString()

            ' Get the serviceID based on the selected location and previously found service parameters
            serviceID = GetServiceID(serviceTypeID, serviceName, serviceProviderID, selectedLocation)

            ' Check if serviceID is empty
            If String.IsNullOrEmpty(serviceID) Then
                MessageBox.Show("Service ID not found for the selected location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Display buttons for each hour between start and end times
            DisplayButtons(selectedDate)
        End If


    End Sub


    Private Sub ClearButtons()
        For i As Integer = Me.Controls.Count - 1 To 0 Step -1
            If TypeOf Me.Controls(i) Is Button AndAlso Me.Controls(i) IsNot Button10 AndAlso Me.Controls(i) IsNot Button11 Then
                Me.Controls.RemoveAt(i)
            End If
        Next
    End Sub


    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        ' Clear existing buttons

        ClearButtons()

        selectedTimeSlot = Nothing

        If Not loadingForm Then
            If ComboBox1.SelectedIndex = -1 Then
                MessageBox.Show("please select a location before choosing a date.", "select location", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'datetimepicker1.value = datetime.today ' reset the date picker
                Return
            End If
        End If


        Dim _selectedDate As DateTime = DateTimePicker1.Value
        selectedDate = _selectedDate
        'MessageBox.Show(SessionManager.appointmentID & " " & selectedDate)

        ' Fetch service provider timings for the selected day of the week
        'Dim dayOfWeek As DayOfWeek = selectedDate.DayOfWeek

        ' Display buttons for each hour between start and end times
        DisplayButtons(selectedDate)
    End Sub


    Private Sub Button_Click(sender As Object, e As EventArgs)

        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is Button AndAlso ctrl IsNot Button10 AndAlso ctrl IsNot Button11 Then
                Dim btn As Button = DirectCast(ctrl, Button)
                btn.BackColor = Color.White
                btn.ForeColor = Color.Black
            End If
        Next

        ' Determine which button was clicked and extract the selected time slot
        Dim clickedButton As Button = DirectCast(sender, Button)
        clickedButton.BackColor = Color.Black
        clickedButton.ForeColor = Color.White

        '' Check if a date is selected
        'If DateTimePicker1.Value.Date = Date.Today Then
        '    MessageBox.Show("Please select a date before selecting a time slot.", "Select Date", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Return
        'End If

        ' Parse the time from the clicked button
        Dim parsedTime = Date.ParseExact(clickedButton.Text, "hh tt", CultureInfo.InvariantCulture)
        selectedTimeSlot = parsedTime.ToString("HH:mm:ss")

        ' Calculate the price of the service using the service ID from the database
        Dim servicePrice = GetServicePrice(serviceID)

        ' Print the price in a label
        Label12.Text = "Rs. " & servicePrice.ToString("0.00")

        ' Calculate and print 50% of the price in a different label
        advancepayment = servicePrice * 0.5

        If appointmentType = "Reschedule" Then
            Label13.Text = "Rs. 0.00"
        Else
            Label13.Text = "Rs. " & advancepayment.ToString("0.00")
        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        RemovePreviousForm()
        Me.Close()

        If appointmentType = "Reschedule" Then
            With InProgressPaymentNotDone
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(InProgressPaymentNotDone)
                Dim query As String =
                "SELECT appointments.appointmentID, 
                serviceproviders.serviceProviderName, 
                serviceTypes.serviceTypeName, 
                serviceAreaTimeslots.startTime, 
                contactDetails.mobileNumber,
                serviceAreas.location,
                services.price,
                services.serviceID,
                appointments.bookingAdvance,
                serviceAreaTimeslots.timeslotDate,
                appointments.appointmentStatus 
                FROM appointments 
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
                WHERE appointments.customerID = @customerID
                AND appointments.appointmentID = @appointmentID"
                ' Create a new SQL connection
                Using connection As New MySqlConnection(SessionManager.connectionString)
                    ' Open the connection
                    connection.Open()

                    ' Create a new SQL command
                    Using command As New MySqlCommand(query, connection)
                        ' Set the parameter value for UserID
                        command.Parameters.AddWithValue("@customerID", SessionManager.customerID)
                        command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)

                        ' Execute the SQL command and create a data reader
                        Using reader As MySqlDataReader = command.ExecuteReader()
                            ' Create a list to hold the labels data
                            Dim labels As New List(Of String)()

                            ' Read data from the reader
                            If reader.Read() Then

                                Dim sp_name As String = reader("serviceProviderName").ToString()
                                Dim sp_service As String = reader("serviceTypeName").ToString()
                                Dim sp_date As String = reader("timeslotDate").ToString()
                                Dim dateObject As DateTime = DateTime.ParseExact(sp_date, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)

                                ' Format the DateTime object to display only the date
                                Dim formattedDate As String = dateObject.ToString("dd-MM-yyyy")
                                Dim appoinment_slot As String = reader("startTime").ToString()
                                Dim sp_num As String = reader("mobileNumber").ToString()
                                Dim sp_loc As String = reader("location").ToString()
                                Dim sp_price As String = reader("price").ToString()
                                Dim sp_adv As String = reader("bookingAdvance").ToString()
                                Dim serviceID As String = reader("serviceID").ToString()
                                ' Set the retrieved values to the corresponding textboxes
                                InProgressPaymentNotDone.SP_name_tb.Text = sp_name
                                InProgressPaymentNotDone.SP_service_tb.Text = sp_service
                                InProgressPaymentNotDone.Booked_slot_tb.Text = formattedDate + "  " + appoinment_slot
                                InProgressPaymentNotDone.SP_contactno.Text = sp_num
                                InProgressPaymentNotDone.SP_loc.Text = sp_loc
                                InProgressPaymentNotDone.SP_price.Text = sp_price
                                InProgressPaymentNotDone.advpaid.Text = sp_adv
                                InProgressPaymentNotDone.rembal.Text = sp_price - sp_adv
                                InProgressPaymentNotDone._serviceID = serviceID
                            End If
                        End Using
                    End Using
                End Using

                .BringToFront()
                .Show()
            End With

        Else
            With Homepage_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(Homepage_Customer)
                .BringToFront()
                .Show()
            End With
        End If
    End Sub

End Class