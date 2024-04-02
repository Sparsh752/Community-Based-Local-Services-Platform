Imports System.IO


Public Class Homepage_SP
    Public Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If SessionManager.Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            SessionManager.Panel3.Controls.Clear()
        End If
    End Sub


    Private Sub AddServicesButton_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        AddServices_SP.Margin = New Padding(0, 0, 0, 0)
        With AddServices_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(AddServices_SP)
            .BringToFront()
            .Show()
        End With
    End Sub


    Private Sub EditServicesButton_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        UpdateServices_SP.Margin = New Padding(0, 0, 0, 0)
        With UpdateServices_SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(UpdateServices_SP)
            .BringToFront()
            .Show()
        End With
    End Sub



    Private Sub EditProfileButton_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        RegisterSP.Margin = New Padding(0, 0, 0, 0)
        With RegisterSP
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(RegisterSP)
            .BringToFront()
            .Show()
            RegisterSP.Back_btn.Visible = False
        End With
    End Sub



    Private Sub DeleteServiceButton_Click(sender As Object, e As EventArgs)
        MessageBox.Show("service is deleted!")
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)

        Label1.Location = New Point(55, 80)

        Label5.Location = New Point(20, 34)
        Label2.Location = New Point(55, 138)
        Label3.Location = New Point(161, 138)
        Label4.Location = New Point(485, 138)

        Panel1.Location = New Point(843, 65)
        Panel6.Location = New Point(10, 64)





        Dim textSize As Size = Label2.Location
        Label2.Location = textSize
        textSize.Width = textSize.Width + Label2.Size.Width
        Label6.Location = New Point(textSize.Width - 5, textSize.Height - 13)
        textSize.Width = textSize.Width + Label6.Size.Width - 5
        Label3.Location = textSize
        textSize.Width = textSize.Width + Label3.Size.Width
        Label7.Location = New Point(textSize.Width - 5, textSize.Height - 13)
        textSize.Width = textSize.Width + Label7.Size.Width - 5
        Label4.Location = textSize

        Dim newButton3 As New Button()

        newButton3.Text = "Add New Service"
        newButton3.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        newButton3.Font = New Font(newButton3.Font, FontStyle.Bold)
        newButton3.Font = New Font(newButton3.Font.FontFamily, 12)
        newButton3.Size = New Size(200, 30)
        newButton3.Location = New Point(600, 90)
        newButton3.BackColor = ColorTranslator.FromHtml("#F9754B")
        newButton3.FlatStyle = FlatStyle.Flat
        newButton3.FlatAppearance.BorderSize = 0
        newButton3.Padding = New Padding(newButton3.Padding.Left, newButton3.Padding.Top, newButton3.Padding.Right, newButton3.Padding.Bottom - 10)
        AddHandler newButton3.Click, AddressOf AddServicesButton_Click
        Me.Controls.Add(newButton3)



        Dim newButton4 As New Button()

        newButton4.Text = "Edit Profile"
        newButton4.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        newButton4.Font = New Font(newButton4.Font, FontStyle.Bold)
        newButton4.Font = New Font(newButton4.Font.FontFamily, 12)
        newButton4.Size = New Size(200, 30)
        newButton4.Location = New Point(600, 130)
        newButton4.BackColor = ColorTranslator.FromHtml("#F9754B")
        newButton4.FlatStyle = FlatStyle.Flat
        newButton4.FlatAppearance.BorderSize = 0
        newButton4.Padding = New Padding(newButton4.Padding.Left, newButton4.Padding.Top, newButton4.Padding.Right, newButton4.Padding.Bottom - 10)
        AddHandler newButton4.Click, AddressOf EditProfileButton_Click
        Me.Controls.Add(newButton4)


        Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")

        Try
            If Not File.Exists(imagePath) Then
                MessageBox.Show("Image file not found: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Dim panel As New Panel()
        panel.Location = New Point(10, 175)
        panel.Size = New Size(833, 450)
        panel.AutoScroll = True

        Me.Controls.Add(panel)

        Dim numGroups As Integer = 16

        Dim groupSize As New Size(750, 200)
        Dim groupSpacing As Integer = 10

        Dim yPosition As Integer = 0

        For i As Integer = 1 To numGroups
            Dim groupBox As New GroupBox()
            groupBox.Size = groupSize
            groupBox.Location = New Point(50, yPosition)

            panel.Controls.Add(groupBox)

            Dim im As New PictureBox()
            im.SizeMode = PictureBoxSizeMode.StretchImage
            im.Size = New Size(170, 170)
            im.Location = New Point(10, 20)
            im.Image = Image.FromFile(imagePath)

            groupBox.Controls.Add(im)

            Dim headingLabel As New Label()
            headingLabel.Text = "Service " & i
            headingLabel.Font = New Font("Arial", 12, FontStyle.Bold)
            headingLabel.AutoSize = True
            headingLabel.Location = New Point(200, 20)

            groupBox.Controls.Add(headingLabel)

            Dim subheadingLabel As New Label()
            subheadingLabel.Text = "Rate: Rs 500"
            subheadingLabel.Font = New Font("Arial", 10)
            subheadingLabel.AutoSize = True
            subheadingLabel.Location = New Point(200, 50)

            groupBox.Controls.Add(subheadingLabel)

            Dim descriptionLabel As New Label()
            descriptionLabel.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec."
            descriptionLabel.AutoSize = False
            descriptionLabel.Size = New Size(500, 80)
            descriptionLabel.Location = New Point(200, 80)
            descriptionLabel.AutoEllipsis = True
            descriptionLabel.BorderStyle = BorderStyle.None

            groupBox.Controls.Add(descriptionLabel)


            Dim newButton1 As New Button()

            newButton1.Text = "Delete"
            newButton1.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            newButton1.Font = New Font(newButton1.Font, FontStyle.Bold)
            newButton1.Font = New Font(newButton1.Font.FontFamily, 12)
            newButton1.Size = New Size(107, 30)
            newButton1.Location = New Point(591, 156)
            newButton1.BackColor = ColorTranslator.FromHtml("#F9754B")
            newButton1.FlatStyle = FlatStyle.Flat
            newButton1.FlatAppearance.BorderSize = 0
            newButton1.Padding = New Padding(newButton1.Padding.Left, newButton1.Padding.Top, newButton1.Padding.Right, newButton1.Padding.Bottom - 10)
            AddHandler newButton1.Click, AddressOf DeleteServiceButton_Click
            groupBox.Controls.Add(newButton1)


            Dim newButton2 As New Button()

            newButton2.Text = "Edit"
            newButton2.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            newButton2.Font = New Font(newButton2.Font, FontStyle.Bold)
            newButton2.Font = New Font(newButton2.Font.FontFamily, 12)
            newButton2.Size = New Size(107, 30)
            newButton2.Location = New Point(459, 156)
            newButton2.BackColor = ColorTranslator.FromHtml("#F9754B")
            newButton2.FlatStyle = FlatStyle.Flat
            newButton2.FlatAppearance.BorderSize = 0
            newButton2.Padding = New Padding(newButton2.Padding.Left, newButton2.Padding.Top, newButton2.Padding.Right, newButton2.Padding.Bottom - 10)
            AddHandler newButton2.Click, AddressOf EditServicesButton_Click
            groupBox.Controls.Add(newButton2)

            yPosition += groupSize.Height + groupSpacing
        Next







        Dim numItems As Integer = 10

        Dim yPosition2 As Integer = 38
        Panel6.AutoScroll = True
        For i As Integer = 1 To numItems
            Dim itemPanel As New Panel()
            itemPanel.Size = New Size(275, 125)
            itemPanel.Location = New Point(16, yPosition2)
            itemPanel.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            Panel6.Controls.Add(itemPanel)

            Dim headingLabel As New Label()
            headingLabel.Text = "Name " & i
            headingLabel.Font = New Font("Segoe", 9)
            headingLabel.AutoSize = True
            headingLabel.Location = New Point(20, 10)

            itemPanel.Controls.Add(headingLabel)



            Dim textLabel As New Label()
            textLabel.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis " & i
            textLabel.Font = New Font("Segoe", 8)
            textLabel.AutoSize = False
            textLabel.Size = New Size(240, 81)
            textLabel.Location = New Point(20, 40)
            textLabel.AutoEllipsis = True
            textLabel.BorderStyle = BorderStyle.None

            itemPanel.Controls.Add(textLabel)

            yPosition2 += 150
        Next



    End Sub
End Class