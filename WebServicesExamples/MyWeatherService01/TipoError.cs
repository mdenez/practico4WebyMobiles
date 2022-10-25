using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeatherService01
{
    public class TipoError : Exception
    {
        public enum tipoError 
        {
            CiudadYaExiste,
            CiudadNoExiste,
            TemperaturaYaExisteEseDia,
            TemperaturaNoExisteEseDia,
            OperacionExitosa
        }
    }
}
