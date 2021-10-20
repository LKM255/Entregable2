﻿using AplicativoMovil.ViewModels;
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
    public partial class Pedido : ContentPage
    {
        public Pedido()
        {
            InitializeComponent();
            BindingContext = new PedidoViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ChekOut());
        }
    }
}