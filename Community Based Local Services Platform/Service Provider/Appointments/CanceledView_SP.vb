Public Class CanceledView_SP
    Private Sub CancelledView_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            services ON appointments.serviceID = services.serviceID 
        JOIN 
            serviceTypes ON services.serviceTypeID = serviceTypes.serviceID 
        JOIN 
            serviceAreas ON serviceAreaTimeslots.areaID = serviceAreas.areaID 
        WHERE
            appointments.serviceProviderID = @spID
            AND appointments.appointmentID = @appointmentID;"

        Me.Size() = New Size(1200, 700)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

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

        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()
            ' Create a new command object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Set the parameter value for appointmentID
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                command.Parameters.AddWithValue("@spID", SessionManager.spID)
                ' Execute the command and get the data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Read the data
                    If reader.Read() Then
                        ' Add the data to the list
                        RichTextBox7.Text = (reader("CustomerName").ToString()) ' Assuming CustomerName is fetched from the query
                        'RichTextBox7.Text = (reader("CustomerAddress").ToString()) ' Assuming CustomerAddress is fetched from the query
                        RichTextBox1.Text = (reader("CustomerPhone").ToString()) ' Assuming CustomerPhone is fetched from the query
                        RichTextBox2.Text = (reader("ServiceName").ToString()) ' Assuming ServiceName is fetched from the query
                        RichTextBox3.Text = (reader("Price").ToString()) ' Assuming Price is fetched from the query

                        Dim bookedSlot As String = $"{reader("BookedSlot").ToString()}" ' Assuming BookedSlot is fetched from the query
                        RichTextBox4.Text = (bookedSlot)

                        RichTextBox5.Text = (reader("ServiceLocation").ToString()) ' Assuming ServiceLocation is fetched from the query
                    End If
                End Using
            End Using
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

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        RemovePreviousForm()
        Me.Close()
        With AppointmentList_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_SP)
            .BringToFront()
            .Show()
        End With
    End Sub

End Class