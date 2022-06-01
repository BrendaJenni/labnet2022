using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryClass;

namespace TPExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1
            try
            {
                Console.WriteLine("1°Caso: \nIngrese un numero a dividir");
                int numA = (int.Parse(Console.ReadLine()));
                int resul1 = numA.Dividir(0);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Ha ocurrido una excepcion: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ha ocurrido una excepcion: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Ejecucion finalizada");
            }

            //Ejercicio 2
            try
            {
                Console.WriteLine("2°Caso: \nIngrese los numeros a dividir");
                int numB = (int.Parse(Console.ReadLine()));
                int numC = (int.Parse(Console.ReadLine()));
                int resul2 = numB.Dividir(numC);
                Console.WriteLine($"El resulado de la division es: {resul2}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Cuantas veces va a recursar matematica?: {e.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"Seguro Ingreso una letra o no ingreso nada!");
            }

            //Ejercicio 3
            var logic=new Logic();
            try
            {
                logic.ThrowException();
            }
            catch (StackOverflowException e)
            {
                Console.WriteLine($"3°Caso: \nTipo de excepcion: {e.GetType().ToString()} \nMensaje: {e.Message}");
            }

            //Ejercicio 4
            try
            {
                logic.ThrowPersonalException();
            }
            catch (PersonalException e)
            {
                Console.WriteLine($"4°Caso: \nTipo de excepcion: {e.GetType().ToString()} \nMensaje: {e.Message}");
            }

            Console.ReadKey();
            

        }
    }
}
