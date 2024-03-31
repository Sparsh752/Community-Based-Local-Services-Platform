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
        All_Queries.Margin = New Padding(0, 0, 0, 0)
        With All_Queries
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(All_Queries)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Homepage_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
        DataGridView1.Rows.Add("1", "John", "30", "1", "John", "30")
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
End Class