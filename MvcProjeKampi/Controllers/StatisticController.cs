using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context _context = new Context();
        public ActionResult Index()
        {
            var totalCategory = _context.Categories.Count().ToString();
            ViewBag.totalCategory = totalCategory;

            var totalSoftwareHeading = _context.Headings.Count(x => x.CategoryID == 20).ToString();
            ViewBag.totalSoftwareHeading = totalSoftwareHeading;

            var withInA = _context.Writers.Count(x => x.WriterName.ToLower().Contains("a")).ToString();
            ViewBag.withInA = withInA;

            var highHeading = _context.Headings.Max(x => x.Category.CategoryName);
            ViewBag.highHeading = highHeading;

            var categoryTrue = _context.Categories.Count(x => x.CategoryStatus == true);
            var categoryFalse = _context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.categoryMinus = (categoryTrue - categoryFalse).ToString();

            return View();
        }
    }
}