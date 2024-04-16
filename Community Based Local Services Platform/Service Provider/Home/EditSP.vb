Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.IO
Imports Community_Based_Local_Services_Platform.Display_Services

Public Class EditSP
    Dim labelfont As New Font(SessionManager.font_family, 13, FontStyle.Regular)
    Public imageByte As Byte()
    Dim isStrongPassword As Boolean = False

    Private Sub RegisterSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateCountriesDropdown()
        YearsExperienceDropdown()
        PopulateNoticeHourDropdown()
        PopulateTime()
        Me.Size = New Size(1200, 700)
        Me.CenterToScreen()
        Me.WindowState = FormWindowState.Normal
        Me.BackColor = Color.White
        Me.StartPosition = FormStartPosition.CenterScreen

        passwordSP_Text.PasswordChar = "*"
        confirmSP_Text.PasswordChar = "*"
        emailSP_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        nameSP_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        phoneSP_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        passwordSP_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        confirmSP_Text.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        ExperienceDropdown.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        GroupBox2.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        GroupBox3.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        SPaccText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        accHolderText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        ifscText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        bankNameText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        branchText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        locationDropdown.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        NoticeHourDropdown.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        registerSPProfilePic.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        SPdescription.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        signUpSP.Location = New Point(138, 80)
        signUpSP.Font = New Font("Bahnschrift", 20, FontStyle.Regular)
        registerSPEmailLabel.Location = New Point(138, 138)
        registerSPEmailLabel.Font = labelfont
        emailSP_Text.Location = New Point(138, 166)
        emailSP_Text.Font = labelfont

        registerNameSP.Location = New Point(138, 234)
        registerNameSP.Font = labelfont
        nameSP_Text.Location = New Point(138, 262)
        nameSP_Text.Font = labelfont
        registerNumberSP.Location = New Point(138, 326)
        registerNumberSP.Font = labelfont
        phoneSP_Text.Location = New Point(138, 357)
        phoneSP_Text.Font = labelfont
        registerPasswordSP.Location = New Point(138, 432)
        registerPasswordSP.Font = labelfont
        passwordSP_Text.Location = New Point(138, 463)
        passwordSP_Text.Font = labelfont
        registerConfirmSP.Location = New Point(643, 432)
        registerConfirmSP.Font = labelfont
        confirmSP_Text.Location = New Point(643, 463)
        confirmSP_Text.Font = labelfont
        experience.Location = New Point(643, 528)
        experience.Font = labelfont
        ExperienceDropdown.Location = New Point(643, 559)
        ExperienceDropdown.Font = labelfont
        registerLocation.Location = New Point(138, 528)
        registerLocation.Font = labelfont
        locationDropdown.Location = New Point(138, 559)
        locationDropdown.Font = labelfont
        Label1.Location = New Point(138, 624)
        Label1.Font = labelfont
        GroupBox2.Location = New Point(138, 655)
        GroupBox3.Location = New Point(643, 655)
        closingHours.Location = New Point(643, 624)
        closingHours.Font = labelfont
        SPdescription.Location = New Point(138, 716)
        SPdescription.Font = labelfont
        descriptionText.Location = New Point(138, 748)
        descriptionText.Font = labelfont
        descriptionText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        SPnoticeHours.Location = New Point(138, 855)
        SPnoticeHours.Font = labelfont
        NoticeHourDropdown.Location = New Point(138, 883)
        NoticeHourDropdown.Font = labelfont
        SPpaymentLabel.Location = New Point(138, 970)
        SPpaymentLabel.Font = New Font(SessionManager.font_family, 13, FontStyle.Bold)
        SPacc.Location = New Point(138, 1022)
        SPacc.Font = labelfont
        SPaccText.Location = New Point(138, 1050)
        SPaccText.Font = labelfont
        bankNameLabel.Location = New Point(643, 1022)
        bankNameLabel.Font = labelfont
        bankNameText.Location = New Point(643, 1050)
        bankNameText.Font = labelfont
        AccLabel.Location = New Point(138, 1120)
        AccLabel.Font = labelfont
        accHolderText.Location = New Point(138, 1148)
        accHolderText.Font = labelfont
        branchLabel.Location = New Point(643, 1120)
        branchLabel.Font = labelfont
        branchText.Location = New Point(643, 1148)
        branchText.Font = labelfont
        SPifscLabel.Location = New Point(138, 1213)
        SPifscLabel.Font = labelfont
        ifscText.Location = New Point(138, 1241)
        ifscText.Font = labelfont
        registerSPProfilePic.Location = New Point(643, 140)
        registerSPProfilePic.Size = New Size(300, 200)
        RegisterSPSubmitBtn.Location = New Point(939, 1338)
        RegisterSPSubmitBtn.Font = labelfont
        RegisterSPSubmitBtn.Size = New Size(150, 41)
        ExperienceDropdown.Size = New Size(286, 41)
        SPaccText.Size = New Size(286, 41)
        accHolderText.Size = New Size(286, 41)
        bankNameText.Size = New Size(286, 41)
        branchText.Size = New Size(286, 41)

        fetchData()

        emailSP_Text.ReadOnly = True
    End Sub

    Private Sub fetchData()
        Using connection As New MySqlConnection(SessionManager.connectionString)
            Try
                connection.Open()

                Dim fetchCommandText As String = "SELECT userName, email, password, userPhoto FROM users WHERE userID = @userID"
                Using fetchCommand As New MySqlCommand(fetchCommandText, connection)
                    fetchCommand.Parameters.AddWithValue("@userID", SessionManager.userID)
                    Using reader As MySqlDataReader = fetchCommand.ExecuteReader()
                        If reader.Read() Then
                            ' Read data from the reader and populate form fields
                            nameSP_Text.Text = reader.GetString("userName")
                            emailSP_Text.Text = reader.GetString("email")
                            passwordSP_Text.Text = reader.GetString("password")
                            ' Populate other form fields similarly
                            ' Retrieve the user photo byte array from the database
                            If Not reader.IsDBNull(reader.GetOrdinal("userPhoto")) Then
                                Dim userPhoto As Byte() = DirectCast(reader("userPhoto"), Byte())

                                ' Check if user photo is not null
                                If userPhoto IsNot Nothing AndAlso userPhoto.Length > 0 Then
                                    ' Convert byte array to image and display it in the picture box
                                    Using ms As New MemoryStream(userPhoto)
                                        registerSPProfilePic.SizeMode = PictureBoxSizeMode.StretchImage
                                        registerSPProfilePic.Image = Image.FromStream(ms)
                                    End Using
                                Else
                                    ' If user photo is null, set a default image or display a placeholder
                                    registerSPProfilePic.Image = My.Resources.Resource1.displayPicture
                                End If
                            End If
                        Else
                            MessageBox.Show("Service provider data not found.")
                        End If
                    End Using
                End Using



                Dim fetchServiceProviderCommandText As String = "SELECT serviceProviderdescription, experienceYears, minimumNoticeHours FROM serviceproviders where userID = @userID"
                Using fetchServiceProviderCommand As New MySqlCommand(fetchServiceProviderCommandText, connection)
                    fetchServiceProviderCommand.Parameters.AddWithValue("@userID", SessionManager.userID)
                    Using reader As MySqlDataReader = fetchServiceProviderCommand.ExecuteReader()
                        If reader.Read() Then
                            ' Read data from the reader and populate form fields
                            descriptionText.Text = reader.GetString("serviceProviderdescription")
                            ExperienceDropdown.Text = reader.GetInt32("experienceYears").ToString()
                            NoticeHourDropdown.Text = reader.GetInt32("minimumNoticeHours").ToString()
                            ' Populate other form fields similarly
                        Else
                            MessageBox.Show("Service provider data not found.")
                        End If
                    End Using
                End Using

                Dim fetchContactText As String = "SELECT location, mobileNumber FROM contactDetails WHERE userID = @userID"
                Using fetchContactCommand As New MySqlCommand(fetchContactText, connection)
                    fetchContactCommand.Parameters.AddWithValue("@userID", SessionManager.userID)
                    Using reader As MySqlDataReader = fetchContactCommand.ExecuteReader()
                        If reader.Read() Then
                            ' Read data from the reader and populate form fields
                            locationDropdown.Text = reader.GetString("location")
                            phoneSP_Text.Text = reader.GetString("mobileNumber")
                            ' Populate other form fields similarly
                        Else
                            MessageBox.Show("Service provider data not found.")
                        End If
                    End Using
                End Using

                Dim fetchBankText As String = "SELECT accountNumber, accountHolderName, bankName, branchName, ifscCode FROM bankDetailsOfServiceProvider WHERE serviceProviderID = @serviceProviderID"
                Using fetchBankCommand As New MySqlCommand(fetchBankText, connection)
                    fetchBankCommand.Parameters.AddWithValue("@serviceProviderID", SessionManager.spID)
                    Using reader As MySqlDataReader = fetchBankCommand.ExecuteReader()
                        If reader.Read() Then
                            ' Read data from the reader and populate form fields
                            accHolderText.Text = reader.GetString("accountHolderName")
                            SPaccText.Text = reader.GetString("accountNumber")
                            bankNameText.Text = reader.GetString("bankName")
                            branchText.Text = reader.GetString("branchName")
                            ifscText.Text = reader.GetString("ifscCode")
                            ' Populate other form fields similarly
                        Else
                            MessageBox.Show("Service provider data not found.")
                        End If
                    End Using
                End Using

                Dim fetchWorkHoursText As String = "SELECT startTime, endTime FROM workHours WHERE serviceProviderID = @serviceProviderID LIMIT 1"

                Using fetchWorkHoursCommand As New MySqlCommand(fetchWorkHoursText, connection)
                    fetchWorkHoursCommand.Parameters.AddWithValue("@serviceProviderID", SessionManager.spID)
                    Using reader As MySqlDataReader = fetchWorkHoursCommand.ExecuteReader()
                        If reader.Read() Then
                            ' Fetch start time and end time as TimeSpan objects
                            Dim startTime As TimeSpan = reader.GetTimeSpan("startTime")
                            Dim endTime As TimeSpan = reader.GetTimeSpan("endTime")

                            ' Extract start hour and minute from start time
                            Dim startHour As String = If(startTime.Hours < 10, "0" & startTime.Hours.ToString(), startTime.Hours.ToString())
                            Dim startMinute As String = If(startTime.Minutes < 10, "0" & startTime.Minutes.ToString(), startTime.Minutes.ToString())

                            ' Extract end hour and minute from end time
                            Dim endHour As String = If(endTime.Hours < 10, "0" & endTime.Hours.ToString(), endTime.Hours.ToString())
                            Dim endMinute As String = If(endTime.Minutes < 10, "0" & endTime.Minutes.ToString(), endTime.Minutes.ToString())

                            ' Populate comboStartingHours and comboClosingHours
                            comboStartingHours.Text = startHour.ToString()
                            comboClosingHours.Text = endHour.ToString()

                            ' Populate comboStartingMins and comboClosingMins
                            comboStartingMins.Text = startMinute.ToString()
                            comboClosingMins.Text = endMinute.ToString()

                        Else
                            MessageBox.Show("Work hours data not found.")
                        End If
                    End Using
                End Using


            Catch ex As Exception
                MessageBox.Show("An error occurred while fetching service provider data: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Email_Text_TextChanged(sender As Object, e As EventArgs) Handles emailSP_Text.TextChanged
        ' Call the function to validate the email format
        ValidateEmailFormat(emailSP_Text.Text)
    End Sub

    Private Sub phone_Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles phoneSP_Text.KeyPress

        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then

            e.Handled = True
        End If

        ' Check if the length of the text exceeds 10 characters
        If phoneSP_Text.Text.Length >= 10 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length exceeds 10 characters and the pressed key is not a control character, suppress it
            e.Handled = True
        End If
    End Sub


    Private Sub SPaccText_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SPaccText.KeyPress
        ' Check if the pressed key is a number or the '+' symbol
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        ' Check if the length of the text exceeds 12 characters
        If SPaccText.Text.Length >= 12 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length exceeds 12 characters and the pressed key is not a control character, suppress it
            e.Handled = True
        End If
    End Sub


    Private Function ValidateIFSC(ifsc As String) As Boolean
        ' Check if the length is exactly 11 characters
        If ifsc.Length <> 11 Then
            Return False
        End If

        ' Check if the first four characters are alphabetic
        For i As Integer = 0 To 3
            If Not Char.IsLetter(ifsc(i)) Then
                Return False
            End If
        Next

        ' Check if the fifth character is '0'
        If ifsc(4) <> "0"c Then
            Return False
        End If

        ' Check if the remaining characters are alphanumeric
        For i As Integer = 5 To 10
            If Not Char.IsLetterOrDigit(ifsc(i)) Then
                Return False
            End If
        Next

        ' All checks passed, IFSC is valid
        Return True
    End Function


    'Function for uploading profile picture
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles registerSPProfilePic.Click
        Try
            OpenFileDialogRegister.Title = "Open Picture"
            OpenFileDialogRegister.Filter = "JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|All Files|*.*"
            OpenFileDialogRegister.ShowDialog()
            If OpenFileDialogRegister.FileName <> "" Then
                registerSPProfilePic.Image = System.Drawing.Image.FromFile(OpenFileDialogRegister.FileName)

                imageByte = File.ReadAllBytes(OpenFileDialogRegister.FileName)
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

    'Convert startTime, closingTime entered in textbox to TIMESPAN.
    'Private Function ConvertToTimeSpan(timeString As String) As TimeSpan
    '    Dim timeParts() As String = timeString.Split(":")
    '    If timeParts.Length <> 2 Then
    '        Throw New ArgumentException("Enter time (HH:MM)")
    '    End If

    '    Dim hours As Integer
    '    Dim minutes As Integer

    '    If Not Integer.TryParse(timeParts(0), hours) OrElse Not Integer.TryParse(timeParts(1), minutes) Then
    '        Throw New ArgumentException("Invalid time format. Time should be in the format HH:mm.")
    '    End If

    '    If hours < 0 OrElse hours > 23 Then
    '        Throw New ArgumentException("Hours should be between 0 and 23.")
    '    End If

    '    If minutes < 0 OrElse minutes > 59 Then
    '        Throw New ArgumentException("Minutes should be between 0 and 59.")
    '    End If

    '    Return New TimeSpan(hours, minutes, 0)
    'End Function


    Function ContainsUpperCase(ByVal inputString As String) As Boolean
        For Each character As Char In inputString
            If Char.IsUpper(character) Then
                Return True
            End If
        Next
        Return False
    End Function

    Function ContainsLowerCase(ByVal inputString As String) As Boolean
        For Each character As Char In inputString
            If Char.IsLower(character) Then
                Return True
            End If
        Next
        Return False
    End Function

    Function ContainsDigit(ByVal inputString As String) As Boolean
        For Each character As Char In inputString
            If Char.IsDigit(character) Then
                Return True
            End If
        Next
        Return False
    End Function

    Function ContainsSpecialCharacter(ByVal inputString As String) As Boolean
        For Each character As Char In inputString
            If Not Char.IsLetterOrDigit(character) Then
                Return True
            End If
        Next
        Return False
    End Function


    Private Sub password_Text_TextChanged(sender As Object, e As EventArgs) Handles passwordSP_Text.TextChanged
        Dim password As String = passwordSP_Text.Text

        Dim checksPassed As Integer = 0

        ' Checking length criteria
        If password.Length >= 8 Then
            checksPassed += 1
            labelSize.Text = "✓" & labelSize.Text.Substring(1)
            labelSize.ForeColor = Color.Green
        Else
            labelSize.Text = "✗" & labelSize.Text.Substring(1)
            labelSize.ForeColor = Color.Red
        End If

        ' Checking if the password has a digit
        If ContainsDigit(password) Then
            checksPassed += 1
            labelNumbers.Text = "✓" & labelNumbers.Text.Substring(1)
            labelNumbers.ForeColor = Color.Green
        Else
            labelNumbers.Text = "✗" & labelNumbers.Text.Substring(1)
            labelNumbers.ForeColor = Color.Red
        End If

        ' Checking if the password has a lowercase letter
        If ContainsLowerCase(password) Then
            checksPassed += 1
            labelLower.Text = "✓" & labelLower.Text.Substring(1)
            labelLower.ForeColor = Color.Green
        Else
            labelLower.Text = "✗" & labelLower.Text.Substring(1)
            labelLower.ForeColor = Color.Red
        End If

        ' Checking if the password has a special character
        If ContainsSpecialCharacter(password) Then
            checksPassed += 1
            labelSpecial.Text = "✓" & labelSpecial.Text.Substring(1)
            labelSpecial.ForeColor = Color.Green
        Else
            labelSpecial.Text = "✗" & labelSpecial.Text.Substring(1)
            labelSpecial.ForeColor = Color.Red
        End If

        ' Checking if the password has an uppercase letter
        If ContainsUpperCase(password) Then
            checksPassed += 1
            labelUpper.Text = "✓" & labelUpper.Text.Substring(1)
            labelUpper.ForeColor = Color.Green
        Else
            labelUpper.Text = "✗" & labelUpper.Text.Substring(1)
            labelUpper.ForeColor = Color.Red
        End If

        If checksPassed < 5 Then
            Return
        End If

        isStrongPassword = True
    End Sub

    Private Function PictureBoxImageToByteArray(pictureBox As PictureBox) As Byte()
        Dim ms As New MemoryStream()
        pictureBox.Image.Save(ms, pictureBox.Image.RawFormat) ' Save the image using its original format
        Return ms.ToArray()
    End Function
    Private Sub RegisterSubmitBtn_Click(sender As Object, e As EventArgs) Handles RegisterSPSubmitBtn.Click
        ' Check if the text in the password_Text and confirm_Text textboxes match
        ' Check if any of the textboxes are empty


        If Not ValidateEmailFormatforSubmit(emailSP_Text.Text) Then
            ' Email format is invalid, display error message
            MessageBox.Show("Invalid email format. Please enter a valid email.")
            Return ' Exit the event handler
        End If

        If Not ValidateIFSC(ifscText.Text) Then
            ' IFSC code is incorrect
            MessageBox.Show("Invalid IFSC. Please enter a valid IFSC.")
            Return ' Exit the event handler
        End If

        If passwordSP_Text.Text = confirmSP_Text.Text Then
            ' Passwords match, proceed with registration process
            ' Add your registration logic here
            'MessageBox.Show("Passwords match. Proceed with registration.")
        Else
            ' Passwords don't match, display error message
            MessageBox.Show("Passwords do not match. Please re-enter the passwords.")
            ' Clear the text in the textboxes to allow the user to re-enter the passwords
            passwordSP_Text.Clear()
            confirmSP_Text.Clear()

        End If

        If Not isStrongPassword Then
            MessageBox.Show("Enter a strong password.")
            Return
        End If

        If String.IsNullOrWhiteSpace(nameSP_Text.Text) OrElse
        String.IsNullOrWhiteSpace(phoneSP_Text.Text) OrElse
        String.IsNullOrWhiteSpace(passwordSP_Text.Text) OrElse
        String.IsNullOrWhiteSpace(confirmSP_Text.Text) OrElse
        comboClosingHours.SelectedIndex < 0 OrElse
        comboClosingMins.SelectedIndex < 0 OrElse
        comboStartingHours.SelectedIndex < 0 OrElse
        comboStartingMins.SelectedIndex < 0 OrElse
        NoticeHourDropdown.SelectedItem Is Nothing OrElse
        String.IsNullOrWhiteSpace(NoticeHourDropdown.SelectedItem.ToString) OrElse
        ExperienceDropdown.SelectedIndex < 0 OrElse
        String.IsNullOrWhiteSpace(ExperienceDropdown.SelectedItem.ToString) OrElse
        locationDropdown.SelectedIndex < 0 OrElse
        String.IsNullOrWhiteSpace(locationDropdown.SelectedItem.ToString) OrElse
        String.IsNullOrWhiteSpace(SPaccText.Text) OrElse
        String.IsNullOrWhiteSpace(accHolderText.Text) OrElse
        String.IsNullOrWhiteSpace(ifscText.Text) OrElse
        String.IsNullOrWhiteSpace(bankNameText.Text) OrElse
        String.IsNullOrWhiteSpace(branchText.Text) Then
            ' If any field is empty, display error message
            MessageBox.Show("Please fill in all fields.")
            Return ' Exit the event handler
        End If

        Dim startingTime As TimeSpan
        Dim closingTime As TimeSpan

        Try
            If comboStartingHours.SelectedIndex < 0 Or comboStartingMins.SelectedIndex < 0 Then
                MessageBox.Show("Enter time (HH:MM)")
                Return
            End If
            If comboClosingHours.SelectedIndex < 0 Or comboClosingMins.SelectedIndex < 0 Then
                MessageBox.Show("Enter time (HH:MM)")
                Return
            End If

            startingTime = New TimeSpan(Convert.ToInt32(comboStartingHours.SelectedItem), Convert.ToInt32(comboStartingMins.SelectedItem), 0)
            closingTime = New TimeSpan(Convert.ToInt32(comboClosingHours.SelectedItem), Convert.ToInt32(comboClosingMins.SelectedItem), 0)

            ' Check if start time is less than end time
            If startingTime >= closingTime Then
                MessageBox.Show("Start time must be before closing time.")
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try

        ' Now you can insert startTime and endTime into the workHours table



        ' Establish connection to the database
        Using connection As New MySqlConnection(SessionManager.connectionString)
            Try
                connection.Open()

                ' Check if the email already exists
                ' Dim emailExists As Boolean = False
                ' Dim checkEmailCommandText As String = "SELECT COUNT(*) FROM users WHERE email = @email"
                ' Using checkEmailCommand As New MySqlCommand(checkEmailCommandText, connection)
                '    checkEmailCommand.Parameters.AddWithValue("@email", emailSP_Text.Text)
                '    Dim count As Integer = Convert.ToInt32(checkEmailCommand.ExecuteScalar())
                '    If count > 0 Then
                '       emailExists = True
                '    End If
                ' End Using

                ' If emailExists Then
                '    MessageBox.Show("Email already exists. Please use a different email address.")
                '    Return
                ' End If

                ' Insert user's information into the database
                ' Dim userId As Integer
                ' Dim serviceProviderId As Integer
                ' Dim contactId As Integer
                ' Dim bankDetailId As Integer

                ' Insert into users table
                'Dim insertUserCommandText As String = "INSERT INTO users (userName, userType, email, password, userPhoto) VALUES (@userName, @userType, @email, @password, @userPhoto)"
                'Using insertUserCommand As New MySqlCommand(insertUserCommandText, connection)
                'insertUserCommand.Parameters.AddWithValue("@userName", nameSP_Text.Text)
                'insertUserCommand.Parameters.AddWithValue("@userType", "Service Provider")
                'insertUserCommand.Parameters.AddWithValue("@email", emailSP_Text.Text)
                'insertUserCommand.Parameters.AddWithValue("@password", passwordSP_Text.Text)
                'insertUserCommand.Parameters.AddWithValue("@userPhoto", imageByte)
                'insertUserCommand.ExecuteNonQuery()
                '
                ' Get the ID of t'he inserted user
                'userId = CInt(insertUserCommand.LastInsertedId)
                'End Using

                ' Insert into users table
                ' Dim insertUserCommandText As String = "INSERT INTO users (userName, userType, email, password"
                ' Dim insertUserValues As String = "VALUES (@userName, @userType, @email, @password"

                Dim updateUserCommandText As String = "UPDATE users SET userName = @userName, password = @password"
                Dim updateUserCommandText2 As String = "WHERE userID = @userID"
                ' Only include the userPhoto field in the insert query if a new image is selected
                If imageByte IsNot Nothing Then
                    updateUserCommandText &= ", userPhoto = @userPhoto"
                    ' updateUserValues &= ", @userPhoto)"
                Else
                    updateUserCommandText &= " "
                    ' updateUserValues &= " "
                End If

                updateUserCommandText &= updateUserCommandText2

                Using updateUserCommand As New MySqlCommand(updateUserCommandText, connection)
                    updateUserCommand.Parameters.AddWithValue("@userID", SessionManager.userID)
                    updateUserCommand.Parameters.AddWithValue("@userName", nameSP_Text.Text)
                    ' insertUserCommand.Parameters.AddWithValue("@email", emailSP_Text.Text)
                    updateUserCommand.Parameters.AddWithValue("@password", passwordSP_Text.Text)

                    ' Only set the userPhoto parameter if a new image is selected
                    If imageByte IsNot Nothing Then
                        updateUserCommand.Parameters.AddWithValue("@userPhoto", imageByte)
                    End If

                    updateUserCommand.ExecuteNonQuery()

                    ' Get the ID of the inserted user
                    ' userId = CInt(updateUserCommand.LastInsertedId)
                End Using


                ' Insert into serviceproviders table
                Dim updateServiceProviderCommandText As String = "UPDATE serviceproviders SET serviceProviderName = @serviceProviderName, serviceProviderdescription = @serviceProviderDescription, experienceYears = @experienceYears, minimumNoticeHours = @minimumNoticeHours WHERE userID = @userID"
                Using updateServiceProviderCommand As New MySqlCommand(updateServiceProviderCommandText, connection)
                    updateServiceProviderCommand.Parameters.AddWithValue("@userID", SessionManager.userID)
                    updateServiceProviderCommand.Parameters.AddWithValue("@serviceProviderName", nameSP_Text.Text)
                    ' updateServiceProviderCommand.Parameters.AddWithValue("@serviceProviderEmail", emailSP_Text.Text)
                    updateServiceProviderCommand.Parameters.AddWithValue("@serviceProviderDescription", descriptionText.Text)
                    ' Set default values for rating, experienceYears, and minimumNoticeHours
                    ' updateServiceProviderCommand.Parameters.AddWithValue("@rating", 0)
                    updateServiceProviderCommand.Parameters.AddWithValue("@experienceYears", Convert.ToInt32(ExperienceDropdown.SelectedItem))
                    updateServiceProviderCommand.Parameters.AddWithValue("@minimumNoticeHours", Convert.ToInt32(NoticeHourDropdown.SelectedItem))
                    updateServiceProviderCommand.ExecuteNonQuery()

                    ' Get the ID of the inserted service provider
                    ' serviceProviderId = CInt(updateServiceProviderCommand.LastInsertedId)
                End Using

                ' Insert into contactDetails table
                Dim updateContactCommandText As String = "UPDATE contactDetails SET location = @location, mobileNumber = @mobileNumber WHERE userID = @userID"
                Using updateContactCommand As New MySqlCommand(updateContactCommandText, connection)
                    updateContactCommand.Parameters.AddWithValue("@userID", SessionManager.userID)
                    ' insertContactCommand.Parameters.AddWithValue("@email", emailSP_Text.Text)
                    updateContactCommand.Parameters.AddWithValue("@location", locationDropdown.SelectedItem.ToString())
                    updateContactCommand.Parameters.AddWithValue("@mobileNumber", phoneSP_Text.Text)
                    ' insertContactCommand.Parameters.AddWithValue("@socialMedia", "")
                    ' insertContactCommand.Parameters.AddWithValue("@address", "")
                    updateContactCommand.ExecuteNonQuery()

                    ' Get the ID of the inserted contact detail
                    ' contactId = CInt(updateContactCommand.LastInsertedId)
                End Using

                ' Insert into bankDetailsOfServiceProvider table
                Dim updateBankDetailCommandText As String = "UPDATE bankDetailsOfServiceProvider SET accountHolderName = @accountHolderName, accountNumber = @accountNumber, bankName = @bankName, branchName = @branchName, ifscCode = @ifscCode WHERE serviceProviderID = @serviceProviderID"
                Using updateBankDetailCommand As New MySqlCommand(updateBankDetailCommandText, connection)
                    updateBankDetailCommand.Parameters.AddWithValue("@serviceProviderID", SessionManager.spID)
                    updateBankDetailCommand.Parameters.AddWithValue("@accountHolderName", accHolderText.Text)
                    updateBankDetailCommand.Parameters.AddWithValue("@accountNumber", SPaccText.Text)
                    updateBankDetailCommand.Parameters.AddWithValue("@bankName", bankNameText.Text)
                    updateBankDetailCommand.Parameters.AddWithValue("@branchName", branchText.Text)
                    updateBankDetailCommand.Parameters.AddWithValue("@ifscCode", ifscText.Text)
                    updateBankDetailCommand.ExecuteNonQuery()

                    ' Get the ID of the inserted bank detail
                    ' bankDetailId = CInt(updateBankDetailCommand.LastInsertedId)
                End Using

                ' Insert into workHours table (if required)


                Dim updateWorkHoursCommandText As String = "UPDATE workHours SET startTime = @startTime, endTime = @endTime WHERE serviceProviderID = @serviceProviderID"


                ' Insert work hours for all days of the week


                Using updateWorkHoursCommand As New MySqlCommand(updateWorkHoursCommandText, connection)
                    updateWorkHoursCommand.Parameters.AddWithValue("@serviceProviderID", SessionManager.spID)
                    updateWorkHoursCommand.Parameters.AddWithValue("@startTime", startingTime)
                    updateWorkHoursCommand.Parameters.AddWithValue("@endTime", closingTime)
                    updateWorkHoursCommand.ExecuteNonQuery()
                End Using




                ' Display success message
                MessageBox.Show("Updated successfully!")

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using

        'SetActiveForm(Homepage)
        Dim homePageSP As New Homepage_SP(SessionManager.spID)
        RemovePreviousForm()
        homePageSP.Margin = New Padding(0, 0, 0, 0)
        With homePageSP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(homePageSP)
            .BringToFront()
            .Show()
        End With

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

    Private Sub YearsExperienceDropdown()
        ' Add countries manually to the dropdown list
        Dim YearsOfExperience As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}

        ExperienceDropdown.Items.Clear()
        ' Add Experience to the dropdown
        For Each year As Integer In YearsOfExperience
            ExperienceDropdown.Items.Add(year.ToString())
        Next

    End Sub
    Private Sub PopulateNoticeHourDropdown()
        ' Add notice hour options manually to the dropdown list
        Dim noticeHours As Integer() = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}

        ' Clear existing items (if needed)
        NoticeHourDropdown.Items.Clear()

        ' Add notice hours to the dropdown
        For Each hour As Integer In noticeHours
            NoticeHourDropdown.Items.Add(hour.ToString())
        Next
    End Sub

    Private Sub PopulateTime()
        comboStartingHours.Items.Clear()
        comboClosingHours.Items.Clear()
        comboStartingMins.Items.Clear()
        comboClosingMins.Items.Clear()
        For i As Integer = 0 To 23
            comboStartingHours.Items.Add(i.ToString().PadLeft(2, "0"c))
            comboClosingHours.Items.Add(i.ToString().PadLeft(2, "0"c))
        Next
        For i As Integer = 0 To 59
            comboStartingMins.Items.Add(i.ToString().PadLeft(2, "0"c))
            comboClosingMins.Items.Add(i.ToString().PadLeft(2, "0"c))
        Next
    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        For Each ctrl As Control In SessionManager.Panel3.Controls
            If TypeOf ctrl Is Form Then
                ' Remove the first control (form) from Panel5
                Dim formCtrl As Form = DirectCast(ctrl, Form)
                formCtrl.Close()
            End If
        Next
        If SessionManager.Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            SessionManager.Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles Back_btn.Click
        RemovePreviousForm()
        Me.Close()
        Dim homePageSP As New Homepage_SP(SessionManager.spID)
        homePageSP.Margin = New Padding(0, 0, 0, 0)
        With homePageSP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(homePageSP)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            passwordSP_Text.PasswordChar = ""
            confirmSP_Text.PasswordChar = ""
        Else
            passwordSP_Text.PasswordChar = "*"
            confirmSP_Text.PasswordChar = "*"
        End If
    End Sub
End Class