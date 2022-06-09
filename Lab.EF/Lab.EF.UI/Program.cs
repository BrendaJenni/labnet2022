using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int num;
            do
            {
                Console.Clear();

                MenuOptions();

                bool resultado = int.TryParse(Console.ReadLine(), out num);
                if (resultado)
                {
                    switch (num)
                    {
                        case 0:
                            ShowCategories();
                            break;
                        case 1:
                            ShowCustomers();
                            break;
                        case 2:
                            AddCategory();
                            break;
                        case 3:
                            DeleteCategory();
                            break;
                        case 4:
                            UpdateCategory();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese un dato válido");
                }
                Console.WriteLine("");
                if (num != 5)
                {
                    Console.WriteLine("Oprima cualquier tecla para regresar al menu");
                    Console.ReadKey();
                }

            } while (num != 5);    
        }

        static void MenuOptions()
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("0. Show Categories");
            Console.WriteLine("1. Show Customers");
            Console.WriteLine("2. Add category");
            Console.WriteLine("3. Delete category");
            Console.WriteLine("4. Update category");
            Console.WriteLine("5. Finish");
        }
        static void ShowCategories()
        {
            CategoriesLogic categoryLogic = new CategoriesLogic();
            foreach (var item in categoryLogic.GetAll())
            {
                Console.WriteLine($"{item.CategoryName} - {item.Description}");
            }
        }
        static void ShowCustomers()
        {
            CustomersLogic customerLogic = new CustomersLogic();
            foreach (var item in customerLogic.GetAll())
            {
                Console.WriteLine($"{item.CompanyName} - {item.City}");
            }
        }
        static void AddCategory()
        {
            try
            {
                Console.WriteLine("Ingrese la categoria");
                string tempName = Console.ReadLine();
                Console.WriteLine("Ingrese la descripcion");
                string tempDescription = Console.ReadLine();

                CategoriesLogic categoryLogic = new CategoriesLogic();
                categoryLogic.Add(new Categories
                {
                    CategoryName = tempName,
                    Description = tempDescription
                });
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingresó un dato erróneo");
               
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                Console.WriteLine("Excedió el límite de caracteres");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void DeleteCategory()
        {
            try
            {
                Console.WriteLine("Ingrese la ID por la que desea eliminar");
                int tempID = int.Parse(Console.ReadLine());

                CategoriesLogic categoryLogic = new CategoriesLogic();
                categoryLogic.ValidateID(tempID);
                categoryLogic.Delete(tempID);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                Console.WriteLine($"No es posible eliminar esta ID por que esta siendo utilizada.");
            }
            catch (PersonalException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("El ID especificado no existe");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void UpdateCategory()
        {
            try
            {
                Console.WriteLine("Ingrese la id buscada");
                int tempNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la categoria");
                string tempName = Console.ReadLine();
                Console.WriteLine("Ingrese la descripcion");
                string tempDescription = Console.ReadLine();

                CategoriesLogic categoryLogic = new CategoriesLogic();
                categoryLogic.ValidateID(tempNum);
                categoryLogic.Update(new Categories
                {
                    CategoryID = tempNum,
                    CategoryName = tempName,
                    Description = tempDescription
                });
            }
            catch (FormatException)
            {
                Console.WriteLine("Ingresó un dato erroneo");
            }
            catch (PersonalException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("El ID especificado no existe");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                Console.WriteLine("Excedió el límite de caracteres");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
