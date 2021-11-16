using AplicativoMovil.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetail : ContentPage
    {
        public PageDetail(string id, string nombre,string imagen, string descrip, string precio)
        {
            InitializeComponent();
            //BindingContext = new PedidoViewModel();
            idp.Text = id;
            nombrep.Text = nombre;
            imagenp.Source = imagen;
            precip.Text = precio;
            descripp.Text = descrip;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idp.Text);
            string nombre = nombrep.Text;
            string imagen = imagenp.Source.ToString();
            double precio = double.Parse(precip.Text);
            string descrip = descripp.Text;
            int cantidad = int.Parse(cantidadp.Text);
            double total  =cantidad * precio;
            
            await Navigation.PushModalAsync(new Carrito( id,  nombre,  imagen,  precio,cantidad,total));
        }
    }
}