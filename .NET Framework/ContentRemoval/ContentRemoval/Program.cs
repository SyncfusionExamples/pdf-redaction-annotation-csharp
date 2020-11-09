using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load the PDF document
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/InvoiceMarked.pdf");

            //Iterate each redaction annotation and apply flatten to redact marked content
            foreach(PdfAnnotation annotation in loadedDocument.Pages[0].Annotations)
            {
                if(annotation is PdfLoadedRedactionAnnotation)
                {
                    (annotation as PdfLoadedRedactionAnnotation).Flatten = true;
                }
            }

            //Save and close the PDF document
            loadedDocument.Save("Redacted.pdf");
            loadedDocument.Close(true);
        }
    }
}
