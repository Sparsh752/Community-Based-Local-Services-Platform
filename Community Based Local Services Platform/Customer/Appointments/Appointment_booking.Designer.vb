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
        Button10 = New Button()
        ComboBox1 = New ComboBox()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Button11 = New Button()
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
        Label3.Location = New Point(38, 304)
        Label3.Name = "Label3"
        Label3.Size = New Size(113, 23)
        Label3.TabIndex = 2
        Label3.Text = " Select Time"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(38, 254)
        Label4.Name = "Label4"
        Label4.Size = New Size(111, 23)
        Label4.TabIndex = 3
        Label4.Text = " Select Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(40, 200)
        Label5.Name = "Label5"
        Label5.Size = New Size(145, 23)
        Label5.TabIndex = 4
        Label5.Text = " Select Location"
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        DateTimePicker1.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.Location = New Point(309, 255)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(241, 27)
        DateTimePicker1.TabIndex = 5
        DateTimePicker1.Value = New Date(2024, 3, 31, 11, 47, 0, 0)
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(40, 357)
        Label6.Name = "Label6"
        Label6.Size = New Size(72, 19)
        Label6.TabIndex = 6
        Label6.Text = " Morning"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(40, 507)
        Label7.Name = "Label7"
        Label7.Size = New Size(51, 19)
        Label7.TabIndex = 7
        Label7.Text = " Night"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(40, 457)
        Label8.Name = "Label8"
        Label8.Size = New Size(71, 19)
        Label8.TabIndex = 8
        Label8.Text = " Evening"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(40, 407)
        Label9.Name = "Label9"
        Label9.Size = New Size(85, 19)
        Label9.TabIndex = 9
        Label9.Text = " Afternoon"
        ' 
        ' Button10
        ' 
        Button10.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Button10.FlatStyle = FlatStyle.Flat
        Button10.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button10.ForeColor = Color.White
        Button10.Location = New Point(467, 562)
        Button10.Name = "Button10"
        Button10.Size = New Size(222, 33)
        Button10.TabIndex = 19
        Button10.Text = "Proceed to pay"
        Button10.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Bahnschrift Light", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(309, 199)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(241, 27)
        ComboBox1.TabIndex = 20
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Bahnschrift Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(782, 433)
        Label10.Name = "Label10"
        Label10.Size = New Size(168, 23)
        Label10.TabIndex = 21
        Label10.Text = "Advance to be paid"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Bahnschrift Light", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(782, 360)
        Label11.Name = "Label11"
        Label11.Size = New Size(54, 23)
        Label11.TabIndex = 22
        Label11.Text = "Price"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Bahnschrift SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.Location = New Point(782, 393)
        Label12.Name = "Label12"
        Label12.Size = New Size(22, 25)
        Label12.TabIndex = 23
        Label12.Text = "-"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Bahnschrift SemiBold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.Location = New Point(782, 466)
        Label13.Name = "Label13"
        Label13.Size = New Size(22, 25)
        Label13.TabIndex = 24
        Label13.Text = "-"
        ' 
        ' Button11
        ' 
        Button11.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Button11.FlatStyle = FlatStyle.Flat
        Button11.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button11.ForeColor = Color.White
        Button11.Location = New Point(1027, 123)
        Button11.Name = "Button11"
        Button11.Size = New Size(77, 33)
        Button11.TabIndex = 25
        Button11.Text = "Back"
        Button11.UseVisualStyleBackColor = False
        ' 
        ' Appointment_booking
        ' 
        AutoScaleDimensions = New SizeF(7F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1200, 747)
        Controls.Add(Button11)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(ComboBox1)
        Controls.Add(Button10)
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
    Friend WithEvents Button10 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Button11 As Button
End Class
