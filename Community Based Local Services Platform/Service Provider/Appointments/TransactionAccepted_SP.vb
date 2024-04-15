Public Class TransactionAccepted_SP
    Private CustomerName As String
    Private CustomerAddress As String
    Private CustomerPhone As String
    Private ServiceName As String
    Private Price As String
    Private BookedSlot As String
    Private ServiceLocation As String
    Private appointmentID As String
    Private spID As String

    Private chatPanel As New Panel()
    Private Sub TransactionAccepted_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            AND appointments.appointmentID = @appointmentID;
"

        ' Create a list to hold the data
        Dim dataList As New List(Of String)()

        ' Create a new connection object
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()
            ' Create a new command object with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Set the parameter value for appointmentID
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID) ' Replace YourAppointmentID with the actual appointment ID you want to retrieve details for
                command.Parameters.AddWithValue("@spID", SessionManager.spID) ' Replace spID with the actual SP ID you want to retrieve details for
                ' Execute the command and get the data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Read the data
                    If reader.Read() Then
                        ' Add the data to the list
                        dataList.Add(reader("CustomerName").ToString()) ' Assuming CustomerName is fetched from the query
                        dataList.Add(reader("CustomerAddress").ToString()) ' Assuming CustomerAddress is fetched from the query
                        dataList.Add(reader("CustomerPhone").ToString()) ' Assuming CustomerPhone is fetched from the query
                        dataList.Add(reader("ServiceName").ToString()) ' Assuming ServiceName is fetched from the query
                        dataList.Add(reader("Price").ToString()) ' Assuming Price is fetched from the query

                        Dim bookedSlot As String = $"{reader("BookedSlot").ToString()}" ' Assuming BookedSlot is fetched from the query
                        dataList.Add(bookedSlot)

                        dataList.Add(reader("ServiceLocation").ToString()) ' Assuming ServiceLocation is fetched from the query
                    End If
                End Using
            End Using
        End Using

        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None

        ' Ensure that dataList has at least 7 elements before accessing them
        If dataList.Count >= 7 Then
            Label5.Text = dataList(0) ' CustomerName
            Label6.Text = dataList(1) ' CustomerAddress
            Label7.Text = dataList(2) ' CustomerPhone
            Label8.Text = dataList(3) ' ServiceName
            Label9.Text = dataList(4) ' Price
            Label10.Text = dataList(5) ' BookedSlot
            Label11.Text = dataList(6) ' ServiceLocation
        Else
            ' If dataList doesn't have enough elements, display an error message or handle it accordingly
            MessageBox.Show($"Insufficient data retrieved from the database. Expected at least 7 elements, but got {dataList.Count} elements.")
        End If



        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        LoadChatPanel()

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

End Class