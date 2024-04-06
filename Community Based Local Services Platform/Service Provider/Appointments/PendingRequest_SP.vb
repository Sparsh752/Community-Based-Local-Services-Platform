﻿Imports System.Reflection.Emit

Public Class PendingRequest_SP
    Private Sub PendingAcceptOrReject_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 700)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White

        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Location = New Point(400, 100)
        Panel1.Size = New Size(380, 410)

        Label1.Text = "Customer XYZ"
        Label2.Text = "Brahmaputra Hostel, IIT Guwahati Guwahati, Assam"
        Label3.Text = "987456789"

        Label4.Text = "Service"
        Label5.Text = "Interior Design"
        Label6.Text = "Booked Slot"
        Label7.Text = "23-Mar-2024  09:00 AM"
        Label8.Text = "Price"
        Label9.Text = "Rs. 15000"


        Label1.Location = New Point(450, 130)
        Label2.Location = New Point(450, 180)
        Label3.Location = New Point(450, 210)
        Label4.Location = New Point(450, 240)
        Label5.Location = New Point(450, 260)
        Label6.Location = New Point(450, 300)
        Label7.Location = New Point(450, 320)
        Label8.Location = New Point(450, 350)
        Label9.Location = New Point(450, 380)

        Button1.BackColor = ColorTranslator.FromHtml("#F9754B")
        Button1.Text = "Accept"
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Width = 120
        Button1.Height = 30
        Button1.ForeColor = Color.White
        Button1.Font = New Font("Bahnschrift Light", 9, FontStyle.Bold)

        Button2.BackColor = ColorTranslator.FromHtml("#F9754B")
        Button2.Text = "Reject"
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Width = 120
        Button2.Height = 30
        Button2.ForeColor = Color.White
        Button2.Font = New Font("Bahnschrift Light", 9, FontStyle.Bold)

        Button1.Location = New Point(450, 430)
        Button2.Location = New Point(600, 430)

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

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
        With AppointmentList_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_SP)
            .BringToFront()
            .Show()
        End With
        'MessageBox.Show("Appointment Booked!")
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
        'MessageBox.Show("Appointment Rejected!")
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

End Class