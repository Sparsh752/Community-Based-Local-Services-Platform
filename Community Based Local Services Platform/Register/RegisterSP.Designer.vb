<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegisterSP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        confirmSP_Text = New TextBox()
        OpenFileDialogRegister = New OpenFileDialog()
        RegisterSPSubmitBtn = New Button()
        locationDropdown = New ComboBox()
        registerLocation = New Label()
        Panel1 = New Panel()
        Back_btn = New Button()
        ExperienceDropdown = New ComboBox()
        emailValidationLabel = New Label()
        branchLabel = New Label()
        branchText = New TextBox()
        bankNameLabel = New Label()
        bankNameText = New TextBox()
        closingHours = New Label()
        closingHoursText = New TextBox()
        SPifscLabel = New Label()
        ifscText = New TextBox()
        SPacc = New Label()
        AccLabel = New Label()
        SPpaymentLabel = New Label()
        SPnoticeHours = New Label()
        SPdescription = New Label()
        GroupBox1 = New GroupBox()
        NoticeHourDropdown = New ComboBox()
        accHolderText = New TextBox()
        SPaccText = New TextBox()
        TextBox2 = New TextBox()
        startHoursText = New TextBox()
        registerSPProfilePic = New PictureBox()
        experience = New Label()
        signUpSP = New Label()
        emailSP_Text = New TextBox()
        nameSP_Text = New TextBox()
        registerConfirmSP = New Label()
        phoneSP_Text = New TextBox()
        registerSPEmailLabel = New Label()
        registerNameSP = New Label()
        registerNumberSP = New Label()
        registerPasswordSP = New Label()
        passwordSP_Text = New TextBox()
        Label1 = New Label()
        ToolTip1 = New ToolTip(components)
        Panel1.SuspendLayout()
        CType(registerSPProfilePic, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' confirmSP_Text
        ' 
        confirmSP_Text.BorderStyle = BorderStyle.FixedSingle
        confirmSP_Text.Location = New Point(207, 492)
        confirmSP_Text.Name = "confirmSP_Text"
        confirmSP_Text.Size = New Size(286, 24)
        confirmSP_Text.TabIndex = 21
        ' 
        ' OpenFileDialogRegister
        ' 
        OpenFileDialogRegister.FileName = "OpenFileDialog1"
        ' 
        ' RegisterSPSubmitBtn
        ' 
        RegisterSPSubmitBtn.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        RegisterSPSubmitBtn.FlatAppearance.BorderSize = 0
        RegisterSPSubmitBtn.FlatStyle = FlatStyle.Flat
        RegisterSPSubmitBtn.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RegisterSPSubmitBtn.ForeColor = Color.White
        RegisterSPSubmitBtn.Location = New Point(867, 1167)
        RegisterSPSubmitBtn.Margin = New Padding(0)
        RegisterSPSubmitBtn.Name = "RegisterSPSubmitBtn"
        RegisterSPSubmitBtn.Size = New Size(137, 41)
        RegisterSPSubmitBtn.TabIndex = 23
        RegisterSPSubmitBtn.Text = "Submit"
        RegisterSPSubmitBtn.UseVisualStyleBackColor = False
        ' 
        ' locationDropdown
        ' 
        locationDropdown.FormattingEnabled = True
        locationDropdown.Location = New Point(206, 589)
        locationDropdown.Name = "locationDropdown"
        locationDropdown.Size = New Size(286, 25)
        locationDropdown.TabIndex = 15
        ' 
        ' registerLocation
        ' 
        registerLocation.AutoSize = True
        registerLocation.Font = New Font("Bahnschrift", 10.2F)
        registerLocation.Location = New Point(199, 565)
        registerLocation.Name = "registerLocation"
        registerLocation.Size = New Size(63, 17)
        registerLocation.TabIndex = 11
        registerLocation.Text = "Location"
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Back_btn)
        Panel1.Controls.Add(ExperienceDropdown)
        Panel1.Controls.Add(emailValidationLabel)
        Panel1.Controls.Add(branchLabel)
        Panel1.Controls.Add(RegisterSPSubmitBtn)
        Panel1.Controls.Add(branchText)
        Panel1.Controls.Add(bankNameLabel)
        Panel1.Controls.Add(bankNameText)
        Panel1.Controls.Add(closingHours)
        Panel1.Controls.Add(closingHoursText)
        Panel1.Controls.Add(SPifscLabel)
        Panel1.Controls.Add(ifscText)
        Panel1.Controls.Add(SPacc)
        Panel1.Controls.Add(AccLabel)
        Panel1.Controls.Add(SPpaymentLabel)
        Panel1.Controls.Add(SPnoticeHours)
        Panel1.Controls.Add(SPdescription)
        Panel1.Controls.Add(GroupBox1)
        Panel1.Controls.Add(NoticeHourDropdown)
        Panel1.Controls.Add(accHolderText)
        Panel1.Controls.Add(SPaccText)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(startHoursText)
        Panel1.Controls.Add(registerSPProfilePic)
        Panel1.Controls.Add(experience)
        Panel1.Controls.Add(signUpSP)
        Panel1.Controls.Add(emailSP_Text)
        Panel1.Controls.Add(nameSP_Text)
        Panel1.Controls.Add(registerConfirmSP)
        Panel1.Controls.Add(confirmSP_Text)
        Panel1.Controls.Add(locationDropdown)
        Panel1.Controls.Add(registerLocation)
        Panel1.Controls.Add(phoneSP_Text)
        Panel1.Controls.Add(registerSPEmailLabel)
        Panel1.Controls.Add(registerNameSP)
        Panel1.Controls.Add(registerNumberSP)
        Panel1.Controls.Add(registerPasswordSP)
        Panel1.Controls.Add(passwordSP_Text)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1360, 1040)
        Panel1.TabIndex = 25
        ' 
        ' Back_btn
        ' 
        Back_btn.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Back_btn.FlatAppearance.BorderSize = 0
        Back_btn.FlatStyle = FlatStyle.Flat
        Back_btn.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Back_btn.ForeColor = Color.White
        Back_btn.Location = New Point(949, 42)
        Back_btn.Margin = New Padding(0)
        Back_btn.Name = "Back_btn"
        Back_btn.Size = New Size(67, 25)
        Back_btn.TabIndex = 63
        Back_btn.Text = "Back"
        Back_btn.UseVisualStyleBackColor = False
        ' 
        ' ExperienceDropdown
        ' 
        ExperienceDropdown.FormattingEnabled = True
        ExperienceDropdown.Location = New Point(770, 415)
        ExperienceDropdown.Name = "ExperienceDropdown"
        ExperienceDropdown.Size = New Size(121, 25)
        ExperienceDropdown.TabIndex = 62
        ' 
        ' emailValidationLabel
        ' 
        emailValidationLabel.AutoSize = True
        emailValidationLabel.Font = New Font("Bahnschrift Light", 7.8F)
        emailValidationLabel.Location = New Point(208, 163)
        emailValidationLabel.Name = "emailValidationLabel"
        emailValidationLabel.Size = New Size(0, 13)
        emailValidationLabel.TabIndex = 61
        ' 
        ' branchLabel
        ' 
        branchLabel.AutoSize = True
        branchLabel.Font = New Font("Bahnschrift", 10.2F)
        branchLabel.Location = New Point(758, 1065)
        branchLabel.Name = "branchLabel"
        branchLabel.Size = New Size(53, 17)
        branchLabel.TabIndex = 60
        branchLabel.Text = "Branch"
        ' 
        ' branchText
        ' 
        branchText.BorderStyle = BorderStyle.FixedSingle
        branchText.Location = New Point(758, 1107)
        branchText.Name = "branchText"
        branchText.Size = New Size(246, 24)
        branchText.TabIndex = 59
        ' 
        ' bankNameLabel
        ' 
        bankNameLabel.AutoSize = True
        bankNameLabel.Font = New Font("Bahnschrift", 10.2F)
        bankNameLabel.Location = New Point(758, 967)
        bankNameLabel.Name = "bankNameLabel"
        bankNameLabel.Size = New Size(80, 17)
        bankNameLabel.TabIndex = 58
        bankNameLabel.Text = "Bank Name"
        ' 
        ' bankNameText
        ' 
        bankNameText.BorderStyle = BorderStyle.FixedSingle
        bankNameText.Location = New Point(758, 1009)
        bankNameText.Name = "bankNameText"
        bankNameText.Size = New Size(246, 24)
        bankNameText.TabIndex = 57
        ' 
        ' closingHours
        ' 
        closingHours.AutoSize = True
        closingHours.Font = New Font("Bahnschrift", 10.2F)
        closingHours.Location = New Point(770, 475)
        closingHours.Name = "closingHours"
        closingHours.Size = New Size(99, 17)
        closingHours.TabIndex = 56
        closingHours.Text = "Closing Hours"
        ' 
        ' closingHoursText
        ' 
        closingHoursText.BorderStyle = BorderStyle.FixedSingle
        closingHoursText.Location = New Point(770, 517)
        closingHoursText.Name = "closingHoursText"
        closingHoursText.Size = New Size(246, 24)
        closingHoursText.TabIndex = 55
        ' 
        ' SPifscLabel
        ' 
        SPifscLabel.AutoSize = True
        SPifscLabel.Font = New Font("Bahnschrift", 10.2F)
        SPifscLabel.Location = New Point(207, 1139)
        SPifscLabel.Name = "SPifscLabel"
        SPifscLabel.Size = New Size(73, 17)
        SPifscLabel.TabIndex = 54
        SPifscLabel.Text = "IFSC code"
        ' 
        ' ifscText
        ' 
        ifscText.BorderStyle = BorderStyle.FixedSingle
        ifscText.Location = New Point(207, 1167)
        ifscText.Name = "ifscText"
        ifscText.Size = New Size(286, 24)
        ifscText.TabIndex = 53
        ' 
        ' SPacc
        ' 
        SPacc.AutoSize = True
        SPacc.Font = New Font("Bahnschrift", 10.2F)
        SPacc.Location = New Point(207, 967)
        SPacc.Name = "SPacc"
        SPacc.Size = New Size(151, 17)
        SPacc.TabIndex = 52
        SPacc.Text = "Bank Account Number"
        ' 
        ' AccLabel
        ' 
        AccLabel.AutoSize = True
        AccLabel.Font = New Font("Bahnschrift", 10.2F)
        AccLabel.Location = New Point(207, 1065)
        AccLabel.Name = "AccLabel"
        AccLabel.Size = New Size(149, 17)
        AccLabel.TabIndex = 51
        AccLabel.Text = "Account Holder Name"
        ' 
        ' SPpaymentLabel
        ' 
        SPpaymentLabel.AutoSize = True
        SPpaymentLabel.Font = New Font("Bahnschrift", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        SPpaymentLabel.Location = New Point(207, 928)
        SPpaymentLabel.Name = "SPpaymentLabel"
        SPpaymentLabel.Size = New Size(117, 18)
        SPpaymentLabel.TabIndex = 50
        SPpaymentLabel.Text = "Payment Details"
        ' 
        ' SPnoticeHours
        ' 
        SPnoticeHours.AutoSize = True
        SPnoticeHours.Font = New Font("Bahnschrift", 10.2F)
        SPnoticeHours.Location = New Point(207, 845)
        SPnoticeHours.Name = "SPnoticeHours"
        SPnoticeHours.Size = New Size(156, 17)
        SPnoticeHours.TabIndex = 49
        SPnoticeHours.Text = "Minimum Notice Hours"
        ' 
        ' SPdescription
        ' 
        SPdescription.AutoSize = True
        SPdescription.Font = New Font("Bahnschrift", 10.2F)
        SPdescription.Location = New Point(206, 728)
        SPdescription.Name = "SPdescription"
        SPdescription.Size = New Size(82, 17)
        SPdescription.TabIndex = 48
        SPdescription.Text = "Description"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Location = New Point(1330, 1273)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(250, 125)
        GroupBox1.TabIndex = 47
        GroupBox1.TabStop = False
        ' 
        ' NoticeHourDropdown
        ' 
        NoticeHourDropdown.FormattingEnabled = True
        NoticeHourDropdown.Location = New Point(207, 880)
        NoticeHourDropdown.Name = "NoticeHourDropdown"
        NoticeHourDropdown.Size = New Size(286, 25)
        NoticeHourDropdown.TabIndex = 46
        ' 
        ' accHolderText
        ' 
        accHolderText.BorderStyle = BorderStyle.FixedSingle
        accHolderText.Location = New Point(207, 1093)
        accHolderText.Name = "accHolderText"
        accHolderText.Size = New Size(286, 24)
        accHolderText.TabIndex = 45
        ' 
        ' SPaccText
        ' 
        SPaccText.BorderStyle = BorderStyle.FixedSingle
        SPaccText.Location = New Point(207, 1014)
        SPaccText.Name = "SPaccText"
        SPaccText.Size = New Size(286, 24)
        SPaccText.TabIndex = 44
        ' 
        ' TextBox2
        ' 
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.Location = New Point(207, 752)
        TextBox2.Multiline = True
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(286, 77)
        TextBox2.TabIndex = 43
        ' 
        ' startHoursText
        ' 
        startHoursText.BorderStyle = BorderStyle.FixedSingle
        startHoursText.Location = New Point(207, 682)
        startHoursText.Name = "startHoursText"
        startHoursText.Size = New Size(286, 24)
        startHoursText.TabIndex = 42
        ' 
        ' registerSPProfilePic
        ' 
        registerSPProfilePic.BorderStyle = BorderStyle.FixedSingle
        registerSPProfilePic.Cursor = Cursors.Hand
        registerSPProfilePic.Location = New Point(770, 97)
        registerSPProfilePic.Name = "registerSPProfilePic"
        registerSPProfilePic.Size = New Size(246, 209)
        registerSPProfilePic.SizeMode = PictureBoxSizeMode.StretchImage
        registerSPProfilePic.TabIndex = 40
        registerSPProfilePic.TabStop = False
        ' 
        ' experience
        ' 
        experience.AutoSize = True
        experience.Font = New Font("Bahnschrift", 10.2F)
        experience.Location = New Point(770, 381)
        experience.Name = "experience"
        experience.Size = New Size(140, 17)
        experience.TabIndex = 39
        experience.Text = "Experience(In Years)"
        ' 
        ' signUpSP
        ' 
        signUpSP.AutoSize = True
        signUpSP.Font = New Font("Bahnschrift", 19.8000011F)
        signUpSP.Location = New Point(205, 42)
        signUpSP.Name = "signUpSP"
        signUpSP.Size = New Size(109, 33)
        signUpSP.TabIndex = 37
        signUpSP.Text = "Sign Up"
        ' 
        ' emailSP_Text
        ' 
        emailSP_Text.BackColor = SystemColors.ControlLight
        emailSP_Text.BorderStyle = BorderStyle.FixedSingle
        emailSP_Text.Location = New Point(207, 132)
        emailSP_Text.Name = "emailSP_Text"
        emailSP_Text.Size = New Size(286, 24)
        emailSP_Text.TabIndex = 36
        ' 
        ' nameSP_Text
        ' 
        nameSP_Text.BorderStyle = BorderStyle.FixedSingle
        nameSP_Text.Location = New Point(206, 209)
        nameSP_Text.Name = "nameSP_Text"
        nameSP_Text.Size = New Size(286, 24)
        nameSP_Text.TabIndex = 35
        ' 
        ' registerConfirmSP
        ' 
        registerConfirmSP.AutoSize = True
        registerConfirmSP.Font = New Font("Bahnschrift", 10.2F)
        registerConfirmSP.Location = New Point(199, 451)
        registerConfirmSP.Name = "registerConfirmSP"
        registerConfirmSP.Size = New Size(126, 17)
        registerConfirmSP.TabIndex = 34
        registerConfirmSP.Text = "Confirm Password"
        ' 
        ' phoneSP_Text
        ' 
        phoneSP_Text.BorderStyle = BorderStyle.FixedSingle
        phoneSP_Text.Location = New Point(208, 305)
        phoneSP_Text.Name = "phoneSP_Text"
        phoneSP_Text.Size = New Size(286, 24)
        phoneSP_Text.TabIndex = 33
        ' 
        ' registerSPEmailLabel
        ' 
        registerSPEmailLabel.AutoSize = True
        registerSPEmailLabel.Font = New Font("Bahnschrift", 10.2F)
        registerSPEmailLabel.Location = New Point(205, 99)
        registerSPEmailLabel.Name = "registerSPEmailLabel"
        registerSPEmailLabel.Size = New Size(43, 17)
        registerSPEmailLabel.TabIndex = 32
        registerSPEmailLabel.Text = "Email"
        ' 
        ' registerNameSP
        ' 
        registerNameSP.AutoSize = True
        registerNameSP.Font = New Font("Bahnschrift", 10.2F)
        registerNameSP.Location = New Point(205, 185)
        registerNameSP.Name = "registerNameSP"
        registerNameSP.Size = New Size(45, 17)
        registerNameSP.TabIndex = 31
        registerNameSP.Text = "Name"
        ' 
        ' registerNumberSP
        ' 
        registerNumberSP.AutoSize = True
        registerNumberSP.Font = New Font("Bahnschrift", 10.2F)
        registerNumberSP.Location = New Point(205, 266)
        registerNumberSP.Name = "registerNumberSP"
        registerNumberSP.Size = New Size(74, 17)
        registerNumberSP.TabIndex = 30
        registerNumberSP.Text = "Phone No."
        ' 
        ' registerPasswordSP
        ' 
        registerPasswordSP.AutoSize = True
        registerPasswordSP.Font = New Font("Bahnschrift", 10.2F)
        registerPasswordSP.Location = New Point(206, 365)
        registerPasswordSP.Name = "registerPasswordSP"
        registerPasswordSP.Size = New Size(71, 17)
        registerPasswordSP.TabIndex = 29
        registerPasswordSP.Text = "Password"
        ' 
        ' passwordSP_Text
        ' 
        passwordSP_Text.BorderStyle = BorderStyle.FixedSingle
        passwordSP_Text.Location = New Point(207, 395)
        passwordSP_Text.Name = "passwordSP_Text"
        passwordSP_Text.Size = New Size(286, 24)
        passwordSP_Text.TabIndex = 28
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift", 10.2F)
        Label1.Location = New Point(203, 644)
        Label1.Name = "Label1"
        Label1.Size = New Size(83, 17)
        Label1.TabIndex = 26
        Label1.Text = "Start Hours"
        ' 
        ' ToolTip1
        ' 
        ToolTip1.ToolTipTitle = "Format of Time"
        ' 
        ' RegisterSP
        ' 
        AutoScaleDimensions = New SizeF(8F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1360, 1040)
        Controls.Add(Panel1)
        Font = New Font("Bahnschrift", 10.2F)
        Name = "RegisterSP"
        Text = "Service Provider Register"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(registerSPProfilePic, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Public Property emailText As TextBox
    Public Property nameText As TextBox
    Public Property phoneText As TextBox
    Friend WithEvents SPaccText As TextBox
    Public Property passwordText As TextBox
    Friend WithEvents accHolderText As TextBox
    Public Property confirmText As TextBox
    Friend WithEvents bankNameText As TextBox
    Friend WithEvents phoneSP_Text As TextBox
    Friend WithEvents confirmSP_Text As TextBox
    Friend WithEvents OpenFileDialogRegister As OpenFileDialog
    Friend WithEvents RegisterSPSubmitBtn As Button
    Friend WithEvents locationDropdown As ComboBox
    Friend WithEvents registerLocation As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents passwordSP_Text As TextBox
    Friend WithEvents registerSPEmailLabel As Label
    Friend WithEvents registerNameSP As Label
    Friend WithEvents registerNumberSP As Label
    Friend WithEvents registerPasswordSP As Label
    Friend WithEvents emailSP_Text As TextBox
    Friend WithEvents nameSP_Text As TextBox
    Friend WithEvents registerConfirmSP As Label
    Friend WithEvents experience As Label
    Friend WithEvents signUpSP As Label
    Friend WithEvents registerSPProfilePic As PictureBox
    Friend WithEvents NoticeHourDropdown As ComboBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents startHoursText As TextBox
    Friend WithEvents SPifscLabel As Label
    Friend WithEvents ifscText As TextBox
    Friend WithEvents SPacc As Label
    Friend WithEvents AccLabel As Label
    Friend WithEvents SPpaymentLabel As Label
    Friend WithEvents SPnoticeHours As Label
    Friend WithEvents SPdescription As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents branchLabel As Label
    Friend WithEvents branchText As TextBox
    Friend WithEvents bankNameLabel As Label
    Friend WithEvents closingHours As Label
    Friend WithEvents closingHoursText As TextBox
    Friend WithEvents emailValidationLabel As Label
    Friend WithEvents ExperienceDropdown As ComboBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Back_btn As Button

End Class
