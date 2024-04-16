Imports System.Net
Imports System.Net.Mail

Public Class EmailSender
    Public Sub SendEmail(email As String, content As String)
        Try
            Dim mail As New MailMessage()
            Dim SmtpServer As New SmtpClient("smtp.gmail.com")

            mail.From = New MailAddress("communityserviceiitg@gmail.com")
            mail.To.Add(email)
            mail.Subject = "NOTIFICATION"
            mail.Body = "COMMUNITY BASED LOCAL SERVICES PLATFORM" & vbCrLf & vbCrLf &
                content

            SmtpServer.Port = 587
            SmtpServer.Credentials = New NetworkCredential("communityserviceiitg@gmail.com", "ugbccschopzulcxz")
            SmtpServer.EnableSsl = True

            SmtpServer.Send(mail)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
