using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestConsole.WebService1;

namespace TestConsole
{
    class Class1
    {
        static void Main(string[] args)
        {
            WebService1SoapClient ws = new TestConsole.WebService1.WebService1SoapClient();
            Double result = ws.getTemperature("Montevideo");
            Console.WriteLine(String.Format("Temperatura de Montevideo {0} ", result));
            Console.ReadLine();
        }
    }
}
