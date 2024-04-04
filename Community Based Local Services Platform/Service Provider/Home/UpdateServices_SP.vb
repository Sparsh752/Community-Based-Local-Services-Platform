Imports System.IO

Public Class UpdateServices_SP
    ' Declare global variables
    Private serviceProviderName As String
    Private serviceType As String
    Private serviceDescription As String
    Private serviceAreas As New List(Of String)()
    Private basicPrice As Decimal
    Private imagePath As String ' To store the path of the uploaded image

    Private Sub UpdateServices_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Populate ComboBoxes with options at runtime
        PopulateServiceTypeComboBox()
        PopulateServiceAreaListBox()
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)
        Service_Name.Location = New Point(129, 178)
        Service_Name.Size = New Size(332, 45)
        Label2.Location = New Point(127, 146)
        Label1.Location = New Point(127, 99)
        Service_type.Location = New Point(129, 268)
        Service_type.Size = New Size(332, 45)
        Label5.Location = New Point(127, 240)
        Label4.Location = New Point(127, 332)
        Description.Size = New Size(332, 73) ' Adjust the size as needed
        Description.Location = New Point(129, 364)
        Label3.Location = New Point(125, 456)
        Service_area.Location = New Point(129, 484)
        PictureBox1.Location = New Point(665, 113)
        PictureBox1.Size = New Size(354, 226)
        Price.Location = New Point(665, 392)
        Price.Size = New Size(354, 45)
        Label6.Location = New Point(665, 360)
        Submit_add.Location = New Point(775, 590)
        Submit_add.Size = New Size(244, 60)
        Label7.Location = New Point(665, 481)
        Submit_add.Font = New Font(font_family, 18, FontStyle.Bold)
        Service_Name.Font = New Font(font_family, 18, FontStyle.Regular)
        Service_area.Font = New Font(font_family, 12, FontStyle.Regular)
        Service_type.Font = New Font(font_family, 18, FontStyle.Regular)
        Description.Font = New Font(font_family, 12, FontStyle.Regular)
        Price.Font = New Font(font_family, 18, FontStyle.Regular)
        Label1.Font = New Font(font_family, 22, FontStyle.Bold)
        Label2.Font = New Font(font_family, 18, FontStyle.Regular)
        Label3.Font = New Font(font_family, 18, FontStyle.Regular)
        Label4.Font = New Font(font_family, 18, FontStyle.Regular)
        Label5.Font = New Font(font_family, 18, FontStyle.Regular)
        Label6.Font = New Font(font_family, 18, FontStyle.Regular)
        Label7.Font = New Font(font_family, 18, FontStyle.Regular)
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
    End Sub

    Private Sub PopulateServiceTypeComboBox()
        ' Add sample options to the ServiceTypeComboBox
        Service_type.Items.Add("Option 1")
        Service_type.Items.Add("Option 2")
        Service_type.Items.Add("Option 3")
        ' Add more options as needed
    End Sub

    Private Sub PopulateServiceAreaListBox()
        ' Add sample options to the ServiceAreaListBox
        Service_area.Items.Add("Area 1")
        Service_area.Items.Add("Area 2")
        Service_area.Items.Add("Area 3")
        ' Add more options as needed
        ' Set ListBox to allow multiple selections
        Service_area.SelectionMode = SelectionMode.MultiSimple
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
        If Service_area.SelectedItems.Count = 0 Then
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

        ' Retrieve selected service areas
        serviceAreas.Clear() ' Clear the list before adding new selections
        For Each selectedArea In Service_area.SelectedItems
            serviceAreas.Add(selectedArea.ToString)
        Next

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
        Dim imageInfo = If(imageData IsNot Nothing, Image.FromStream(New MemoryStream(imageData)), Nothing)

        ' Display the image in the message box
        Dim msg As New Form
        msg.Text = "Service Details"
        msg.Size = New Size(400, 400)
        If imageInfo IsNot Nothing Then
            Dim picBox As New PictureBox
            picBox.Dock = DockStyle.Top
            picBox.SizeMode = PictureBoxSizeMode.Zoom
            picBox.Image = imageInfo
            msg.Controls.Add(picBox)
        End If

        Dim details = "Service Provider's Name: " & serviceProviderName & Environment.NewLine &
                    "Type of Service: " & serviceType & Environment.NewLine &
                    "Description of Service: " & serviceDescription & Environment.NewLine &
                    "Service Areas: " & String.Join(", ", serviceAreas) & Environment.NewLine &
                    "Basic Price of Service: $" & basicPrice.ToString("F2") & Environment.NewLine &
                    If(imageData IsNot Nothing, "Image Attached", "No image uploaded")

        Dim lblDetails As New Label
        lblDetails.Text = details
        lblDetails.Dock = DockStyle.Fill

        msg.Controls.Add(lblDetails)

        msg.ShowDialog()

        ' Reset the form fields after submission
        Service_Name.Clear()
        Service_type.SelectedIndex = -1 ' Deselect any selected item
        Description.Clear()
        Service_area.ClearSelected() ' Deselect all items
        Price.Clear()
        PictureBox1.Image = Nothing 'Put the default image here'
    End Sub



    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Service_area_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Service_area.SelectedIndexChanged

    End Sub
End Class
