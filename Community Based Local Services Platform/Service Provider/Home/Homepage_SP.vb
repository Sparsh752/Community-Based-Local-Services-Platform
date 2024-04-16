Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.ApplicationServices
Imports Org.BouncyCastle.Asn1.X509.Qualified




Public Class Services
    Public Property serviceID As Integer
    Public Property serviceTypeID As Integer
    Public Property serviceName As String
    Public Property price As Double
    Public Property serviceDescription As String
    Public Property completionTime As String
    Public Property areaID As String

    Public Property servicePhoto As Byte()
End Class


Public Class Reviews
    Public Property reviewID As Integer
    Public Property appointmentID As Integer
    Public Property rating As Double
    Public Property reviewText As String
    Public Property reviewDate As String
    Public Property givenForID As Integer
    Public Property givenByID As Integer
    Public Property givenByName As String
End Class


Public Class Homepage_SP
    Dim serviceProviderID As Integer
    Dim userID As Integer
    Public Sub New(serviceProviderID As Integer)
        InitializeComponent()
        serviceProviderID = SessionManager.spID
    End Sub
    Public Sub RemovePreviousForm()
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




    Private Sub AddServicesButton_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        Dim newpage As AddServices_SP = New AddServices_SP(serviceProviderID)
        newpage.Margin = New Padding(0, 0, 0, 0)
        With newpage
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(newpage)
            .BringToFront()
            .Show()
        End With
    End Sub


    Private Sub EditServicesButton_Click(sender As Object, e As EventArgs, serviceID As Integer)
        RemovePreviousForm()
        Dim newpage As UpdateServices_SP = New UpdateServices_SP(serviceProviderID, serviceID)
        newpage.Margin = New Padding(0, 0, 0, 0)
        With newpage
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(newpage)
            .BringToFront()
            .Show()
        End With
    End Sub



    Private Sub EditProfileButton_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        EditSP.Margin = New Padding(0, 0, 0, 0)
        With EditSP
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(EditSP)
            .BringToFront()
            .Show()
            EditSP.Back_btn.Visible = False
        End With
    End Sub



    Private Sub DeleteServiceButton_Click(sender As Object, e As EventArgs, serviceName As String)
        Dim connection As New MySqlConnection(SessionManager.connectionString)

        Try
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the service?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            ' Check the user's response
            If result = DialogResult.No Then
                ' Delete the service (write your deletion logic here)
                ' For example:
                Return

            End If


            connection.Open()
            ' Connection established successfully

            Dim query As String = "Update services as s SET s.flagbit = 0 WHERE s.serviceName = '" & serviceName & "' AND s.serviceProviderID = " & serviceProviderID
            MessageBox.Show(serviceProviderID)
            Dim command As New MySqlCommand(query, connection)

            Dim rowsAffected As Integer = command.ExecuteNonQuery()

            ' Check if any rows were deleted
            If rowsAffected > 0 Then
                MessageBox.Show("The entry has been successfully deleted from the server.", "Entry Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Dim homePageSP As New Homepage_SP(serviceProviderID)
                RemovePreviousForm()
                homePageSP.Margin = New Padding(0, 0, 0, 0)
                With homePageSP
                    .TopLevel = False
                    .Dock = DockStyle.Fill
                    Panel3.Controls.Add(homePageSP)
                    .BringToFront()
                    .Show()
                End With
            Else
                MessageBox.Show("No matching rows found to delete.", "No Rows Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            ' Handle connection errors
            MessageBox.Show("Error connecting to MySQL: " & ex.Message)
        Finally
            ' Close the connection
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try

    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        serviceProviderID = SessionManager.spID


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
            Dim serviceNameThis As String = servicesList(i).serviceName
            AddHandler newButton1.Click, Sub(s, ev) DeleteServiceButton_Click(s, ev, serviceNameThis)
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
            Dim serviceIDThis As Integer = servicesList(i).serviceID
            AddHandler newButton2.Click, Sub(s, ev) EditServicesButton_Click(s, ev, serviceIDThis)
            groupBox.Controls.Add(newButton2)

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


        Dim numItems As Integer = 10

        Dim yPosition2 As Integer = 38
        Panel6.AutoScroll = True
        For i As Integer = 0 To reviewsList.Count
            If (i >= reviewsList.Count) Then
                Exit For
            End If
            Dim itemPanel As New Panel()
            itemPanel.Size = New Size(275, 125)
            itemPanel.Location = New Point(16, yPosition2)
            itemPanel.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            Panel6.Controls.Add(itemPanel)

            Dim headingLabel As New Label()
            headingLabel.Text = "By " & reviewsList(i).givenByName & ":"
            headingLabel.Font = New Font("Segoe", 9)
            headingLabel.AutoSize = True
            headingLabel.Location = New Point(20, 10)

            itemPanel.Controls.Add(headingLabel)


            Dim starsLabel As New Label()

            ' Calculate the number of full stars and empty stars
            Dim fullStars As Integer = reviewsList(i).rating
            Dim emptyStars As Integer = Math.Max(0, 5 - reviewsList(i).rating)

            ' Generate the text for full and empty stars
            Dim fullStarsText As String = New String("★"c, fullStars)
            Dim emptyStarsText As String = New String("☆"c, emptyStars)

            ' Combine full and empty stars text
            Dim combinedText As String = fullStarsText & emptyStarsText

            ' Set text and properties for stars label
            starsLabel.Text = "Rating : " & combinedText
            starsLabel.ForeColor = ColorTranslator.FromHtml("#124E55") ' Set color to yellow for full stars
            starsLabel.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
            starsLabel.AutoSize = True ' Automatically adjust the size of the label
            starsLabel.Location = New Point(20, 30)




            itemPanel.Controls.Add(starsLabel)


            Dim textLabel As New Label()
            textLabel.Text = reviewsList(i).reviewText.ToString()
            textLabel.Font = New Font("Segoe", 8)
            textLabel.AutoSize = False
            textLabel.Size = New Size(240, 81)
            textLabel.Location = New Point(20, 50)
            textLabel.AutoEllipsis = True
            textLabel.BorderStyle = BorderStyle.None

            itemPanel.Controls.Add(textLabel)

            yPosition2 += 150
        Next



    End Sub
End Class