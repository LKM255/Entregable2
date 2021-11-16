using AplicativoMovil.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoMovil.ViewModels
{
    public class RegisterVM : BaseVM
    {
        public Command _BackCommand;
        public Command _RegisterCommand;
        private string emailtxt;
        private string passwordtxt;
        private string nombretxt;

        public ICommand RegisterCommand
        {
            get
            {
                if(_RegisterCommand==null)
                {
                    _RegisterCommand = new Command(SavetoDB);
                }
                return _RegisterCommand;
            }
        }

        public ICommand BackCommand
        {
            get
            {
                if(_BackCommand == null)
                {
                    _BackCommand = new Command(LoginBack);
                }
                return _BackCommand;
            }
        }
        public string Emailtxt
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
        public string Passwordtxt
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
        public string Nombretxt
        {
            get => nombretxt;
            set
            {
                if (nombretxt != value)
                {
                    nombretxt = value;
                }
                OnPropertyChanged();
            }
        }

        
        private void SavetoDB()
        {
            var email = Emailtxt;
            var pass = Passwordtxt;
            var nombre = Nombretxt;

            DataLogic dl = new DataLogic();
            bool succes = dl.RegisterUsers(nombre,email,pass);
            if(string.IsNullOrEmpty(email)|| string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(nombre))
            {
                App.Current.MainPage.DisplayAlert("Error", "Debe completar los campos correspondietes", "OK");
            }
            else
            {
                if(succes)
                {
                    Emailtxt = string.Empty;
                    Passwordtxt = string.Empty;
                    Nombretxt = string.Empty;
                    App.Current.MainPage.DisplayAlert("Exito", "Se registro con exito", "OK");
                }
            }
        }
        private void LoginBack(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new Login());
        }

    }
}
