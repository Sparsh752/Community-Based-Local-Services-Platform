Imports System.IO

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Profile_Customer
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
        customerProfilePicture = New PictureBox()
        customerName_tb = New TextBox()
        email_tb = New TextBox()
        contact_tb = New TextBox()
        address_tb = New TextBox()
        location_tb = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        CType(customerProfilePicture, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' customerProfilePicture
        ' 
        customerProfilePicture.BackgroundImage = My.Resources.Resource1.displayPicture
        customerProfilePicture.BackgroundImageLayout = ImageLayout.Stretch
        customerProfilePicture.Location = New Point(215, 66)
        customerProfilePicture.Name = "customerProfilePicture"
        customerProfilePicture.Size = New Size(370, 443)
        customerProfilePicture.TabIndex = 0
        customerProfilePicture.TabStop = False
        ' 
        ' customerName_tb
        ' 
        customerName_tb.BackColor = Color.WhiteSmoke
        customerName_tb.BorderStyle = BorderStyle.None
        customerName_tb.Font = New Font("Bahnschrift SemiCondensed", 32.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        customerName_tb.Location = New Point(629, 66)
        customerName_tb.Name = "customerName_tb"
        customerName_tb.Size = New Size(327, 52)
        customerName_tb.TabIndex = 1
        customerName_tb.Text = "ADITYA MANDAL"
        ' 
        ' email_tb
        ' 
        email_tb.BorderStyle = BorderStyle.FixedSingle
        email_tb.Font = New Font("Bahnschrift Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        email_tb.Location = New Point(629, 171)
        email_tb.Name = "email_tb"
        email_tb.Size = New Size(332, 33)
        email_tb.TabIndex = 2
        email_tb.Text = "aditya.mandal@iitg.ac.in"
        ' 
        ' contact_tb
        ' 
        contact_tb.BorderStyle = BorderStyle.FixedSingle
        contact_tb.Font = New Font("Bahnschrift Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        contact_tb.Location = New Point(629, 237)
        contact_tb.Name = "contact_tb"
        contact_tb.Size = New Size(332, 33)
        contact_tb.TabIndex = 3
        contact_tb.Text = "9939383327"
        ' 
        ' address_tb
        ' 
        address_tb.BorderStyle = BorderStyle.FixedSingle
        address_tb.Font = New Font("Bahnschrift Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        address_tb.Location = New Point(629, 303)
        address_tb.Multiline = True
        address_tb.Name = "address_tb"
        address_tb.Size = New Size(332, 109)
        address_tb.TabIndex = 4
        address_tb.Text = "Brahmaputra Hostel, IIT Guwahati"
        ' 
        ' location_tb
        ' 
        location_tb.BorderStyle = BorderStyle.FixedSingle
        location_tb.Font = New Font("Bahnschrift Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        location_tb.Location = New Point(629, 447)
        location_tb.Name = "location_tb"
        location_tb.Size = New Size(332, 33)
        location_tb.TabIndex = 5
        location_tb.Text = "Guwahati"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.WhiteSmoke
        Label1.Font = New Font("Bahnschrift", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(629, 149)
        Label1.Name = "Label1"
        Label1.Size = New Size(51, 19)
        Label1.TabIndex = 6
        Label1.Text = "Email"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.WhiteSmoke
        Label2.Font = New Font("Bahnschrift", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(629, 215)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 19)
        Label2.TabIndex = 7
        Label2.Text = "Contact"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.WhiteSmoke
        Label3.Font = New Font("Bahnschrift", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(629, 281)
        Label3.Name = "Label3"
        Label3.Size = New Size(69, 19)
        Label3.TabIndex = 8
        Label3.Text = "Address"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.WhiteSmoke
        Label4.Font = New Font("Bahnschrift", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.Black
        Label4.Location = New Point(629, 425)
        Label4.Name = "Label4"
        Label4.Size = New Size(71, 19)
        Label4.TabIndex = 9
        Label4.Text = "Location"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Label5.Cursor = Cursors.Hand
        Label5.Font = New Font("Bahnschrift", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(519, 551)
        Label5.Name = "Label5"
        Label5.Size = New Size(115, 19)
        Label5.TabIndex = 10
        Label5.Text = "Update Details"
        ' 
        ' Profile_Customer
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        BackgroundImage = My.Resources.Resource1.Customer_Profile
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1194, 629)
        ControlBox = False
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(location_tb)
        Controls.Add(address_tb)
        Controls.Add(contact_tb)
        Controls.Add(email_tb)
        Controls.Add(customerName_tb)
        Controls.Add(customerProfilePicture)
        DoubleBuffered = True
        ForeColor = SystemColors.Control
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 2, 3, 2)
        Name = "Profile_Customer"
        StartPosition = FormStartPosition.CenterParent
        TopMost = True
        CType(customerProfilePicture, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents customerProfilePicture As PictureBox
    Friend WithEvents customerName_tb As TextBox
    Friend WithEvents email_tb As TextBox
    Friend WithEvents contact_tb As TextBox
    Friend WithEvents address_tb As TextBox
    Friend WithEvents location_tb As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
