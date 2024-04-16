Imports System.ComponentModel
Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify
Imports Google.Protobuf.WellKnownTypes

Public Class AppointmentList_Customer
    Private datalist As New List(Of String)()
    Private labels As New List(Of String)()
    Dim sp_list As New List(Of SP)()

    Public Class SP
        Public Property spID As Integer
        Public Property sp_userID As Integer
        Public Property appointmentID As Integer
        Public Property Status As String
        Public Property Index As Integer

        Public Sub New(ByVal index As Integer, ByVal spID As Integer, ByVal appointmentID As Integer, ByVal status As String, ByVal sp_userID As Integer)
            Me.spID = spID
            Me.Index = index
            Me.Status = status
            Me.appointmentID = appointmentID
            Me.sp_userID = sp_userID
        End Sub
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SessionManager.customerID = SessionManager.userID

        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None
        TableLayoutPanel1.Hide()
        TableLayoutPanel1.Size = New Size(900, 600)
        TableLayoutPanel1.Location = New Point(150, 200)
        ' Call the method to add labels to TableLayoutPanel

        AddLabelsToTableLayoutPanel()
        TableLayoutPanel1.Show()
        TableLayoutPanel1.HorizontalScroll.Visible = False
        TableLayoutPanel1.HorizontalScroll.Enabled = False
        TableLayoutPanel1.AutoScroll = True

    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint
        Dim panel As TableLayoutPanel = DirectCast(sender, TableLayoutPanel)
        Dim g As Graphics = e.Graphics
        Dim pen As New Pen(Color.Black, 1) ' Adjust the width as needed
        ' Draw border for background
        g.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1)
        Dim rowTop As Integer = panel.Padding.Top
        For i As Integer = 0 To panel.RowCount - 1
            Dim rowHeight As Integer = panel.GetRowHeights()(i)
            Dim rowBottom As Integer = rowTop + rowHeight
            g.DrawRectangle(pen, panel.Padding.Left, rowTop, panel.Width - panel.Padding.Horizontal, rowHeight)
            g.DrawRectangle(pen, panel.Padding.Left, rowBottom, panel.Width - panel.Padding.Horizontal, 0) ' Draw bottom border
            rowTop = rowBottom
        Next
        Dim lastRowBottom As Integer = panel.Height
        g.DrawRectangle(pen, panel.Padding.Left, lastRowBottom, panel.Width - panel.Padding.Horizontal, 0)

        ' Draw borders for columns
        Dim columnLeft As Integer = panel.Padding.Left
        For i As Integer = 0 To panel.ColumnCount - 1
            Dim columnWidth As Integer = panel.GetColumnWidths()(i)
            g.DrawRectangle(pen, columnLeft, panel.Padding.Top, columnWidth, panel.Height - panel.Padding.Vertical)
            columnLeft += columnWidth
        Next

        ' Dispose of the pen object to release resources
        pen.Dispose()
    End Sub

    Private Sub AddLabelsToTableLayoutPanel()

        Dim query As String = "SELECT appointments.appointmentID, 
                serviceproviders.serviceProviderName, 
                serviceproviders.serviceProviderID,
                serviceproviders.userID,
                serviceTypes.serviceTypeName, 
                serviceAreaTimeslots.startTime, 
                serviceAreaTimeslots.timeslotDate,
                appointments.appointmentStatus 
                FROM appointments 
                JOIN serviceproviders 
                ON appointments.serviceProviderID = serviceproviders.serviceProviderID 
                JOIN serviceAreaTimeslots 
                ON appointments.areaTimeslotID = serviceAreaTimeslots.areaTimeslotID 
                JOIN serviceTypes 
                ON serviceAreaTimeslots.serviceTypeID = serviceTypes.serviceID 
                WHERE appointments.customerID = @UserID"

        Dim count As Integer = 1

        ' Create a new SQL connection
        Using connection As New MySqlConnection(SessionManager.connectionString)
            ' Open the connection
            connection.Open()

            ' Create a new SQL command
            Using command As New MySqlCommand(query, connection)
                ' Set the parameter value for UserID
                command.Parameters.AddWithValue("@UserID", SessionManager.userID)

                ' Execute the SQL command and create a data reader
                Using reader As MySqlDataReader = command.ExecuteReader()
                    ' Create a list to hold the labels data
                    Dim labels As New List(Of String)()

                    ' Read data from the reader
                    While reader.Read()
                        ' Add data to the list
                        datalist.Add(reader("appointmentID").ToString())
                        datalist.Add(reader("serviceProviderName").ToString())
                        datalist.Add(reader("serviceTypeName").ToString())
                        Dim startTime As String = reader("startTime").ToString()
                        Dim timeslotDate As String = CType(reader("timeslotDate"), Date).ToString("dd-MMM-yyyy")

                        Dim combinedDateTime As String = $"{timeslotDate} {startTime}"


                        datalist.Add(combinedDateTime)
                        'datalist.Add(reader("startTime").ToString())
                        datalist.Add(reader("appointmentStatus").ToString())

                        Dim spID As Integer = CInt(reader("serviceProviderID"))
                        Dim status As String = reader("appointmentStatus")
                        Dim appointmentID As Integer = CInt(reader("appointmentID"))
                        Dim sp_userID As Integer = CInt(reader("userID"))

                        Dim new_sp As New SP(count, spID, appointmentID, status, sp_userID)
                        sp_list.Add(new_sp)
                        count = count + 1

                        datalist.Add("view")
                        datalist.Add("query")
                    End While


                End Using
            End Using
        End Using

        ' Convert the list to an array
        ' Convert the list to an array
        labels = datalist
        ' Determine the number of rows needed based on the labels array size
        Dim rowCount As Integer = labels.Count \ TableLayoutPanel1.ColumnCount
        If labels.Count Mod TableLayoutPanel1.ColumnCount <> 0 Then
            rowCount += 1 ' Add an extra row if there are leftover labels
        End If

        ' Set the RowCount property of the TableLayoutPanel
        rowCount = rowCount + 1
        TableLayoutPanel1.RowCount = rowCount
        TableLayoutPanel1.Height = 40 * rowCount
        TableLayoutPanel1.RowCount = rowCount

        ' Set the row styles to be absolute 40 pixels
        TableLayoutPanel1.RowStyles.Clear()
        For i As Integer = 0 To rowCount - 1
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        Next

        ' Add labels to the TableLayoutPanel
        ' Set the row styles to be absolute 40 pixels
        TableLayoutPanel1.RowStyles.Clear()
        For i As Integer = 0 To rowCount - 1
            TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        Next

        ' Clear any existing controls in the TableLayoutPanel
        TableLayoutPanel1.Controls.Clear()

        ' Add labels and buttons to the TableLayoutPanel
        For i As Integer = 0 To rowCount - 1
            For j As Integer = 0 To TableLayoutPanel1.ColumnCount - 1


                If i = 0 Then
                    ' Add column labels and paint the cell background
                    Dim columnLabel As New Label()
                    If j = 0 Then
                        columnLabel.Text = "Appointment ID"
                    ElseIf j = 1 Then
                        columnLabel.Text = "Service Provider"
                    ElseIf j = 2 Then
                        columnLabel.Text = "Service Category"
                    ElseIf j = 3 Then
                        columnLabel.Text = "Slot"
                    ElseIf j = 4 Then
                        columnLabel.Text = "Status"
                    End If

                    columnLabel.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
                    columnLabel.ForeColor = Color.White
                    columnLabel.AutoSize = True
                    columnLabel.TextAlign = ContentAlignment.MiddleCenter
                    columnLabel.BackColor = ColorTranslator.FromHtml("#F9754B")
                    ' Dock the label to fill the cell vertically
                    columnLabel.Anchor = AnchorStyles.None
                    columnLabel.Dock = DockStyle.Fill
                    columnLabel.Margin = New Padding(0)
                    TableLayoutPanel1.Controls.Add(columnLabel, j, i)


                Else

                    Dim index As Integer = (i - 1) * (TableLayoutPanel1.ColumnCount) + j
                    If index < labels.Count Then
                        If j = TableLayoutPanel1.ColumnCount - 1 Then
                            Dim button As New Button()
                            button.BackgroundImage = My.Resources.Resource1.query
                            button.Height = 21
                            button.FlatStyle = FlatStyle.Flat
                            button.Anchor = AnchorStyles.None ' Center button horizontally and vertically
                            button.Width = 82
                            button.Tag = i
                            AddHandler button.Click, AddressOf QueryButton_Click
                            TableLayoutPanel1.Controls.Add(button, j, i)
                        ElseIf j = TableLayoutPanel1.ColumnCount - 2 Then
                            Dim button As New Button()
                            button.BackgroundImage = My.Resources.Resource1.view
                            button.Height = 21
                            button.FlatStyle = FlatStyle.Flat
                            button.Anchor = AnchorStyles.None ' Center button horizontally and vertically
                            button.Width = 57
                            button.Padding = New Padding(0)
                            button.Tag = i
                            button.FlatAppearance.BorderColor = Color.White
                            AddHandler button.Click, AddressOf ViewButton_Click
                            TableLayoutPanel1.Controls.Add(button, j, i)
                        Else
                            ' Add label in other columns
                            Dim label As New Label()
                            label.Text = labels(index)
                            label.Font = New Font("Bahnschrift Light", 10, FontStyle.Regular)
                            label.ForeColor = Color.Black
                            label.Padding = New Padding(0, 0, 0, 0)
                            label.AutoSize = True
                            label.TextAlign = ContentAlignment.MiddleCenter
                            label.Anchor = AnchorStyles.None

                            label.TextAlign = ContentAlignment.MiddleCenter

                            TableLayoutPanel1.Controls.Add(label, j, i)
                            label.SendToBack()
                        End If
                    End If
                End If

            Next
        Next
    End Sub

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
        End If
    End Sub

    ' Event handler for view button click
    Private Sub ViewButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)
        Dim status As String
        Dim _spID As Integer
        Dim _appointmentID As Integer
        Dim _sp_userID As Integer

        'MessageBox.Show(button.Tag)

        For Each _sp In sp_list
            If (_sp.Index = CInt(button.Tag)) Then
                status = _sp.Status
                _spID = _sp.spID
                _appointmentID = _sp.appointmentID
                _sp_userID = _sp.sp_userID
            End If
        Next

        SessionManager.spID = _spID
        SessionManager.appointmentID = _appointmentID
        SessionManager.sp_userID = _sp_userID

        'MessageBox.Show(SessionManager.appointmentID & " " & SessionManager.customerID & " " & SessionManager.spID & " " & status)

        RemovePreviousForm()
        Me.Close()

        If (status = "Scheduled") Then
            With InProgressPaymentNotDone
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(InProgressPaymentNotDone)
                Dim query As String =
                "SELECT appointments.appointmentID, 
                serviceproviders.serviceProviderName, 
                serviceTypes.serviceTypeName, 
                serviceAreaTimeslots.startTime, 
                contactDetails.mobileNumber,
                serviceAreas.location,
                services.price,
                services.serviceID,
                appointments.bookingAdvance,
                serviceAreaTimeslots.timeslotDate,
                appointments.appointmentStatus 
                FROM appointments 
                JOIN serviceproviders 
                ON appointments.serviceProviderID = serviceproviders.serviceProviderID 
                JOIN serviceAreaTimeslots 
                ON appointments.areaTimeslotID = serviceAreaTimeslots.areaTimeslotID 
                JOIN contactDetails 
                ON contactDetails.UserID = serviceproviders.userID
                JOIN serviceAreas 
                ON serviceAreas.areaID = serviceAreaTimeslots.areaID
                JOIN services
                ON services.serviceTypeID = serviceAreaTimeslots.serviceTypeID
                AND services.serviceProviderID = serviceAreaTimeslots.serviceProviderID 
                JOIN serviceTypes 
                ON serviceAreaTimeslots.serviceTypeID = serviceTypes.serviceID 
                WHERE appointments.customerID = @customerID
                AND appointments.appointmentID = @appointmentID"
                ' Create a new SQL connection
                Using connection As New MySqlConnection(SessionManager.connectionString)
                    ' Open the connection
                    connection.Open()

                    ' Create a new SQL command
                    Using command As New MySqlCommand(query, connection)
                        ' Set the parameter value for UserID
                        command.Parameters.AddWithValue("@customerID", SessionManager.customerID)
                        command.Parameters.AddWithValue("@appointmentID", SessionManager.appointmentID)

                        ' Execute the SQL command and create a data reader
                        Using reader As MySqlDataReader = command.ExecuteReader()
                            ' Create a list to hold the labels data
                            Dim labels As New List(Of String)()

                            ' Read data from the reader
                            If reader.Read() Then

                                Dim sp_name As String = reader("serviceProviderName").ToString()
                                Dim sp_service As String = reader("serviceTypeName").ToString()
                                Dim sp_date As String = reader("timeslotDate").ToString()
                                Dim dateObject As DateTime = DateTime.ParseExact(sp_date, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture)

                                ' Format the DateTime object to display only the date
                                Dim formattedDate As String = dateObject.ToString("dd-MM-yyyy")
                                Dim appoinment_slot As String = reader("startTime").ToString()
                                Dim sp_num As String = reader("mobileNumber").ToString()
                                Dim sp_loc As String = reader("location").ToString()
                                Dim sp_price As String = reader("price").ToString()
                                Dim sp_adv As String = reader("bookingAdvance").ToString()
                                Dim serviceID As String = reader("serviceID").ToString()
                                ' Set the retrieved values to the corresponding textboxes
                                InProgressPaymentNotDone.SP_name_tb.Text = sp_name
                                InProgressPaymentNotDone.SP_service_tb.Text = sp_service
                                InProgressPaymentNotDone.Booked_slot_tb.Text = formattedDate + "  " + appoinment_slot
                                InProgressPaymentNotDone.SP_contactno.Text = sp_num
                                InProgressPaymentNotDone.SP_loc.Text = sp_loc
                                InProgressPaymentNotDone.SP_price.Text = sp_price
                                InProgressPaymentNotDone.advpaid.Text = sp_adv
                                InProgressPaymentNotDone.rembal.Text = sp_price - sp_adv
                                InProgressPaymentNotDone._serviceID = serviceID
                            End If
                        End Using
                    End Using
                End Using

                .BringToFront()
                .Show()
            End With
        ElseIf (status = "Completed") Then
            With TransactionComplete_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(TransactionComplete_Customer)
                .BringToFront()
                .Show()
            End With
        ElseIf (status = "Canceled") Then
            With Cancelled_By_Customer
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(Cancelled_By_Customer)
                .BringToFront()
                .Show()
            End With
        ElseIf (status = "Rejected") Then
            With Rejected_View
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(Rejected_View)
                .BringToFront()
                .Show()
            End With
        ElseIf (status = "Pending") Then
            With Rejected_View
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(Rejected_View)
                .BringToFront()
                .Show()
            End With
        End If
    End Sub

    Private Sub QueryButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)
        Dim status As String
        Dim _spID As Integer
        Dim _appointmentID As Integer

        For Each _sp In sp_list
            If (_sp.Index = CInt(button.Tag)) Then
                status = _sp.Status
                _spID = _sp.spID
                _appointmentID = _sp.appointmentID
            End If
        Next

        SessionManager.spID = _spID
        SessionManager.appointmentID = _appointmentID

        RemovePreviousForm()
        With Query_3SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Query_3SP)
            .BringToFront()
            .Show()
        End With
    End Sub

End Class