Public Class Query_3SP
    Private queryTypes As New List(Of String)()
    Public AppointmentId As String

    Private Sub Query_3SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AppointmentId = "1"
        Me.Size = New Size(1200, 700)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White

        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Location = New Point(400, 100)
        Panel1.Size = New Size(380, 410)
        Label3.Text = SessionManager.appointmentID

        queryTypes.Add("Services")
        queryTypes.Add("Timings")
        queryTypes.Add("Payment")

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("Query sent.")



        ' Get the query entered by the user from RichTextBox1



        Try
                ' Create a MySqlConnection object
                Using connection As New MySqlConnection(SessionManager.connectionString)
                    ' Open the connection
                    connection.Open()

                    ' Define the SQL query to insert the query into AddressQueries table
                    Dim query As String = "INSERT INTO AddressQueries (appointmentID, userID, type, description, queryDate) VALUES (@appointmentID, @userID, @type, @query, NOW());"

                    ' Create a MySqlCommand object
                    Using command As New MySqlCommand(query, connection)
                        ' Set the parameters
                        command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID) ' Replace Your_UserID with the actual user ID
                        command.Parameters.AddWithValue("@userID", SessionManager.userID) ' Replace Your_UserID with the actual user ID
                        command.Parameters.AddWithValue("@type", ComboBox1.SelectedItem.ToString())
                    command.Parameters.AddWithValue("@query", RichTextBox1.Text)

                    ' Execute the command
                    command.ExecuteNonQuery()

                        ' Display a success message
                        MessageBox.Show("Query inserted successfully.")
                    End Using
                End Using
            Catch ex As Exception
                ' Display an error message if an exception occurs
                MessageBox.Show("Error: " & ex.Message)
            End Try

            RemovePreviousForm()
            Me.Close()

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
        Me.Close()

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