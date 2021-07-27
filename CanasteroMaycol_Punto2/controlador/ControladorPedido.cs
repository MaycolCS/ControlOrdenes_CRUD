using CanasteroMaycol_Punto2.dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.controlador
{
    class Controlador_Pedido
    {
        private static DAO_Pedido fachadaServiciosDAO_Pedido;
        public Controlador_Pedido()
        {
            String cadenaConexion = "";
            cadenaConexion = ConfigurationManager.ConnectionStrings["CanasteroMaycol_Punto2.Properties.Settings.CanasteroMaycol_Punto2ConnectionString"].ConnectionString;
            //Console.WriteLine("Cadena conexion: " + cadenaConexion);
            fachadaServiciosDAO_Pedido = new DAO_Pedido(cadenaConexion);
        }

        // Metodos validacion datos

        public bool validarNumerosInt(string valor)
        {
            try
            {
                int.Parse(valor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int convertirToInt(string valor)
        {
            int resultado = Int32.Parse(valor);
            return resultado;
        }

        public int ingresoConsolaEntero(string mensaje)
        {
            bool valid_1 = false;
            int valorEntero = 0;
            while (!valid_1)
            {
                Console.Write(mensaje);
                string inputInt = System.Console.ReadLine();
                bool valid_2 = validarNumerosInt(inputInt);
                if (valid_2)
                {
                    valorEntero = convertirToInt(inputInt);
                    valid_1 = true;
                }
            }
            return valorEntero;
        }

        public string ingresoConsolaString(string mensaje)
        {
            bool valid_1 = false;
            string valorString = "";
            while (!valid_1)
            {
                Console.Write(mensaje);
                string inputString = System.Console.ReadLine();
                if (inputString.Length != 0)
                {
                    valorString = inputString;
                    valid_1 = true;
                }
            }
            return valorString;
        }

        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool registro_Pedido(Pedido registro)
        {
            return (fachadaServiciosDAO_Pedido.insertarRegistro_Pedido(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool modificar_Pedido(Pedido registro)
        {
            return (fachadaServiciosDAO_Pedido.actualizarRegistro_Pedido(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool eliminar_Pedido(int idPedido)
        {
            return (fachadaServiciosDAO_Pedido.eliminarRegistro_Pedido(idPedido));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para consultar el registro
        public Pedido consultarRegistro_Pedido(int idPedido)
        {
            return (fachadaServiciosDAO_Pedido.consultarRegistro_Pedido(idPedido));
        }
        //***********************************************
        //***********************************************
        //***********************************************

        public Pedido armarRegistro_Pedido()
        {
            Pedido registro_Pedido = new Pedido();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("INGRESO DE LOS DATOS DEL REGISTRO");

            registro_Pedido.PedidoNumero = ingresoConsolaEntero("Ingrese el valor del campo PedidoNumero: ");
            registro_Pedido.PedidoCliente = ingresoConsolaEntero("Ingrese el valor del campo PedidoCliente: ");
            registro_Pedido.PedidoProducto = ingresoConsolaEntero("Ingrese el valor del campo PedidoProducto: ");
            registro_Pedido.PedidoCantidad = ingresoConsolaEntero("Ingrese el valor del campo PedidoCantidad: ");


            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------");

            return (registro_Pedido);
        }

        //***********************************************
        //***********************************************
        //***********************************************
        public void imprimirDatos_Pedido(Pedido registro_Pedido)
        {
            if (registro_Pedido.PedidoNumero == 0)
            {
                Console.WriteLine("\n*******************************************************88******");
                Console.WriteLine("**** EL registro no existe actualmente en la base de datos ****");
                Console.WriteLine("***************************************************************\n");
            }
            else
            {
                Console.WriteLine("\n************************************************************");
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************");
                Console.WriteLine("*** PedidoNumero: " + registro_Pedido.PedidoNumero);
                Console.WriteLine("*** PedidoCliente: " + registro_Pedido.PedidoCliente);
                Console.WriteLine("*** PedidoProducto: " + registro_Pedido.PedidoProducto);
                Console.WriteLine("*** PedidoCantidad: " + registro_Pedido.PedidoCantidad);
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************\n");
            }
        }
    }
}
