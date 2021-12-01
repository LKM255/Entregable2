using AplicativoMovil.Data;
using AplicativoMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoMovil.ViewModels
{
    public class SearchPageVM:BaseVM
    {
        public string _Filter;
        public Command _BackCommand;
        public Command _SearchCommand;
        public string Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                SerchProduct();
                OnPropertyChanged();
            }
        }

        ObservableCollection<Producto> Productolista = new ObservableCollection<Producto>();
        public ObservableCollection<Producto> producto { get { return Productolista; } set { Productolista = value; OnPropertyChanged(); } }

        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new Command(SerchProduct);
                }
                return _SearchCommand;
            }
        }
        public SearchPageVM()
        {
            if(string.IsNullOrEmpty(Filter))
            {
                Listar();
            }
            else
            {
                SerchProduct();
            }
        }
        
        private void Listar()
        {
            DataLogic dl = new DataLogic();
            var lspro = dl.ListaProducto();
            foreach (var prodetails in lspro)
            {
                Producto students = new Producto
                {
                    ID = prodetails.ID,
                    nombre = prodetails.nombre,
                    precio = prodetails.precio,
                    imagen = prodetails.imagen,
                    descripcion = prodetails.descripcion
                };
                producto.Add(students);
            }
        }
        private void SerchProduct()
        {
            producto.Clear();
            DataLogic dl = new DataLogic();
            var lst = dl.ShowDataProductFilter(Filter);
            foreach (var prodetails in lst)
            {
                Producto pr = new Producto
                {
                    ID = prodetails.ID,
                    nombre = prodetails.nombre,
                    imagen = prodetails.imagen,
                    descripcion = prodetails.descripcion,
                    precio = prodetails.precio
                };
                producto.Add(pr);
            }
        }
    }
}
