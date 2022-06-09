using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab.EF.Entities;

namespace Lab.EF.Logic.Tests
{
    [TestClass()]
    public class CategoriesLogicTests
    {
        [TestMethod()]
        public void UpdateTest()
        {
            //Arrange
            CategoriesLogic categoryLogic = new CategoriesLogic();

            Categories originalCategory = new Categories()
            {
                CategoryName = "TestName",
                Description= "TestDescription"
            };
            string originalDescription = originalCategory.Description;
            string originalCategoryName = originalCategory.CategoryName;

            categoryLogic.Add(originalCategory);

            int id = originalCategory.CategoryID;
            //Act
            categoryLogic.Update(new Categories()
            {
                CategoryID = id,
                CategoryName = "ModTestName",
                Description = "ModTestDescription"
            });
            var modifiedCategory = categoryLogic.GetAll().Single(x=>x.CategoryID == id);
            //Assert
            Assert.AreNotEqual(originalCategoryName,modifiedCategory.CategoryName);
            Assert.AreNotEqual(originalDescription, modifiedCategory.Description);
        }
    }
}