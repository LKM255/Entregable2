using AplicativoMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AplicativoMovil.ViewModels
{
    public class UsuarioVm
    {
        public ObservableCollection<Usuario> usaurio { get; set; }
        public UsuarioVm()
        {
            usaurio = new ObservableCollection<Usuario>
            {
                new Usuario
                {
                    ID ='1', Nombres="Jean Pierre", User="Jean",Password="12345"
                }
            };
        }
    }
}
