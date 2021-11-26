using AplicativoMovil.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
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
        private int id;
        public DataLogic()
        {
            con = DependencyService.Get<ISQLite>().GetConnection();
            con.CreateTable<Producto>();
            con.CreateTable<Pedido>();
            con.CreateTable<DetallePedido>();
            con.CreateTable<Usuario>();
            con.CreateTable<TablaTemporal>();
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

        public Usuario LoginUser(string email, string pass)
        {
            var select = con.Table<Usuario>();
            var d1 = select.Where(x => x.User == email && x.Password == pass).FirstOrDefault();
            Usuario us = new Usuario();
            us.ID = d1.ID;
            us.User = d1.User;
            us.Nombres = d1.Nombres;
            if (d1 != null)
            {
                return us;
            }
            else
                return null;
        }

        public IEnumerable<Categoria> ListaCategoria()
        {
            var lstStudent = from c in con.Table<Categoria>() select c;
            return lstStudent;
        }

        public IEnumerable<Producto> ListaProducto()
        {
            var lstStudent = from p in con.Table<Producto>() select p;
            return lstStudent;
        }

        public bool AgregarCarrito(TablaTemporal tabla)
        {
            try
            {
                con.Insert(tabla);
                con.Close();
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception) { }
            return false;
        }

        public void EliminarCarrito()
        {
            con.DeleteAll<TablaTemporal>();
            con.Close();
        }

        public IEnumerable<TablaTemporal> BuscaraCarrito()
        {
            var lstStudent = from p in con.Table<TablaTemporal>() select p;
            return lstStudent;
        }
        public IEnumerable<Producto> ListaProductoxCategoria(int id)
        {
            var lstStudent = from p in con.Table<Producto>().Where(i=> i.CategoriaId == id) select p;
            return lstStudent;
        }

        public bool RegisterPedido(DetallePedido dp, double total)
        {
            var ID = Convert.ToInt32(Preferences.Get("IDUSU", 0));
            ped = new Pedido
            {
                correo = "jean@hotmail.com",
                IDU=ID,
                nombre="Jean Pierre Esteban Valderrama",
            };
            try
            {
                int id;
                con.Insert(ped);
                var variable = con.Query<Pedido>("SELECT MAX(ID) FROM Pedido");
                foreach( var s in variable)
                {
                   id = s.ID;
                }
            }
            catch (SQLiteException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            det = new DetallePedido
            {
                PedidoId = id,
                idp = dp.idp,
                descripcion = dp.descripcion,
                cantidad = dp.cantidad,
                precio = dp.precio,
                total = total
            };
            try
            {
                con.Insert(det);
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception) { }
            return false;
        }

    }
}
