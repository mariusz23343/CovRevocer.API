using Application.Posts;
using CovRecover.API;
using CovRecover.API.Controllers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CovRecoverTestProject
{
    public class PostControllerTests
    {
        private readonly Mock<IMediator> _mediator = new Mock<IMediator>();
        private readonly Mock<UserManager<AppUser>> _userManager = new Mock<UserManager<AppUser>>();
        private readonly Mock<SignInManager<AppUser>> _singInManager = new Mock<SignInManager<AppUser>>();
        private readonly Mock<TokenService> _tokenService = new Mock<TokenService>();
        [Fact]
        public async Task ControllerTest_Publish_ShouldReturnOk()
        {
            //arrange
            _mediator.Setup(p => p.Send(It.IsAny<Publish.Command>(), It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<Unit>());
            _userManager.Setup(p => p.)

            var sut = new PostsController();

            var testGuid = new Guid();
            //act
            var result = await sut.Publish(testGuid);

            //assert
            result.
            
        }
    }
}
