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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            BindingContext = new ViewModels.UsuarioVm();
            
            if(user.Text == "jean" && Pass.Text == "12345")
            {
                Navigation.PushModalAsync(new Inicio());
            }
            else
            {
                DisplayAlert("Error", "Contraseña o usuario incorecto", "OK");
            }
        }
    }
}