Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create a Label for Notifications
        Dim lblNotifications As New Label()
        lblNotifications.Text = "Notifications"
        lblNotifications.Font = New Font("Montserrat", 20, FontStyle.Bold) ' Set font to Montserrat, size to 20, and style to Bold
        lblNotifications.Size = New Size(318, 38) ' Set size to 318x28
        lblNotifications.Location = New Point(40, 27) ' Set location to 40, 27
        Me.Controls.Add(lblNotifications)

        ' Create ListBox for Notifications
        Dim listBoxNotifications As New ListBox()
        listBoxNotifications.Name = "notification"
        listBoxNotifications.Size = New Size(318, 28) ' Set size to 318x28
        listBoxNotifications.Location = New Point(40, 27) ' Set location to 40, 27
        listBoxNotifications.Font = New Font("Montserrat", 20, FontStyle.Regular) ' Set font to Montserrat, size to 20, and style to Regular
        Me.Controls.Add(listBoxNotifications)

        ' Create a Panel to hold the cards
        Dim cardsPanel As New Panel()
        cardsPanel.Location = New Point(10, lblNotifications.Bottom + 10)
        cardsPanel.Size = New Size(Me.ClientSize.Width - 20, Me.ClientSize.Height - lblNotifications.Bottom - 30)
        cardsPanel.AutoScroll = True
        Me.Controls.Add(cardsPanel)

        ' Sample data for cards
        Dim cardData As New List(Of String)()


        ' Add 20 cards with different customer names and dates
        cardData.Add("Customer A has booked a slot|18-March")
        cardData.Add("Customer B has booked a slot|19-March")
        cardData.Add("Customer C has booked a slot|20-March")
        cardData.Add("Customer D has booked a slot|21-March")
        cardData.Add("Customer E has booked a slot|22-March")
        cardData.Add("Customer F has booked a slot|23-March")
        cardData.Add("Customer G has booked a slot|24-March")
        cardData.Add("Customer H has booked a slot|25-March")
        cardData.Add("Customer I has booked a slot|26-March")
        cardData.Add("Customer J has booked a slot|27-March")
        cardData.Add("Customer K has booked a slot|28-March")
        cardData.Add("Customer L has booked a slot|29-March")
        cardData.Add("Customer M has booked a slot|30-March")
        cardData.Add("Customer N has booked a slot|31-March")
        cardData.Add("Customer O has booked a slot|1-March")
        cardData.Add("Customer P has booked a slot|2-March")
        cardData.Add("Customer Q has booked a slot|3-March")
        cardData.Add("Customer R has booked a slot|4-March")
        cardData.Add("Customer S has booked a slot|5-March")
        cardData.Add("Customer T has booked a slot|6-March")


        ' Create and position cards dynamically using a for loop inside the Panel
        For i As Integer = 0 To cardData.Count - 1
            Dim cardInfo As String() = cardData(i).Split("|"c)
            Dim card As New UserControl1()
            card.HeadingText = cardInfo(0)
            card.SubheadingText = cardInfo(1)
            card.Location = New Point(40, 19 + i * (card.Height + 5)) ' Adjust the location as needed
            cardsPanel.Controls.Add(card)
        Next
    End Sub




End Class