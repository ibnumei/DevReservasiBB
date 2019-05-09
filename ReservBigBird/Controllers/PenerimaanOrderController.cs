using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservBigBird.Models;

namespace ReservBigBird.Controllers
{
    public class PenerimaanOrderController : Controller
    {
        // GET: PenerimaanOrder
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _TableDate(PenerimaOrder penerimaOrder)
        {
            
            String tglawal = penerimaOrder.tglawalpilih.Substring(3, 2) + "/" + penerimaOrder.tglawalpilih.Substring(0, 2) + "/" + penerimaOrder.tglawalpilih.Substring(6, 4);

            String tglakhir = penerimaOrder.tglakhirpilih.Substring(3, 2) + "/" + penerimaOrder.tglakhirpilih.Substring(0, 2) + "/" + penerimaOrder.tglakhirpilih.Substring(6, 4);

            DateTime awal = DateTime.Parse(tglawal);
            DateTime akhir = DateTime.Parse(tglakhir);

            List<String> allDates = new List<String>();

            int starting = awal.Day;
            int ending = akhir.Day;

            for (DateTime date = awal; date <= akhir; date = date.AddDays(1))
            {
                allDates.Add(date.ToString("dd-MM-yyyy"));
            }

            ViewBag.tgl = allDates.ToList();
            return PartialView("_TableDate", allDates.ToList());
        }
    }
}