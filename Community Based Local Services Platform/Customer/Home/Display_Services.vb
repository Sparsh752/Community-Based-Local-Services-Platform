Imports System.IO

Public Class Display_Services
    Private Most_Trusted(3) As String
    Private Popular_Trusted(3) As String

    ' Define the service provider class
    Private Class ServiceProvider
        Public Property Name As String
        Public Property Cost As String
    End Class

    Private Sub Display_Services_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate the arrays with service provider names
        Most_Trusted(0) = "Provider 1"
        Most_Trusted(1) = "Provider 2"
        Most_Trusted(2) = "Provider 3"
        Most_Trusted(3) = "Provider 4"

        Popular_Trusted(0) = "Provider A"
        Popular_Trusted(1) = "Provider B"
        Popular_Trusted(2) = "Provider C"
        Popular_Trusted(3) = "Provider D"

        ' Display the default data
        DisplayProviders(Most_Trusted, "Most Trusted Service Providers", 90)
        DisplayProviders(Popular_Trusted, "Trending Services", 350)
    End Sub

    ' Default Homepage for most trusted service providers and trending services
    Private Sub DisplayProviders(providers As String(), heading As String, topOffset As Integer)
        Dim lblHeading As New Label()
        lblHeading.Text = heading
        lblHeading.Font = New Font("Bahnschrift Light", 18, FontStyle.Bold)
        lblHeading.AutoSize = True
        lblHeading.Location = New Point(40, topOffset)
        Me.Controls.Add(lblHeading)

        Dim startX As Integer = 60 ' Starting X position for PictureBox and Label
        ' Combine the startup path with the relative path to the image file
        Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")

        ' Check if the image file exists
        Try
            If Not File.Exists(imagePath) Then
                ' Handle the situation when the image file doesn't exist
                MessageBox.Show("Image file not found: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            ' Handle any other exceptions that might occur during image loading
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        For i As Integer = 0 To providers.Length - 1
            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(150, 150)
            pb.Location = New Point(startX + (i * 200) - 10, topOffset + 50)
            pb.Image = Image.FromFile(imagePath)

            Dim lblProvider As New Label()
            lblProvider.Text = providers(i)
            lblProvider.AutoSize = True
            lblProvider.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
            lblProvider.Location = New Point(startX + (i * 200) + 20, topOffset + 210)

            Me.Controls.Add(pb)
            Me.Controls.Add(lblProvider)
        Next
    End Sub

    ' Method to update services based on search criteria
    ' Public Sub UpdateServices(searchCriteria As String)
    ' Implement your logic to update services based on search criteria
    ' For demonstration purposes, I'm clearing the controls in the form
    ' You need to replace this with your actual logic to update services
    ' Me.Controls.Clear()
    '  End Sub
    ' Method to update services based on search criteria
    ' Method to update services based on search criteria
    Public Sub UpdateServices(searchCriteria As String)
        ' Clear existing controls from the form
        Me.Controls.Clear()

        ' Simulate fetching data based on search criteria
        Dim serviceProviders As New List(Of ServiceProvider)()

        ' Sample data - Replace this with actual data fetching logic
        If searchCriteria.ToLower() = "cleaning" Then
            serviceProviders.Add(New ServiceProvider() With {.Name = "Cleaner 1", .Cost = "$50"})
            serviceProviders.Add(New ServiceProvider() With {.Name = "Cleaner 2", .Cost = "$60"})
            serviceProviders.Add(New ServiceProvider() With {.Name = "Cleaner 3", .Cost = "$55"})
        ElseIf searchCriteria.ToLower() = "plumbing" Then
            serviceProviders.Add(New ServiceProvider() With {.Name = "Plumber A", .Cost = "$80"})
            serviceProviders.Add(New ServiceProvider() With {.Name = "Plumber B", .Cost = "$90"})
            serviceProviders.Add(New ServiceProvider() With {.Name = "Plumber C", .Cost = "$85"})
        End If

        ' Display the service providers on Panel2
        Dim topOffset As Integer = 50
        For Each provider In serviceProviders.Take(3) ' Display only the first 3 service providers
            ' Load and display image for the service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            If File.Exists(imagePath) Then
                ' Create a panel to contain PictureBox and labels with black border
                Dim providerPanel As New Panel()
                providerPanel.Size = New Size(300, 100)
                providerPanel.Location = New Point(10, topOffset)
                providerPanel.BorderStyle = BorderStyle.FixedSingle ' Apply black border
                Me.Controls.Add(providerPanel)

                ' Create PictureBox for the image
                Dim imagePictureBox As New PictureBox()
                imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage
                imagePictureBox.Size = New Size(80, 80)
                imagePictureBox.Location = New Point(10, 10)
                imagePictureBox.Image = Image.FromFile(imagePath)
                providerPanel.Controls.Add(imagePictureBox)

                ' Create labels for name and cost
                Dim nameLabel As New Label()
                nameLabel.Text = provider.Name
                nameLabel.AutoSize = True
                nameLabel.Location = New Point(100, 10)
                providerPanel.Controls.Add(nameLabel)

                Dim costLabel As New Label()
                costLabel.Text = "Cost: " & provider.Cost
                costLabel.AutoSize = True
                costLabel.Location = New Point(100, 30)
                providerPanel.Controls.Add(costLabel)
            Else
                ' Handle the situation when the image file doesn't exist
                MessageBox.Show("Image file not found: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            ' Increment top offset for next set of controls
            topOffset += 120
        Next
    End Sub
End Class
