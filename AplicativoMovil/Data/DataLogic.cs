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
        private DetallePedido detpedido;
        private Pedido ped;
        private int id;
        public DataLogic()
        {
            con = DependencyService.Get<ISQLite>().GetConnection();
            
            con.CreateTable<Pedido>();
            con.CreateTable<DetallePedido>();
            con.CreateTable<Usuario>();
            con.CreateTable<TablaTemporal>();
            con.CreateTable<Producto>();
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

        public bool RegisterPedido(List<DetallePedido> dpe, double total)
        {
            var ID = Convert.ToInt32(Preferences.Get("IDUSU", 0));
            var nombre = Preferences.Get("Nombre", "");
            var usuario = Preferences.Get("Usuario", "");
            ped = new Pedido
            {
                correo = usuario,
                IDU = ID,
                nombre = nombre,
                Total = total,
            };
            try
            {
                con.Insert(ped);
                var variable = con.Query<Pedido>("SELECT * FROM Pedido WHERE ID = (SELECT MAX(ID) FROM Pedido)").ToList();
                foreach( var s in variable)
                {
                   id = s.ID;
                }
            }
            catch (SQLiteException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            try
            {
                foreach (var dp in dpe)
                {
                    detpedido = new DetallePedido
                    {
                        PedidoId = id,
                        idp = dp.idp,
                        descripcion = dp.descripcion,
                        cantidad = dp.cantidad,
                        precio = dp.precio,
                        total = dp.total,
                    };

                    con.Insert(detpedido);
                }
                return true;
                
            }
            catch (SQLiteException) { }
            catch (Exception) { }
            return false;
        }

        internal IEnumerable<Pedido> BuscaraPedido()
        {
            var lstStudent = from p in con.Table<Pedido>() select p;
            return lstStudent;
        }

        public IEnumerable<Producto> ShowDataProductFilter(string Filter)
        {
            var lstProducts = from product in con.Table<Producto>().Where(p => p.nombre.ToLower().Contains(Filter.ToLower())) select product;
            return lstProducts;
        }


    }
}
