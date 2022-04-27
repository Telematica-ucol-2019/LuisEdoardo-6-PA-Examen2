﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Banca6892.Models6892
{
    internal class Usuario
    {
        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public ObservableCollection<Telefono> Telefonos { get; set; }
    }

    public class Telefono
    {
        public string Id { get; set; }

        public string Numero { get; set; }

    }
}
