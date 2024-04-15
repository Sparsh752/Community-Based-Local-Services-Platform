Imports System.IO

Public Class Registration_Request


    Public NotVerifiedSPs As DataTable = New DataTable()
    Public Main_Panel As New Panel()
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure the form
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)
        Dim Header As New Label()
        Header.Text = "Registration Requests"
        Header.Location = New Point(97, 101)
        Header.AutoSize = True
        Header.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
        Me.Controls.Add(Header)
        Me.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        ' Create and configure the FlowLayoutPanel

        Main_Panel.Size = New Size(800, 430)
        Main_Panel.Location = New Point(98, 138)
        Main_Panel.AutoScroll = True
        Me.Controls.Add(Main_Panel)
        LoadCards()



        ' Create some sample cards


    End Sub
    Sub LoadCards()
        NotVerifiedSPs.Clear()
        Main_Panel.Controls.Clear()
        RetrieveNotVerifiedSP()
        For i As Integer = 1 To NotVerifiedSPs.Rows.Count ' Adjust the number of cards for demonstration
            ' Dim card As New Card("pic.png", "Service Provider Name", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit.", "Location", "Contact", "Experience", "Services from 09:00 AM to 05:00 PM  ")
            Dim ithRow As DataRow = NotVerifiedSPs.Rows(i - 1)
            Dim card As New Panel()
            card.Size = New Size(734, 198)
            card.BorderStyle = BorderStyle.FixedSingle
            Dim pictureBox As New PictureBox()
            pictureBox.Size = New Size(169, 157)
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage
            pictureBox.Location = New Point(21, 21)
            pictureBox.Image = My.Resources.Resource1.sample_SP
            If Not ithRow("userPhoto") Is DBNull.Value Then
                Dim bytes As Byte() = CType(ithRow("userPhoto"), Byte())
                Dim ms As New MemoryStream(bytes)
                pictureBox.Image = Image.FromStream(ms)
            End If
            Dim label1 As New Label()
            label1.Text = ithRow("serviceProviderName").ToString()
            label1.AutoSize = False
            label1.Size = New Size(280, 28)
            label1.Location = New Point(208, 22)
            label1.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
            label1.ForeColor = Color.FromArgb(0, 0, 0)

            Dim label2 As New Label()
            label2.Text = ithRow("serviceProviderdescription").ToString()
            label2.AutoSize = False
            label2.Size = New Size(490, 47)
            label2.Location = New Point(208, 99)
            label2.Font = New Font(SessionManager.font_family, 7, FontStyle.Regular)
            label2.ForeColor = Color.FromArgb(0, 0, 0)

            Dim label3 As New Label()
            label3.Text = ithRow("location").ToString()
            label3.AutoSize = False
            label3.Size = New Size(73, 28)
            label3.Location = New Point(208, 50)
            label3.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            label3.ForeColor = Color.FromArgb(0, 0, 0)

            Dim ellipsePanel3 As New Panel()
            ellipsePanel3.Size = New Size(5, 5)
            ellipsePanel3.Location = New Point(295, 59)
            ellipsePanel3.BackColor = Color.Black

            Dim label4 As New Label()
            label4.Text = ithRow("mobileNumber").ToString()
            label4.AutoSize = False
            label4.Size = New Size(94, 28)
            label4.Location = New Point(314, 50)
            label4.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            label4.ForeColor = Color.FromArgb(0, 0, 0)

            Dim ellipsePanel4 As New Panel()
            ellipsePanel4.Size = New Size(5, 5)
            ellipsePanel4.Location = New Point(405, 59)
            ellipsePanel4.BackColor = Color.Black

            Dim label5 As New Label()
            label5.Text = ithRow("experienceYears").ToString() & " years"
            label5.AutoSize = False
            label5.Size = New Size(112, 28)
            label5.Location = New Point(424, 50)
            label5.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            label5.ForeColor = Color.FromArgb(0, 0, 0)

            Dim label6 As New Label()
            Dim starttime As String = ithRow("startTime").ToString()
            Dim endtime As String = ithRow("endTime").ToString()
            label6.Text = "Services from " & starttime & " to " & endtime
            label6.AutoSize = False
            label6.Size = New Size(268, 14)
            label6.Location = New Point(208, 76)
            label6.Font = New Font(SessionManager.font_family, 7, FontStyle.Regular)
            label6.ForeColor = Color.FromArgb(0, 0, 0)


            Dim acceptButton As New Button()
            acceptButton.Text = "Accept"
            acceptButton.Size = New Size(107, 29)
            acceptButton.Location = New Point(451, 156)
            acceptButton.BackColor = Color.FromArgb(249, 117, 75)
            acceptButton.ForeColor = Color.White
            acceptButton.FlatStyle = FlatStyle.Flat
            acceptButton.FlatAppearance.BorderSize = 0
            AddHandler acceptButton.Click, AddressOf HandleAccept
            acceptButton.Tag = ithRow("userID").ToString()
            Dim rejectButton As New Button()
            rejectButton.Text = "Reject"
            rejectButton.Size = New Size(107, 29)
            rejectButton.Location = New Point(591, 156)
            rejectButton.BackColor = Color.FromArgb(249, 117, 75)
            rejectButton.ForeColor = Color.White
            rejectButton.FlatStyle = FlatStyle.Flat
            rejectButton.FlatAppearance.BorderSize = 0
            AddHandler rejectButton.Click, AddressOf HandleReject
            rejectButton.Tag = ithRow("userID").ToString()
            card.Controls.Add(pictureBox)
            card.Controls.Add(label1)
            card.Controls.Add(label2)
            card.Controls.Add(label3)
            'card.Controls.Add(ellipsePanel3)
            card.Controls.Add(label4)
            'card.Controls.Add(ellipsePanel4)
            card.Controls.Add(label5)
            card.Controls.Add(label6)
            card.Controls.Add(acceptButton)
            card.Controls.Add(rejectButton)

            card.Location = New Point(0, (i - 1) * 224)
            Main_Panel.Controls.Add(card)
        Next
    End Sub
    Sub HandleReject(sender As Object, e As EventArgs)
        Dim button As Button = sender
        Dim userId As String = button.Tag.ToString()
        Dim connection As New MySqlConnection(SessionManager.connectionString)

        Try

            ' Connection established successfully

            Dim query As String = "UPDATE serviceproviders SET registrationStatus = 'Rejected' where userID=@userID"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@userID", userId)
            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            LoadCards()
        Catch ex As Exception
            ' Handle connection errors
            MessageBox.Show("Error connecting to MySQL: " & ex.Message)
        End Try

    End Sub
    Sub HandleAccept(sender As Object, e As EventArgs)
        Dim button As Button = sender
        Dim userId As String = button.Tag.ToString()
        Dim connection As New MySqlConnection(SessionManager.connectionString)

        Try

            ' Connection established successfully

            Dim query As String = "UPDATE serviceproviders SET registrationStatus = 'Approved' where userID=@userID"
            Dim command As New MySqlCommand(query, connection)
            command.Parameters.AddWithValue("@userID", userId)
            Try
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            LoadCards()


        Catch ex As Exception
            ' Handle connection errors
            MessageBox.Show("Error connecting to MySQL: " & ex.Message)
        End Try
    End Sub

    Private Sub RetrieveNotVerifiedSP()
        Dim connection As New MySqlConnection(SessionManager.connectionString)

        Try
            connection.Open()
            ' Connection established successfully

            Dim query As String = $"SELECT DISTINCT sp.userID, sp.serviceProviderName, sp.serviceProviderdescription, sp.experienceYears, cd.location, cd.mobileNumber, u.userPhoto, wh.startTime, wh.endTime FROM serviceproviders AS sp JOIN contactDetails AS cd ON sp.userID = cd.userID JOIN users AS u ON sp.userID = u.userID JOIN workHours AS wh ON sp.serviceProviderID = wh.serviceProviderID WHERE sp.registrationStatus = 'Pending'"

            Dim command As New MySqlCommand(query, connection)

            Dim reader As MySqlDataReader = command.ExecuteReader()
            NotVerifiedSPs.Load(reader)
            reader.Close()

        Catch ex As Exception
            ' Handle connection errors
            MessageBox.Show("Error connecting to MySQL: " & ex.Message)
        End Try

    End Sub

End Class