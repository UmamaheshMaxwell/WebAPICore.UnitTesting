using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPICore.Controllers;
using WebAPICore.Services;
using WebAPICore.Test.Services;
using Xunit;

namespace WebAPICore.Test.Controllers
{
    public class ShoppingCartControllerTest
    {
        ShoppingCartController _contoller;
        IShoppingCartService _service;

        public ShoppingCartControllerTest()
        {
            _service = new ShoppingCartServiceFake();
            _contoller = new ShoppingCartController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            var okResult = _contoller.Get();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
