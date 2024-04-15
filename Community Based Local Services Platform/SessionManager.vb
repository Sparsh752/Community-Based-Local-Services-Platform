Module SessionManager
    Public font_family As String = "Bahnschrift Light"
    Public userType As String
    Public userID As String
    Public Panel3 As New Panel()
    Public connectionString As String = "server=172.16.114.199;userid=admin;password=istrator;database=communityservice;sslmode=none"
    'Public connectionString As String = "server=localhost;userid=root;database=communityservice;sslmode=none"
    Public mailVerified As Boolean = False
    Public userEmail As String
    Public customerID As Integer
    Public spID As Integer
    Public appointmentID As Integer
    Public sp_userID As Integer ' for userID from service provider table
    Public serviceID As Integer
    Public notificationsCleared As Boolean = False ' for clearing notifications the entire session
    Public notificationCount As Integer = 0 ' Variable to store the notification count

    Public Sub GetNotificationCount()
        ' Query to get the notification count
        Dim query As String = "SELECT COUNT(*) FROM notifications WHERE userID = '" & userID & "'"

        Using connection As New MySqlConnection(connectionString)
            Using command As New MySqlCommand(query, connection)
                Try
                    connection.Open()
                    ' Execute the query
                    Dim count As Object = command.ExecuteScalar()
                    If count IsNot Nothing AndAlso IsNumeric(count) Then
                        ' Set the notification count
                        notificationCount = Convert.ToInt32(count)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub



End Module
