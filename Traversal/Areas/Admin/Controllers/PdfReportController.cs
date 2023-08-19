using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult StaticPdfReport()
        {
            var guid = Guid.NewGuid();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon PDF Raporu") ;
            
            document.Add(paragraph);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "application/pdf", "dosya1.pdf");

        }

        public IActionResult StaticCustomerReport()
        {
            var guid = Guid.NewGuid();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TCKN");

            pdfPTable.AddCell("Erhan");
            pdfPTable.AddCell("Gündüz");
            pdfPTable.AddCell("33300033000");

            pdfPTable.AddCell("Mehmet");
            pdfPTable.AddCell("Yıldız");
            pdfPTable.AddCell("44400044000");

            pdfPTable.AddCell("Ahmet");
            pdfPTable.AddCell("Yılmaz");
            pdfPTable.AddCell("55500055000");


            document.Add(pdfPTable);
            document.Close();
            return File("/pdfreports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
