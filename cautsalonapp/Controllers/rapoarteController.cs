using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using cautsalonapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace cautsalonapp.Controllers
{
    public class rapoarteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public rapoarteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetRaportProgramari()
        {

            var query = await (from p in _context.Programari
                              join s in _context.Saloane
                              on p.Salon.Cod_salon equals s.Cod_salon
                              where s.Firma.Webuser.UserName == User.Identity.Name
                              select new { p.Confirmata, p.Status }).ToListAsync();


            var confirmate = 0;
            var anulate = 0;
            var noi = 0;
            foreach(var item in query)
            {
                if (item.Confirmata)
                    confirmate++;
                if (item.Status == "Anulata")
                    anulate++;
                if (item.Status == "Noua")
                    noi++;
            }
            List<object> iData = new List<object>();
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Expense", System.Type.GetType("System.String"));
            dt.Columns.Add("ExpenseValues", System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();
            dr["Expense"] = "Programari confirmate";
            dr["ExpenseValues"] = confirmate;
            dt.Rows.Add(dr);
            DataRow dr2 = dt.NewRow();
            dr2["Expense"] = "Programari anulate";
            dr2["ExpenseValues"] = anulate;
            dt.Rows.Add(dr2);
            DataRow dr3 = dt.NewRow();
            dr3["Expense"] = "Programari noi";
            dr3["ExpenseValues"] = noi;
            dt.Rows.Add(dr3);           
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }

            return new JsonResult(iData);
        }
        [HttpPost]
        public async Task<JsonResult> GetRaportServicii()
        {

            var servicii = await (from p in _context.Servicii
                                  select new { p.Cod_serviciu, p.Denumire }).ToListAsync();

            var query = await (from p in _context.Programari
                               join s in _context.Saloane
                               on p.Salon.Cod_salon equals s.Cod_salon
                               join se in _context.Servicii
                               on p.Serviciu.Cod_serviciu equals se.Cod_serviciu
                               where s.Firma.Webuser.UserName == User.Identity.Name
                               select new { p.Serviciu.Denumire, p.Serviciu.Cod_serviciu }).ToListAsync();


           
            List<object> iData = new List<object>();

            DataTable dt = new DataTable();
            dt.Columns.Add("Expense", System.Type.GetType("System.String"));
            dt.Columns.Add("ExpenseValues", System.Type.GetType("System.Int32"));

            var count = 0;
            foreach (var serv in servicii)
            {
                foreach (var item in query)
                {
                    if (serv.Cod_serviciu == item.Cod_serviciu)
                    {
                        count++;
                    }
                }
                DataRow dr = dt.NewRow();
                dr["Expense"] = serv.Denumire;
                dr["ExpenseValues"] = count;
                dt.Rows.Add(dr);
                count = 0;
            }          

      
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }

            return new JsonResult(iData);
        }


    }
    
    
}