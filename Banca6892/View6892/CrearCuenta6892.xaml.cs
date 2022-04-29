using Banca6892.ViewModel6892;
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
    public partial class CrearCuenta6892 : ContentPage
    {
        public CrearCuenta6892(UsuarioViewModel6892 vm)
        {
            InitializeComponent();
            vm.Cuenta = new Models6892.Cuenta6892();
            vm.Cuenta.Transaccion = new System.Collections.ObjectModel.ObservableCollection<Models6892.Transaccion6892>();
            BindingContext = vm;
            Title = "Nuevo Contacto";
        }
    }
}