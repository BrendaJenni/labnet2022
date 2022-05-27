using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary;

namespace TP1_POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Transporte> transportes = new List<Transporte>
            {
                new Taxi(4,"AB11"),
                new Taxi(2,"KL09"),
                new Taxi(3,"MD08"),
                new Taxi(1,"OA23"),
                new Taxi(5,"EM74"),

                new Omnibus(35,"La Plata"),
                new Omnibus(100,"Bahía Blanca"),
                new Omnibus(10,"Mar del Plata"),
                new Omnibus(66,"Luján"),
                new Omnibus(20,"Zárate")
            };           
            
            int num;
            do
            {
                Console.Clear();
                Console.WriteLine("Ingrese una opción");
                Console.WriteLine("0.Mostrar toda la colección");
                Console.WriteLine("1.Mostrar Taxis");
                Console.WriteLine("2.Mostrar Omnibus");
                Console.WriteLine("3.Ver ubicación aproximada del Omnibus");
                Console.WriteLine("4.Ver km recorridos y tarifas del Taxi");
                Console.WriteLine("5.Finalizar");

                bool resultado = int.TryParse(Console.ReadLine(), out num);
                if (resultado)
                {
                    switch (num)
                    {
                        case 0:
                            //Muestra toda la lista
                            Console.WriteLine("");
                            foreach (var item in transportes)
                            {  
                                if (item.GetType() == typeof(Omnibus))
                                {
                                    Console.WriteLine($"Omnibus ramal {((Omnibus)item).Ramal}: {item.pasajeros} pasajeros");
                                }
                                else
                                {
                                    Console.WriteLine($"Taxi {((Taxi)item).Codigo}: {item.pasajeros} pasajeros");
                                }
                            }
                            break;
                        case 1:
                            //Muestra solo los taxis
                            Console.WriteLine("");
                            foreach (var item in transportes)
                            {                               
                                if (item.GetType() == typeof(Taxi))
                                {
                                    Console.WriteLine($"Taxi {((Taxi)item).Codigo}: {item.pasajeros} pasajeros");
                                }
                            }
                            break;
                        case 2:
                            //Muestra solo los omnibus
                            Console.WriteLine("");
                            foreach (var item in transportes)
                            {
                                if (item.GetType() == typeof(Omnibus))
                                {
                                    Console.WriteLine($"Omnibus ramal {((Omnibus)item).Ramal}: {item.pasajeros} pasajeros");
                                }
                            }
                            break;
                        case 3:
                            //Muestra la cercania del omnibus a las paradas hasta llegar al final y se reinicia
                            Console.WriteLine("");
                            foreach (var item in transportes)
                            {                               
                                if (item.GetType() == typeof(Omnibus))
                                {
                                    item.Detenerse();
                                    Console.WriteLine(((Omnibus)item).Paradas());
                                }
                            }
                            break;
                        case 4:
                            //Muestra los km recorridos, la cantidad de pasajeros y la tarifa de los 5 taxis
                            Console.WriteLine("");
                            foreach (var item in transportes)
                            {
                                if (item.GetType() == typeof(Taxi))
                                {
                                    item.Avanzar();
                                    Console.WriteLine($"El taxi {((Taxi)item).Codigo}: {item.pasajeros} pasajeros");
                                    Console.WriteLine($"Recorrió {item.km}km y su valor fue de ${((Taxi)item).Tarifa}");
                                    item.Detenerse();
                                    
                                }
                            }
                            break;
                        default: Console.WriteLine("Ingrese un valor valido"); break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un dato válido");
                }
                Console.WriteLine("");
                Console.WriteLine("Oprima cualquier tecla para regresar al menu");
                Console.ReadKey();
            } while (num != 5);
        }
    }
}
