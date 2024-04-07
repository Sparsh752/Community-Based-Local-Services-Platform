<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    Private lblHeading As System.Windows.Forms.Label
    Private lblSubheading As System.Windows.Forms.Label

    ' Constructor
    Public Sub New()
        InitializeComponent()
        InitializeCard()
    End Sub

    ' Initialize the card layout and controls
    Private Sub InitializeCard()
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.None ' Set border style to None

        ' Heading Label
        lblHeading = New System.Windows.Forms.Label()
        lblHeading.Font = New System.Drawing.Font(SessionManager.font_family, 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        lblHeading.Location = New System.Drawing.Point(10, 5)
        lblHeading.AutoSize = True
        lblHeading.Text = "Heading"
        Me.Controls.Add(lblHeading)

        ' Subheading Label
        lblSubheading = New System.Windows.Forms.Label()
        lblSubheading.Font = New System.Drawing.Font(SessionManager.font_family, 8, System.Drawing.FontStyle.Regular) ' Set font to Montserrat, size to 10, and style to Regular
        lblSubheading.Location = New System.Drawing.Point(10, 30)
        lblSubheading.AutoSize = True
        lblSubheading.ForeColor = Color.FromArgb(&HF9604B) ' Set color to F9604B
        lblSubheading.Text = "Subheading"
        Me.Controls.Add(lblSubheading)
    End Sub

    ' Properties for setting the heading and subheading text
    Public Property HeadingText As String
        Get
            Return lblHeading.Text
        End Get
        Set(value As String)
            lblHeading.Text = value
        End Set
    End Property

    Public Property SubheadingText As String
        Get
            Return lblSubheading.Text
        End Get
        Set(value As String)
            lblSubheading.Text = value
        End Set
    End Property

    ' Required designer method for initializing controls
    Private Sub InitializeComponent()
        SuspendLayout()
        ' 
        ' UserControl1
        ' 
        Location = New Point(40, 74)
        Name = "UserControl1"
        Size = New Size(337, 45)
        ResumeLayout(False)

    End Sub

End Class
