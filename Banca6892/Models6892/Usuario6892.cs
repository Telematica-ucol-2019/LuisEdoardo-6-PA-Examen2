using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Banca6892.Models6892
{
    public class Usuario6892
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Telefonos { get; set; }
        public ObservableCollection<Cuenta6892> cuentas { get; set; }
    }


}
