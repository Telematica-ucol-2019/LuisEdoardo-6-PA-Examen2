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
    public partial class CuentaDetalles : ContentPage
    {
        public CuentaDetalles()
        {
            InitializeComponent();
            BindingContext = new CuentaViewModel6892();
        }
    }
}