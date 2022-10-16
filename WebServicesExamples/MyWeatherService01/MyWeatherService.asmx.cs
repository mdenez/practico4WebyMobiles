using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyWeatherService01
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://localhost")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public Double getTemperature(String city)
        {
            Dictionary<String, Double> citiesTemp = new Dictionary<string, double>();
            citiesTemp.Add("Montevideo", 20.5);
            citiesTemp.Add("Maldonado", 15.8);
            citiesTemp.Add("Salto", 29.8);
            citiesTemp.Add("Colonia", 12.3);

            Double temp;
            try
            {
                citiesTemp.TryGetValue(city,out temp);
            }catch (Exception)
            {
                throw new ArgumentNullException();
            }
            return temp;
        }
    }
}
