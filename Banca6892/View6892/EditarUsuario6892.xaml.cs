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
    public partial class EditarUsuario6892 : ContentPage
    {
        public EditarUsuario6892()
        {
            InitializeComponent();
            BindingContext = new RegistroViewModel6892();
        }
    }
}