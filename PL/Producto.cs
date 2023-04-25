using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PL
{
    public class Producto
    {
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese un nombre de producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el el precio unitario: ");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el numero de stock: ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion: ");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el id del departamento: ");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el id del proveedor: ");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            BL.Producto.AddEF(producto);

     
        }

        public static void Delete()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese id del producto que desea eliminar");
            producto.IdProducto = int.Parse(Console.ReadLine());

           
            BL.Producto.DeleteEF(producto.IdProducto);

            


        }

        public static void Update()
        {
            //Console.WriteLine("Ingrese la informacion del usuario");
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Ingrese id del producto que desea modificar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese un nombre de producto");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el el precio unitario");
            producto.PrecioUnitario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el numero de stock");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la descripcion");
            producto.Descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese el id del departamento: ");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el id del proveedor: ");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            BL.Producto.UpdateEF(producto);






        }

        public static void GetAll()
        {
            ML.Result result = BL.Producto.GetAllEF();
            

            if (result.Correct)
            {


                foreach (ML.Producto productos in result.Objects)
              
                {


                    Console.WriteLine("El id del producto es: " + productos.IdProducto);
                    Console.WriteLine("El nombre del producto es: " + productos.Nombre);
                    Console.WriteLine("El Precio Unitario del producto: " + productos.PrecioUnitario);
                    Console.WriteLine("La Cantidad en Stock del producto es: " + productos.Stock);
                    Console.WriteLine("La Descripcion del producto es: " + productos.Descripcion);
                    Console.WriteLine("El departamento es: " + productos.Departamento.Nombre);
                    Console.WriteLine("El provedor es: " + productos.Proveedor.Nombre);
                    Console.WriteLine("El area es: " + productos.Departamento.Area.Nombre);
                   




                    Console.WriteLine("-------------------------------------");


                }
            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }
        }

        public static void GetById()
        {
            ML.Producto producto = new ML.Producto();// intancio mi obj usuario
          //  Console.WriteLine("Ingrese la informacion que se solicite");        // solicito datos
            Console.WriteLine("Ingrese el id del usuario que quiere buscar");
            producto.IdProducto = int.Parse(Console.ReadLine()); // guardo el dato y parseo

            ML.Result result = BL.Producto.GetByIdEF(producto.IdProducto);


            if (result.Correct)
            {


                producto = (ML.Producto)result.Object;


                Console.WriteLine("El Id del producto es: " + producto.IdProducto);
                Console.WriteLine("El nombre del producto es: " + producto.Nombre);
                Console.WriteLine("El precio unitario es: " + producto.PrecioUnitario);
                Console.WriteLine("La cantidad en stock es: " + producto.Stock);
                Console.WriteLine("La descripcion del producto es: " + producto.Descripcion);
                Console.WriteLine("El departamento es: " + producto.Departamento.Nombre);
                Console.WriteLine("El provedor es: " + producto.Proveedor.Nombre);
                Console.WriteLine("El area es: " + producto.Departamento.Area.Nombre);


                Console.WriteLine("-------------------------------------");


            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }


        }

        public static void GetAllAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);
                //HTTP GET
                var responseTask = client.GetAsync("Producto");
                responseTask.Wait();


                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();


                    foreach (var productoItem in readTask.Result.Objects)
                    {
                        ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(productoItem.ToString());
                        //DeserializeObject
                        Console.WriteLine("IdProducto: " + resultItemList.IdProducto);
                        Console.WriteLine("Nombre: " + resultItemList.Nombre);
                        Console.WriteLine("PrecioUnitario: " + resultItemList.PrecioUnitario);
                        Console.WriteLine("Stock: " + resultItemList.Stock);
                        Console.WriteLine("Descripcion: " + resultItemList.Descripcion);
                        Console.WriteLine("Descripcion: " + resultItemList.Proveedor.Nombre);
                        Console.WriteLine("Descripcion: " + resultItemList.Departamento.Nombre);
                    }

                }

            }

        }
        public static void AddAPI()
        {
          
           
            using (var client = new HttpClient())
            {
                ML.Producto producto = new ML.Producto();
                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);

                //HTTP POST

                Console.WriteLine("Ingresa el nombre del producto");
                producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa el PrecioUni del producto");
                producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa cantidad en stock del producto");
                producto.Stock = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa la descripcion del producto");
                producto.Descripcion =Console.ReadLine();

                var postTask = client.PostAsJsonAsync<ML.Producto>("Producto", producto);

                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Registro con api exitoso");
                }
                else
                {
                    Console.WriteLine("Ocurrio un error");
                }

            }


        }
        public static void UpdateAPI()
        {


            using (var client = new HttpClient())
            {
                 ML.Producto producto = new ML.Producto();

                //HTTP POST
                Console.WriteLine("Ingresa el Id del producto");
                producto.IdProducto = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa el nombre del producto");
                producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa el PrecioUni del producto");
                producto.PrecioUnitario = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa cantidad en stock del producto");
                producto.Stock = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa la descripcion del producto");
                producto.Descripcion = Console.ReadLine();


                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);
                var putTask = client.PutAsJsonAsync<ML.Producto>("Producto/"+producto.IdProducto, producto);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Actualizacion con api exitosa");
                }
                else
                {
                    Console.WriteLine("Ocurrio un error");
                }

            }


        }

        public static void DeleteAPI()
        {

            using (var client = new HttpClient())
            {
                ML.Producto producto = new ML.Producto();

                //HTTP Delete
                Console.WriteLine("Ingresa el Id del producto");
                producto.IdProducto = int.Parse(Console.ReadLine());


                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);
                var delTask = client.DeleteAsync("Producto/" + producto.IdProducto);
                delTask.Wait();

                var result = delTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Delete con api exitoso");
                }
                else
                {
                    Console.WriteLine("Ocurrio un error en el borrado");
                }

            }
        }

        public static void GetByIdAPI()
        {
            using (HttpClient client = new HttpClient())
            {
               
                Console.WriteLine("Ingresa el Id del producto");
                 int idProducto = int.Parse(Console.ReadLine());
                //HTTP GET by id
                var url = ConfigurationManager.AppSettings["WebApiURL"].ToString();
                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("Producto/"+ idProducto);
                responseTask.Wait();


                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
        
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();


                    ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());

                    Console.WriteLine("IdProducto: " + resultItemList.IdProducto);
                    Console.WriteLine("Nombre: " + resultItemList.Nombre);
                    Console.WriteLine("PrecioUnitario: " + resultItemList.PrecioUnitario);
                    Console.WriteLine("Stock: " + resultItemList.Stock);
                    Console.WriteLine("Descripcion: " + resultItemList.Descripcion);

                    

                }

            }

        }

       
    }
}

