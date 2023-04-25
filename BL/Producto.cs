using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;

using System.Net.Http;

namespace BL
{
    public class Producto
    {


        public static ML.Result Add(ML.Producto producto)
        {
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                    {
                        using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                        {
                            cmd.CommandText = "INSERT INTO [Producto]([Nombre],[PrecioUnitario],[Stock],[Descripcion]) VALUES(@Nombre,@PrecioUnitario,@Stock,@Descripcion)";
                            //cmd.CommandText = "7777";
                            //cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] collection = new SqlParameter[4]; //Cantidad sin contemplar 0
                            collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                            collection[0].Value = producto.Nombre;
                            collection[1] = new SqlParameter("PrecioUnitario", System.Data.SqlDbType.VarChar);
                            collection[1].Value = producto.PrecioUnitario;
                            collection[2] = new SqlParameter("Stock", System.Data.SqlDbType.Int);
                            collection[2].Value = producto.Stock;
                            collection[3] = new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar);
                            collection[3].Value = producto.Descripcion;


                            cmd.Parameters.AddRange(collection);
                            cmd.Connection = context;

                            cmd.Connection.Open();
                            int RowAffeted = cmd.ExecuteNonQuery();
                            if (RowAffeted > 0)
                            {
                                result.Correct = true;

                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "Ocurrio un error al insertar en la tabla producto";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;
                    result.Ex = ex;

                }
                return result;

            }



        }
        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {
                        cmd.CommandText = "DELETE FROM [Producto] WHERE [IdProducto]=@IdProducto";

                        SqlParameter[] collection = new SqlParameter[1]; //Cantidad sin contemplar 0
                        collection[0] = new SqlParameter("IdProducto", System.Data.SqlDbType.Int);
                        collection[0].Value = IdProducto;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection = context;

                        cmd.Connection.Open();
                        int RowAffeted = cmd.ExecuteNonQuery();
                        if (RowAffeted > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al eliminar el producto";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;


            }
            return result;

        }
        public static ML.Result Update(ML.Producto producto)

        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {

                        cmd.CommandText = "UPDATE [Producto] SET [Nombre] = @Nombre, [PrecioUnitario] = @PrecioUnitario, [Stock] = @Stock, [Descripcion] = @Descripcion WHERE IdProducto = @IdProducto";


                        SqlParameter[] collection = new SqlParameter[5]; //Cantidad sin contemplar 0
                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;
                        collection[1] = new SqlParameter("PrecioUnitario", System.Data.SqlDbType.Decimal);
                        collection[1].Value = producto.PrecioUnitario;
                        collection[2] = new SqlParameter("Stock", System.Data.SqlDbType.Int);
                        collection[2].Value = producto.Stock;
                        collection[3] = new SqlParameter("Descripcion", System.Data.SqlDbType.VarChar);
                        collection[3].Value = producto.Descripcion;
                        collection[4] = new SqlParameter("IdProducto", System.Data.SqlDbType.Int);
                        collection[4].Value = producto.IdProducto;
                        cmd.Parameters.AddRange(collection);
                        cmd.Connection = context;

                        cmd.Connection.Open();
                        int RowAffeted = cmd.ExecuteNonQuery();
                        if (RowAffeted > 0)
                        {
                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al actualizar el producto";
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT [IdProducto],[Nombre],[PrecioUnitario],[Stock],[Descripcion] FROM [Producto]";
                        cmd.Connection = context;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaProducto = new DataTable();
                            da.Fill(tablaProducto);

                            if (tablaProducto.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablaProducto.Rows)
                                {
                                    ML.Producto producto = new ML.Producto();
                                    producto.IdProducto = int.Parse(row[0].ToString());
                                    producto.Nombre = row[1].ToString();
                                    producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                    producto.Stock = int.Parse(row[3].ToString());
                                    producto.Descripcion = row[4].ToString();
                                  //  producto.Proveedor = row[4].ToString();


                                    result.Objects.Add(producto);

                                    //Console.WriteLine("");
                                    //Console.WriteLine(row["IdUsuario"] + ",  " + row["Nombre"] + ",  " + row["ApellidoPaterno"]+ ",  " + row["ApellidoMaterno"] + ",  " + row["Correo"] + ",  " + row["FechaNacimiento"] + ",  ");

                                }
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "Error al buscar todos los usuarios";
                            }
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "SELECT [IdProducto],[Nombre],[PrecioUnitario],[Stock],[Descripcion] FROM [Producto] WHERE [IdProducto] = @IdProducto";
                        cmd.Connection = context;//conexion
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = IdProducto;

                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaProducto = new DataTable();
                            da.Fill(tablaProducto);
                            ////////////////////////////////////////
                            if (tablaProducto.Rows.Count > 0)
                            {
                                // Con el datarow creamos un objeto row
                                DataRow row = tablaProducto.Rows[0];
                                ML.Producto producto = new ML.Producto();
                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.PrecioUnitario = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());
                                producto.Descripcion = row[4].ToString();


                                result.Object = producto; //boxing
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "Error al buscar un usuario por id";
                            }
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }

        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.ProductoAdd(producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Departamento.IdDepartamento, producto.Proveedor.IdProveedor);

