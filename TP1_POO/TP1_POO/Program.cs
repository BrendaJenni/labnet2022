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

            List<Transporte> transportes=new List<Transporte>();
            int num;
            
            do
            {
                
                Console.Clear();
                Console.WriteLine("Ingrese una opción");
                Console.WriteLine("0.Cargar Transportes");
                Console.WriteLine("1.Mostrar Taxis");
                Console.WriteLine("2.Mostrar Omnibus");
                Console.WriteLine("3.Ver ubicación aproximada del Omnibus");
                Console.WriteLine("4.Ver km recorridos y tarifas del Taxi");
                Console.WriteLine("5.Mostrar toda la colección");
                Console.WriteLine("6.Finalizar");

                bool resultado = int.TryParse(Console.ReadLine(), out num);
                if (resultado)
                {
                    switch (num)
                    {
                        case 0:
                            //Es necesario cargar los transportes primero para visualizarlos
                            Console.WriteLine("");

                            try
                            {
                                transportes = CargarTransportes();
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Ha ingresado un caracter invalido");
                            }
                            break;
                        case 1:
                            //Muestra solo los taxis
                            Console.WriteLine("");
                            MostrarTransportes(transportes, num);
                            break;
                        case 2:
                            //Muestra solo los omnibus
                            Console.WriteLine("");
                            MostrarTransportes(transportes, num);
                            break;
                        case 3:
                            //Muestra la cercania del omnibus a las paradas hasta llegar al final y se reinicia
                            Console.WriteLine("");
                            if(transportes.Count > 0)
                            {
                                Console.WriteLine("Los transportes no fueron cargados");
                            }
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
                            if (transportes.Count > 0)
                            {
                                Console.WriteLine("Los transportes no fueron cargados");
                            }
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
                        case 5:
                            //Muestra toda la lista
                            Console.WriteLine("");
                            MostrarTransportes(transportes, num);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un dato válido");
                }
                Console.WriteLine("");
                if (num != 6)
                {
                    Console.WriteLine("Oprima cualquier tecla para regresar al menu");
                    Console.ReadKey();
                }
            } while (num != 6);
        }
        public static List<Transporte> CargarTransportes()
        {
            List<Transporte> transportes = new List<Transporte>();
            Console.WriteLine("Ingrese los pasajeros de 5 taxis");
            try
            {
                
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Taxi {i + 1} cantidad de pasajeros: ");
                    int cantPasajeros = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Taxi {i + 1} codigo: ");
                    string identificador = Console.ReadLine();
                    var taxi = new Taxi(cantPasajeros, identificador);
                    transportes.Add(taxi);
                }
                Console.WriteLine("Ingrese los pasajeros de 5 omnibuses");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Omnibus {i + 1} cantidad de pasajeros: ");
                    int cantPasajeros = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Omnibus {i + 1} ramal: ");
                    string identificador = Console.ReadLine();
                    var omnibus = new Omnibus(cantPasajeros, identificador);
                    transportes.Add(omnibus);
                }

                return transportes;
            }
            catch (FormatException)
            {

                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void MostrarTransportes(List<Transporte> lista,int tipo)
        {
            if(lista.Count>0)
            {
                if (tipo == 2 || tipo == 5)
                {
                    foreach (var item in lista)
                    {
                        if (item.GetType() == typeof(Omnibus))
                        {
                            Console.WriteLine($"Omnibus ramal {((Omnibus)item).Ramal}: {item.pasajeros} pasajeros");
                        }
                    }
                }
                if (tipo == 1 || tipo == 5)
                {
                    foreach (var item in lista)
                    {
                        if (item.GetType() == typeof(Taxi))
                        {
                            Console.WriteLine($"Taxi {((Taxi)item).Codigo}: {item.pasajeros} pasajeros");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Los transportes no fueron cargados");
            }
            
        }
    }
}
