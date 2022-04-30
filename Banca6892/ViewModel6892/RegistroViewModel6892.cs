using Banca6892.Models6892;
using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Banca6892.ViewModel6892
{
    public class RegistroViewModel6892 : BaseViewModel6892
    {
        #region Attributes
        private string nombre;
        private string apellidoP;
        private string apellidoM;
        private string telefono;


        #endregion
        #region Properties
        public string NombreText
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public string ApellidoPText
        {
            get { return this.apellidoP; }
            set { SetValue(ref this.apellidoP, value); }
        }

        public string ApellidoMText
        {
            get { return this.apellidoM; }
            set { SetValue(ref this.apellidoM, value); }
        }

        public string TelefonoNumb
        {
            get { return this.telefono; }
            set { SetValue(ref this.telefono, value); }
        }
        #endregion
        #region Commads
        public ICommand btRegistrar
        {
            get
            {
                return new RelayCommand(BtVal);
            }
            set { }
        }
        public ICommand InpNombre
        {
            get
            {
                return new RelayCommand(NombreVal);
            }
            set { }
        }

        public ICommand InpApellidoP
        {
            get
            {
                return new RelayCommand(ApellidoPVal);
            }
            set { }
        }
        public ICommand InpApellidoM
        {
            get
            {
                return new RelayCommand(ApellidoPVal);
            }
            set { }
        }

        public ICommand InpTelefono
        {
            get
            {
                return new RelayCommand(TelefonoVal);
            }
            set { }
        }




        #endregion
        #region Methods
        private void NombreVal()
        {
            if (NombreText.Length > 0)
            {
                string caracteres = NombreText[NombreText.Length - 1].ToString();
                if (!Regex.IsMatch(caracteres, @"^[a-zA-Z' ']+$"))
                {
                    NombreText = NombreText.Substring(0, NombreText.Length - 1);
                }
            }
        }

        private void ApellidoPVal()
        {
            if (ApellidoPText.Length > 0) {
                string caracteres = ApellidoPText[ApellidoPText.Length - 1].ToString();
                if (!Regex.IsMatch(caracteres, @"^[a-zA-Z' ']+$"))
                {
                    ApellidoPText = ApellidoPText.Substring(0, ApellidoPText.Length - 1);
                }
            }
        }

        private void ApellidoMVal()
        {
            if (ApellidoPText.Length > 0)
            {
                string caracteres = ApellidoPText[ApellidoPText.Length - 1].ToString();
                if (!Regex.IsMatch(caracteres, @"^[a-zA-Z' ']+$"))
                {
                    ApellidoPText = ApellidoPText.Substring(0, ApellidoPText.Length - 1);
                }
            }
        }

        private void TelefonoVal()
        {
            if (TelefonoNumb.Length > 0)
            {
                if (TelefonoNumb.Length <= 10)
                {
                    string caracteres = TelefonoNumb[TelefonoNumb.Length - 1].ToString();
                    if (!Regex.IsMatch(caracteres, @"^[0-9]*$"))
                    {
                        TelefonoNumb = TelefonoNumb.Substring(0, TelefonoNumb.Length - 1);
                    }
                }
                else
                {
                    TelefonoNumb = TelefonoNumb.Substring(0, 10);
                }
            }
        }

        async private void BtVal()
        {
            if(NombreText?.Length > 0 && ApellidoPText?.Length > 0 && ApellidoMText?.Length > 0 && TelefonoNumb?.Length > 0)
            {
                Usuario6892 usuario = new Usuario6892()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nombre = NombreText,
                    ApellidoPaterno = ApellidoPText,
                    ApellidoMaterno = ApellidoMText,
                    Telefonos = TelefonoNumb
                };
                await Application.Current.MainPage.DisplayAlert("Registro Exitoso!", "Gracias!", "Continuar");
                Application.Current.MainPage = new NavigationPage(new View6892.Principal6892(usuario));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Favor de llenar el formulario", "Informacion Incorrecta", "Ok");
            }
        }


        #endregion
        #region Constructor

        #endregion
    }
}
