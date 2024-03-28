Public Class ServiceComplete_SP
    Private ServiceProviderName As String
    Private ServiceProviderAddress As String
    Private ServiceProviderPhone As String
    Private ServiceName As String
    Private Price As String
    Private BookedSlot As String
    Private Location As String
    Private Sub ServiceComplete_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServiceProviderName = "Example Provider"
        ServiceProviderAddress = "123 Example St, City"
        ServiceProviderPhone = "123-456-7890"
        ServiceName = "Example Service"
        Price = "$50"
        BookedSlot = "Monday, 9:00 AM"
        Location = "Example Location"

        Label5.Text = ServiceProviderName
        Label6.Text = ServiceProviderAddress
        Label7.Text = ServiceProviderPhone
        Label8.Text = ServiceName
        Label9.Text = Price
        Label10.Text = BookedSlot
        Label11.Text = Location

        Dim label As New Label()
        label.Text = "Ask customer for the OTP before leaving the premises to complete the transaction."
        label.Font = New Font("Bahnschrift Light", 8, FontStyle.Regular)
        label.Location = New Point(64, 440)
        label.AutoSize = True
        label.MaximumSize = New Size(345, 45)
        Panel1.Controls.Add(label)

    End Sub

    Private Sub RichTextBox_TextChanged(sender As Object, e As EventArgs)
        Dim rtb = DirectCast(sender, RichTextBox)
        Dim otp = rtb.Text

        ' Check if the OTP length is greater than 1
        If otp.Length > 1 Then
            ' Remove additional characters
            rtb.Text = otp.Substring(0, 1)
            rtb.SelectionStart = 1
            MessageBox.Show("OTP should be a single digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if the character is a digit
        If Not Char.IsDigit(otp) Then
            ' Clear invalid characters
            rtb.Text = ""
            MessageBox.Show("OTP should be a single digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

End Class