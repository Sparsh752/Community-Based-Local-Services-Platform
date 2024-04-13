Imports System.IO

Public Class Payment_Gateway
    Dim UPI_button As New Button()
    Dim D_Card_button As New Button()
    Dim C_Card_button As New Button()
    Dim QR_button As New Button()
    Dim Panel2 As New Panel()
    Private Sub Gateway_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(1200, 700)
        Dim panel1 As New Panel()
        panel1.BackColor = ColorTranslator.FromHtml("#EDEDED")
        panel1.Size = New Size(359, 700)
        panel1.Location = New Point(0, 0)
        Me.Controls.Add(panel1)
        Me.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        Me.Size = New Size(1200, 700)

        Panel2.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        Panel2.Location = New Point(359, 0)
        Panel2.Size = New Size(841, 700)
        Me.Controls.Add(Panel2)
        Dim Heading As New Label()
        Heading.Text = "Payment Gateway"
        Heading.Font = New Font("Bahnschrift Light", 20, FontStyle.Bold)
        Heading.Location = New Point(34, 92)
        Heading.Size = New Size(251, 83)
        Heading.TextAlign = ContentAlignment.MiddleCenter
        panel1.Controls.Add(Heading)
        Dim lineLabel As New Label()
        lineLabel.BorderStyle = BorderStyle.Fixed3D
        lineLabel.Location = New Point(34, 207)
        lineLabel.Size = New Size(256, 1)
        panel1.Controls.Add(lineLabel)

        UPI_button.Text = "UPI"
        UPI_button.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
        UPI_button.Location = New Point(57, 243)
        panel1.Controls.Add(UPI_button)
        UPI_button.FlatStyle = FlatStyle.Flat
        UPI_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        UPI_button.FlatAppearance.BorderSize = 0
        UPI_button.Size = New Size(239, 28)
        UPI_button.ForeColor = Color.White
        UPI_button.TextAlign = ContentAlignment.MiddleLeft

        D_Card_button.Text = "DEBIT CARD"
        D_Card_button.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
        D_Card_button.Location = New Point(57, 291)
        panel1.Controls.Add(D_Card_button)
        D_Card_button.FlatStyle = FlatStyle.Flat
        D_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        D_Card_button.FlatAppearance.BorderSize = 0
        D_Card_button.Size = New Size(239, 28)
        D_Card_button.ForeColor = Color.Black
        D_Card_button.TextAlign = ContentAlignment.MiddleLeft

        C_Card_button.Text = "CREDIT CARD"
        C_Card_button.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
        C_Card_button.Location = New Point(57, 339)
        panel1.Controls.Add(C_Card_button)
        C_Card_button.FlatStyle = FlatStyle.Flat
        C_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        C_Card_button.FlatAppearance.BorderSize = 0
        C_Card_button.Size = New Size(239, 28)
        C_Card_button.ForeColor = Color.Black
        C_Card_button.TextAlign = ContentAlignment.MiddleLeft

        QR_button.Text = "QR CODE"
        QR_button.Font = New Font("Bahnschrift Light", 10, FontStyle.Bold)
        QR_button.Location = New Point(57, 387)
        panel1.Controls.Add(QR_button)
        QR_button.FlatStyle = FlatStyle.Flat
        QR_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        QR_button.FlatAppearance.BorderSize = 0
        QR_button.Size = New Size(239, 28)
        QR_button.ForeColor = Color.Black
        QR_button.TextAlign = ContentAlignment.MiddleLeft
        AddHandler UPI_button.Click, AddressOf UPI_button_Click
        AddHandler D_Card_button.Click, AddressOf D_Card_button_Click
        AddHandler C_Card_button.Click, AddressOf C_Card_button_Click
        AddHandler QR_button.Click, AddressOf QR_button_Click
        RemovePreviousForm()
        LoadUPI()
    End Sub
    Private Sub UPI_button_Click(sender As Object, e As EventArgs)
        UPI_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        UPI_button.ForeColor = Color.White
        D_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        D_Card_button.ForeColor = Color.Black
        C_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        C_Card_button.ForeColor = Color.Black
        QR_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        QR_button.ForeColor = Color.Black
        RemovePreviousForm()
        LoadUPI()
    End Sub
    Private Sub D_Card_button_Click(sender As Object, e As EventArgs)
        D_Card_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        D_Card_button.ForeColor = Color.White
        C_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        C_Card_button.ForeColor = Color.Black
        UPI_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        UPI_button.ForeColor = Color.Black
        QR_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        QR_button.ForeColor = Color.Black
        RemovePreviousForm()
        LoadCard()
    End Sub

    Private Sub Proceed_Button_Click(sender As Object, e As EventArgs)
        Dim confirmationForm As New Confirmation()
        confirmationForm.ShowDialog()
    End Sub

    Private Sub C_Card_button_Click(sender As Object, e As EventArgs)
        C_Card_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        C_Card_button.ForeColor = Color.White
        D_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        D_Card_button.ForeColor = Color.Black
        UPI_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        UPI_button.ForeColor = Color.Black
        QR_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        QR_button.ForeColor = Color.Black
        RemovePreviousForm()
        LoadCard()
    End Sub
    Private Sub QR_button_Click(sender As Object, e As EventArgs)
        QR_button.BackColor = ColorTranslator.FromHtml("#F9754B")
        QR_button.ForeColor = Color.White
        UPI_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        UPI_button.ForeColor = Color.Black
        D_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        D_Card_button.ForeColor = Color.Black
        C_Card_button.BackColor = ColorTranslator.FromHtml("#EDEDED")
        C_Card_button.ForeColor = Color.Black
        RemovePreviousForm()
        LoadQR()
    End Sub

    Private Sub RemovePreviousForm()
        Panel2.Controls.Clear()
    End Sub
    Private Sub LoadUPI()
        Dim Amount_label As New Label()
        Amount_label.Text = "Amount"
        Amount_label.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Amount_label.Location = New Point(137, 156)
        Panel2.Controls.Add(Amount_label)
        Amount_label.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim Amount As New Label()
        Amount.Text = "Rs. 15000"
        Amount.Font = New Font("Bahnschrift Light", 26, FontStyle.Bold)
        Amount.Location = New Point(137, 179)
        Panel2.Controls.Add(Amount)
        Amount.AutoSize = True
        Dim EnterUPI As New Label()
        EnterUPI.Text = "Enter UPI ID"
        EnterUPI.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterUPI.Location = New Point(137, 275)
        Panel2.Controls.Add(EnterUPI)
        EnterUPI.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim UPI_ID As New TextBox()
        UPI_ID.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        UPI_ID.Location = New Point(137, 312)
        Panel2.Controls.Add(UPI_ID)
        UPI_ID.Size = New Size(560, 59)
        UPI_ID.BorderStyle = BorderStyle.FixedSingle
        Dim Proceed_Button As New Button()
        Proceed_Button.Text = "Proceed"
        Proceed_Button.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Proceed_Button.Location = New Point(137, 431)
        Panel2.Controls.Add(Proceed_Button)
        Proceed_Button.FlatStyle = FlatStyle.Flat
        Proceed_Button.BackColor = ColorTranslator.FromHtml("#F9754B")
        Proceed_Button.FlatAppearance.BorderSize = 0
        Proceed_Button.Size = New Size(150, 40)
        Proceed_Button.ForeColor = Color.White
        AddHandler Proceed_Button.Click, AddressOf Proceed_Button_Click

    End Sub
    Private Sub LoadCard()
        Dim Amount_label As New Label()
        Amount_label.Text = "Amount"
        Amount_label.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Amount_label.Location = New Point(137, 156)
        Panel2.Controls.Add(Amount_label)
        Amount_label.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim Amount As New Label()
        Amount.Text = "Rs. 15000"
        Amount.Font = New Font("Bahnschrift Light", 26, FontStyle.Bold)
        Amount.Location = New Point(137, 179)
        Panel2.Controls.Add(Amount)
        Amount.AutoSize = True

        Dim EnterCardNumber As New Label()
        EnterCardNumber.Text = "Card Number"
        EnterCardNumber.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterCardNumber.Location = New Point(137, 275)
        Panel2.Controls.Add(EnterCardNumber)
        EnterCardNumber.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim CardNumber As New TextBox()
        CardNumber.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        CardNumber.Location = New Point(137, 312)
        Panel2.Controls.Add(CardNumber)
        CardNumber.Size = New Size(560, 59)
        CardNumber.BorderStyle = BorderStyle.FixedSingle

        Dim EnterCVV As New Label()
        EnterCVV.Text = "CVV"
        EnterCVV.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterCVV.Location = New Point(137, 400)
        Panel2.Controls.Add(EnterCVV)
        EnterCVV.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim CVV As New TextBox()
        CVV.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        CVV.Location = New Point(137, 437)
        Panel2.Controls.Add(CVV)
        CVV.Size = New Size(140, 59)
        CVV.BorderStyle = BorderStyle.FixedSingle

        Dim EnterMonth As New Label()
        EnterMonth.Text = "Month(MM)"
        EnterMonth.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterMonth.Location = New Point(337, 400)
        Panel2.Controls.Add(EnterMonth)
        EnterMonth.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim Month As New TextBox()
        Month.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Month.Location = New Point(337, 437)
        Panel2.Controls.Add(Month)
        Month.Size = New Size(140, 59)
        Month.BorderStyle = BorderStyle.FixedSingle

        Dim EnterYear As New Label()
        EnterYear.Text = "Year(YYYY)"
        EnterYear.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        EnterYear.Location = New Point(537, 400)
        Panel2.Controls.Add(EnterYear)
        EnterYear.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim Year As New TextBox()
        Year.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Year.Location = New Point(537, 437)
        Panel2.Controls.Add(Year)
        Year.Size = New Size(140, 59)
        Year.BorderStyle = BorderStyle.FixedSingle

        Dim Proceed_Button As New Button()
        Proceed_Button.Text = "Proceed"
        Proceed_Button.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Proceed_Button.Location = New Point(137, 520)
        Panel2.Controls.Add(Proceed_Button)
        Proceed_Button.FlatStyle = FlatStyle.Flat
        Proceed_Button.BackColor = ColorTranslator.FromHtml("#F9754B")
        Proceed_Button.FlatAppearance.BorderSize = 0
        Proceed_Button.Size = New Size(150, 40)
        Proceed_Button.ForeColor = Color.White
        AddHandler Proceed_Button.Click, AddressOf Proceed_Button_Click

    End Sub

    Dim imagePath As String = Path.Combine(Application.StartupPath, "..\..\..\Resources\QR.png")
    Private Sub LoadQR()
        Dim Amount_label As New Label()
        Amount_label.Text = "Amount"
        Amount_label.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Amount_label.Location = New Point(137, 156)
        Panel2.Controls.Add(Amount_label)
        Amount_label.ForeColor = ColorTranslator.FromHtml("#888888")
        Dim Amount As New Label()
        Amount.Text = "Rs. 15000"
        Amount.Font = New Font("Bahnschrift Light", 26, FontStyle.Bold)
        Amount.Location = New Point(137, 179)
        Panel2.Controls.Add(Amount)
        Amount.AutoSize = True

        Dim QRCode As New PictureBox()
        QRCode.Image = Image.FromFile(imagePath) ' Specify the path to your image
        QRCode.SizeMode = PictureBoxSizeMode.StretchImage
        QRCode.Location = New Point(137, 250) ' Adjust the location as needed
        QRCode.Size = New Size(200, 200) ' Adjust the size as needed
        Panel2.Controls.Add(QRCode)


        Dim Proceed_Button As New Button()
        Proceed_Button.Text = "Proceed"
        Proceed_Button.Font = New Font("Bahnschrift Light", 13, FontStyle.Regular)
        Proceed_Button.Location = New Point(137, 520)
        Panel2.Controls.Add(Proceed_Button)
        Proceed_Button.FlatStyle = FlatStyle.Flat
        Proceed_Button.BackColor = ColorTranslator.FromHtml("#F9754B")
        Proceed_Button.FlatAppearance.BorderSize = 0
        Proceed_Button.Size = New Size(150, 40)
        Proceed_Button.ForeColor = Color.White
        AddHandler Proceed_Button.Click, AddressOf Proceed_Button_Click

    End Sub

End Class