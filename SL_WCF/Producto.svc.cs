using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Producto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Producto.svc o Producto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Producto : IProducto
    {
       
        public SL_WCF.Result Add(ML.Producto producto)
        {
            var resultml = BL.Producto.Add(producto);
            return new SL_WCF.Result
            {
              
                Correct = resultml.Correct,
               
                ErrorMessage = resultml.ErrorMessage
            };
        }
        public SL_WCF.Result Delete(int IdProducto)
        {
            var resultml = BL.Producto.Delete(IdProducto);
            return new SL_WCF.Result
            {

                Correct = resultml.Correct,

                ErrorMessage = resultml.ErrorMessage
            };
        }

        public SL_WCF.Result Update(ML.Producto producto)
        {
            var resultml = BL.Producto.Update(producto);
            return new SL_WCF.Result
            {

                Correct = resultml.Correct,

                ErrorMessage = resultml.ErrorMessage
            };
        }
        public SL_WCF.Result GetAll()
        {
            var resultml = BL.Producto.GetAll();
            return new SL_WCF.Result
            {

                Correct = resultml.Correct,

                ErrorMessage = resultml.ErrorMessage,

                Object = resultml.Object,

                Objects = resultml.Objects
            };
        }

        public SL_WCF.Result GetById(int IdProducto)
        {
            var resultml = BL.Producto.GetById(IdProducto);
            return new SL_WCF.Result
            {

                Correct = resultml.Correct,

                ErrorMessage = resultml.ErrorMessage,

                   Object = resultml.Object,

                Objects = resultml.Objects
            };
        }


    }
}
