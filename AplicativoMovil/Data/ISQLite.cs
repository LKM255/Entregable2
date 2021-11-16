using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AplicativoMovil.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
