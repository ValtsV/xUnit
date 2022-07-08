using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDDProject.Controllers;
using TDDProject.Models;
using TDDProject.Services;
using TDDProjectTest.Fixtures;

namespace TDDProjectTest.Systems.Controllers
{
    public class UnitTest1
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            //sut = system under test
            var sut = new UsersController(mockUsersService.Object);

            var result = (OkObjectResult) await sut.GetUsers();

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUserService_ExactlyOne()
        {
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());


            var sut = new UsersController(mockUsersService.Object);

            var result = await sut.GetUsers();

            mockUsersService.Verify(service => service.GetAllUsers(), Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            var sut = new UsersController(mockUsersService.Object);

            var result = await sut.GetUsers();

            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult) result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task Get_OnNoUserFound_Return404()
        {
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UsersController(mockUsersService.Object);

            var result = await sut.GetUsers();

            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Get_OnNoUsersFound_ReturnsStatusCode200()
        {
            var mockUsersService = new Mock<IUsersService>();
            mockUsersService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            //sut = system under test
            var sut = new UsersController(mockUsersService.Object);

            var result = await sut.GetUsers();

            result.Should().BeOfType<NotFoundResult>();
            var notFoundResult = (NotFoundResult)result;
            notFoundResult.StatusCode.Should().Be(404);
        }
    }
}