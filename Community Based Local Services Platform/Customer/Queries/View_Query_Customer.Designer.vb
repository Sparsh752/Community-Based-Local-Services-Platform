﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class View_Query_Customer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()



        TextBox1 = New TextBox()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Me.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Me.BackColor = Color.White
        Me.Controls.Add(TextBox1)
        Me.Controls.Add(Button3)
        Me.Controls.Add(Button2)
        Me.Controls.Add(Button1)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Label2)
        Me.Controls.Add(Label1)
        Me.Location = New Point(0, 0)
        Me.Margin = New Padding(3, 4, 3, 4)
        Me.Name = "Panel1"
        Me.Size = New Size(791, 587)
        Me.TabIndex = 0
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = SystemColors.ControlLight
        TextBox1.Location = New Point(39, 332)
        TextBox1.Margin = New Padding(3, 4, 3, 4)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(717, 105)
        TextBox1.TabIndex = 8
        TextBox1.ReadOnly = True
        TextBox1.Text = "Admin has resolved the query"


        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.75F)
        Label5.Location = New Point(43, 260)
        Label5.Name = "Label5"
        Label5.Size = New Size(133, 23)
        Label5.TabIndex = 4
        Label5.Text = "Reply To Query :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F)
        Label4.Location = New Point(43, 191)
        Label4.Name = "Label4"
        Label4.Size = New Size(173, 23)
        Label4.TabIndex = 3
        Label4.Text = "10:40 am          Today"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F)
        Label3.Location = New Point(39, 137)
        Label3.Name = "Label3"
        Label3.Size = New Size(203, 23)
        Label3.TabIndex = 2
        Label3.Text = "Lorem Ipsum descripition"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F)
        Label2.Location = New Point(39, 105)
        Label2.Name = "Label2"
        Label2.Size = New Size(110, 23)
        Label2.TabIndex = 1
        Label2.Text = "Lorem Ipsum"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 18.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(39, 60)
        Label1.Name = "Label1"
        Label1.Size = New Size(653, 36)
        Label1.TabIndex = 0
        Label1.Text = "Provided service but did not recived payment"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        Margin = New Padding(3, 4, 3, 4)
        Name = "Query"
        Text = "Query"
        Me.ResumeLayout(False)
        Me.PerformLayout()
        ResumeLayout(False)
        Me.CenterToParent()
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(713, 480)
    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label

End Class
