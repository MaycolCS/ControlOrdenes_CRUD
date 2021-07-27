using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanasteroMaycol_Punto2.dao;
using CanasteroMaycol_Punto2.controlador;

namespace CanasteroMaycol_Punto2
{
    class Program
    {
        //Manejo de la pantalla
        public void prepararPantalla()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
        }

        public void mostrarMenuCRUD()
        {
            bool endApp = false;

            while (!endApp)
            {
                string op1;
                do
                {
                    prepararPantalla();
                    Console.WriteLine("MENÚ DE OPCIONES");
                    Console.WriteLine("1.  Productos");
                    Console.WriteLine("2.  Clientes");
                    Console.WriteLine("3.  Pedidos");
                    Console.Write("Ingrese una opción: ");
                    op1 = Console.ReadLine();
                } while (!op1.Equals("1") && !op1.Equals("2") && !op1.Equals("3"));

                string menu = "";
                if (op1 == "1")
                {
                    menu = "producto";
                }
                else if (op1 == "2")
                {
                    menu = "cliente";
                }
                else if (op1 == "3")
                {
                    menu = "pedido";
                }

                string op2;
                do
                {
                    prepararPantalla();
                    Console.WriteLine("MENÚ DE OPCIONES");
                    Console.WriteLine("1.  Insertar " + menu);
                    Console.WriteLine("2.  Modificar " + menu);
                    Console.WriteLine("3.  Consultar " + menu);
                    Console.WriteLine("4.  Eliminar " + menu);
                    Console.Write("Ingrese una opción: ");
                    op2 = Console.ReadLine();
                } while (!op2.Equals("1") && !op2.Equals("2") && !op2.Equals("3") && !op2.Equals("4"));

                prepararPantalla();
                ejecutarOpcionCrud(op1, op2);

                Console.WriteLine("\nEl programa ha terminado");
                // Esperar a que el usuario responda
                Console.Write("Presione la tecla 'n' y luego 'Enter' para finalizar, sino presione 'Enter' para continuar: ");
                if (Console.ReadLine() == "n")
                    endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
        //**************************************************
        //**************************************************
        //**************************************************
        public void ejecutarOpcionCrud(string opcion1, string opcion2)
        {

            if (opcion1 == "1") //PRODUCTO
            {
                Producto registro = null;
                bool resultado = false;
                Int32 id_Producto = 0;
                Controlador_Producto Producto_Controller = new Controlador_Producto();

                switch (opcion2)
                {
                    case "1":
                        registro = Producto_Controller.armarRegistro_Producto();
                        resultado = Producto_Controller.registro_Producto(registro);
                        break;
                    case "2":
                        registro = Producto_Controller.armarRegistro_Producto();
                        resultado = Producto_Controller.modificar_Producto(registro);
                        break;
                    case "3":
                        id_Producto = Producto_Controller.ingresoConsolaEntero("Digite el ID del producto: ");
                        registro = Producto_Controller.consultarRegistro_Producto(id_Producto);
                        Producto_Controller.imprimirDatos_Producto(registro);
                        break;
                    case "4":
                        id_Producto = Producto_Controller.ingresoConsolaEntero("Digite el ID del producto: ");
                        resultado = Producto_Controller.eliminar_Producto(id_Producto);
                        break;
                }
            }

            if (opcion1 == "2") //CLIENTE
            {
                Cliente registro = null;
                bool resultado = false;
                Int32 id_Cliente = 0;
                Controlador_Cliente Cliente_Controller = new Controlador_Cliente();

                switch (opcion2)
                {
                    case "1":
                        registro = Cliente_Controller.armarRegistro_Cliente();
                        resultado = Cliente_Controller.registro_Cliente(registro);
                        break;
                    case "2":
                        registro = Cliente_Controller.armarRegistro_Cliente();
                        resultado = Cliente_Controller.modificar_Cliente(registro);
                        break;
                    case "3":
                        id_Cliente = Cliente_Controller.ingresoConsolaEntero("Digite la cédula del cliente: ");
                        registro = Cliente_Controller.consultarRegistro_Cliente(id_Cliente);
                        Cliente_Controller.imprimirDatos_Cliente(registro);
                        break;
                    case "4":
                        id_Cliente = Cliente_Controller.ingresoConsolaEntero("Digite la cédula del cliente: ");
                        resultado = Cliente_Controller.eliminar_Cliente(id_Cliente);
                        break;
                }
            }

            if (opcion1 == "3") //PEDIDO
            {
                Pedido registro = null;
                bool resultado = false;
                Int32 id_Producto = 0;
                Controlador_Pedido Pedido_Controller = new Controlador_Pedido();

                switch (opcion2)
                {
                    case "1":
                        registro = Pedido_Controller.armarRegistro_Pedido();
                        resultado = Pedido_Controller.registro_Pedido(registro);
                        break;
                    case "2":
                        registro = Pedido_Controller.armarRegistro_Pedido();
                        resultado = Pedido_Controller.modificar_Pedido(registro);
                        break;
                    case "3":
                        id_Producto = Pedido_Controller.ingresoConsolaEntero("Digite el ID del pedido: ");
                        registro = Pedido_Controller.consultarRegistro_Pedido(id_Producto);
                        Pedido_Controller.imprimirDatos_Pedido(registro);
                        break;
                    case "4":
                        id_Producto = Pedido_Controller.ingresoConsolaEntero("Digite el ID del pedido: ");
                        resultado = Pedido_Controller.eliminar_Pedido(id_Producto);
                        break;
                }
            }

        }
        static void Main(string[] args)
        {
            Program nuevoGestorCRUD = new Program();
            nuevoGestorCRUD.mostrarMenuCRUD();
        }
    }
}
