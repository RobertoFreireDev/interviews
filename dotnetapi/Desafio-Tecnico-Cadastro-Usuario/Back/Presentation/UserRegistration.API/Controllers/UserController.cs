using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using UserRegistration.Application.DataContracts.Requests;
using UserRegistration.Application.DataContracts.Responses;
using System.Threading.Tasks;
using UserRegistration.Domain.Services.User;
using AutoMapper;
using UserRegistration.Domain.Dtos.User;

namespace UserRegistration.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {        
        public IUserService UserService { get; }
        public IMapper Mapper { get; }

        public UserController(IMapper mapper, 
            IUserService userService)
        {
            Mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            UserService = userService ??
                throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<UserDto> result = await UserService.GetAllAsync();
                return Ok(Mapper.Map<IEnumerable<UserResponse>>(result));              
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("getusersbyfilter")]
        public async Task<IActionResult> GetUsersByFilter(UsersFilterRequest userfilter)
        {
            try
            {            
                var result = await UserService.GetUsersByFilterAsync(Mapper.Map<UserFilterDto>(userfilter));
                return Ok(Mapper.Map<IEnumerable<UserResponse>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("toggleactivation")]
        public async Task<IActionResult> ToggleActivation([FromBody] UserToggleActivationRequest request)
        {
            try
            {
                var result = await UserService.ToggleActivationInUserAsync(Mapper.Map<UserToggleActivationDto>(request));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserRequest user)
        {
            try
            {
                return Ok(await UserService.AddUserAsync(Mapper.Map<UserDto>(user)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] UserRequest user)
        {
            try
            {
                return Ok(await UserService.EditUserAsync(Mapper.Map<UserDto>(user)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            try
            {
                return Ok(await UserService.DeleteUserAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
