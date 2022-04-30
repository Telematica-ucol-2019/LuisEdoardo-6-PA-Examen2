using Banca6892.Models6892;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public ICommand btBorrarCuenta { get; set; }
        public ICommand btDepositar { get; set; }
        public ICommand transaccionD { get; set; }
        public ICommand btRetirar { get; set; }
        public ICommand transaccionR { get; set; }


        private Usuario6892 usuario;
        public Usuario6892 Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }

        private Cuenta6892 cuenta;
        public Cuenta6892 Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; OnPropertyChanged(); }
        }

        private Transaccion6892 transaccion;
        public Transaccion6892 Transaccion
        {
            get { return transaccion; }
            set { transaccion = value; OnPropertyChanged(); }
        }

        public UsuarioViewModel6892(Usuario6892 usuario)
        {

            nombre = usuario.Nombre;
            apellidoP = usuario.ApellidoPaterno;
            apellidoM = usuario.ApellidoMaterno;
            telefono = usuario.Telefonos;
            CuentasL = new ObservableCollection<Cuenta6892>();
            usuario.cuentas = new ObservableCollection<Cuenta6892>() { new Cuenta6892() { NombreC = "Debito", Numero = new Random().Next(1000, 9999), Saldo = 0, Transaccion = new ObservableCollection<Transaccion6892>(){
            new Transaccion6892{Monto = 100, FechaT ="24/24/23", Hora = "2:23" } }}};
            CuentasL = usuario.cuentas;

            btCuentaNueva = new Command(async () => await PCbtCommand());
            cuentaDetalle = new Command<Cuenta6892>(async (x) => await PCcuentaDetalle(x));
            btAñadirCuenta = new Command<Cuenta6892>(async (x) => await PCañadirCuenta(x));
            btBorrarCuenta = new Command<Cuenta6892>(async (x) => await PCBorrarCuenta(x));
            btDepositar = new Command(async () => await PCbtDepositar());
            transaccionD = new Command<Transaccion6892>(async (x) => await PCTransaccionD(x));
            btRetirar = new Command(async () => await PCbtRetirar());
            transaccionR = new Command<Transaccion6892>(async (x) => await PCTransaccionR(x));

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

            async Task PCBorrarCuenta(Cuenta6892 _Cuenta)
            {
                if (_Cuenta.Saldo == 0)
                {
                    usuario.cuentas.Remove(_Cuenta);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Saldo aun disponible", "No puede borrar la cuenta si aún cuenta con saldo", "Continuar");
                }
            }

            async Task PCcuentaDetalle(Models6892.Cuenta6892 _Cuenta)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View6892.CuentaDetalles(_Cuenta, this));
            }

            async Task PCbtDepositar()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View6892.Transferencia6892("Deposito", Cuenta, this));
            }

            async Task PCbtRetirar()
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View6892.Transferencia6892("Retirar", Cuenta, this));
            }

            async Task PCTransaccionD(Models6892.Transaccion6892 _Transaccion)
            {

                _Transaccion.FechaT = DateTime.Today.ToString("d");
                _Transaccion.Hora = DateTime.Now.ToString("HH:mm");

                if (Cuenta.Transaccion == null)
                {
                    Cuenta.Transaccion = new ObservableCollection<Transaccion6892>();
                }
                var index = -1;
                Cuenta6892 tiempo =  usuario.cuentas.FirstOrDefault(a => a.Numero == Cuenta.Numero);
                if (tiempo != null)
                {
                    Cuenta.Transaccion.Add(_Transaccion);
                    Cuenta.Saldo += _Transaccion.Monto;
                    index = usuario.cuentas.IndexOf(tiempo);
                    usuario.cuentas[index] = Cuenta;
                }
                OnPropertyChanged();

                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCTransaccionR(Models6892.Transaccion6892 _Transaccion)
            {

                _Transaccion.FechaT = DateTime.Today.ToString("d");
                _Transaccion.Hora = DateTime.Now.ToString("HH:mm");

                if (Cuenta.Transaccion == null)
                {
                    Cuenta.Transaccion = new ObservableCollection<Transaccion6892>();
                }
                var index = -1;
                Cuenta6892 tiempo = usuario.cuentas.FirstOrDefault(a => a.Numero == Cuenta.Numero);
                if (tiempo != null)
                {
                    Cuenta.Transaccion.Add(_Transaccion);
                    Cuenta.Saldo -= _Transaccion.Monto;
                    index = usuario.cuentas.IndexOf(tiempo);
                    usuario.cuentas[index] = Cuenta;
                }
                OnPropertyChanged();

                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PopAsync();
            }

    }
        public string NombreUser
        {
            get { return this.nombre; }
            set { this.usuario.Nombre = value; OnPropertyChanged();}
        }

        public string ApellidoPUser
        {
            get { return this.apellidoP; }
            set { this.usuario.ApellidoPaterno = value; OnPropertyChanged(); }
        }

        public string ApellidoMUser
        {
            get { return this.apellidoM; }
            set { this.usuario.ApellidoMaterno = value; OnPropertyChanged(); }
        }

        public string TelefonoUser
        {
            get { return this.telefono; }
            set { this.usuario.Telefonos = value; OnPropertyChanged(); }
        }

        public ICommand nombreUserV
        {
            get { return new RelayCommand(nombreUserValidate); }
            set { }
        }

        public ICommand ApellidoPUserV
        {
            get { return new RelayCommand(apellidoPUserV); }
            set { }
        }

        public ICommand ApellidoMUserV
        {
            get { return new RelayCommand(apellidoMUserV); }
            set { }
        }

        public ICommand TelefonoUserV
        {
            get { return new RelayCommand(telefonosV); }
            set { }
        }

        public ICommand btGuardar
        {
            get { return new RelayCommand<Usuario6892>(btGuardarUser); }
            set { }
        }

        public ICommand btEditar
        {
            get { return new RelayCommand<Usuario6892>(btEditarV); }
        }

        private void nombreUserValidate()
        {
            if (NombreUser.Length > 0)
            {
                string caracteres = NombreUser[NombreUser.Length - 1].ToString();
                if (!Regex.IsMatch(caracteres, @"^[a-zA-Z' ']+$"))
                {
                    NombreUser = NombreUser.Substring(0, NombreUser.Length - 1);
                }
            }
        }

        private void apellidoPUserV()
        {
            if (ApellidoPUser.Length > 0)
            {
                string caracteres = ApellidoPUser[ApellidoPUser.Length - 1].ToString();
                if (!Regex.IsMatch(caracteres, @"^[a-zA-Z' ']+$"))
                {
                    ApellidoPUser = ApellidoPUser.Substring(0, ApellidoPUser.Length - 1);
                }
            }
        }
        private void apellidoMUserV()
        {
            if (ApellidoMUser.Length > 0)
            {
                string caracteres = ApellidoMUser[ApellidoMUser.Length - 1].ToString();
                if (!Regex.IsMatch(caracteres, @"^[a-zA-Z' ']+$"))
                {
                    ApellidoMUser = ApellidoMUser.Substring(0, ApellidoMUser.Length - 1);
                }
            }
        }

        private void telefonosV()
        {
            if (TelefonoUser.Length > 0)
            {
                string caracteres = TelefonoUser[TelefonoUser.Length - 1].ToString();
                if (!Regex.IsMatch(caracteres, @"^[0-9]*$"))
                {
                    TelefonoUser = TelefonoUser.Substring(0, TelefonoUser.Length - 1);
                }
            }
            else
            {
                TelefonoUser = TelefonoUser.Substring(0, 10);
            }
        }

        async private void btGuardarUser(Usuario6892 usuario6892)
        {
            if (NombreUser?.Length > 0 && ApellidoPUser?.Length > 0 && ApellidoMUser?.Length > 0 && TelefonoUser?.Length > 0)
            {
                Usuario = usuario;
                await Application.Current.MainPage.DisplayAlert("Registro Exitoso!", "Gracias!", "Continuar");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Favor de llenar el formulario", "Informacion Incorrecta", "Ok");
            }
        }

        async private void btEditarV(Usuario6892 _usuario)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new View6892.EditarUsuario6892(_usuario, this));
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
