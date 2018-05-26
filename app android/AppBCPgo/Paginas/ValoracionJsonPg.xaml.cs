using AppBCPgo.Entity;
using Newtonsoft.Json;
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
	public partial class ValoracionJsonPg : ContentPage
	{
		public ValoracionJsonPg ()
		{
			InitializeComponent ();
            obtener();
		}

        private async void obtener()
        {

            string RestUrl = "http://18.191.14.35";
            string Url = "/alarmas/sistema/api/getestablecimiento.php";
            string result = "";
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestUrl);
                string url = string.Format(Url);

                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {

            }

            List<Establecimiento> esta = new List<Establecimiento>();

            esta = JsonConvert.DeserializeObject<List<Establecimiento>>(result);

           
            Random rnd = new Random();

            int  mIndex = rnd.Next(0, esta.Count);

            while (mIndex==ids)
            {
                mIndex = rnd.Next(0, esta.Count);
            }

            estadoval.Text=   esta[mIndex].estado;
            horarioval.Text = esta[mIndex].horario ;
            tiempoval.Text = esta[mIndex].tiempo_estimado+ " min";
            titulo.Text = esta[mIndex].nombre;
            operacionval.Text = esta[mIndex].operaciones_validas;

            ids = mIndex;
        }

        public int ids;
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("¡Gracias!", "Su Calificacion fue enviada con éxito", "Aceptar");
        }
    }
}