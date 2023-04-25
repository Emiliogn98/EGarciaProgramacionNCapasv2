using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Saludar" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Saludar.svc o Saludar.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Saludar : ISaludar
    {
        public string Saludo(string nombre)
        {
            return string.Format("Hola: " + nombre);
        }
    }
}
