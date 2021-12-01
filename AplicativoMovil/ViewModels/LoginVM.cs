using AplicativoMovil.Data;
using AplicativoMovil.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AplicativoMovil.ViewModels
{
    public class LoginVM : BaseVM
    {
        public Command _RegisterCommand;
        public Command _LoginCommand;
        private string emailtxt;
        private string passwordtxt;

        public ICommand LoginCommmand
        {
            get
            {
                if(_LoginCommand == null)
                {
                    _LoginCommand = new Command(LoginUser);
                }
                return _LoginCommand;
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                if(_RegisterCommand == null)
                {
                    _RegisterCommand = new Command(RegisterBack);
                }
                return _RegisterCommand;
            }
        }
        public string EmailTxt
        {
            get => emailtxt;
            set
            {
                if (emailtxt != value)
                {
                    emailtxt = value;
                }
                OnPropertyChanged();
            }
        }
        public string PasswordTxt
        {
            get => passwordtxt;
            set
            {
                if (passwordtxt != value)
                {
                    passwordtxt = value;
                }
                OnPropertyChanged();
            }
        }
        private void LoginUser()
        {
            var email = EmailTxt;
            var pass = PasswordTxt;
            DataLogic dl = new DataLogic();
            Usuario usu = dl.LoginUser(email, pass);
            if(usu.ID != 0)
            {
                Preferences.Set("IDUSU", usu.ID);
                Preferences.Set("Usuario", usu.User);
                Preferences.Set("Nombre", usu.Nombres);

                App.Current.MainPage = new AppShell();
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", "Ususario no encontrado", "OK");
            }
        }

        private void RegisterBack(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Register());
        }

    }
}
