Public Class All_Queries
    Public Queries As DataTable = New DataTable()
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
    
    Private Sub RetrieveQueries()
        Dim connection As New MySqlConnection(SessionManager.connectionString)

        Try
            connection.Open()
            ' Connection established successfully

            Dim query As String = $"SELECT queryID AS QueryID, type AS QueryType, userID AS QueryBy, appointmentID as AppointmentID, queryDate AS QueryDate, description AS Description, status AS Status FROM AddressQueries as aq ORDER BY queryDate DESC;"
            Dim command As New MySqlCommand(query, connection)

            Dim reader As MySqlDataReader = command.ExecuteReader()
            Queries.Load(reader)
            reader.Close()

        Catch ex As Exception
            ' Handle connection errors
            MessageBox.Show("Error connecting to MySQL: " & ex.Message)
        Finally
            connection.Close()
        End Try

    End Sub

    Private Sub All_Queries_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.White
        Me.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        Me.FormBorderStyle = FormBorderStyle.None
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        DataGridView1.DefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        Me.Size = New Size(1200, 700)
        DataGridView1.Location = New Point(0, 0)

        RetrieveQueries()
        For i As Integer = 1 To Queries.Rows.Count
            Dim ithRow As DataRow = Queries.Rows(i - 1)
            Dim queryID As String = ithRow("QueryID").ToString()
            Dim queryType As String = ithRow("QueryType").ToString()
            Dim queryBy As String = ithRow("QueryBy").ToString()
            Dim appointmentID As String = ithRow("AppointmentID").ToString()
            Dim queryDate As String = ithRow("QueryDate").ToString()
            Dim description As String = ithRow("Description").ToString()
            Dim status As String = ithRow("Status").ToString()
            DataGridView1.Rows.Add(queryID, queryType, queryBy, appointmentID, queryDate, status)
        Next
        ' Subscribe to the CellContentClick event of the DataGridView
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
                If TypeOf form Is Reply_Query Then
                    form.Close()
                    Exit For ' Exit loop once a form is closed
                End If
            Next

            Dim Reply As New Reply_Query()
            Reply.QueryID = queryId
            Reply.Show()
        End If
    End Sub
End Class