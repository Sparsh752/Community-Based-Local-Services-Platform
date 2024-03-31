<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Appointment_booking
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
        DateTimePicker1 = New DateTimePicker()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Button8 = New Button()
        Button9 = New Button()
        Button10 = New Button()
        ComboBox1 = New ComboBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(38, 91)
        Label1.Name = "Label1"
        Label1.Size = New Size(237, 33)
        Label1.TabIndex = 0
        Label1.Text = "Book Appointment"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(38, 133)
        Label2.Name = "Label2"
        Label2.Size = New Size(230, 23)
        Label2.TabIndex = 1
        Label2.Text = " Service, Service Provider"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bahnschrift Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(38, 293)
        Label3.Name = "Label3"
        Label3.Size = New Size(113, 23)
        Label3.TabIndex = 2
        Label3.Text = " Select Time"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(38, 244)
        Label4.Name = "Label4"
        Label4.Size = New Size(111, 23)
        Label4.TabIndex = 3
        Label4.Text = " Select Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(38, 188)
        Label5.Name = "Label5"
        Label5.Size = New Size(145, 23)
        Label5.TabIndex = 4
        Label5.Text = " Select Location"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CustomFormat = "dd-MM-yy"
        DateTimePicker1.Font = New Font("Bahnschrift Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.Location = New Point(309, 245)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(225, 23)
        DateTimePicker1.TabIndex = 5
        DateTimePicker1.Value = New Date(2024, 3, 31, 11, 47, 0, 0)
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(38, 346)
        Label6.Name = "Label6"
        Label6.Size = New Size(72, 19)
        Label6.TabIndex = 6
        Label6.Text = " Morning"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(38, 495)
        Label7.Name = "Label7"
        Label7.Size = New Size(51, 19)
        Label7.TabIndex = 7
        Label7.Text = " Night"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(38, 446)
        Label8.Name = "Label8"
        Label8.Size = New Size(71, 19)
        Label8.TabIndex = 8
        Label8.Text = " Evening"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(38, 397)
        Label9.Name = "Label9"
        Label9.Size = New Size(85, 19)
        Label9.TabIndex = 9
        Label9.Text = " Afternoon"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.White
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Location = New Point(148, 342)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 30)
        Button1.TabIndex = 10
        Button1.Text = "09:00 AM"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.White
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Location = New Point(339, 342)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 30)
        Button2.TabIndex = 11
        Button2.Text = "11:00 AM"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.White
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Location = New Point(244, 342)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 30)
        Button3.TabIndex = 12
        Button3.Text = "10:00 AM"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.White
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Location = New Point(244, 491)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 30)
        Button4.TabIndex = 13
        Button4.Text = "10:00 PM"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.BackColor = Color.White
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Location = New Point(148, 491)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 30)
        Button5.TabIndex = 14
        Button5.Text = "09:00 PM"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button6
        ' 
        Button6.BackColor = Color.White
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Location = New Point(244, 442)
        Button6.Name = "Button6"
        Button6.Size = New Size(75, 30)
        Button6.TabIndex = 15
        Button6.Text = "08:00 PM"
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button7
        ' 
        Button7.BackColor = Color.White
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Location = New Point(148, 442)
        Button7.Name = "Button7"
        Button7.Size = New Size(75, 30)
        Button7.TabIndex = 16
        Button7.Text = "07:00 PM"
        Button7.UseVisualStyleBackColor = False
        ' 
        ' Button8
        ' 
        Button8.BackColor = Color.White
        Button8.FlatStyle = FlatStyle.Flat
        Button8.Location = New Point(244, 393)
        Button8.Name = "Button8"
        Button8.Size = New Size(75, 30)
        Button8.TabIndex = 17
        Button8.Text = "02:00 PM"
        Button8.UseVisualStyleBackColor = False
        ' 
        ' Button9
        ' 
        Button9.BackColor = Color.White
        Button9.FlatStyle = FlatStyle.Flat
        Button9.Location = New Point(148, 393)
        Button9.Name = "Button9"
        Button9.Size = New Size(75, 30)
        Button9.TabIndex = 18
        Button9.Text = "01:00 PM"
        Button9.UseVisualStyleBackColor = False
        ' 
        ' Button10
        ' 
        Button10.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Button10.FlatStyle = FlatStyle.Flat
        Button10.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button10.ForeColor = Color.White
        Button10.Location = New Point(793, 481)
        Button10.Name = "Button10"
        Button10.Size = New Size(222, 33)
        Button10.TabIndex = 19
        Button10.Text = "Proceed to pay"
        Button10.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"Location1", "Location2", "Location3"})
        ComboBox1.Location = New Point(309, 189)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(225, 24)
        ComboBox1.TabIndex = 20
        ' 
        ' Appointment_booking
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1200, 747)
        Controls.Add(ComboBox1)
        Controls.Add(Button10)
        Controls.Add(Button9)
        Controls.Add(Button8)
        Controls.Add(Button7)
        Controls.Add(Button6)
        Controls.Add(Button5)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(DateTimePicker1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Bahnschrift Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        Name = "Appointment_booking"
        Text = " "
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents ComboBox1 As ComboBox
End Class
