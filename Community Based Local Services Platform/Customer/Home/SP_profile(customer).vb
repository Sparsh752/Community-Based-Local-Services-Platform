Imports System.IO


Public Class SP_profile
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


        Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")

        Try
            If Not File.Exists(imagePath) Then
                ' Handle the situation when the image file doesn't exist
                MessageBox.Show("Image file not found: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Handle any other exceptions that might occur during image loading
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Dim panel As New Panel()
        panel.Location = New Point(10, 175)
        panel.Size = New Size(833, 450) ' Adjust panel size to accommodate group size and spacing
        panel.AutoScroll = True ' Enable auto-scrolling

        ' Add the panel to the form
        Me.Controls.Add(panel)

        ' Generate some example items to add to the panel
        Dim numGroups As Integer = 16 ' Change this value to the desired number of groups

        Dim groupSize As New Size(750, 200) ' Size of each group
        Dim groupSpacing As Integer = 10 ' Spacing between groups

        Dim yPosition As Integer = 0 ' Starting Y position for groups

        For i As Integer = 1 To numGroups
            ' Create a group box to encapsulate each group
            Dim groupBox As New GroupBox()
            groupBox.Size = groupSize
            groupBox.Location = New Point(50, yPosition)

            ' Add the group box to the panel
            panel.Controls.Add(groupBox)

            ' Add an image to the group box
            Dim im As New PictureBox()
            im.SizeMode = PictureBoxSizeMode.StretchImage
            im.Size = New Size(170, 170)
            im.Location = New Point(10, 20)
            im.Image = Image.FromFile(imagePath)

            ' Add the image to the group box
            groupBox.Controls.Add(im)

            ' Add heading, subheading, and description labels
            Dim headingLabel As New Label()
            headingLabel.Text = "Heading" & i
            headingLabel.Font = New Font("Arial", 12, FontStyle.Bold)
            headingLabel.AutoSize = True
            headingLabel.Location = New Point(200, 20)

            ' Add the heading label to the group box
            groupBox.Controls.Add(headingLabel)

            Dim subheadingLabel As New Label()
            subheadingLabel.Text = "Subheading"
            subheadingLabel.Font = New Font("Arial", 10)
            subheadingLabel.AutoSize = True
            subheadingLabel.Location = New Point(200, 50)

            ' Add the subheading label to the group box
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


            ' Increment the Y position for the next group
            yPosition += groupSize.Height + groupSpacing ' Add spacing between groups
        Next







        Dim numItems As Integer = 10 ' Change this value to the desired number of items

        Dim yPosition2 As Integer = 38 ' Starting Y position for items inside the groupBox1
        Panel6.AutoScroll = True
        For i As Integer = 1 To numItems
            ' Create an item panel
            Dim itemPanel As New Panel()
            itemPanel.Size = New Size(275, 125)
            itemPanel.Location = New Point(16, yPosition2)
            itemPanel.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            ' Add the item panel to the groupBox1
            Panel6.Controls.Add(itemPanel)

            ' Add heading label
            Dim headingLabel As New Label()
            headingLabel.Text = "Name " & i
            headingLabel.Font = New Font("Segoe", 9)
            headingLabel.AutoSize = True
            headingLabel.Location = New Point(20, 10)

            ' Add the heading label to the item panel
            itemPanel.Controls.Add(headingLabel)



            Dim textLabel As New Label()
            textLabel.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis " & i
            textLabel.Font = New Font("Segoe", 8)
            textLabel.AutoSize = False
            textLabel.Size = New Size(240, 81)
            textLabel.Location = New Point(20, 40)
            textLabel.AutoEllipsis = True
            textLabel.BorderStyle = BorderStyle.None

            ' Add the text label to the item panel
            itemPanel.Controls.Add(textLabel)

            ' Increment the Y position for the next item
            yPosition2 += 150  ' Add some spacing between items
        Next



    End Sub
End Class