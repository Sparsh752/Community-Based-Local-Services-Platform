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

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        ' Retrieve search criteria from text box or other UI elements in Panel1
        Dim searchCriteria As String = searchBox.Text
        Dim minCostCriteria As String = MinCostBox.Text
        Dim maxCostCriteria As String = MaxCostBox.Text

        ' Call the method to update services based on search criteria
        UpdateServices(searchCriteria, minCostCriteria, maxCostCriteria)
    End Sub

    ' Method to update services in Panel2 based on search criteria
    Public Sub UpdateServices(searchCriteria As String, minCostCriteria As String, maxCostCriteria As String)
        Dim displayServicesForm As Display_Services = TryCast(Panel2.Controls(0), Display_Services)
        If displayServicesForm IsNot Nothing Then
            displayServicesForm.UpdateServices(searchCriteria, minCostCriteria, maxCostCriteria)
        End If
    End Sub
End Class
