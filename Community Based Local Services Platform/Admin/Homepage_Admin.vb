Public Class Homepage_Admin
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim form2 As New All_Queries()
        form2.Show()
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
    End Sub
End Class