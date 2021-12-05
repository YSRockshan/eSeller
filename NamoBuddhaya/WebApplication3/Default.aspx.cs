using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.Diagnostics;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           

            PDFform pdfForm = new PDFform(GetTable(), Server.MapPath("img2.gif"));

            // Create a MigraDoc document
            Document document = pdfForm.CreateDocument();
            document.UseCmykColor = true;

#if DEBUG
        // for debugging only...
        MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");
        document = MigraDoc.DocumentObjectModel.IO.DdlReader.DocumentFromFile("MigraDoc.mdddl");
#endif
           
            // Create a renderer for PDF that uses Unicode font encoding
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

            // Set the MigraDoc document
            pdfRenderer.Document = document;
            

            // Create the PDF document
            pdfRenderer.RenderDocument();

            // Save the PDF document...
            string filename = "PatientsDetail.pdf";
#if DEBUG
        // I don't want to close the document constantly...
        filename = "Invoice-" + Guid.NewGuid().ToString("N").ToUpper() + ".pdf";
#endif
            pdfRenderer.Save(filename);
            // ...and start a viewer.
            Process.Start(filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }



    static DataTable GetTable()
    {
        //
        // Here we create a DataTable with four columns.
        //
        DataTable table = new DataTable();
        table.Columns.Add("Dosage", typeof(int));
        table.Columns.Add("Drug", typeof(string));
        table.Columns.Add("Patient", typeof(string));
        table.Columns.Add("Date", typeof(DateTime));

        //
        // Here we add five DataRows.
        //
        table.Rows.Add(25, "Indocin", "Shehzad", DateTime.Now);
        table.Rows.Add(50, "Enebrel", "Kashif", DateTime.Now);
        table.Rows.Add(10, "Hydralazine", "Umair", DateTime.Now);
        table.Rows.Add(21, "Combivent", "Jahanzaib", DateTime.Now);
        table.Rows.Add(100, "Dilantin", "Talha", DateTime.Now);
        return table;
    }

}
