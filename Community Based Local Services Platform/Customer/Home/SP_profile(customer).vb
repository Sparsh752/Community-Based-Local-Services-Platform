Imports System.IO


Public Class SP_profile
    ' Constructor to receive and display details
    Public Sub New(name As String, description As String, cost As String, serviceName As String)
        InitializeComponent()

        ' Display the details received
        Label1.Text = name
        Label2.Text = description
        Label3.Text = "Rate: Rs. " & cost
        Label4.Text = serviceName
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)

        Label1.Location = New Point(55, 99)
        Label1.Size = New Size(318, 28)

        Label2.Location = New Point(55, 168)
        Label2.Size = New Size(80, 28)
        Label3.Location = New Point(161, 168)
        Label3.Size = New Size(300, 28)
        Label4.Location = New Point(485, 168)
        Label4.Size = New Size(115, 28)

        Label5.Location = New Point(34, 101)
        Label5.Size = New Size(115, 28)

        Panel1.Width = 359
        Panel2.Height = 571


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
            headingLabel.Text = "Heading" & i
            headingLabel.Font = New Font("Arial", 12, FontStyle.Bold)
            headingLabel.AutoSize = True
            headingLabel.Location = New Point(200, 20)

            groupBox.Controls.Add(headingLabel)

            Dim subheadingLabel As New Label()
            subheadingLabel.Text = "Subheading"
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

            Dim newButton As New Button()

            newButton.Text = "Book Now"
            newButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            newButton.Font = New Font(newButton.Font, FontStyle.Bold)
            newButton.Font = New Font(newButton.Font.FontFamily, 12)
            newButton.Size = New Size(107, 30)
            newButton.Location = New Point(591, 156)
            newButton.BackColor = ColorTranslator.FromHtml("#F9754B")
            newButton.FlatStyle = FlatStyle.Flat
            newButton.FlatAppearance.BorderSize = 0
            newButton.Padding = New Padding(newButton.Padding.Left, newButton.Padding.Top, newButton.Padding.Right, newButton.Padding.Bottom - 10)
            groupBox.Controls.Add(newButton)

            yPosition += groupSize.Height + groupSpacing
        Next

        Dim numItems As Integer = 10

        Dim yPosition2 As Integer = 38
        Panel2.AutoScroll = True
        For i As Integer = 1 To numItems
            Dim itemPanel As New Panel()
            itemPanel.Size = New Size(275, 125)
            itemPanel.Location = New Point(16, yPosition2)
            itemPanel.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            Panel2.Controls.Add(itemPanel)

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
