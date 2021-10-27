using AplicativoMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AplicativoMovil.ViewModels
{
    public class ProductoViewModel
    {
        public ObservableCollection<Producto> producto { get; set; }
        public ProductoViewModel()
        {
            producto = new ObservableCollection<Producto>
            {
                new Producto
                {
                    ID ='1', nombre="Juego de comedor de madera", Precio="S/ 250", imagen="mesa1.png"
                },
                new Producto
                {
                    ID ='2', nombre="Repostero para cocina", Precio="S/ 1000", imagen="cocina1.webp"
                },
                new Producto
                {
                    ID ='3', nombre="Sofa de espuma", Precio="S/ 1500", imagen="sofa1.png"
                },
                new Producto
                {
                    ID ='3', nombre="Cama pastel", Precio="S/ 900", imagen="cama1.png"
                }
            };
        }
    }
}
