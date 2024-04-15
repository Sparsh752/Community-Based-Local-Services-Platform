Public Class Reply_Query
    Public QueryID As String
    Dim AppointmentID As Integer
    Dim UserID As Integer
    Public title = ""
    Public description = ""
    Public status = ""


    Private Sub RemovePreviousForm()
        For Each ctrl As Control In Panel3.Controls
            If TypeOf ctrl Is Form Then
                ' Remove the first control (form) from Panel5
                Dim formCtrl As Form = DirectCast(ctrl, Form)
                formCtrl.Close()
            End If
        Next

        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If

    End Sub

    Private Sub Reply_Query_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        title = Label1.Text
        description = Label2.Text
        status = "Pending"
    End Sub

    Private Sub Delete_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using conn As New MySqlConnection(SessionManager.connectionString)
            Try
                conn.Open()
                Dim query As String = "DELETE FROM AddressQueries WHERE queryID = @queryid"
                Dim command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@queryid", QueryID)
                command.ExecuteNonQuery()
                MessageBox.Show("Query deleted successfully!")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Me.Close()
        RemovePreviousForm()
        With Homepage_Admin
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Admin)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Resolve_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Enter a reply to the query")
            Return
        End If

        Dim reply = TextBox1.Text

        Using conn As New MySqlConnection(SessionManager.connectionString)
            Try
                conn.Open()
                Dim query As String = "UPDATE AddressQueries SET reply = @reply, status = 'Resolved', resolutionDate = NOW() WHERE queryID = @queryid"
                Dim command As New MySqlCommand(query, conn)
                command.Parameters.AddWithValue("@queryid", QueryID)
                command.Parameters.AddWithValue("@reply", reply)
                command.ExecuteNonQuery()
                MessageBox.Show("Query reply sent!")
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using

        Me.Close()
        RemovePreviousForm()
        With Homepage_Admin
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Admin)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class