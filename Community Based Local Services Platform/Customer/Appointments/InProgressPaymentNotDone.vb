Imports System.IO
Public Class InProgressPaymentNotDone
    Private Sub Appointmentdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = BorderStyle.None

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
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RemovePreviousForm()

        Dim str As String = "Reschedule"
        Dim appointmentBookingForm As New Appointment_booking(str)

        With appointmentBookingForm
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(appointmentBookingForm)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RemovePreviousForm()

        With Payment_Gateway
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Payment_Gateway)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RemovePreviousForm()

        With AppointmentList_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_Customer)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        RemovePreviousForm()

        With AppointmentList_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_Customer)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class