using MyWeatherService01.CitiesDSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Services;
using static MyWeatherService01.TipoError;

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
    public class WebService1 : WebService
    {
        CitiesDS cities = new CitiesDS();
        TemperatureTableAdapter temperatureTableAdapter = new TemperatureTableAdapter();
        CitiesTableAdapter citiesTableAdapter = new CitiesTableAdapter();


        [WebMethod]
        public Double getTemperature(DateTime day, String city)
        {
            //CitiesDS cities = new CitiesDS();
            //TemperatureTableAdapter temperature = new TemperatureTableAdapter();
            temperatureTableAdapter.Fill(cities.Temperature);

            if(temperatureTableAdapter.ConsultaTemp(city, day.ToString()) == 1){
                return (float)temperatureTableAdapter.ConsultaTemperatura(city, day.ToString());
            }
            else
            {
                return -1000;
            }
        }

        [WebMethod]
        public tipoError InsertCity(String city)
        {
           
            //CitiesDS citiesDS = new CitiesDS();
            //CitiesTableAdapter citiesTableAdapter = new CitiesTableAdapter();
            citiesTableAdapter.Fill(cities.Cities);
            if (citiesTableAdapter.SelectCity(city) == 1)
            {
                return tipoError.CiudadYaExiste;
            }
            else
            {
                citiesTableAdapter.Insert(city);
                return tipoError.OperacionExitosa;

            }

        }

        [WebMethod]
        public tipoError InsertTemperature(VOTemperature vot)
        {
            
            //CitiesDS citiesDS = new CitiesDS();
            //TemperatureTableAdapter tempTA = new TemperatureTableAdapter();
            //CitiesTableAdapter citiesTableAdapter = new CitiesTableAdapter();
            citiesTableAdapter.Fill(cities.Cities);
            temperatureTableAdapter.Fill(cities.Temperature);
            if (citiesTableAdapter.SelectCity(vot.Ciudad) !=1)
            {
                return tipoError.CiudadNoExiste;
            }
            else
            {
                int v = (int)temperatureTableAdapter.CheckExisteTemp(vot.Ciudad, vot.Fecha.ToString(), (float)vot.Temperature);
                if (v == 1)
                {
                    return tipoError.TemperaturaYaExisteEseDia;
                }
                else
                {
                    temperatureTableAdapter.InsertQuery(vot.Ciudad,vot.Fecha.ToString(),(float)vot.Temperature);
                    return tipoError.OperacionExitosa;
                }
            }

        }

        [WebMethod]
        public tipoError ModifyTemperature(VOTemperature vot, VOTemperature votNueva)
        {
            //CitiesDS citiesDS = new CitiesDS();
            //TemperatureTableAdapter tempTA = new TemperatureTableAdapter();
            //CitiesTableAdapter citiesTableAdapter = new CitiesTableAdapter();
            citiesTableAdapter.Fill(cities.Cities);
            temperatureTableAdapter.Fill(cities.Temperature);
            if (citiesTableAdapter.SelectCity(vot.Ciudad) != 1)
            {
                return tipoError.CiudadNoExiste;
            }
            else
            {
                int v = (int)temperatureTableAdapter.CheckExisteTemp(vot.Ciudad, vot.Fecha.ToString(), (float)vot.Temperature);
                if (v == 1)
                {
                    temperatureTableAdapter.UpdateQuery((float)votNueva.Temperature,vot.Ciudad, vot.Fecha.ToString(), (float)vot.Temperature);
                    return tipoError.OperacionExitosa;
                }
                else
                {
                    return tipoError.TemperaturaNoExisteEseDia;
                }
            }
        }

        [WebMethod]
        public tipoError DeleteCity(String city)
        {
            //CitiesDS cities = new CitiesDS();
            //CitiesTableAdapter citiesTableAdapter = new CitiesTableAdapter();
            citiesTableAdapter.Fill(cities.Cities);
            if(citiesTableAdapter.SelectCity(city) != 1)
            {
                return tipoError.CiudadNoExiste;
            }
            else
            {
                citiesTableAdapter.Delete(city);
                return tipoError.OperacionExitosa;
            }
        }

        [WebMethod]
        public tipoError DeleteTemperature(String city, DateTime fecha)
        {
            temperatureTableAdapter.Fill(cities.Temperature);
            if(temperatureTableAdapter.ConsultaTemp(city,fecha.ToString()) != 1)
            {
                return tipoError.TemperaturaNoExisteEseDia;
            }
            else
            {
                temperatureTableAdapter.DeleteTemp(city, fecha.ToString());
                return tipoError.OperacionExitosa;
            }
        }

        [WebMethod]
        public List<VOTemperature> ListTempreaturesByCity(String city)
        {
            List<VOTemperature> lista = new List<VOTemperature>();
            temperatureTableAdapter.Fill(cities.Temperature);
            DataTable dsTemps = temperatureTableAdapter.GetTemperaturesCity(city);

            foreach(CitiesDS.TemperatureRow tr in dsTemps.Rows)
            {
                VOTemperature vot = new VOTemperature(tr.ciudad, tr.fecha, tr.temperatura);
                lista.Add(vot);
            }


            return lista;
        }
    }
}
