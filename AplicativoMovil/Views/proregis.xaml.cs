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
        private SQLiteConnection con;
        public proregis()
        {
            InitializeComponent();
            con = DependencyService.Get<ISQLite>().GetConnection();
            con.CreateTable<Producto>();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            p = new Producto();
            p.nombre = nombre.Text;
            p.precio = double.Parse(precio.Text);
            p.imagen = imagen.Text;
            p.descripcion = descrip.Text;
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
                descripcion = p.descripcion
            };
            try
            {
                con.Insert(p);
                con.Close();
                return true;
            }
            catch (SQLiteException) { }
            catch (Exception ex) { throw ex; }
            return false;
        }
    }
}