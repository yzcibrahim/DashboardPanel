using DashboardPanel.Contexts;
using DashboardPanel.Entities;
using DashboardPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardPanel.Controllers
{
    public class DashboardController : Controller
    {
        private readonly GrafikDbContext _context;
        public DashboardController(GrafikDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            DashViewModel model = new DashViewModel();
            model.Widgets = _context.Grafiks.ToList();

            if (id > 0)
            {
                DashBoard dashboardModel = _context.DashBoards.Include(c => c.DashBoardWidgets).ThenInclude(c => c.Graf).First(c => c.Id == id);
                model.Dash = dashboardModel;
            }

            return View(model);
        }

        public int SaveDash(DashWidModel model)
        {
            if (model.DashId > 0)
            {
                DashBoard dashBoardToUpdate = _context.DashBoards.Include(c => c.DashBoardWidgets).First(c => c.Id == model.DashId);
                dashBoardToUpdate.Isim = model.Isim;

                foreach (var silinecek in dashBoardToUpdate.DashBoardWidgets)
                {
                    _context.DashBoardWidgets.Remove(silinecek);
                }

                var dashwidgetList = new List<DashBoardWidget>();
                foreach (var item in model.WidList)
                {
                    DashBoardWidget dw = new DashBoardWidget()
                    {
                        GrafikId = item.WidgetId,
                        Height = item.Height,
                        Width = item.Width,
                        Left = item.Left,
                        Top = item.Top
                    };
                    dashwidgetList.Add(dw);
                }
                dashBoardToUpdate.DashBoardWidgets = dashwidgetList;

                _context.SaveChanges();
            }
            else
            {

                DashBoard dashboard = new DashBoard();
                dashboard.Isim = model.Isim;
                dashboard.DashBoardWidgets = new List<DashBoardWidget>();

                var dashwidgetList = new List<DashBoardWidget>();
                foreach (var item in model.WidList)
                {
                    DashBoardWidget dw = new DashBoardWidget()
                    {
                        GrafikId = item.WidgetId,
                        Height = item.Height,
                        Width = item.Width,
                        Left = item.Left,
                        Top = item.Top
                    };
                    dashwidgetList.Add(dw);
                }
                dashboard.DashBoardWidgets = dashwidgetList;

                _context.DashBoards.Add(dashboard);
                _context.SaveChanges();
            }
            return 1;
        }

        public IActionResult Dashboards()
        {
            List<DashBoard> model = _context.DashBoards.ToList();
            return View(model);
        }

        public IActionResult Open(int id)
        {
            var model = _context.DashBoards.Include(c => c.DashBoardWidgets).ThenInclude(c => c.Graf).ThenInclude(c => c.GrafikDatas).First(c => c.Id == id);
            return View(model);
        }
    }

}
