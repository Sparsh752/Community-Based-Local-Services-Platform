Public Class Query_3SP
    Private queryTypes As New List(Of String)()
    Private AppointmentId As String

    Private Sub Query_3SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AppointmentId = "12345"
        Me.Size = New Size(1200, 700)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White

        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Location = New Point(400, 100)
        Panel1.Size = New Size(380, 410)
        Label3.Text = AppointmentId

        queryTypes.Add("Type 1")
        queryTypes.Add("Type 2")
        queryTypes.Add("Type 3")

        ' Add query types from the list to the ComboBox
        For Each queryType As String In queryTypes
            ComboBox1.Items.Add(queryType)
        Next

        BackButton.Font = New Font(SessionManager.font_family, 11, FontStyle.Regular)
        BackButton.BackColor = ColorTranslator.FromHtml("#F9754B")
        BackButton.Size = New Size(67, 25)
        BackButton.Location = New Point(1067, 75)
        BackButton.FlatAppearance.BorderSize = 0
        BackButton.ForeColor = ColorTranslator.FromHtml("#FFFFFF")

    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Query sent.")
        RemovePreviousForm()

        If (SessionManager.userType = "Customer") Then
            With AppointmentList_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(AppointmentList_Customer)
                .BringToFront()
                .Show()
            End With
        Else
            With AppointmentList_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(AppointmentList_SP)
                .BringToFront()
                .Show()
            End With
        End If

    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        RemovePreviousForm()

        If (SessionManager.userType = "Customer") Then
            With AppointmentList_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(AppointmentList_Customer)
                .BringToFront()
                .Show()
            End With
        Else
            With AppointmentList_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(AppointmentList_SP)
                .BringToFront()
                .Show()
            End With
        End If

    End Sub

End Class