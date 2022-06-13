using PracticaLINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaLINQ.Entities;

namespace PracticaLINQ.Logic
{
    public class QueryExercices : BaseLogic
    {
        // Exercice 1
        public string returnCustomerObj()
        {
            //Query exercice
            var query = from customers in _context.Customers
                        select customers;
            var customer = query.First();

            return customer.ContactName + "\n" + customer.CustomerID + "\n" + customer.CompanyName;
        }

        // Exercice 2
        public string returnProductsNoStock()
        {
            var list = new StringBuilder("Lista de productos sin stock\n");

            //Query exercice
            var query = _context.Products.Where(x => x.UnitsInStock == 0).ToList();

            foreach(var product in query)
            {
                string productStr = $"{product.ProductName}";
                list.AppendLine(productStr);
            }
            return list.ToString();
        }

        // Exercice 3
        public string returnProductsOnStock()
        {
            var list = new StringBuilder("Lista de productos con stock y que cuestan mas de 3 por unidad\n");

            //Query exercice
            var query = _context.Products.Where(x => x.UnitsInStock != 0 && x.UnitPrice > 3).ToList();

            foreach (var product in query)
            {
                string productStr = $"{product.ProductName}";
                list.AppendLine(productStr);
            }
            return list.ToString();
        }

        // Exercice 4
        public string returnWACustomers()
        {
            var list = new StringBuilder("Customer de la Region WA\n");

            //Query exercice
            var query = _context.Customers.Where(x => x.Region == "WA").ToList();

            foreach(Customers customer in query)
            {
                string info = customer.ContactName +" "+ customer.Region;
                list.AppendLine(info);
            }
            return list.ToString();
        }

        // Exercice 5
        public Products returnFirstElement()
        {
            //Query exercice
            var query = (from products in _context.Products
                        where products.ProductID == 789
                        select products).FirstOrDefault();
            return query;
        }

        // Exercice 6
        public List<string> returnCustomerNames()
        {
            //Query exercice
            var query = _context.Customers.Select(x => x.ContactName).ToList();
            List<string> upperNames = query.ConvertAll(x => x.ToUpper());
            List<string> lowerNames = query.ConvertAll(x => x.ToLower());
            var listNames = upperNames.Concat(lowerNames).ToList();
            return listNames;
        }

        // Exercice 7
        public string returnOrdersCustomers()
        {
            //Query exercice
            var query = from orders in _context.Orders
                        join customers in _context.Customers
                        on orders.CustomerID equals customers.CustomerID
                        where orders.OrderDate > new DateTime(1997, 1, 1) && customers.Region == "WA"
                        select new
                        {
                            CustomerName = customers.ContactName,
                            CustomerRegion = customers.Region,
                            OrderID = orders.OrderID,
                            OrderDate = orders.OrderDate,
                        };

            var list = new StringBuilder("Join Customers and Orders\n");
            foreach (var item in query)
            {
                string info = item.CustomerName +"\n"+ item.CustomerRegion +"\n"+ item.OrderID +"\n"+ item.OrderDate + "\n";
                list.AppendLine(info);
            }
            return list.ToString();
        }

        // Exercice 8
        public List<Customers> returnCustomers()
        {
            var query = _context.Customers.Where(x => x.Region == "WA");
            return query.Take(3).ToList();
        }

        // Exercice 9
        public List<Products> returnOrderByNameProducts()
        {
            return _context.Products.OrderBy(x => x.ProductName).ToList();
        }

        // Exercice 10
        public List<Products> returnOrderByUnitInStock()
        {
            var query = from products in _context.Products
                        orderby products.UnitsInStock descending
                        select products;
            return query.ToList();
        }

        // Exercice 11
        public List<Products> returnCategoryID()
        {
            return _context.Products.OrderBy(x => x.CategoryID).ToList();
        }

        // Exercice 12
        public Products returnFirstProduct()
        {
            return _context.Products.First();
        }

        // Exercice 13
        public Object returnOrderByCustomer()
        {
            var query = from customers in _context.Customers
                        join orders in _context.Orders
                        on customers.CustomerID
                        equals orders.CustomerID
                        into count
                        select new
                        {
                            ID = customers.CustomerID,
                            Name = customers.ContactName,
                            QuantityOrders = count.Count()
                        };
            return query.ToList();
        }
    }
}
