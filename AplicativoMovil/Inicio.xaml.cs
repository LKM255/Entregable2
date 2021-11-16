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
            
            var c = e.CurrentSelection.First();
            Models.Producto model = e.CurrentSelection.FirstOrDefault() as Models.Producto;
            string id = model.ID.ToString();
            string nombre = model.nombre;
            string imagen = model.imagen;
            string descrip = model.descripcion;
            string precio = model.precio.ToString();
            Navigation.PushModalAsync(new PageDetail(id, nombre, imagen, descrip,  precio));
        }

    }
}