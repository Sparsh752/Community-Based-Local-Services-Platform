Imports System.Globalization
Imports System.IO

Public Class Appointment_booking

    Private appointmentType As String
    Private selectedLocation As String
    Private selectedDate As DateTime
    Private selectedTimeSlot As String
    Private serviceID As String
    Private userID As String = SessionManager.userID

    ' Constructor to accept the string parameter
    Public Sub New(ByVal str As String, serviceID As String)
        InitializeComponent()
        appointmentType = str
        Me.serviceID = serviceID
    End Sub

    Private Sub Appointment_booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)

        ' MessageBox.Show("service ID: " & serviceID, "serviceID", MessageBoxButtons.OK,
        MessageBoxIcon.Information)

        Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\appointment-book.png")

        Try
            If Not File.Exists(imagePath) Then
                MessageBox.Show("Image file not found: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim im As New PictureBox()
        im.SizeMode = PictureBoxSizeMode.StretchImage
        im.Size = New Size(220, 220)
        im.Location = New Point(800, 150)
        im.Image = Image.FromFile(imagePath)

        Me.Controls.Add(im)

        If (appointmentType = "Reschedule") Then
            Button10.Text = "Reschedule"
        Else
            Button10.Text = "Proceed to Pay"
        End If

    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub RescheduleAppointment(appointmentID As Integer, newDate As DateTime, newTime As String, newLocation As String)
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
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Me.Close()

        If (appointmentType = "Reschedule") Then
            Dim currentDateTime As DateTime = DateTime.Now

            ' Combine selected date and time
            Dim selectedDateTime As DateTime = selectedDate.Date + TimeSpan.Parse(selectedTimeSlot)
            ' Check if the selected date and time are in the past
            If selectedDateTime <= currentDateTime Then
                MessageBox.Show("Selected date and time cannot be in the past. Please select a future date and time for rescheduling.")
            Else
                RemovePreviousForm()
                RescheduleAppointment(SessionManager.appointmentID, selectedDate, selectedTimeSlot, selectedLocation)
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
                Panel3.Controls.Add(Payment_Gateway)
                .BringToFront()
                .Show()
            End With
        End If

    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        selectedLocation = ComboBox1.SelectedItem.ToString()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        selectedDate = DateTimePicker1.Value
    End Sub
    Private Sub ButtonTimeSlot_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        ' Determine which button was clicked and extract the selected time slot
        Dim clickedButton As Button = DirectCast(sender, Button)
        Dim timeValue As String = clickedButton.Text
        Dim parsedTime As DateTime = DateTime.ParseExact(timeValue, "hh:mm tt", CultureInfo.InvariantCulture)
        selectedTimeSlot = parsedTime.ToString("HH:mm:ss")
    End Sub

End Class