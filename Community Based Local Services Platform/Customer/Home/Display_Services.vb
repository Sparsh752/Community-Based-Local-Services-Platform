Imports System.IO

Public Class Display_Services
    ' Define the service provider class
    Public Class ServiceProvider
        Public Property Name As String
        Public Property Description As String
        Public Property Price As String
        Public Property ServiceTypeID As String
        Public Property ServiceName As String
        Public Property Ratings As Integer
        Public Property Experience As Integer
        Public Property Location As String
        Public Property TimeSlots As String
    End Class

    ' List to store service providers
    Private serviceProviders As New List(Of ServiceProvider)()

    Private Sub Display_Services_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure the form
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(841, 635)

        Dim query As String = "SELECT s.serviceProviderName, s.ServiceProviderdescription, s.rating, se.serviceTypeID, se.price, se.areaID, se.serviceName " &
                          "FROM serviceproviders AS s " &
                          "INNER JOIN services AS se ON s.serviceProviderID = se.serviceProviderID "

        ' Create a new SQL connection
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()

            ' Create a new SQL command
            Using command As New MySqlCommand(query, connection)
                ' Set the parameter value for UserID
                command.Parameters.AddWithValue("@UserID", SessionManager.userID)

                ' Execute the SQL command and create a data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Create a list to hold the labels data
                    Dim labels As New List(Of String)()

                    ' Read data from the reader
                    While reader.Read()
                        Dim serviceProvider As New ServiceProvider() With {
                           .Name = reader("serviceProviderName").ToString(),
                           .Description = reader("ServiceProviderdescription").ToString(),
                           .Ratings = Convert.ToInt32(reader("rating")),
                           .ServiceName = reader("serviceName").ToString(),
                           .ServiceTypeID = reader("serviceTypeID").ToString(),
                           .Price = reader("price").ToString(),
                           .Location = reader("areaID").ToString(),
                           .Experience = Convert.ToInt32(reader("rating"))
                       }
                        ' Add the service provider to the list
                        serviceProviders.Add(serviceProvider)
                    End While

                End Using
            End Using
        End Using
        ' Display the default data
        DisplayDefault()
    End Sub


    ' Method to display default view
    Private Sub DisplayDefault()
        Dim lblMostTrustedHeading As New Label()
        lblMostTrustedHeading.Text = "Most Trusted Service Providers"
        lblMostTrustedHeading.Font = New Font(SessionManager.font_family, 14, FontStyle.Bold)
        lblMostTrustedHeading.Size = New Size(360, 28)
        lblMostTrustedHeading.Location = New Point(71, 118)
        Me.Controls.Add(lblMostTrustedHeading)
        Dim sortedProviders = serviceProviders.OrderByDescending(Function(provider) provider.Ratings) _
                                      .ThenByDescending(Function(provider) provider.Experience) _
                                      .ToList()
        Dim lblPopularHeading As New Label()
        lblPopularHeading.Text = "Trending Services"
        lblPopularHeading.Font = New Font(SessionManager.font_family, 14, FontStyle.Bold)
        lblPopularHeading.Size = New Size(280, 28)
        lblPopularHeading.Location = New Point(71, 371)
        Me.Controls.Add(lblPopularHeading)

        ' Display most trusted service providers
        For i As Integer = 0 To Math.Min(2, sortedProviders.Count - 1)
            Dim pb As New PictureBox()
            pb.Tag = sortedProviders(i) ' Store ServiceProvider object in Tag property
            AddHandler pb.Click, AddressOf Navbar_Customer.PictureBox_Click

            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(169, 157)
            pb.Location = New Point(68 + (i * (32 + 169)), 155)
            ' Load sample image for service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            pb.Image = Image.FromFile(imagePath)
            Me.Controls.Add(pb)

            Dim lblProvider As New Label()
            lblProvider.Text = sortedProviders(i).Name
            lblProvider.Tag = sortedProviders(i) ' Store ServiceProvider object in Tag property
            lblProvider.Size = New Size(92, 14)
            lblProvider.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProvider.Location = New Point(106 + (i * (110 + 92)) + 20, 320)
            AddHandler lblProvider.Click, AddressOf Navbar_Customer.Label_Click

            Dim lblProvider1 As New Label()
            lblProvider1.Text = "Rating : " & sortedProviders(i).Ratings
            lblProvider1.Size = New Size(92, 18)
            lblProvider1.Tag = sortedProviders(i) ' Store ServiceProvider object in Tag property
            lblProvider1.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProvider1.Location = New Point(106 + (i * (110 + 92)) + 20, 340)
            AddHandler lblProvider1.Click, AddressOf Navbar_Customer.Label_Click
            Me.Controls.Add(lblProvider)
            Me.Controls.Add(lblProvider1)

        Next

        ' Display popular services
        For i As Integer = 0 To 2
            Dim pb As New PictureBox()
            pb.Tag = serviceProviders(i) ' Store ServiceProvider object in Tag property
            AddHandler pb.Click, AddressOf Navbar_Customer.PictureBox_Click
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(169, 157)
            pb.Location = New Point(68 + (i * (32 + 169)), 408)
            ' Load sample image for service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            pb.Image = Image.FromFile(imagePath)
            Me.Controls.Add(pb)

            Dim lblProvider As New Label()
            lblProvider.Text = serviceProviders(i).Name
            lblProvider.Size = New Size(92, 18)
            lblProvider.Tag = serviceProviders(i) ' Store ServiceProvider object in Tag property
            lblProvider.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProvider.Location = New Point(106 + (i * (110 + 92)) + 20, 574)
            AddHandler lblProvider.Click, AddressOf Navbar_Customer.Label_Click

            Dim lblProvider1 As New Label()
            lblProvider1.Text = "Rating : " & serviceProviders(i).Ratings
            lblProvider1.Size = New Size(92, 14)
            lblProvider1.Tag = serviceProviders(i) ' Store ServiceProvider object in Tag property
            lblProvider1.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProvider1.Location = New Point(106 + (i * (110 + 92)) + 20, 594)
            AddHandler lblProvider1.Click, AddressOf Navbar_Customer.Label_Click

            Me.Controls.Add(lblProvider)
            Me.Controls.Add(lblProvider1)


        Next
    End Sub

    ' Method to update services based on search criteria
    Public Sub UpdateServices(searchCriteria As String, minCostCriteria As String, maxCostCriteria As String, minRating As Integer, maxRating As Integer, locationCriteria As String, selectedServiceTypes As List(Of String))
        ' Clear existing controls from the form
        Me.Controls.Clear()

        ' Convert min and max cost criteria to integers
        Dim minCost As Integer
        Dim maxCost As Integer
        Integer.TryParse(minCostCriteria, minCost)
        Integer.TryParse(maxCostCriteria, maxCost)

        ' Check if the search criteria is empty
        ' If String.IsNullOrWhiteSpace(searchCriteria) Then
        ' Load the default view
        ' DisplayDefault()
        ' Show a "No results" popup
        ' MessageBox.Show("Please enter a search criteria.", "No results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Else
        ' Filter service providers based on search criteria, cost criteria, rating criteria, and selected service types
        Dim filteredProviders = serviceProviders.Where(Function(provider) _
        (provider.Name.ToLower().Contains(searchCriteria.ToLower()) Or
        provider.Description.ToLower().Contains(searchCriteria.ToLower())) AndAlso
        (String.IsNullOrWhiteSpace(minCostCriteria) OrElse Integer.TryParse(provider.Price, Nothing) AndAlso Integer.Parse(provider.Price) >= minCost) AndAlso
        (String.IsNullOrWhiteSpace(maxCostCriteria) OrElse Integer.TryParse(provider.Price, Nothing) AndAlso Integer.Parse(provider.Price) <= maxCost) AndAlso
        provider.Ratings >= minRating AndAlso provider.Ratings <= maxRating AndAlso
        (String.IsNullOrWhiteSpace(locationCriteria) OrElse provider.Location.ToLower() = locationCriteria.ToLower()) AndAlso
        (selectedServiceTypes.Count = 0 OrElse selectedServiceTypes.Any(Function(serviceType) provider.ServiceName.ToLower().Contains(serviceType.ToLower())))
        ).ToList()

        ' Check if there are any results
        If filteredProviders.Count = 0 Then
            ' Load the default view
            DisplayDefault()
            ' Show a "No results" popup
            MessageBox.Show("No results found for the search criteria.", "No results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Display the filtered service providers
            DisplaySearchResults(filteredProviders, minRating, maxRating)
        End If
        ' End If
    End Sub

    ' Method to display search results
    Private Sub DisplaySearchResults(providers As List(Of ServiceProvider), minRating As Integer, maxRating As Integer)
        Me.AutoScroll = True
        Dim verticalGap As Integer = 26 ' Vertical gap between result panels

        Dim yPos As Integer = 101 ' Initial Y position of the result panels
        For Each provider In providers
            Dim resultPanel As New Panel()
            resultPanel.Size = New Size(734, 198)
            ' Set the position of the result panel
            resultPanel.Location = New Point(38, yPos)
            yPos += resultPanel.Height + verticalGap ' Update yPos for next result panel
            resultPanel.BorderStyle = BorderStyle.FixedSingle

            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(169, 157)
            ' Load sample image for service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            pb.Image = Image.FromFile(imagePath)
            pb.Location = New Point(21, 21)
            resultPanel.Controls.Add(pb)

            Dim nameLabel As New Label()
            nameLabel.Text = provider.Name
            nameLabel.Size = New Size(280, 28)
            nameLabel.Location = New Point(208, 22)
            nameLabel.Font = New Font(SessionManager.font_family, 13, FontStyle.Regular)
            resultPanel.Controls.Add(nameLabel)

            Dim serviceNameLabel As New Label()
            serviceNameLabel.Text = provider.Name
            serviceNameLabel.Size = New Size(280, 28)
            serviceNameLabel.Location = New Point(208, 50)
            serviceNameLabel.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
            resultPanel.Controls.Add(serviceNameLabel)

            Dim costLabel As New Label()
            costLabel.Text = "Rate : Rs. " & provider.Price
            costLabel.Size = New Size(280, 14)
            costLabel.Location = New Point(208, 76)
            costLabel.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
            resultPanel.Controls.Add(costLabel)

            Dim descriptionLabel As New Label()
            descriptionLabel.Text = provider.Description
            descriptionLabel.Size = New Size(490, 47)
            descriptionLabel.Location = New Point(208, 99)
            descriptionLabel.Font = New Font(SessionManager.font_family, 7, FontStyle.Regular)
            resultPanel.Controls.Add(descriptionLabel)

            Dim viewBtn As New Button()
            viewBtn.Text = "View Details"
            viewBtn.Size = New Size(107, 29)
            viewBtn.Location = New Point(451, 156)
            viewBtn.BackColor = Color.FromArgb(249, 117, 75)
            viewBtn.ForeColor = Color.White
            viewBtn.FlatStyle = FlatStyle.Flat
            viewBtn.FlatAppearance.BorderSize = 0
            ' Set the Tag property of the button to store the provider details
            viewBtn.Tag = provider
            ' Attach event handler for the button click
            AddHandler viewBtn.Click, AddressOf Navbar_Customer.ViewDetails_Click
            resultPanel.Controls.Add(viewBtn)

            Dim bookNowBtn As New Button()
            bookNowBtn.Text = "Book Now"
            bookNowBtn.Size = New Size(107, 29)
            bookNowBtn.Location = New Point(591, 156)
            bookNowBtn.BackColor = Color.FromArgb(249, 117, 75)
            bookNowBtn.ForeColor = Color.White
            bookNowBtn.FlatStyle = FlatStyle.Flat
            bookNowBtn.FlatAppearance.BorderSize = 0
            AddHandler bookNowBtn.Click, AddressOf BookNowButton_Click
            resultPanel.Controls.Add(bookNowBtn)

            Me.Controls.Add(resultPanel)
        Next
    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub BookNowButton_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()

        Dim str As String = "Proceed to Pay"
        Dim appointmentBookingForm As New Appointment_booking(str)

        With appointmentBookingForm
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(appointmentBookingForm)
            .BringToFront()
            .Show()
        End With

    End Sub

End Class
