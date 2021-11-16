using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoMovil.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Nombres { get; set; }
        [MaxLength(50)]
        public string User { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
