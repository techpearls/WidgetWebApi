using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using WebApplication3.Models;

namespace WebApplication3.Controllers.Tests
{
    [TestClass()]
    public class TestHomeController
    {
        [TestMethod]
        public void GetAllWidgets_ShouldReturnAllWidgets()
        {
            var testWidgets = GetTestWidgets();
            var controller = new HomeController(testWidgets);

            var result = controller.GetAll() as JsonResult<List<Widget>>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
        }

        [TestMethod]
        public void GetWidget_ShouldReturnCorrectWidget()
        {
            var testWidgets = GetTestWidgets();
            var controller = new HomeController(testWidgets);

            var result = controller.Get(4) as JsonResult<Widget>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testWidgets[3].Name, result.Content.Name);
        }

        [TestMethod]
        public void GetWidget_ShouldNotFindWidget()
        {
            var controller = new HomeController(GetTestWidgets());

            var result = controller.Get(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Widget> GetTestWidgets()
        {
            var testWidgets = new List<Widget>();
            testWidgets.Add(new Widget { Id = 1, Name = "Demo1", Description = "Desc1", Price = 1 });
            testWidgets.Add(new Widget { Id = 2, Name = "Demo2", Description = "Desc2", Price = 3.75 });
            testWidgets.Add(new Widget { Id = 3, Name = "Demo3", Description = "Desc3", Price = 16.99 });
            testWidgets.Add(new Widget { Id = 4, Name = "Demo4", Description = "Desc4", Price = 11.00 });

            return testWidgets;
        }
    }
}