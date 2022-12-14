using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen_Final.Clases
{
    public class ClsUsuario
    {
        public static string correo { get; set; }
        public static string clave { get; set; }
        public static string nombre { get; set; }
        public static string apellido { get; set; }


        public static int Agregar(string Nomb, string Apelli, string Corr, string clave )
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("NewUser", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nomb));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", Apelli));
                    cmd.Parameters.Add(new SqlParameter("@User", Corr));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));
                 

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static int ModificarCliente(string Nombre, string Apellido, string Correo, string Clave)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarUser", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", Apellido));
                    cmd.Parameters.Add(new SqlParameter("@Clave", Clave));
                    cmd.Parameters.Add(new SqlParameter("@User", Correo));
                
                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int BuscarUsuario(string Correo)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Select * from Usuarios where Usuario='"+Correo+"'", Conn);                 
                    
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ClsUsuario.clave = rdr["Clave"].ToString();
                            ClsUsuario.nombre = rdr["Nombre"].ToString();
                            ClsUsuario.apellido = rdr["Apellido"].ToString();
                            ClsUsuario.correo = rdr["Usuario"].ToString();
                         
                            retorno = 1;
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }
        public static int BuscarPlaca(string Correo)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("Select * from Placa where NumeroPlaca = '"+Correo+"'", Conn);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ClsUsuario.clave = rdr["NumeroPlaca"].ToString();
                            ClsUsuario.nombre = rdr["Id_Usuario"].ToString();
                            ClsUsuario.apellido = rdr["Monto"].ToString();
                            retorno = 1;
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }
        public static int BorrarUser(string User)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EliminarUser", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@User", User));
                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int AgregarPlaca(string Nomb, int id, float monto)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("NewPlaca", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Numplaca", Nomb));
                    cmd.Parameters.Add(new SqlParameter("@iduser", id));
                    cmd.Parameters.Add(new SqlParameter("@Monto", monto));


                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static int ModificarPlaca(string Numplaca, string NPlca, int id, float monto)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarPlaca", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Numplaca", Numplaca));
                    cmd.Parameters.Add(new SqlParameter("@Nplaca", NPlca));
                    cmd.Parameters.Add(new SqlParameter("@iduser", id));
                    cmd.Parameters.Add(new SqlParameter("@Monto", monto));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static int BorrarPlaca(string placa)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EliminarPlaca", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@Nplaca", placa));
                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static DataTable Listar(string Cod)
        {
            int retorno = 1;
            SqlConnection Conn = new SqlConnection();
            DataTable dt = new DataTable();

            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {

                    SqlCommand cmd = new SqlCommand("Reporte", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NumPlaca", Cod));

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        retorno = cmd.ExecuteNonQuery();
                        cmd.Connection = Conn;
                        sda.SelectCommand = cmd;
                        using (dt = new DataTable())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                // Conn.Close();
            }
            return dt;
        }
        public static int ValidarLogin(string Correo, string Clave)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ValidarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Email", Correo));
                    cmd.Parameters.Add(new SqlParameter("@Clave", Clave));

                    // retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            
                            retorno = 1;
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

    }
}