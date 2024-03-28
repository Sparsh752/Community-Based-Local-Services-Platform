<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Navbar_Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        BtnLogout = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.FromArgb(CByte(15), CByte(42), CByte(55))
        Panel1.Controls.Add(BtnLogout)
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1200, 65)
        Panel1.TabIndex = 0
        ' 
        ' BtnLogout
        ' 
        BtnLogout.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        BtnLogout.FlatAppearance.BorderSize = 0
        BtnLogout.FlatStyle = FlatStyle.Flat
        BtnLogout.Font = New Font("Bahnschrift Light", 12.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BtnLogout.ForeColor = Color.White
        BtnLogout.Location = New Point(1031, 18)
        BtnLogout.Margin = New Padding(0)
        BtnLogout.Name = "BtnLogout"
        BtnLogout.Size = New Size(107, 29)
        BtnLogout.TabIndex = 5
        BtnLogout.Text = "Logout"
        BtnLogout.UseVisualStyleBackColor = False
        ' 
        ' Navbar_Admin
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1184, 661)
        Controls.Add(Panel1)
        Name = "Navbar_Admin"
        Text = "Navbar_Admin"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnLogout As Button
End Class
