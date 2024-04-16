Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Community_Based_Local_Services_Platform.ChatBox

Public Class ChatBox

    Public currentLastLocation As Integer
    Public curMessageID As Integer
    Public Class Message
        Public Property Time As DateTime
        Public Property Text As String
        Public Property Sender As String
        Public Property IsRead As Boolean
        Public Property MessageID As Integer

        Public Sub New(ByVal time As DateTime, ByVal text As String, ByVal sender1 As String, ByVal isRead As Boolean, ByVal messageID As Integer)
            Me.Time = time
            Me.Text = text
            Me.Sender = sender1
            Me.IsRead = isRead
            Me.MessageID = messageID
        End Sub
    End Class

    Dim messages As New List(Of Message)()
    Dim messages1 As New List(Of Message)()
    Private Sub ChatBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        messages.Clear()
        messages1.Clear()

        curMessageID = -2

        Me.Size = New Size(437, 506)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None

        Dim _status As String

        Dim query = "SELECT appointmentStatus FROM appointments WHERE appointmentID = @appointmentID;"
        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                Using reader As MySqlDataReader = command.ExecuteReader()

                    Dim labels As New List(Of String)()

                    If reader.Read() Then
                        _status = reader("appointmentStatus")
                    End If
                End Using
            End Using
        End Using

        Label1.Location = New Point(150, 6)

        Panel1.Controls.Clear()
        Panel1.Location = New Point(37, 45)
        Panel1.Size = New Size(361, 340)
        Panel1.BackColor = Color.White
        Panel1.AutoScroll = True
        Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Maximum

        Panel2.Location = New Point(27, 405)
        Panel2.Size = New Size(375, 55)

        RichTextBox1.Location = New Point(40, 415)
        RichTextBox1.Size = New Size(285, 42)
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Bahnschrift Light", 12, FontStyle.Regular)
        RichTextBox1.Padding = New Padding(5, 10, 67, 5)
        RichTextBox1.WordWrap = True

        SendButton.Size() = New Size(57, 26)
        SendButton.Location = New Point(333, 417)
        SendButton.BackColor = ColorTranslator.FromHtml("#124E55")
        SendButton.Text = "Send"
        SendButton.ForeColor = Color.White
        SendButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        SendButton.FlatStyle = FlatStyle.Flat
        SendButton.FlatAppearance.BorderSize = 0
        SendButton.Padding = New Padding(0, 0, 0, 0)
        SendButton.TextAlign = ContentAlignment.MiddleCenter
        SendButton.AutoSize = True

        If _status <> "Scheduled" Then
            SendButton.Hide()
            Panel2.Hide()
            RichTextBox1.Hide()
        End If

        LoadOldMessages()

    End Sub

    Private Function LoadMessages()
        For Each message In messages
            Dim newMessageLabel As New Label()
            newMessageLabel.Text = message.Text
            newMessageLabel.AutoSize = True

            newMessageLabel.MaximumSize = New Size(250, 0)
            newMessageLabel.BorderStyle = BorderStyle.None
            newMessageLabel.Padding = New Padding(5)
            newMessageLabel.Margin = New Padding(5)
            newMessageLabel.ForeColor = Color.White
            newMessageLabel.Font = New Font("Bahnschrift Light", 12, FontStyle.Regular)

            Dim textSize As SizeF = TextRenderer.MeasureText(message.Text, newMessageLabel.Font)
            newMessageLabel.Width = CInt(textSize.Width) + 10

            If (message.Sender = "Me") Then
                newMessageLabel.Width = CInt(textSize.Width) + 16
                newMessageLabel.Left = Panel1.Width - newMessageLabel.Width - 20
                newMessageLabel.BackColor = ColorTranslator.FromHtml("#F9754B")
            Else
                newMessageLabel.Left = 20
                newMessageLabel.BackColor = ColorTranslator.FromHtml("#124E55")
            End If

            Panel1.Controls.Add(newMessageLabel)
            'MessageBox.Show(message.MessageID & " ww")
            curMessageID = message.MessageID

            If Panel1.Controls.Count > 1 Then
                Dim prevMessageLabel As Control = Panel1.Controls(Panel1.Controls.Count - 2)
                newMessageLabel.Top = prevMessageLabel.Bottom + 10
            End If
            currentLastLocation = newMessageLabel.Bottom + 10
            Panel1.AutoScrollPosition = New Point(0, Panel1.VerticalScroll.Maximum)
        Next

        'MessageBox.Show(curMessageID)

        If refreshTimer.Enabled = False Then
            refreshTimer.Enabled = True
            'MessageBox.Show("Timer start")
        End If

    End Function

    Private Sub RealTimeLoad()
        For Each message In messages1
            Dim newMessageLabel As New Label()
            newMessageLabel.Text = message.Text
            newMessageLabel.AutoSize = True

            newMessageLabel.MaximumSize = New Size(250, 0)
            newMessageLabel.BorderStyle = BorderStyle.None
            newMessageLabel.Padding = New Padding(5)
            newMessageLabel.Margin = New Padding(5)
            newMessageLabel.ForeColor = Color.White
            newMessageLabel.Font = New Font("Bahnschrift Light", 12, FontStyle.Regular)

            Dim textSize As SizeF = TextRenderer.MeasureText(message.Text, newMessageLabel.Font)
            newMessageLabel.Width = CInt(textSize.Width) + 10

            'MessageBox.Show(message.Sender & message.MessageID)

            If (message.Sender = "Me") Then
                'MessageBox.Show("Me : " & message.Text)
                newMessageLabel.Width = CInt(textSize.Width) + 16
                newMessageLabel.Left = Panel1.Width - newMessageLabel.Width - 20
                newMessageLabel.BackColor = ColorTranslator.FromHtml("#F9754B")
            Else
                'MessageBox.Show("Rec : " & message.Text)
                newMessageLabel.Left = 20
                newMessageLabel.BackColor = ColorTranslator.FromHtml("#124E55")
            End If

            Panel1.Controls.Add(newMessageLabel)
            curMessageID = message.MessageID

            If Panel1.Controls.Count > 1 Then
                Dim prevMessageLabel As Control = Panel1.Controls(Panel1.Controls.Count - 2)
                newMessageLabel.Top = prevMessageLabel.Bottom + 10
            End If
            Panel1.AutoScrollPosition = New Point(0, Panel1.VerticalScroll.Maximum)

        Next
        messages1.Clear()
    End Sub

    Private Sub SendMessage(ByVal message As String)
        Dim newMessageLabel As New Label()
        newMessageLabel.Text = message
        newMessageLabel.AutoSize = True
        newMessageLabel.BackColor = ColorTranslator.FromHtml("#F9754B")
        newMessageLabel.MaximumSize = New Size(250, 0)
        newMessageLabel.BorderStyle = BorderStyle.None
        newMessageLabel.Padding = New Padding(5)
        newMessageLabel.Margin = New Padding(5)
        newMessageLabel.ForeColor = Color.White
        newMessageLabel.Font = New Font("Bahnschrift Light", 12, FontStyle.Regular)

        Dim textSize As SizeF = TextRenderer.MeasureText(message, newMessageLabel.Font)
        newMessageLabel.Width = CInt(textSize.Width) + 16
        newMessageLabel.Left = Panel1.Width - newMessageLabel.Width - 20
        Panel1.Controls.Add(newMessageLabel)

        If Panel1.Controls.Count > 1 Then
            Dim prevMessageLabel As Control = Panel1.Controls(Panel1.Controls.Count - 2)
            newMessageLabel.Top = prevMessageLabel.Bottom + 10
        End If
        currentLastLocation = newMessageLabel.Bottom + 10
        Panel1.AutoScrollPosition = New Point(0, Panel1.VerticalScroll.Maximum)

    End Sub

    Private Sub LoadOldMessages()
        'MessageBox.Show(SessionManager.appointmentID)
        Dim query As String = "SELECT m.*, 
           CASE 
               WHEN m.senderID = @senderID THEN 'Me' 
               ELSE 'Receiver'
           END AS messageSide
            FROM messages m
            WHERE m.appointmentID = @appointmentID
            ORDER BY m.sentDateTime; "

        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)

                If (SessionManager.userType = "Customer") Then
                    command.Parameters.AddWithValue("@senderID", SessionManager.customerID)
                    command.Parameters.AddWithValue("@receiverID", SessionManager.sp_userID)
                Else
                    command.Parameters.AddWithValue("@senderID", SessionManager.sp_userID)
                    command.Parameters.AddWithValue("@receiverID", SessionManager.customerID)
                End If

                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim time As DateTime = Convert.ToDateTime(reader("sentDateTime"))
                        Dim text As String = reader("messageText")
                        Dim sender1 As String = reader("messageSide").ToString()
                        Dim isRead As Boolean = reader("isRead")
                        Dim messageID As Integer = reader("messageID")
                        'MessageBox.Show(messageID & " * " & sender1)
                        Dim message As New Message(time, text, sender1, isRead, messageID)
                        messages.Add(message)
                    End While
                End Using
            End Using
        End Using

        LoadMessages()

    End Sub

    Private WithEvents refreshTimer As New Timer()

    Public Sub New()
        refreshTimer.Interval = 3000
        refreshTimer.Enabled = False
        InitializeComponent()
    End Sub

    Private Sub RefreshTimer_Tick(sender As Object, e As EventArgs) Handles refreshTimer.Tick

        Dim query As String = "SELECT m.*, 
           CASE 
               WHEN m.senderID = @senderID THEN 'Me' 
               ELSE 'Receiver'
           END AS messageSide
            FROM messages m
            WHERE m.appointmentID = @appointmentID AND m.messageID > @curMessageID AND m.senderID = @receiverID
            ORDER BY m.sentDateTime; "

        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                command.Parameters.AddWithValue("@curMessageID", curMessageID)

                If (SessionManager.userType = "Customer") Then
                    command.Parameters.AddWithValue("@senderID", SessionManager.customerID)
                    command.Parameters.AddWithValue("@receiverID", SessionManager.sp_userID)
                Else
                    command.Parameters.AddWithValue("@senderID", SessionManager.sp_userID)
                    command.Parameters.AddWithValue("@receiverID", SessionManager.customerID)
                End If


                Using reader As MySqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim time As DateTime = Convert.ToDateTime(reader("sentDateTime"))
                        Dim text As String = reader("messageText")
                        Dim sender1 As String = reader("messageSide").ToString()
                        Dim isRead As Boolean = reader("isRead")
                        Dim messageID As Integer = reader("messageID")
                        'MessageBox.Show(messageID & " " & sender1)
                        Dim message As New Message(time, text, sender1, isRead, messageID)
                        messages1.Add(message)
                    End While
                End Using

            End Using

        End Using

        RealTimeLoad()

    End Sub

    Private Sub StoreNewMessage(ByVal textMessage As String)
        Dim query As String = "INSERT INTO 
            messages (appointmentID, senderID, receiverID, messageText, sentDateTime, isRead)
            VALUES (@appointmentID, @senderID, @receiverID, @textMessage, CURDATE(), 0);"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            connection.Open()

            Using command As New MySqlCommand(query, connection)

                command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)
                command.Parameters.AddWithValue("@textMessage", textMessage)

                If (SessionManager.userType = "Customer") Then
                    command.Parameters.AddWithValue("@senderID", SessionManager.customerID)
                    command.Parameters.AddWithValue("@receiverID", SessionManager.sp_userID)
                Else
                    command.Parameters.AddWithValue("@senderID", SessionManager.sp_userID)
                    command.Parameters.AddWithValue("@receiverID", SessionManager.customerID)
                End If

                command.ExecuteNonQuery()

                'MessageBox.Show(SessionManager.appointmentID & " " & SessionManager.sp_userID & " " & SessionManager.customerID)

            End Using
        End Using
    End Sub

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Dim message As String = RichTextBox1.Text.Trim()
        If message <> "" Then
            StoreNewMessage(message)
            SendMessage(message)
            RichTextBox1.Clear()
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

End Class