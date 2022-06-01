using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClass.Tests
{
    [TestClass()]
    public class MetodoExtensionsTests
    {
        [DataRow(10, 5)]
        [DataRow(6, 3)]
        [TestMethod()]
        public void DividirTest(int dividendo, int divisor)
        {
            //Arrange
            int resultadoEsperado = 2;

            //Act
            int resultado = dividendo.Dividir(divisor);

            //Assert
            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
}