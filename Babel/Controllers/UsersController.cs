using AutoMapper;
using Babel.Extensions;
using Babel.Filters;
using Babel.Models;
using Babel.Models.Dtos;
using Babel.Service;
using Babel.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;


namespace Babel.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet("/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUsers()
        {
            var result = _userService.GetUsers();

            // Usa el método Match para manejar el resultado
            return result.Match(
                onSuccess: users => Ok(new
                {
                    title = "Users retrieved successfully.",  
                    status = 200,
                    data = users  
                }),
                onFailure: error => NotFound(new
                {
                    title = "No users found.",
                    status = 404,
                    error = error.Description  // Detalle del error en la respuesta
                }));

        }


        [HttpGet("/{id}")]
        [ServiceFilter(typeof(ValidateId))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUser([FromRoute] int id)
        {
            var result = _userService.GetUser(id);

            // Usa el método Match para manejar el resultado
            return result.Match(
                onSuccess: user => Ok(new
                {
                    title = "User retrieved successfully.",
                    status = 200,
                    data = user
                }),
                onFailure: error => NotFound(new
                {
                    title = "No user found.",
                    status = 404,
                    error = error.Description
                }));

        }

        [HttpPatch("/change/status/{id}")]
        [ServiceFilter(typeof(ValidateId))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult ChangeUserStatus([FromRoute] int id)
        {
           var result = _userService.ChangeUserStatus(id);

            return result.Match(
               onSuccess: user => Ok(new
               {
                   title = "User status has been changed",
                   status = 200,
                   data = user
               }),
               onFailure: error => NotFound(new
               {
                   title = "No user found.",
                   status = 404,
                   error = error.Description
               }));

        }


        [HttpPost("/new")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("new-user")]
        public async Task<IActionResult> NewUser([FromBody] NewUserDto newUsuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Llama al método CreateUserAsync de manera asincrónica
            var result = await _userService.CreateUserAsync(newUsuarioDto);

            return result.Match(
                onSuccess: user => Ok(new
                {
                    title = "User has been created",
                    status = 200,
                    data = user
                }),
                onFailure: error => BadRequest(new
                {
                    title = "Invalid User Request.",
                    status = 400,
                    error = error.Description
                }));
        }
    }

}
