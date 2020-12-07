using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfBuyPay
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract] String Agregar(Usuario u);
        [OperationContract] String Login(Usuario u);
        [OperationContract] Usuario buscarUsuario(string usuario);
        [OperationContract] String Contra(Usuario u);
    }

   [DataContract]
    public class Usuario
    {

        [DataMember] public int codigo_usu { get; set;}
        [DataMember] public int estado { get; set; }
        [DataMember]public string nombre{ get; set; }
        [DataMember] public string apellido { get; set; }
        [DataMember] public string usuario { get; set; }
        [DataMember] public string clave { get; set; }
        [DataMember] public string facceso { get; set; }
        [DataMember] public string fecNac { get; set; }
        [DataMember] public string sexo { get; set; }

    }
}
