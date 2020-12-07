using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBuyPay.Models
{
    public class Usuario
    {
        public int codigo_usu { get; set; }
        public int estado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string facceso { get; set; }
        public string fecNac { get; set; }
        public string sexo { get; set; }

    }
}