using AplicativoMovil.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AplicativoMovil.Data
{
    public class DataLogic
    {
        private SQLiteConnection con;
        private Producto p;
        private Usuario usu;
        private DetallePedido det;
        private Pedido ped;

        public DataLogic()
        {
            con = DependencyService.Get<ISQLite>().GetConnection();
            con.CreateTable<Producto>();
            con.CreateTable<Pedido>();
            con.CreateTable<DetallePedido>();
            con.CreateTable<Usuario>();
        }

        public bool RegisterUsers(string nombres, string user, string pass)
        {
            usu = new Usuario
            {
                Nombres = nombres,
                Password = pass,
                User = user
            };
            try
            {
                con.Insert(usu);
                con.Close();
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception) { }
            return false;
        }

        public bool LoginUser(string email, string pass)
        {
            var select = con.Table<Usuario>();
            var d1 = select.Where(x => x.User == email && x.Password == pass).FirstOrDefault();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }

        public IEnumerable<Producto> ListaProducto()
        {
            var lstStudent = from p in con.Table<Producto>() select p;
            return lstStudent;
        }

        public bool RegisterPedido(DetallePedido dp, double total)
        {
            int id = 0;
            ped = new Pedido
            {
                correo = "jean@hotmail.com",
                IDU=1,
                nombre="Jean Pierre Esteban Valderrama",
            };
            try
            {
                con.Insert(ped);
                //string query2 = "SELECT last_insert_rowid()";
                //SQLite.SQLiteCommand obtener = con.CreateCommand(query2);
                //id = obtener.ExecuteNonQuery();
                con.Close();
            }
            catch (SQLiteException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            det = new DetallePedido
            {
                PedidoId = 1,
                idp = dp.idp,
                descripcion = dp.descripcion,
                cantidad = dp.cantidad,
                precio = dp.precio,
                total = total
            };
            try
            {
                con.Insert(det);
                con.Close();
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception) { }
            return false;
        }

    }
}
