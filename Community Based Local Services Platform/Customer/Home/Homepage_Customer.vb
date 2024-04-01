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
