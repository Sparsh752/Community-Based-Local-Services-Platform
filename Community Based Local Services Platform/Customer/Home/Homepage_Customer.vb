Public Class Homepage_Customer
    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure the form
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)
        searchBox.Location = New Point(27, 106)
        ' Open Display_Services.vb form inside Panel2
        Panel1.BackColor = ColorTranslator.FromHtml("#F6F6F6")
        priceLabel.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
        priceLabel.Location = New Point(34, 253)
        searchBox.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
        Label3.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
        Label1.Font = New Font(SessionManager.font_family, 7, FontStyle.Regular)
        Label2.Font = New Font(SessionManager.font_family, 7, FontStyle.Regular)
        Label4.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
        SearchBtn.Location = New Point(98, 522)
        SearchBtn.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.FlatAppearance.BorderSize = 0
        SearchBtn.BackColor = ColorTranslator.FromHtml("#F9754B")
        SearchBtn.Size = New Size(151, 29)
        Panel1.Size = New Size(359, 700)
        Label1.Location = New Point(34, 276)
        Label2.Location = New Point(161, 276)
        MinCostBox.Location = New Point(34, 293)
        MaxCostBox.Location = New Point(161, 293)
        MinCostBox.Size = New Size(106, 27)
        MaxCostBox.Size = New Size(106, 27)
        MinCostBox.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
        MaxCostBox.Font = New Font(SessionManager.font_family, 10, FontStyle.Regular)
        Label3.Location = New Point(34, 343)
        ComboBox1.Location = New Point(34, 371)
        Label4.Location = New Point(34, 422)
        TrackBar1.Location = New Point(34, 450)
        TrackBar1.Size = New Size(249, 56)
        Dim Servicetypelabel1 As New Button()
        Dim Servicetypelabel2 As New Button()
        Dim Servicetypelabel3 As New Button()
        Dim Servicetypelabel4 As New Button()
        Dim Servicetypelabel5 As New Button()
        Servicetypelabel1.Text = "Cleaning"
        Servicetypelabel2.Text = "Plumbing"
        Servicetypelabel3.Text = "Electrical"
        Servicetypelabel4.Text = "Carpentry"
        Servicetypelabel5.Text = "Painting"
        Servicetypelabel1.Location = New Point(34, 171)
        Servicetypelabel2.Location = New Point(122, 171)
        Servicetypelabel3.Location = New Point(211, 171)
        Servicetypelabel4.Location = New Point(34, 202)
        Servicetypelabel5.Location = New Point(122, 202)
        Servicetypelabel1.Size = New Size(84, 24)
        Servicetypelabel2.Size = New Size(84, 24)
        Servicetypelabel3.Size = New Size(84, 24)
        Servicetypelabel4.Size = New Size(84, 24)
        Servicetypelabel5.Size = New Size(84, 24)
        Servicetypelabel1.FlatStyle = FlatStyle.Flat
        Servicetypelabel2.FlatStyle = FlatStyle.Flat
        Servicetypelabel3.FlatStyle = FlatStyle.Flat
        Servicetypelabel4.FlatStyle = FlatStyle.Flat
        Servicetypelabel5.FlatStyle = FlatStyle.Flat
        Servicetypelabel1.FlatAppearance.BorderSize = 0
        Servicetypelabel2.FlatAppearance.BorderSize = 0
        Servicetypelabel3.FlatAppearance.BorderSize = 0
        Servicetypelabel4.FlatAppearance.BorderSize = 0
        Servicetypelabel5.FlatAppearance.BorderSize = 0
        Servicetypelabel1.BackColor = ColorTranslator.FromHtml("#124E55")
        Servicetypelabel2.BackColor = ColorTranslator.FromHtml("#124E55")
        Servicetypelabel3.BackColor = ColorTranslator.FromHtml("#124E55")
        Servicetypelabel4.BackColor = ColorTranslator.FromHtml("#124E55")
        Servicetypelabel5.BackColor = ColorTranslator.FromHtml("#124E55")
        Servicetypelabel1.ForeColor = Color.White
        Servicetypelabel2.ForeColor = Color.White
        Servicetypelabel3.ForeColor = Color.White
        Servicetypelabel4.ForeColor = Color.White
        Servicetypelabel5.ForeColor = Color.White
        Servicetypelabel1.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
        Servicetypelabel2.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
        Servicetypelabel3.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
        Servicetypelabel4.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
        Servicetypelabel5.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
        Panel1.Controls.Add(Servicetypelabel1)
        Panel1.Controls.Add(Servicetypelabel2)
        Panel1.Controls.Add(Servicetypelabel3)
        Panel1.Controls.Add(Servicetypelabel4)
        Panel1.Controls.Add(Servicetypelabel5)
        ' Load default services in Panel2
        LoadDefaultServices()
        ' Add labels over the TrackBar
        AddTrackBarLabels()
    End Sub

    ' Method to load default services in Panel2
    Private Sub LoadDefaultServices()
        Dim displayServicesForm As New Display_Services()
        displayServicesForm.TopLevel = False
        Panel2.Controls.Clear() ' Clear existing controls in Panel2
        Panel2.Controls.Add(displayServicesForm)
        displayServicesForm.Dock = DockStyle.Fill
        displayServicesForm.FormBorderStyle = FormBorderStyle.None
        displayServicesForm.Show()

        ' Reset search criteria in the search box
        searchBox.Text = ""
        MinCostBox.Text = ""
        MaxCostBox.Text = ""
    End Sub
    ' Adding labels to trackbar
    Private Sub AddTrackBarLabels()
        ' Create labels for each tick mark value
        For i As Integer = TrackBar1.Minimum To TrackBar1.Maximum
            Dim label As New Label()
            label.Text = i.ToString()
            label.AutoSize = False
            label.Size = New Size(100, 20)
            label.Font = New Font("Arial", 12, FontStyle.Regular) ' Set a larger font size
            label.ForeColor = Color.Black ' Set the label text color
            ' Calculate the position of the label relative to the TrackBar
            Dim labelX As Integer = TrackBar1.Location.X + (i - TrackBar1.Minimum) * (TrackBar1.Width / (TrackBar1.Maximum - TrackBar1.Minimum))
            Dim labelY As Integer = TrackBar1.Location.Y - 20
            ' Adjust the label position to center it over the tick mark
            label.Location = New Point(labelX - label.Width / 2, labelY)
            Me.Controls.Add(label)
        Next
    End Sub



    ' Event handler for "View Details" button click
    Public Sub ViewDetails_Click(sender As Object, e As EventArgs)
        ' Retrieve the provider details from the Tag property of the button
        Dim provider As Display_Services.ServiceProvider = DirectCast(DirectCast(sender, Button).Tag, Display_Services.ServiceProvider)

        ' Open the SP_profile form and pass the provider details
        Dim spProfileForm As New SP_profile(provider.Name, provider.Description, provider.Cost, provider.ServiceName)
        spProfileForm.ShowDialog() ' Show the form as a dialog
    End Sub

    ' Event handler for TrackBar1 scroll event is removed here to address functionality mistakes


    ' Event handler for SearchBtn click event
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        ' Retrieve search criteria from text box or other UI elements in Panel1
        Dim searchCriteria As String = searchBox.Text
        Dim minCostCriteria As String = MinCostBox.Text
        Dim maxCostCriteria As String = MaxCostBox.Text

        ' Call the method to update services based on search criteria and rating filter
        UpdateServices(searchCriteria, minCostCriteria, maxCostCriteria)
    End Sub

    ' Method to update services in Panel2 based on search criteria and rating filter
    Public Sub UpdateServices(searchCriteria As String, minCostCriteria As String, maxCostCriteria As String)
        ' Retrieve rating filter value from TrackBar1
        Dim minRating As Integer = TrackBar1.Value
        Dim maxRating As Integer = 5 ' Maximum rating value is 5

        ' Retrieve Display_Services form from Panel2 controls
        Dim displayServicesForm As Display_Services = TryCast(Panel2.Controls(0), Display_Services)

        ' Update services on Display_Services form with search criteria and rating filter
        If displayServicesForm IsNot Nothing Then
            displayServicesForm.UpdateServices(searchCriteria, minCostCriteria, maxCostCriteria, minRating, maxRating)
        End If
    End Sub
End Class
