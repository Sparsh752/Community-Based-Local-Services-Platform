Public Class All_Queries
    Private Sub All_Queries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Location = New Point(0, 65)
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")

        ' Subscribe to the CellContentClick event of the DataGridView
        AddHandler DataGridView1.CellContentClick, AddressOf DataGridView1_CellContentClick
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Check if the clicked cell is the "View" button column
        If e.ColumnIndex = DataGridView1.Columns("View").Index AndAlso e.RowIndex >= 0 Then
            ' Handle the "View" button click for the specific row
            Dim appointmentId As String = DataGridView1.Rows(e.RowIndex).Cells("AppointmentID").Value.ToString()
            ' You can perform actions based on the appointment ID, such as opening a new form or displaying details
            ' Check if a Reply_Query form is already open
            For Each form As Form In Application.OpenForms
                If TypeOf form Is Reply_Query Then
                    form.Close()
                    Exit For ' Exit loop once a form is closed
                End If
            Next

            Dim Reply As New Reply_Query()
            Reply.Show()
        End If
    End Sub
End Class