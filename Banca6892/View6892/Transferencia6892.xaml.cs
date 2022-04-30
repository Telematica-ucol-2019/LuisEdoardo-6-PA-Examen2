using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banca6892.ViewModel6892;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Banca6892.View6892
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Transferencia6892 : ContentPage
    {
        public Transferencia6892(string TransaccionT, Models6892.Cuenta6892 cuenta, UsuarioViewModel6892 vm)
        {
            InitializeComponent();

            vm.Cuenta = new Models6892.Cuenta6892();
            vm.Cuenta.Transaccion = new System.Collections.ObjectModel.ObservableCollection<Models6892.Transaccion6892>();
            vm.Transaccion = new Models6892.Transaccion6892();

            vm.Cuenta = cuenta;
            BindingContext = vm;

            if(TransaccionT == "Deposito")
            {
                NombreT.Text = "Importe";
                btRetirar.IsVisible = false;
                vm.Transaccion.TipoT = "Deposito";
            }

            if (TransaccionT == "Retirar")
            {
                NombreT.Text = "Cantidad a retirar";
                btDepositar.IsVisible = false;
                vm.Transaccion.TipoT = "Retiro";
            }
        }
    }
}