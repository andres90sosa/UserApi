using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserApi.DTOs;
using UserApi.Entities;
using UserApi.Services;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userService.GetAllUsersAsync();
            return Ok(mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Usuario no encontrado.");
            }

            var userDto = mapper.Map<UserDto>(user);
            
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(userCreateDto);
            var createdUser = await userService.AddUserAsync(user);
            var userDto = mapper.Map<UserDto>(createdUser);

            return Created("/", userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserCreateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await userService.GetUserByIdAsync(id);

            if (existingUser == null)
            {
                return NotFound($"Usuario no encontrado.");
            }

            mapper.Map(userDto, existingUser);
            await userService.UpdateUserAsync(existingUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Usuario no encontrado.");
            }

            await userService.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
