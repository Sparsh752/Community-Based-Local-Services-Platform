Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Data.SqlClient

Public Class Register1
    Dim labelfont As New Font(SessionManager.font_family, 13, FontStyle.Regular)
    Private Sub Register1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateCountriesDropdown()
        Me.Size = New Size(1200, 700)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Normal
        Me.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        Me.CenterToParent()
        email_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        name_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        phone_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        password_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        confirm_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        locationDropdown.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        address.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        registerProfilePic.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        signUp.Location = New Point(138, 69)
        registerEmailLabel.Location = New Point(138, 124)
        email_Text.Location = New Point(138, 152)
        registerName.Location = New Point(138, 214)
        name_Text.Location = New Point(138, 244)
        registerNumber.Location = New Point(138, 308)
        phone_Text.Location = New Point(138, 336)
        registerPassword.Location = New Point(138, 400)
        password_Text.Location = New Point(138, 431)
        registerConfirm.Location = New Point(138, 499)
        confirm_Text.Location = New Point(138, 530)
        registerProfilePic.Location = New Point(702, 107)
        registerLocation.Location = New Point(702, 339)
        registerLocation.Size = New Size(332, 45)
        locationDropdown.Location = New Point(702, 370)
        registerAddress.Location = New Point(702, 420)
        address.Location = New Point(702, 452)
        RegisterSubmitBtn.Location = New Point(901, 552)
        RegisterSubmitBtn.Size = New Size(150, 41)
        address.Size = New Size(332, 73)
        address.BorderStyle = BorderStyle.FixedSingle
        registerEmailLabel.Font = labelfont
        registerName.Font = labelfont
        registerNumber.Font = labelfont
        registerPassword.Font = labelfont
        registerConfirm.Font = labelfont
        registerLocation.Font = labelfont
        registerAddress.Font = labelfont
        RegisterSubmitBtn.Font = labelfont
        email_Text.Font = labelfont
        name_Text.Font = labelfont
        phone_Text.Font = labelfont
        password_Text.Font = labelfont
        confirm_Text.Font = labelfont
        locationDropdown.Font = labelfont
        address.Font = labelfont

        confirm_Text.PasswordChar = "*"
        password_Text.PasswordChar = "*"



    End Sub
    Private Sub Email_Text_TextChanged(sender As Object, e As EventArgs) Handles email_Text.TextChanged
        ' Call the function to validate the email format
        ValidateEmailFormat(email_Text.Text)
    End Sub

    Private Sub phone_Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles phone_Text.KeyPress
        ' Check if the pressed key is a number or the '+' symbol
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number or '+', suppress it
            e.Handled = True
        End If

        ' Check if the length of the text exceeds 13 characters
        If phone_Text.Text.Length >= 10 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length exceeds 13 characters and the pressed key is not a control character, suppress it
            e.Handled = True
        End If
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles registerProfilePic.Click
        Try
            OpenFileDialogRegister.Title = "Open Picture"
            OpenFileDialogRegister.Filter = "JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|All Files|*.*"
            OpenFileDialogRegister.ShowDialog()
            If OpenFileDialogRegister.FileName <> "" Then
                registerProfilePic.Image = System.Drawing.Image.FromFile(OpenFileDialogRegister.FileName)
            End If
        Catch ex As Exception
            ' Handle any exceptions here
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


    Private Sub ValidateEmailFormat(email As String)
        ' Define a regular expression pattern for email validation
        Dim emailPattern As String = "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
        Dim regex As New Regex(emailPattern)

        ' Check if the email matches the pattern
        If regex.IsMatch(email) Then
            ' Email format is correct
            emailValidationLabel.Text = "Valid email format"
            emailValidationLabel.ForeColor = Color.Green
        Else
            ' Email format is incorrect
            emailValidationLabel.Text = "Invalid email format"
            emailValidationLabel.ForeColor = Color.Red
        End If
    End Sub
    Private Function ValidateEmailFormatforSubmit(email As String) As Boolean
        ' Define a regular expression pattern for email validation
        Dim emailPattern As String = "^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"
        Dim regex As New Regex(emailPattern)

        ' Check if the email matches the pattern
        If regex.IsMatch(email) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SendData()
        Dim connectionString As String = "server=172.16.114.199;userid=admin;password=istrator;database=communityservice;sslmode=none"

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            ' Check if the email already exists
            Dim emailExists As Boolean = False
            Dim checkEmailCommandText As String = "SELECT COUNT(*) FROM users WHERE email = @email"
            Using checkEmailCommand As New SqlCommand(checkEmailCommandText, connection)
                checkEmailCommand.Parameters.AddWithValue("@email", email_Text.Text)
                Dim count As Integer = Convert.ToInt32(checkEmailCommand.ExecuteScalar())
                If count > 0 Then
                    emailExists = True
                End If
            End Using

            If emailExists Then
                MessageBox.Show("Email already exists. Please use a different email address.")
            Else
                ' Insert into the users table
                Dim userId As Integer = 0
                Dim insertUserCommandText As String = "INSERT INTO users (userName, userType, email, password) VALUES (@usrname, @usrtype, @email, @password); SELECT SCOPE_IDENTITY();"
                Using insertUserCommand As New SqlCommand(insertUserCommandText, connection)
                    insertUserCommand.Parameters.AddWithValue("@usrname", name_Text.Text)
                    insertUserCommand.Parameters.AddWithValue("@usrtype", "Customer")
                    insertUserCommand.Parameters.AddWithValue("@email", email_Text.Text)
                    insertUserCommand.Parameters.AddWithValue("@password", password_Text.Text)
                    userId = Convert.ToInt32(insertUserCommand.ExecuteScalar()) ' Get the userID of the inserted user
                End Using

                If userId > 0 Then
                    ' Insert into the contactDetails table
                    Dim insertContactCommandText As String = "INSERT INTO contactDetails (userID, email, address, location) VALUES (@userID, @email, @address, @location)"
                    Using insertContactCommand As New SqlCommand(insertContactCommandText, connection)
                        insertContactCommand.Parameters.AddWithValue("@userID", userId)
                        insertContactCommand.Parameters.AddWithValue("@email", email_Text.Text)
                        insertContactCommand.Parameters.AddWithValue("@address", address.Text)
                        insertContactCommand.Parameters.AddWithValue("@location", locationDropdown.SelectedItem.ToString()) ' Assuming dropdownLocation is the name of your dropdown
                        If insertContactCommand.ExecuteNonQuery() = 1 Then
                            MessageBox.Show("User Inserted")
                        Else
                            MessageBox.Show("User Not Inserted")
                        End If
                    End Using

                Else
                    MessageBox.Show("Error inserting user.")
                End If
            End If
        End Using
    End Sub

    Private Sub RegisterSubmitBtn_Click(sender As Object, e As EventArgs) Handles RegisterSubmitBtn.Click
        ' Check if the text in the password_Text and confirm_Text textboxes match
        ' Check if any of the textboxes are empty
        If String.IsNullOrWhiteSpace(email_Text.Text) OrElse
        String.IsNullOrWhiteSpace(name_Text.Text) OrElse
        String.IsNullOrWhiteSpace(phone_Text.Text) OrElse
        String.IsNullOrWhiteSpace(password_Text.Text) OrElse
        String.IsNullOrWhiteSpace(confirm_Text.Text) OrElse
        String.IsNullOrWhiteSpace(address.Text) OrElse
        locationDropdown.SelectedItem Is Nothing OrElse
        String.IsNullOrWhiteSpace(locationDropdown.SelectedItem.ToString) Then
            ' If any field is empty, display error message
            MessageBox.Show("Please fill in all fields.")
            Return ' Exit the event handler
        End If

        If Not ValidateEmailFormatforSubmit(email_Text.Text) Then

            ' Email format is invalid, display error message
            MessageBox.Show("Invalid email format. Please enter a valid email.")
            Return ' Exit the event handler
        End If

        If password_Text.Text = confirm_Text.Text Then
            ' Passwords match, proceed with registration process
            ' Add your registration logic here
            'MessageBox.Show("Passwords match. Proceed with registration.")
        Else
            ' Passwords don't match, display error message
            MessageBox.Show("Passwords do not match. Please re-enter the passwords.")
            ' Clear the text in the textboxes to allow the user to re-enter the passwords
            password_Text.Clear()
            confirm_Text.Clear()

        End If

        SendData()
    End Sub
    Private Sub PopulateCountriesDropdown()
        ' Add countries manually to the dropdown list
        Dim megacitiesOfIndia As String() = {
                                        "Mumbai",
                                        "Delhi",
                                        "Bangalore",
                                        "Kolkata",
                                        "Chennai",
                                        "Hyderabad",
                                        "Ahmedabad",
                                        "Pune"
                                    }

        'locationDropdown.Items.Clear()
        locationDropdown.Items.AddRange(megacitiesOfIndia)

    End Sub

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles Back_btn.Click
        Dim loginForm As New LoginPage()
        loginForm.Show()
        Me.Hide()
    End Sub
End Class