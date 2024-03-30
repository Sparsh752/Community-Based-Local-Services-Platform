<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChatBox
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
        SendButton = New Button()
        RichTextBox1 = New RichTextBox()
        Panel1 = New Panel()
        Label1 = New Label()
        Panel2 = New Panel()
        SuspendLayout()
        ' 
        ' SendButton
        ' 
        SendButton.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        SendButton.FlatAppearance.BorderSize = 0
        SendButton.FlatStyle = FlatStyle.Flat
        SendButton.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SendButton.ForeColor = Color.White
        SendButton.Location = New Point(317, 404)
        SendButton.Margin = New Padding(0)
        SendButton.Name = "SendButton"
        SendButton.Size = New Size(57, 26)
        SendButton.TabIndex = 6
        SendButton.Text = "Logout"
        SendButton.UseVisualStyleBackColor = False
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Location = New Point(23, 396)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(282, 42)
        RichTextBox1.TabIndex = 7
        RichTextBox1.Text = ""
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(48, 76)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 150)
        Panel1.TabIndex = 8
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift", 16F)
        Label1.Location = New Point(121, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(155, 39)
        Label1.TabIndex = 9
        Label1.Text = "CHATBOX"
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Location = New Point(12, 388)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(391, 57)
        Panel2.TabIndex = 10
        ' 
        ' ChatBox
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(415, 450)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Controls.Add(SendButton)
        Controls.Add(RichTextBox1)
        Controls.Add(Panel2)
        Name = "ChatBox"
        Text = "ChatBox"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents SendButton As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
End Class
