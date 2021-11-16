using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoMovil.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string nombre { get; set; }
        [MaxLength(50)]
        public double precio { get; set; }
        [MaxLength(100)]
        public string imagen { get; set; }
        [MaxLength(400)]
        public string descripcion { get; set; }
    }
}
