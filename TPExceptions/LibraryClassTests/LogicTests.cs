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
    public class LogicTests
    {
        [ExpectedException(typeof(PersonalException))]
        [TestMethod()]
        public void ThrowPersonalExceptionTest()
        {
            //arrange
            Logic logic = new Logic();

            //act
            logic.ThrowPersonalException();

        }
    }
}