<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginPage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginPage))
        Label1 = New Label()
        LoginLabel = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        CheckBox1 = New CheckBox()
        Button1 = New Button()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        PictureBox1 = New PictureBox()
        Button2 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Gainsboro
        Label1.Location = New Point(11, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(593, 700)
        Label1.TabIndex = 0
        ' 
        ' LoginLabel
        ' 
        LoginLabel.BackColor = Color.Gainsboro
        LoginLabel.Location = New Point(661, 99)
        LoginLabel.Name = "LoginLabel"
        LoginLabel.Size = New Size(473, 491)
        LoginLabel.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.FlatStyle = FlatStyle.System
        Label2.Font = New Font("Segoe UI Variable Text", 30F, FontStyle.Regular, GraphicsUnit.Pixel, CByte(0))
        Label2.ImageAlign = ContentAlignment.TopLeft
        Label2.Location = New Point(731, 147)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(280, 55)
        Label2.TabIndex = 2
        Label2.Text = "Login"
        ' 
        ' Label3
        ' 
        Label3.FlatStyle = FlatStyle.System
        Label3.ImageAlign = ContentAlignment.TopLeft
        Label3.Location = New Point(731, 213)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(280, 28)
        Label3.TabIndex = 3
        Label3.Text = "Email"
        ' 
        ' Label4
        ' 
        Label4.Location = New Point(731, 336)
        Label4.Name = "Label4"
        Label4.Size = New Size(280, 28)
        Label4.TabIndex = 5
        Label4.Text = "Password"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(938, 407)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(132, 24)
        CheckBox1.TabIndex = 7
        CheckBox1.Text = "Show Password"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(822, 489)
        Button1.Name = "Button1"
        Button1.Size = New Size(150, 40)
        Button1.TabIndex = 8
        Button1.Text = "Login"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.FlatStyle = FlatStyle.System
        Label5.Location = New Point(775, 599)
        Label5.Name = "Label5"
        Label5.Size = New Size(159, 28)
        Label5.TabIndex = 9
        Label5.Text = "Don't have an account?"
        ' 
        ' Label6
        ' 
        Label6.FlatStyle = FlatStyle.System
        Label6.Location = New Point(934, 599)
        Label6.Name = "Label6"
        Label6.Size = New Size(159, 28)
        Label6.TabIndex = 10
        Label6.Text = "Label6"
        ' 
        ' Label7
        ' 
        Label7.Location = New Point(11, 381)
        Label7.Name = "Label7"
        Label7.Size = New Size(593, 147)
        Label7.TabIndex = 11
        Label7.Text = "Label7"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Location = New Point(731, 369)
        TextBox1.Name = "TextBox1"
        TextBox1.PasswordChar = "*"c
        TextBox1.Size = New Size(331, 27)
        TextBox1.TabIndex = 14
        ' 
        ' TextBox2
        ' 
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.Location = New Point(730, 261)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(331, 27)
        TextBox2.TabIndex = 15
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(190, 124)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(206, 240)
        PictureBox1.TabIndex = 16
        PictureBox1.TabStop = False
        ' 
        ' Button2
        ' 
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(1099, 40)
        Button2.Name = "Button2"
        Button2.Size = New Size(150, 40)
        Button2.TabIndex = 17
        Button2.Text = "Back"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' LoginPage
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1353, 881)
        Controls.Add(Button2)
        Controls.Add(PictureBox1)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Button1)
        Controls.Add(CheckBox1)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(LoginLabel)
        Controls.Add(Label1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "LoginPage"
        Text = "LoginPage"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents LoginLabel As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button2 As Button
End Class
