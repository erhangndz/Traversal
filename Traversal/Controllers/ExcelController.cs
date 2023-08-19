using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OfficeOpenXml;
using System;
using Traversal.Models;

namespace Traversal.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModel= new List<DestinationModel>();
            using var c = new Context();

            destinationModel = c.Destinations.Select(x => new DestinationModel
            {
                City = x.City,
                StayDuration = x.StayDuration,
                Price = x.Price,
                Capacity = x.Capacity,

            }).ToList();

            return destinationModel;    
        }
        public IActionResult StaticExcelReport()
        {
            var guid = Guid.NewGuid();
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocuments.spreadsheetml.sheet", guid + ".xlsx");
            

             //"application/vnd.openxmlformats-officedocuments.spreadsheetml.sheet", guid + ".xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using var workBook = new XLWorkbook();
            
                var workSheet= workBook.Worksheets.Add("Tur Listesi");
            workSheet.Cell(1, 1).Value = "Şehir";
            workSheet.Cell(1, 2).Value = "Konaklama Süresi";
            workSheet.Cell(1, 3).Value = "Fiyat";
            workSheet.Cell(1, 4).Value = "Kapasite";

            int rowCount = 2;
            foreach (var item in DestinationList())
            {
                workSheet.Cell(rowCount,1).Value= item.City;
                workSheet.Cell(rowCount,2).Value= item.StayDuration;
                workSheet.Cell(rowCount,3).Value= item.Price;
                workSheet.Cell(rowCount,4).Value= item.Capacity;
                rowCount++;
            }

            using var stream = new MemoryStream();
            workBook.SaveAs(stream);
            var content = stream.ToArray();
            string guid = Guid.NewGuid().ToString();
            return File(content, "application/vnd.openxmlformats-officedocuments.spreadsheetml.sheet", guid + ".xlsx");
            
        }

    }
}
