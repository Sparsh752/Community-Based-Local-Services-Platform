Imports System.IO

Public Class Appointment_booking
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

    End Sub


End Class