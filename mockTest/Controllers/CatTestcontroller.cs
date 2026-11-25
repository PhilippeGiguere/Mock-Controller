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
        [TestMethod]
        public void DeleteCatCute()
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
                CuteLevel = Cuteness.BarelyOk
            };
            serviceMock.Setup(s => s.Get(c.Id)).Returns(c);
            serviceMock.Setup(s => s.Delete(c.Id)).Returns(c);
            controllerMock.Setup(controller => controller.UserId).Returns("111");

            var result = controllerMock.Object.DeleteCat(c.Id).Result as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreSame(c, result.Value);
        }
        [TestMethod]
        public void DeleteCatBadRequest()
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
            serviceMock.Setup(s => s.Get(c.Id)).Returns(c);
            controllerMock.Setup(controller => controller.UserId).Returns(catOwner.Id);

            var result = controllerMock.Object.DeleteCat(c.Id).Result as BadRequestObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Cat is too cute", result.Value);

        }
        [TestMethod]
        public void ChiffreChanceuxTest()
        {
            Mock<CatsService> serviceMock = new Mock<CatsService>();
            Mock<CatsController> controllerMock = new Mock<CatsController>(serviceMock.Object)
            {
                CallBase = true
            };
            serviceMock.Setup(s => s.ChiffreChanceux()).Returns(42);
            var result = controllerMock.Object.ChiffreChanceux().Result as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(42, result.Value);
        }





    }
}
