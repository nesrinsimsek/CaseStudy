using AutoMapper;
using CaseApi.Dtos;
using CaseBusiness.Abstract;
using CaseBusiness.Concrete;
using CaseDataAccess.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaseApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public UserApiController(IUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _userManager.GetUserById(id);
            if (user == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }
            var userDto = _mapper.Map<UserDto>(user);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = userDto;
            return Ok(_response);

        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {

            var users = await _userManager.GetUserList();
            var userDtos = _mapper.Map<List<UserDto>>(users);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = userDtos;
            return Ok(_response);

        }
    }
}
