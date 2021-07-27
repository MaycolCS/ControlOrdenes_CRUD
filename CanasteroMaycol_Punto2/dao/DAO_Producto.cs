using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.dao
{
    class DAO_Producto
    {
        private static Queries_CRUD generadorQueriesSQL;
        private static SqlConnection connection;
        private static SqlCommand cmd;
        public DAO_Producto()
        {
        }

        //Constructor sobrecargado del DAO
        public DAO_Producto(string cadenaConexion)
        {
            connection = new SqlConnection(cadenaConexion);
            Console.WriteLine("»»» Conexión establecida: " + connection + " «««\n");
            generadorQueriesSQL = new Queries_CRUD();
        }

        //************************************************************************************************************************************************
        //Método para realizar la inserción del registro
        //************************************************************************************************************************************************
        public bool insertarRegistro_Producto(Producto registroEntidad)
        {
            bool seInserto = false;
            string consulta = "";
            int totalFilas = 0;

            try
            {
                // Generar Query para realizar el Insert
                consulta = generadorQueriesSQL.generarConsultaInsert_Producto();
                //Generamos el comando
                cmd = new SqlCommand(consulta, connection);
                //Abrimos la conexión
                connection.Open();

                //Seteamos los parámetros
                cmd.Parameters.AddWithValue("@productoCodigo", registroEntidad.ProductoCodigo);
                cmd.Parameters.AddWithValue("@productoNombre", registroEntidad.ProductoNombre);
                cmd.Parameters.AddWithValue("@productoCantidad", registroEntidad.ProductoCantidad);
                cmd.Parameters.AddWithValue("@productoPrecio", registroEntidad.ProductoPrecio);

                //Ejecutamos la query de actualización
                totalFilas = cmd.ExecuteNonQuery();
                seInserto = true;

                Console.WriteLine("Resultado de la inserción: " + seInserto + " - Se insertaron " + totalFilas + " filas en la tabla");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*********************************************");
            }

            catch (Exception errorInsertar)
            {
                Console.WriteLine("Error de inserción: " + errorInsertar.Message);
                Console.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return (seInserto);
        }
        //************************************************************************************************************************************************
        //Método para realizar la modificación del registro
        //************************************************************************************************************************************************
        public bool actualizarRegistro_Producto(Producto registroEntidad)
        {
            bool seModifico = false;
            string consulta = "";
            int totalFilas = 0;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaUpdate_Producto();
                //Generamos el comando
                cmd = new SqlCommand(consulta, connection);
                //Abrimos la conexión
                connection.Open();
                //********************************************************************
                //********************************************************************
                //Seteamos los parámetros
                cmd.Parameters.AddWithValue("@productoNombre", registroEntidad.ProductoNombre);
                cmd.Parameters.AddWithValue("@productoCantidad", registroEntidad.ProductoCantidad);
                cmd.Parameters.AddWithValue("@productoPrecio", registroEntidad.ProductoPrecio);

                //Llave para el update
                cmd.Parameters.AddWithValue("@productoCodigo", registroEntidad.ProductoCodigo);

                //Ejecutamos la query de actualización
                totalFilas = cmd.ExecuteNonQuery();
                seModifico = true;

                Console.WriteLine("Resultado de la modificación: " + seModifico + " - Se modificaron " + totalFilas + " filas en la tabla");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*********************************************");
            }

            catch (Exception errorInsertar)
            {
                Console.WriteLine("Error de modificación: " + errorInsertar.Message);
                Console.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return (seModifico);
        }
        //************************************************************************************************************************************************
        // Método para eliminar registro
        //************************************************************************************************************************************************
        public bool eliminarRegistro_Producto(int idProducto)
        {
            bool seElimino = false;
            string consulta = "";

            try
            {
                consulta = generadorQueriesSQL.generarConsultaDelete_Producto();
                cmd = new SqlCommand(consulta, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@productoCodigo", idProducto);
                cmd.ExecuteNonQuery();
                seElimino = true;
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("El registro con ID " + idProducto + " se borró: " + seElimino);
                Console.WriteLine("-------------------------------------------------------------------");
            }

            catch (Exception errorInsertar)
            {
                Console.WriteLine("Error de eliminación: " + errorInsertar.Message);
                Console.WriteLine("Error detallado: " + errorInsertar.ToString());
            }

            finally
            {
                if (cmd != null)
                {
                    cmd.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return (seElimino);
        }
        //************************************************************************************************************************************************
        // Método para consultar registro por ID
        //************************************************************************************************************************************************
        public Producto consultarRegistro_Producto(int idProducto)
        {
            Producto registroConsultado = new Producto();
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaSelect_Producto();

                connection.Open();
                command = new SqlCommand(consulta, connection);
                Console.WriteLine("\nID DE PRODUCTO A CONSULTAR: " + idProducto);
                command.Parameters.AddWithValue("@productoCodigo", idProducto);

                //Recorremos el cursor de la consulta para obtener los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado.ProductoCodigo = cursor.GetInt32(0);
                        registroConsultado.ProductoNombre = cursor.GetString(1);
                        registroConsultado.ProductoCantidad = cursor.GetInt32(2);
                        registroConsultado.ProductoPrecio = cursor.GetInt32(3);
                    }
                }
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
                Producto registroVacio = new Producto();
                registroVacio.ProductoCodigo = 0;
                return (registroVacio);
            }

            finally
            {
                //Libera los recursos de la transacción DML de consulta
                if (command != null)
                {
                    command.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return (registroConsultado);
        }
    }
}
