Imports System.IO
Imports Community_Based_Local_Services_Platform.Display_Services


Public Class SP_profile
    ' Constructor to receive and display details
    Dim serviceProviderID As String
    Dim userID As Integer
    Dim ratings As Integer
    Public Sub New(provider As ServiceProvider)
        InitializeComponent()

        ' Display the details received
        Label1.Text = provider.Name
        Label2.Text = provider.Location
        ratings = provider.Ratings
        Label3.Text = "Available from : " & provider.Price   ' yash change this once the db team adds the endtime to serviceAreaTimeslots table
        Label4.Text = provider.Experience & " years"
        Me.serviceProviderID = provider.ID
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)

        Label1.Location = New Point(55, 80)
        Label5.Location = New Point(20, 45)
        Label2.Location = New Point(55, 138)
        Label3.Location = New Point(161, 138)
        Label4.Location = New Point(485, 138)

        Panel1.Location = New Point(843, 65)
        Panel2.Location = New Point(10, 80)

        ' Create a label for stars
        Dim starsLabel As New Label()

        ' Calculate the number of full stars and empty stars
        Dim fullStars As Integer = ratings
        Dim emptyStars As Integer = Math.Max(0, 5 - ratings)

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
        starsLabel.Location = New Point(586, 130)

        ' Create label for "Rating"
        Dim ratingTextLabel As New Label()
        ratingTextLabel.Text = "Rating:"
        ratingTextLabel.Size = New Size(70, 20) ' Reduce the size of the label
        ratingTextLabel.Location = New Point(591, 115) ' Move further right
        ratingTextLabel.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular) ' Reduce the font size
        ratingTextLabel.ForeColor = Color.Black ' Set color to black

        ' Add all labels to the result panel
        Me.Controls.Add(ratingTextLabel)
        Me.Controls.Add(starsLabel)


        Dim connection3 As New MySqlConnection(SessionManager.connectionString)

        ' Create a MySqlCommand object with the SQL query and connection
        Try
            ' Open the connection
            connection3.Open()
            Dim query As String = "SELECT * FROM serviceproviders as sp WHERE sp.serviceProviderID = " & serviceProviderID
            Dim query2 As String = "SELECT * FROM workHours WHERE workHours.serviceProviderID= " & serviceProviderID
            Dim query3 As String = "SELECT * FROM (SELECT * FROM serviceproviders WHERE serviceproviders.serviceProviderID= " & serviceProviderID & " ) as newT JOIN contactDetails ON newT.userID=contactDetails.userID"
            Dim command As New MySqlCommand(query, connection3)

            ' Execute the SQL query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Loop through the result set and populate userList
            If (reader.Read()) Then
                Label1.Text = reader("serviceProviderName")
                userID = reader("userID")
                Label4.Text = "Experience : " & reader("experienceYears") & " years"
            End If
            reader.Close()



            Dim command2 As New MySqlCommand(query2, connection3)

            ' Execute the SQL query
            Dim reader2 As MySqlDataReader = command2.ExecuteReader()

            If (reader2.Read()) Then
                Label3.Text = "Services from " & reader2("startTime").ToString().Substring(0, 5) & " to " & reader2("endTime").ToString().Substring(0, 5)
            End If
            reader2.Close()


            Dim command3 As New MySqlCommand(query3, connection3)

            ' Execute the SQL query
            Dim reader3 As MySqlDataReader = command3.ExecuteReader()

            If (reader3.Read()) Then
                Label2.Text = reader3("location")
            End If
            reader3.Close()
            ' Close the reader
        Catch ex As Exception
            ' Display error message if loading fails
            MessageBox.Show("Failed to load serviceprovider. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



        Dim textSize As Size = Label2.Location
        Label2.Location = textSize
        textSize.Width = textSize.Width + Label2.Size.Width
        Label6.Location = New Point(textSize.Width, textSize.Height - 13)
        textSize.Width = textSize.Width + Label6.Size.Width
        Label3.Location = textSize
        textSize.Width = textSize.Width + Label3.Size.Width
        Label7.Location = New Point(textSize.Width, textSize.Height - 13)
        textSize.Width = textSize.Width + Label7.Size.Width
        Label4.Location = textSize


        Dim panel As New Panel()
        panel.Location = New Point(10, 175)
        panel.Size = New Size(833, 450)
        panel.AutoScroll = True

        Me.Controls.Add(panel)

        Dim numGroups As Integer = 16

        Dim groupSize As New Size(750, 200)
        Dim groupSpacing As Integer = 10

        Dim yPosition As Integer = 0


        Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")

        Try
            If Not File.Exists(imagePath) Then
                MessageBox.Show("Image file not found: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Dim servicesList As New List(Of Services)()

        Dim connection1 As New MySqlConnection(SessionManager.connectionString)

        ' Create a MySqlCommand object with the SQL query and connection
        Try
            ' Open the connection
            connection1.Open()
            Dim query As String = "SELECT MAX(services.serviceID) as serviceID,  services.serviceName,services.price ,services.serviceTypeID, services.serviceDescription,services.completionTime,services.areaID, services.servicePhoto FROM services WHERE services.flagbit=1 AND services.serviceProviderID = " & serviceProviderID & " GROUP BY services.serviceName,services.price, services.serviceDescription"
            Dim command As New MySqlCommand(query, connection1)

            ' Execute the SQL query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Loop through the result set and populate userList



            While reader.Read()
                Dim service As New Services()
                service.serviceTypeID = reader("serviceTypeID")
                service.serviceID = reader("serviceID")
                service.serviceName = reader("serviceName")
                service.price = reader("price")
                service.serviceDescription = reader("serviceDescription")

                service.completionTime = reader("completionTime")
                service.areaID = reader("areaID")

                If Not reader.IsDBNull(reader.GetOrdinal("servicePhoto")) Then
                    ' Convert byte array to image
                    service.servicePhoto = reader("servicePhoto")
                Else
                    service.servicePhoto = File.ReadAllBytes(imagePath)
                End If



                ' Add more properties as needed
                servicesList.Add(service)
            End While

            ' Close the reader
            reader.Close()
            connection1.Close()
        Catch ex As Exception
            ' Display error message if loading fails
            MessageBox.Show("Failed to load services. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        For i As Integer = 0 To servicesList.Count
            If (i >= servicesList.Count) Then
                Exit For
            End If
            Dim groupBox As New GroupBox()
            groupBox.Size = groupSize
            groupBox.Location = New Point(50, yPosition)

            panel.Controls.Add(groupBox)

            Dim stream As New MemoryStream(servicesList(i).servicePhoto)
            Dim image As Image = Image.FromStream(stream)

            Dim im As New PictureBox()
            im.SizeMode = PictureBoxSizeMode.StretchImage
            im.Size = New Size(170, 170)
            im.Location = New Point(10, 20)
            im.Image = image

            groupBox.Controls.Add(im)

            Dim headingLabel As New Label()
            headingLabel.Text = servicesList(i).serviceName
            headingLabel.Font = New Font("Arial", 12, FontStyle.Bold)
            headingLabel.AutoSize = True
            headingLabel.Location = New Point(200, 20)

            groupBox.Controls.Add(headingLabel)

            Dim subheadingLabel As New Label()
            subheadingLabel.Text = "Rate: Rs " & servicesList(i).price
            subheadingLabel.Font = New Font("Arial", 10)
            subheadingLabel.AutoSize = True
            subheadingLabel.Location = New Point(200, 50)

            groupBox.Controls.Add(subheadingLabel)

            Dim descriptionLabel As New Label()
            descriptionLabel.Text = servicesList(i).serviceDescription
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
            Dim serviceIDThis As Integer = servicesList(i).serviceID
            AddHandler newButton.Click, Sub(s, ev) BookNowButton_Click(s, ev, serviceIDThis)
            groupBox.Controls.Add(newButton)

            yPosition += groupSize.Height + groupSpacing
        Next



        Dim reviewsList As New List(Of Reviews)()

        Dim connection2 As New MySqlConnection(SessionManager.connectionString)

        ' Create a MySqlCommand object with the SQL query and connection
        Try
            ' Open the connection
            connection2.Open()
            Dim query As String = "SELECT * FROM (SELECT * FROM reviews as r WHERE r.givenForID = " & userID & " ) as newT JOIN users ON newT.givenByID=users.userID "
            Dim command As New MySqlCommand(query, connection2)

            ' Execute the SQL query
            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Loop through the result set and populate userList



            While reader.Read()
                Dim review As New Reviews()
                review.reviewID = Convert.ToInt32(reader("reviewID"))
                review.appointmentID = reader("appointmentID")
                review.rating = reader("rating")
                review.reviewText = reader("reviewText")
                review.reviewDate = reader("reviewDate")
                review.givenForID = reader("givenForID")
                review.givenByID = reader("givenByID")
                review.givenByName = reader("userName")
                ' Add more properties as needed
                reviewsList.Add(review)
            End While

            ' Close the reader
            reader.Close()
            connection2.Close()
        Catch ex As Exception
            ' Display error message if loading fails
            MessageBox.Show("Failed to load reviews. Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        Dim yPosition2 As Integer = 10
        Panel2.AutoScroll = True
        For i As Integer = 0 To reviewsList.Count
            If (i >= reviewsList.Count) Then
                Exit For
            End If
            Dim itemPanel As New Panel()
            itemPanel.Size = New Size(275, 125)
            itemPanel.Location = New Point(16, yPosition2)
            itemPanel.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            Panel2.Controls.Add(itemPanel)

            Dim headingLabel As New Label()
            headingLabel.Text = "By " & reviewsList(i).givenByName & ":"
            headingLabel.Font = New Font("Segoe", 9)
            headingLabel.AutoSize = True
            headingLabel.Location = New Point(20, 10)

            itemPanel.Controls.Add(headingLabel)



            Dim starsLabel2 As New Label()

            ' Calculate the number of full stars and empty stars
            Dim fullStars2 As Integer = reviewsList(i).rating
            Dim emptyStars2 As Integer = Math.Max(0, 5 - reviewsList(i).rating)

            ' Generate the text for full and empty stars
            Dim fullStarsText2 As String = New String("★"c, fullStars2)
            Dim emptyStarsText2 As String = New String("☆"c, emptyStars2)

            ' Combine full and empty stars text
            Dim combinedText2 As String = fullStarsText2 & emptyStarsText2

            ' Set text and properties for stars label
            starsLabel2.Text = "Rating : " & combinedText2
            starsLabel2.ForeColor = ColorTranslator.FromHtml("#124E55") ' Set color to yellow for full stars
            starsLabel2.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
            starsLabel2.AutoSize = True ' Automatically adjust the size of the label
            starsLabel2.Location = New Point(20, 30)




            itemPanel.Controls.Add(starsLabel2)

            Dim textLabel As New Label()
            textLabel.Text = reviewsList(i).reviewText.ToString()
            textLabel.AutoSize = False
            textLabel.Size = New Size(240, 81)
            textLabel.Location = New Point(20, 50)
            textLabel.AutoEllipsis = True
            textLabel.BorderStyle = BorderStyle.None

            itemPanel.Controls.Add(textLabel)

            yPosition2 += 150
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

    Private Sub BookNowButton_Click(sender As Object, e As EventArgs, serviceserviceID As Integer)
        'RemovePreviousForm()

        Dim str As String = "Proceed to Pay"
        Dim appointmentBookingForm As New Appointment_booking(str, serviceserviceID)

        With appointmentBookingForm
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(appointmentBookingForm)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click

        RemovePreviousForm()
        Me.Close()

        With Homepage_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Customer)
            .BringToFront()
            .Show()
        End With

    End Sub
End Class
