using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using System.Collections.Generic;
using System.Net.Http;
using AppBCPgo.Entity;
using Newtonsoft.Json;

namespace AppBCPgo.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapaPg : ContentPage
	{
		public MapaPg ()
		{
			InitializeComponent ();

            MapView.MoveToRegion( MapSpan.FromCenterAndRadius(  new Position(37, -122), Distance.FromMiles(1)));
            AddPins();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ValoracionJsonPg());  
        }

        private async void AddPins()
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
                result = ex.Message;
            }

            List<Establecimiento> esta = new List<Establecimiento>();

            esta = JsonConvert.DeserializeObject<List<Establecimiento>>(result);

            Position position = new Position(37, -122);
            double lati = 0.0;
            double longi = 0.0;
            for (int i = 0; i < esta.Count; i++)
            {

                lati = double.Parse(esta[i].lat.ToString());
                longi = double.Parse(esta[i].longi.ToString());
                position = new Position(lati,longi ); // Latitude, Longitude
                Pin pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = esta[i].nombre,
                    Address = "Tiempo estimado: " + esta[i].tiempo_estimado + " min"
                };
              MapView.Pins.Add(pin);
            } 
           
          MapView.MoveToRegion(new MapSpan(position,position.Latitude, position.Longitude));

            }

         

        }
           


          
        }
    
