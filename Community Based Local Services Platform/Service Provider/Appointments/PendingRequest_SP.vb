Imports System.Reflection.Emit

Public Class PendingRequest_SP
    Private Sub PendingAcceptOrReject_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 635)
        Me.FormBorderStyle = FormBorderStyle.None

        Label1.Text = "Customer XYZ"
        Label2.Text = "Brahmaputra Hostel, IIT Guwahati Guwahati, Assam"
        Label3.Text = "987456789"

        Label4.Text = "Service"
        Label5.Text = "Interior Design"
        Label6.Text = "Booked Slot"
        Label7.Text = "23-Mar-2024  09:00 AM"
        Label8.Text = "Price"
        Label9.Text = "Rs. 15000"


        Label1.Location = New Point(450, 100)
        Label2.Location = New Point(450, 150)
        Label3.Location = New Point(450, 170)
        Label4.Location = New Point(450, 210)
        Label5.Location = New Point(450, 230)
        Label6.Location = New Point(450, 270)
        Label7.Location = New Point(450, 290)
        Label8.Location = New Point(450, 330)
        Label9.Location = New Point(450, 350)

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

        Button1.Location = New Point(450, 400)
        Button2.Location = New Point(600, 400)

    End Sub
End Class