Imports System.IO

Public Class Display_Services
    ' Define the service provider class
    Private Class ServiceProvider
        Public Property Name As String
        Public Property Description As String
        Public Property Cost As String
        Public Property ServiceName As String
        Public Property Ratings As Integer
    End Class

    ' List to store service providers
    Private serviceProviders As New List(Of ServiceProvider)()

    Private Sub Display_Services_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate the serviceProviders list with query from DB
        ' Sample data for demonstration purposes
        serviceProviders.Add(New ServiceProvider() With {.Name = "Electrician", .Description = "Expert in electrical repairs", .Cost = "5000", .ServiceName = "Electrical Services", .Ratings = 4})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Plumber", .Description = "Experienced in plumbing works", .Cost = "6000", .ServiceName = "Plumbing Services", .Ratings = 4})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Gardener", .Description = "Provides garden maintenance services", .Cost = "5500", .ServiceName = "Gardening Services", .Ratings = 3})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Cleaner", .Description = "Offers professional cleaning services", .Cost = "8000", .ServiceName = "Cleaning Services", .Ratings = 5})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Painter", .Description = "Specializes in interior and exterior painting", .Cost = "9000", .ServiceName = "Painting Services", .Ratings = 4})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Carpenter", .Description = "Skilled in carpentry and woodworking", .Cost = "8500", .ServiceName = "Carpentry Services", .Ratings = 3})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Mover", .Description = "Offers moving and relocation services", .Cost = "7500", .ServiceName = "Moving Services", .Ratings = 4})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Tutor", .Description = "Provides tutoring services for various subjects", .Cost = "6500", .ServiceName = "Tutoring Services", .Ratings = 4})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Electrician", .Description = "Expert in electrical repairs and installation", .Cost = "7000", .ServiceName = "Electrical Services", .Ratings = 4})
        serviceProviders.Add(New ServiceProvider() With {.Name = "Plumber", .Description = "Offers plumbing solutions for households and businesses", .Cost = "6500", .ServiceName = "Plumbing Services", .Ratings = 3})

        ' Display the default data
        DisplayDefault()
    End Sub

    ' Method to display default view
    Private Sub DisplayDefault()
        Dim lblMostTrustedHeading As New Label()
        lblMostTrustedHeading.Text = "Most Trusted Service Providers"
        lblMostTrustedHeading.Font = New Font("Bahnschrift Light", 14, FontStyle.Bold)
        lblMostTrustedHeading.AutoSize = True
        lblMostTrustedHeading.Location = New Point(40, 30)
        Me.Controls.Add(lblMostTrustedHeading)

        Dim lblPopularHeading As New Label()
        lblPopularHeading.Text = "Popular Services"
        lblPopularHeading.Font = New Font("Bahnschrift Light", 14, FontStyle.Bold)
        lblPopularHeading.AutoSize = True
        lblPopularHeading.Location = New Point(40, 300)
        Me.Controls.Add(lblPopularHeading)

        Dim startX As Integer = 60 ' Starting X position for PictureBox and Label

        ' Display most trusted service providers
        For i As Integer = 0 To 3
            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(150, 150)
            pb.Location = New Point(startX + (i * 200) - 10, 80)
            ' Load sample image for service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            pb.Image = Image.FromFile(imagePath)
            Me.Controls.Add(pb)

            Dim lblProvider As New Label()
            lblProvider.Text = serviceProviders(i).Name
            lblProvider.AutoSize = True
            lblProvider.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
            lblProvider.Location = New Point(startX + (i * 200) + 20, 235)
            Me.Controls.Add(lblProvider)
        Next

        ' Display popular services
        For i As Integer = 0 To 3
            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(150, 150)
            pb.Location = New Point(startX + (i * 200) - 10, 350)
            ' Load sample image for service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            pb.Image = Image.FromFile(imagePath)
            Me.Controls.Add(pb)

            Dim lblProvider As New Label()
            lblProvider.Text = serviceProviders(i).ServiceName
            lblProvider.AutoSize = True
            lblProvider.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
            lblProvider.Location = New Point(startX + (i * 200), 505)
            Me.Controls.Add(lblProvider)
        Next
    End Sub

    ' Method to update services based on search criteria
    Public Sub UpdateServices(searchCriteria As String, minCostCriteria As String, maxCostCriteria As String)
        ' Clear existing controls from the form
        Me.Controls.Clear()

        ' Convert min and max cost criteria to integers
        Dim minCost As Integer
        Dim maxCost As Integer
        Integer.TryParse(minCostCriteria, minCost)
        Integer.TryParse(maxCostCriteria, maxCost)

        ' Check if the search criteria is empty
        If String.IsNullOrWhiteSpace(searchCriteria) Then
            ' Load the default view
            DisplayDefault()
            ' Show a "No results" popup
            MessageBox.Show("Please enter a search criteria.", "No results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Filter service providers based on search criteria and cost criteria
            Dim filteredProviders = serviceProviders.Where(Function(provider) _
            (provider.Name.ToLower().Contains(searchCriteria.ToLower()) Or
            provider.Description.ToLower().Contains(searchCriteria.ToLower()) Or
            provider.ServiceName.ToLower().Contains(searchCriteria.ToLower())) And
            (Integer.TryParse(provider.Cost, Nothing) AndAlso
            (String.IsNullOrWhiteSpace(minCostCriteria) OrElse Integer.Parse(provider.Cost) >= minCost) AndAlso
            (String.IsNullOrWhiteSpace(maxCostCriteria) OrElse Integer.Parse(provider.Cost) <= maxCost))
        ).ToList()

            ' Check if there are any results
            If filteredProviders.Count = 0 Then
                ' Load the default view
                DisplayDefault()
                ' Show a "No results" popup
                MessageBox.Show("No results found for the search criteria.", "No results", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Display the filtered service providers
                DisplaySearchResults(filteredProviders)
            End If
        End If
    End Sub


    ' Method to display search results
    Private Sub DisplaySearchResults(providers As List(Of ServiceProvider))
        Dim flowLayoutPanel As New FlowLayoutPanel()
        flowLayoutPanel.FlowDirection = FlowDirection.TopDown
        flowLayoutPanel.AutoScroll = True
        flowLayoutPanel.WrapContents = False
        flowLayoutPanel.Dock = DockStyle.Fill

        For Each provider In providers
            Dim resultPanel As New Panel()
            resultPanel.Size = New Size(600, 150)
            resultPanel.Margin = New Padding(10)
            resultPanel.BackColor = Color.LightGray
            resultPanel.BorderStyle = BorderStyle.FixedSingle

            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(100, 100)
            ' Load sample image for service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            pb.Image = Image.FromFile(imagePath)
            pb.Location = New Point(10, 25)
            resultPanel.Controls.Add(pb)

            Dim nameLabel As New Label()
            nameLabel.Text = "Name: " & provider.Name
            nameLabel.AutoSize = True
            nameLabel.Location = New Point(130, 10)
            resultPanel.Controls.Add(nameLabel)

            Dim costLabel As New Label()
            costLabel.Text = "Cost: " & provider.Cost
            costLabel.AutoSize = True
            costLabel.Location = New Point(130, 30)
            resultPanel.Controls.Add(costLabel)

            Dim serviceNameLabel As New Label()
            serviceNameLabel.Text = "Service Name: " & provider.ServiceName
            serviceNameLabel.AutoSize = True
            serviceNameLabel.Location = New Point(130, 50)
            resultPanel.Controls.Add(serviceNameLabel)

            Dim descriptionLabel As New Label()
            descriptionLabel.Text = "Description: " & provider.Description
            descriptionLabel.AutoSize = True
            descriptionLabel.Location = New Point(130, 70)
            resultPanel.Controls.Add(descriptionLabel)

            flowLayoutPanel.Controls.Add(resultPanel)
        Next

        Me.Controls.Add(flowLayoutPanel)
    End Sub
End Class
