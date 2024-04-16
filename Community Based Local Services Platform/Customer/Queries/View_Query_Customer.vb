Public Class View_Query_Customer
    Public QueryID As Integer
    Dim AppointmentID As Integer
    Dim UserID As Integer

    Private Sub View_Query_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using conn As New MySqlConnection(SessionManager.connectionString)
            Try
                conn.Open()
                Dim query As String = "SELECT * FROM AddressQueries WHERE queryID = @queryid"
                Dim command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@queryid", QueryID)
                Dim reader As MySqlDataReader = command.ExecuteReader()

                While reader.Read()
                    Label1.Text = "# " & QueryID
                    Label2.Text = Convert.ToString(reader("description"))
                    TextBox1.Text = Convert.ToString(reader("reply"))
                    Label4.Text = Convert.ToDateTime(reader("queryDate")).ToString("g")
                End While

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class