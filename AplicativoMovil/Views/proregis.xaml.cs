using AplicativoMovil.Data;
using AplicativoMovil.Models;
using SQLite;
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
    public partial class proregis : ContentPage
    {
        Producto p;
        Categoria c;
        private SQLiteConnection con;
        public proregis()
        {
            InitializeComponent();
            con = DependencyService.Get<ISQLite>().GetConnection();
            con.CreateTable<Producto>();
            con.CreateTable<Categoria>();
            con.CreateTable<TablaTemporal>();
            Eliminar();
        }
        public void Eliminar()
        {
            con.DeleteAll<TablaTemporal>();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            p = new Producto();
            p.nombre = nombre.Text;
            p.precio = double.Parse(precio.Text);
            p.imagen = imagen.Text;
            p.descripcion = descrip.Text;
            p.CategoriaId = Convert.ToInt32(categoid.Text);
            bool si = registrar(p);
            if(si)
            {
                DisplayAlert("A", "Exito", "OK");
            }
        }
        public bool registrar(Producto p)
        {
            p = new Producto()
            {
                nombre = p.nombre,
                precio = p.precio,
                imagen = p.imagen,
                descripcion = p.descripcion,
                CategoriaId = p.CategoriaId
            };
            try
            {
                con.Insert(p);
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception ex) { throw ex; }
            return false;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            c = new Categoria();
            c.imagen = imagencat.Text;
            c.Descripcion = descripcat.Text;
            bool si = registrarcat(c);
            if (si)
            {
                DisplayAlert("A", "Exito", "OK");
            }
        }
        public bool registrarcat(Categoria c)
        {
            c = new Categoria()
            {
                Descripcion = c.Descripcion,
                imagen = c.imagen,
            };
            try
            {
                con.Insert(c);
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception ex) { throw ex; }
            return false;
        }
    }
}