using Banca6892.ViewModel6892;
using Banca6892.Models6892;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Banca6892.View6892
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CuentaDetalles : ContentPage
    {
        public CuentaDetalles(Models6892.Cuenta6892 cuenta, UsuarioViewModel6892 vm)
        {
            InitializeComponent();
            vm.Cuenta = new Models6892.Cuenta6892();
            vm.Cuenta = cuenta;
            this.BindingContext = vm;
        }
    }
}