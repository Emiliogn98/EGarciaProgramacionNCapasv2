using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Calculadora
    {
        public static void Suma()
        {
            ServiceCalculadora.CalculatorSoapClient calculadora = new ServiceCalculadora.CalculatorSoapClient();
            var result = calculadora.Add(5,5);
            Console.WriteLine(result);
        }
        public static void Resta()
        {
            ServiceCalculadora.CalculatorSoapClient calculadora = new ServiceCalculadora.CalculatorSoapClient();
            var result = calculadora.Subtract(10, 5);
            Console.WriteLine(result);
        }
        public static void Multiplicacion()
        {
            ServiceCalculadora.CalculatorSoapClient calculadora = new ServiceCalculadora.CalculatorSoapClient();
            var result = calculadora.Multiply(5, 5);
            Console.WriteLine(result);
        }
        public static void Division()
        {
            ServiceCalculadora.CalculatorSoapClient calculadora = new ServiceCalculadora.CalculatorSoapClient();
            var result = calculadora.Divide(5, 5);
            Console.WriteLine(result);
        }
    }
}
