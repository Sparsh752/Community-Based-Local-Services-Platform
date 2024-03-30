Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class ChatBox

    Dim messages As String() = New String(1) {}
    Private Sub ChatBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        messages(0) = "hello"
        messages(1) = "welcome"

        Me.Size = New Size(437, 506)
        Me.BackColor = Color.White
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        Label1.Location = New Point(150, 6)

        Panel1.Location = New Point(37, 45)
        Panel1.Size = New Size(361, 340)
        Panel1.BackColor = Color.White
        Panel1.AutoScroll = True
        Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Maximum

        Panel2.Location = New Point(27, 405)
        Panel2.Size = New Size(375, 55)

        RichTextBox1.Location = New Point(40, 415)
        RichTextBox1.Size = New Size(285, 42)
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Bahnschrift Light", 12, FontStyle.Regular)
        RichTextBox1.Padding = New Padding(5, 10, 67, 5)
        RichTextBox1.WordWrap = True

        SendButton.Size() = New Size(57, 26)
        SendButton.Location = New Point(333, 417)
        SendButton.BackColor = ColorTranslator.FromHtml("#124E55")
        SendButton.Text = "Send"
        SendButton.ForeColor = Color.White
        SendButton.Font = New Font("Bahnschrift Light", 11, FontStyle.Regular)
        SendButton.FlatStyle = FlatStyle.Flat
        SendButton.FlatAppearance.BorderSize = 0
        SendButton.Padding = New Padding(0, 0, 0, 0)
        SendButton.TextAlign = ContentAlignment.MiddleCenter
        SendButton.AutoSize = True

        LoadMessages()

    End Sub

    Private Function LoadMessages()
        For Each message In messages
            Dim newMessageLabel As New Label()
            newMessageLabel.Text = message
            newMessageLabel.AutoSize = True
            newMessageLabel.BackColor = ColorTranslator.FromHtml("#124E55")
            newMessageLabel.MaximumSize = New Size(250, 0)
            newMessageLabel.BorderStyle = BorderStyle.FixedSingle
            newMessageLabel.Padding = New Padding(5)
            newMessageLabel.Margin = New Padding(5)
            newMessageLabel.ForeColor = Color.White
            newMessageLabel.Font = New Font("Bahnschrift Light", 12, FontStyle.Regular)

            Dim textSize As SizeF = TextRenderer.MeasureText(message, newMessageLabel.Font)
            newMessageLabel.Width = CInt(textSize.Width) + 10
            newMessageLabel.Left = 20

            Panel1.Controls.Add(newMessageLabel)

            If Panel1.Controls.Count > 1 Then
                Dim prevMessageLabel As Control = Panel1.Controls(Panel1.Controls.Count - 2)
                newMessageLabel.Top = prevMessageLabel.Bottom + 10
            End If
        Next
    End Function

    Private Sub SendMessage(ByVal message As String)
        Dim newMessageLabel As New Label()
        newMessageLabel.Text = message
        newMessageLabel.AutoSize = True
        newMessageLabel.BackColor = ColorTranslator.FromHtml("#F9754B")
        newMessageLabel.MaximumSize = New Size(250, 0)
        newMessageLabel.BorderStyle = BorderStyle.None
        newMessageLabel.Padding = New Padding(5)
        newMessageLabel.Margin = New Padding(5)
        newMessageLabel.ForeColor = Color.White
        newMessageLabel.Font = New Font("Bahnschrift Light", 12, FontStyle.Regular)

        Dim textSize As SizeF = TextRenderer.MeasureText(message, newMessageLabel.Font)
        newMessageLabel.Width = CInt(textSize.Width) + 16
        newMessageLabel.Left = Panel1.Width - newMessageLabel.Width - 20
        Panel1.Controls.Add(newMessageLabel)

        If Panel1.Controls.Count > 1 Then
            Dim prevMessageLabel As Control = Panel1.Controls(Panel1.Controls.Count - 2)
            newMessageLabel.Top = prevMessageLabel.Bottom + 10
        End If
    End Sub

    Private Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        Dim message As String = RichTextBox1.Text.Trim()
        If message <> "" Then
            SendMessage(message)
            RichTextBox1.Clear()
        End If
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub

End Class