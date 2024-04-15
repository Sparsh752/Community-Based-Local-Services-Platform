<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddServices_SP
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Service_Name = New TextBox()
        Service_type = New ComboBox()
        Description = New TextBox()
        PictureBox1 = New PictureBox()
        Submit_add = New Button()
        Price = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Service_area = New ComboBox()
        Panel1 = New Panel()
        Location_list = New ListView()
        BackButton = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift SemiBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(69, 60)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(325, 48)
        Label1.TabIndex = 0
        Label1.Text = "Add New Service"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift Light", 19.8000011F)
        Label2.Location = New Point(69, 121)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(269, 48)
        Label2.TabIndex = 1
        Label2.Text = "Service Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bahnschrift Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(69, 508)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(173, 48)
        Label3.TabIndex = 2
        Label3.Text = "Location"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift Light", 19.8000011F)
        Label4.Location = New Point(71, 345)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(235, 48)
        Label4.TabIndex = 3
        Label4.Text = "Description "
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift Light", 19.8000011F)
        Label5.Location = New Point(69, 220)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(245, 48)
        Label5.TabIndex = 4
        Label5.Text = "Service Type"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift Light", 19.8000011F)
        Label6.Location = New Point(895, 374)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(112, 48)
        Label6.TabIndex = 5
        Label6.Text = "Price"
        ' 
        ' Service_Name
        ' 
        Service_Name.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        Service_Name.BorderStyle = BorderStyle.FixedSingle
        Service_Name.Location = New Point(71, 150)
        Service_Name.Margin = New Padding(4, 4, 4, 4)
        Service_Name.Name = "Service_Name"
        Service_Name.Size = New Size(347, 31)
        Service_Name.TabIndex = 0
        ' 
        ' Service_type
        ' 
        Service_type.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        Service_type.DropDownStyle = ComboBoxStyle.DropDownList
        Service_type.FlatStyle = FlatStyle.System
        Service_type.FormattingEnabled = True
        Service_type.Location = New Point(69, 249)
        Service_type.Margin = New Padding(4, 4, 4, 4)
        Service_type.Name = "Service_type"
        Service_type.Size = New Size(349, 33)
        Service_type.TabIndex = 3
        ' 
        ' Description
        ' 
        Description.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        Description.BorderStyle = BorderStyle.FixedSingle
        Description.Location = New Point(69, 374)
        Description.Margin = New Padding(4, 4, 4, 4)
        Description.Multiline = True
        Description.Name = "Description"
        Description.Size = New Size(147, 46)
        Description.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resource1.Upload_img
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Location = New Point(895, 60)
        PictureBox1.Margin = New Padding(4, 4, 4, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(408, 190)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' Submit_add
        ' 
        Submit_add.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Submit_add.BackgroundImageLayout = ImageLayout.None
        Submit_add.FlatStyle = FlatStyle.Popup
        Submit_add.Font = New Font("Bahnschrift Light", 12F)
        Submit_add.ForeColor = Color.White
        Submit_add.Location = New Point(895, 566)
        Submit_add.Margin = New Padding(4, 4, 4, 4)
        Submit_add.Name = "Submit_add"
        Submit_add.Size = New Size(118, 36)
        Submit_add.TabIndex = 9
        Submit_add.Text = "Submit"
        Submit_add.UseVisualStyleBackColor = False
        ' 
        ' Price
        ' 
        Price.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        Price.BorderStyle = BorderStyle.FixedSingle
        Price.Location = New Point(895, 402)
        Price.Margin = New Padding(4, 4, 4, 4)
        Price.Name = "Price"
        Price.Size = New Size(147, 31)
        Price.TabIndex = 10
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Button1.BackgroundImageLayout = ImageLayout.None
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Font = New Font("Bahnschrift Light", 12F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(349, 688)
        Button1.Margin = New Padding(4, 4, 4, 4)
        Button1.Name = "Button1"
        Button1.Size = New Size(118, 36)
        Button1.TabIndex = 12
        Button1.Text = "Clear"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Button2.BackgroundImageLayout = ImageLayout.None
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Font = New Font("Bahnschrift Light", 12F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(71, 688)
        Button2.Margin = New Padding(4, 4, 4, 4)
        Button2.Name = "Button2"
        Button2.Size = New Size(118, 36)
        Button2.TabIndex = 13
        Button2.Text = "Add"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Service_area
        ' 
        Service_area.DropDownStyle = ComboBoxStyle.DropDownList
        Service_area.FlatStyle = FlatStyle.System
        Service_area.FormattingEnabled = True
        Service_area.Location = New Point(69, 586)
        Service_area.Margin = New Padding(4, 4, 4, 4)
        Service_area.Name = "Service_area"
        Service_area.Size = New Size(282, 33)
        Service_area.TabIndex = 15
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Location = New Point(869, 534)
        Panel1.Margin = New Padding(4, 4, 4, 4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(530, 18)
        Panel1.TabIndex = 18
        ' 
        ' Location_list
        ' 
        Location_list.LabelWrap = False
        Location_list.Location = New Point(895, 484)
        Location_list.Margin = New Padding(4, 4, 4, 4)
        Location_list.Name = "Location_list"
        Location_list.Size = New Size(445, 63)
        Location_list.TabIndex = 17
        Location_list.UseCompatibleStateImageBehavior = False
        Location_list.View = View.List
        ' 
        ' BackButton
        ' 
        BackButton.FlatStyle = FlatStyle.Flat
        BackButton.Location = New Point(675, 78)
        BackButton.Margin = New Padding(4, 3, 4, 3)
        BackButton.Name = "BackButton"
        BackButton.Size = New Size(187, 50)
        BackButton.TabIndex = 88
        BackButton.Text = "Back"
        BackButton.UseVisualStyleBackColor = True
        ' 
        ' AddServices_SP
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1478, 816)
        ControlBox = False
        Controls.Add(BackButton)
        Controls.Add(Panel1)
        Controls.Add(Location_list)
        Controls.Add(Service_area)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Price)
        Controls.Add(Submit_add)
        Controls.Add(PictureBox1)
        Controls.Add(Description)
        Controls.Add(Service_type)
        Controls.Add(Service_Name)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4, 4, 4, 4)
        Name = "AddServices_SP"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Service_Name As TextBox
    Friend WithEvents Service_type As ComboBox
    Friend WithEvents Description As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Submit_add As Button
    Friend WithEvents Price As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Service_area As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Location_list As ListView
    Friend WithEvents BackButton As Button

End Class
