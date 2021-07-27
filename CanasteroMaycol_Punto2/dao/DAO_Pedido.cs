using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.dao
{
    class DAO_Pedido
    {
        private static Queries_CRUD generadorQueriesSQL;
        private static SqlConnection connection;
        private static SqlCommand cmd;
        public DAO_Pedido()
        {
        }

        //Constructor sobrecargado del DAO
        public DAO_Pedido(string cadenaConexion)
        {
            connection = new SqlConnection(cadenaConexion);
            Console.WriteLine("»»» Conexión establecida: " + connection + " «««\n");
            generadorQueriesSQL = new Queries_CRUD();
        }

        //************************************************************************************************************************************************
        //Método para realizar la inserción del registro
        //************************************************************************************************************************************************
        public bool insertarRegistro_Pedido(Pedido registroEntidad)
        {
            bool seInserto = false;
            string consulta = "";
            int totalFilas = 0;

            try
            {
                // Generar Query para realizar el Insert
                consulta = generadorQueriesSQL.generarConsultaInsert_Pedido();
                //Generamos el comando
                cmd = new SqlCommand(consulta, connection);
                //Abrimos la conexión
                connection.Open();

                //Seteamos los parámetros
                cmd.Parameters.AddWithValue("@pedidoNumero", registroEntidad.PedidoNumero);
                cmd.Parameters.AddWithValue("@pedidoCliente", registroEntidad.PedidoCliente);
                cmd.Parameters.AddWithValue("@pedidoProducto", registroEntidad.PedidoProducto);
                cmd.Parameters.AddWithValue("@pedidoCantidad", registroEntidad.PedidoCantidad);

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
        public bool actualizarRegistro_Pedido(Pedido registroEntidad)
        {
            bool seModifico = false;
            string consulta = "";
            int totalFilas = 0;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaUpdate_Pedido();
                //Generamos el comando
                cmd = new SqlCommand(consulta, connection);
                //Abrimos la conexión
                connection.Open();
                //********************************************************************
                //********************************************************************
                //Seteamos los parámetros
                cmd.Parameters.AddWithValue("@pedidoCliente", registroEntidad.PedidoCliente);
                cmd.Parameters.AddWithValue("@pedidoProducto", registroEntidad.PedidoProducto);
                cmd.Parameters.AddWithValue("@pedidoCantidad", registroEntidad.PedidoCantidad);

                //Llave para el update
                cmd.Parameters.AddWithValue("@pedidoNumero", registroEntidad.PedidoNumero);

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
        public bool eliminarRegistro_Pedido(int idPedido)
        {
            bool seElimino = false;
            string consulta = "";

            try
            {
                consulta = generadorQueriesSQL.generarConsultaDelete_Pedido();
                cmd = new SqlCommand(consulta, connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@pedidoNumero", idPedido);
                cmd.ExecuteNonQuery();
                seElimino = true;
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("El registro con ID " + idPedido + " se borró: " + seElimino);
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
        public Pedido consultarRegistro_Pedido(int idPedido)
        {
            Pedido registroConsultado = new Pedido();
            string consulta = "";
            SqlCommand command = null;
            SqlDataReader cursor = null;

            try
            {
                consulta = generadorQueriesSQL.generarConsultaSelect_Pedido();

                connection.Open();
                command = new SqlCommand(consulta, connection);
                Console.WriteLine("\nID DE PEDIDO A CONSULTAR: " + idPedido);
                command.Parameters.AddWithValue("@pedidoNumero", idPedido);

                //Recorremos el cursor de la consulta para obtener los datos usando un sqlDataReader
                cursor = command.ExecuteReader();

                if (cursor != null)
                {
                    while (cursor.Read())
                    {
                        registroConsultado.PedidoNumero = cursor.GetInt32(0);
                        registroConsultado.PedidoCliente = cursor.GetInt32(1);
                        registroConsultado.PedidoProducto = cursor.GetInt32(2);
                        registroConsultado.PedidoCantidad = cursor.GetInt32(3);
                    }
                }
            }

            catch (Exception errorLectura)
            {
                Console.WriteLine("Error de consulta: " + errorLectura.Message);
                Pedido registroVacio = new Pedido();
                registroVacio.PedidoNumero = 0;
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
