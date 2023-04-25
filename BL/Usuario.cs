using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ML;
using System.Globalization;
using System.Data;

namespace BL
{
    public class Usuario
    {
        //metodos
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {
                        cmd.CommandText = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[FechaNacimiento]) VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Email,@FechaNacimiento)";

                        SqlParameter[] collection = new SqlParameter[5]; //Cantidad sin contemplar 0
                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;
                        collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;
                        collection[3] = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.Email;
                        collection[4] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

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
                            result.ErrorMessage = "Ocurrio un error al insertar en la tabla usuario";
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
        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {
                        cmd.CommandText = "DELETE FROM [Usuario] WHERE [IdUsuario]=@IdUsuario";

                        SqlParameter[] collection = new SqlParameter[1]; //Cantidad sin contemplar 0
                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

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
                            result.ErrorMessage = "Ocurrio un error al eliminar el usuario";
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
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {

                        cmd.CommandText = "UPDATE [Usuario] SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno, [ApellidoMaterno] = @ApellidoMaterno, [Email] = @Email,[FechaNacimiento] = @FechaNacimiento WHERE IdUsuario = @IdUsuario";

                        SqlParameter[] collection = new SqlParameter[6]; //Cantidad sin contemplar 0
                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;
                        collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;
                        collection[3] = new SqlParameter("Email", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.Email;
                        collection[4] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;
                        collection[5] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[5].Value = usuario.IdUsuario;
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
                            result.ErrorMessage = "Ocurrio un error al actualizar el usuario";
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
                        cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[FechaNacimiento] FROM [Usuario]";
                        cmd.Connection = context;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaUsuario = new DataTable();
                            da.Fill(tablaUsuario);

                            if (tablaUsuario.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablaUsuario.Rows)
                                {
                                    ML.Usuario usuario = new ML.Usuario();
                                    usuario.IdUsuario = int.Parse(row[0].ToString());
                                    usuario.Nombre = row[1].ToString();
                                    usuario.ApellidoPaterno = row[2].ToString();
                                    usuario.ApellidoMaterno = row[3].ToString();
                                    usuario.Email = row[4].ToString();
                                    usuario.FechaNacimiento = row[5].ToString();

                                    result.Objects.Add(usuario);

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

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Email],[FechaNacimiento] FROM [Usuario] WHERE [IdUsuario] = @IdUsuario";
                        cmd.Connection = context;//conexion
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaUsuario = new DataTable();
                            da.Fill(tablaUsuario);
                            ////////////////////////////////////////
                            if (tablaUsuario.Rows.Count > 0)
                            {
                                // Con el datarow creamos un objeto row
                                DataRow row = tablaUsuario.Rows[0];
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.Email = row[4].ToString();
                                usuario.FechaNacimiento = row[5].ToString();

                                // Console.WriteLine(row["IdUsuario"] + ",  " + row["Nombre"] + ",  " + row["ApellidoPaterno"] + ",  " + row["ApellidoMaterno"] + ",  " + row["Correo"] + ",  " + row["FechaNacimiento"] + ",  ");
                                result.Object = usuario; //boxing
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

        public static ML.Result AddSP(ML.Usuario usuario)
        {
            {
                ML.Result result = new ML.Result();
                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                    {
                        using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                        {
                            //cmd.CommandText = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Correo],[FechaNacimiento]) VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Correo,@FechaNacimiento)";
                            cmd.CommandText = "UsuarioAdd";
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] collection = new SqlParameter[5]; //Cantidad sin contemplar 0
                            collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                            collection[0].Value = usuario.Nombre;
                            collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                            collection[1].Value = usuario.ApellidoPaterno;
                            collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                            collection[2].Value = usuario.ApellidoMaterno;
                            collection[3] = new SqlParameter("Correo", System.Data.SqlDbType.VarChar);
                            collection[3].Value = usuario.Email;
                            collection[4] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.VarChar);
                            collection[4].Value = usuario.FechaNacimiento;

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
                                result.ErrorMessage = "Ocurrio un error al insertar en la tabla usuario";
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
        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {
                        //cmd.CommandText = "DELETE FROM [Usuario] WHERE [IdUsuario]=@IdUsuario";
                        cmd.CommandText = "UsuarioDelete";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1]; //Cantidad sin contemplar 0
                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

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
                            result.ErrorMessage = "Ocurrio un error al eliminar el usuario";
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
        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand()) //Enviar Parametros, Sentencia SQL(Query), Instrucciones, Transact-SQL
                    {

                        //cmd.CommandText = "UPDATE [Usuario] SET [Nombre] = @Nombre, [ApellidoPaterno] = @ApellidoPaterno, [ApellidoMaterno] = @ApellidoMaterno, [Correo] = @Correo,[FechaNacimiento] = @FechaNacimiento WHERE IdUsuario = @IdUsuario";
                        cmd.CommandText = "UsuarioUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[6]; //Cantidad sin contemplar 0
                        collection[0] = new SqlParameter("Nombre", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;
                        collection[1] = new SqlParameter("ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;
                        collection[2] = new SqlParameter("ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;
                        collection[3] = new SqlParameter("Correo", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.Email;
                        collection[4] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.DateTime);
                        collection[4].Value = usuario.FechaNacimiento;
                        collection[5] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[5].Value = usuario.IdUsuario;
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
                            result.ErrorMessage = "Ocurrio un error al actualizar el usuario";
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

        public static ML.Result GetlAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        //cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Correo],[FechaNacimiento] FROM [Usuario]";
                        cmd.CommandText = "SelectAll";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Connection = context;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaUsuario = new DataTable();
                            da.Fill(tablaUsuario);

                            if (tablaUsuario.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tablaUsuario.Rows)
                                {
                                    ML.Usuario usuario = new ML.Usuario();
                                    usuario.IdUsuario = int.Parse(row[0].ToString());
                                    usuario.Nombre = row[1].ToString();
                                    usuario.ApellidoPaterno = row[2].ToString();
                                    usuario.ApellidoMaterno = row[3].ToString();
                                    usuario.Email = row[4].ToString();
                                    usuario.FechaNacimiento = row[5].ToString();

                                    result.Objects.Add(usuario);

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
        public static ML.Result GetByIdSP(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        //cmd.CommandText = "SELECT [IdUsuario],[Nombre],[ApellidoPaterno],[ApellidoMaterno],[Correo],[FechaNacimiento] FROM [Usuario] WHERE [IdUsuario] = @IdUsuario";
                        //cmd.Connection = context;//conexion
                        cmd.CommandText = "UsuarioById";
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable tablaUsuario = new DataTable();
                            da.Fill(tablaUsuario);
                            ////////////////////////////////////////
                            if (tablaUsuario.Rows.Count > 0)
                            {
                                // Con el datarow creamos un objeto row
                                DataRow row = tablaUsuario.Rows[0];
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.Email = row[4].ToString();
                                usuario.FechaNacimiento = row[5].ToString();

                                // Console.WriteLine(row["IdUsuario"] + ",  " + row["Nombre"] + ",  " + row["ApellidoPaterno"] + ",  " + row["ApellidoMaterno"] + ",  " + row["Correo"] + ",  " + row["FechaNacimiento"] + ",  ");
                                result.Object = usuario; //boxing
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
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.FechaNacimiento, usuario.Password, usuario.UserName, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

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

        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioDelete(usuario.IdUsuario);

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

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();// instancio el obj result de la clase Result proveniente de la capa model layer

            try // try catch para ejecutar y capturar errores
            {          // conexion con ef
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())
                {
                    int rowAffected = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.FechaNacimiento, usuario.Password, usuario.UserName, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol,usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

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
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();// intancio result

            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities()) // conexion
                {
                    var usuarios = context.UsuarioGetAll().ToList(); //declaro la variable usuarios que es =  la conexion, store procedure
                                                                     // que voy a ocupar en forma de lista

                    if (usuarios != null)
                    {
                        result.Objects = new List<object>(); // declaro la lista de objetos
                        foreach (var usuarioObj in usuarios) // recorremos la variable usuarioObj en usuarios
                        {
                            ML.Usuario usuario = new ML.Usuario(); // instanciamos el obj usuario de la clase Usuario
                            usuario.IdUsuario = usuarioObj.IdUsuario; // guardo los parametros en el usuarioObj
                            usuario.Nombre = usuarioObj.NombreUsuario;
                            usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
                            usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
                            usuario.Email = usuarioObj.Email;
                            usuario.FechaNacimiento = usuarioObj.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.UserName = usuarioObj.UserName;
                            usuario.Password = usuarioObj.Password;
                            usuario.Sexo = usuarioObj.Sexo;
                            usuario.Telefono = usuarioObj.Telefono;
                            usuario.Celular = usuarioObj.Celular;
                            usuario.CURP = usuarioObj.CURP;
                         


                            //Instancia de Rol
                            //ML.Rol rol = new ML.Semestre(); NO tiene relación con usuario
                            usuario.Rol = new ML.Rol();// instancia de usuario.rol proveniente de la clase Rol
                            usuario.Rol.IdRol = usuarioObj.IdRol.Value; //Solo cuando estamos seguros que viene un valor
                            usuario.Rol.Nombre = usuarioObj.NombreRol;
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Calle = usuarioObj.Calle;
                            usuario.Direccion.NumeroInterior = usuarioObj.NumeroInterior;
                            usuario.Direccion.NumeroExterior = usuarioObj.NumeroExterior;
                            usuario.Direccion.Colonia = new ML.Colonia();
                          //  usuario.Direccion.Colonia.IdColonia = usuarioObj.IdColonia.Value;
                            usuario.Direccion.Colonia.Nombre = usuarioObj.Colonia;



                            result.Objects.Add(usuario);
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

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result(); // instancio el obj result de la clase result de la capa de modelo
            try // try ejecuta mi codigo y en catch captura el error para verificar bien que fallo
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities()) // conexion siempre se llama context
                {
                    var usuarioObj = context.UsuarioGetById(IdUsuario).Single(); // creo mi variable usuario obj que va ser igual a la conexion ya
                                                                                 //que ef tiene guardados los procedures, single regresa solamente el elemento especifico
                                                                                 // en este caso el ID es conveniente utilizarlo para que nos regrese un null y utilicemos la Excepcion
                    if (usuarioObj != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = usuarioObj.IdUsuario;
                        usuario.Nombre = usuarioObj.NombreUsuario;
                        usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
                        usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
                        usuario.Email = usuarioObj.Email;
                        usuario.FechaNacimiento = usuarioObj.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Password = usuarioObj.Password;
                        usuario.UserName = usuarioObj.UserName;
                        usuario.Sexo = usuarioObj.Sexo;
                        usuario.Telefono = usuarioObj.Telefono;
                        usuario.Celular = usuarioObj.Celular;
                        usuario.CURP = usuarioObj.CURP;
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = usuarioObj.IdRol.Value;
                        usuario.Rol.Nombre = usuarioObj.NombreRol;
                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Calle = usuarioObj.Calle;
                        usuario.Direccion.NumeroInterior = usuarioObj.NumeroInterior;
                        usuario.Direccion.NumeroExterior = usuarioObj.NumeroExterior;
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Nombre = usuarioObj.Colonia;
                       // usuario.Direccion.Colonia.IdColonia = usuarioObj.IdColonia.Value;
                        result.Correct = true;
                        result.Object = usuario;


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

        public static ML.Result AddLINQ(ML.Usuario usuario) // instacio el model y obj usuario para poder ingresar despues//tambien instacio ml result 
        {
            ML.Result result = new ML.Result();// instancio mi obj result
            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())//conexion con ef
                {
                    DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();// instancio mi  obj usuarioLINQ
                    usuarioLINQ.Nombre = usuario.Nombre;  // comienzo a guardar mis datos en el obj usuario
                    usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLINQ.Email = usuario.Email;
                    // usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);

                    usuarioLINQ.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    usuarioLINQ.Password = usuario.Password;
                    usuarioLINQ.UserName = usuario.UserName;
                    usuarioLINQ.Sexo = usuario.Sexo;
                    usuarioLINQ.Telefono = usuario.Telefono;
                    usuarioLINQ.Celular = usuario.Celular;
                    usuarioLINQ.CURP = usuario.CURP;
                    usuarioLINQ.IdRol = usuario.Rol.IdRol;

                    //context
                    context.Usuarios.Add(usuarioLINQ);
                    //creo la variable rowAfeccted para validar despues

                    int rowAffected = context.SaveChanges(); // el metodo savechange me ayudara a guardar mi consulta y se vea reflejado
                                                             // gracias a context que es la comunicacion entre mi bd y ef



                    if (rowAffected > 0)// hago mi validacion si es > entonces fue correcto de lo contrario paso un error
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false; // error
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
        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())// contex es la conexion con ef y mi bd
                {

                    var usuarioObj = (from obj in context.Usuarios where obj.IdUsuario == usuario.IdUsuario select obj).First();
                    context.Usuarios.Remove(usuarioObj);
                    context.SaveChanges();


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
        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())// contex es la conexion con ef y mi bd
                {


                    var usuariosLINQ = (from obj in context.Usuarios select obj).ToList();

                    if (usuariosLINQ != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var usuarios in usuariosLINQ)

                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = usuarios.IdUsuario;
                            usuario.Nombre = usuarios.Nombre;
                            usuario.ApellidoPaterno = usuarios.ApellidoPaterno;
                            usuario.ApellidoMaterno = usuarios.ApellidoMaterno;
                            usuario.Email = usuarios.Email;
                            //usuario.FechaNacimiento = DateTime.ParseExact(usuarios.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            usuario.Password = usuarios.Password;
                            usuario.UserName = usuarios.UserName;
                            usuario.Sexo = usuarios.Sexo;
                            usuario.Telefono = usuarios.Telefono;
                            usuario.Celular = usuarios.Celular;
                            usuario.CURP = usuarios.CURP;
                            //ML.Rol Rol = new ML.Rol();
                            //ML.Rol usuario= new 
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = usuarios.IdRol.Value;
                            usuario.Rol.Nombre = usuarios.Rol.Nombre;

                            result.Objects.Add(usuario);


                        }
                        result.Correct = true;



                    }
                    else
                    {
                        result.Correct = false; // error
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
            //.GetEnumerator()
        }

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())// contex es la conexion con ef y mi bd
                {
                    var usuarioLINQ = (from obj in context.Usuarios where obj.IdUsuario == usuario.IdUsuario select obj).SingleOrDefault();

                    if (usuarioLINQ != null)
                    {

                        usuarioLINQ.Nombre = usuario.Nombre;  // comienzo a guardar mis datos en el obj usuario
                        usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioLINQ.Email = usuario.Email;
                        usuarioLINQ.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        usuarioLINQ.Password = usuario.Password;
                        usuarioLINQ.UserName = usuario.UserName;
                        usuarioLINQ.Sexo = usuario.Sexo;
                        usuarioLINQ.Telefono = usuario.Telefono;
                        usuarioLINQ.Celular = usuario.Celular;
                        usuarioLINQ.CURP = usuario.CURP;
                        usuarioLINQ.IdRol = usuario.Rol.IdRol;
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el usuario" + usuario.IdUsuario;
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

        public static ML.Result GetByIDLINQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EGarciaProgramacionNCapasEntities context = new DL_EF.EGarciaProgramacionNCapasEntities())// contex es la conexion con ef y mi bd
                {
                    
                    var usuarioObj = (from obj in context.Usuarios where obj.IdUsuario == IdUsuario select obj).Single();



                    if (usuarioObj != null)
                    {


                        ML.Usuario usuario = new ML.Usuario();
                    
                       usuario.IdUsuario = usuarioObj.IdUsuario;
                        
                        usuario.Nombre = usuarioObj.Nombre;
                        usuario.ApellidoPaterno = usuarioObj.ApellidoPaterno;
                        usuario.ApellidoMaterno = usuarioObj.ApellidoMaterno;
                        usuario.Email = usuarioObj.Email;
                       // usuario.FechaNacimiento = DateTime.ParseExact(usuarioObj.FechaNacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        usuario.Password = usuarioObj.Password;
                        usuario.UserName = usuarioObj.UserName;
                        usuario.Sexo = usuarioObj.Sexo;
                        usuario.Telefono = usuarioObj.Telefono;
                        usuario.Celular = usuarioObj.Celular;
                        usuario.CURP = usuarioObj.CURP;
                        
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = usuarioObj.Rol.IdRol;
                        usuario.Rol.Nombre = usuarioObj.Rol.Nombre;


                        result.Object = usuario;
                        result.Correct = true;

                    }

                    





                    else
                    {
                        result.Correct = false; // error
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
    }
}
