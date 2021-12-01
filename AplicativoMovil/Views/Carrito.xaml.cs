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
    public partial class Carrito : ContentPage
    {
        public ObservableCollection<DetallePedido> det { get; set; }
        ObservableCollection<DetallePedido> lista = new ObservableCollection<DetallePedido>();
        public ObservableCollection<DetallePedido> detpedido { get { return lista; } }
        //List<DetallePedido> listde;
        DetallePedido detalle;
        public Carrito()
        {
            InitializeComponent();
            //det = new ObservableCollection<DetallePedido>
            //{
            //    new DetallePedido
            //    {
            //        idp=id, descripcion=nombre,cantidad=cantidad,precio=precio,total=total,PedidoId=1
            //    }
            //};
            //double tot = 0;
            //foreach (var deta in det)
            //{
            //    detalle = new DetallePedido
            //    {
            //        idp = deta.idp,
            //        descripcion = deta.descripcion,
            //        precio = deta.precio,
            //        cantidad = deta.cantidad,
            //        total = deta.total,
            //        PedidoId = deta.PedidoId
            //    };
            //    tot = deta.total;
            //    detpedido.Add(detalle);
            //}
            //BindingContext = new PedidoViewModel();
            //cldetalle.ItemsSource = detpedido;
            //double totaldet = double.Parse(lblsubtotal.Text.ToString());
            //lblsubtotal.Text = Convert.ToString(totaldet + tot);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            List<DetallePedido> listdet = new List<DetallePedido>();
            Data.DataLogic dt = new Data.DataLogic();
            var ls = dt.BuscaraCarrito();
            foreach (var prodetails in ls)
            {
                detalle = new DetallePedido
                {
                    descripcion = prodetails.nombre,
                    precio = prodetails.precio,
                    total = prodetails.total,
                    cantidad = prodetails.cantidad,
                    idp = prodetails.idproducto
                };
                listdet.Add(detalle);
            }
            double total = double.Parse(lblsubtotal.Text);
            dt.RegisterPedido(listdet, total);
            dt.EliminarCarrito();
            Navigation.PushModalAsync(new ChekOut());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new AppShell();
            //new NavigationPage(new AppShell());
            //await Navigation.PushModalAsync(new AppShell());
        }
    }
}