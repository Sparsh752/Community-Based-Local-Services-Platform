Imports Community_Based_Local_Services_Platform.Display_Services
Imports Mysqlx.Crud

Public Class Cancelled_By_Customer
    Private Sub Cancelled_By_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show("cfbajc")
        Me.Size() = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = BorderStyle.None

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        Dim query As String = "Select appointments.appointmentID, 
                serviceproviders.serviceProviderName,
                serviceTypes.serviceTypeName,
                serviceAreaTimeslots.startTime,
                contactDetails.mobileNumber,
                serviceAreas.location,
                services.price,
                appointments.bookingAdvance,
                serviceAreaTimeslots.timeslotDate,
                cancelledAppointments.refundAmount,
                appointments.appointmentStatus 
                From appointments
                Join serviceproviders
                On appointments.serviceProviderID = serviceproviders.serviceProviderID 
                Join cancelledAppointments
                On appointments.appointmentID = cancelledAppointments.appointmentID
                Join serviceAreaTimeslots
                On appointments.areaTimeslotID = serviceAreaTimeslots.areaTimeslotID 
                Join contactDetails
                On contactDetails.UserID = serviceproviders.userID
                Join serviceAreas
                On serviceAreas.areaID = serviceAreaTimeslots.areaID
                Join services
                On services.serviceTypeID = serviceAreaTimeslots.serviceTypeID
                And services.serviceProviderID = serviceAreaTimeslots.serviceProviderID 
                Join serviceTypes 
                On serviceAreaTimeslots.serviceTypeID = serviceTypes.serviceID 
                WHERE appointments.customerID = @customerID
                And appointments.appointmentID = @appointmentID;"

        ' Create a new connection object
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()
            ' Create a new command object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Set the parameter value for UserID
                command.Parameters.AddWithValue("@customerID", SessionManager.customerID)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                ' Execute the command and get the data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Read the data

                    ' Check if data is available
                    If reader.Read() Then
                        ' Populate RichTextBox controls with fetched data
                        RichTextBox1.Text = reader("mobileNumber").ToString()
                        RichTextBox7.Text = reader("serviceProviderName").ToString()
                        RichTextBox2.Text = reader("serviceTypeName").ToString()
                        RichTextBox3.Text = reader("price").ToString()
                        Dim _date As String = reader("timeslotDate").ToString()
                        Dim dateObject As DateTime = DateTime.ParseExact(_date, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)
                        Dim formattedDate As String = dateObject.ToString("dd-MM-yyyy")
                        RichTextBox4.Text = formattedDate
                        RichTextBox5.Text = reader("location").ToString()
                        RichTextBox13.Text = reader("refundAmount").ToString()
                    Else
                        MessageBox.Show("Appointment not found.")
                    End If
                End Using
            End Using

            ' Close connection
            connection.Close()
        End Using

        RichTextBox1.ReadOnly = True
        RichTextBox2.ReadOnly = True
        RichTextBox3.ReadOnly = True
        RichTextBox4.ReadOnly = True
        RichTextBox5.ReadOnly = True
        RichTextBox6.ReadOnly = True
        RichTextBox7.ReadOnly = True
        RichTextBox8.ReadOnly = True
        RichTextBox9.ReadOnly = True
        RichTextBox10.ReadOnly = True
        RichTextBox11.ReadOnly = True
        RichTextBox12.ReadOnly = True
        RichTextBox13.ReadOnly = True
        RichTextBox14.ReadOnly = True

    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        RemovePreviousForm()
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