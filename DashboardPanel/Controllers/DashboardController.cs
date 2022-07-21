using DashboardPanel.Contexts;
using DashboardPanel.Entities;
using DashboardPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

            List<string> colors = new List<string>() { "#FF0000", "#00FF00", "#0000FF" };

            ///
           
            ///

            foreach (var item in model.DashBoardWidgets.Where(c => c.Graf.WidgetTip == 1))
            {
                
                var dt = new DataTable();
                var conn = _context.Database.GetDbConnection();
                var connectionState = conn.State;
                try
                {
                    if (connectionState != ConnectionState.Open)
                        conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = item.Graf.SqlQuery;
                        cmd.CommandType = CommandType.Text;
                       
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // error handling
                    throw;
                }
                finally
                {
                    if (connectionState != ConnectionState.Closed) conn.Close();
                }

                List<GrafikData> dataList = new List<GrafikData>();

                int colorIndex = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    dataList.Add(new GrafikData()
                    {
                        Id = 0,
                        Anahtar = dr[1].ToString(),
                        Value = Convert.ToDouble(dr[2].ToString()),
                        ColorCode= colors[colorIndex]
                    });

                    colorIndex++;
                }
                item.Graf.GrafikDatas = dataList;

            }

            //foreach (var item in model.DashBoardWidgets.Where(c => c.Graf.WidgetTip == 1))
            //{
            //    item.Graf.GrafikDatas = _context.GrafikDatas.FromSqlRaw(item.Graf.SqlQuery).ToList();

            //    int colorIndex = 0;
            //    foreach (var datas in item.Graf.GrafikDatas)
            //    {
            //        datas.ColorCode = colors[colorIndex];
            //        colorIndex++;
            //    }

            //    colorIndex = 0;
            //}



            return View(model);
        }
    }

}
