Imports System.IO

Public Class Display_Services
    Private Most_Trusted(3) As String
    Private Popular_Trusted(3) As String

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

        ' Display the data
        DisplayProviders(Most_Trusted, "Most Trusted Service Providers", 90)
        DisplayProviders(Popular_Trusted, "Trending Services", 350)
    End Sub

    Private Sub DisplayProviders(providers As String(), heading As String, topOffset As Integer)
        Dim lblHeading As New Label()
        lblHeading.Text = heading
        lblHeading.Font = New Font("Bahnschrift Light", 18, FontStyle.Bold)
        lblHeading.AutoSize = True
        lblHeading.Location = New Point(40, topOffset)
        Me.Controls.Add(lblHeading)

        Dim startX As Integer = 60 ' Starting X position for PictureBox and Label

        For i As Integer = 0 To providers.Length - 1
            Dim pb As New PictureBox()
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Size = New Size(150, 150)
            pb.Location = New Point(startX + (i * 200) - 10, topOffset + 50)

            ' Combine the startup path with the relative path to the image file
            Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\sample_SP.jpg")

            ' Check if the image file exists
            Try
                If File.Exists(imagePath) Then
                    pb.Image = Image.FromFile(imagePath)
                Else
                    ' Handle the situation when the image file doesn't exist
                    MessageBox.Show("Image file not found: " & imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                ' Handle any other exceptions that might occur during image loading
                MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Dim lblProvider As New Label()
            lblProvider.Text = providers(i)
            lblProvider.AutoSize = True
            lblProvider.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
            lblProvider.Location = New Point(startX + (i * 200) + 20, topOffset + 210)

            Me.Controls.Add(pb)
            Me.Controls.Add(lblProvider)
        Next
    End Sub

End Class
