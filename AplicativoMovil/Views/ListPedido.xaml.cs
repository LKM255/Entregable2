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
    public partial class ListPedido : ContentPage
    {
        public ListPedido()
        {
            InitializeComponent();
            BindingContext = new PedidoViewModel();
        }
    }
}