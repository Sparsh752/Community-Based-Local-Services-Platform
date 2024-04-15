Imports System.IO
Imports Mysqlx

Public Class Payment_Gateway

    Public serviceID As String
    Public selectedDate As DateTime
    Public selectedTimeSlot As String
    Public advancepayment As Decimal
    Public serviceProviderID As String
    Public serviceLocation As String
    Public areaId As String
    Public areaTimeSlotId As String
    Public serviceTypeID As String
    Public paymentMode As String
    Public paymentID As String

    Dim UPI_button As New Button()
    Dim D_Card_button As New Button()
    Dim C_Card_button As New Button()
    Dim QR_button As New Button()
    Dim Panel2 As New Panel()
    Public Price As String
    Dim PaymentType As Boolean


    Dim UPI_ID As New TextBox()
    Dim CardNumber As New TextBox()
    Dim CVV As New TextBox()
    Dim Month As New TextBox()
    Dim Year As New TextBox()

    Public Sub RetrievePrice()
        Dim checkQuery As String = "SELECT bookingAdvance
            FROM appointments
            WHERE appointmentID = @appointmentID"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()

            Using checkCommand As New MySqlCommand(checkQuery, connection)
                checkCommand.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)

                Dim reader As MySqlDataReader = checkCommand.ExecuteReader()

                If reader.HasRows Then
                    ' If the query returns any record
                    While reader.Read()
                        Dim bookingAdvance As Decimal = reader.GetDecimal(0) ' Assuming bookingAdvance is a decimal field

                        Price = bookingAdvance.ToString()
                    End While
                    PaymentType = 1
                End If

                reader.Close() ' Close the reader when done reading
            End Using

            connection.Close()
        End Using
    End Sub
    Private Sub Gateway_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MessageBox.Show(Price)
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)
        Dim panel1 As New Panel()
        panel1.BackColor = ColorTranslator.FromHtml("#EDEDED")
        panel1.Size = New Size(359, 700)
        panel1.Location = New Point(0, 0)
        Me.Controls.Add(panel1)
        Me.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        Me.Size = New Size(1200, 700)

        Panel2.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        Panel2.Location = New Point(359, 0)
        Panel2.Size = New Size(841, 700)
        Me.Controls.Add(Panel2)
        Dim Heading As New Label()
        Heading.Text = "Payment Gateway"
        Heading.Font = New Font("Bahnschrift Light", 20, FontStyle.Bold)
        Heading.Location = New Point(34, 92)
        Heading.Size = New Size(251, 83)
        Heading.TextAlign = ContentAlignment.MiddleCenter
        panel1.Controls.Add(Heading)
        Dim lineLabel As New Label()
        lineLabel.BorderStyle = BorderStyle.Fixed3D
        lineLabel.Location = New Point(34, 207)
        lineLabel.Size = New Size(256, 1)
        panel1.Controls.Add(lineLabel)

        UPI_button.Text = "UPI"
        UPI_button.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
        UPI_button.Location = New Point(57, 243)
        panel1.Controls.Add(UPI_button)
        UPI_button.FlatStyle = FlatStyle.Flat
        UPI_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        UPI_button.FlatAppearance.BorderSize = 0
        UPI_button.Size = New Size(239, 28)
        UPI_button.ForeColor = Color.White
        UPI_button.TextAlign = ContentAlignment.MiddleLeft

        D_Card_button.Text = "DEBIT CARD"
        D_Card_button.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
        D_Card_button.Location = New Point(57, 291)
        panel1.Controls.Add(D_Card_button)
        D_Card_button.FlatStyle = FlatStyle.Flat
        D_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        D_Card_button.FlatAppearance.BorderSize = 0
        D_Card_button.Size = New Size(239, 28)
        D_Card_button.ForeColor = Color.Black
        D_Card_button.TextAlign = ContentAlignment.MiddleLeft

        C_Card_button.Text = "CREDIT CARD"
        C_Card_button.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
        C_Card_button.Location = New Point(57, 339)
        panel1.Controls.Add(C_Card_button)
        C_Card_button.FlatStyle = FlatStyle.Flat
        C_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        C_Card_button.FlatAppearance.BorderSize = 0
        C_Card_button.Size = New Size(239, 28)
        C_Card_button.ForeColor = Color.Black
        C_Card_button.TextAlign = ContentAlignment.MiddleLeft

        QR_button.Text = "QR CODE"
        QR_button.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
        QR_button.Location = New Point(57, 387)
        panel1.Controls.Add(QR_button)
        QR_button.FlatStyle = FlatStyle.Flat
        QR_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        QR_button.FlatAppearance.BorderSize = 0
        QR_button.Size = New Size(239, 28)
        QR_button.ForeColor = Color.Black
        QR_button.TextAlign = ContentAlignment.MiddleLeft
        AddHandler UPI_button.Click, AddressOf UPI_button_Click
        AddHandler D_Card_button.Click, AddressOf D_Card_button_Click
        AddHandler C_Card_button.Click, AddressOf C_Card_button_Click
        AddHandler QR_button.Click, AddressOf QR_button_Click
        PaymentType = False
        RemovePreviousForm()
        RetrievePrice()
        LoadUPI()
        paymentMode = "upi"
    End Sub
    Private Sub UPI_button_Click(sender As Object, e As EventArgs)
        UPI_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        UPI_button.ForeColor = Color.White
        D_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        D_Card_button.ForeColor = Color.Black
        C_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        C_Card_button.ForeColor = Color.Black
        QR_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        QR_button.ForeColor = Color.Black
        RemovePreviousForm()
        LoadUPI()
    End Sub
    Private Sub D_Card_button_Click(sender As Object, e As EventArgs)
        D_Card_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        D_Card_button.ForeColor = Color.White
        C_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        C_Card_button.ForeColor = Color.Black
        UPI_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        UPI_button.ForeColor = Color.Black
        QR_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        QR_button.ForeColor = Color.Black
        RemovePreviousForm()
        LoadCard()
        paymentMode = "debit"
    End Sub



    Private Sub C_Card_button_Click(sender As Object, e As EventArgs)
        C_Card_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        C_Card_button.ForeColor = Color.White
        D_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        D_Card_button.ForeColor = Color.Black
        UPI_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        UPI_button.ForeColor = Color.Black
        QR_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        QR_button.ForeColor = Color.Black
        RemovePreviousForm()
        LoadCard()
        paymentMode = "credit"
    End Sub
    Private Sub QR_button_Click(sender As Object, e As EventArgs)
        QR_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        QR_button.ForeColor = Color.White
        UPI_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        UPI_button.ForeColor = Color.Black
        D_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        D_Card_button.ForeColor = Color.Black
        C_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        C_Card_button.ForeColor = Color.Black
        RemovePreviousForm()
        LoadQR()
        paymentMode = "qr"
    End Sub

    Private Sub RemovePreviousForm()
        Panel2.Controls.Clear()
    End Sub

    Private Sub RemovePreviousPanel3Form()
        PaymentType = False

        For Each ctrl As Control In Panel3.Controls
            If TypeOf ctrl Is Form Then
                ' Remove the first control (form) from Panel5
                Dim formCtrl As Form = DirectCast(ctrl, Form)
                formCtrl.Close()
            End If
        Next

        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub
    Private Sub LoadUPI()
        Dim Amount_label As New Label()
        Amount_label.Text = "Amount"
        Amount_label.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Amount_label.Location = New Point(137, 156)
        Panel2.Controls.Add(Amount_label)
        Amount_label.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim Amount As New Label()
        Amount.Text = "Rs." + Price
        Amount.Font = New Font("Bahnschrift Light", 26, FontStyle.Bold)
        Amount.Location = New Point(137, 179)
        Panel2.Controls.Add(Amount)
        Amount.AutoSize = True
        Dim EnterUPI As New Label()
        EnterUPI.Text = "Enter UPI ID"
        EnterUPI.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterUPI.Location = New Point(137, 275)
        Panel2.Controls.Add(EnterUPI)
        EnterUPI.ForeColor = ColorTranslator.FromHtml("#888888")
        UPI_ID.Size = New Size(560, 59)
        UPI_ID.BorderStyle = BorderStyle.FixedSingle
        UPI_ID.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        UPI_ID.Location = New Point(137, 312)
        Panel2.Controls.Add(UPI_ID)
        Dim Proceed_Button As New Button()
        Proceed_Button.Text = "Proceed"
        Proceed_Button.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Proceed_Button.Location = New Point(137, 431)
        Panel2.Controls.Add(Proceed_Button)
        Proceed_Button.FlatStyle = FlatStyle.Flat
        Proceed_Button.BackColor = ColorTranslator.FromHtml("#F9754B")
        Proceed_Button.FlatAppearance.BorderSize = 0
        Proceed_Button.Size = New Size(150, 40)
        Proceed_Button.ForeColor = Color.White
        AddHandler Proceed_Button.Click, AddressOf Proceed_Button_Click

    End Sub
    Private Sub LoadCard()
        Dim Amount_label As New Label()
        Amount_label.Text = "Amount"
        Amount_label.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Amount_label.Location = New Point(137, 156)
        Panel2.Controls.Add(Amount_label)
        Amount_label.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim Amount As New Label()
        Amount.Text = "Rs." + Price
        Amount.Font = New Font("Bahnschrift Light", 26, FontStyle.Bold)
        Amount.Location = New Point(137, 179)
        Panel2.Controls.Add(Amount)
        Amount.AutoSize = True

        Dim EnterCardNumber As New Label()
        EnterCardNumber.Text = "Card Number"
        EnterCardNumber.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterCardNumber.Location = New Point(137, 275)
        Panel2.Controls.Add(EnterCardNumber)
        EnterCardNumber.ForeColor = ColorTranslator.FromHtml("#888888")

        CardNumber.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        CardNumber.Location = New Point(137, 312)
        Panel2.Controls.Add(CardNumber)
        CardNumber.Size = New Size(560, 59)
        CardNumber.BorderStyle = BorderStyle.FixedSingle

        Dim EnterCVV As New Label()
        EnterCVV.Text = "CVV"
        EnterCVV.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterCVV.Location = New Point(137, 400)
        Panel2.Controls.Add(EnterCVV)
        EnterCVV.ForeColor = ColorTranslator.FromHtml("#888888")

        CVV.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        CVV.Location = New Point(137, 437)
        Panel2.Controls.Add(CVV)
        CVV.Size = New Size(140, 59)
        CVV.BorderStyle = BorderStyle.FixedSingle

        Dim EnterMonth As New Label()
        EnterMonth.Text = "Month(MM)"
        EnterMonth.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterMonth.Location = New Point(337, 400)
        Panel2.Controls.Add(EnterMonth)
        EnterMonth.ForeColor = ColorTranslator.FromHtml("#888888")

        Month.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Month.Location = New Point(337, 437)
        Panel2.Controls.Add(Month)
        Month.Size = New Size(140, 59)
        Month.BorderStyle = BorderStyle.FixedSingle

        Dim EnterYear As New Label()
        EnterYear.Text = "Year(YYYY)"
        EnterYear.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterYear.Location = New Point(537, 400)
        Panel2.Controls.Add(EnterYear)
        EnterYear.ForeColor = ColorTranslator.FromHtml("#888888")

        Year.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Year.Location = New Point(537, 437)
        Panel2.Controls.Add(Year)
        Year.Size = New Size(140, 59)
        Year.BorderStyle = BorderStyle.FixedSingle

        Dim Proceed_Button As New Button()
        Proceed_Button.Text = "Proceed"
        Proceed_Button.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Proceed_Button.Location = New Point(137, 520)
        Panel2.Controls.Add(Proceed_Button)
        Proceed_Button.FlatStyle = FlatStyle.Flat
        Proceed_Button.BackColor = ColorTranslator.FromHtml("#F9754B")
        Proceed_Button.FlatAppearance.BorderSize = 0
        Proceed_Button.Size = New Size(150, 40)
        Proceed_Button.ForeColor = Color.White
        AddHandler Proceed_Button.Click, AddressOf Proceed_Button_Click

    End Sub

    Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\QR.png")
    Private Sub LoadQR()
        Dim Amount_label As New Label()
        Amount_label.Text = "Amount"
        Amount_label.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Amount_label.Location = New Point(137, 156)
        Panel2.Controls.Add(Amount_label)
        Amount_label.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim Amount As New Label()
        Amount.Text = "Rs." + Price
        Amount.Font = New Font("Bahnschrift Light", 26, FontStyle.Bold)
        Amount.Location = New Point(137, 179)
        Panel2.Controls.Add(Amount)
        Amount.AutoSize = True

        Dim QRCode As New PictureBox()
        QRCode.Image = Image.FromFile(imagePath) ' Specify the path to your image
        QRCode.SizeMode = PictureBoxSizeMode.StretchImage
        QRCode.Location = New Point(137, 250) ' Adjust the location as needed
        QRCode.Size = New Size(200, 200) ' Adjust the size as needed
        Panel2.Controls.Add(QRCode)


        Dim Proceed_Button As New Button()
        Proceed_Button.Text = "Proceed"
        Proceed_Button.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Proceed_Button.Location = New Point(137, 520)
        Panel2.Controls.Add(Proceed_Button)
        Proceed_Button.FlatStyle = FlatStyle.Flat
        Proceed_Button.BackColor = ColorTranslator.FromHtml("#F9754B")
        Proceed_Button.FlatAppearance.BorderSize = 0
        Proceed_Button.Size = New Size(150, 40)
        Proceed_Button.ForeColor = Color.White
        AddHandler Proceed_Button.Click, AddressOf Proceed_Button_Click

    End Sub

    Private Sub Proceed_Button_Click(sender As Object, e As EventArgs)

        If paymentMode = "qr" Then
            ' Code to handle QR payment mode
        ElseIf paymentMode = "upi" Then
            ' Code to handle UPI payment mode\
            If String.IsNullOrWhiteSpace(UPI_ID.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter your UPI ID.")
                Return
            End If
        ElseIf paymentMode = "debit" Then
            ' Code to handle debit card payment mode
            If String.IsNullOrWhiteSpace(CardNumber.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter your Debit Card Number.")
                Return
            End If
            If String.IsNullOrWhiteSpace(CVV.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter the CVV")
                Return
            End If
            If String.IsNullOrWhiteSpace(Month.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter the Expiry Month.")
                Return
            End If
            If String.IsNullOrWhiteSpace(Year.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter the Expiry Year.")
                Return
            End If
        ElseIf paymentMode = "credit" Then
            ' Code to handle credit card payment mode
            If String.IsNullOrWhiteSpace(CardNumber.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter your Credit Card Number.")
                Return
            End If
            If String.IsNullOrWhiteSpace(CVV.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter the CVV")
                Return
            End If
            If String.IsNullOrWhiteSpace(Month.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter the Expiry Month.")
                Return
            End If
            If String.IsNullOrWhiteSpace(Year.Text) Then
                ' Display an error message or perform any action for empty UPI ID
                MessageBox.Show("Please enter the Expiry Year.")
                Return
            End If
        Else
            ' Code to handle invalid payment mode
            MessageBox.Show("Invalid payment mode!")
        End If


        Dim confirmationMessage As String = "Rs. " & Price & " will be deducted from your bank account."
        Dim result As DialogResult = MessageBox.Show(confirmationMessage, "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

        If result = DialogResult.OK And PaymentType = True Then
            Dim checkQuery As String = "UPDATE appointments SET appointmentStatus='Completed' WHERE appointmentID = @appointmentID"

            Dim paymentQuery As String = "Insert into payments values (@paymentID, @appointmentID, @amount, NOW(), @paymentType, @paymentStatus, @paymentMode)"
            Dim countPaymentQuery As String = "Select count(*) from payments"


            Using connection As New MySqlConnection(SessionManager.connectionString)
                connection.Open()

                Using checkCommand As New MySqlCommand(checkQuery, connection)
                    checkCommand.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                    checkCommand.ExecuteNonQuery() ' Use ExecuteNonQuery for UPDATE queries

                End Using

                Using countPaymentsCommand As New MySqlCommand(countPaymentQuery, connection)
                    Dim temp As Integer = Convert.ToInt32(countPaymentsCommand.ExecuteScalar())
                    temp += 1
                    paymentID = temp.ToString()
                End Using

                'Dim currDateTime As String = Now()

                Using paymentCommand As New MySqlCommand(paymentQuery, connection)
                    paymentCommand.Parameters.AddWithValue("@paymentID", paymentID)
                    paymentCommand.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                    paymentCommand.Parameters.AddWithValue("@amount", Price)
                    'paymentCommand.Parameters.AddWithValue("@paymentDateTime", currDateTime)
                    paymentCommand.Parameters.AddWithValue("@paymentType", "Final")
                    paymentCommand.Parameters.AddWithValue("@paymentStatus", "Completed")
                    paymentCommand.Parameters.AddWithValue("@paymentMode", paymentMode)
                    paymentCommand.ExecuteNonQuery() ' Use ExecuteNonQuery for Insert queries

                    ' After executing the query, you can show a success message or perform any other necessary actions
                    MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                SendNotification()
                connection.Close()
            End Using




            RemovePreviousPanel3Form()
            With Homepage_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(Homepage_Customer)
                .BringToFront()
                .Show()
            End With
        ElseIf result = DialogResult.OK And PaymentType = False Then

            ' inserting into appointment table
            Dim countQuery As String = "SELECT COUNT(*) FROM appointments"
            Dim countAreaTimeSlotQuery As String = "SELECT COUNT(*) FROM serviceAreaTimeslots"
            Dim checkQuery As String = "Insert into appointments values (@appointmentID, @serviceProviderID, @customerID, @areaTimeSlotID, @bookingAdvance, @serviceID, 'Pending')"
            Dim areaTimeSLotQuery As String = "Insert into serviceAreaTimeslots values (@areaTimeSlotID, @serviceProviderID, @areaID, @serviceTypeID, @startTime, @timeSlotDate, @serviceID)"
            Dim areaIdQuery As String = "Select areaID from serviceAreas where location = @serviceLocation"

            Dim paymentQuery As String = "Insert into payments values (@paymentID, @appointmentID, @amount, NOW(), @paymentType, @paymentStatus, @paymentMode)"
            Dim countPaymentQuery As String = "Select count(*) from payments"


            Using connection As New MySqlConnection(SessionManager.connectionString)
                connection.Open()

                Using countCommand As New MySqlCommand(countQuery, connection)
                    Dim count As Integer = Convert.ToInt32(countCommand.ExecuteScalar())
                    ' Add 1 to the count and store it in SessionManager.appointmentID
                    SessionManager.appointmentID = count + 1
                End Using

                Using countAreaTimeSlotCommand As New MySqlCommand(countAreaTimeSlotQuery, connection)
                    Dim temp As Integer = Convert.ToInt32(countAreaTimeSlotCommand.ExecuteScalar())
                    temp += 1
                    areaTimeSlotId = temp.ToString()
                End Using

                Using areaIdCommand As New MySqlCommand(areaIdQuery, connection)
                    areaIdCommand.Parameters.AddWithValue("@serviceLocation", serviceLocation)
                    areaId = areaIdCommand.ExecuteScalar().ToString()
                    ' Add 1 to the count and store it in SessionManager.appointmentID
                End Using

                Using areaTimeSlotCommand As New MySqlCommand(areaTimeSLotQuery, connection)
                    areaTimeSlotCommand.Parameters.AddWithValue("@areaTimeSlotID", areaTimeSlotId)
                    areaTimeSlotCommand.Parameters.AddWithValue("@serviceProviderID", serviceProviderID)
                    areaTimeSlotCommand.Parameters.AddWithValue("@areaID", areaId)
                    areaTimeSlotCommand.Parameters.AddWithValue("@serviceTypeID", serviceTypeID)
                    areaTimeSlotCommand.Parameters.AddWithValue("@startTime", selectedTimeSlot)
                    areaTimeSlotCommand.Parameters.AddWithValue("@timeSlotDate", selectedDate)
                    areaTimeSlotCommand.Parameters.AddWithValue("@serviceID", serviceID)
                    areaTimeSlotCommand.ExecuteNonQuery() ' Use ExecuteNonQuery for Insert queries

                End Using

                'MessageBox.Show(SessionManager.customerID)

                Using checkCommand As New MySqlCommand(checkQuery, connection)
                    checkCommand.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                    checkCommand.Parameters.AddWithValue("@serviceProviderID", serviceProviderID)
                    checkCommand.Parameters.AddWithValue("@customerID", SessionManager.customerID)
                    checkCommand.Parameters.AddWithValue("@areaTimeSlotID", areaTimeSlotId)
                    checkCommand.Parameters.AddWithValue("@bookingAdvance", Price)
                    checkCommand.Parameters.AddWithValue("@serviceID", serviceID)
                    checkCommand.ExecuteNonQuery() ' Use ExecuteNonQuery for Insert queries

                End Using

                'MessageBox.Show(areaTimeSlotId)


                Using countPaymentsCommand As New MySqlCommand(countPaymentQuery, connection)
                    Dim temp As Integer = Convert.ToInt32(countPaymentsCommand.ExecuteScalar())
                    temp += 1
                    paymentID = temp.ToString()
                End Using

                Dim currDateTime As String = Now()

                Using paymentCommand As New MySqlCommand(paymentQuery, connection)
                    paymentCommand.Parameters.AddWithValue("@paymentID", paymentID)
                    paymentCommand.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                    paymentCommand.Parameters.AddWithValue("@amount", Price)
                    'paymentCommand.Parameters.AddWithValue("@paymentDateTime", currDateTime)
                    paymentCommand.Parameters.AddWithValue("@paymentType", "Advance")
                    paymentCommand.Parameters.AddWithValue("@paymentStatus", "Completed")
                    paymentCommand.Parameters.AddWithValue("@paymentMode", paymentMode)
                    paymentCommand.ExecuteNonQuery() ' Use ExecuteNonQuery for Insert queries

                    ' After executing the query, you can show a success message or perform any other necessary actions
                    MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                SendNotification()

                connection.Close()
            End Using

            RemovePreviousPanel3Form()
            With Homepage_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(Homepage_Customer)
                .BringToFront()
                .Show()
            End With
        Else
            ' User clicked Cancel, do nothing or show a message
            MessageBox.Show("Payment cancelled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Function SendNotification()
        Using connection As New MySqlConnection(SessionManager.connectionString)
            Dim getuserIDfromsID = "Select userID from serviceproviders WHERE serviceProviderID = @SID"
            Dim command As New MySqlCommand(getuserIDfromsID, connection)
            command.Parameters.AddWithValue("@SID", serviceProviderID)
            connection.Open()
            Dim SPuserID As String = command.ExecuteScalar().ToString()
            Dim getuserName = "Select userName from users WHERE userID = @UID"
            Dim command2 As New MySqlCommand(getuserName, connection)
            command2.Parameters.AddWithValue("@UID", userID)
            Dim userName As String = command2.ExecuteScalar().ToString()
            Dim notifmsg As String = "You have a new appointment request with " & userName
            Dim notificationquery As String = "Insert into notifications (notificationMessage, notificationDateTime, userID) values (@notifmsg, NOW(), @UID)"
            Dim command3 As New MySqlCommand(notificationquery, connection)
            command3.Parameters.AddWithValue("@notifmsg", notifmsg)
            command3.Parameters.AddWithValue("@UID", SPuserID)
            command3.ExecuteNonQuery()
            Dim emailofServiceP = "Select email from users WHERE userID = @SID"
            Dim command4 As New MySqlCommand(emailofServiceP, connection)
            command4.Parameters.AddWithValue("@SID", SPuserID)
            Dim emailSP As String = command4.ExecuteScalar().ToString()
            Dim email_sender As New EmailSender()
            email_sender.SendEmail(emailSP, notifmsg)



        End Using

    End Function
End Class