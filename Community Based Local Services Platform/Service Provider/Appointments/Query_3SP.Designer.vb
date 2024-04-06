<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Query_3SP
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
        Panel1 = New Panel()
        ComboBox1 = New ComboBox()
        Button1 = New Button()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Panel2 = New Panel()
        RichTextBox1 = New RichTextBox()
        BackButton = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Panel2)
        Panel1.Location = New Point(500, 125)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(572, 634)
        Panel1.TabIndex = 0
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Bahnschrift Light", 12F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(50, 251)
        ComboBox1.Margin = New Padding(4)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(442, 37)
        ComboBox1.TabIndex = 7
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Coral
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Bahnschrift", 10F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(174, 560)
        Button1.Margin = New Padding(4)
        Button1.Name = "Button1"
        Button1.Size = New Size(199, 45)
        Button1.TabIndex = 6
        Button1.Text = "Send"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift Light", 10F)
        Label5.ForeColor = SystemColors.ControlDarkDark
        Label5.Location = New Point(42, 324)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(172, 24)
        Label5.TabIndex = 4
        Label5.Text = "Query Description"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift Light", 10F)
        Label4.ForeColor = SystemColors.ControlDarkDark
        Label4.Location = New Point(42, 221)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(110, 24)
        Label4.TabIndex = 2
        Label4.Text = "Query Type"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bahnschrift", 20F)
        Label3.Location = New Point(36, 144)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(120, 48)
        Label3.TabIndex = 1
        Label3.Text = "12345"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift Light", 10F)
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.Location = New Point(42, 118)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(81, 24)
        Label2.TabIndex = 1
        Label2.Text = "Appt. ID"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift", 20F)
        Label1.Location = New Point(35, 41)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(234, 48)
        Label1.TabIndex = 0
        Label1.Text = "Raise Query"
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(RichTextBox1)
        Panel2.Location = New Point(50, 367)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(442, 169)
        Panel2.TabIndex = 1
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Bahnschrift Light", 10F)
        RichTextBox1.Location = New Point(8, 4)
        RichTextBox1.Margin = New Padding(4)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(424, 161)
        RichTextBox1.TabIndex = 5
        RichTextBox1.Text = ""
        ' 
        ' BackButton
        ' 
        BackButton.FlatStyle = FlatStyle.Flat
        BackButton.Location = New Point(1231, 67)
        BackButton.Margin = New Padding(4, 3, 4, 3)
        BackButton.Name = "BackButton"
        BackButton.Size = New Size(187, 50)
        BackButton.TabIndex = 86
        BackButton.Text = "Back"
        BackButton.UseVisualStyleBackColor = True
        ' 
        ' Query_3SP
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1456, 735)
        Controls.Add(BackButton)
        Controls.Add(Panel1)
        Margin = New Padding(4)
        Name = "Query_3SP"
        Text = "Query_3SP"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BackButton As Button
End Class
