Imports System.Net
Imports System.Net.Mail
Imports System.Reflection.Emit

Public Class TwoFA
    Dim currentIndex As Integer = 0
    Dim randomCode As String
    Dim validTime As Integer = 60
    Dim resendTime As Integer = 30
    Dim WithEvents timer As New Timer()

    Private Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer.Tick

        If resendTime > 0 Then
            resendTime -= 1
            Label2.Text = "OTP sent! Resend in " & resendTime.ToString() & " seconds"
        Else
            Label2.Text = "OTP sent!"
        End If

        If validTime > 0 Then
            validTime -= 1
        Else
            Label2.Text = ""
        End If

    End Sub

    Private Sub TwoFA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 700)
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.StartPosition = FormStartPosition.CenterScreen
        PictureBox1.Size = New Size(180, 180)
        PictureBox1.Location = New Point(200, 200)
        PictureBox1.BackColor = ColorTranslator.FromHtml("#0F2A37")
        Label4.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        Label4.BackColor = ColorTranslator.FromHtml("#0F2A37")
        Label4.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label4.Size = New Size(593, 147)
        Label4.Location = New Point(110, 420)
        Label4.TextAlign = ContentAlignment.MiddleCenter
        Panel1.Size = New Size(593, 700)
        Panel2.Size = New Size(473, 490)
        Panel2.Location = New Point(653, 105)
        grpOtp.Location = New Point(105, 118)
        'txtOtp0.Location = New Point(717, 223)
        btnSubmit.Location = New Point(105, 320)
        btnSubmit.Size = New Size(263, 50)
        btnSubmit.FlatAppearance.BorderSize = 0
        btnSubmit.FlatStyle = FlatStyle.Flat
        Label1.Location = New Point(100, 230)
        linkResend.Location = New Point(270, 230)
        Label2.Location = New Point(100, 270)
        Label2.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        linkResend.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        Label1.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        btnSubmit.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        timer.Interval = 1000
        timer.Start()
        SendOTP()
    End Sub

    Private Sub TwoFA_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        txtOtp0.Focus()
    End Sub

    Private Sub txtOtp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOtp0.KeyPress, txtOtp1.KeyPress, txtOtp2.KeyPress, txtOtp3.KeyPress

        If Char.IsDigit(e.KeyChar) And currentIndex >= 0 And currentIndex < 4 Then
            Dim textboxName As String = "txtOtp" & currentIndex
            Dim textBox As Control = grpOtp.Controls(textboxName)
            textBox.Text = e.KeyChar
            currentIndex += 1

        ElseIf e.KeyChar = ChrW(Keys.Back) And currentIndex > 0 And currentIndex <= 4 Then
            currentIndex -= 1
            Dim textboxName As String = "txtOtp" & currentIndex
            Dim textBox As TextBox = grpOtp.Controls(textboxName)
            textBox.Text = ""

        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtp_MouseClick(sender As Object, e As MouseEventArgs) Handles txtOtp0.MouseClick, txtOtp1.MouseClick, txtOtp2.MouseClick, txtOtp3.MouseClick
        Dim textboxName As String
        If currentIndex >= 4 Then
            textboxName = "txtOtp3"
        Else
            textboxName = "txtOtp" & currentIndex
        End If

        Dim textBox As TextBox = grpOtp.Controls(textboxName)
        textBox.Focus()
    End Sub

    Private Sub textOtp_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtp0.KeyDown, txtOtp1.KeyDown, txtOtp2.KeyDown, txtOtp3.KeyDown
        If e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtp0_TextChanged(sender As Object, e As EventArgs) Handles txtOtp0.TextChanged, txtOtp1.TextChanged, txtOtp2.TextChanged, txtOtp3.TextChanged
        Dim textboxName As String = ""
        If currentIndex >= 4 Then
            textboxName = "txtOtp3"
        Else
            textboxName = "txtOtp" & currentIndex
        End If

        Dim textBox As TextBox = grpOtp.Controls(textboxName)
        textBox.Focus()
        textBox.Select(textBox.Text.Length, 0)
    End Sub

    Private Sub linkResend_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkResend.LinkClicked
        If resendTime = 0 Then
            SendOTP()
        End If
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim otp As String = txtOtp0.Text & txtOtp1.Text & txtOtp2.Text & txtOtp3.Text
        If otp.Length <> 4 Then
            MessageBox.Show("Enter valid code", "Incorrect code", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If validTime > 0 Then
            If otp.Equals(randomCode) Then
                timer.Stop()

                SessionManager.mailVerified = True
                Me.Dispose()
            Else
                MessageBox.Show("Enter correct code", "Incorrect code", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Resend OTP", "Verification code has expired", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SendOTP()
        Dim rand As New Random()
        randomCode = (1000 + rand.Next(9000)).ToString()

        Try
            Dim mail As New MailMessage()
            Dim SmtpServer As New SmtpClient("smtp.gmail.com")

            mail.From = New MailAddress("communityserviceiitg@gmail.com")
            mail.To.Add(SessionManager.userEmail)
            mail.Subject = "Two-Factor Authentication Code"
            mail.Body = "COMMUNITY BASED LOCAL SERVICES PLATFORM" & vbCrLf &
                "Verification Code: " & randomCode & vbCrLf &
                "This code is valid for 60 seconds" & vbCrLf & vbCrLf &
                "If you did not initiate this request or have any concerns about the security of your account, please contact our support team immediately."

            SmtpServer.Port = 587
            SmtpServer.Credentials = New NetworkCredential("communityserviceiitg@gmail.com", "ugbccschopzulcxz")
            SmtpServer.EnableSsl = True

            SmtpServer.Send(mail)
            validTime = 60
            resendTime = 30

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class