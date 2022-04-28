using Banca6892.Models6892;
using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using System.Text;
using System.Windows.Input;

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
                return new RelayCommand(checkValidations);
            }
            set { }
        }
        public ICommand InpNombre
        {
            get
            {
                return new RelayCommand(checkValidations);
            }
            set { }
        }
        #endregion
        #region Methods
        private void checkValidations()
        {
            Console.WriteLine("FAK");
        }
        #endregion
        #region Constructor

        #endregion
    }
}
