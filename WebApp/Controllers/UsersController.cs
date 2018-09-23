using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Model.Entities;
using Services;
using WebApp.Core;
using WebApp.Dtos;

namespace WebApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;

		public UsersController(IUserService userService, IMapper mapper)
		{
			_userService = userService;
			_mapper = mapper;
		}

		[HttpPost(Name = "Register")]
		public IActionResult Register([FromBody]RegistrationDto registrationDto)
		{
			if (!ModelState.IsValid)
			{
				var response = new ServerResponse<ModelStateDictionary>();
				response.Data = ModelState;
				return BadRequest(response);
			}
			else
			{
				var user = _mapper.Map<RegistrationDto, User>(registrationDto);
				_userService.Register(user);
				return Ok();
			}
		}

		public IActionResult Login([FromBody] LoginDto loginDto)
		{			
			var user = _mapper.Map<LoginDto, User>(loginDto);
			string token = _userService.Authenticate(user);

			if (token is null)
			{
				
			}
			else
			{
				var response = new ServerResponse<string>();
				response.Data = token;
				return Ok(response);
			}
		}
	}
}