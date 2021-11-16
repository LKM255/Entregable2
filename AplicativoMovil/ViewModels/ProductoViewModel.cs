using AplicativoMovil.Data;
using AplicativoMovil.Models;
using AplicativoMovil.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AplicativoMovil.ViewModels
{
    public class ProductoViewModel : BaseVM
    {
         
        ObservableCollection<Producto> Productolista = new ObservableCollection<Producto>();
        public int id;
        public ObservableCollection<Producto> producto { get { return Productolista; } }
        public ProductoViewModel()
        {
            Listar();
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
    }
}
