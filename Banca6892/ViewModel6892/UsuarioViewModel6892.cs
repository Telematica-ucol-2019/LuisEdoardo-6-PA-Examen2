using Banca6892.Models6892;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Banca6892.ViewModel6892
{
    public class UsuarioViewModel6892 : BaseViewModel6892
    {




        public ObservableCollection<Cuenta6892> CuentasL { get; set; }
        public ICommand btCuentaNueva { get; set; }
        public ICommand cuentaDetalle { get; set; }
        public ICommand btAñadirCuenta { get; set; }

        private Cuenta6892 cuenta;
        public Cuenta6892 Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; OnPropertyChanged(); }
        }

        public UsuarioViewModel6892(Usuario6892 usuario)
        {

            nombre = usuario.Nombre;
            apellidoP = usuario.ApellidoPaterno;
            apellidoM = usuario.ApellidoMaterno;
            telefono = usuario.Telefonos;
            CuentasL = new ObservableCollection<Cuenta6892>();
            usuario.cuentas = new ObservableCollection<Cuenta6892>() { new Cuenta6892() { NombreC = "Debito", Numero = new Random().Next(1000, 9999), Saldo = new Random().Next(1000, 4000), Transaccion = new ObservableCollection<Transaccion6892>() } };
            CuentasL = usuario.cuentas;

            btCuentaNueva = new Command(async () => await PCbtCommand());
            cuentaDetalle = new Command<Cuenta6892>(async (x) => await PCcuentaDetalle(x));
            btAñadirCuenta = new Command<Cuenta6892>(async (x) => await PCañadirCuenta(x));


            async Task PCbtCommand()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View6892.CrearCuenta6892(this));
            }

            async Task PCañadirCuenta(Models6892.Cuenta6892 _Cuenta)
            {
                _Cuenta.Numero = new Random().Next(1000, 9999);
                _Cuenta.Saldo = new Random().Next(1000, 4000);
                usuario.cuentas.Add(_Cuenta);
                CuentasL = usuario.cuentas;
                Console.WriteLine("Cuenta Añadida");
                Console.WriteLine(usuario.cuentas[1].NombreC);
                Console.WriteLine(usuario.cuentas[1].Numero);
                Console.WriteLine(usuario.cuentas[1].Saldo);
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCcuentaDetalle(Models6892.Cuenta6892 _Cuenta)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View6892.CuentaDetalles(_Cuenta, this));
            }
        }
        #region Attributes
        private string nombre;
        private string apellidoP;
        private string apellidoM;
        private string telefono;
        #endregion
        #region Properties
        
        public string inNombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        #endregion

        #region Commands
 

        #endregion
        #region Methods
        #endregion
        #region Contructor
        #endregion
    }
}
