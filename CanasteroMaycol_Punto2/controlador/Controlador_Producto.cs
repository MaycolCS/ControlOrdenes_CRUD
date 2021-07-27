using CanasteroMaycol_Punto2.dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.controlador
{
    class Controlador_Producto
    {
        private static DAO_Producto fachadaServiciosDAO_Producto;
        public Controlador_Producto()
        {
            String cadenaConexion = "";
            cadenaConexion = ConfigurationManager.ConnectionStrings["CanasteroMaycol_Punto2.Properties.Settings.CanasteroMaycol_Punto2ConnectionString"].ConnectionString;
            //Console.WriteLine("Cadena conexion: " + cadenaConexion);
            fachadaServiciosDAO_Producto = new DAO_Producto(cadenaConexion);
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
        public bool registro_Producto(Producto registro)
        {
            return (fachadaServiciosDAO_Producto.insertarRegistro_Producto(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool modificar_Producto(Producto registro)
        {
            return (fachadaServiciosDAO_Producto.actualizarRegistro_Producto(registro));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para insertar el registro
        public bool eliminar_Producto(int idProducto)
        {
            return (fachadaServiciosDAO_Producto.eliminarRegistro_Producto(idProducto));
        }
        //***********************************************
        //***********************************************
        //***********************************************
        //Método para consultar el registro
        public Producto consultarRegistro_Producto(int idProducto)
        {
            return (fachadaServiciosDAO_Producto.consultarRegistro_Producto(idProducto));
        }

        public Producto armarRegistro_Producto()
        {
            Producto registro_Producto = new Producto();

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("INGRESO DE LOS DATOS DEL REGISTRO");

            registro_Producto.ProductoCodigo = ingresoConsolaEntero("Ingrese el valor del campo ProductoCodigo: ");
            registro_Producto.ProductoNombre = ingresoConsolaString("Ingrese el valor del campo ProductoNombre: ");
            registro_Producto.ProductoCantidad = ingresoConsolaEntero("Ingrese el valor del campo ProductoCantidad: ");
            registro_Producto.ProductoPrecio = ingresoConsolaEntero("Ingrese el valor del campo ProductoPrecio: ");


            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------");

            return (registro_Producto);
        }

        //***********************************************
        //***********************************************
        //***********************************************
        public void imprimirDatos_Producto(Producto registro_Producto)
        {
            if (registro_Producto.ProductoCodigo == 0)
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
                Console.WriteLine("*** ProductoCodigo: " + registro_Producto.ProductoCodigo);
                Console.WriteLine("*** ProductoNombre: " + registro_Producto.ProductoNombre);
                Console.WriteLine("*** ProductoCantidad: " + registro_Producto.ProductoCantidad);
                Console.WriteLine("*** ProductoPrecio: " + registro_Producto.ProductoPrecio);
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************");
                Console.WriteLine("************************************************************\n");
            }
        }
    }
}
