Imports ZstdSharp.Unsafe

Public Class Rejected_View
    Private Sub Rejected_View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size() = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        Dim _status As String = "Pending"

        Dim query As String = "Select appointments.appointmentID, 
                serviceproviders.serviceProviderName,
                serviceTypes.serviceTypeName,
                serviceAreaTimeslots.startTime,
                contactDetails.mobileNumber,
                serviceAreas.location,
                services.price,
                appointments.bookingAdvance,
                serviceAreaTimeslots.timeslotDate,
                appointments.appointmentStatus 
                From appointments
                Join serviceproviders
                On appointments.serviceProviderID = serviceproviders.serviceProviderID 
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
                        RichTextBox13.Text = reader("bookingAdvance").ToString()

                        _status = reader("appointmentStatus").ToString()

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

        If _status = "Pending" Then
            RichTextBox6.Text = "This appointment is pending at service provider's end."
            RichTextBox12.Text = ""
            RichTextBox13.Text = ""
            RichTextBox14.Text = ""
        Else
            RichTextBox6.Text = "This booking was canceled by the service provider."
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
        Me.Close()
        With AppointmentList_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_Customer)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub RichTextBox6_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox6.TextChanged

    End Sub
End Class