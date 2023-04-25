using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        //metodos

        public static void Add()
        {
            //Console.WriteLine("Ingrese la informacion del usuario");
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese un nombre de usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el correo");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento dd-mm-yyyy :");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese el password");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese el Sexo F o M");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el Telefono");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el Celular");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Ingrese el ID Rol 1.admin ,2.Empleado,3.Usuario :");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            // direccion
            Console.WriteLine("Ingrese la calle donde vive: ");
            usuario.Direccion = new ML.Direccion();//// instancio direccion
            usuario.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Ingrese el numero interior: ");
            usuario.Direccion.NumeroInterior = Console.ReadLine();

            Console.WriteLine("Ingrese el numero exterior: ");
            usuario.Direccion.NumeroExterior = Console.ReadLine();

            Console.WriteLine("Ingrese el id de su colonia ej:1,2,3,etc... : ");
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            ////Instancia de Semestre
            ////ML.Semestre semestre = new ML.Semestre(); NO tiene relación con alumno
            //usuario.Rol = new ML.Rol();
            //usuario.Rol.IdRol = usuarioObj.IdRol.Value; //Solo cuando estamos seguros que viene un valor
            //result.Objects.Add(usuario);

            BL.Usuario.AddEF(usuario);



        }
        public static void Delete()
        {
            //Console.WriteLine("Ingrese el usuario");
            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese id del usuario que desea eliminar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            BL.Usuario.DeleteEF(usuario);
        }
        public static void Update()
        {
            //Console.WriteLine("Ingrese los datos a modificar");
            ML.Usuario usuario = new ML.Usuario();//intanciar el obj usuario
            usuario.Rol = new ML.Rol(); // intanciar los obj en caso de escritura
            
            Console.WriteLine("Ingrese id del usuario que desea modificar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo nombre ");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el nuevo apellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el correo");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento dd-mm-yyyy : ");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese el password");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el UserName");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese el Sexo F o M : ");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el Telefono: ");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el Celular: ");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP: ");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Ingrese el ID Rol 1.admin ,2.Empleado,3.Usuario : ");

            usuario.Rol.IdRol = int.Parse(Console.ReadLine());
            // direccion
            Console.WriteLine("Ingrese la calle donde vive: ");
            usuario.Direccion = new ML.Direccion();//// instancio direccion
            usuario.Direccion.Calle = Console.ReadLine();

            Console.WriteLine("Ingrese el numero interior: ");
            usuario.Direccion.NumeroInterior = Console.ReadLine();

            Console.WriteLine("Ingrese el numero exterior: ");
            usuario.Direccion.NumeroExterior = Console.ReadLine();

            Console.WriteLine("Ingrese el id de su colonia ej:1,2,3,etc... : ");
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.IdColonia = int.Parse(Console.ReadLine());

            BL.Usuario.UpdateEF(usuario);
        }
        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();// intancio mi obj usuario
            Console.WriteLine("Ingrese la informacion que se solicite");        // solicito datos
            Console.WriteLine("Ingrese el id del usuario que quiere buscar");
            usuario.IdUsuario = int.Parse(Console.ReadLine()); // guardo el dato y parseo

           // ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);
            ML.Result result = BL.Usuario.GetByIdEF( usuario.IdUsuario);

         
            if (result.Correct)
            {
                
          
              usuario = (ML.Usuario) result.Object;  // unboxing
                                                    // impresion
                //usuario.Rol = new ML.Rol();
               
                Console.WriteLine("El Id del Usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El nombre del Usuario es: " + usuario.Nombre);
                Console.WriteLine("El ApellidoPaterno del Usuario es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El ApellidoMaterno del Usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("El Email del Usuario es: " + usuario.Email);
                Console.WriteLine("El Fecha de Nacimiento del Usuario es: " + usuario.FechaNacimiento);
                Console.WriteLine("El password es: " + usuario.Password);
                Console.WriteLine("El username es: " + usuario.UserName);
                Console.WriteLine("El sexo es: " + usuario.Sexo);
                Console.WriteLine("El telefono es: " + usuario.Telefono);
                Console.WriteLine("El celular es: " + usuario.Celular);
                Console.WriteLine("El curp es: " + usuario.CURP);
                Console.WriteLine("El rol es: " + usuario.Rol.IdRol);
                Console.WriteLine("El del rol es: " + usuario.Rol.Nombre);
                Console.WriteLine("La calle donde vive es: " + usuario.Direccion.Calle);
                Console.WriteLine("El numero interior es: " + usuario.Direccion.NumeroInterior);
                Console.WriteLine("El numero exterior es: " + usuario.Direccion.NumeroExterior);
             //   Console.WriteLine("el id de la colonia es: " + usuario.Direccion.Colonia.IdColonia);
                Console.WriteLine("La colonia es: " + usuario.Direccion.Colonia.Nombre);

                Console.WriteLine("-------------------------------------");


            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }

      
        }
        public static void GetAll()
        {
            ML.Result result = BL.Usuario.GetAllEF();
            if (result.Correct)
            {
                

                foreach (ML.Usuario usuario in result.Objects)
                //ML.Usuario usuario in result.Objects
                {
                  

                    Console.WriteLine("El Id del Usuario es: " + usuario.IdUsuario);
                    Console.WriteLine("El nombre del Usuario es: " + usuario.Nombre);
                    Console.WriteLine("El ApellidoPaterno del Usuario es: " + usuario.ApellidoPaterno);
                    Console.WriteLine("El ApellidoMaterno del Usuario es: " + usuario.ApellidoMaterno);
                    Console.WriteLine("El Email del Usuario es: " + usuario.Email);
                    Console.WriteLine("El Fecha de Nacimiento del Usuario es: " + usuario.FechaNacimiento);
                    Console.WriteLine("El password es: " + usuario.Password);
                    Console.WriteLine("El username es: " + usuario.UserName);
                    Console.WriteLine("El sexo es: " + usuario.Sexo);
                    Console.WriteLine("El telefono es: " + usuario.Telefono);
                    Console.WriteLine("El celular es: " + usuario.Celular);
                    Console.WriteLine("El curp es: " + usuario.CURP);
                    Console.WriteLine("El rol es: " + usuario.Rol.IdRol);
                    Console.WriteLine("El Nombre del rol es: " + usuario.Rol.Nombre);
                    Console.WriteLine("La calle donde vive es: " + usuario.Direccion.Calle);
                    Console.WriteLine("El numero interior es: " + usuario.Direccion.NumeroInterior);
                    Console.WriteLine("El numero exterior es: " + usuario.Direccion.NumeroExterior);
              //      Console.WriteLine("el id de la colonia es: " + usuario.Direccion.Colonia.IdColonia);
                    Console.WriteLine("La colonia es: " + usuario.Direccion.Colonia.Nombre);




                    Console.WriteLine("-------------------------------------");

                   
                }
            }
            else
            {
                Console.WriteLine("Ocurrio error" + result.ErrorMessage);
            }
        }

      
    }
}
