using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.dao
{
    class Pedido
    {
        private Int32 pedidoNumero;
        private Int32 pedidoCliente;
        private Int32 pedidoProducto;
        private Int32 pedidoCantidad;

        public int PedidoNumero { get => pedidoNumero; set => pedidoNumero = value; }
        public int PedidoCliente { get => pedidoCliente; set => pedidoCliente = value; }
        public int PedidoProducto { get => pedidoProducto; set => pedidoProducto = value; }
        public int PedidoCantidad { get => pedidoCantidad; set => pedidoCantidad = value; }
    }
}
