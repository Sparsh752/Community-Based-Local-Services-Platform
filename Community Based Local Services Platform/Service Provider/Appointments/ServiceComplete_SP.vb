Public Class ServiceComplete_SP
    Private ServiceProviderName As String
    Private ServiceProviderAddress As String
    Private ServiceProviderPhone As String
    Private ServiceName As String
    Private Price As String
    Private BookedSlot As String
    Private ServiceLocation As String
    Private appointmentID As String
    Private spID As String

    Private chatPanel As New Panel()
    Private Sub ServiceComplete_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        LoadChatPanel()

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

        Dim label As New Label()
        label.Text = "Ask customer for the OTP before leaving the premises to complete the transaction."
        label.Font = New Font("Bahnschrift Light", 8, FontStyle.Regular)
        label.Location = New Point(85, 520)
        label.AutoSize = True
        label.MaximumSize = New Size(345, 45)
        Panel1.Controls.Add(label)

        RichTextBox1.Clear()
        RichTextBox2.Clear()
        RichTextBox3.Clear()
        RichTextBox4.Clear()

        RichTextBox1.Font = New Font("Bahnschrift Light", 16, FontStyle.Regular)
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
        RichTextBox2.Font = New Font("Bahnschrift Light", 16, FontStyle.Regular)
        RichTextBox2.SelectionAlignment = HorizontalAlignment.Center
        RichTextBox3.Font = New Font("Bahnschrift Light", 16, FontStyle.Regular)
        RichTextBox3.SelectionAlignment = HorizontalAlignment.Center
        RichTextBox4.Font = New Font("Bahnschrift Light", 16, FontStyle.Regular)
        RichTextBox4.SelectionAlignment = HorizontalAlignment.Center

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        SendOTP()

    End Sub

    Function SendOTP()

        Using connection As New MySqlConnection(SessionManager.connectionString)

            Dim getOTP = " SELECT 
                otpCode
            FROM 
                OTPs
            WHERE 
                appointmentID = @appointmentID;"

            Dim comm As New MySqlCommand(getOTP, connection)
            Dim _otp As String = ""


            Using reader As MySqlDataReader = comm.ExecuteReader()

                While reader.Read()
                    _otp = (reader("otpCode").ToString())
                End While

            End Using

            Dim notifmsg As String = "Service Complete! The OTP for appointment " & SessionManager.appointmentID & " is " & _otp
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

    Private Sub LoadChatPanel()

        chatPanel.Location = New Point(687, 125)
        chatPanel.Size = New Size(437, 490)
        chatPanel.BorderStyle = BorderStyle.FixedSingle
        chatPanel.BackColor = Color.White

        Panel1.Controls.Add(chatPanel)

        With ChatBox
            .TopLevel = False
            .Dock = DockStyle.Fill
            chatPanel.Controls.Add(ChatBox)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub RichTextBox_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged, RichTextBox2.TextChanged, RichTextBox3.TextChanged, RichTextBox4.TextChanged
        Dim rtb = DirectCast(sender, RichTextBox)
        Dim otp = rtb.Text

        ' Check if the OTP length is greater than 1
        If otp.Length > 1 Then
            ' Remove additional characters
            rtb.Text = otp.Substring(0, 1)
            rtb.SelectionStart = 1
            MessageBox.Show("OTP should be a single digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if the character is a digit
        If otp.Length > 1 And Not Char.IsDigit(otp) Then
            ' Clear invalid characters
            rtb.Text = ""
            MessageBox.Show("OTP should be a single digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function FetchOTP(ByVal appointmentID As Integer) As (otp As String, expirationTime As DateTime)
        ' Connection string

        ' Query to fetch OTP for the given appointmentID
        Dim query As String = "
        SELECT 
            otpCode AS OTP,
            otpExpiration AS ExpirationTime
        FROM 
            OTPs
        WHERE 
            appointmentID = @appointmentID;
    "

        ' Initialize the OTP and expiration time variables
        Dim otp As String = ""
        Dim expirationTime As DateTime = DateTime.MinValue

        ' Create a new connection
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()

            ' Create a command with the query and connection
            Using command As New MySqlCommand(query, connection)
                ' Add parameter for appointmentID
                command.Parameters.AddWithValue("@appointmentID", appointmentID)

                ' Execute the command and get the data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Check if there is data
                    If reader.Read() Then
                        ' Retrieve the OTP and expiration time
                        otp = reader("OTP").ToString()
                        expirationTime = Convert.ToDateTime(reader("ExpirationTime"))
                    End If
                End Using
            End Using
        End Using

        ' Return the fetched OTP and expiration time as a tuple
        Return (otp, expirationTime)
    End Function


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

    Private Sub DeleteOtpAfterCompletion()
        Dim query As String = "DELETE FROM OTPs
            WHERE appointmentID = @appointmentID;"
        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                command.ExecuteReader()
            End Using
            connection.Close()
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Concatenate the text from four RichTextBoxes
        Dim enteredOTP As String = RichTextBox1.Text & RichTextBox2.Text & RichTextBox3.Text & RichTextBox4.Text

        ' Fetch the OTP and its expiration time for the given appointment ID (replace 123 with the actual appointment ID)
        'Dim appointmentID As Integer = 123
        Dim otpTuple As (otp As String, expirationTime As DateTime) = FetchOTP(appointmentID:=SessionManager.appointmentID)

        ' Check if the OTP has expired
        'If otpTuple.expirationTime < DateTime.Now Then
        '    MessageBox.Show("OTP has expired.")
        '    Return
        'Else
        ' Compare the entered OTP with the fetched OTP

        'Not using OTP expiration
        'OTP match - assumption money is tranferred to service provider

        If enteredOTP = otpTuple.otp Then
            MessageBox.Show("OTP entered is correct!")
            DeleteOtpAfterCompletion()
            RemovePreviousForm()

            For Each ctrl As Control In chatPanel.Controls
                If TypeOf ctrl Is Form Then
                    Dim formCtrl As Form = DirectCast(ctrl, Form)
                    formCtrl.Close()
                End If
            Next

            Me.Close()

            With TransactionComplete_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(TransactionComplete_SP)
                .BringToFront()
                .Show()
            End With
        Else
            MessageBox.Show("OTP entered is incorrect.")
        End If

        'End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class