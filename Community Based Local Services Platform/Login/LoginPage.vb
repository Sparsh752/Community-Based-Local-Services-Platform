Imports System.Data.SqlClient
Public Class LoginPage

    Dim standardFont As New Font("Montserrat", 15, FontStyle.Regular)
    Dim standardColor As Color = ColorTranslator.FromHtml("#F1F1F1")
    Private Sub LoginPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        Label1.BackColor = ColorTranslator.FromHtml("#0F2A37")
        Label1.Size = New Size(593, 700)
        Label1.Location = New Point(0, 0)

        LoginLabel.BackColor = standardColor
        LoginLabel.Size = New Size(473, 490)
        LoginLabel.Location = New Point(661, 98)

        Label2.Font = New Font(SessionManager.font_family, 20, FontStyle.Bold)
        Label2.BackColor = standardColor
        Label2.Size = New Size(280, 45)
        Label2.Location = New Point(731, 144)

        Label3.BackColor = standardColor
        Label3.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        Label3.Size = New Size(280, 30)
        Label3.Location = New Point(731, 214)

        TextBox2.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        'RichTextBox1.BackColor = standardColor
        TextBox2.Size = New Size(332, 30)
        TextBox2.Location = New Point(731, 249)
        TextBox2.BringToFront()

        Label4.BackColor = standardColor
        Label4.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        Label4.Size = New Size(280, 45)
        Label4.Location = New Point(731, 336)

        TextBox1.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        TextBox1.Size = New Size(332, 30)
        TextBox1.Location = New Point(731, 369)

        CheckBox1.BackColor = standardColor
        CheckBox1.Size = New Size(280, 28)
        CheckBox1.Location = New Point(961, 426)

        Button1.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        Button1.BackColor = ColorTranslator.FromHtml("#F9754B")
        Button1.Size = New Size(150, 40)
        Button1.Location = New Point(822, 489)
        Button1.FlatAppearance.BorderSize = 0
        Button1.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

        'Label5.Text = "Don't have an account?"
        Label5.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
        Label5.Location = New Point(815, 599)

        Label6.Text = "Sign Up"
        Label6.Font = New Font(SessionManager.font_family, 8, FontStyle.Bold)
        Label6.ForeColor = ColorTranslator.FromHtml("#F9754B")
        Label6.Location = New Point(934, 599)

        Label7.Text = "Community Based Local Services Platform"
        Label7.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
        Label7.BackColor = ColorTranslator.FromHtml("#0F2A37")
        Label7.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        Label7.Size = New Size(593, 147)
        Label7.Location = New Point(0, 382)
        PictureBox1.Size = New Size(180, 180)
        PictureBox1.Location = New Point(200, 200)
        PictureBox1.BackColor = ColorTranslator.FromHtml("#0F2A37")
        CheckBox1.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
    End Sub

    Private Function GetCustomerID(ByVal email As String, ByVal password As String) As Integer
        Dim customerID As Integer = -1
        Dim connectionString As String = "server=172.16.114.199;userid=admin;password=istrator;database=communityservice;sslmode=none"

        ' Query to retrieve customer's ID based on email and password
        Dim query As String = "SELECT Customer_ID FROM Customer WHERE Email = @Email AND Password = @Password"

        ' Using connection As New SqlConnection(connectionString)
        'Using command As New SqlCommand(query, connection)
        'Command.Parameters.AddWithValue("@Email", email)
        '   Command.Parameters.AddWithValue("@Password", password)
        '
        'Try
        'connection.Open()
        'Dim result As Object = command.ExecuteScalar()
        'If result IsNot Nothing AndAlso Not IsDBNull(result) Then
        'customerID = Convert.ToInt32(result)
        'End If
        'Catch ex As Exception
        'MessageBox.Show("Error retrieving customer's ID: " & ex.Message)
        'End Try
        'End Using
        'End Using

        Return customerID
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.PasswordChar = ""
        Else
            TextBox1.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email As String = TextBox2.Text
        Dim password As String = TextBox1.Text


        Dim customerID As Integer = GetCustomerID(email, password)
        If customerID > 0 Then
            CleanupForm()
            Return
        End If
    End Sub

    Private Sub CleanupForm()
        TextBox2.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub LoginPage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class