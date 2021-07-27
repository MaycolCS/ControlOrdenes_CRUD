using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.dao
{
    class Cliente
    {
        private string clienteNombre;
        private Int32 clienteCedula;
        private string clienteDireccion;
        private Int32 clienteNumero;
        private string clienteTipoPago;

        public string ClienteNombre { get => clienteNombre; set => clienteNombre = value; }
        public int ClienteCedula { get => clienteCedula; set => clienteCedula = value; }
        public string ClienteDireccion { get => clienteDireccion; set => clienteDireccion = value; }
        public int ClienteNumero { get => clienteNumero; set => clienteNumero = value; }
        public string ClienteTipoPago { get => clienteTipoPago; set => clienteTipoPago = value; }
    }
}
