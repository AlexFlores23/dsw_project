using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ProyectoBuyPay;
using ProyectoBuyPay.Models;

namespace ProyectoBuyPay.Controllers
{
    public class EcommerceController : Controller
    {
        SqlConnection cn = new SqlConnection(
               @"server=BETP\MSSQLSERVER01; database=Negocios2020; integrated security= true");
        

        // GET: Ecommerce
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Usuario u)
        {
            String mensaje = "";

            using (SqlCommand cmd = new SqlCommand("sp_addUsuario", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", u.nombre);
                    cmd.Parameters.AddWithValue("@apellidos", u.apellido);
                    cmd.Parameters.AddWithValue("@fecha", u.fecNac);
                    cmd.Parameters.AddWithValue("@sexo", u.sexo);
                    cmd.Parameters.AddWithValue("@correo", u.usuario);
                    cmd.Parameters.AddWithValue("@clave", u.clave);
                    cn.Open();//abrir antes de ejecutar
                    cmd.ExecuteNonQuery();
                    mensaje = "Usuario registrado";
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    cn.Close();
                }
            }
            ViewBag.mensaje = mensaje;
            return Cliente();

        }
    }
}