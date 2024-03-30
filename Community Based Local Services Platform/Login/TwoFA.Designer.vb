<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TwoFA
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
        txtOtp0 = New TextBox()
        txtOtp1 = New TextBox()
        txtOtp2 = New TextBox()
        txtOtp3 = New TextBox()
        grpOtp = New GroupBox()
        Label1 = New Label()
        linkResend = New LinkLabel()
        btnSubmit = New Button()
        Label2 = New Label()
        Panel1 = New Panel()
        Label4 = New Label()
        PictureBox1 = New PictureBox()
        Panel2 = New Panel()
        grpOtp.SuspendLayout()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtOtp0
        ' 
        txtOtp0.Font = New Font("Segoe UI", 24F)
        txtOtp0.Location = New Point(25, 20)
        txtOtp0.MaxLength = 1
        txtOtp0.Name = "txtOtp0"
        txtOtp0.Size = New Size(60, 61)
        txtOtp0.TabIndex = 0
        txtOtp0.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtOtp1
        ' 
        txtOtp1.Font = New Font("Segoe UI", 24F)
        txtOtp1.Location = New Point(91, 20)
        txtOtp1.MaxLength = 1
        txtOtp1.Name = "txtOtp1"
        txtOtp1.Size = New Size(60, 61)
        txtOtp1.TabIndex = 0
        txtOtp1.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtOtp2
        ' 
        txtOtp2.Font = New Font("Segoe UI", 24F)
        txtOtp2.Location = New Point(157, 20)
        txtOtp2.MaxLength = 1
        txtOtp2.Name = "txtOtp2"
        txtOtp2.Size = New Size(60, 61)
        txtOtp2.TabIndex = 0
        txtOtp2.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtOtp3
        ' 
        txtOtp3.Font = New Font("Segoe UI", 24F)
        txtOtp3.Location = New Point(223, 20)
        txtOtp3.MaxLength = 1
        txtOtp3.Name = "txtOtp3"
        txtOtp3.Size = New Size(60, 61)
        txtOtp3.TabIndex = 0
        txtOtp3.TextAlign = HorizontalAlignment.Center
        ' 
        ' grpOtp
        ' 
        grpOtp.BackColor = SystemColors.ControlLight
        grpOtp.Controls.Add(txtOtp3)
        grpOtp.Controls.Add(txtOtp2)
        grpOtp.Controls.Add(txtOtp1)
        grpOtp.Controls.Add(txtOtp0)
        grpOtp.Location = New Point(83, 92)
        grpOtp.Name = "grpOtp"
        grpOtp.Size = New Size(306, 103)
        grpOtp.TabIndex = 1
        grpOtp.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift Light", 10F)
        Label1.Location = New Point(106, 198)
        Label1.Name = "Label1"
        Label1.Size = New Size(159, 21)
        Label1.TabIndex = 2
        Label1.Text = "Didn't receive OTP ?"
        ' 
        ' linkResend
        ' 
        linkResend.AutoSize = True
        linkResend.Font = New Font("Bahnschrift Light", 10F)
        linkResend.LinkBehavior = LinkBehavior.NeverUnderline
        linkResend.LinkColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        linkResend.Location = New Point(265, 198)
        linkResend.Name = "linkResend"
        linkResend.Size = New Size(101, 21)
        linkResend.TabIndex = 3
        linkResend.TabStop = True
        linkResend.Text = "Resend OTP"
        linkResend.VisitedLinkColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        btnSubmit.Font = New Font("Bahnschrift Light", 10F)
        btnSubmit.ForeColor = SystemColors.ButtonFace
        btnSubmit.Location = New Point(107, 299)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(258, 54)
        btnSubmit.TabIndex = 4
        btnSubmit.Text = "Submit"
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift Light", 10F)
        Label2.Location = New Point(107, 243)
        Label2.Name = "Label2"
        Label2.Size = New Size(0, 21)
        Label2.TabIndex = 5
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(15), CByte(42), CByte(55))
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(620, 657)
        Panel1.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.Control
        Label4.Location = New Point(113, 430)
        Label4.Name = "Label4"
        Label4.Size = New Size(393, 24)
        Label4.TabIndex = 19
        Label4.Text = "Community Based Local Services Platform"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resource1.image_removebg_preview_2
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(195, 171)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(206, 240)
        PictureBox1.TabIndex = 17
        PictureBox1.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ControlLight
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(btnSubmit)
        Panel2.Controls.Add(grpOtp)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(linkResend)
        Panel2.Location = New Point(664, 105)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(473, 469)
        Panel2.TabIndex = 7
        ' 
        ' TwoFA
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1182, 653)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "TwoFA"
        Text = "TwoFA"
        grpOtp.ResumeLayout(False)
        grpOtp.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents txtOtp0 As TextBox
    Friend WithEvents txtOtp1 As TextBox
    Friend WithEvents txtOtp2 As TextBox
    Friend WithEvents txtOtp3 As TextBox
    Friend WithEvents grpOtp As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents linkResend As LinkLabel
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel2 As Panel
End Class
