Imports System.Runtime.InteropServices
Public Class Navbar_Admin
    ' Method to highlight the active button
    Public Panel3 As New Panel()
    Public line As New Panel()
    
    Public NotificationButton As New Button()
    Public notificationForm As New Notification()
    Public NotificationCountLabel As New Label()
    Public NewnotificationCount As Integer = 0
    ' Import user32.dll for smooth scrolling
    <DllImport("user32.dll")>
    Public Shared Function AnimateWindow(hWnd As IntPtr, time As Integer, flags As AnimateWindowFlags) As Boolean
    End Function

    Public Enum AnimateWindowFlags As Integer
        AW_HOR_POSITIVE = &H1
        AW_HOR_NEGATIVE = &H2
        AW_VER_POSITIVE = &H4
        AW_VER_NEGATIVE = &H8
        AW_CENTER = &H10
        AW_HIDE = &H10000
        AW_ACTIVATE = &H20000
        AW_SLIDE = &H40000
        AW_BLEND = &H80000
    End Enum
    Private Sub Navbar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        line.BackColor = ColorTranslator.FromHtml("#F9754B")
        line.Size = New Size(52, 2)
        line.Location = New Point(954, 47)
        Panel1.Controls.Add(line)
        SessionManager.Panel3 = Panel3
        ' Highlight the Home button by default
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Panel1.BackColor = ColorTranslator.FromHtml("#0F2A37")


        NotificationButton.Size() = New Size(52, 30)
        NotificationButton.BackColor = ColorTranslator.FromHtml("#0F2A37")
        NotificationButton.Location = New Point(49, 18)
        NotificationButton.Text = "Notifications"
        NotificationButton.ForeColor = Color.White
        NotificationButton.Font = New Font("Bahnschrift Bold", 11, FontStyle.Regular)
        NotificationButton.FlatStyle = FlatStyle.Flat
        NotificationButton.FlatAppearance.BorderSize = 0
        NotificationButton.Padding = New Padding(0, 0, 0, 0)
        NotificationButton.TextAlign = ContentAlignment.MiddleCenter
        NotificationButton.AutoSize = True

        Panel1.Controls.Add(NotificationButton)
        AddHandler NotificationButton.Click, AddressOf NotificationButton_Click

        Dim NotificationIcon As New PictureBox With {
            .BackgroundImage = My.Resources.Resource1.notification_icon,
            .Location = New Point(155, 25),
            .Name = "NotificationIcon",
            .Size = New Size(17, 18),
            .TabIndex = 1,
            .TabStop = False
        }
        Panel1.Controls.Add(NotificationIcon)


        NotificationCountLabel.Size = New Size(14, 14)
        NotificationCountLabel.Location = New Point(NotificationIcon.Right - 4, NotificationIcon.Top)
        NotificationCountLabel.ForeColor = Color.Black
        NotificationCountLabel.BackColor = Color.White
        NotificationCountLabel.TextAlign = ContentAlignment.MiddleCenter
        NotificationCountLabel.Font = New Font("Bahnschrift Bold", 6, FontStyle.Regular)
        Dim path As New System.Drawing.Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, NotificationCountLabel.Width, NotificationCountLabel.Height)
        NotificationCountLabel.Region = New Region(path)
        NotificationCountLabel.Visible = False
        Panel1.Controls.Add(NotificationCountLabel)


        ' Check if notifications exist and get the notification count
        SessionManager.GetNotificationCount()

        ' Show or hide the dot image based on the notification count
        ShowHideNotificationDot()

        Dim HomeButton As New Button()
        HomeButton.Size() = New Size(52, 30)

        HomeButton.BackColor = ColorTranslator.FromHtml("#0F2A37")
        HomeButton.Location = New Point(951, 18)
        HomeButton.Text = "Home"
        HomeButton.ForeColor = Color.White
        HomeButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        HomeButton.FlatStyle = FlatStyle.Flat
        HomeButton.FlatAppearance.BorderSize = 0
        HomeButton.Padding = New Padding(0, 0, 0, 0)
        HomeButton.TextAlign = ContentAlignment.MiddleCenter
        HomeButton.AutoSize = True

        Panel1.Controls.Add(HomeButton)

        AddHandler HomeButton.Click, AddressOf BtnHome_Click
        Me.Controls.Add(Panel3)
        Panel3.Size = New Size(1200, 700)
        Panel3.Location = New Point(0, 0)
        Panel3.BackColor = Color.White
        Panel3.Padding = New Padding(0, 0, 0, 0)

        RemovePreviousForm()

        'SetActiveForm(Homepage)
        Homepage_Admin.Margin = New Padding(0, 0, 0, 0)
        With Homepage_Admin
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Admin)
            .BringToFront()
            .Show()
        End With
    End Sub
    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
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
    Public Sub GetNewNotificationCount()
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
                        NewnotificationCount = Convert.ToInt32(count)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
    Private Sub ShowHideNotificationDot()
        ' Show or hide the dot image based on the notification count
        If SessionManager.notificationCount > 0 Then
            NotificationCountLabel.Visible = True
            NotificationCountLabel.Text = SessionManager.notificationCount
            NotificationCountLabel.BringToFront()
        Else
            NotificationCountLabel.Visible = False
        End If
    End Sub

    Private Sub ShowHideNewNotificationDot()
        ' Show or hide the dot image based on the notification count
        If NewnotificationCount > SessionManager.notificationCount Then
            NotificationCountLabel.Visible = True
            NotificationCountLabel.Text = NewnotificationCount
            'SessionManager.notificationCount = NewnotificationCount
            NotificationCountLabel.BringToFront()
        Else
            NotificationCountLabel.Visible = False
        End If
    End Sub

    Public isNotificationFormOpen As Boolean = False
    Private Sub NotificationButton_Click(sender As Object, e As EventArgs)

        If Not isNotificationFormOpen Then

            notificationForm = New Notification()
            ' Set the location of the Notification form to be just below the NotificationButton
            Dim xPosition As Integer = Me.Location.X + 45
            Dim yPosition As Integer = Me.Location.Y + 98

            notificationForm.StartPosition = FormStartPosition.Manual
            notificationForm.Location = New Point(xPosition, yPosition)

            ' Adjust the position of the CustomerForm to simulate scrolling
            'Dim formStartPosition As Point = Me.Location
            'Dim formEndPosition As Point = New Point(Me.Location.X, Me.Location.Y + NotificationButton.Location.Y + NotificationButton.Height)

            ' Show the Notification form with smooth scrolling effect
            AnimateWindow(notificationForm.Handle, 500, AnimateWindowFlags.AW_VER_POSITIVE Or AnimateWindowFlags.AW_SLIDE)
            notificationForm.Show()

            isNotificationFormOpen = True
        Else
            ' Reverse the scrolling animation to close the form

            ' Close the Notification form with smooth scrolling effect
            AnimateWindow(notificationForm.Handle, 500, AnimateWindowFlags.AW_VER_NEGATIVE Or AnimateWindowFlags.AW_SLIDE Or AnimateWindowFlags.AW_HIDE)
            notificationForm.Close()
            notificationForm.Dispose()
            isNotificationFormOpen = False
        End If

        ' Check if new notifications exist and get the notification count
        GetNewNotificationCount()

        ' Show or hide the dot image based on the notification count
        ShowHideNewNotificationDot()
    End Sub

    Private Sub BtnHome_Click(sender As Object, e As EventArgs)
        RemovePreviousForm()
        'SetActiveForm(Homepage)

        With Homepage_Admin
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Homepage_Admin)
            .BringToFront()
            .Show()
        End With

    End Sub
    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        ' here you have add the logic of reverting the state of shared variable for cureent user to null
        ' Whoever is doing the bankend part will do this part.
        RemovePreviousForm()
        Me.Hide()

        Dim form As New LandingPage()
        form.Show()

    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Ensure that the application exits when the main form is closed
        Application.Exit()
    End Sub
End Class