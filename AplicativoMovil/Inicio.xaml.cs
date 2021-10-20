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
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Comedor());
        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Sala());
        }

        private void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Cocina());
        }

        private void ImageButton_Clicked_3(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Dormitorio());
        }
    }
}