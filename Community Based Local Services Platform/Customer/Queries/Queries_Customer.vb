Public Class Queries_Customer

    Public userID As String

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

    Private Sub Queries_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DataGridView1.ColumnCount = 6 ' Set the number of columns to 4
        Me.BackColor = Color.White
        DataGridView1.Columns(0).HeaderText = "Query ID"
        DataGridView1.Columns(1).HeaderText = "Type"
        DataGridView1.Columns(2).HeaderText = "Appointment ID"
        DataGridView1.Columns(3).HeaderText = "Query Date"
        DataGridView1.Columns(4).HeaderText = "Status"
        DataGridView1.Columns(5).HeaderText = ""

        DataGridView1.Columns(0).Name = "QueryID"
        DataGridView1.Columns(1).Name = "Type"
        DataGridView1.Columns(2).Name = "AppointmentID"
        DataGridView1.Columns(3).Name = "QueryDate"
        DataGridView1.Columns(4).Name = "Status"

        Me.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        Me.FormBorderStyle = FormBorderStyle.None
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        DataGridView1.DefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        Me.Size = New Size(1200, 700)
        DataGridView1.Location = New Point(200, 120)

        DataGridView1.Size = New Size(800, 300)

        Using conn As New MySqlConnection(SessionManager.connectionString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM AddressQueries where userID = @userID"
                Dim command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@userID", userID)
                Dim reader As MySqlDataReader = command.ExecuteReader()

                Dim FieldCount As Integer = 6

                While reader.Read()
                    Dim row(FieldCount) As String

                    row(0) = reader("queryID").ToString()
                    row(1) = reader("type").ToString()
                    row(2) = reader("appointmentID").ToString()
                    row(3) = reader("queryDate").ToString()
                    row(4) = reader("status").ToString()

                    DataGridView1.Rows.Add(row)
                End While

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using

        AddHandler DataGridView1.CellContentClick, AddressOf DataGridView1_CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Check if the clicked cell is the "View" button column
        If e.ColumnIndex = DataGridView1.Columns("View").Index AndAlso e.RowIndex >= 0 Then
            ' Handle the "View" button click for the specific row
            Dim appointmentId As String = DataGridView1.Rows(e.RowIndex).Cells("AppointmentID").Value.ToString()
            Dim queryId As String = DataGridView1.Rows(e.RowIndex).Cells("QueryID").Value.ToString()
            ' You can perform actions based on the appointment ID, such as opening a new form or displaying details
            ' Check if a Reply_Query form is already open
            For Each form As Form In Application.OpenForms
                If TypeOf form Is View_Query_Customer Then
                    form.Close()
                    Exit For ' Exit loop once a form is closed
                End If
            Next

            Dim Query As New View_Query_Customer()
            Query.QueryID = queryId
            Query.Show()
        End If
    End Sub

End Class