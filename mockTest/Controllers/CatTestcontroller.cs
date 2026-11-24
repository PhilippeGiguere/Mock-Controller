using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using mock.depart.Controllers;
using mock.depart.Models;
using mock.depart.Services;
using Moq;

namespace mockTest.Controllers
{
    [TestClass]
    public class CatTestcontroller
    {
        [TestMethod]
        public void DeleteCatNotFound()
        {
            Mock<CatsService> serviceMock = new Mock<CatsService>();
            serviceMock.Setup(s => s.Get(It.IsAny<int>())).Returns((Cat?)null);
            var controllerMock = new Mock<CatsController>(serviceMock.Object)
            {
                CallBase = true
            };
            controllerMock.Setup(c => c.UserId).Returns("1");
            var actionresult = controllerMock.Object.DeleteCat(0);
            var result = actionresult.Result as NotFoundResult;
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void Deletewrongcat()
        {
            Mock<CatsService> serviceMock = new Mock<CatsService>();
           Mock<CatsController> controllerMock = new Mock<CatsController>(serviceMock.Object)
            {
                CallBase = true
            };
            CatOwner catOwner = new CatOwner
            {
                Id = "111"
            };
            Cat c = new Cat()
            {
                Id = 1,
                Name = "Tite Dali",
                CatOwner = catOwner,
                CuteLevel = Cuteness.Amazing
            };
            serviceMock.Setup(s => s.Get(It.IsAny<int>())).Returns(c);
            controllerMock.Setup(c => c.UserId).Returns("1");
            var actionresult = controllerMock.Object.DeleteCat(0);
            var result = actionresult.Result as BadRequestObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Cat is not yours", result.Value);
        }



    }
}
