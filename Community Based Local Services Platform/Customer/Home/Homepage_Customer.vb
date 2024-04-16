Public Class Homepage_Customer

    Private spdata As New List(Of String)()
    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configure the form
        Dim x = 20
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)

        Panel1.BackColor = ColorTranslator.FromHtml("#F6F6F6")
        Panel1.Size = New Size(359, 635)

        searchBox.Location = New Point(34, 106)
        searchBox.Font = New Font(SessionManager.font_family, 14, FontStyle.Regular)
        searchBox.Size = New Size(280, 27)

        priceLabel.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        priceLabel.Location = New Point(34, 253 + x)

        Label3.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        Label1.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
        Label2.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)
        Label4.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        Label1.Location = New Point(34, 276 + x)
        Label2.Location = New Point(169, 276 + x)
        Label3.Location = New Point(34, 343 + x)
        Label4.Location = New Point(34, 422 + x)

        SearchBtn.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        SearchBtn.FlatStyle = FlatStyle.Flat
        SearchBtn.FlatAppearance.BorderSize = 0
        SearchBtn.BackColor = ColorTranslator.FromHtml("#F9754B")
        SearchBtn.Size = New Size(151, 29)
        SearchBtn.Location = New Point(98, 522 + x)

        MinCostBox.Size = New Size(106, 27)
        MaxCostBox.Size = New Size(106, 27)
        MinCostBox.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        MaxCostBox.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        MinCostBox.Location = New Point(34, 293 + x)
        MaxCostBox.Location = New Point(169, 293 + x)

        TrackBar1.Size = New Size(249, 56)
        TrackBar1.Location = New Point(34, 450 + x)

        ComboBox1.Location = New Point(34, 371 + x)

        ' Load default services in Panel2
        LoadDefaultServices()

        Dim serviceTypeHeadingLabel As New Label()
        serviceTypeHeadingLabel.Text = "Service Types"
        serviceTypeHeadingLabel.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        serviceTypeHeadingLabel.ForeColor = Color.Black
        serviceTypeHeadingLabel.Location = New Point(34, 140 + x)
        serviceTypeHeadingLabel.AutoSize = True
        Panel1.Controls.Add(serviceTypeHeadingLabel)

        ' Assuming you have a function to retrieve distinct service types from the database
        Dim serviceTypes As List(Of Tuple(Of String, String)) = GetDistinctServiceTypesFromDB()

        ' Define the initial position and size of the buttons
        Dim initialX As Integer = 34
        Dim initialY As Integer = 171 + x
        Dim buttonWidth As Integer = 84
        Dim buttonHeight As Integer = 24
        Dim xOffset As Integer = 15 ' Horizontal spacing between buttons
        Dim maxButtonsPerRow As Integer = 3 ' Maximum buttons per row
        Dim currentRow As Integer = 0
        Dim currentColumn As Integer = 0

        ' Create a panel to contain the buttons
        Dim buttonsPanel As New Panel()
        buttonsPanel.AutoScroll = True ' Enable scrolling for the panel

        ' Add the buttons panel to the main panel
        Panel1.Controls.Add(buttonsPanel)

        ' Calculate the total height required for two rows of buttons
        Dim totalHeightForTwoRows As Integer = (2 * (buttonHeight + 7))

        ' Set the size of the buttons panel
        buttonsPanel.Size = New Size(320, totalHeightForTwoRows)
        buttonsPanel.Location = New Point(initialX, initialY)

        ' Loop through the distinct service types and create buttons dynamically
        For Each serviceType As Tuple(Of String, String) In serviceTypes
            Dim serviceTypeButton As New Button With {
                .Name = serviceType.Item1,
                .Text = serviceType.Item2
            }

            ' Calculate the position of the button
            Dim buttonX As Integer = (currentColumn * (buttonWidth + xOffset))
            Dim buttonY As Integer = (currentRow * (buttonHeight + 7)) ' Vertical spacing between rows

            serviceTypeButton.Location = New Point(buttonX, buttonY)
            serviceTypeButton.Size = New Size(buttonWidth, buttonHeight)
            serviceTypeButton.FlatStyle = FlatStyle.Flat
            serviceTypeButton.FlatAppearance.BorderSize = 0
            serviceTypeButton.BackColor = ColorTranslator.FromHtml("#124E55")
            serviceTypeButton.ForeColor = Color.White
            serviceTypeButton.Font = New Font(SessionManager.font_family, 8, FontStyle.Regular)

            ' Attach event handler for the button click
            AddHandler serviceTypeButton.Click, AddressOf ServiceTypeButton_Click

            ' Add the button to the buttons panel
            buttonsPanel.Controls.Add(serviceTypeButton)

            ' Increment the column count
            currentColumn += 1

            ' If the maximum buttons per row is reached, reset column count and increment row count
            If currentColumn >= maxButtonsPerRow Then
                currentColumn = 0
                currentRow += 1
            End If
        Next
        Panel1.Controls.Add(buttonsPanel)

        ' Assuming you have a function to retrieve distinct locations from the database
        Dim locations As List(Of Tuple(Of String, String)) = GetDistinctLocationsFromDB()

        ' Add the retrieved locations to the ComboBox
        For Each Location As Tuple(Of String, String) In locations
            ComboBox1.Items.Add(New LocationItem(Location.Item1, Location.Item2))
        Next


        ' Add labels over the TrackBar
        AddTrackBarLabels()
    End Sub

    Public Class LocationItem
        Public Property AreaID As String
        Public Property DisplayString As String

        Public Sub New(ByVal areaID As String, ByVal displayString As String)
            Me.AreaID = areaID
            Me.DisplayString = displayString
        End Sub

        Public Overrides Function ToString() As String
            Return DisplayString
        End Function
    End Class


    Private Function GetDistinctLocationsFromDB() As List(Of Tuple(Of String, String))
        Dim distinctLocations As New List(Of Tuple(Of String, String))()
        ' Query the database to retrieve distinct locations
        Dim query As String = "SELECT areaID, location FROM serviceAreas"
        ' Create a new SQL connection
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()

            ' Create a new SQL command
            Using command As New MySqlCommand(query, connection)
                ' Execute the SQL command and create a data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Read data from the reader
                    While reader.Read()
                        ' Add the location to the list
                        distinctLocations.Add(Tuple.Create(reader("areaID").ToString(), reader("location").ToString()))
                    End While
                End Using
            End Using
        End Using
        Return distinctLocations
    End Function

    Private Function GetDistinctServiceTypesFromDB() As List(Of Tuple(Of String, String))
        Dim distinctServiceTypes As New List(Of Tuple(Of String, String))()
        ' Query the database to retrieve distinct service types
        Dim query As String = "SELECT DISTINCT serviceID, serviceTypeName FROM serviceTypes"
        ' Create a new SQL connection
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()

            ' Create a new SQL command
            Using command As New MySqlCommand(query, connection)
                ' Execute the SQL command and create a data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Read data from the reader
                    While reader.Read()
                        ' Add the location to the list
                        distinctServiceTypes.Add(Tuple.Create(reader("serviceID").ToString(), reader("serviceTypeName").ToString()))
                    End While
                End Using
            End Using
        End Using
        Return distinctServiceTypes
    End Function

    Private selectedservices As New List(Of Button)()
    Private Sub ServiceTypeButton_Click(sender As Object, e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)

        ' Toggle button color
        If selectedservices.Contains(button) Then
            ' If button is already selected, remove it from selectedservices and reset its color
            selectedservices.Remove(button)
            button.BackColor = ColorTranslator.FromHtml("#124E55")
        Else
            ' If button is not selected, add it to selectedservices and change its color
            selectedservices.Add(button)
            button.BackColor = ColorTranslator.FromHtml("#F9754B") ' Change to whatever color you want when the button is selected
        End If
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
            label.Size = New Size(75, 20)
            label.Font = New Font("Arial", 12, FontStyle.Regular) ' Set a larger font size
            label.ForeColor = Color.Black ' Set the label text color

            ' Calculate the position of the label relative to the TrackBar
            Dim labelX As Integer = TrackBar1.Location.X + 42.5 + (i - TrackBar1.Minimum) * ((TrackBar1.Width - 25) / (TrackBar1.Maximum - TrackBar1.Minimum))
            Dim labelY As Integer = TrackBar1.Location.Y - 5 ' Adjust the Y-coordinate to place the labels above the TrackBar

            ' Adjust the label position to center it over the tick mark
            label.Location = New Point(labelX - label.Width / 2, labelY)
            Panel1.Controls.Add(label)
            label.BringToFront() ' Bring the label to the front
        Next
    End Sub


    Private Sub minCostBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MinCostBox.KeyPress
        ' Allowing only numeric characters and certain control characters
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub maxCostBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MaxCostBox.KeyPress
        ' Allowing only numeric characters and certain control characters
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Event handler for SearchBtn click event
    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        ' Retrieve search criteria from text box or other UI elements in Panel1
        Dim searchCriteria As String = searchBox.Text
        Dim minCostCriteria As String = MinCostBox.Text
        Dim maxCostCriteria As String = MaxCostBox.Text
        Dim locationCriteria As String = ""

        If ComboBox1.SelectedItem IsNot Nothing Then
            ' Get the selected location criteria
            Dim selectedLocation As LocationItem = DirectCast(ComboBox1.SelectedItem, LocationItem)
            locationCriteria = selectedLocation.AreaID
        End If

        ' Call the method to update services based on search criteria and rating filter
        Dim minRating As Integer = TrackBar1.Value
        Dim maxRating As Integer = 5 ' Maximum rating value is 5
        Dim selectedServiceTypes As New List(Of String)()
        For Each button As Button In selectedservices
            selectedServiceTypes.Add(button.Name)
        Next

        ' Retrieve Display_Services form from Panel2 controls
        Dim displayServicesForm As Display_Services = TryCast(Panel2.Controls(0), Display_Services)

        ' Update services on Display_Services form with search criteria and rating filter
        If displayServicesForm IsNot Nothing Then
            displayServicesForm.UpdateServices(searchCriteria, minCostCriteria, maxCostCriteria, minRating, maxRating, locationCriteria, selectedServiceTypes)
        End If
    End Sub
End Class