Module SessionManager
    Public font_family As String = "Bahnschrift Light"
    Public userType As String
    Public userID As String
    Public Panel3 As New Panel()
    Public connectionString As String = "server=172.16.114.199;userid=admin;password=istrator;database=communityservice;sslmode=none"
    'Public connectionString As String = "server=localhost;userid=root;database=communityservice;sslmode=none"
    Public mailVerified As Boolean = False
    Public userEmail As String
End Module
