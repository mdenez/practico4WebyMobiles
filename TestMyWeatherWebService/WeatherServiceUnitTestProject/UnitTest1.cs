using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherServiceUnitTestProject.ServiceReference1;

namespace WeatherServiceUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();
            List<VOTemperature> lista = ws.ListTempreaturesByCity("Montevideo").ToList<VOTemperature>();

            Assert.AreEqual(lista.Count, 5);

        }
    }
}
