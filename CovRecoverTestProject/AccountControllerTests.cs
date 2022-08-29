using CovRecover.API;
using CovRecover.API.Controllers;
using Domain;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CovRecoverTestProject
{
    public class AccountControllerTests
    {
        private readonly Mock<UserManager<AppUser>> _userManager = new Mock<UserManager<AppUser>>();
        private readonly Mock<SignInManager<AppUser>> _singInManager = new Mock<SignInManager<AppUser>>();
        private readonly Mock<TokenService> _tokenService = new Mock<TokenService>();

        [Fact]
        public void Test1()
        {
            
        }
    }
}
