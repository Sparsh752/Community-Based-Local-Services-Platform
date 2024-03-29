Public Class Homepage_Customer
    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Open Display_Services.vb form inside Panel2
        Panel1.BackColor = ColorTranslator.FromHtml("#ededed")
        Me.Font = New Font("Bahnschrift Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point)

        ' Load default services in Panel2
        LoadDefaultServices()

        ' Center the form and set its WindowState
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
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
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchBtn.Click
        ' Retrieve search criteria from text box or other UI elements in Panel1
        Dim searchCriteria As String = searchBox.Text

        ' Call the method to update services based on search criteria
        UpdateServices(searchCriteria)
    End Sub

    ' Method to update services in Panel2 based on search criteria
    Public Sub UpdateServices(searchCriteria As String)
        Dim displayServicesForm As Display_Services = TryCast(Panel2.Controls(0), Display_Services)
        If displayServicesForm IsNot Nothing Then
            displayServicesForm.UpdateServices(searchCriteria)
        End If
    End Sub

End Class
