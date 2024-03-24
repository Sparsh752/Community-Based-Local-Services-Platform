Public Class Homepage_Customer
    Private Sub HomePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Open Display_Services.vb form inside Panel2
        Panel1.BackColor = ColorTranslator.FromHtml("#ededed")

        Me.Font = New Font("Bahnschrift Light", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Dim displayServicesForm As New Display_Services()
        displayServicesForm.TopLevel = False
        Panel2.Controls.Add(displayServicesForm)
        displayServicesForm.Dock = DockStyle.Fill
        displayServicesForm.FormBorderStyle = FormBorderStyle.None
        displayServicesForm.Show()

        ' Center the form and set its WindowState
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
    End Sub
End Class
