﻿using AplicativoMovil.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AplicativoMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Inicio();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
