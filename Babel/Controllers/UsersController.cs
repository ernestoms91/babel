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
        public IActionResult NewUser([FromBody] NewUserDto newUsuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var role = _roleService.GetRole(newUsuarioDto.Role);

            if (role == null)
            {
                return BadRequest((new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = $"The {role.RoleName} role does not exist.",
                    timestamp = DateTime.UtcNow,
                }));
            }



            return Ok(new
            {
                status = StatusCodes.Status200OK,
                message = "User retrieved successfully.",
                timestamp = DateTime.UtcNow,
                //user = userDto
            });
        }






    }
}
