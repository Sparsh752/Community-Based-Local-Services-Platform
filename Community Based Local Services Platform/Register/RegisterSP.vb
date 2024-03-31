Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class RegisterSP
    Dim labelfont As New Font(SessionManager.font_family, 13, FontStyle.Regular)
    Private Sub RegisterSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateCountriesDropdown()
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
        Experiencecombobox.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        closingHoursText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        startHoursText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        SPaccText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        accHolderText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        ifscText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        bankNameText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        branchText.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        locationDropdown.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        ComboBox1.BackColor = ColorTranslator.FromHtml("#F9F9F9")
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
        Experiencecombobox.Location = New Point(643, 559)
        Experiencecombobox.Font = labelfont
        registerLocation.Location = New Point(138, 528)
        registerLocation.Font = labelfont
        locationDropdown.Location = New Point(138, 559)
        locationDropdown.Font = labelfont
        Label1.Location = New Point(138, 624)
        Label1.Font = labelfont
        startHoursText.Location = New Point(138, 655)
        startHoursText.Font = labelfont
        closingHours.Location = New Point(643, 624)
        closingHours.Font = labelfont
        closingHoursText.Location = New Point(643, 655)
        closingHoursText.Font = labelfont
        SPdescription.Location = New Point(138, 716)
        SPdescription.Font = labelfont
        TextBox2.Location = New Point(138, 748)
        TextBox2.Font = labelfont
        TextBox2.BackColor = ColorTranslator.FromHtml("#F9F9F9")
        SPnoticeHours.Location = New Point(138, 855)
        SPnoticeHours.Font = labelfont
        ComboBox1.Location = New Point(138, 883)
        ComboBox1.Font = labelfont
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
        Experiencecombobox.Size = New Size(286, 41)
        closingHoursText.Size = New Size(286, 41)
        startHoursText.Size = New Size(286, 41)
        SPaccText.Size = New Size(286, 41)
        accHolderText.Size = New Size(286, 41)
        bankNameText.Size = New Size(286, 41)
        branchText.Size = New Size(286, 41)
    End Sub
    Private Sub Email_Text_TextChanged(sender As Object, e As EventArgs) Handles emailSP_Text.TextChanged
        ' Call the function to validate the email format
        ValidateEmailFormat(emailSP_Text.Text)
    End Sub

    Private Sub phone_Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles phoneSP_Text.KeyPress

        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then

            e.Handled = True
        End If

        ' Check if the length of the text exceeds 13 characters
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


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles registerSPProfilePic.Click
        Try
            OpenFileDialogRegister.Title = "Open Picture"
            OpenFileDialogRegister.Filter = "JPEG Files|*.jpg;*.jpeg|PNG Files|*.png|All Files|*.*"
            OpenFileDialogRegister.ShowDialog()
            If OpenFileDialogRegister.FileName <> "" Then
                registerSPProfilePic.Image = System.Drawing.Image.FromFile(OpenFileDialogRegister.FileName)
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

        If String.IsNullOrWhiteSpace(emailSP_Text.Text) OrElse
       String.IsNullOrWhiteSpace(nameSP_Text.Text) OrElse
       String.IsNullOrWhiteSpace(phoneSP_Text.Text) OrElse
       String.IsNullOrWhiteSpace(passwordSP_Text.Text) OrElse
       String.IsNullOrWhiteSpace(Experiencecombobox.Text) OrElse
       String.IsNullOrWhiteSpace(closingHoursText.Text) OrElse
       String.IsNullOrWhiteSpace(startHoursText.Text) OrElse
       String.IsNullOrWhiteSpace(SPaccText.Text) OrElse
       String.IsNullOrWhiteSpace(accHolderText.Text) OrElse
       String.IsNullOrWhiteSpace(ifscText.Text) OrElse
       String.IsNullOrWhiteSpace(bankNameText.Text) OrElse
       String.IsNullOrWhiteSpace(branchText.Text) OrElse
       String.IsNullOrWhiteSpace(phoneSP_Text.Text) OrElse
       String.IsNullOrWhiteSpace(passwordSP_Text.Text) OrElse
       String.IsNullOrWhiteSpace(confirmSP_Text.Text) Then
            ' If any field is empty, display error message
            MessageBox.Show("Please fill in all fields.")
            Return ' Exit the event handler
        End If

        Dim customerID As Integer = -1
        Dim connectionString As String = "server=172.16.114.199;userid=admin;password=istrator;database=communityservice;sslmode=none"

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

End Class