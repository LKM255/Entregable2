using AplicativoMovil.Models;
using AplicativoMovil.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedido : ContentPage
    {
        public ObservableCollection<DetallePedido> det { get; set; }
        ObservableCollection<DetallePedido> lista = new ObservableCollection<DetallePedido>();
        public ObservableCollection<DetallePedido> detpedido { get { return lista; } }
        public Pedido(int id,string nombre,string imagen, double precio, int cantidad, double total)
        //public Pedido()
        {
            InitializeComponent();
            
            det = new ObservableCollection<DetallePedido>
            {
                new DetallePedido
                {
                    idp=id, descripcion=nombre,cantidad=cantidad,precio=precio,total=total,PedidoId=1
                }
            };
            double tot = 0;
            foreach (var deta in det)
            {
                DetallePedido detalle = new DetallePedido
                {
                    idp =deta.idp,
                    descripcion = deta.descripcion,
                    precio = deta.precio,
                    cantidad = deta.cantidad,
                    total = deta.total,
                    PedidoId = deta.PedidoId
                };
                tot = deta.total;
                detpedido.Add(detalle);
            }
            cldetalle.ItemsSource = detpedido;
            Totallbl.Text = tot.ToString();
            double totaldet = double.Parse(Totallbl.Text);
            Totallbl.Text = Convert.ToString(totaldet + tot);

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ChekOut());
        }
    }
}