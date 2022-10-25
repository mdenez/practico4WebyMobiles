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

        public VOTemperature crearVOT()
        {
            VOTemperature vot = new VOTemperature();
            Console.WriteLine("Ingrese ciudad, fecha, temperatura: ");
            String ciudad = Console.ReadLine();
            DateTime fecha = Convert.ToDateTime(Console.ReadLine());


            bool valid = false;

            while (!valid)
            {
                string inValue = Console.ReadLine();
                Double temp = 0;
                if (double.TryParse(inValue, out temp) == false)
                {
                    Console.WriteLine("Initial value must be of the type double");
                    Console.WriteLine("\nPlease enter the number again: ");
                }
                else if (temp < 0)
                {
                    Console.WriteLine("Initial value must be of at least a value of zero");
                    Console.WriteLine("\nPlease enter the number again: ");
                }
                else
                {
                    valid = true;
                    //Double temp = Convert.ToDouble(Console.ReadLine());
                    
                    vot.Ciudad = ciudad;
                    vot.Fecha = fecha;
                    vot.Temperature = temp;

                }
            }

            return vot;
        }


        static void Main(string[] args)
        {
            WebService1SoapClient ws = new TestConsole.WebService1.WebService1SoapClient();
            //Double result = ws.getTemperature("Montevideo");
            //Console.WriteLine(String.Format("Temperatura de Montevideo {0} ", result));
            //Console.ReadLine();

            int opcion=0;

            while (opcion != 10)
            {
                Console.WriteLine("Opciones; \n\n1-Insertar Temperatura\n2-Modificar Temperatura \n3-Temperaturas por ciudad\n\n\n\n10-Salir");
                Console.WriteLine("\n\nIngrese opcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Class1 c1 = new Class1();
                tipoError error = new tipoError();

                switch (opcion)
                {
                    case 1:
                        VOTemperature votIns = c1.crearVOT();
                        error = ws.InsertTemperature(votIns);
                        Console.WriteLine(error.ToString());
                        Console.ReadLine();
                        
                        Console.Clear();
                        break;
                    case 2:
                        VOTemperature vot1 = c1.crearVOT();
                        VOTemperature vot2 = c1.crearVOT();
                        error = ws.ModifyTemperature(vot1, vot2);
                        Console.WriteLine(error.ToString());
                        Console.ReadLine();

                        Console.Clear();
                        break;

                    case 3:
                        Console.WriteLine("Ingrese ciudad");
                        String ciudad = Console.ReadLine();
                        List<VOTemperature> lista = ws.ListTempreaturesByCity(ciudad).ToList<VOTemperature>();
                        foreach(VOTemperature t in lista)
                        {
                            Console.WriteLine(t.Ciudad + " " + t.Fecha + " " + t.Temperature);
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }

            }
        }

        
    }
}
