Imports System.IO

Public Class Display_Services
    ' Define the service provider class
    Public Class ServiceProvider
        Public Property Name As String
        Public Property Description As String
        Public Property Price As String
        Public Property ServiceTypeID As String
        Public Property ServiceName As String
        Public Property ServiceDescription As String
        Public Property Ratings As Integer
        Public Property Experience As Integer
        Public Property Location As String
        Public Property TimeSlots As String
        Public Property count As Integer

    End Class

    ' List to store service providers
    Private serviceProviders As New List(Of ServiceProvider)()

    ' Variable to keep track of the current index of services being displayed for each section
    Private currentIndexMostTrusted As Integer = 0
    Private currentIndexPopular As Integer = 0

    Private Sub Display_Services_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure the form
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(841, 635)

        currentIndexMostTrusted = 0
        currentIndexPopular = 0
        Dim query As String = "SELECT s.serviceProviderName, s.ServiceProviderdescription, se.serviceDescription, s.rating, se.serviceTypeID, se.price, se.areaID, se.serviceName, COUNT(a.serviceID) AS count " &
                      "FROM serviceproviders AS s " &
                      "INNER JOIN services AS se ON s.serviceProviderID = se.serviceProviderID " &
                      "LEFT JOIN appointments AS a ON se.serviceID = a.serviceID " &
                      "GROUP BY s.serviceProviderName, s.ServiceProviderdescription, s.rating, se.serviceTypeID, se.price, se.areaID, se.serviceName"

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
                           .ServiceDescription = reader("serviceDescription").ToString(),
                           .ServiceTypeID = reader("serviceTypeID").ToString(),
                           .Price = reader("price").ToString(),
                           .Location = reader("areaID").ToString(),
                           .Experience = Convert.ToInt32(reader("rating")),
                           .count = Convert.ToInt32(reader("count"))
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

    Private pbMostTrusted As New List(Of PictureBox)()
    Private lblMostTrustedServiceName As New List(Of Label)()
    Private lblMostTrustedRating As New List(Of Label)()

    Private pbPopular As New List(Of PictureBox)()
    Private lblPopularServiceName As New List(Of Label)()
    Private lblPopularRating As New List(Of Label)()

    ' Method to display default view
    Private Sub DisplayDefault()
        Dim lblMostTrustedHeading As New Label()
        lblMostTrustedHeading.Text = "Most Trusted Service Providers"
        lblMostTrustedHeading.Font = New Font(SessionManager.font_family, 14, FontStyle.Bold)
        lblMostTrustedHeading.Size = New Size(360, 28)
        lblMostTrustedHeading.Location = New Point(91, 118)
        Me.Controls.Add(lblMostTrustedHeading)
        Dim sortedProviders = serviceProviders.OrderByDescending(Function(provider) provider.Ratings) _
                                      .ThenByDescending(Function(provider) provider.Experience) _
                                      .ToList()

        For i As Integer = 1 To 3
            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(169, 157)
            pb.Location = New Point(108 + ((i - 1) * (32 + 169)), 155)
            ' Load sample image for service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            pb.Image = Image.FromFile(imagePath)
            Me.Controls.Add(pb)
            pbMostTrusted.Add(pb)

            Dim lblProvider As New Label()
            lblProvider.Size = New Size(92, 18)
            lblProvider.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProvider.Location = New Point(146 + ((i - 1) * (110 + 92)) + 20, 320)
            lblProvider.Text = sortedProviders(i - 1).Name

            Me.Controls.Add(lblProvider)
            lblMostTrustedServiceName.Add(lblProvider)

            ' Update labels
            Dim lblProviderRating As New Label()
            lblProviderRating.Size = New Size(92, 18)
            lblProviderRating.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProviderRating.Location = New Point(146 + ((i - 1) * (110 + 92)) + 20, 340)
            lblProviderRating.Text = "Rating : " & sortedProviders(i - 1).Ratings

            Me.Controls.Add(lblProviderRating)
            lblMostTrustedRating.Add(lblProviderRating)
        Next

        Dim lblPopularHeading As New Label()
        lblPopularHeading.Text = "Trending Services"
        lblPopularHeading.Font = New Font(SessionManager.font_family, 14, FontStyle.Bold)
        lblPopularHeading.Size = New Size(280, 28)
        lblPopularHeading.Location = New Point(91, 371)
        Me.Controls.Add(lblPopularHeading)
        Dim sortedProviders_popular = serviceProviders.OrderByDescending(Function(provider) provider.count) _
                                  .ToList()

        ' Create picture boxes and labels for Popular section
        For i As Integer = 1 To 3
            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(169, 157)
            pb.Location = New Point(108 + ((i - 1) * (32 + 169)), 408)
            ' Load sample image for service provider
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            pb.Image = Image.FromFile(imagePath)
            Me.Controls.Add(pb)
            pbPopular.Add(pb)

            Dim lblProvider As New Label()
            lblProvider.Size = New Size(92, 18)
            lblProvider.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProvider.Location = New Point(146 + ((i - 1) * (110 + 92)) + 20, 574)
            lblProvider.Text = sortedProviders_popular(i - 1).ServiceName
            Me.Controls.Add(lblProvider)
            lblPopularServiceName.Add(lblProvider)

            ' Update labels
            Dim lblProviderRating As New Label()
            lblProviderRating.Size = New Size(92, 14)
            lblProviderRating.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProviderRating.Location = New Point(146 + ((i - 1) * (110 + 92)) + 20, 594)
            lblProviderRating.Text = "Rating : " & sortedProviders_popular(i - 1).Ratings
            Me.Controls.Add(lblProviderRating)
            lblPopularRating.Add(lblProviderRating)
        Next

        ' Display next and previous buttons for most trusted providers
        Dim btnNextMostTrusted As New Button()
        With btnNextMostTrusted
            .Text = "▶" ' Unicode character for right-pointing triangle
            .Size = New Size(30, 60)
            .Location = New Point(700, 195)
            .BackColor = ColorTranslator.FromHtml("#124E55")
            .ForeColor = Color.White
            .Font = New Font(btnNextMostTrusted.Font.FontFamily, 11) ' Increase font size to 12

            AddHandler .Click, AddressOf BtnNextMostTrusted_Click
            AddHandler .MouseEnter, Sub() .BackColor = ColorTranslator.FromHtml("#F9754B")
            AddHandler .MouseLeave, Sub() .BackColor = ColorTranslator.FromHtml("#124E55")
        End With
        'Me.Controls.Add(btnNextMostTrusted)

        Dim btnPrevMostTrusted As New Button()
        With btnPrevMostTrusted
            .Text = "◀" ' Unicode character for left-pointing triangle
            .Size = New Size(30, 60)
            .Location = New Point(60, 195)
            .BackColor = ColorTranslator.FromHtml("#124E55")
            .ForeColor = Color.White
            .Font = New Font(btnNextMostTrusted.Font.FontFamily, 11) ' Increase font size to 12

            AddHandler .Click, AddressOf BtnPrevMostTrusted_Click
            AddHandler .MouseEnter, Sub() .BackColor = ColorTranslator.FromHtml("#F9754B")
            AddHandler .MouseLeave, Sub() .BackColor = ColorTranslator.FromHtml("#124E55")
        End With
        'Me.Controls.Add(btnPrevMostTrusted)

        ' Display next and previous buttons for popular services
        Dim btnNextPopular As New Button()
        With btnNextPopular
            .Text = "▶" ' Unicode character for right-pointing triangle
            .Size = New Size(30, 60)
            .Location = New Point(700, 438)
            .BackColor = ColorTranslator.FromHtml("#124E55")
            .ForeColor = Color.White
            .Font = New Font(btnNextMostTrusted.Font.FontFamily, 11) ' Increase font size to 12

            AddHandler .Click, AddressOf BtnNextPopular_Click
            AddHandler .MouseEnter, Sub() .BackColor = ColorTranslator.FromHtml("#F9754B")
            AddHandler .MouseLeave, Sub() .BackColor = ColorTranslator.FromHtml("#124E55")
        End With
        'Me.Controls.Add(btnNextPopular)

        Dim btnPrevPopular As New Button()
        With btnPrevPopular
            .Text = "◀" ' Unicode character for left-pointing triangle
            .Size = New Size(30, 60)
            .Location = New Point(60, 438)
            .BackColor = ColorTranslator.FromHtml("#124E55")
            .ForeColor = Color.White
            .Font = New Font(btnNextMostTrusted.Font.FontFamily, 11) ' Increase font size to 12

            AddHandler .Click, AddressOf BtnPrevPopular_Click
            AddHandler .MouseEnter, Sub() .BackColor = ColorTranslator.FromHtml("#F9754B")
            AddHandler .MouseLeave, Sub() .BackColor = ColorTranslator.FromHtml("#124E55")
        End With
        'Me.Controls.Add(btnPrevPopular)

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

        ' Convert min and max rating criteria to integers
        Dim minRatingValue As Integer = Math.Max(0, Math.Min(5, minRating))
        Dim maxRatingValue As Integer = Math.Max(0, Math.Min(5, maxRating))

        ' Print filter inputs for debugging
        MessageBox.Show("Search Criteria: " & searchCriteria & vbCrLf &
                    "Minimum Cost Criteria: " & minCostCriteria & vbCrLf &
                    "Maximum Cost Criteria: " & maxCostCriteria & vbCrLf &
                    "Minimum Rating Criteria: " & minRating & vbCrLf &
                    "Maximum Rating Criteria: " & maxRating & vbCrLf &
                    "Location Criteria: " & locationCriteria & vbCrLf &
                    "Selected Service Types: " & String.Join(", ", selectedServiceTypes),
                    "Filter Inputs",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information)

        ' Filter service providers based on search criteria, cost criteria, rating criteria, and selected service types
        Dim filteredProviders = serviceProviders.Where(Function(provider) _
        (String.IsNullOrWhiteSpace(searchCriteria) OrElse
        provider.Name.ToLower().Contains(searchCriteria.ToLower()) Or
        provider.Description.ToLower().Contains(searchCriteria.ToLower()) Or
        provider.ServiceName.ToLower().Contains(searchCriteria.ToLower()) Or
        provider.ServiceDescription.ToLower().Contains(searchCriteria.ToLower())) AndAlso
        (String.IsNullOrWhiteSpace(minCostCriteria) OrElse Integer.TryParse(provider.Price, Nothing) AndAlso Integer.Parse(provider.Price) >= minCost) AndAlso
        (String.IsNullOrWhiteSpace(maxCostCriteria) OrElse Integer.TryParse(provider.Price, Nothing) AndAlso Integer.Parse(provider.Price) <= maxCost) AndAlso
        (provider.Ratings >= minRatingValue AndAlso provider.Ratings <= maxRatingValue) AndAlso
        (String.IsNullOrWhiteSpace(locationCriteria) OrElse provider.Location.ToLower() = locationCriteria.ToLower()) AndAlso
        (selectedServiceTypes.Count = 0 OrElse selectedServiceTypes.Any(Function(serviceType) provider.ServiceTypeID.ToLower().Contains(serviceType.ToLower())))
    ).ToList()

        ' Check if there are any results
        If filteredProviders.Count = 0 Then
            ' Load the default view
            DisplayDefault()
            ' Show a "No results" popup
            MessageBox.Show("No results found for the search criteria.", "No results", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Display the filtered service providers
            DisplaySearchResults(filteredProviders, minRatingValue, maxRatingValue)
        End If
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
            serviceNameLabel.Text = provider.ServiceName
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
    Private Sub UpdateMostTrustedPictureBoxesAndLabels()
        Dim sortedProviders = serviceProviders.OrderByDescending(Function(provider) provider.Ratings) _
                                  .ThenByDescending(Function(provider) provider.Experience) _
                                  .ToList()

        ' Update picture boxes and labels for Most Trusted section
        For i As Integer = 0 To 2
            Dim index As Integer = i + currentIndexMostTrusted
            If index < sortedProviders.Count Then
                Dim pb As PictureBox = pbMostTrusted(i)
                Dim lblProvider As Label = lblMostTrustedServiceName(i)
                Dim lblProviderRating As Label = lblMostTrustedRating(i)

                ' Update picture box
                ' Load sample image for service provider
                Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
                pb.Image = Image.FromFile(imagePath)

                ' Update labels
                lblProvider.Text = sortedProviders(index).ServiceName
                lblProviderRating.Text = "Rating : " & sortedProviders(index).Ratings
            Else
                ' If index is out of bounds, clear the picture box and labels
                pbMostTrusted(i).Image = Nothing
                lblMostTrustedServiceName(i).Text = ""
                lblMostTrustedRating(i).Text = ""
            End If
        Next
    End Sub

    Private Sub UpdatePopularPictureBoxesAndLabels()
        Dim sortedProviders_popular = serviceProviders.OrderByDescending(Function(provider) provider.count) _
                                  .ToList()
        ' Update picture boxes and labels for Popular section
        For i As Integer = 0 To 2
            Dim index As Integer = i + currentIndexPopular
            If index < serviceProviders.Count Then
                Dim pb As PictureBox = pbPopular(i)
                Dim lblProvider As Label = lblPopularServiceName(i)
                Dim lblProviderRating As Label = lblPopularRating(i)

                ' Update picture box
                ' Load sample image for service provider
                Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
                pb.Image = Image.FromFile(imagePath)

                ' Update labels
                lblProvider.Text = sortedProviders_popular(index).ServiceName
                lblProviderRating.Text = "Rating : " & sortedProviders_popular(index).Ratings
            Else
                ' If index is out of bounds, clear the picture box and labels
                pbPopular(i).Image = Nothing
                lblPopularServiceName(i).Text = ""
                lblPopularRating(i).Text = ""
            End If
        Next
    End Sub


    Private Sub BtnNextMostTrusted_Click(sender As Object, e As EventArgs)
        ' Increment the current index for most trusted providers
        currentIndexMostTrusted += 3
        ' Ensure currentIndexMostTrusted does not exceed the maximum index
        If currentIndexMostTrusted >= serviceProviders.Count Then
            currentIndexMostTrusted = serviceProviders.Count - 3
        End If
        ' Update picture boxes and labels for Most Trusted section
        UpdateMostTrustedPictureBoxesAndLabels()
    End Sub

    Private Sub BtnPrevMostTrusted_Click(sender As Object, e As EventArgs)
        ' Decrement the current index for most trusted providers
        currentIndexMostTrusted -= 3
        ' Ensure currentIndexMostTrusted does not go below 0
        If currentIndexMostTrusted < 0 Then
            currentIndexMostTrusted = 0
        End If
        ' Update picture boxes and labels for Most Trusted section
        UpdateMostTrustedPictureBoxesAndLabels()
    End Sub

    Private Sub BtnNextPopular_Click(sender As Object, e As EventArgs)
        ' Increment the current index for popular services
        currentIndexPopular += 3
        ' Ensure currentIndexPopular does not exceed the maximum index
        If currentIndexPopular >= serviceProviders.Count Then
            currentIndexPopular = serviceProviders.Count - 3
        End If
        ' Update picture boxes and labels for Popular section
        UpdatePopularPictureBoxesAndLabels()
    End Sub

    Private Sub BtnPrevPopular_Click(sender As Object, e As EventArgs)
        ' Decrement the current index for popular services
        currentIndexPopular -= 3
        ' Ensure currentIndexPopular does not go below 0
        If currentIndexPopular < 0 Then
            currentIndexPopular = 0
        End If
        ' Update picture boxes and labels for Popular section
        UpdatePopularPictureBoxesAndLabels()
    End Sub
End Class
