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
        SqlConnection cn = new SqlConnection(@"server=BETP\MSSQLSERVER01; database=proyectoDSW; integrated security= true");

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

        public string Login(Usuario u)
        {
            String mensaje = "";

            using (SqlCommand cmd = new SqlCommand("usp_validaAcceso", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", u.usuario);
                    cmd.Parameters.AddWithValue("@clave", u.clave);
                    cn.Open();//abrir antes de ejecutar
                    cmd.ExecuteNonQuery();
                    mensaje = "Ingresando";
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

        public Usuario buscarUsuario(string usuario){

            Usuario u = null;

            using (SqlCommand cmd = new SqlCommand("sp_buscarUsuario", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new Usuario()
                    {
                        clave = dr.GetString(5),

                    };
                }
                dr.Close();
                cn.Close();
            }

            return u;
        }

        public string Contra(Usuario u)

        {
            String mensaje = "";

            using (SqlCommand cmd = new SqlCommand("usp_recuperarcontra", cn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.AddWithValue("@clave", u.clave);
                    cn.Open();//abrir antes de ejecutar
                    cmd.ExecuteNonQuery();
                    mensaje = "Se cambio con exito";
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
