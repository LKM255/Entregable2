using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario : ContentPage
    {
        public Usuario()
        {
            InitializeComponent();
            int id = Preferences.Get("IDUSU", 0);
            Nombre.Text = Preferences.Get("Usuario", "");
            correo.Text=Preferences.Get("Nombre", "");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("IDUSU");
            Navigation.PushModalAsync(new Login());
        }
    }
}