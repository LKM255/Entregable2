using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoMovil.Models
{
    public class TablaTemporal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; }
        [MaxLength(50)]
        public double precio { get; set; }
        [MaxLength(100)]
        public int idproducto { get; set; }
        [MaxLength(400)]
        public double total { get; set; }
        [MaxLength(400)]
        public int cantidad { get; set; }
    }
}
