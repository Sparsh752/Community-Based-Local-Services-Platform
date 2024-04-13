Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports System.IO

Public Class PdfGenerator
    Public Sub GeneratePDF(filePath As String, ServiceProviderName As String, Address As String, PhoneNo As String, SlotDate As String, SlotTime As String, TransactionID As String, TransactionType As String, ServiceName As String, ServPrice As String)
        ' Create a Document object
        Dim receiptPageSize As New Rectangle(4.25F * 72, 6.0F * 72)
        Dim document As New iTextSharp.text.Document(receiptPageSize)

        Try
            ' Create a PdfWriter instance to write the PDF file
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))

            ' Open the document for writing
            document.Open()
            Dim sepline As String = "----------------------------------------------------------" & Environment.NewLine
            ' Add content to the PDF (e.g., text, images, tables)
            document.Add(New Paragraph(sepline))
            Dim title As New Paragraph("RECEIPT", New Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))
            title.Alignment = Element.ALIGN_CENTER
            document.Add(title)
            document.Add(New Paragraph(sepline))
            Dim ServicePrv As New Paragraph(ServiceProviderName, New Font(Font.FontFamily.COURIER, 10, Font.NORMAL))
            ServicePrv.Alignment = Element.ALIGN_CENTER
            document.Add(ServicePrv)
            Dim ServicePrvAdd As New Paragraph(Address, New Font(Font.FontFamily.COURIER, 10, Font.NORMAL))
            ServicePrvAdd.Alignment = Element.ALIGN_CENTER
            document.Add(ServicePrvAdd)
            Dim ServicePrvPhone As New Paragraph("Phone: " & PhoneNo, New Font(Font.FontFamily.COURIER, 10, Font.NORMAL))
            ServicePrvPhone.Alignment = Element.ALIGN_CENTER
            document.Add(ServicePrvPhone)
            Dim Slot As New Paragraph(Environment.NewLine & "Booked Slot: " & SlotDate & " " & SlotTime, New Font(Font.FontFamily.COURIER, 10, Font.NORMAL))
            Slot.Alignment = Element.ALIGN_CENTER
            document.Add(Slot)
            Dim NewL As New Paragraph(Environment.NewLine)
            document.Add(NewL)
            Dim TrId = TransactionID
            Dim table1 As New PdfPTable(2)
            table1.WidthPercentage = 100
            table1.HorizontalAlignment = Element.ALIGN_CENTER
            table1.DefaultCell.Border = Rectangle.NO_BORDER
            table1.AddCell(New Phrase("Transaction ID: ", New Font(Font.FontFamily.COURIER, 10, Font.NORMAL)))
            Dim TrIdCell As New PdfPCell(New Phrase(TrId, New Font(Font.FontFamily.COURIER, 10, Font.NORMAL)))
            TrIdCell.Border = PdfPCell.NO_BORDER
            TrIdCell.HorizontalAlignment = Element.ALIGN_RIGHT
            table1.AddCell(TrIdCell)
            document.Add(table1)
            Dim Trtype = TransactionType
            Dim table2 As New PdfPTable(2)
            table2.WidthPercentage = 100
            table2.HorizontalAlignment = Element.ALIGN_CENTER
            table2.DefaultCell.Border = Rectangle.NO_BORDER
            table2.AddCell(New Phrase("Transaction Type: ", New Font(Font.FontFamily.COURIER, 10, Font.NORMAL)))
            Dim TrtypeCell As New PdfPCell(New Phrase(Trtype, New Font(Font.FontFamily.COURIER, 10, Font.NORMAL)))
            TrtypeCell.Border = PdfPCell.NO_BORDER
            TrtypeCell.HorizontalAlignment = Element.ALIGN_RIGHT
            table2.AddCell(TrtypeCell)
            document.Add(table2)
            Dim lightline As New Paragraph("---------------------------------------", New Font(Font.FontFamily.COURIER, 10, Font.NORMAL))
            document.Add(lightline)
            Dim service As String = ServiceName
            Dim price As String = "Rs. " & ServPrice
            Dim table As New PdfPTable(2)
            table.WidthPercentage = 100
            table.HorizontalAlignment = Element.ALIGN_CENTER
            table.DefaultCell.Border = Rectangle.NO_BORDER
            table.AddCell(New Phrase(service, New Font(Font.FontFamily.COURIER, 10, Font.NORMAL)))
            Dim priceCell As New PdfPCell(New Phrase(price, New Font(Font.FontFamily.COURIER, 10, Font.NORMAL)))
            priceCell.Border = PdfPCell.NO_BORDER
            priceCell.HorizontalAlignment = Element.ALIGN_RIGHT
            table.AddCell(priceCell)
            document.Add(table)
            document.Add(lightline)
            Dim Total As String = "Rs. " & ServPrice
            Dim table3 As New PdfPTable(2)
            table3.WidthPercentage = 100
            table3.HorizontalAlignment = Element.ALIGN_CENTER
            table3.DefaultCell.Border = Rectangle.NO_BORDER
            table3.AddCell(New Phrase("Total", New Font(Font.FontFamily.COURIER, 10, Font.BOLD)))
            Dim TotalCell As New PdfPCell(New Phrase(Total, New Font(Font.FontFamily.COURIER, 10, Font.BOLD)))
            TotalCell.Border = PdfPCell.NO_BORDER
            TotalCell.HorizontalAlignment = Element.ALIGN_RIGHT
            table3.AddCell(TotalCell)
            document.Add(table3)
            document.Add(NewL)
            'document.Add(NewL)
            document.Add(New Paragraph(sepline))
            Dim Thankyouline As New Paragraph("Thank you for choosing us!", New Font(Font.FontFamily.HELVETICA, 12, Font.BOLD))
            Thankyouline.Alignment = Element.ALIGN_CENTER
            document.Add(Thankyouline)
            document.Add(New Paragraph(sepline))


        Catch ex As Exception
            ' Handle any exceptions
            Console.WriteLine("An error occurred: " & ex.Message)
        Finally
            ' Close the document
            document.Close()
        End Try
    End Sub
End Class

'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
'Dim pdfGenerator As New PdfGenerator()
'Dim currentDirectory As String = AppDomain.CurrentDomain.BaseDirectory

'Dim filePath As String = Path.Combine(currentDirectory, "TransactionReceipt.pdf")


' Adjusted content to fit custom page size

'pdfGenerator.GeneratePDF(filePath, "Sparsh Cleaning Service", "287, Kapili Hostel, IIT Guwahati, Guwahati - 781039, Assam", "8770768952", "09/08/2024", "09:00", "123456789123456789", "Credit/Debit", "Cleaning Room", "400") ' Assuming your PdfGenerator class has support for custom page size
'If File.Exists(filePath) Then
'Dim edgePath As String = "C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"
'Process.Start(edgePath, """" & filePath & """")

'Else
'Console.WriteLine("PDF file does not exist.")
'End If

'End Sub
