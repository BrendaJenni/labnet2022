using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaLINQ.Data;
using PracticaLINQ.Logic;

namespace PracticaLINQ.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queryExcercice = new QueryExercices();
            Console.WriteLine("----------------Ejercicio 1----------------");
            Console.WriteLine($"Customer 1:\n{queryExcercice.returnCustomerObj()}");

            Console.WriteLine("----------------Ejercicio 2----------------");
            Console.WriteLine(queryExcercice.returnProductsNoStock());

            Console.WriteLine("----------------Ejercicio 3----------------");
            Console.WriteLine(queryExcercice.returnProductsOnStock());

            Console.WriteLine("----------------Ejercicio 4----------------");
            Console.WriteLine(queryExcercice.returnWACustomers());

            Console.WriteLine("----------------Ejercicio 5----------------");
            var aux = queryExcercice.returnFirstElement();
            if(aux != null)
            {
                Console.WriteLine(aux);
            }
            else
            {
                Console.WriteLine("No existe el ID");
            }

            Console.WriteLine("----------------Ejercicio 6----------------");
            foreach(string item in queryExcercice.returnCustomerNames())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------Ejercicio 7----------------");
            Console.WriteLine(queryExcercice.returnOrdersCustomers());


            Console.ReadKey();
        }
    }
}
