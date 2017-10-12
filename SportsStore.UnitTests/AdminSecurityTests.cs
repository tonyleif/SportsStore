using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminSecurityTests
    {
        [TestMethod]
        public void Can_Login_With_Valid_Credentials()
        {
            //Arrange
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);
            LoginViewModel model = new LoginViewModel
            {
                UserName = "admin",
                Password = "secret"
            };
            AccoutController target = new AccoutController(mock.Object);
            //Act
            ActionResult result = target.Login(model, "/MyURL");
            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyURL", ((RedirectResult)result).Url);
        }
        [TestMethod]
        public void Cannot_Login_With_Invalid_Credentials()
        {
            //Arrange
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("badUser", "badPass")).Returns(false);
            LoginViewModel model = new LoginViewModel
            {
                UserName = "badUser",
                Password = "badPass"
            };
            AccoutController target = new AccoutController(mock.Object);
            //Act
            ActionResult result = target.Login(model, "/MyURL");
            //Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
