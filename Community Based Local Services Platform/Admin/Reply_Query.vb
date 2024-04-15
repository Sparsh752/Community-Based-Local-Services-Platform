Public Class Reply_Query
    Public title = ""
    Public description = ""
    Public status = ""


    Private Sub Reply_Query_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = title
        Label2.Text = status
        Label3.Text = description
    End Sub
End Class