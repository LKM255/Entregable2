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
        public ObservableCollection<Producto> producto { get { return Productolista; } }

        ObservableCollection<Categoria> CategoriaLista = new ObservableCollection<Categoria>();
        public ObservableCollection<Categoria> categoria { get { return CategoriaLista; } }

        ObservableCollection<Producto> ProductolistaxCategoria = new ObservableCollection<Producto>();
        public ObservableCollection<Producto> productoxcategoria { get { return ProductolistaxCategoria; } }
        public int id;
        public ProductoViewModel()
        {
            ListarCategoria();
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
        private void ListarCategoria()
        {
            DataLogic dl = new DataLogic();
            var lspro = dl.ListaCategoria();
            foreach (var prodetails in lspro)
            {
                Categoria cat = new Categoria
                {
                    ID = prodetails.ID,
                    imagen = prodetails.imagen,
                    Descripcion = prodetails.Descripcion
                };
                categoria.Add(cat);
            }
        }
        public void ListarProductoxCategoria(int id)
        {
            DataLogic dl = new DataLogic();
            var lspro = dl.ListaProductoxCategoria(id);
            foreach (var prodetails in lspro)
            {
                Producto cat = new Producto
                {
                    ID = prodetails.ID,
                    imagen = prodetails.imagen,
                    descripcion = prodetails.descripcion,
                    nombre = prodetails.nombre,
                    precio=prodetails.precio
                };
                productoxcategoria.Add(cat);
            }
        }
    }
}
