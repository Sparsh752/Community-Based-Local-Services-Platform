Imports System.Data.SqlClient

Public Class Notification


    Private WithEvents cardsPanel As Panel
    Public NewNotificationCount As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Size = New Size(446, 275)
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

        ' Create Clear Button
        Dim clearButton As New Button With {
            .Text = "Clear All",
            .Font = New Font(SessionManager.font_family, 12, FontStyle.Regular),
            .Size = New Size(90, 30),
            .Location = New Point(lblNotifications.Right - 40, lblNotifications.Bottom + 220),
            .Visible = False ' Initially hide the clear button
        }
        AddHandler clearButton.Click, AddressOf ClearButton_Click
        Me.Controls.Add(clearButton)


        ' Create a Panel to hold the cards
        cardsPanel = New Panel With {
            .Location = New Point(10, lblNotifications.Bottom + 10),
            .Size = New Size(Me.ClientSize.Width - 20, Me.ClientSize.Height - lblNotifications.Bottom - clearButton.Height - 30),
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
        'SessionManager.userID = 15

        ' Query to get the notification count
        Dim countquery As String = "SELECT COUNT(*) FROM notifications WHERE userID = '" & userID & "'"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(countquery, connection)
                Try
                    connection.Open()
                    ' Execute the query
                    Dim count As Object = command.ExecuteScalar()
                    If count IsNot Nothing AndAlso IsNumeric(count) Then
                        ' Set the notification count
                        NewNotificationCount = Convert.ToInt32(count)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using


        If SessionManager.notificationsCleared AndAlso SessionManager.notificationCount = NewNotificationCount Then
            ShowNoNotificationsLabel()
        Else
            Dim notificationCards As New List(Of UserControl1)()
            Dim query As String = "SELECT notificationMessage, notificationDateTime FROM notifications WHERE userID = '" & SessionManager.userID & "'"

            Using connection As New MySqlConnection(SessionManager.connectionString)
                Using command As New MySqlCommand(query, connection)


                    Try
                        connection.Open()
                        Dim reader As MySqlDataReader = command.ExecuteReader()

                        ' Retrieve and display notifications if they exist
                        If reader.HasRows Then
                            clearButton.Visible = True
                            ' Create and position cards dynamically using fetched data
                            While reader.Read()
                                Dim notificationMessage As String = reader("notificationMessage").ToString()
                                Dim notificationDateTime As DateTime = Convert.ToDateTime(reader("notificationDateTime"))

                                Dim card As New UserControl1()
                                card.HeadingText = notificationMessage
                                card.SubheadingText = notificationDateTime.ToString("dd-MMMM")
                                ' Adjust the location as needed
                                'card.Location = New Point(40, 19 + cardsPanel.Controls.Count * (card.Height + 5))
                                notificationCards.Add(card)
                            End While


                            ' Insert the cards into the panel controls at the beginning of the list
                            For i As Integer = notificationCards.Count - 1 To 0 Step -1
                                notificationCards(i).Location = New Point(40, 19 + cardsPanel.Controls.Count * (notificationCards(i).Height + 5))
                                cardsPanel.Controls.Add(notificationCards(i))
                            Next i
                        Else
                            ShowNoNotificationsLabel()
                        End If

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Using
            End Using

        End If




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


    Public Sub ClearButton_Click(sender As Object, e As EventArgs)
        ' Create a list to store controls to be removed
        Dim controlsToRemove As New List(Of Control)

        ' Iterate over the controls in the cardsPanel
        For Each control As Control In cardsPanel.Controls
            If TypeOf control Is UserControl1 Then
                ' Add notification cards to the list of controls to be removed
                controlsToRemove.Add(control)
            End If
        Next

        ' Remove controls from the cardsPanel
        For Each controlToRemove As Control In controlsToRemove
            cardsPanel.Controls.Remove(controlToRemove)
            controlToRemove.Dispose() ' Optionally, dispose the control to release resources
        Next



        ' Show the "No New Notifications" label if there are no remaining notification cards
        If cardsPanel.Controls.Count = 0 Then
            ' Display "No new Notifications" message in the center of the form
            ShowNoNotificationsLabel()

            ' Update flag to indicate notifications have been cleared
            SessionManager.notificationsCleared = True

            SessionManager.notificationCount = NewNotificationCount

        End If


        ' Hide the clear button
        Dim clearButton As Button = DirectCast(sender, Button)
        clearButton.Visible = False


    End Sub

    Private Sub ShowNoNotificationsLabel()
        ' Display "No New Notifications" message in the center of the form
        Dim noNotificationsLabel As New Label With {
            .Text = "No New Notifications",
            .Font = New Font(SessionManager.font_family, 16, FontStyle.Regular),
            .AutoSize = True
        }
        noNotificationsLabel.Location = New Point((Me.ClientSize.Width - noNotificationsLabel.Width - 50) \ 2, (Me.ClientSize.Height - noNotificationsLabel.Height) \ 2)
        noNotificationsLabel.Visible = True
        Me.Controls.Add(noNotificationsLabel)
        noNotificationsLabel.BringToFront()
    End Sub




End Class