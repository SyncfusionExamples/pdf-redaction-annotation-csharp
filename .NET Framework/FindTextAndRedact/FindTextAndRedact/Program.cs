using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
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
                    //Create redaction annotation
                    PdfRedactionAnnotation redactionAnnotation1 = new PdfRedactionAnnotation();
                    //Assign the rectangle bounds to cover full invoice number
                    redactionAnnotation1.Bounds =new RectangleF(textItem.Bounds.X,textItem.Bounds.Y,textItem.Bounds.Width+55,textItem.Bounds.Height);
                    //Set inner color of the annotation
                    redactionAnnotation1.InnerColor = Color.Black;
                    //Set border color of the annotation
                    redactionAnnotation1.BorderColor = Color.Red;
                    //add annotation to the page
                    loadedDocument.Pages[textCollection.Key].Annotations.Add(redactionAnnotation1);
                }

            }

            loadedDocument.Save("Redact.pdf");
            //Close the document
            loadedDocument.Close(true);
        }
    }
}
