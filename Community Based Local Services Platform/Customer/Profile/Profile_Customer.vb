Imports System.IO

Public Class Profile_Customer

    Private Sub RemovePreviousForm()
        For Each ctrl As Control In Panel3.Controls
            If TypeOf ctrl Is Form Then
                ' Remove the first control (form) from Panel5
                Dim formCtrl As Form = DirectCast(ctrl, Form)
                formCtrl.Close()
            End If
        Next
        If Panel3.Controls.Count > 0 Then
            ' Remove the first control (form) from Panel5
            Panel3.Controls.Clear()
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

    Private Sub Profile_Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'retrieve data

        ' Dim loadQuery As String = "SELECT email, location, mobileNumber,address FROM ContactDetails WHERE BINARY userID='" & SessionManager.userID & "'"
        Dim loadQuery As String = "SELECT CD.email, CD.location, CD.mobileNumber, CD.address, U.userName, U.userPhoto " &
                          "FROM contactDetails CD " &
                          "JOIN users U ON CD.userID = U.userID " &
                          "WHERE BINARY CD.userID='" & SessionManager.userID & "'"

        Using connection As New MySqlConnection(SessionManager.connectionString)
            Using command As New MySqlCommand(loadQuery, connection)
                Try
                    connection.Open()
                    Dim reader As MySqlDataReader = command.ExecuteReader()

                    If reader.Read() Then

                        Dim cus_email As String = reader("email").ToString()
                        Dim cus_location As String = reader("location").ToString()
                        Dim cus_mobile As String = reader("mobileNumber").ToString()
                        Dim cus_address As String = reader("address").ToString()
                        Dim cus_username As String = reader("userName").ToString()



                        ' Set the retrieved values to the corresponding textboxes
                        email_tb.Text = cus_email
                        location_tb.Text = cus_location
                        contact_tb.Text = cus_mobile
                        address_tb.Text = cus_address
                        customerName_tb.Text = cus_username

                        ' Retrieve the user photo byte array from the database
                        If Not reader.IsDBNull(reader.GetOrdinal("userPhoto")) Then
                            Dim userPhoto As Byte() = DirectCast(reader("userPhoto"), Byte())

                            ' Check if user photo is not null
                            If userPhoto IsNot Nothing AndAlso userPhoto.Length > 0 Then
                                ' Convert byte array to image and display it in the picture box
                                Using ms As New MemoryStream(userPhoto)
                                    customerProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage
                                    customerProfilePicture.Image = Image.FromStream(ms)
                                End Using
                            Else
                                ' If user photo is null, set a default image or display a placeholder
                                customerProfilePicture.Image = My.Resources.Resource1.displayPicture
                            End If
                        End If

                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

    End Sub
End Class