﻿Public Class Queries_Customer

    Private Sub DataGridView1_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
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

    Private Sub Queries_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DataGridView1.ColumnCount = 6 ' Set the number of columns to 4

        DataGridView1.Columns(0).HeaderText = "Query Type"
        DataGridView1.Columns(1).HeaderText = "Appointment ID"
        DataGridView1.Columns(2).HeaderText = "Query Date"
        DataGridView1.Columns(3).HeaderText = "Description"
        DataGridView1.Columns(4).HeaderText = "Status"
        DataGridView1.Columns(5).HeaderText = ""

        Me.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        Me.FormBorderStyle = FormBorderStyle.None
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        DataGridView1.DefaultCellStyle.Font = New Font(SessionManager.font_family, 9, FontStyle.Regular)
        Me.Size = New Size(1200, 700)
        DataGridView1.Location = New Point(200, 120)

        DataGridView1.Size = New Size(800, 300)

        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")
        DataGridView1.Rows.Add("Payment", "123", "xyz", "xyz", "Pending")

        AddHandler DataGridView1.CellContentClick, AddressOf DataGridView1_CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

End Class