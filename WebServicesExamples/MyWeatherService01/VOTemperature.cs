using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeatherService01
{
    public class VOTemperature
    {
        public String Ciudad { get; set; }
        public DateTime Fecha { get; set; }
        public Double Temperature { get; set; }

        public VOTemperature() { }

        public VOTemperature(String ciudad, DateTime fecha, Double temp)
        {
            this.Ciudad = ciudad;
            this.Fecha = fecha;
            this.Temperature = temp;
        }
    }
}