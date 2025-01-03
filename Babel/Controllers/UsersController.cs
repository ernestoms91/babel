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
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IRoleService roleService, IUserRoleService userRoleService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        [HttpGet("/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUsers() // Método ahora asincrónico
        {
            var result = await _userService.GetUsersAsync(); // Llamada asincrónica al servicio

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
                    error = error.Description
                }));
        }

        [HttpGet("/{id}")]
        [ServiceFilter(typeof(ValidateId))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser([FromRoute] int id) // Método ahora asincrónico
        {
            var result = await _userService.GetUserAsync(id); // Llamada asincrónica al servicio

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
        public async Task<IActionResult> ChangeUserStatus([FromRoute] int id) // Método ahora asincrónico
        {
            var result = await _userService.ChangeUserStatusAsync(id); // Llamada asincrónica al servicio

            return result.Match(
                onSuccess: user => Ok(new
                {
                    title = "User status has been updated",
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
        public async Task<IActionResult> NewUser([FromBody] NewUserDto newUsuarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Llamada asincrónica al servicio CreateUserAsync
            var result = await _userRoleService.CreateAsync(newUsuarioDto);

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

        [HttpPut("/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Llamada asincrónica al servicio CreateUserAsync
            var result = await _userRoleService.UpdateAsync(updateUserDto);

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
