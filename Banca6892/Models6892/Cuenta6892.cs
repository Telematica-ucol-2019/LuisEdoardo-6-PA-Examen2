using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Banca6892.Models6892
{
    public class Cuenta6892
    {
        public string Id { get; set; }
        public string NombreC { get; set; }
        public int Numero { get; set; }
        public int Saldo { get; set; }
        public string Tipo { get; set; }
        public string Fecha { get; set; }

        public ObservableCollection<Transaccion6892> transaccion {get; set;}

    }
}
