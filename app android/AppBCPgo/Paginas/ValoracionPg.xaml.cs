using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBCPgo.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ValoracionPg : ContentPage
	{
		public ValoracionPg ()
		{
			InitializeComponent ();
        
		}

     
    

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Alerta());
        }
    }
}