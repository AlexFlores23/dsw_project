using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WcfBuyPay
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        SqlConnection cn = new SqlConnection(@"server=BETP\MSSQLSERVER01; database=Negocios2020; integrated security= true");

        public string Agregar(Usuario u)
        {
            String mensaje = "";

            using (SqlCommand cmd = new SqlCommand("sp_addUsuario", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", u.nombre);
                    cmd.Parameters.AddWithValue("@apellido", u.apellido);
                    cmd.Parameters.AddWithValue("@usuario", u.usuario);
                    cmd.Parameters.AddWithValue("@clave", u.clave);
                    cn.Open();//abrir antes de ejecutar
                    cmd.ExecuteNonQuery();
                    mensaje = "Usuario Registrado ";
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
            return mensaje;
        }

        public string login(Usuario u)
        {
            string mensaje;
            using (SqlCommand cmd = new SqlCommand("sp_addUsuario", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", u.nombre);
                    cmd.Parameters.AddWithValue("@apellido", u.apellido);
                    cmd.Parameters.AddWithValue("@usuario", u.usuario);
                    cmd.Parameters.AddWithValue("@clave", u.clave);
                    cn.Open();//abrir antes de ejecutar
                    cmd.ExecuteNonQuery();
                    mensaje = "Usuario Registrado ";
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
            return mensaje;

        }
    }
}
