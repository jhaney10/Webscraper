using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BLL.DATA;
using ClosedXML.Excel;
using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Webscraper.Models;

namespace Webscraper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Scraper scraper;

        public HomeController(ILogger<HomeController> logger)
        {

            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductListing> products = new List<ProductListing>();
            DummyData data = new DummyData();
           products = data.Products;
            scraper = new Scraper();
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ScrapeData(string page)
        {
            ScrapeDataBLL scrape = new ScrapeDataBLL();
            var result = scrape.ScrapeData(page);
            return RedirectToAction("Index");
        }
        public void Export(List<string> names)
        {
            using (var wb = GenerateExcelSheet(names))
            {
                //Response.Clear();
                //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.AddHeader("content-disposition", "attachment;filename=\"" + "samplesheet.xlsx" + "\"");
                //using (MemoryStream memoryStream = new MemoryStream())
                //{
                //    wb.SaveAs(memoryStream);
                //    memoryStream.WriteTo(Response.OutputStream);
                //    memoryStream.Close();
                //}
                //Response.End();
                //return Response;
            }
        }
        public XLWorkbook GenerateExcelSheet(List<string> list)
        {
            Type elementType = typeof(string);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                dt.Columns.Add(propInfo.Name, ColType);
            }
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            var workbook = new XLWorkbook();
            workbook.Author = "Jane";
            workbook.Worksheets.Add(ds);
            return workbook;

        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
