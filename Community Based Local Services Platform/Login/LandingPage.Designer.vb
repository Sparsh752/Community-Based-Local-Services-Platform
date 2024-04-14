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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LandingPage))
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
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(192, 127)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(206, 240)
        PictureBox1.TabIndex = 29
        PictureBox1.TabStop = False
        ' 
        ' Label7
        ' 
        Label7.Location = New Point(14, 384)
        Label7.Name = "Label7"
        Label7.Size = New Size(593, 147)
        Label7.TabIndex = 26
        Label7.Text = "Label7"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CustomerButton
        ' 
        CustomerButton.FlatStyle = FlatStyle.Flat
        CustomerButton.Location = New Point(824, 437)
        CustomerButton.Name = "CustomerButton"
        CustomerButton.Size = New Size(150, 40)
        CustomerButton.TabIndex = 23
        CustomerButton.Text = "Customer"
        CustomerButton.UseVisualStyleBackColor = True
        ' 
        ' LoginLabel
        ' 
        LoginLabel.BackColor = Color.Gainsboro
        LoginLabel.Location = New Point(663, 101)
        LoginLabel.Name = "LoginLabel"
        LoginLabel.Size = New Size(473, 491)
        LoginLabel.TabIndex = 18
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Gainsboro
        Label1.Location = New Point(14, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(593, 700)
        Label1.TabIndex = 17
        ' 
        ' SPButton
        ' 
        SPButton.FlatStyle = FlatStyle.Flat
        SPButton.Location = New Point(824, 301)
        SPButton.Name = "SPButton"
        SPButton.Size = New Size(150, 40)
        SPButton.TabIndex = 30
        SPButton.Text = "Service Provider"
        SPButton.UseVisualStyleBackColor = True
        ' 
        ' AdminButton
        ' 
        AdminButton.FlatStyle = FlatStyle.Flat
        AdminButton.Location = New Point(824, 181)
        AdminButton.Name = "AdminButton"
        AdminButton.Size = New Size(150, 40)
        AdminButton.TabIndex = 31
        AdminButton.Text = "Admin"
        AdminButton.UseVisualStyleBackColor = True
        ' 
        ' LandingPage
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1353, 881)
        Controls.Add(AdminButton)
        Controls.Add(SPButton)
        Controls.Add(PictureBox1)
        Controls.Add(Label7)
        Controls.Add(CustomerButton)
        Controls.Add(LoginLabel)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedDialog
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
