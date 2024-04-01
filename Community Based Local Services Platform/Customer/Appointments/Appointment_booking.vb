Imports System.IO

Public Class Appointment_booking

    Private appointmentType As String

    ' Constructor to accept the string parameter
    Public Sub New(ByVal str As String)
        InitializeComponent()
        appointmentType = str
    End Sub

    Private Sub Appointment_booking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)

        Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\appointment-book.png")

        Try
            If Not File.Exists(imagePath) Then
                MessageBox.Show("Image file not found: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Dim im As New PictureBox()
        im.SizeMode = PictureBoxSizeMode.StretchImage
        im.Size = New Size(220, 220)
        im.Location = New Point(800, 150)
        im.Image = Image.FromFile(imagePath)

        Me.Controls.Add(im)

        If (appointmentType = "Reschedule") Then
            Button10.Text = "Reschedule"
        Else
            Button10.Text = "Proceed to Pay"
        End If

    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        RemovePreviousForm()

        If (appointmentType = "Reschedule") Then
            MessageBox.Show("Reschedule request sent.")
            With AppointmentList_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(AppointmentList_Customer)
                .BringToFront()
                .Show()
            End With
        Else
            With Payment_Gateway
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(Payment_Gateway)
                .BringToFront()
                .Show()
            End With
        End If

    End Sub

End Class