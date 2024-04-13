Public Class Profile_Customer

    Private Sub RemovePreviousForm()
        ' Check if any form is already in Panel5
        If SessionManager.Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            SessionManager.Panel3.Controls.Clear()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RemovePreviousForm()
        Edit_Profile_Customer.Margin = New Padding(0, 0, 0, 0)
        With Edit_Profile_Customer
            .TopLevel = False
            .Dock = DockStyle.Fill
            SessionManager.Panel3.Controls.Add(Edit_Profile_Customer)
            .BringToFront()
            .Show()

        End With
    End Sub
End Class