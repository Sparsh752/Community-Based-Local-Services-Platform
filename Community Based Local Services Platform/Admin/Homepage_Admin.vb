Public Class Homepage_Admin
    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If SessionManager.Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            SessionManager.Panel3.Controls.Clear()
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        RemovePreviousForm()
        All_Queries.Margin = New Padding(10, 10, 10, 10)
        With All_Queries
            .TopLevel = False
            SessionManager.Panel3.Controls.Add(All_Queries)
            .BringToFront()
            .Show()
        End With
    End Sub
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

    Private Sub Homepage_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        DataGridView1.DefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        LinkLabel1.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel2.LinkBehavior = LinkBehavior.NeverUnderline
        LinkLabel3.LinkBehavior = LinkBehavior.NeverUnderline
        PictureBox1.Size = New Size(140, 140)
        PictureBox2.Size = New Size(140, 140)
        PictureBox3.Size = New Size(140, 140)
        PictureBox4.Size = New Size(140, 140)
        PictureBox1.Image = My.Resources.Resource1.sample_SP
        PictureBox2.Image = My.Resources.Resource1.sample_SP
        PictureBox3.Image = My.Resources.Resource1.sample_SP
        PictureBox4.Image = My.Resources.Resource1.sample_SP
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox4.BackgroundImageLayout = ImageLayout.Stretch

        ' Subscribe to the CellContentClick event of the DataGridView
        AddHandler DataGridView1.CellContentClick, AddressOf DataGridView1_CellContentClick
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        RemovePreviousForm()
        Registration_Request.Margin = New Padding(0, 0, 0, 0)
        With Registration_Request
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(Registration_Request)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        RemovePreviousForm()
        Registration_Request.Margin = New Padding(0, 0, 0, 0)
        With Registration_Request
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(Registration_Request)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Check if the clicked cell is the "View" button column
        If e.ColumnIndex = DataGridView1.Columns("View").Index AndAlso e.RowIndex >= 0 Then
            ' Handle the "View" button click for the specific row
            Dim appointmentId As String = DataGridView1.Rows(e.RowIndex).Cells("AppointmentID").Value.ToString()
            ' You can perform actions based on the appointment ID, such as opening a new form or displaying details
            ' Check if a Reply_Query form is already open
            For Each form As Form In Application.OpenForms
                If TypeOf form Is Reply_Query Then
                    form.Close()
                    Exit For ' Exit loop once a form is closed
                End If
            Next

            Dim Reply As New Reply_Query()
            Reply.Show()
        End If
    End Sub


End Class