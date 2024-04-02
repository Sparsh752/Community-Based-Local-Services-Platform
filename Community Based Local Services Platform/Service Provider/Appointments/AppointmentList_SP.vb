Public Class AppointmentList_SP
    Dim labels() As String = {"12354", "Interior design", "23-Feb-2024 09:00", "Guwahati", "Pending", "link", "link", "12354", "Interior design", "23-Feb-2024 09:00", "Guwahati", "Scheduled", "link", "link",
        "12354", "Interior design", "23-Feb-2024 09:00", "Guwahati", "Completed", "link", "link", "12354", "Interior design", "23-Feb-2024 09:00", "Guwahati", "Rejected", "link", "link", "12354", "Interior design", "23-Feb-2024 09:00", "Guwahati", "Canceled", "link", "link"}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1200, 700)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.None
        TableLayoutPanel1.Hide()
        ' Call the method to add labels to TableLayoutPanel
        AddLabelsToTableLayoutPanel()
        TableLayoutPanel1.Show()

    End Sub
    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint
        Dim panel As TableLayoutPanel = DirectCast(sender, TableLayoutPanel)
        Dim g As Graphics = e.Graphics
        Dim pen As New Pen(Color.Black, 1)

        g.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1)
        Dim rowTop As Integer = panel.Padding.Top
        For i As Integer = 0 To panel.RowCount - 1
            Dim rowHeight As Integer = panel.GetRowHeights()(i)
            Dim rowBottom As Integer = rowTop + rowHeight
            g.DrawRectangle(pen, panel.Padding.Left, rowTop, panel.Width - panel.Padding.Horizontal, rowHeight)
            g.DrawRectangle(pen, panel.Padding.Left, rowBottom, panel.Width - panel.Padding.Horizontal, 0) ' Draw bottom border
            rowTop = rowBottom
        Next
        Dim lastRowBottom As Integer = panel.Height - panel.Padding.Bottom
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


        ' Determine the number of rows needed based on the labels array size
        Dim rowCount As Integer = labels.Length \ TableLayoutPanel1.ColumnCount
        If labels.Length Mod TableLayoutPanel1.ColumnCount <> 0 Then
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
                        columnLabel.Text = "Service"
                    ElseIf j = 2 Then
                        columnLabel.Text = "Slot"
                    ElseIf j = 3 Then
                        columnLabel.Text = "Location"
                    ElseIf j = 4 Then
                        columnLabel.Text = "Status"
                    End If
                    columnLabel.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular
                                                )
                    columnLabel.ForeColor = Color.White
                    columnLabel.AutoSize = True
                    columnLabel.TextAlign = ContentAlignment.MiddleCenter
                    columnLabel.BackColor = ColorTranslator.FromHtml("#F9754B")
                    ' Dock the label to fill the cell vertically
                    columnLabel.Anchor = AnchorStyles.Left
                    columnLabel.Dock = DockStyle.Fill
                    columnLabel.Margin = New Padding(0)
                    TableLayoutPanel1.Controls.Add(columnLabel, j, i)
                Else

                    Dim index As Integer = (i - 1) * (TableLayoutPanel1.ColumnCount) + j
                    If index < labels.Length Then
                        If j = TableLayoutPanel1.ColumnCount - 1 Then
                            ' Add button instead of label in the last column
                            Dim button As New Button()
                            button.BackgroundImage = My.Resources.Resource1.query
                            button.FlatStyle = FlatStyle.Flat
                            button.Height = 21
                            button.Anchor = AnchorStyles.None ' Center button horizontally and vertically
                            button.Width = 82
                            'button.BackColor = Color.White
                            'button.Margin = New Padding(0)
                            'button.Padding = New Padding(0)
                            button.Tag = labels(index - 2)
                            AddHandler button.Click, AddressOf QueryButton_Click
                            TableLayoutPanel1.Controls.Add(button, j, i)
                        ElseIf j = TableLayoutPanel1.ColumnCount - 2 Then
                            ' Add button instead of label in the last but one column
                            Dim button As New Button()
                            button.BackgroundImage = My.Resources.Resource1.view
                            button.FlatStyle = FlatStyle.Flat
                            button.Height = 21
                            button.Anchor = AnchorStyles.None ' Center button horizontally and vertically
                            button.Width = 57
                            button.Padding = New Padding(0)
                            button.Tag = labels(index - 1)
                            button.FlatAppearance.BorderColor = Color.White
                            AddHandler button.Click, AddressOf ViewButton_Click
                            TableLayoutPanel1.Controls.Add(button, j, i)
                        Else
                            ' Add label in other columns
                            Dim label As New Label()
                            label.Text = labels(index)
                            label.Font = New Font("Bahnschrift Light", 9, FontStyle.Regular)
                            label.Padding = New Padding(0, 0, 0, 0)
                            label.AutoSize = True
                            label.Anchor = AnchorStyles.None
                            label.TextAlign = ContentAlignment.MiddleCenter ' Center text horizontally and vertically
                            label.SendToBack()

                            TableLayoutPanel1.Controls.Add(label, j, i)

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
        Dim status As String = button.Tag

        If (status = "Pending") Then
            With PendingRequest_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(PendingRequest_SP)
                .BringToFront()
                .Show()
            End With
        ElseIf (status = "Scheduled") Then
            With TransactionAccepted_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(TransactionAccepted_SP)
                .BringToFront()
                .Show()
            End With
        ElseIf (status = "Completed") Then
            With ServiceComplete_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(ServiceComplete_SP)
                .BringToFront()
                .Show()
            End With
        ElseIf (status = "Canceled") Then
            With CanceledView_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(CanceledView_SP)
                .BringToFront()
                .Show()
            End With
        ElseIf (status = "Rejected") Then
            With RejectedView_SP
                .TopLevel = False
                .Dock = DockStyle.Fill
                Panel3.Controls.Add(RejectedView_SP)
                .BringToFront()
                .Show()
            End With
        End If
    End Sub

    Private Sub QueryButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        RemovePreviousForm()
        With Query_3SP
            .TopLevel = False
            .Dock = DockStyle.Fill
            Panel3.Controls.Add(Query_3SP)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub
End Class
