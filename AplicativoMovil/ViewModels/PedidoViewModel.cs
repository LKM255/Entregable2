using AplicativoMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AplicativoMovil.ViewModels
{
    public class PedidoViewModel
    {
        public ObservableCollection<Pedido> pedidos { get; set; }
        public PedidoViewModel()
        {
            pedidos = new ObservableCollection<Pedido>
            {
                new Pedido
                {
                    ID ='1', producto="cama espuma", Total="S/ 1500"
                }
            };
        }
    }
}
