using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoBuyPlay.ServiceReference1;

namespace ProyectoBuyPlay.Controllers
{
    public class EcommerceController : Controller
    {
        Service1Client servicio = new Service1Client();
        // GET: Ecommerce
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CrearUsuario()
        {
            
            return RedirectToAction("Login");
        }
        [HttpPost]public ActionResult CrearUsuario(Usuario u)
        {
            ViewBag.mensaje = servicio.Agregar(u);
            return RedirectToAction("Index");
        }
        public ActionResult Login(string usuario=null, string clave=null)
        {
            return RedirectToAction("Index");
        }
        [HttpPost]public ActionResult Login(Usuario u)
        {
            ViewBag.mensaje = servicio.Login(u);
            return RedirectToAction("Index");
        }

        public ActionResult RecuperaCuenta(string usuario=null)
        {
            Usuario u = servicio.buscarUsuario(usuario);
            return View(u);

        }
        [HttpPost] public ActionResult RecuperaCuenta(Usuario u)
        {
            ViewBag.mesaje = servicio.Contra(u);
            return View(u);
        }
    }
}