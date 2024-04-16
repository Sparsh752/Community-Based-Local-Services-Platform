<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class View_Query_Customer
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
        TextBox1 = New TextBox()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label5 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = SystemColors.ControlLight
        TextBox1.Location = New Point(43, 255)
        TextBox1.Margin = New Padding(3, 4, 3, 4)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(539, 105)
        TextBox1.TabIndex = 8
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(0, 0)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 23)
        Button3.TabIndex = 9
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(0, 0)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 10
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(0, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F)
        Label5.Location = New Point(43, 218)
        Label5.Name = "Label5"
        Label5.Size = New Size(133, 23)
        Label5.TabIndex = 4
        Label5.Text = "Reply To Query :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F)
        Label4.Location = New Point(43, 141)
        Label4.Name = "Label4"
        Label4.Size = New Size(173, 23)
        Label4.TabIndex = 3
        Label4.Text = "10:40 am          Today"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F)
        Label2.Location = New Point(43, 94)
        Label2.Name = "Label2"
        Label2.Size = New Size(110, 23)
        Label2.TabIndex = 1
        Label2.Text = "Lorem Ipsum"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(43, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(356, 36)
        Label1.TabIndex = 0
        Label1.Text = "Did not receive payment"
        ' 
        ' View_Query_Customer
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(631, 414)
        Controls.Add(TextBox1)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "View_Query_Customer"
        Text = "Query"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label

End Class
