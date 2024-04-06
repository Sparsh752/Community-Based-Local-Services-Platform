Public Class ServiceComplete_SP
    Private ServiceProviderName As String
    Private ServiceProviderAddress As String
    Private ServiceProviderPhone As String
    Private ServiceName As String
    Private Price As String
    Private BookedSlot As String
    Private Location As String
    Private Sub ServiceComplete_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServiceProviderName = "Customer XYZ"
        ServiceProviderAddress = "123 Example St, City"
        ServiceProviderPhone = "123-456-7890"
        ServiceName = "Example Service"
        Price = "$50"
        BookedSlot = "Monday, 9:00 AM"
        Location = "Example Location"

        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None

        LoadChatPanel()

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
        label.Location = New Point(85, 520)
        label.AutoSize = True
        label.MaximumSize = New Size(345, 45)
        Panel1.Controls.Add(label)

        RichTextBox1.Clear()
        RichTextBox2.Clear()
        RichTextBox3.Clear()
        RichTextBox4.Clear()

        RichTextBox1.Font = New Font("Bahnschrift Light", 16, FontStyle.Regular)
        RichTextBox1.SelectionAlignment = HorizontalAlignment.Center
        RichTextBox2.Font = New Font("Bahnschrift Light", 16, FontStyle.Regular)
        RichTextBox2.SelectionAlignment = HorizontalAlignment.Center
        RichTextBox3.Font = New Font("Bahnschrift Light", 16, FontStyle.Regular)
        RichTextBox3.SelectionAlignment = HorizontalAlignment.Center
        RichTextBox4.Font = New Font("Bahnschrift Light", 16, FontStyle.Regular)
        RichTextBox4.SelectionAlignment = HorizontalAlignment.Center

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

    End Sub

    Private Sub LoadChatPanel()

        Dim chatPanel As New Panel()
        chatPanel.Location = New Point(687, 125)
        chatPanel.Size = New Size(437, 490)
        chatPanel.BorderStyle = BorderStyle.FixedSingle
        chatPanel.BackColor = Color.White

        Panel1.Controls.Add(chatPanel)

        With ChatBox
            .TopLevel = False
            .Dock = DockStyle.Fill
            chatPanel.Controls.Add(ChatBox)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub RichTextBox_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged, RichTextBox2.TextChanged, RichTextBox3.TextChanged, RichTextBox4.TextChanged
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
        If otp.Length > 1 And Not Char.IsDigit(otp) Then
            ' Clear invalid characters
            rtb.Text = ""
            MessageBox.Show("OTP should be a single digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

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
        RemovePreviousForm()
        With TransactionComplete_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(TransactionComplete_SP)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class