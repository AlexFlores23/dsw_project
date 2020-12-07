using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace PortalBuyPlay.Controllers
{
    public class BuyController : Controller
    {
        const string conexion = "server=;database=Negocios2020;uid=sa;pwd=sql";

        public ActionResult Index()
        {
            return View();
        }
    }
}