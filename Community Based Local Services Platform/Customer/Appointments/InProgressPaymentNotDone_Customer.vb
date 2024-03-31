Imports System.IO
Public Class InProgressPaymentNotDone_Customer
    Private Sub Appointmentdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(700, 613)

        Button1.BackgroundImage = My.Resources.Resource1.reschedule
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Size = New Size(122, 30)

        Button2.BackgroundImage = My.Resources.Resource1.proceedtopay
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Size = New Size(236, 30)

        Button3.BackgroundImage = My.Resources.Resource1.cancelandrefund
        Button3.BackgroundImageLayout = ImageLayout.Stretch
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Size = New Size(236, 30)

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Appointment_booking
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Appointment_booking)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Payment_Gateway
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Payment_Gateway)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With AppointmentList_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(AppointmentList_Customer)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class