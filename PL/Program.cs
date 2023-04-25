using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opc;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. AgregarUsuario");
                Console.WriteLine("2. BorrarUsuario");
                Console.WriteLine("3. ModificarUsuario");
                Console.WriteLine("4. Buscar Todos los Usuarios");
                Console.WriteLine("5. Buscar por ID de usuario");
                Console.WriteLine("6. AgregarProducto");
                Console.WriteLine("7. BorrarProducto");
                Console.WriteLine("8. ModificarProducto");
                Console.WriteLine("9. Buscar Todos los productos");
                Console.WriteLine("10. Buscar producto por ID");
                Console.WriteLine("11. Salir");
                //Console.WriteLine("11. Sumar");
                //Console.WriteLine("12. Restar");
                //Console.WriteLine("13. Multiplicar");
                //Console.WriteLine("14. Dividir");
                //Console.WriteLine("15. Salir");
                Console.WriteLine("Ingrese una opcion: ");
                opc = int.Parse(Console.ReadLine());


                switch (opc)
                {
                    case 1:
                        PL.Usuario.Add();
                        break;
                    case 2:
                        PL.Usuario.Delete();
                        break;
                    case 3:
                        PL.Usuario.Update();
                        break;
                    case 4:
                        PL.Usuario.GetAll();
                        break;
                    case 5:
                      PL.Usuario.GetById();
                     break;
                    case 6:
                        PL.Producto.Add();
                        break;
                    case 7:
                        PL.Producto.Delete();
                        break;
                    case 8:
                        PL.Producto.Update();
                        break;
                    case 9:
                        PL.Producto.GetAll();
                        break;
                    case 10:
                        PL.Producto.GetById();
                        break;
                    //case 11:
                    //    PL.Calculadora.Suma();
                    //    break;
                    //case 12:
                    //    PL.Calculadora.Resta();
                    //    break;
                    //case 13:
                    //    PL.Calculadora.Multiplicacion();
                    //    break;
                    //case 14:
                    //    PL.Calculadora.Division();
                    //    break;
                    //case 15:
                    //    break;
                    //case 11:

                    //    return;

                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
                Console.WriteLine("Presione una tecla para limpiar");
                Console.ReadKey();
                Console.Clear();

            }

            while (opc != 11);



        }
    }
}
