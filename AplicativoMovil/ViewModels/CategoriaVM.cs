using AplicativoMovil.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AplicativoMovil.ViewModels
{
    public class CategoriaVM
    {
        public ObservableCollection<Categoria> categoria { get; set; }
        public CategoriaVM()
        {
            categoria = new ObservableCollection<Categoria>
            {
                new Categoria
                {
                    ID ='1', Descripcion="Dormitorio", imagen="dormitorio.png"
                },
                new Categoria
                {
                    ID ='2', Descripcion="Cocina", imagen="cocina.png"
                },
                new Categoria
                {
                    ID ='3', Descripcion="Comedor", imagen="mesa.png"
                },
                new Categoria
                {
                    ID ='4', Descripcion="Sala", imagen="sofa.png"
                },
            };
        }
    }
}
