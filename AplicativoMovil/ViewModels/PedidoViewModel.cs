using AplicativoMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoMovil.ViewModels
{
    public class PedidoViewModel
    {
        public ObservableCollection<Pedido> pedidos { get; set; }

        public Command Carrito { get; set; }
        public ObservableCollection<DetallePedido> detallepedido { get; set; }
        public string NombreProducto { get; set; }
        public string CantidadProducto { get; set; }
        public PedidoViewModel()
        {
            pedidos = new ObservableCollection<Pedido>
            {
                new Pedido
                {
                    ID ='1', nombre="Jean", correo="jean123_255@hotmail.com"
                }
            };
            detallepedido = new ObservableCollection<DetallePedido>
            {
                new DetallePedido
                {
                    descripcion = NombreProducto
                }
            };
        }
        public ICommand Comprar
        {
            get
            {
                if (Carrito == null)
                {
                    Carrito = new Command(comprar);
                }
                return Carrito;
            }
        }

        private void comprar()
        {
            string nombre = NombreProducto;
            string ca = CantidadProducto;
        }
    }
}
