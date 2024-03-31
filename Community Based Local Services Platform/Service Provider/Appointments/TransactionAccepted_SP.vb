Public Class TransactionAccepted_SP
    Private ServiceProviderName As String
    Private ServiceProviderAddress As String
    Private ServiceProviderPhone As String
    Private ServiceName As String
    Private Price As String
    Private BookedSlot As String
    Private Location As String
    Private Sub TransactionAccepted_SP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ServiceProviderName = "Customer XYZ"
        ServiceProviderAddress = "123 Example St, City"
        ServiceProviderPhone = "123-456-7890"
        ServiceName = "Example Service"
        Price = "$50"
        BookedSlot = "Monday, 9:00 AM"
        Location = "Example Location"

        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None

        Label5.Text = ServiceProviderName
        Label6.Text = ServiceProviderAddress
        Label7.Text = ServiceProviderPhone
        Label8.Text = ServiceName
        Label9.Text = Price
        Label10.Text = BookedSlot
        Label11.Text = Location

        LoadChatPanel()

    End Sub

    Private Sub LoadChatPanel()

        Dim chatPanel As New Panel()
        chatPanel.Location = New Point(687, 125)
        chatPanel.Size = New Size(437, 490)
        chatPanel.BorderStyle = BorderStyle.FixedSingle
        chatPanel.BackColor = Color.White

        Me.Controls.Add(chatPanel)

        With ChatBox
            .TopLevel = False
            .Dock = DockStyle.Fill
            chatPanel.Controls.Add(ChatBox)
            .BringToFront()
            .Show()
        End With

    End Sub

End Class