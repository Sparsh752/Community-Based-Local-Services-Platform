<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Register1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        signUp = New Label()
        registerEmailLabel = New Label()
        registerName = New Label()
        registerNumber = New Label()
        registerPassword = New Label()
        registerConfirm = New Label()
        registerLocation = New Label()
        registerAddress = New Label()
        locationDropdown = New ComboBox()
        registerProfilePic = New PictureBox()
        email_Text = New TextBox()
        name_Text = New TextBox()
        phone_Text = New TextBox()
        password_Text = New TextBox()
        confirm_Text = New TextBox()
        OpenFileDialogRegister = New OpenFileDialog()
        RegisterSubmitBtn = New Button()
        emailValidationLabel = New Label()
        address = New RichTextBox()
        Back_btn = New Button()
        labelSize = New Label()
        labelLower = New Label()
        labelUpper = New Label()
        labelNumbers = New Label()
        labelSpecial = New Label()
        CheckBox1 = New CheckBox()
        CType(registerProfilePic, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' signUp
        ' 
        signUp.AutoSize = True
        signUp.Font = New Font("Bahnschrift", 20F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        signUp.Location = New Point(138, 69)
        signUp.Name = "signUp"
        signUp.Size = New Size(134, 41)
        signUp.TabIndex = 0
        signUp.Text = "Sign Up"
        ' 
        ' registerEmailLabel
        ' 
        registerEmailLabel.AutoSize = True
        registerEmailLabel.Font = New Font("Bahnschrift", 10.2F)
        registerEmailLabel.Location = New Point(138, 124)
        registerEmailLabel.Name = "registerEmailLabel"
        registerEmailLabel.Size = New Size(53, 21)
        registerEmailLabel.TabIndex = 1
        registerEmailLabel.Text = "Email"
        ' 
        ' registerName
        ' 
        registerName.AutoSize = True
        registerName.Font = New Font("Bahnschrift", 10.2F)
        registerName.Location = New Point(138, 214)
        registerName.Name = "registerName"
        registerName.Size = New Size(55, 21)
        registerName.TabIndex = 3
        registerName.Text = "Name"
        ' 
        ' registerNumber
        ' 
        registerNumber.AutoSize = True
        registerNumber.Font = New Font("Bahnschrift", 10.2F)
        registerNumber.Location = New Point(138, 308)
        registerNumber.Name = "registerNumber"
        registerNumber.Size = New Size(87, 21)
        registerNumber.TabIndex = 5
        registerNumber.Text = "Phone No."
        ' 
        ' registerPassword
        ' 
        registerPassword.AutoSize = True
        registerPassword.Font = New Font("Bahnschrift", 10.2F)
        registerPassword.Location = New Point(138, 400)
        registerPassword.Name = "registerPassword"
        registerPassword.Size = New Size(86, 21)
        registerPassword.TabIndex = 7
        registerPassword.Text = "Password"
        ' 
        ' registerConfirm
        ' 
        registerConfirm.AutoSize = True
        registerConfirm.Location = New Point(138, 499)
        registerConfirm.Name = "registerConfirm"
        registerConfirm.Size = New Size(151, 21)
        registerConfirm.TabIndex = 9
        registerConfirm.Text = "Confirm Password"
        ' 
        ' registerLocation
        ' 
        registerLocation.AutoSize = True
        registerLocation.Font = New Font("Bahnschrift", 10.2F)
        registerLocation.Location = New Point(702, 339)
        registerLocation.Name = "registerLocation"
        registerLocation.Size = New Size(74, 21)
        registerLocation.TabIndex = 11
        registerLocation.Text = "Location"
        ' 
        ' registerAddress
        ' 
        registerAddress.AutoSize = True
        registerAddress.Font = New Font("Bahnschrift", 10.2F)
        registerAddress.Location = New Point(702, 420)
        registerAddress.Name = "registerAddress"
        registerAddress.Size = New Size(73, 21)
        registerAddress.TabIndex = 13
        registerAddress.Text = "Address"
        ' 
        ' locationDropdown
        ' 
        locationDropdown.AutoCompleteMode = AutoCompleteMode.Suggest
        locationDropdown.AutoCompleteSource = AutoCompleteSource.ListItems
        locationDropdown.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        locationDropdown.FormattingEnabled = True
        locationDropdown.Items.AddRange(New Object() {"Mumbai", "Delhi", "Bangalore", "Kolkata", "Chennai", "Hyderabad", "Ahmedabad", "Pune"})
        locationDropdown.Location = New Point(702, 370)
        locationDropdown.Name = "locationDropdown"
        locationDropdown.Size = New Size(332, 29)
        locationDropdown.TabIndex = 15
        ' 
        ' registerProfilePic
        ' 
        registerProfilePic.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        registerProfilePic.BorderStyle = BorderStyle.FixedSingle
        registerProfilePic.Cursor = Cursors.Hand
        registerProfilePic.Location = New Point(702, 107)
        registerProfilePic.Name = "registerProfilePic"
        registerProfilePic.Size = New Size(332, 208)
        registerProfilePic.SizeMode = PictureBoxSizeMode.StretchImage
        registerProfilePic.TabIndex = 16
        registerProfilePic.TabStop = False
        ' 
        ' email_Text
        ' 
        email_Text.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        email_Text.BorderStyle = BorderStyle.FixedSingle
        email_Text.Location = New Point(138, 152)
        email_Text.Name = "email_Text"
        email_Text.Size = New Size(283, 28)
        email_Text.TabIndex = 17
        ' 
        ' name_Text
        ' 
        name_Text.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        name_Text.BorderStyle = BorderStyle.FixedSingle
        name_Text.Location = New Point(138, 244)
        name_Text.Name = "name_Text"
        name_Text.Size = New Size(286, 28)
        name_Text.TabIndex = 18
        ' 
        ' phone_Text
        ' 
        phone_Text.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        phone_Text.BorderStyle = BorderStyle.FixedSingle
        phone_Text.Location = New Point(138, 336)
        phone_Text.Name = "phone_Text"
        phone_Text.Size = New Size(288, 28)
        phone_Text.TabIndex = 19
        ' 
        ' password_Text
        ' 
        password_Text.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        password_Text.BorderStyle = BorderStyle.FixedSingle
        password_Text.Location = New Point(138, 431)
        password_Text.Name = "password_Text"
        password_Text.Size = New Size(288, 28)
        password_Text.TabIndex = 20
        ' 
        ' confirm_Text
        ' 
        confirm_Text.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        confirm_Text.BorderStyle = BorderStyle.FixedSingle
        confirm_Text.Location = New Point(138, 530)
        confirm_Text.Name = "confirm_Text"
        confirm_Text.Size = New Size(292, 28)
        confirm_Text.TabIndex = 21
        ' 
        ' OpenFileDialogRegister
        ' 
        OpenFileDialogRegister.FileName = "OpenFileDialog1"
        ' 
        ' RegisterSubmitBtn
        ' 
        RegisterSubmitBtn.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        RegisterSubmitBtn.FlatAppearance.BorderSize = 0
        RegisterSubmitBtn.FlatStyle = FlatStyle.Flat
        RegisterSubmitBtn.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RegisterSubmitBtn.ForeColor = Color.White
        RegisterSubmitBtn.Location = New Point(901, 552)
        RegisterSubmitBtn.Margin = New Padding(0)
        RegisterSubmitBtn.Name = "RegisterSubmitBtn"
        RegisterSubmitBtn.Size = New Size(150, 41)
        RegisterSubmitBtn.TabIndex = 23
        RegisterSubmitBtn.Text = "Submit"
        RegisterSubmitBtn.UseVisualStyleBackColor = False
        ' 
        ' emailValidationLabel
        ' 
        emailValidationLabel.AutoSize = True
        emailValidationLabel.Font = New Font("Bahnschrift Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        emailValidationLabel.Location = New Point(203, 144)
        emailValidationLabel.Name = "emailValidationLabel"
        emailValidationLabel.Size = New Size(0, 16)
        emailValidationLabel.TabIndex = 24
        ' 
        ' address
        ' 
        address.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        address.BorderStyle = BorderStyle.FixedSingle
        address.Location = New Point(702, 452)
        address.Name = "address"
        address.Size = New Size(332, 73)
        address.TabIndex = 25
        address.Text = ""
        ' 
        ' Back_btn
        ' 
        Back_btn.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Back_btn.FlatAppearance.BorderSize = 0
        Back_btn.FlatStyle = FlatStyle.Flat
        Back_btn.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Back_btn.ForeColor = Color.White
        Back_btn.Location = New Point(1035, 39)
        Back_btn.Margin = New Padding(0)
        Back_btn.Name = "Back_btn"
        Back_btn.Size = New Size(67, 37)
        Back_btn.TabIndex = 26
        Back_btn.Text = "Back"
        Back_btn.UseVisualStyleBackColor = False
        ' 
        ' labelSize
        ' 
        labelSize.AutoSize = True
        labelSize.Font = New Font("Bahnschrift Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelSize.ForeColor = Color.Red
        labelSize.Location = New Point(443, 433)
        labelSize.Name = "labelSize"
        labelSize.Size = New Size(162, 16)
        labelSize.TabIndex = 27
        labelSize.Text = "✗ Atleast 8 characters long"
        ' 
        ' labelLower
        ' 
        labelLower.AutoSize = True
        labelLower.Font = New Font("Bahnschrift Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelLower.ForeColor = Color.Red
        labelLower.Location = New Point(443, 454)
        labelLower.Name = "labelLower"
        labelLower.Size = New Size(134, 16)
        labelLower.TabIndex = 27
        labelLower.Text = "✗ Contains Lowercase"
        ' 
        ' labelUpper
        ' 
        labelUpper.AutoSize = True
        labelUpper.Font = New Font("Bahnschrift Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelUpper.ForeColor = Color.Red
        labelUpper.Location = New Point(443, 475)
        labelUpper.Name = "labelUpper"
        labelUpper.Size = New Size(133, 16)
        labelUpper.TabIndex = 27
        labelUpper.Text = "✗ Contains Uppercase"
        ' 
        ' labelNumbers
        ' 
        labelNumbers.AutoSize = True
        labelNumbers.Font = New Font("Bahnschrift Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelNumbers.ForeColor = Color.Red
        labelNumbers.Location = New Point(443, 496)
        labelNumbers.Name = "labelNumbers"
        labelNumbers.Size = New Size(124, 16)
        labelNumbers.TabIndex = 27
        labelNumbers.Text = "✗ Contains Numbers"
        ' 
        ' labelSpecial
        ' 
        labelSpecial.AutoSize = True
        labelSpecial.Font = New Font("Bahnschrift Light", 7.8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        labelSpecial.ForeColor = Color.Red
        labelSpecial.Location = New Point(443, 517)
        labelSpecial.Name = "labelSpecial"
        labelSpecial.Size = New Size(150, 16)
        labelSpecial.TabIndex = 27
        labelSpecial.Text = "✗ Contains Special Chars"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(443, 405)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(154, 25)
        CheckBox1.TabIndex = 28
        CheckBox1.Text = "Show Password"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Register1
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(255))
        ClientSize = New Size(1330, 686)
        Controls.Add(CheckBox1)
        Controls.Add(labelSpecial)
        Controls.Add(labelNumbers)
        Controls.Add(labelUpper)
        Controls.Add(labelLower)
        Controls.Add(labelSize)
        Controls.Add(Back_btn)
        Controls.Add(address)
        Controls.Add(emailValidationLabel)
        Controls.Add(RegisterSubmitBtn)
        Controls.Add(confirm_Text)
        Controls.Add(password_Text)
        Controls.Add(phone_Text)
        Controls.Add(name_Text)
        Controls.Add(email_Text)
        Controls.Add(registerProfilePic)
        Controls.Add(locationDropdown)
        Controls.Add(registerAddress)
        Controls.Add(registerLocation)
        Controls.Add(registerConfirm)
        Controls.Add(registerPassword)
        Controls.Add(registerNumber)
        Controls.Add(registerName)
        Controls.Add(registerEmailLabel)
        Controls.Add(signUp)
        Font = New Font("Bahnschrift", 10.2F)
        Name = "Register1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Customer_Register"
        CType(registerProfilePic, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents signUp As Label
    Friend WithEvents registerEmailLabel As Label
    Public Property emailText As TextBox
    Public Property nameText As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents registerName As Label
    Public Property phoneText As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents registerNumber As Label
    Public Property passwordText As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents registerPassword As Label
    Public Property confirmText As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents registerConfirm As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents registerLocation As Label
    Friend WithEvents registerAddress As Label
    Friend WithEvents locationDropdown As ComboBox
    Friend WithEvents registerProfilePic As PictureBox
    Friend WithEvents email_Text As TextBox
    Friend WithEvents name_Text As TextBox
    Friend WithEvents phone_Text As TextBox
    Friend WithEvents password_Text As TextBox
    Friend WithEvents confirm_Text As TextBox
    Friend WithEvents OpenFileDialogRegister As OpenFileDialog
    Friend WithEvents RegisterSubmitBtn As Button
    Friend WithEvents emailValidationLabel As Label
    Friend WithEvents address As RichTextBox
    Friend WithEvents Back_btn As Button
    Friend WithEvents labelSize As Label
    Friend WithEvents labelLower As Label
    Friend WithEvents labelUpper As Label
    Friend WithEvents labelNumbers As Label
    Friend WithEvents labelSpecial As Label
    Friend WithEvents CheckBox1 As CheckBox

End Class
