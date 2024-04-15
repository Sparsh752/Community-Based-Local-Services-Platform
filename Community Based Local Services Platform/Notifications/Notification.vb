Imports System.Data.SqlClient

Public Class Notification

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Size = New Size(446, 345)
        ' Create a Label for Notifications
        Dim lblNotifications As New Label With {
        .Size = New Size(318, 5), ' Set size to 318x28
        .Location = New Point(40, 5), ' Set location to 40, 27
        .BorderStyle = BorderStyle.None
        }
        Me.Controls.Add(lblNotifications)

        ' Create ListBox for Notifications
        Dim listBoxNotifications As New ListBox With {
            .Name = "notification",
            .Size = New Size(318, 5), ' Set size to 318x28
            .Location = New Point(40, 5), ' Set location to 40, 27
            .Font = New Font(SessionManager.font_family, 13, FontStyle.Regular) ' Set font to Montserrat, size to 20, and style to Regular
            }
        Me.Controls.Add(listBoxNotifications)

        ' Create a Panel to hold the cards
        Dim cardsPanel As New Panel With {
            .Location = New Point(10, lblNotifications.Bottom + 10),
            .Size = New Size(Me.ClientSize.Width - 20, Me.ClientSize.Height - lblNotifications.Bottom - 30),
            .AutoScroll = True
        }
        Me.Controls.Add(cardsPanel)

        ' Sample data for cards
        Dim cardData As New List(Of String)()


        ' Add 20 cards with different customer names and dates
        'cardData.Add("Customer A has booked a slot|18-March")
        'cardData.Add("Customer B has booked a slot|19-March")
        'cardData.Add("Customer C has booked a slot|20-March")
        'cardData.Add("Customer D has booked a slot|21-March")
        'cardData.Add("Customer E has booked a slot|22-March")
        'cardData.Add("Customer F has booked a slot|23-March")
        'cardData.Add("Customer G has booked a slot|24-March")
        'cardData.Add("Customer H has booked a slot|25-March")
        'cardData.Add("Customer I has booked a slot|26-March")
        'cardData.Add("Customer J has booked a slot|27-March")
        'cardData.Add("Customer K has booked a slot|28-March")
        'cardData.Add("Customer L has booked a slot|29-March")
        'cardData.Add("Customer M has booked a slot|30-March")
        'cardData.Add("Customer N has booked a slot|31-March")
        'cardData.Add("Customer O has booked a slot|1-March")
        'cardData.Add("Customer P has booked a slot|2-March")
        'cardData.Add("Customer Q has booked a slot|3-March")
        'cardData.Add("Customer R has booked a slot|4-March")
        'cardData.Add("Customer S has booked a slot|5-March")
        'cardData.Add("Customer T has booked a slot|6-March")

        'Dim connectionString As String = SessionManager.connectionString
        'Dim userId As String = SessionManager.userID

        Dim query As String = "SELECT notificationMessage, notificationDateTime FROM notifications WHERE userID = '" & SessionManager.userID & "'"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)


                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    If reader.HasRows Then
                        ' Create and position cards dynamically using fetched data
                        While reader.Read()
                            Dim notificationMessage As String = reader("notificationMessage").ToString()
                            Dim notificationDateTime As DateTime = Convert.ToDateTime(reader("notificationDateTime"))

                            Dim card As New UserControl1()
                            card.HeadingText = notificationMessage
                            card.SubheadingText = notificationDateTime.ToString("dd-MMMM")
                            ' Adjust the location as needed
                            card.Location = New Point(40, 19 + cardsPanel.Controls.Count * (card.Height + 5))
                            cardsPanel.Controls.Add(card)
                        End While
                    Else
                        ' Display "No new Notifications" message in the center of the form
                        Dim noNotificationsLabel As New Label With {
                            .Text = "No New Notifications",
                            .Font = New Font(SessionManager.font_family, 16, FontStyle.Regular), ' Set font
                            .AutoSize = True
                        }
                        noNotificationsLabel.Location = New Point((Me.ClientSize.Width - noNotificationsLabel.Width - 50) \ 2, (Me.ClientSize.Height - noNotificationsLabel.Height) \ 2)
                        noNotificationsLabel.Visible = True
                        Me.Controls.Add(noNotificationsLabel)
                        noNotificationsLabel.BringToFront()
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using


        ' Create and position cards dynamically using a for loop inside the Panel
        'For i As Integer = 0 To cardData.Count - 1
        'Dim cardInfo As String() = cardData(i).Split("|"c)
        'Dim card As New UserControl1()
        'card.HeadingText = cardInfo(0)
        'card.SubheadingText = cardInfo(1)
        'card.Location = New Point(40, 19 + i * (card.Height + 5)) ' Adjust the location as needed
        'cardsPanel.Controls.Add(card)
        'Next
    End Sub




End Class