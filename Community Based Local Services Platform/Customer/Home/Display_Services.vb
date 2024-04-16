Imports System.IO

Public Class Display_Services
    ' Define the service provider class
    Public Class ServiceProvider
        Public Property ID As String
        Public Property Name As String
        Public Property Description As String
        Public Property Price As Decimal
        Public Property ServiceID As String
        Public Property ServiceTypeID As Integer
        Public Property ServiceName As String
        Public Property ServiceDescription As String
        Public Property Ratings As Integer ' Changed to integer
        Public Property Experience As Integer
        Public Property Location As String
        Public Property TimeSlots As String
        Public Property Count As Integer
        Public Property ServiveProviderPhoto As Byte()
        Public Property ServicePhoto As Byte()
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
        Dim query As String = "SELECT s.serviceProviderID, s.serviceProviderName, s.ServiceProviderdescription, se.serviceDescription, s.rating, se.serviceID, se.serviceTypeID, se.price, se.areaID, se.serviceName, s.serviceProviderPhotos, s.experienceYears, se.servicePhoto, COUNT(a.serviceID) AS count " &
                      "FROM serviceproviders AS s " &
                      "INNER JOIN services AS se ON s.serviceProviderID = se.serviceProviderID " &
                      "LEFT JOIN appointments AS a ON se.serviceID = a.serviceID " &
                      "WHERE flagbit = 1 " &
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
                            .ID = reader("serviceProviderID").ToString(),
                            .Name = reader("serviceProviderName").ToString(),
                            .Description = reader("ServiceProviderdescription").ToString(),
                            .Ratings = CInt(Math.Floor(CDec(reader("rating")))), ' Convert to Integer using Floor
                            .ServiceName = reader("serviceName").ToString(),
                            .ServiceDescription = reader("serviceDescription").ToString(),
                            .ServiceTypeID = Convert.ToInt32(reader("serviceTypeID")),
                            .ServiceID = reader("serviceID").ToString(),
                            .Price = Convert.ToDecimal(reader("price")), ' Convert.ToDecimal is used to ensure the conversion to Decimal
                            .Location = reader("areaID").ToString(),
                            .Experience = reader("experienceYears"),
                            .Count = Convert.ToInt32(reader("count"))
                        }

                        ' Check if the serviceProviderPhotos column is DBNull
                        If Not IsDBNull(reader("serviceProviderPhotos")) Then
                            serviceProvider.ServiveProviderPhoto = DirectCast(reader("serviceProviderPhotos"), Byte())
                        End If

                        ' Check if the servicePhoto column is DBNull
                        If Not IsDBNull(reader("servicePhoto")) Then
                            serviceProvider.ServicePhoto = DirectCast(reader("servicePhoto"), Byte())
                        End If

                        ' Add the serviceProvider object to the list
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
        Dim sortedProviders = serviceProviders.GroupBy(Function(provider) provider.ID) _
                                          .Select(Function(group) group.First()) _
                                          .OrderByDescending(Function(provider) provider.Ratings) _
                                          .ThenByDescending(Function(provider) provider.Experience) _
                                          .Take(9) _
                                          .ToList()


        For i As Integer = 1 To 3
            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(169, 157)
            pb.Location = New Point(108 + ((i - 1) * (32 + 169)), 155)

            ' Load image from binary data
            If sortedProviders(i - 1).ServiveProviderPhoto IsNot Nothing AndAlso sortedProviders(i - 1).ServiveProviderPhoto.Length > 0 Then
                Using ms As New MemoryStream(sortedProviders(i - 1).ServiveProviderPhoto)
                    pb.Image = Image.FromStream(ms)
                End Using
            Else
                ' Handle the case where image data is not available or empty
                ' For example, load a default image
                Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
                pb.Image = Image.FromFile(imagePath)
            End If

            Me.Controls.Add(pb)


            ' Set the Tag property of the picturebox to store the provider details
            pb.Tag = sortedProviders(i - 1)
            ' Attach event handler for the picturebox click
            AddHandler pb.Click, AddressOf Navbar_Customer.PictureBox_Click
            pbMostTrusted.Add(pb)
            ' Inside the loop where you create picture boxes for most trusted section
            AddHandler pb.MouseHover, Sub(sender As Object, e As EventArgs)
                                          Dim index As Integer = pbMostTrusted.IndexOf(DirectCast(sender, PictureBox))
                                          If index <> -1 Then
                                              'pbMostTrusted(index).BackColor = Color.FromArgb(150, Color.Black) ' Set semi-transparent background color
                                              lblMostTrustedRating(index).Visible = True
                                              lblMostTrustedRating(index).BringToFront()

                                          End If
                                      End Sub

            AddHandler pb.MouseLeave, Sub(sender As Object, e As EventArgs)
                                          Dim index As Integer = pbMostTrusted.IndexOf(DirectCast(sender, PictureBox))
                                          If index <> -1 Then
                                              'pbMostTrusted(index).BackColor = Color.Transparent ' Restore transparent background color
                                              lblMostTrustedRating(index).Visible = False
                                          End If
                                      End Sub


            Dim lblProvider As New Label()
            lblProvider.Size = New Size(92, 18)
            lblProvider.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProvider.Location = New Point(146 + ((i - 1) * (110 + 92)) + 20, 320)
            lblProvider.Text = sortedProviders(i - 1).Name
            Me.Controls.Add(lblProvider)
            lblMostTrustedServiceName.Add(lblProvider)

            ' Create a label for stars
            Dim starsLabel As New Label()

            ' Calculate the number of full stars and empty stars
            Dim fullStars As Integer = sortedProviders(i - 1).Ratings
            Dim emptyStars As Integer = Math.Max(0, 5 - fullStars)

            ' Generate the text for full and empty stars
            Dim fullStarsText As String = New String("★"c, fullStars)
            Dim emptyStarsText As String = New String("☆"c, emptyStars)

            ' Combine full and empty stars text
            Dim combinedText As String = fullStarsText & emptyStarsText

            ' Update labels
            Dim lblProviderRating As New Label()
            lblProviderRating.Size = New Size(169, 20)
            lblProviderRating.Location = New Point(108 + ((i - 1) * (32 + 169)), 300)
            lblProviderRating.ForeColor = ColorTranslator.FromHtml("#124E55")
            lblProviderRating.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProviderRating.Text = "      Rating : " & combinedText
            lblProviderRating.Visible = False
            lblProviderRating.BringToFront() 

            Me.Controls.Add(lblProviderRating)
            lblMostTrustedRating.Add(lblProviderRating)
        Next

        Dim lblPopularHeading As New Label()
        lblPopularHeading.Text = "Trending Services"
        lblPopularHeading.Font = New Font(SessionManager.font_family, 14, FontStyle.Bold)
        lblPopularHeading.Size = New Size(280, 28)
        lblPopularHeading.Location = New Point(91, 371)
        Me.Controls.Add(lblPopularHeading)
        Dim sortedProviders_popular = serviceProviders.GroupBy(Function(provider) (provider.ID, provider.ServiceTypeID)).
                                                       Select(Function(group) group.First()).
                                                       OrderByDescending(Function(provider) provider.Count) _
                                                       .OrderByDescending(Function(provider) provider.Ratings) _
                                                       .Take(12) _
                                                      .ToList()

        ' Create picture boxes and labels for Popular section
        For i As Integer = 1 To 3
            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(169, 157)
            pb.Location = New Point(108 + ((i - 1) * (32 + 169)), 408)

            ' Load image from binary data
            If sortedProviders_popular(i - 1).ServicePhoto IsNot Nothing AndAlso sortedProviders_popular(i - 1).ServicePhoto.Length > 0 Then
                Using ms As New MemoryStream(sortedProviders_popular(i - 1).ServicePhoto)
                    pb.Image = Image.FromStream(ms)
                End Using
            Else
                ' Handle the case where image data is not available or empty
                Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
                pb.Image = Image.FromFile(imagePath)
            End If

            Me.Controls.Add(pb)

            ' Set the Tag property of the picturebox to store the provider details
            pb.Tag = sortedProviders_popular(i - 1)
            ' Attach event handler for the button click
            AddHandler pb.Click, AddressOf Navbar_Customer.PictureBox_Click
            pbPopular.Add(pb)
            AddHandler pb.MouseHover, Sub(sender As Object, e As EventArgs)
                                          Dim index As Integer = pbPopular.IndexOf(DirectCast(sender, PictureBox))
                                          If index <> -1 Then
                                              'pbPopular(index).BackColor = Color.FromArgb(150, Color.Black) ' Set semi-transparent background color
                                              lblPopularRating(index).Visible = True
                                              lblPopularRating(index).BringToFront()
                                          End If
                                      End Sub

            AddHandler pb.MouseLeave, Sub(sender As Object, e As EventArgs)
                                          Dim index As Integer = pbPopular.IndexOf(DirectCast(sender, PictureBox))
                                          If index <> -1 Then
                                              'pbPopular(index).BackColor = Color.Transparent ' Restore transparent background color
                                              lblPopularRating(index).Visible = False
                                          End If
                                      End Sub
            Dim lblProvider As New Label()
            lblProvider.Size = New Size(92, 18)
            lblProvider.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProvider.Location = New Point(146 + ((i - 1) * (110 + 92)) + 20, 574)
            lblProvider.Text = sortedProviders_popular(i - 1).ServiceName
            Me.Controls.Add(lblProvider)
            lblPopularServiceName.Add(lblProvider)

            ' Create a label for stars
            Dim starsLabel As New Label()

            ' Calculate the number of full stars and empty stars
            Dim fullStars As Integer = sortedProviders_popular(i - 1).Ratings
            Dim emptyStars As Integer = Math.Max(0, 5 - fullStars)

            ' Generate the text for full and empty stars
            Dim fullStarsText As String = New String("★"c, fullStars)
            Dim emptyStarsText As String = New String("☆"c, emptyStars)

            ' Combine full and empty stars text
            Dim combinedText As String = fullStarsText & emptyStarsText

            ' Update labels
            Dim lblProviderRating As New Label()
            lblProviderRating.Size = New Size(169, 20)
            lblProviderRating.Location = New Point(108 + ((i - 1) * (32 + 169)), 550)
            lblProviderRating.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            lblProviderRating.Text = "     Rating : " & combinedText
            lblProviderRating.Visible = False
            lblProviderRating.BringToFront()

            Me.Controls.Add(lblProviderRating)
            lblPopularRating.Add(lblProviderRating)
        Next

        ' Display next and previous buttons for most trusted providers
        Dim btnNextMostTrusted As New Button()
        With btnNextMostTrusted
            .Text = "▶" ' Unicode character for right-pointing triangle
            .Size = New Size(25, 60)
            .Location = New Point(700, 206)
            .BackColor = ColorTranslator.FromHtml("#124E55")
            .ForeColor = Color.White
            .Font = New Font(btnNextMostTrusted.Font.FontFamily, 11) ' Increase font size to 12
            .FlatStyle = FlatStyle.Flat

            AddHandler .Click, AddressOf BtnNextMostTrusted_Click
            AddHandler .MouseEnter, Sub() .BackColor = ColorTranslator.FromHtml("#F9754B")
            AddHandler .MouseLeave, Sub() .BackColor = ColorTranslator.FromHtml("#124E55")
        End With
        Me.Controls.Add(btnNextMostTrusted)

        Dim btnPrevMostTrusted As New Button()
        With btnPrevMostTrusted
            .Text = "◀" ' Unicode character for left-pointing triangle
            .Size = New Size(25, 60)
            .Location = New Point(60, 206)
            .BackColor = ColorTranslator.FromHtml("#124E55")
            .ForeColor = Color.White
            .Font = New Font(btnNextMostTrusted.Font.FontFamily, 11) ' Increase font size to 12
            .FlatStyle = FlatStyle.Flat

            AddHandler .Click, AddressOf BtnPrevMostTrusted_Click
            AddHandler .MouseEnter, Sub() .BackColor = ColorTranslator.FromHtml("#F9754B")
            AddHandler .MouseLeave, Sub() .BackColor = ColorTranslator.FromHtml("#124E55")
        End With
        Me.Controls.Add(btnPrevMostTrusted)

        ' Display next and previous buttons for popular services
        Dim btnNextPopular As New Button()
        With btnNextPopular
            .Text = "▶" ' Unicode character for right-pointing triangle
            .Size = New Size(25, 60)
            .Location = New Point(700, 449)
            .BackColor = ColorTranslator.FromHtml("#124E55")
            .ForeColor = Color.White
            .Font = New Font(btnNextMostTrusted.Font.FontFamily, 11) ' Increase font size to 12
            .FlatStyle = FlatStyle.Flat
            AddHandler .Click, AddressOf BtnNextPopular_Click
            AddHandler .MouseEnter, Sub() .BackColor = ColorTranslator.FromHtml("#F9754B")
            AddHandler .MouseLeave, Sub() .BackColor = ColorTranslator.FromHtml("#124E55")
        End With
        Me.Controls.Add(btnNextPopular)

        Dim btnPrevPopular As New Button()
        With btnPrevPopular
            .Text = "◀" ' Unicode character for left-pointing triangle
            .Size = New Size(25, 60)
            .Location = New Point(60, 449)
            .BackColor = ColorTranslator.FromHtml("#124E55")
            .ForeColor = Color.White
            .Font = New Font(btnNextMostTrusted.Font.FontFamily, 11) ' Increase font size to 12
            .FlatStyle = FlatStyle.Flat

            AddHandler .Click, AddressOf BtnPrevPopular_Click
            AddHandler .MouseEnter, Sub() .BackColor = ColorTranslator.FromHtml("#F9754B")
            AddHandler .MouseLeave, Sub() .BackColor = ColorTranslator.FromHtml("#124E55")
        End With
        Me.Controls.Add(btnPrevPopular)

    End Sub



    ' Method to update services based on search criteria
    Public Sub UpdateServices(searchCriteria As String, minCostCriteria As String, maxCostCriteria As String, minRating As Integer, maxRating As Integer, locationCriteria As String, selectedServiceTypes As List(Of String))
        ' Clear existing controls from the form
        Me.Controls.Clear()

        ' Convert min and max cost criteria to integers
        Dim minCost As Decimal
        Dim maxCost As Decimal

        ' Attempt to parse minCostCriteria
        If String.IsNullOrEmpty(minCostCriteria) Then
            minCost = 0D ' Default value
        ElseIf Decimal.TryParse(minCostCriteria, minCost) Then
            ' Parsing successful
        Else
            minCost = 0D ' Default value
        End If

        ' Attempt to parse maxCostCriteria
        If String.IsNullOrEmpty(maxCostCriteria) Then
            maxCost = Decimal.MaxValue ' Default value to represent maximum possible decimal value
        ElseIf Decimal.TryParse(maxCostCriteria, maxCost) Then
            ' Parsing successful
        Else
            maxCost = Decimal.MaxValue ' Default value to represent maximum possible decimal value
        End If

        ' Filter service providers based on search criteria, cost criteria, rating criteria, and selected service types
        Dim filteredProviders = serviceProviders.
            OrderByDescending(Function(provider) provider.Ratings).
        Where(Function(provider) _
            (String.IsNullOrWhiteSpace(searchCriteria) OrElse
            provider.Name.ToLower().Contains(searchCriteria.ToLower()) Or
            provider.ServiceName.ToLower().Contains(searchCriteria.ToLower()) Or
            provider.ServiceDescription.ToLower().Contains(searchCriteria.ToLower())) AndAlso
            (CInt(Math.Floor(provider.Ratings)) >= minRating AndAlso CInt(Math.Floor(provider.Ratings)) <= maxRating) AndAlso
            (String.IsNullOrWhiteSpace(minCostCriteria) OrElse
            Decimal.TryParse(minCostCriteria, Nothing) AndAlso provider.Price >= minCost) AndAlso
            (String.IsNullOrWhiteSpace(maxCostCriteria) OrElse
            Decimal.TryParse(maxCostCriteria, Nothing) AndAlso provider.Price <= maxCost) AndAlso
            (String.IsNullOrWhiteSpace(locationCriteria) OrElse provider.Location.ToLower() = locationCriteria.ToLower()) AndAlso
            (selectedServiceTypes.Count = 0 OrElse selectedServiceTypes.Any(Function(serviceType) provider.ServiceTypeID = Convert.ToInt32(serviceType)))
        ).
        GroupBy(Function(provider) (provider.ID, provider.ServiceTypeID)).
        Select(Function(group) group.First()).
        ToList()



        ' Print filter inputs for debugging
        ' MessageBox.Show("Search Criteria: " & searchCriteria & vbCrLf &
        '           "Minimum Cost Criteria: " & minCostCriteria & vbCrLf &
        '         "Maximum Cost Criteria: " & maxCostCriteria & vbCrLf &
        '       "Minimum Rating Criteria: " & minRating & vbCrLf &
        '     "Maximum Rating Criteria: " & maxRating & vbCrLf &
        '   "Location Criteria: " & locationCriteria & vbCrLf &
        ' "Selected Service Types: " & String.Join(", ", selectedServiceTypes) & vbCrLf &
        ' "Filter Inputs: " & filteredProviders.Count,
        ' "Filter Inputs",
        ' MessageBoxButtons.OK,
        ' MessageBoxIcon.Information)
        ' Check if there are any results
        If filteredProviders.Count = 0 Then
            ' Create and configure a PictureBox for displaying the image
            Dim noResultsPictureBox As New PictureBox()
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\no_search.png")
            Dim originalImage As Image = Image.FromFile(imagePath)
            Dim croppedImage As New Bitmap(originalImage, New Size(originalImage.Width - 10, originalImage.Height)) ' Crop 2 pixels from the left side
            noResultsPictureBox.Image = croppedImage
            noResultsPictureBox.SizeMode = PictureBoxSizeMode.AutoSize

            ' Position the PictureBox in the center of the form
            noResultsPictureBox.Location = New Point((Me.ClientSize.Width - noResultsPictureBox.Width) / 2, (Me.ClientSize.Height - noResultsPictureBox.Height) / 2)

            ' Add the PictureBox to the form
            Me.Controls.Add(noResultsPictureBox)
        Else
            ' Display the filtered service providers
            DisplaySearchResults(filteredProviders, minRating, maxRating)
        End If

    End Sub

    ' Method to display search results
    Private Sub DisplaySearchResults(providers As List(Of ServiceProvider), minRating As Integer, maxRating As Integer)
        Me.AutoScroll = True
        Dim verticalGap As Integer = 26 ' Vertical gap between result panels

        Dim yPos As Integer = 101 ' Initial Y position of the result panels

        Dim filteredCountLabel As New Label()
        filteredCountLabel.Text = "Filtered Search Count: " & providers.Count.ToString()
        filteredCountLabel.AutoSize = True
        filteredCountLabel.Location = New Point(38, 80) ' Adjust the X and Y coordinates as needed
        filteredCountLabel.Font = New Font(SessionManager.font_family, 12, FontStyle.Bold)
        Me.Controls.Add(filteredCountLabel) ' Add the label to the form

        For Each Provider In providers
            Dim resultPanel As New Panel()
            resultPanel.Size = New Size(734, 198)
            ' Set the position of the result panel
            resultPanel.Location = New Point(38, yPos)
            yPos += resultPanel.Height + verticalGap ' Update yPos for next result panel
            resultPanel.BorderStyle = BorderStyle.FixedSingle

            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(169, 157)
            ' Load image from binary data
            If Provider.ServicePhoto IsNot Nothing AndAlso Provider.ServicePhoto.Length > 0 Then
                Using ms As New MemoryStream(Provider.ServicePhoto)
                    pb.Image = Image.FromStream(ms)
                End Using
            Else
                ' Handle the case where image data is not available or empty
                Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
                pb.Image = Image.FromFile(imagePath)
            End If
            pb.Location = New Point(21, 21)
            resultPanel.Controls.Add(pb)

            Dim nameLabel As New Label()
            nameLabel.Text = Provider.Name
            nameLabel.Size = New Size(280, 28)
            nameLabel.Location = New Point(208, 22)
            nameLabel.Font = New Font(SessionManager.font_family, 13, FontStyle.Bold)
            resultPanel.Controls.Add(nameLabel)

            Dim serviceNameLabel As New Label()
            serviceNameLabel.Text = Provider.ServiceName
            serviceNameLabel.Size = New Size(280, 28)
            serviceNameLabel.Location = New Point(208, 50)
            serviceNameLabel.Font = New Font(SessionManager.font_family, 12, FontStyle.Regular)
            resultPanel.Controls.Add(serviceNameLabel)

            Dim costLabel As New Label()
            costLabel.Text = "Rate : Rs. " & Provider.Price
            costLabel.Size = New Size(280, 14)
            costLabel.Location = New Point(208, 76)
            costLabel.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
            resultPanel.Controls.Add(costLabel)

            ' Create a label for stars
            Dim starsLabel As New Label()

            ' Calculate the number of full stars and empty stars
            Dim fullStars As Integer = Provider.Ratings
            Dim emptyStars As Integer = Math.Max(0, 5 - Provider.Ratings)

            ' Generate the text for full and empty stars
            Dim fullStarsText As String = New String("★"c, fullStars)
            Dim emptyStarsText As String = New String("☆"c, emptyStars)

            ' Combine full and empty stars text
            Dim combinedText As String = fullStarsText & emptyStarsText

            ' Set text and properties for stars label
            starsLabel.Text = combinedText
            starsLabel.ForeColor = ColorTranslator.FromHtml("#124E55") ' Set color to yellow for full stars
            starsLabel.Font = New Font(SessionManager.font_family, 16, FontStyle.Regular)
            starsLabel.AutoSize = True ' Automatically adjust the size of the label
            starsLabel.Location = New Point(586, 70)

            ' Create label for "Rating"
            Dim ratingTextLabel As New Label()
            ratingTextLabel.Text = "Rating:"
            ratingTextLabel.Size = New Size(70, 20) ' Reduce the size of the label
            ratingTextLabel.Location = New Point(591, 55) ' Move further right
            ratingTextLabel.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular) ' Reduce the font size
            ratingTextLabel.ForeColor = Color.Black ' Set color to black

            ' Add all labels to the result panel
            resultPanel.Controls.Add(ratingTextLabel)
            resultPanel.Controls.Add(starsLabel)

            Dim descriptionLabel As New Label()
            descriptionLabel.Text = Provider.ServiceDescription
            descriptionLabel.Size = New Size(490, 47)
            descriptionLabel.Location = New Point(208, 110)
            descriptionLabel.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
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
            viewBtn.Tag = Provider
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
            ' Attach event handler for the button click
            AddHandler bookNowBtn.Click, Sub(s, ev) BookNowButton_Click(s, ev, Provider.ServiceID)
            resultPanel.Controls.Add(bookNowBtn)

            Me.Controls.Add(resultPanel)

        Next
    End Sub

    Private Sub RemovePreviousForm()
        For Each ctrl As Control In Panel3.Controls
            If TypeOf ctrl Is Form Then
                ' Remove the first control (form) from Panel5
                Dim formCtrl As Form = DirectCast(ctrl, Form)
                formCtrl.Close()
            End If
        Next
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If

    End Sub

    Private Sub BookNowButton_Click(sender As Object, e As EventArgs, serviceID As String)
        'RemovePreviousForm()

        Dim str As String = "Proceed to Pay"
        Dim appointmentBookingForm As New Appointment_booking(str, serviceID)

        With appointmentBookingForm
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(appointmentBookingForm)
            .BringToFront()
            .Show()
        End With

    End Sub
    Private Sub UpdateMostTrustedPictureBoxesAndLabels()
        Dim sortedProviders = serviceProviders.GroupBy(Function(provider) provider.ID) _
                                      .Select(Function(group) group.First()) _
                                      .OrderByDescending(Function(provider) provider.Ratings) _
                                      .ThenByDescending(Function(provider) provider.Experience) _
                                      .Take(9) _
                                      .ToList()

        ' Update picture boxes and labels for Most Trusted section
        For i As Integer = 0 To 2
            Dim index As Integer = i + currentIndexMostTrusted
            If index < sortedProviders.Count Then
                Dim pb As PictureBox = pbMostTrusted(i)
                Dim lblProvider As Label = lblMostTrustedServiceName(i)
                Dim lblProviderRating As Label = lblMostTrustedRating(i)

                If sortedProviders(index).ServiveProviderPhoto IsNot Nothing AndAlso sortedProviders(index).ServiveProviderPhoto.Length > 0 Then
                    Using ms As New MemoryStream(sortedProviders(index).ServiveProviderPhoto)
                        pb.Image = Image.FromStream(ms)
                    End Using
                Else
                    ' Handle the case where image data is not available or empty
                    ' For example, load a default image
                    Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
                    pb.Image = Image.FromFile(imagePath)
                End If
                pb.Tag = sortedProviders(index)
                lblProvider.Tag = sortedProviders(index)
                lblProviderRating.Tag = sortedProviders(index)
                ' Update labels
                lblProvider.Text = sortedProviders(index).Name

                ' Create a label for stars
                Dim starsLabel As New Label()

                ' Calculate the number of full stars and empty stars
                Dim fullStars As Integer = sortedProviders(index).Ratings
                Dim emptyStars As Integer = Math.Max(0, 5 - fullStars)

                ' Generate the text for full and empty stars
                Dim fullStarsText As String = New String("★"c, fullStars)
                Dim emptyStarsText As String = New String("☆"c, emptyStars)

                ' Combine full and empty stars text
                Dim combinedText As String = fullStarsText & emptyStarsText

                lblProviderRating.Text = "Rating : " & combinedText
            Else
                ' If index is out of bounds, clear the picture box and labels
                pbMostTrusted(i).Image = Nothing
                lblMostTrustedServiceName(i).Text = ""
                lblMostTrustedRating(i).Text = ""
            End If
        Next
    End Sub

    Private Sub UpdatePopularPictureBoxesAndLabels()
        Dim sortedProviders_popular = serviceProviders.GroupBy(Function(provider) (provider.ID, provider.ServiceTypeID)).
                                                   Select(Function(group) group.First()).
                                                   OrderByDescending(Function(provider) provider.Count) _
                                                   .OrderByDescending(Function(provider) provider.Ratings) _
                                                   .Take(12) _
                                                  .ToList()
        ' Update picture boxes and labels for Popular section
        For i As Integer = 0 To 2
            Dim index As Integer = i + currentIndexPopular
            If index < sortedProviders_popular.Count Then
                Dim pb As PictureBox = pbPopular(i)
                Dim lblProvider As Label = lblPopularServiceName(i)
                Dim lblProviderRating As Label = lblPopularRating(i)

                ' Update picture box
                ' Load image from binary data
                If sortedProviders_popular(index).ServicePhoto IsNot Nothing AndAlso sortedProviders_popular(index).ServicePhoto.Length > 0 Then
                    Using ms As New MemoryStream(sortedProviders_popular(index).ServicePhoto)
                        pb.Image = Image.FromStream(ms)
                    End Using
                Else
                    ' Handle the case where image data is not available or empty
                    Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
                    pb.Image = Image.FromFile(imagePath)
                End If
                pb.Tag = sortedProviders_popular(index)
                lblProvider.Tag = sortedProviders_popular(index)
                lblProviderRating.Tag = sortedProviders_popular(index)

                ' Update labels
                lblProvider.Text = sortedProviders_popular(index).ServiceName

                ' Create a label for stars
                Dim starsLabel As New Label()

                ' Calculate the number of full stars and empty stars
                Dim fullStars As Integer = sortedProviders_popular(index).Ratings
                Dim emptyStars As Integer = Math.Max(0, 5 - fullStars)

                ' Generate the text for full and empty stars
                Dim fullStarsText As String = New String("★"c, fullStars)
                Dim emptyStarsText As String = New String("☆"c, emptyStars)

                ' Combine full and empty stars text
                Dim combinedText As String = fullStarsText & emptyStarsText

                lblProviderRating.Text = "Rating : " & combinedText
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
        Dim sortedProviders = serviceProviders.GroupBy(Function(provider) provider.ID) _
                                  .Select(Function(group) group.First()) _
                                  .OrderByDescending(Function(provider) provider.Ratings) _
                                  .ThenByDescending(Function(provider) provider.Experience) _
                                  .Take(9) _
                                  .ToList()
        ' Ensure currentIndexMostTrusted does not exceed the maximum index
        If currentIndexMostTrusted >= sortedProviders.Count Then
            currentIndexMostTrusted -= 3
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
        Dim sortedProviders_popular = serviceProviders.GroupBy(Function(provider) (provider.ID, provider.ServiceTypeID)).
                                                       Select(Function(group) group.First()).
                                                       OrderByDescending(Function(provider) provider.Count) _
                                                      .Take(12) _
                                                      .ToList()
        ' Ensure currentIndexPopular does not exceed the maximum index
        If currentIndexPopular >= sortedProviders_popular.Count Then
            currentIndexPopular -= 3
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
