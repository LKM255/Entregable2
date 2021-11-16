using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoMovil.Models
{
    public class Categoria
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        [MaxLength(50)]
        public string imagen { get; set; }
    }
}
