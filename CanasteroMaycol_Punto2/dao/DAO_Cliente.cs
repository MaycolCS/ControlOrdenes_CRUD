using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.dao
{
    class DAO_Cliente
    {
        private static Queries_CRUD generadorQueriesSQL;
        private static SqlConnection connection;
        private static SqlCommand cmd;
        public DAO_Cliente()
        {
        }

        //Constructor sobrecargado del DAO
        public DAO_Cliente(string cadenaConexion)
        {
            connection = new SqlConnection(cadenaConexion);
            Console.WriteLine("»»» Conexión establecida: " + connection + " «««\n");
            generadorQueriesSQL = new Queries_CRUD();
        }

        //************************************************************************************************************************************************
        //Método para realizar la inserción del registro
        //************************************************************************************************************************************************
        public bool insertarRegistro_Cliente(Cliente registroEntidad)
        {
            bool seInserto = false;
            string consulta = "";
            int totalFilas = 0;

            try
            {
                // Generar Query para realizar el Insert
                consulta = generadorQueriesSQL.generarConsultaInsert_Cliente();
                //Generamos el comando
                cmd = new SqlCommand(consulta, connection);
                //Abrimos la conexión
                connection.Open();

                //Seteamos los parámetros
                cmd.Parameters.AddWithValue("@clienteNombre", registroEntidad.ClienteNombre);
                cmd.Parameters.AddWithValue("@clienteCedula", registroEntidad.ClienteCedula);
                cmd.Parameters.AddWithValue("@clienteDireccion", registroEntidad.ClienteDireccion);
                cmd.Parameters.AddWithValue("@clienteNumero", registroEntidad.ClienteNumero);
                cmd.Parameters.AddWithValue("@clienteTipoPago", registroEntidad.ClienteTipoPago);

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
        public bool actualizarRegistro_Cliente(Cliente registroEntidad)
        {
            bool seModifico = false;
            string consulta = "";
            int totalFilas = 0;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaUpdate_Cliente();
                //Generamos el comando
                cmd = new SqlCommand(consulta, connection);
                //Abrimos la conexión
                connection.Open();
                //********************************************************************
                //********************************************************************
                //Seteamos los parámetros
                cmd.Parameters.AddWithValue("@clienteNombre", registroEntidad.ClienteNombre);
                cmd.Parameters.AddWithValue("@clienteDireccion", registroEntidad.ClienteDireccion);
                cmd.Parameters.AddWithValue("@clienteNumero", registroEntidad.ClienteNumero);
                cmd.Parameters.AddWithValue("@clienteTipoPago", registroEntidad.ClienteTipoPago);

                //Llave para el update
                cmd.Parameters.AddWithValue("@clienteCedula", registroEntidad.ClienteCedula);

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
        public bool eliminarRegistro_Cliente(int idCliente)
        {
            bool seElimino = false;
            string consulta = "";

            try
            {
                consulta = generadorQueriesSQL.generarConsultaDelete_Cliente();
                cmd = new SqlCommand(consulta, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@clienteCedula", idCliente);
                cmd.ExecuteNonQuery();
                seElimino = true;
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("El registro con ID " + idCliente + " se borró: " + seElimino);
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
        public Cliente consultarRegistro_Cliente(int idCliente)
        {
            Cliente registroConsultado = new Cliente();
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaSelect_Cliente();

                connection.Open();
                command = new SqlCommand(consulta, connection);
                Console.WriteLine("\nID DE CLIENTE A CONSULTAR: " + idCliente);
                command.Parameters.AddWithValue("@clienteCedula", idCliente);

                //Recorremos el cursor de la consulta para obtener los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado.ClienteCedula = cursor.GetInt32(0);
                        registroConsultado.ClienteNombre = cursor.GetString(1);
                        registroConsultado.ClienteDireccion = cursor.GetString(2);
                        registroConsultado.ClienteNumero = cursor.GetInt32(3);
                        registroConsultado.ClienteTipoPago = cursor.GetString(4);
                    }
                }
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
                Cliente registroVacio = new Cliente();
                registroVacio.ClienteCedula = 0;
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
