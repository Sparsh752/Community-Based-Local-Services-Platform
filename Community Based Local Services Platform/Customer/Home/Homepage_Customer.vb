Public Class Homepage_Customer
    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Fill Panel1 with pink color
        Panel1.BackColor = Color.Pink

        ' Open Display_Services.vb form inside Panel2
        Dim displayServicesForm As New Display_Services()
        displayServicesForm.TopLevel = False
        Panel2.Controls.Add(displayServicesForm)
        displayServicesForm.Dock = DockStyle.Fill
        displayServicesForm.Show()

        ' Center the form and set its WindowState
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class
