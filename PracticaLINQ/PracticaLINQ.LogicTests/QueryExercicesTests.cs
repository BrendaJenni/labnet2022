using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaLINQ.Data;
using PracticaLINQ.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLINQ.Logic.Tests
{
    [TestClass()]
    public class QueryExercicesTests : BaseLogic
    {
        [TestMethod()]
        public void returnCustomersTest()
        {
            //Arrange
            QueryExercices queryExcercice = new QueryExercices();
            //Act
            var aux = queryExcercice.returnCustomers();
            //Assert
            Assert.AreEqual(3, aux.Count());
        }

        [TestMethod()]
        public void returnOrderByNameProductsTest()
        {
            //Arrange
            QueryExercices queryExcercice = new QueryExercices();
            //Act
            var aux = queryExcercice.returnOrderByNameProducts();
            var actual = _context.Products.OrderBy(x => x.ProductID).ToList();
            //Assert, comparo el orden actual por ID con el orden por nombre
            Assert.AreNotSame(actual, aux);
        }

        [TestMethod()]
        public void returnOrderByUnitInStockTest()
        {
            //Arrange
            QueryExercices queryExcercice = new QueryExercices();
            //Act
            var aux = queryExcercice.returnOrderByUnitInStock();
            var actual = _context.Products.OrderBy(x => x.ProductID).ToList();
            //Assert
            Assert.AreNotSame(actual, aux);
        }

        [TestMethod()]
        public void returnFirstProductTest()
        {
            //Arrange
            QueryExercices queryExcercice = new QueryExercices();
            //Act
            var aux = queryExcercice.returnFirstProduct();
            int idFirst = aux.ProductID;
            //Assert, si el product es el primero, id sera 1
            Assert.AreEqual(1, idFirst);
        }

    }
}