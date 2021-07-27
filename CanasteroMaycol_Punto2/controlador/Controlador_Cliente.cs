using CanasteroMaycol_Punto2.dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.controlador
{
    class Controlador_Cliente
    {
        private static DAO_Cliente fachadaServiciosDAO_Cliente;
        public Controlador_Cliente()
        {
            String cadenaConexion = "";
            cadenaConexion = ConfigurationManager.ConnectionStrings["CanasteroMaycol_Punto2.Properties.Settings.CanasteroMaycol_Punto2ConnectionString"].ConnectionString;
            //Console.WriteLine("Cadena conexion: " + cadenaConexion);
            fachadaServiciosDAO_Cliente = new DAO_Cliente(cadenaConexion);
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
        public bool registro_Cliente(Cliente registro)
        {
            return (fachadaServiciosDAO_Cliente.insertarRegistro_Cliente(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool modificar_Cliente(Cliente registro)
        {
            return (fachadaServiciosDAO_Cliente.actualizarRegistro_Cliente(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool eliminar_Cliente(int idCliente)
        {
            return (fachadaServiciosDAO_Cliente.eliminarRegistro_Cliente(idCliente));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para consultar el registro
        public Cliente consultarRegistro_Cliente(int idCliente)
        {
            return (fachadaServiciosDAO_Cliente.consultarRegistro_Cliente(idCliente));
        }
        //***********************************************
        //***********************************************
        //***********************************************

        public Cliente armarRegistro_Cliente()
        {
            Cliente registro_Cliente = new Cliente();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("INGRESO DE LOS DATOS DEL REGISTRO");

            registro_Cliente.ClienteCedula = ingresoConsolaEntero("Ingrese el valor del campo ClienteCedula: ");
            registro_Cliente.ClienteNombre = ingresoConsolaString("Ingrese el valor del campo ClienteNombre: ");
            registro_Cliente.ClienteDireccion = ingresoConsolaString("Ingrese el valor del campo ClienteDireccion: ");
            registro_Cliente.ClienteNumero = ingresoConsolaEntero("Ingrese el valor del campo ClienteNumero: ");
            registro_Cliente.ClienteTipoPago = ingresoConsolaString("Ingrese el valor del campo ClienteTipoPago: ");


            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------");

            return (registro_Cliente);
        }

        //***********************************************
        //***********************************************
        //***********************************************
        public void imprimirDatos_Cliente(Cliente registro_Cliente)
        {
            if (registro_Cliente.ClienteCedula == 0)
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
                Console.WriteLine("*** ClienteCedula: " + registro_Cliente.ClienteCedula);
                Console.WriteLine("*** ClienteNombre: " + registro_Cliente.ClienteNombre);
                Console.WriteLine("*** ClienteDireccion: " + registro_Cliente.ClienteDireccion);
                Console.WriteLine("*** ClienteNumero: " + registro_Cliente.ClienteNumero);
                Console.WriteLine("*** ClienteTipoPago: " + registro_Cliente.ClienteTipoPago);
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************\n");
            }
        }
    }
}
