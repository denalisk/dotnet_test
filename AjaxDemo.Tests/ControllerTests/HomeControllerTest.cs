using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AjaxDemo.Controllers;
using AjaxDemo.Models;
using Xunit;
using Moq;
using System.Linq;
using AjaxDemo.Models.Repositories;

namespace AjaxDemo.Tests.ControllerTests
{
    public class HomeControllerTest
    {
        EFWidgetRepository db = new EFWidgetRepository(new AjaxDemoDbContext(EFWidgetRepository.ContextOptions));

        Mock<IWidgetRepository> mock = new Mock<IWidgetRepository>();
        private void DbSetup()
        {
            mock.Setup(m => m.Widgets).Returns(new Widget[]
                    {
            new Widget {Id = 1, Name = "Wat", Description = "Wash the dog" },
            new Widget {Id = 2, Name = "Wizard", Description = "Wash the dog" },
            new Widget {Id = 3, Name = "Hagrid", Description = "Sweep the floor" }
                    }.AsQueryable());
        }

        [Fact]
        public void Mock_ConfirmEntry_Test()
        {
            //Arrange
            DbSetup();
            HomeController controller = new HomeController(mock.Object);
            Widget testWidget = new Widget { Description = "It's a bonus test widget", Name = "TestWidget", Id = 1 };

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Widget>;

            // Assert
            Assert.Contains<Widget>(testWidget, collection);
        }

        [Fact]
        public void Post_MethodAddsWidget_Test()
        {
            //Arrange
            HomeController controller = new HomeController();
            Widget testWidget = new Widget { Name = "Thing1", Description = "It's a thing what more do you want" };

            // Act
            controller.Create(testWidget);
            ViewResult indexView = new HomeController(mock.Object).Index() as ViewResult;

            //Compare
        }

        [Fact]
        public void DB_CreateNewEntry_Test()
        {
            //arrange
            HomeController controller = new HomeController(db);
            Widget testWidget = new Widget();
            testWidget.Description = "Test Widget";
            testWidget.Name = "Widget";

            //act
            controller.Create(testWidget);
            var collection = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Widget>;

            //assert
            Assert.Contains<Widget>(testWidget, collection);
        }
    }
}