                    if (rowAffected > 0)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;

        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();// intancio result

            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities()) // conexion
                {
                    var productos = context.ProductoGetAll().ToList(); //declaro la variable usuarios que es =  la conexion, store procedure
                                                                       // que voy a ocupar en forma de lista

                    if (productos != null)
                    {
                        result.Objects = new List<object>(); // declaro la lista de objetos
                        foreach (var productoObj in productos) // recorremos la variable usuarioObj en usuarios
                        {
                            ML.Producto producto = new ML.Producto(); // instanciamos el obj usuario de la clase Usuario
                            producto.IdProducto = productoObj.IdProducto; // guardo los parametros en el usuarioObj
                            producto.Nombre = productoObj.Nombre;
                            producto.PrecioUnitario = productoObj.PrecioUnitario;
                            producto.Stock = productoObj.Stock;
                            producto.Descripcion = productoObj.Descripcion;
                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.Nombre = productoObj.NombreDepartamento;
                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.Nombre = productoObj.NombreArea;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.Nombre = productoObj.NombreProveedor;


                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdProducto)
        {
            ML.Result result = new ML.Result(); 
            try 
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities()) 
                {
                    var productoObj = context.ProductoGetById(IdProducto).Single();

                    if (productoObj != null)
                    {
                        ML.Producto producto = new ML.Producto(); // instanciamos el obj usuario de la clase Usuario
                        producto.IdProducto = productoObj.IdProducto; // guardo los parametros en el usuarioObj
                        producto.Nombre = productoObj.Nombre;
                        producto.PrecioUnitario = productoObj.PrecioUnitario;
                        producto.Stock = productoObj.Stock;
                        producto.Descripcion = productoObj.Descripcion;
                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.Nombre = productoObj.NombreDepartamento;
                        producto.Departamento.IdDepartamento = productoObj.IdDepartamento;
                        producto.Departamento.Area = new ML.Area();
                        producto.Departamento.Area.Nombre = productoObj.NombreArea;
                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.Nombre = productoObj.NombreProveedor;
                        producto.Proveedor.IdProveedor = productoObj.IdProveedor;


                        
                        result.Object = producto;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }

        public static ML.Result DeleteEF(int IdProducto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.ProductoDelete(IdProducto);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;


        }

        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();// instancio el obj result de la clase Result proveniente de la capa model layer

            try // try catch para ejecutar y capturar errores
            {          // conexion con ef
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.ProductoUpdate(producto.IdProducto,producto.Nombre, producto.PrecioUnitario, producto.Stock, producto.Descripcion, producto.Departamento.IdDepartamento, producto.Proveedor.IdProveedor);

                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error";
                    }
                }
            }
            catch (Exception ex) // excepcion aqui cacha los errores 
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result; // regresa el resultado
        }


    }


}






