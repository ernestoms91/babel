using AutoMapper;
using Babel.Filters;
using Babel.Models;
using Babel.Models.Dtos;
using Babel.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;


namespace Babel.Controllers
{
    [ApiController]
    [Route ("api/v1/user")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        [HttpGet("/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUsers()
        {
            var listaUsers = _userService.GetUsers();

            if (listaUsers == null || !listaUsers.Any())
            {
                return NotFound((new
                {
                    status = StatusCodes.Status404NotFound,
                    message = "No users found.",
                    timestamp = DateTime.UtcNow,
                }));
            }

            var listaUsersDtos = _mapper.Map<List<UserDto>>(listaUsers);

            //var listaUsersDtos = new List<UserDto>();
            //foreach (var user in listaUsers)
            //{
            //    listaUsersDtos.Add(_mapper.Map<UserDto>(user));
            //}
            return Ok(new
            {
                status = StatusCodes.Status200OK,
                message = "Users retrieved successfully.", // Mensaje de éxito
                timestamp = DateTime.UtcNow,
                users = listaUsersDtos // Los datos de los usuarios
            });
        }


        [HttpGet("/{id}")]
        [ServiceFilter(typeof(ValidateId))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                //return NotFound($"User with ID {id} not found.");
                return NotFound((new
                {
                    status = StatusCodes.Status404NotFound,
                    message = $"User with ID {id} not found.",
                    timestamp = DateTime.UtcNow,
                }));
            }

            var userDto = _mapper.Map<UserDto>(user);

            return Ok(new
            {
                status = StatusCodes.Status200OK,
                message = "User retrieved successfully.",
                timestamp = DateTime.UtcNow,
                user = userDto 
            });
        }

        [HttpPatch("/change/status/{id}")]
        [ServiceFilter(typeof(ValidateId))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 

        public IActionResult ChangeUserStatus(int id)
        {
            try
            {
              var status =  _userService.ChangeUserStatus(id);
                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = $"User with ID {id} has been {(status ? "enabled" : "disabled")}.",
                    timestamp = DateTime.UtcNow
                });
            }
            catch (KeyNotFoundException ex)
            {
                // Si no se encuentra el usuario, devolver un 404
                return NotFound((new
                {
                    status = StatusCodes.Status404NotFound,
                    message = $"User with ID {id} not found.",
                    timestamp = DateTime.UtcNow,
                }));
            }
        }


        [HttpPost("/new")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult NewUser(int id)
        {
            var user = _userService.GetUser(id);

            


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
