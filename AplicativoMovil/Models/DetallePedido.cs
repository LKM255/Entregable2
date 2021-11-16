using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoMovil.Models
{
    public class DetallePedido
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Pedido))]
        public int PedidoId { get; set; }
        [ForeignKey(typeof(Producto))]
        public int idp { get; set; }
        [MaxLength(50)]
        public string descripcion { get; set; }
        [MaxLength(50)]
        public int cantidad { get; set; }
        [MaxLength(50)]
        public double precio { get; set; }
        [MaxLength(50)]
        public double total { get; set; }
    }
}
