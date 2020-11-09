using Syncfusion.Pdf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholePageRedaction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/invoice_merged.pdf");
            
            //Iterate each page and add redaction annotation
            foreach (PdfLoadedPage page in loadedDocument.Pages)
            {
                //Create redaction annotation
                PdfRedactionAnnotation redactionAnnotation = new PdfRedactionAnnotation();
                //Assign the page bounds to redaction annotation
                redactionAnnotation.Bounds = new System.Drawing.RectangleF(0, 0, page.Size.Width, page.Size.Height);
                //Set inner color of the annotation
                redactionAnnotation.InnerColor = Color.Black;
                //Set border color of the annotation
                redactionAnnotation.BorderColor = Color.Red;
                //add annotation to the page
                page.Annotations.Add(redactionAnnotation);
            }

            //Save and close the PDF document
            loadedDocument.Save("WholePage.pdf");
            loadedDocument.Close(true);
        }
    }
}
