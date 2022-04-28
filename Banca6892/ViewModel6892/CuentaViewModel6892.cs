using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Banca6892.Models6892;
using System.Text;

namespace Banca6892.ViewModel6892
{
    public class CuentaViewModel6892
    {
        public ObservableCollection<Cuenta6892> cuentas { get; set; }

        public CuentaViewModel6892()
        {
            cuentas = new ObservableCollection<Cuenta6892>
            {
                new Cuenta6892
                {
                    NombreC = "Debito",
                    Numero = new Random().Next(1000, 9999),
                    Tipo = "VISA",
                    Fecha = "07/24",
                    Saldo = new Random().Next(1000, 4000)
                },

                new Cuenta6892
                {
                    NombreC = "Crédito",
                    Numero = new Random().Next(1000, 9999),
                    Tipo = "VISA",
                    Fecha = "06/23",
                    Saldo = new Random().Next(1000, 4000)
                }
            };
        }
    }
}
