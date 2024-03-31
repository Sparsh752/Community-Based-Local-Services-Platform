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
    End Sub
End Class