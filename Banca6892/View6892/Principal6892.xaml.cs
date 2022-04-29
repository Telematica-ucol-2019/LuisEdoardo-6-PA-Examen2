using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banca6892.Models6892;
using Banca6892.ViewModel6892;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Banca6892.View6892
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal6892 : ContentPage
    {

        public Principal6892(Usuario6892 usuario)
        {
            InitializeComponent();
            BindingContext = new UsuarioViewModel6892(usuario);
        }

    }
}