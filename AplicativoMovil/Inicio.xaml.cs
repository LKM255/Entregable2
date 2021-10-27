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

        //private void ImageButton_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new Comedor());
        //}

        //private void ImageButton_Clicked_1(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new Sala());
        //}

        //private void ImageButton_Clicked_2(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new Cocina());
        //}

        //private void ImageButton_Clicked_3(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new Dormitorio());
        //}


        //private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Navigation.PushModalAsync(new Comedor());
        //}

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = e.SelectedItemIndex;
            
            //var obj = (Models.Producto)e.SelectedItem;
            if(obj == 0)
            {
                Navigation.PushAsync(new Comedor());
            }
            else if(obj==1)
            {
                Navigation.PushAsync(new Sala());
            }
            else if (obj == 2)
            {
                Navigation.PushAsync(new Cocina());
            }
            else if (obj== 3)
            {
                Navigation.PushAsync(new Dormitorio());
            }

        }
    }
}