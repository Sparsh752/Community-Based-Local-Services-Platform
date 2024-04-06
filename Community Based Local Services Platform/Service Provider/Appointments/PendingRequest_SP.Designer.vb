<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendingRequest_SP
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Panel1 = New Panel()
        BackButton = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift Condensed", 20F)
        Label1.Location = New Point(408, 123)
        Label1.Name = "Label1"
        Label1.Size = New Size(103, 48)
        Label1.TabIndex = 0
        Label1.Text = "Label1"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift Condensed", 10F)
        Label2.Location = New Point(425, 175)
        Label2.Name = "Label2"
        Label2.Size = New Size(54, 24)
        Label2.TabIndex = 1
        Label2.Text = "Label2"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bahnschrift Condensed", 10F)
        Label3.Location = New Point(685, 200)
        Label3.Name = "Label3"
        Label3.Size = New Size(54, 24)
        Label3.TabIndex = 2
        Label3.Text = "Label3"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift Condensed", 10F)
        Label4.Location = New Point(708, 241)
        Label4.Name = "Label4"
        Label4.Size = New Size(55, 24)
        Label4.TabIndex = 3
        Label4.Text = "Label4"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift Condensed", 16F)
        Label5.Location = New Point(693, 288)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 39)
        Label5.TabIndex = 4
        Label5.Text = "Label5"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift Condensed", 10F)
        Label6.Location = New Point(698, 329)
        Label6.Name = "Label6"
        Label6.Size = New Size(54, 24)
        Label6.TabIndex = 5
        Label6.Text = "Label6"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Bahnschrift Condensed", 16F)
        Label7.Location = New Point(705, 374)
        Label7.Name = "Label7"
        Label7.Size = New Size(87, 39)
        Label7.TabIndex = 6
        Label7.Text = "Label7"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Bahnschrift Condensed", 10F)
        Label8.Location = New Point(707, 419)
        Label8.Name = "Label8"
        Label8.Size = New Size(54, 24)
        Label8.TabIndex = 7
        Label8.Text = "Label8"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Bahnschrift Condensed", 16F)
        Label9.Location = New Point(705, 455)
        Label9.Name = "Label9"
        Label9.Size = New Size(87, 39)
        Label9.TabIndex = 8
        Label9.Text = "Label9"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(389, 410)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 9
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(519, 414)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 34)
        Button2.TabIndex = 10
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(314, 89)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(577, 478)
        Panel1.TabIndex = 11
        ' 
        ' BackButton
        ' 
        BackButton.FlatStyle = FlatStyle.Flat
        BackButton.Location = New Point(968, 63)
        BackButton.Margin = New Padding(4, 3, 4, 3)
        BackButton.Name = "BackButton"
        BackButton.Size = New Size(187, 50)
        BackButton.TabIndex = 86
        BackButton.Text = "Back"
        BackButton.UseVisualStyleBackColor = True
        ' 
        ' PendingRequest_SP
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1178, 579)
        Controls.Add(BackButton)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel1)
        Name = "PendingRequest_SP"
        Text = "PendingAcceptOrReject_SP"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BackButton As Button
End Class
