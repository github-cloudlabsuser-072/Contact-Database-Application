using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewWithUserList()
        {
            // Arrange
            var controller = new UserController();
            var expectedUserList = new List<User>()
            {
                new User() { Id = 1, Name = "John", Email = "john@example.com" },
                new User() { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            UserController.userlist = expectedUserList;

            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model as List<User>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUserList, model);
        }

        [TestMethod]
        public void Details_ExistingUserId_ReturnsViewWithUserDetails()
        {
            // Arrange
            var controller = new UserController();
            var expectedUser = new User() { Id = 1, Name = "John", Email = "john@example.com" };
            UserController.userlist = new List<User>() { expectedUser };

            // Act
            var result = controller.Details(1) as ViewResult;
            var model = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser, model);
        }

        [TestMethod]
        public void Details_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User>();

            // Act
            var result = controller.Details(1) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_ReturnsView()
        {
            // Arrange
            var controller = new UserController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var user = new User() { Id = 1, Name = "John", Email = "john@example.com" };

            // Act
            var result = controller.Create(user) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_ExistingUserId_ReturnsViewWithUserDetails()
        {
            // Arrange
            var controller = new UserController();
            var expectedUser = new User() { Id = 1, Name = "John", Email = "john@example.com" };
            UserController.userlist = new List<User>() { expectedUser };

            // Act
            var result = controller.Edit(1) as ViewResult;
            var model = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser, model);
        }

        [TestMethod]
        public void Edit_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User>();

            // Act
            var result = controller.Edit(1) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var existingUser = new User() { Id = 1, Name = "John", Email = "john@example.com" };
            UserController.userlist = new List<User>() { existingUser };
            var updatedUser = new User() { Id = 1, Name = "Jane", Email = "jane@example.com" };

            // Act
            var result = controller.Edit(1, updatedUser) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(updatedUser.Name, existingUser.Name);
            Assert.AreEqual(updatedUser.Email, existingUser.Email);
        }

        [TestMethod]
        public void Delete_ExistingUserId_ReturnsViewWithUserDetails()
        {
            // Arrange
            var controller = new UserController();
            var expectedUser = new User() { Id = 1, Name = "John", Email = "john@example.com" };
            UserController.userlist = new List<User>() { expectedUser };

            // Act
            var result = controller.Delete(1) as ViewResult;
            var model = result.Model as User;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser, model);
        }

        [TestMethod]
        public void Delete_NonExistingUserId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            UserController.userlist = new List<User>();

            // Act
            var result = controller.Delete(1) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete_ValidUser_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var existingUser = new User() { Id = 1, Name = "John", Email = "john@example.com" };
            UserController.userlist = new List<User>() { existingUser };

            // Act
            var result = controller.Delete(1, null) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.IsFalse(UserController.userlist.Contains(existingUser));
        }
    }
}
