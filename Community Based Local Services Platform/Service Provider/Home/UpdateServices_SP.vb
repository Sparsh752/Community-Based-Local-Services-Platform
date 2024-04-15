Imports System.IO
Imports com.itextpdf.text.pdf
Imports Mysqlx

Public Class UpdateServices_SP
    ' Declare global variables
    Private serviceProviderName As String
    Private serviceType As String
    Private serviceDescription As String
    Private serviceAreas As New List(Of String)()
    Private basicPrice As Decimal
    Private imagePath As String ' To store the path of the uploaded image
    Dim connection1 As New MySqlConnection(SessionManager.connectionString)
    Dim serviceID As Integer
    Dim serviceProviderID As Integer
    Dim connection2 As New MySqlConnection(SessionManager.connectionString)
    Public Sub New(serviceProviderID As Integer, serviceID As Integer)
        InitializeComponent()
        Me.serviceProviderID = serviceProviderID
        Me.serviceID = serviceID

    End Sub
    Private Sub UpdateServices_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate ComboBoxes with options at runtime
        PopulateServiceTypeComboBox()
        PopulateServiceAreaListBox()
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)
        Service_Name.Location = New Point(129, 178)
        Service_Name.Size = New Size(332, 40)
        Label2.Location = New Point(127, 146)
        Label1.Location = New Point(127, 99)
        Service_type.Location = New Point(129, 268)
        Service_type.Size = New Size(332, 40)
        Label5.Location = New Point(127, 240)
        Label4.Location = New Point(127, 332)
        Description.Size = New Size(332, 73) ' Adjust the size as needed
        Description.Location = New Point(129, 364)
        Label3.Location = New Point(125, 456)
        Service_area.Location = New Point(129, 484)
        Service_area.Size = New Size(250, 40)
        PictureBox1.Location = New Point(665, 113)
        PictureBox1.Size = New Size(354, 226)
        Price.Location = New Point(665, 392)
        Price.Size = New Size(354, 45)
        Label6.Location = New Point(665, 360)
        Submit_add.Location = New Point(775, 590)
        Submit_add.Size = New Size(150, 40)
        Submit_add.Font = New Font(font_family, 16, FontStyle.Bold)
        Service_Name.Font = New Font(font_family, 16, FontStyle.Regular)
        Service_area.Font = New Font(font_family, 12, FontStyle.Regular)
        Service_type.Font = New Font(font_family, 16, FontStyle.Regular)
        Description.Font = New Font(font_family, 12, FontStyle.Regular)
        Price.Font = New Font(font_family, 16, FontStyle.Regular)
        Label1.Font = New Font(font_family, 22, FontStyle.Bold)
        Label2.Font = New Font(font_family, 16, FontStyle.Regular)
        Label3.Font = New Font(font_family, 16, FontStyle.Regular)
        Label4.Font = New Font(font_family, 16, FontStyle.Regular)
        Label5.Font = New Font(font_family, 16, FontStyle.Regular)
        Label6.Font = New Font(font_family, 16, FontStyle.Regular)
        Button1.Font = New Font(font_family, 12, FontStyle.Bold)
        Button2.Font = New Font(font_family, 12, FontStyle.Bold)
        Button1.Location = New Point(128, 560)
        Button2.Location = New Point(256, 560)
        Button1.Size = New Size(107, 30)
        Button2.Size = New Size(107, 30)
        Button1.FlatAppearance.BorderSize = 0
        Button2.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button2.FlatStyle = FlatStyle.Flat
        Submit_add.FlatAppearance.BorderSize = 0
        Submit_add.FlatStyle = FlatStyle.Flat
        Location_list.Location = New Point(665, 490)
        Location_list.Size = New Size(332, 45)
        Location_list.Font = New Font(font_family, 12, FontStyle.Regular)
        Location_list.Scrollable = True
        Panel1.Location = New Point(666, 517.5)
        Panel1.Size = New Size(330, 16)

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")



        Try
            ' Open connection
            connection1.Open()

            ' Fetch existing service details from the database
            Dim query As String = "SELECT serviceName, serviceDescription, serviceTypeID, price, areaID, servicePhoto FROM services WHERE serviceID = @serviceID AND serviceProviderID = @serviceProviderID"
            Dim command As New MySqlCommand(query, connection1)
            command.Parameters.AddWithValue("@serviceID", serviceID)
            command.Parameters.AddWithValue("@serviceProviderID", serviceProviderID)

            Dim reader As MySqlDataReader = command.ExecuteReader()
            Dim x As Integer = 0
            Dim temp_image As Byte()
            Dim imagePath2 As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")
            While reader.Read()
                If x = 0 Then


                    Service_Name.Text = reader("serviceName").ToString()
                    Description.Text = reader("serviceDescription").ToString()

                    If Not reader.IsDBNull(reader.GetOrdinal("servicePhoto")) Then
                        ' Convert byte array to image
                        temp_image = reader("servicePhoto")

                    Else
                        temp_image = File.ReadAllBytes(imagePath2)
                    End If

                    If temp_image IsNot Nothing AndAlso temp_image.Length > 0 Then
                        Using ms As New MemoryStream(temp_image)
                            ' Convert the byte array to an Image
                            Dim image As Image = Image.FromStream(ms)
                            ' Set the Image to the PictureBox
                            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
                            PictureBox1.Image = image

                        End Using
                    End If

                    ' Select the existing service type in the ComboBox
                    Dim typeID As Integer = reader("serviceTypeID") ' You may need to adjust this part based on how serviceTypeID is represented in your database

                    Price.Text = reader("price").ToString()

                    Dim getTypename As String = "SELECT serviceTypeName FROM serviceTypes WHERE serviceID=@typeID"
                    connection2.Open()
                    Using command2 As New MySqlCommand(getTypename, connection2)
                        command2.Parameters.AddWithValue("@typeID", typeID)
                        Service_type.Text = Convert.ToString(command2.ExecuteScalar())
                    End Using
                    connection2.Close()

                End If
                ' Set existing values to the corresponding controls

                Dim curr_area As Integer = reader("areaID")
                Dim get_area As String = "SELECT location FROM serviceAreas WHERE areaID=@curr_area"
                connection2.Open()
                Using command2 As New MySqlCommand(get_area, connection2)
                    command2.Parameters.AddWithValue("@curr_area", curr_area)
                    serviceAreas.Add(Convert.ToString(command2.ExecuteScalar()))
                End Using
                connection2.Close()
                x += 1
                ' You may also need to retrieve and set the image here if applicable
            End While

            For Each area As String In serviceAreas
                Service_area.Items.Add(area)
                Location_list.Items.Add(area)
            Next

            reader.Close()
        Catch ex As Exception
            ' Handle connection errors or any other exceptions
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close the connection
            connection1.Close()
        End Try



    End Sub

    Private Sub PopulateServiceTypeComboBox()

        Try
            connection1.Open()
            ' Connection established successfully

            Dim query As String = "SELECT serviceTypeName FROM serviceTypes"
            Dim command As New MySqlCommand(query, connection1)

            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Clear existing items from the ComboBox
            Service_type.Items.Clear()

            ' Add items from the database to the ComboBox
            While reader.Read()
                Service_type.Items.Add(reader("serviceTypeName").ToString())
            End While

            reader.Close()

        Catch ex As Exception
            ' Handle connection errors
            MessageBox.Show("Error connecting to MySQL: " & ex.Message)
        Finally
            ' Close the connection
            connection1.Close()
        End Try
        ' Add more items as needed
    End Sub


    Private Sub PopulateServiceAreaListBox()
        ' Clear the ListBox first

        Try
            connection1.Open()
            ' Connection established successfully

            Dim query As String = "SELECT location FROM serviceAreas"
            Dim command As New MySqlCommand(query, connection1)

            Dim reader As MySqlDataReader = command.ExecuteReader()

            ' Clear existing items from the ComboBox
            Service_area.Items.Clear()

            ' Add items from the database to the ComboBox
            While reader.Read()
                Service_area.Items.Add(reader("location").ToString())
            End While

            reader.Close()

        Catch ex As Exception
            ' Handle connection errors
            MessageBox.Show("Error connecting to MySQL: " & ex.Message)
        Finally
            ' Close the connection
            connection1.Close()
        End Try
        ' Add more items as needed
    End Sub


    Private Sub Submit_add_Click(sender As Object, e As EventArgs) Handles Submit_add.Click
        ' Check if Service Name is filled
        If String.IsNullOrWhiteSpace(Service_Name.Text) Then
            MessageBox.Show("Please enter Service Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if Service Type is selected
        If Service_type.SelectedItem Is Nothing Then
            MessageBox.Show("Please select Service Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if Description is filled
        If String.IsNullOrWhiteSpace(Description.Text) Then
            MessageBox.Show("Please enter Description.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if Service Area is selected
        If (Location_list.Items.Count = 0) Then
            MessageBox.Show("Please select at least one Service Area.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if Price is filled
        If String.IsNullOrWhiteSpace(Price.Text) Then
            MessageBox.Show("Please enter Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Retrieve information from the form fields and store them globally
        serviceProviderName = Service_Name.Text
        serviceType = Service_type.SelectedItem.ToString
        serviceDescription = Description.Text

        ' Check if Price is a valid number
        If Not Decimal.TryParse(Price.Text, basicPrice) Then
            MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Convert the image to a byte array
        Dim imageData As Byte() = Nothing
        If Not PictureBox1.Image Is Nothing Then
            Using ms As New MemoryStream
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                imageData = ms.ToArray
            End Using
        End If

        ' Display all information including the image in a message box
        '  Dim imageInfo = If(imageData IsNot Nothing, Image.FromStream(New MemoryStream(imageData)), Nothing)

        ' Display the image in the message box
        '  Dim msg As New Form
        '  msg.Text = "Service Details"
        '  msg.Size = New Size(400, 400)
        ''  If imageInfo IsNot Nothing Then
        ' Dim picBox As New PictureBox
        'picBox.Dock = DockStyle.Top
        'picBox.SizeMode = PictureBoxSizeMode.Zoom
        'icBox.Image = imageInfo
        'msg.Controls.Add(picBox)
        '  End If









        '  Dim details = "Service Provider's Name: " & serviceProviderName & Environment.NewLine &
        '              "Type of Service: " & serviceType & Environment.NewLine &
        '              "Description of Service: " & serviceDescription & Environment.NewLine &
        ''              "Service Areas: " & String.Join(", ", serviceAreas) & Environment.NewLine &
        '              "Basic Price of Service: $" & basicPrice.ToString("F2") & Environment.NewLine &
        'If (imageData IsNot Nothing, "Image Attached", "No image uploaded")Then

        '  Dim lblDetails As New Label
        '  lblDetails.Text = details
        '  lblDetails.Dock = DockStyle.Fill

        '  msg.Controls.Add(lblDetails)

        ''  msg.ShowDialog()




        Dim newPrice As Decimal = basicPrice ' New price


        Try

            connection1.Open()

            For Each areaName As String In serviceAreas
                ' Retrieve serviceTypeID based on serviceTypeName
                Dim getServiceTypeIDQuery As String = $"SELECT serviceID FROM serviceTypes WHERE serviceTypeName = @serviceTypeName"
                Dim serviceTypeID As Integer

                Using command As New MySqlCommand(getServiceTypeIDQuery, connection1)
                    command.Parameters.AddWithValue("@serviceTypeName", serviceType)
                    serviceTypeID = Convert.ToInt32(command.ExecuteScalar())
                End Using

                ' Retrieve areaID based on areaName
                Dim getAreaIDQuery As String = "SELECT areaID FROM serviceAreas WHERE location = @areaName"
                Dim areaID As Integer

                Using command As New MySqlCommand(getAreaIDQuery, connection1)
                    command.Parameters.AddWithValue("@areaName", areaName)
                    areaID = Convert.ToInt32(command.ExecuteScalar())
                End Using

                ' Update the row in the services table for the current area
                Dim updateQuery As String = "UPDATE services SET serviceName = @serviceName, serviceDescription = @serviceDescription, serviceTypeID = @serviceTypeID, price = @price, areaID = @areaID, servicePhoto=@imagedata WHERE serviceID = @serviceID AND serviceProviderID = @serviceProviderID"

                Using command As New MySqlCommand(updateQuery, connection1)
                    command.Parameters.AddWithValue("@serviceName", serviceProviderName)
                    command.Parameters.AddWithValue("@serviceDescription", serviceDescription)
                    command.Parameters.AddWithValue("@serviceTypeID", serviceTypeID)
                    command.Parameters.AddWithValue("@price", newPrice)
                    command.Parameters.AddWithValue("@areaID", areaID)
                    command.Parameters.AddWithValue("@imagedata", imageData)
                    command.Parameters.AddWithValue("@serviceProviderID", serviceProviderID)
                    command.Parameters.AddWithValue("@serviceID", serviceID)
                    command.ExecuteNonQuery()
                End Using
            Next
            connection1.Close()

        Catch ex As Exception
            ' Handle any exceptions
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        RemovePreviousForm()
        Dim newpage As Homepage_SP = New Homepage_SP(serviceProviderID) With {
            .Margin = New Padding(0, 0, 0, 0)
        }
        With newpage
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(newpage)
            .BringToFront()
            .Show()
        End With
        ' Reset the form fields after submission
        ' Service_Name.Clear()
        ' Service_type.SelectedIndex = -1 ' Deselect any selected item
        ' Description.Clear()
        ' Service_area.Items.Clear() ' Deselect all items
        ' Price.Clear()
        ' PictureBox1.Image = Nothing 'Put the default image here'
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Open file dialog to select an image file
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Load selected image into PictureBox control with Zoom SizeMode
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            PictureBox1.Image = Image.FromFile(openFileDialog.FileName)
            ' Store the path of the uploaded image
            imagePath = openFileDialog.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim selectedItem As String = Service_area.SelectedItem.ToString()

        ' Check if the selected item is not already in the list
        If Not serviceAreas.Contains(selectedItem) Then
            ' Add the selected item to the list
            serviceAreas.Add(selectedItem)
        End If


        ' Clear existing items from the ListView
        Location_list.Items.Clear()

        ' Add items from the selectedAreas list to the ListView
        For Each area As String In serviceAreas
            Location_list.Items.Add(area)
        Next

    End Sub

    Public Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If SessionManager.Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            SessionManager.Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        Close()
        Dim homePageSP As New Homepage_SP(spID)
        homePageSP.Margin = New Padding(0, 0, 0, 0)
        With homePageSP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(homePageSP)
            .BringToFront()
            .Show()
        End With
    End Sub


End Class
