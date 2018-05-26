using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBCPgo.Entity
{
    public class Establecimiento
    {
        public string id { get; set; }
        public string puntuacion_prom { get; set; }
        public string horario { get; set; }
        public string operaciones_validas { get; set; }
        public string tiempo_estimado { get; set; }
        public string estado { get; set; }
        public string cantidad_disponibles { get; set; }
        public string id_historial { get; set; }
        public string lat { get; set; }
        [JsonProperty("long")]
        public string longi { get; set; }
        public string nombre { get; set; }
    }
}
