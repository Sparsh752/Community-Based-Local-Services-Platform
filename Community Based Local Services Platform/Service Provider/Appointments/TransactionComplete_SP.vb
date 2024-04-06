﻿Public Class TransactionComplete_SP
    Private CustomerName As String
    Private ServiceProviderAddress As String
    Private ServiceProviderPhone As String
    Private ServiceName As String
    Private Price As String
    Private BookedSlot As String
    Private Location As String

    Private ReviewSubmitted As Boolean = False
    Private Sub TransactionComplete_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CustomerName = "Customer XYZ"
        ServiceProviderAddress = "123 Example St, City"
        ServiceProviderPhone = "123-456-7890"
        ServiceName = "Example Service"
        Price = "$50"
        BookedSlot = "Monday, 9:00 AM"
        Location = "Example Location"

        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None

        Label5.Text = CustomerName
        Label6.Text = ServiceProviderAddress
        Label7.Text = ServiceProviderPhone
        Label8.Text = ServiceName
        Label9.Text = Price
        Label10.Text = BookedSlot
        Label11.Text = Location

        Star1.Size = New Size(20, 20)
        Star1.BackgroundImageLayout = ImageLayout.Stretch
        Star1.BackColor = Me.BackColor
        Star1.FlatStyle = FlatStyle.Flat
        Star1.FlatAppearance.BorderSize = 0
        Star2.Size = New Size(20, 20)
        Star2.BackgroundImageLayout = ImageLayout.Stretch
        Star2.BackColor = Me.BackColor
        Star2.FlatStyle = FlatStyle.Flat
        Star2.FlatAppearance.BorderSize = 0
        Star3.Size = New Size(20, 20)
        Star3.BackgroundImageLayout = ImageLayout.Stretch
        Star3.BackColor = Me.BackColor
        Star3.FlatStyle = FlatStyle.Flat
        Star3.FlatAppearance.BorderSize = 0
        Star4.Size = New Size(20, 20)
        Star4.BackgroundImageLayout = ImageLayout.Stretch
        Star4.BackColor = Me.BackColor
        Star4.FlatStyle = FlatStyle.Flat
        Star4.FlatAppearance.BorderSize = 0
        Star5.Size = New Size(20, 20)
        Star5.BackgroundImageLayout = ImageLayout.Stretch
        Star5.BackColor = Me.BackColor
        Star5.FlatStyle = FlatStyle.Flat
        Star5.FlatAppearance.BorderSize = 0

        Star1.BackgroundImage = My.Resources.Resource1.star_uncolored
        Star2.BackgroundImage = My.Resources.Resource1.star_uncolored
        Star3.BackgroundImage = My.Resources.Resource1.star_uncolored
        Star4.BackgroundImage = My.Resources.Resource1.star_uncolored
        Star5.BackgroundImage = My.Resources.Resource1.star_uncolored

        Panel1.BorderStyle = BorderStyle.FixedSingle

        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.BackColor = Me.BackColor
        RichTextBox1.Font = New Font("Bahnschrift", 12, FontStyle.Regular)

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        LoadChatPanel()

    End Sub

    Private Sub LoadChatPanel()

        Dim chatPanel As New Panel()
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

    Private Sub Star1_Click(sender As Object, e As EventArgs) Handles Star1.Click
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star3.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star4.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star5.BackgroundImage = My.Resources.Resource1.star_uncolored
        End If
    End Sub

    Private Sub Star2_Click(sender As Object, e As EventArgs) Handles Star2.Click
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_colored
            Star3.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star4.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star5.BackgroundImage = My.Resources.Resource1.star_uncolored
        End If
    End Sub

    Private Sub Star3_Click(sender As Object, e As EventArgs) Handles Star3.Click
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_colored
            Star3.BackgroundImage = My.Resources.Resource1.star_colored
            Star4.BackgroundImage = My.Resources.Resource1.star_uncolored
            Star5.BackgroundImage = My.Resources.Resource1.star_uncolored
        End If
    End Sub

    Private Sub Star4_Click(sender As Object, e As EventArgs) Handles Star4.Click
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_colored
            Star3.BackgroundImage = My.Resources.Resource1.star_colored
            Star4.BackgroundImage = My.Resources.Resource1.star_colored
            Star5.BackgroundImage = My.Resources.Resource1.star_uncolored
        End If
    End Sub

    Private Sub Star5_Click(sender As Object, e As EventArgs) Handles Star5.Click
        If ReviewSubmitted = False Then
            Star1.BackgroundImage = My.Resources.Resource1.star_colored
            Star2.BackgroundImage = My.Resources.Resource1.star_colored
            Star3.BackgroundImage = My.Resources.Resource1.star_colored
            Star4.BackgroundImage = My.Resources.Resource1.star_colored
            Star5.BackgroundImage = My.Resources.Resource1.star_colored
        End If
    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        RemovePreviousForm()

        With AppointmentList_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_SP)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RemovePreviousForm()
        With AppointmentList_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_SP)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class