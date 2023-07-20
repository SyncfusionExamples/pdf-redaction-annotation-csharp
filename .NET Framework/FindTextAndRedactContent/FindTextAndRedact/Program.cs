using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Redaction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTextAndRedact
{
    class Program
    {
        static void Main(string[] args)
        {

            // Load an existing PDF
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument("../../../../Data/Invoice.pdf");

            TextSearchResultCollection searchCollection;

            TextSearchItem text = new TextSearchItem("Invoice Number", TextSearchOptions.None);

            //Search the text from PDF dcoument
            loadedDocument.FindText(new List<TextSearchItem> { text }, out searchCollection);

            //Iterate serach collection to get serach results
            foreach (KeyValuePair<int, MatchedItemCollection> textCollection in searchCollection)
            {
                //Get matched text collection
                foreach (MatchedItem textItem in textCollection.Value)
                {
                    //Redact the text
                    PdfRedaction redaction = new PdfRedaction(new RectangleF(textItem.Bounds.X, textItem.Bounds.Y, textItem.Bounds.Width+55, textItem.Bounds.Height));
                    (loadedDocument.Pages[textCollection.Key] as PdfLoadedPage).Redactions.Add(redaction);
                    loadedDocument.Redact();
                    //Replace the redacted text with new text
                    (loadedDocument.Pages[0] as PdfLoadedPage).Graphics.DrawString("Invoice Number: 2345678989909", new PdfStandardFont(PdfFontFamily.Helvetica, 9), PdfBrushes.Red, new PointF(textItem.Bounds.X, textItem.Bounds.Y));
                }

            }

           

            loadedDocument.Save("Redact.pdf");
            //Close the document
            loadedDocument.Close(true);
        }
    }
}
