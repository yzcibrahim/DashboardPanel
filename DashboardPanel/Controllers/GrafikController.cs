using DashboardPanel.Contexts;
using DashboardPanel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Controllers
{
    public class GrafikController : Controller
    {
        GrafikDbContext _context;
        public GrafikController(GrafikDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Grafiks.ToList());
        }

        [HttpGet]
        public IActionResult Create(int? id)
        {
            if(id.HasValue && id>0)
            {
                return View(_context.Grafiks.FirstOrDefault(c => c.Id == id.Value));
            }
           
            return View(new Grafik());
        }

        [HttpPost]
        public IActionResult Create(Grafik model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id <= 0)
            {
                _context.Grafiks.Add(model);
            }
            else
            {
                _context.Grafiks.Attach(model);
                _context.Entry<Grafik>(model).State = EntityState.Modified;

            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Grafik model = _context.Grafiks.Include(x=>x.GrafikDatas).FirstOrDefault(c => c.Id == id);
            ViewBag.dataId = 0;
            return View(model);
        }

        public PartialViewResult GrafikDatas(int id)
        {
            List<GrafikData> model = _context.GrafikDatas.Where(c => c.GrafikId == id).ToList();
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult AddGrafikData(GrafikData model)
        {
            if (model.Id > 0)
            {
                _context.GrafikDatas.Attach(model);
                _context.Entry<GrafikData>(model).State = EntityState.Modified;
            }
            else
            {
                _context.GrafikDatas.Add(model);
            }
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = model.GrafikId });
        }

        public IActionResult AddGrafikQuery(int id,string SqlQuery)
        {
            var model = _context.Grafiks.First(c => c.Id == id);
            model.SqlQuery = SqlQuery;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Edit(int id, int dataId)
        {
            Grafik model = _context.Grafiks.Include(x => x.GrafikDatas).FirstOrDefault(c => c.Id == id);

            ViewBag.dataId = dataId;

            return View("Details",model);
        }

        public IActionResult ShowChart(int id)
        {
            Grafik grph = _context.Grafiks.Include(c=>c.GrafikDatas).First(c=>c.Id==id);
            grph.GrafikDatas = new List<GrafikData>();

            grph.GrafikDatas=_context.GrafikDatas.FromSqlRaw(grph.SqlQuery).ToList();


            return View(grph);
        }



        public IActionResult ShowAllChart()
        {

            List<string> colors = new List<string>() { "#FF0000", "#00FF00", "#0000FF" };

            List<Grafik> model = _context.Grafiks.Include(c => c.GrafikDatas).ToList();

            foreach(var item in model.Where(c=>c.WidgetTip==1))
            {
                item.GrafikDatas = _context.GrafikDatas.FromSqlRaw(item.SqlQuery).ToList();

                int colorIndex = 0;
                foreach(var datas in item.GrafikDatas)
                {
                    datas.ColorCode = colors[colorIndex];
                    colorIndex++;
                }

                colorIndex = 0;
            }


            return View(model);
        }
    }
}
