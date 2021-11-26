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
    public partial class ListProduct : ContentPage
    {
        public ListProduct(int id)
        {
            InitializeComponent();
            ProductoViewModel p = new ProductoViewModel();
            p.ListarProductoxCategoria(id);
            list.ItemsSource = p.productoxcategoria;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Models.Producto model = e.CurrentSelection.FirstOrDefault() as Models.Producto;
            string id = model.ID.ToString();
            string nombre = model.nombre;
            string imagen = model.imagen;
            string descrip = model.descripcion;
            string precio = model.precio.ToString();
            Navigation.PushModalAsync(new PageDetail(id, nombre, imagen, descrip, precio));
        }
    }
}