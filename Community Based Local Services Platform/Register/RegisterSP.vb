Imports System.Text.RegularExpressions
Imports System.Data.SqlClient

Public Class RegisterSP
    Private Sub RegisterSP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateCountriesDropdown()
        passwordSP_Text.PasswordChar = "*"
        confirmSP_Text.PasswordChar = "*"
    End Sub
    Private Sub Email_Text_TextChanged(sender As Object, e As EventArgs) Handles emailSP_Text.TextChanged
        ' Call the function to validate the email format
        ValidateEmailFormat(emailSP_Text.Text)
    End Sub

    Private Sub phone_Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles phoneSP_Text.KeyPress
        ' Check if the pressed key is a number or the '+' symbol
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "+" AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the pressed key is not a number or '+', suppress it
            e.Handled = True
        End If

        ' Check if the length of the text exceeds 13 characters
        If phoneSP_Text.Text.Length >= 13 AndAlso Not Char.IsControl(e.KeyChar) Then
            ' If the length exceeds 13 characters and the pressed key is not a control character, suppress it
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
       String.IsNullOrWhiteSpace(experienceTextbox.Text) OrElse
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
        locationDropdown.Items.Add("Afghanistan")
        locationDropdown.Items.Add("Albania")
        locationDropdown.Items.Add("Algeria")
        locationDropdown.Items.Add("Andorra")
        locationDropdown.Items.Add("Angola")
        locationDropdown.Items.Add("Antigua and Barbuda")
        locationDropdown.Items.Add("Argentina")
        locationDropdown.Items.Add("Armenia")
        locationDropdown.Items.Add("Australia")
        locationDropdown.Items.Add("Austria")
        locationDropdown.Items.Add("Azerbaijan")
        locationDropdown.Items.Add("Bahamas")
        locationDropdown.Items.Add("Bahrain")
        locationDropdown.Items.Add("Bangladesh")
        locationDropdown.Items.Add("Barbados")
        locationDropdown.Items.Add("Belarus")
        locationDropdown.Items.Add("Belgium")
        locationDropdown.Items.Add("Belize")
        locationDropdown.Items.Add("Benin")
        locationDropdown.Items.Add("Bhutan")
        locationDropdown.Items.Add("Bolivia")
        locationDropdown.Items.Add("Bosnia and Herzegovina")
        locationDropdown.Items.Add("Botswana")
        locationDropdown.Items.Add("Brazil")
        locationDropdown.Items.Add("Brunei")
        locationDropdown.Items.Add("Bulgaria")
        locationDropdown.Items.Add("Burkina Faso")
        locationDropdown.Items.Add("Burundi")
        locationDropdown.Items.Add("Cabo Verde")
        locationDropdown.Items.Add("Cambodia")
        locationDropdown.Items.Add("Cameroon")
        locationDropdown.Items.Add("Canada")
        locationDropdown.Items.Add("Central African Republic")
        locationDropdown.Items.Add("Chad")
        locationDropdown.Items.Add("Chile")
        locationDropdown.Items.Add("China")
        locationDropdown.Items.Add("Colombia")
        locationDropdown.Items.Add("Comoros")
        locationDropdown.Items.Add("Congo")
        locationDropdown.Items.Add("Costa Rica")
        locationDropdown.Items.Add("Croatia")
        locationDropdown.Items.Add("Cuba")
        locationDropdown.Items.Add("Cyprus")
        locationDropdown.Items.Add("Czech Republic")
        locationDropdown.Items.Add("Democratic Republic of the Congo")
        locationDropdown.Items.Add("Denmark")
        locationDropdown.Items.Add("Djibouti")
        locationDropdown.Items.Add("Dominica")
        locationDropdown.Items.Add("Dominican Republic")
        locationDropdown.Items.Add("East Timor")
        locationDropdown.Items.Add("Ecuador")
        locationDropdown.Items.Add("Egypt")
        locationDropdown.Items.Add("El Salvador")
        locationDropdown.Items.Add("Equatorial Guinea")
        locationDropdown.Items.Add("Eritrea")
        locationDropdown.Items.Add("Estonia")
        locationDropdown.Items.Add("Eswatini")
        locationDropdown.Items.Add("Ethiopia")
        locationDropdown.Items.Add("Fiji")
        locationDropdown.Items.Add("Finland")
        locationDropdown.Items.Add("France")
        locationDropdown.Items.Add("Gabon")
        locationDropdown.Items.Add("Gambia")
        locationDropdown.Items.Add("Georgia")
        locationDropdown.Items.Add("Germany")
        locationDropdown.Items.Add("Ghana")
        locationDropdown.Items.Add("Greece")
        locationDropdown.Items.Add("Grenada")
        locationDropdown.Items.Add("Guatemala")
        locationDropdown.Items.Add("Guinea")
        locationDropdown.Items.Add("Guinea-Bissau")
        locationDropdown.Items.Add("Guyana")
        locationDropdown.Items.Add("Haiti")
        locationDropdown.Items.Add("Honduras")
        locationDropdown.Items.Add("Hungary")
        locationDropdown.Items.Add("Iceland")
        locationDropdown.Items.Add("India")
        locationDropdown.Items.Add("Indonesia")
        locationDropdown.Items.Add("Iran")
        locationDropdown.Items.Add("Iraq")
        locationDropdown.Items.Add("Ireland")
        locationDropdown.Items.Add("Israel")
        locationDropdown.Items.Add("Italy")
        locationDropdown.Items.Add("Ivory Coast")
        locationDropdown.Items.Add("Jamaica")
        locationDropdown.Items.Add("Japan")
        locationDropdown.Items.Add("Jordan")
        locationDropdown.Items.Add("Kazakhstan")
        locationDropdown.Items.Add("Kenya")
        locationDropdown.Items.Add("Kiribati")
        locationDropdown.Items.Add("Kuwait")
        locationDropdown.Items.Add("Kyrgyzstan")
        locationDropdown.Items.Add("Laos")
        locationDropdown.Items.Add("Latvia")
        locationDropdown.Items.Add("Lebanon")
        locationDropdown.Items.Add("Lesotho")
        locationDropdown.Items.Add("Liberia")
        locationDropdown.Items.Add("Libya")
        locationDropdown.Items.Add("Liechtenstein")
        locationDropdown.Items.Add("Lithuania")
        locationDropdown.Items.Add("Luxembourg")
        locationDropdown.Items.Add("Madagascar")
        locationDropdown.Items.Add("Malawi")
        locationDropdown.Items.Add("Malaysia")
        locationDropdown.Items.Add("Maldives")
        locationDropdown.Items.Add("Mali")
        locationDropdown.Items.Add("Malta")
        locationDropdown.Items.Add("Marshall Islands")
        locationDropdown.Items.Add("Mauritania")
        locationDropdown.Items.Add("Mauritius")
        locationDropdown.Items.Add("Mexico")
        locationDropdown.Items.Add("Micronesia")
        locationDropdown.Items.Add("Moldova")
        locationDropdown.Items.Add("Monaco")
        locationDropdown.Items.Add("Mongolia")
        locationDropdown.Items.Add("Montenegro")
        locationDropdown.Items.Add("Morocco")
        locationDropdown.Items.Add("Mozambique")
        locationDropdown.Items.Add("Myanmar")
        locationDropdown.Items.Add("Namibia")
        locationDropdown.Items.Add("Nauru")
        locationDropdown.Items.Add("Nepal")
        locationDropdown.Items.Add("Netherlands")
        locationDropdown.Items.Add("New Zealand")
        locationDropdown.Items.Add("Nicaragua")
        locationDropdown.Items.Add("Niger")
        locationDropdown.Items.Add("Nigeria")
        locationDropdown.Items.Add("North Korea")
        locationDropdown.Items.Add("North Macedonia")
        locationDropdown.Items.Add("Norway")
        locationDropdown.Items.Add("Oman")
        locationDropdown.Items.Add("Pakistan")
        locationDropdown.Items.Add("Palau")
        locationDropdown.Items.Add("Palestine")
        locationDropdown.Items.Add("Panama")
        locationDropdown.Items.Add("Papua New Guinea")
        locationDropdown.Items.Add("Paraguay")
        locationDropdown.Items.Add("Peru")
        locationDropdown.Items.Add("Philippines")
        locationDropdown.Items.Add("Poland")
        locationDropdown.Items.Add("Portugal")
        locationDropdown.Items.Add("Qatar")
        locationDropdown.Items.Add("Romania")
        locationDropdown.Items.Add("Russia")
        locationDropdown.Items.Add("Rwanda")
        locationDropdown.Items.Add("Saint Kitts and Nevis")
        locationDropdown.Items.Add("Saint Lucia")
        locationDropdown.Items.Add("Saint Vincent and the Grenadines")
        locationDropdown.Items.Add("Samoa")
        locationDropdown.Items.Add("San Marino")
        locationDropdown.Items.Add("Sao Tome and Principe")
        locationDropdown.Items.Add("Saudi Arabia")
        locationDropdown.Items.Add("Senegal")
        locationDropdown.Items.Add("Serbia")
        locationDropdown.Items.Add("Seychelles")
        locationDropdown.Items.Add("Sierra Leone")
        locationDropdown.Items.Add("Singapore")
        locationDropdown.Items.Add("Slovakia")
        locationDropdown.Items.Add("Slovenia")
        locationDropdown.Items.Add("Solomon Islands")
        locationDropdown.Items.Add("Somalia")
        locationDropdown.Items.Add("South Africa")
        locationDropdown.Items.Add("South Korea")
        locationDropdown.Items.Add("South Sudan")
        locationDropdown.Items.Add("Spain")
        locationDropdown.Items.Add("Sri Lanka")
        locationDropdown.Items.Add("Sudan")
        locationDropdown.Items.Add("Suriname")
        locationDropdown.Items.Add("Sweden")
        locationDropdown.Items.Add("Switzerland")
        locationDropdown.Items.Add("Syria")
        locationDropdown.Items.Add("Taiwan")
        locationDropdown.Items.Add("Tajikistan")
        locationDropdown.Items.Add("Tanzania")
        locationDropdown.Items.Add("Thailand")
        locationDropdown.Items.Add("Togo")
        locationDropdown.Items.Add("Tonga")
        locationDropdown.Items.Add("Trinidad and Tobago")
        locationDropdown.Items.Add("Tunisia")
        locationDropdown.Items.Add("Turkey")
        locationDropdown.Items.Add("Turkmenistan")
        locationDropdown.Items.Add("Tuvalu")
        locationDropdown.Items.Add("Uganda")
        locationDropdown.Items.Add("Ukraine")
        locationDropdown.Items.Add("United Arab Emirates")
        locationDropdown.Items.Add("United Kingdom")
        locationDropdown.Items.Add("United States")
        locationDropdown.Items.Add("Uruguay")
        locationDropdown.Items.Add("Uzbekistan")
        locationDropdown.Items.Add("Vanuatu")
        locationDropdown.Items.Add("Vatican City")
        locationDropdown.Items.Add("Venezuela")
        locationDropdown.Items.Add("Vietnam")
        locationDropdown.Items.Add("Yemen")
        locationDropdown.Items.Add("Zambia")
        locationDropdown.Items.Add("Zimbabwe")
    End Sub

End Class