using AplicativoMovil.Data;
using AplicativoMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoMovil.ViewModels
{
    public class PedidoViewModel:BaseVM
    {
        ObservableCollection<TablaTemporal> listacarrito = new ObservableCollection<TablaTemporal>();
        public ObservableCollection<TablaTemporal> carrito { get; set; }
        public double _totalcosto;
        public double totalcosto
        {
            set
            {
                _totalcosto = value;
                OnPropertyChanged();
            }
            get
            {
                return _totalcosto;
            }
        }
        public PedidoViewModel()
        {
            //pedidos = new ObservableCollection<Pedido>
            //{
            //    new Pedido
            //    {
            //        ID ='1', nombre="Jean", correo="jean123_255@hotmail.com"
            //    }
            //};
            //detallepedido = new ObservableCollection<DetallePedido>
            //{
            //    new DetallePedido
            //    {
            //        descripcion = NombreProducto
            //    }
            //};
            carrito = new ObservableCollection<TablaTemporal>();
            BuscarCarrito();

        }
        
        public void BuscarCarrito()
        {
            DataLogic dl = new DataLogic();
            var lspro = dl.BuscaraCarrito();
            foreach (var prodetails in lspro)
            {
                carrito.Add(new TablaTemporal()
                {
                    nombre = prodetails.nombre,
                    precio = prodetails.precio,
                    total = prodetails.total,
                    cantidad = prodetails.cantidad,
                    idproducto = prodetails.idproducto
                });
                //TablaTemporal cat = new TablaTemporal
                //{
                //    nombre = prodetails.nombre,
                //    precio = prodetails.precio,
                //    total = prodetails.total,
                //    cantidad =prodetails.cantidad,
                //    idproducto=prodetails.idproducto
                //};
                //carrito.Add(cat);
                totalcosto += prodetails.total;
            }
        }

        public bool AgregarCarito(int id, string nombre, double precio, double total,int cantidad)
        {
            TablaTemporal tabla = new TablaTemporal();
            tabla.idproducto = id;
            tabla.nombre = nombre;
            tabla.precio = precio;
            tabla.total = total;
            tabla.cantidad = cantidad;
            DataLogic dl = new DataLogic();
            bool exite= dl.AgregarCarrito(tabla);
            return exite;
        }
    }
}
