<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LandingPage
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
        PictureBox1 = New PictureBox()
        Label7 = New Label()
        CustomerButton = New Button()
        LoginLabel = New Label()
        Label1 = New Label()
        SPButton = New Button()
        AdminButton = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resource1.image_removebg_preview_2
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(168, 95)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(180, 180)
        PictureBox1.TabIndex = 29
        PictureBox1.TabStop = False
        ' 
        ' Label7
        ' 
        Label7.Location = New Point(12, 288)
        Label7.Name = "Label7"
        Label7.Size = New Size(519, 110)
        Label7.TabIndex = 26
        Label7.Text = "Label7"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CustomerButton
        ' 
        CustomerButton.FlatStyle = FlatStyle.Flat
        CustomerButton.Location = New Point(721, 328)
        CustomerButton.Margin = New Padding(3, 2, 3, 2)
        CustomerButton.Name = "CustomerButton"
        CustomerButton.Size = New Size(131, 30)
        CustomerButton.TabIndex = 23
        CustomerButton.Text = "Customer"
        CustomerButton.UseVisualStyleBackColor = True
        ' 
        ' LoginLabel
        ' 
        LoginLabel.BackColor = Color.Gainsboro
        LoginLabel.Location = New Point(580, 76)
        LoginLabel.Name = "LoginLabel"
        LoginLabel.Size = New Size(414, 368)
        LoginLabel.TabIndex = 18
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Gainsboro
        Label1.Location = New Point(12, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(519, 525)
        Label1.TabIndex = 17
        ' 
        ' SPButton
        ' 
        SPButton.FlatStyle = FlatStyle.Flat
        SPButton.Location = New Point(721, 226)
        SPButton.Margin = New Padding(3, 2, 3, 2)
        SPButton.Name = "SPButton"
        SPButton.Size = New Size(131, 30)
        SPButton.TabIndex = 30
        SPButton.Text = "Service Provider"
        SPButton.UseVisualStyleBackColor = True
        ' 
        ' AdminButton
        ' 
        AdminButton.FlatStyle = FlatStyle.Flat
        AdminButton.Location = New Point(721, 136)
        AdminButton.Margin = New Padding(3, 2, 3, 2)
        AdminButton.Name = "AdminButton"
        AdminButton.Size = New Size(131, 30)
        AdminButton.TabIndex = 31
        AdminButton.Text = "Admin"
        AdminButton.UseVisualStyleBackColor = True
        ' 
        ' LandingPage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1184, 661)
        Controls.Add(AdminButton)
        Controls.Add(SPButton)
        Controls.Add(PictureBox1)
        Controls.Add(Label7)
        Controls.Add(CustomerButton)
        Controls.Add(LoginLabel)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 2, 3, 2)
        Name = "LandingPage"
        Text = "Landing Page"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CustomerButton As Button
    Friend WithEvents LoginLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SPButton As Button
    Friend WithEvents AdminButton As Button
End Class
