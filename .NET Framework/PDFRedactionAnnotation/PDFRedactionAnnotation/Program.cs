using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;

namespace PDFRedactionAnnotation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/invoice_merged.pdf");
            PdfLoadedPage loadedPage = loadedDocument.Pages[0] as PdfLoadedPage;

            //Create redaction annotation
            PdfRedactionAnnotation redactionAnnotation1 = new PdfRedactionAnnotation();
            //Assign the rectangle bounds
            redactionAnnotation1.Bounds = new System.Drawing.RectangleF(35, 393, 100, 20);
            //Set inner color of the annotation
            redactionAnnotation1.InnerColor = Color.Black;
            //Set border color of the annotation
            redactionAnnotation1.BorderColor = Color.Red;
            //add annotation to the page
            loadedPage.Annotations.Add(redactionAnnotation1);

            PdfRedactionAnnotation redactionAnnotation2 = new PdfRedactionAnnotation();
            redactionAnnotation2.Bounds = new System.Drawing.RectangleF(95, 435, 80, 100);
            redactionAnnotation2.InnerColor = Color.Black;
            redactionAnnotation2.BorderColor = Color.Red;

            loadedPage.Annotations.Add(redactionAnnotation2);

            //Save and close the PDF document
            loadedDocument.Save("output.pdf");
            loadedDocument.Close(true);
        }

       
    }
}
