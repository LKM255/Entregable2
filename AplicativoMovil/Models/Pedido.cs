using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;


namespace AplicativoMovil.Models
{
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Usuario))]
        public int IDU { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; }
        [MaxLength(50)]
        public string correo { get; set; }
        [MaxLength(50)]
        public double Total { get; set; }
    }
}
