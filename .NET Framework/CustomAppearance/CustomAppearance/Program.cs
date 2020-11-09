using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAppearance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/Invoice.pdf");

            //Create redaction annotation
            PdfRedactionAnnotation redactionAnnotation = new PdfRedactionAnnotation();
            //Assign the page bounds to redaction annotation
            redactionAnnotation.Bounds = new System.Drawing.RectangleF(60, 150,170, 120);
            //Set inner color of the annotation
            redactionAnnotation.InnerColor = Color.Black;
            //Set border color of the annotation
            redactionAnnotation.BorderColor = Color.Red;

            //Font for the overlay text
            redactionAnnotation.Font = new PdfStandardFont(PdfFontFamily.Courier, 10);
            //Text color
            redactionAnnotation.TextColor = Color.White;
            //Text alignment 
            redactionAnnotation.TextAlignment = PdfTextAlignment.Center;
            //Set overlay text
            redactionAnnotation.OverlayText = "Confidential";
            //Set repeat text option
            redactionAnnotation.RepeatText = true;
            //Enable appearance of the annotation
            redactionAnnotation.SetAppearance(true);

            //add annotation to the page page.Annotations.Add(redactionAnnotation);
            loadedDocument.Pages[0].Annotations.Add(redactionAnnotation);

            //Save and close the PDF document
            loadedDocument.Save("CustomAppearance.pdf");
            loadedDocument.Close(true);
        }
    }
}
