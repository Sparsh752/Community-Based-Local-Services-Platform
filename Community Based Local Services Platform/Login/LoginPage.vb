Public Class LoginPage

    Dim standardFont As New Font("Montserrat", 15, FontStyle.Regular)
    Dim standardColor As Color = ColorTranslator.FromHtml("#F1F1F1")
    Private Sub LoginPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        Me.Size = New Size(1200, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
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

        Button2.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        Button2.BackColor = ColorTranslator.FromHtml("#F9754B")
        Button2.Size = New Size(67, 25)
        Button2.Location = New Point(1067, 57)
        Button2.FlatAppearance.BorderSize = 0
        Button2.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

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
        PictureBox1.Size = New Size(200, 200)
        PictureBox1.Location = New Point(200, 200)
        PictureBox1.BackColor = ColorTranslator.FromHtml("#0F2A37")
        CheckBox1.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)

        If SessionManager.userType = "Admin" Then
            Label5.Visible = False
            Label6.Visible = False
        End If
    End Sub

    Private Function GetCustomerID(ByVal email As String, ByVal password As String) As Integer
        Dim customerID As Integer = -1

        ' Query to retrieve customer's ID based on email and password
        Dim query As String = "SELECT userID FROM users " &
            "WHERE email = @Email And password = @Password and userType = @UserType"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@Email", email)
                command.Parameters.AddWithValue("@Password", password)
                command.Parameters.AddWithValue("@UserType", userType)

                Try
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()
                    If IsDBNull(result) Or result Is Nothing Then
                        MessageBox.Show("Invalid email or password")
                        Return -1
                    End If
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        customerID = Convert.ToInt32(result)
                        If SessionManager.userType = "Service Provider" Then
                            command.CommandText = "SELECT COUNT(*) FROM serviceproviders WHERE userID = @userid AND registrationStatus = 'Approved'"
                            command.Parameters.AddWithValue("@userid", customerID)
                            result = command.ExecuteScalar()
                            If Convert.ToInt32(result) Then
                                SessionManager.customerID = customerID
                                Return customerID
                            Else
                                MessageBox.Show("Pending approval from Admin")
                            End If
                        Else
                            Return customerID
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error retrieving customer's ID: " & ex.Message)
                End Try
            End Using
        End Using
        Return -1
    End Function
    Private Function GetSPIDFromUserID(userID As String)
        Dim spID As Integer = -1

        ' Query to retrieve customer's ID based on email and password
        Dim query As String = "SELECT serviceProviderID FROM serviceproviders " &
            "WHERE userID = @UserID"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@UserID", userID)

                Try
                    connection.Open()
                    Dim result As Object = command.ExecuteScalar()
                    If IsDBNull(result) Or result Is Nothing Then
                        MessageBox.Show("Invalid email or password")
                        Return spID
                    End If
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        spID = Convert.ToInt32(result)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error retrieving service provider's ID: " & ex.Message)
                End Try
            End Using
        End Using

        Return spID

    End Function
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.PasswordChar = ""
        Else
            TextBox1.PasswordChar = "*"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim email = TextBox2.Text
        Dim password = TextBox1.Text

        If String.IsNullOrEmpty(TextBox1.Text) Or String.IsNullOrEmpty(TextBox2.Text) Then
            MessageBox.Show("Please enter email and password to login")
            Return
        End If

        Dim customerID = GetCustomerID(email, password)
        'store userid to retrieve profile from database
        SessionManager.userID = customerID

        If customerID > 0 Then

            If SessionManager.userType = "Customer" Then
                Dim customerForm As New Navbar_Customer()
                customerForm.Show()
                Me.Hide()
            ElseIf SessionManager.userType = "Service Provider" Then
                SessionManager.spID = GetSPIDFromUserID(customerID)
                Dim serviceProviderForm As New Navbar_SP(SessionManager.spID)
                serviceProviderForm.Show()
                Me.Hide()
            ElseIf SessionManager.userType = "Admin" Then

                Dim adminForm As New Navbar_Admin()
                adminForm.Show()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim landingForm As New LandingPage()
        landingForm.Show()
        Me.Hide()
    End Sub

    Private Sub CleanupForm()
        TextBox2.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub LoginPage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

        If SessionManager.userType = "Service Provider" Then
            Dim registerSpForm As New RegisterSP()
            RegisterSP.Show()
            Me.Hide()

        ElseIf SessionManager.userType = "Customer" Then
            Dim register1Form As New Register1()
            register1Form.Show()
            Me.Hide()

        Else
            MessageBox.Show("New Admin cannot register,Please try logging in.")
        End If




    End Sub
End Class