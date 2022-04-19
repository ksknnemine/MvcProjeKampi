using DataAccessLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryPieChart()
        {
            return View();
        }

        public ActionResult WriterColumnChart()
        {
            return View();
        }

        public ActionResult EntryChart()
        {
            return View();
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName="Seyahat",
                CategoryCount=4 
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });

            return ct;
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> CategoryList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            using (var context= new Context())
            {
                ct = context.Categories.Select(c => new CategoryClass
                {
                    CategoryName = c.CategoryName,
                    CategoryCount = c.Headings.Count()
                }).ToList();
            }
            return ct;
        }

        public ActionResult CategoryCharts()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<WriterClass> WriterList()
        {
            List<WriterClass> wr = new List<WriterClass>();
            using (var context = new Context())
            {
                wr = context.Writers.Select(c => new WriterClass
                {
                    WriterName=c.WriterName,
                    WriterCount=c.Headings.Count()
                }).ToList();
            }

            return wr;
        }

        public ActionResult WriterClass()
        {
            return Json(WriterList(), JsonRequestBehavior.AllowGet);
        }
    }
}