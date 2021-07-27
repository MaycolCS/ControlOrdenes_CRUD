using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.dao
{
    class Producto
    {
        private Int32 productoCodigo;
        private string productoNombre;
        private Int32 productoCantidad;
        private Int32 productoPrecio;

        public int ProductoCodigo { get => productoCodigo; set => productoCodigo = value; }
        public string ProductoNombre { get => productoNombre; set => productoNombre = value; }
        public int ProductoCantidad { get => productoCantidad; set => productoCantidad = value; }
        public int ProductoPrecio { get => productoPrecio; set => productoPrecio = value; }
    }
}
