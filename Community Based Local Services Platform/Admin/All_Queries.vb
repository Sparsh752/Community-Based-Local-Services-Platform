Public Class All_Queries
    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 AndAlso e.ColumnIndex <= 5 Then
            ' Draw cell border
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            ' Draw right border
            Dim rectRight As New Rectangle(e.CellBounds.Right - 1, e.CellBounds.Top, 1, e.CellBounds.Height)
            e.Graphics.FillRectangle(Brushes.Black, rectRight)

            ' Draw bottom border
            Dim rectBottom As New Rectangle(e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Width, 1)
            e.Graphics.FillRectangle(Brushes.Black, rectBottom)

            e.Handled = True
        End If
    End Sub
    Private Sub All_Queries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        Me.FormBorderStyle = FormBorderStyle.None
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        DataGridView1.DefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        Me.Size = New Size(1200, 700)
        DataGridView1.Location = New Point(0, 0)
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