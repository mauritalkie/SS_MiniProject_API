using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Social_Service_API.Controllers;
using Social_Service_API.DTOs;
using Social_Service_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Service_API.Tests.Controller
{
	public class ControllerTests
	{
        private readonly ITipoUsuarioService _tipoUsuarioService;
        public ControllerTests()
        {
            _tipoUsuarioService = A.Fake<ITipoUsuarioService>();
        }

        [Fact]
        public void TipoUsuarioController_GetTipoUsuario_ReturnList()
        {
            // Arrange
            var controller = new TipoUsuarioController(_tipoUsuarioService);
            var dtos = A.Fake<List<GetTipoUsuarioDto>>();
            A.CallTo(() => _tipoUsuarioService.GetTipoUsuario()).Returns(new List<GetTipoUsuarioDto>
            {
                new GetTipoUsuarioDto(1, "XD", "LOL"),
                new GetTipoUsuarioDto(2, "bruh", "lmao")
            });

            // Act
            var result = controller.GetTipoUsuario();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ActionResult<List<GetTipoUsuarioDto>>>>();
            //result.Should().BeOfType<Task<OkObjectResult>>();
		}

		[Fact]
		public void TipoUsuarioController_UrMom_ReturnString()
		{
			// Arrange
			var controller = new TipoUsuarioController(_tipoUsuarioService);
			A.CallTo(() => _tipoUsuarioService.UrMom()).Returns("ur mom");

			// Act
			var result = controller.UrMom();

			// Assert
			result.Should().NotBeNull();
            result.Should().BeOfType<string>();
			result.Should().Be("ur mom");
		}
	}
}
