using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanasteroMaycol_Punto2.dao
{
    class Queries_CRUD
    {
        private string querySQL;

        //******************************************************
        //******************************************************
        //PRODUCTOS
        //******************************************************
        //******************************************************
        public string generarConsultaInsert_Producto()
        {
            this.querySQL =
            "INSERT INTO [dbo].[Producto] " +
            " ([productoCodigo],[productoNombre],[productoCantidad],[productoPrecio]) " +
            " VALUES (@productoCodigo, @productoNombre, @productoCantidad, @productoPrecio) ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaUpdate_Producto()
        {
            this.querySQL =
            "UPDATE [dbo].[Producto] " +
            "   SET [productoNombre] = @productoNombre " +
            "      ,[productoCantidad] = @productoCantidad " +
            "      ,[productoPrecio] = @productoPrecio " +
            "   WHERE [productoCodigo] = @productoCodigo ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaSelect_Producto()
        {
            this.querySQL =
            "SELECT [productoCodigo] " +
            "   ,[productoNombre] " +
            "   ,[productoCantidad] " +
            "   ,[productoPrecio] " +
            "     FROM[dbo].[Producto] " +
            "WHERE [productoCodigo] = @productoCodigo ";

            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaDelete_Producto()
        {
            this.querySQL =
            "DELETE FROM[dbo].[Producto] " +
            "  WHERE [productoCodigo] = @productoCodigo ";
            return (this.querySQL);
        }

        //******************************************************
        //******************************************************
        //CLIENTES
        //******************************************************
        //******************************************************
        public string generarConsultaInsert_Cliente()
        {
            this.querySQL =
            "INSERT INTO [dbo].[Cliente] " +
            " ([clienteNombre],[clienteCedula],[clienteDireccion],[clienteNumero],[clienteTipoPago]) " +
            " VALUES (@clienteNombre, @clienteCedula, @clienteDireccion, @clienteNumero, @clienteTipoPago) ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaUpdate_Cliente()
        {
            this.querySQL =
            "UPDATE [dbo].[Cliente] " +
            "   SET [clienteNombre] = @clienteNombre " +
            "      ,[clienteDireccion] = @clienteDireccion " +
            "      ,[clienteNumero] = @clienteNumero " +
            "      ,[clienteTipoPago] = @clienteTipoPago " +
            "   WHERE [clienteCedula] = @clienteCedula ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaSelect_Cliente()
        {
            this.querySQL =
            "SELECT [clienteNombre] " +
            "   ,[clienteDireccion] " +
            "   ,[clienteNumero] " +
            "   ,[clienteTipoPago] " +
            "     FROM[dbo].[Cliente] " +
            "WHERE [clienteCedula] = @clienteCedula ";

            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaDelete_Cliente()
        {
            this.querySQL =
            "DELETE FROM[dbo].[Cliente] " +
            "  WHERE [clienteCedula] = @clienteCedula ";
            return (this.querySQL);
        }

        //******************************************************
        //******************************************************
        //PEDIDOS
        //******************************************************
        //******************************************************
        public string generarConsultaInsert_Pedido()
        {
            this.querySQL =
            "INSERT INTO [dbo].[Pedido] " +
            " ([pedidoNumero],[pedidoCliente],[pedidoProducto],[pedidoCantidad]) " +
            " VALUES (@pedidoNumero, @pedidoCliente, @pedidoProducto, @pedidoCantidad) ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaUpdate_Pedido()
        {
            this.querySQL =
            "UPDATE [dbo].[Pedido] " +
            "   SET [pedidoCliente] = @pedidoCliente " +
            "      ,[pedidoProducto] = @pedidoProducto " +
            "      ,[pedidoCantidad] = @pedidoCantidad " +
            "   WHERE [pedidoNumero] = @pedidoNumero ";
            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaSelect_Pedido()
        {
            this.querySQL =
            "SELECT [pedidoCliente] " +
            "   ,[pedidoProducto] " +
            "   ,[pedidoCantidad] " +
            "     FROM[dbo].[Pedido] " +
            "WHERE [pedidoNumero] = @pedidoNumero ";

            return (this.querySQL);
        }
        //******************************************************
        //******************************************************
        //******************************************************
        public string generarConsultaDelete_Pedido()
        {
            this.querySQL =
            "DELETE FROM[dbo].[Pedido] " +
            "  WHERE [pedidoNumero] = @pedidoNumero ";
            return (this.querySQL);
        }
    }
}
