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
                    Console.WriteLine("Please, enter valid and correct data");
                }
                Console.WriteLine("");
                if (num != 5)
                {
                    Console.WriteLine("Press any key to continue to the menu");
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
                Console.WriteLine("Enter category");
                string tempName = Console.ReadLine();
                Console.WriteLine("Enter description");
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
                Console.WriteLine("Please, enter valid and correct data");
               
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                Console.WriteLine("Maximum character limit exceeded in one or more fields");
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
                Console.WriteLine("Enter the ID what you're looking for");
                int tempID = int.Parse(Console.ReadLine());

                CategoriesLogic categoryLogic = new CategoriesLogic();
                categoryLogic.ValidateID(tempID);
                categoryLogic.Delete(tempID);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                Console.WriteLine("It's not possible to delete");
            }
            catch (PersonalException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The ID does not exist");
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
                Console.WriteLine("Enter the ID");
                int tempNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter category");
                string tempName = Console.ReadLine();
                Console.WriteLine("Enter description");
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
                Console.WriteLine("Please, enter valid and correct data");
            }
            catch (PersonalException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The ID does not exist");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                Console.WriteLine("Maximum character limit exceeded in one or more fields");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
