using AplicativoMovil.ViewModels;
using AplicativoMovil.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public Inicio()
        {
            InitializeComponent();
            BindingContext = new ProductoViewModel();
        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Models.Producto model = e.CurrentSelection.FirstOrDefault() as Models.Producto;
            string id = model.ID.ToString();
            string nombre = model.nombre;
            string imagen = model.imagen;
            string descrip = model.descripcion;
            string precio = model.precio.ToString();
            Navigation.PushModalAsync(new PageDetail(id, nombre, imagen, descrip,  precio));
        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Models.Categoria model = e.CurrentSelection.FirstOrDefault() as Models.Categoria;
            int id = model.ID;
            Navigation.PushModalAsync(new ListProduct(id));
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Carrito());
        }
    }
}