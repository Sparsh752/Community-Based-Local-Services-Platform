Imports System.Windows.Forms

Public Class Confirmation
    Inherits Form

    Dim lblMessage As New Label()
    Dim btnProceed As New Button()
    Dim btnCancel As New Button()

    Public Sub New()
        ' Initialize form properties
        Me.Text = "Payment Confirmation"
        Me.Size = New Size(600, 300)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        ' Initialize label properties
        lblMessage.Text = "Rs. 15000 will be deducted from your bank account."
        lblMessage.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular) ' Consistent font
        lblMessage.TextAlign = ContentAlignment.MiddleCenter
        lblMessage.Size = New Size(600, 50)
        lblMessage.Location = New Point(0, 40)

        ' Initialize Proceed button properties
        btnProceed.Text = "Proceed"
        btnProceed.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold) ' Consistent font
        btnProceed.FlatStyle = FlatStyle.Flat
        btnProceed.BackColor = ColorTranslator.FromHtml("#F9754B") ' Consistent color
        btnProceed.ForeColor = Color.White
        btnProceed.Location = New Point(100, 120)
        btnProceed.Size = New Size(150, 40)
        AddHandler btnProceed.Click, AddressOf btnProceed_Click

        ' Initialize Cancel button properties
        btnCancel.Text = "Cancel"
        btnCancel.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold) ' Consistent font
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.BackColor = ColorTranslator.FromHtml("#F9754B") ' Consistent color
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(330, 120)
        btnCancel.Size = New Size(150, 40)
        AddHandler btnCancel.Click, AddressOf btnCancel_Click

        ' Add controls to the form
        Me.Controls.Add(lblMessage)
        Me.Controls.Add(btnProceed)
        Me.Controls.Add(btnCancel)
    End Sub

    Private Sub btnProceed_Click(sender As Object, e As EventArgs)
        ' Implement payment processing logic here
        MessageBox.Show("Payment processed successfully!", "Payment Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        ' Close the form without processing payment
        Me.Close()
    End Sub
End Class
