using AutoMapper;
using CaseApi.Common;
using CaseApi.Dtos;
using CaseBusiness.Abstract;
using CaseDataAccess.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaseApi.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class TodoItemApiController : ControllerBase
    {
        private readonly ITodoItemManager _todoItemManager;
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public TodoItemApiController(ITodoItemManager todoItemManager, IUserManager userManager, IMapper mapper)
        {
            _todoItemManager = todoItemManager;
            _userManager = userManager;
            _mapper = mapper;
            _response = new();
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Add([FromBody] TodoItemCreateDto todoItemCreateDto) 
        {
            var user = await _userManager.GetUserById(todoItemCreateDto.User_Id);
            if (!ModelState.IsValid || (user == null))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var todoItem = _mapper.Map<TodoItem>(todoItemCreateDto);
            await _todoItemManager.AddTodoItem(todoItem);
            _response.StatusCode = HttpStatusCode.Created;
            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, _response);


        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> Update(int id, [FromBody] TodoItemUpdateDto todoItemUpdateDto) 
        {
            var user = await _userManager.GetUserById(todoItemUpdateDto.User_Id);
            if (!ModelState.IsValid || (user == null))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var todoItem = await _todoItemManager.GetTodoItemById(id);
            if (todoItem == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            var updatedTodoItem = _mapper.Map<TodoItem>(todoItemUpdateDto);
            await _todoItemManager.UpdateTodoItem(id, updatedTodoItem);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var todoItem = await _todoItemManager.GetTodoItemById(id);
            if (todoItem == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            await _todoItemManager.DeleteTodoItem(id);
            _response.StatusCode = HttpStatusCode.NoContent;
            return NoContent();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> Get(int id)
        {
            var todoItem = await _todoItemManager.GetTodoItemById(id);
            if (todoItem == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            var todoItemDto = _mapper.Map<TodoItemDto>(todoItem);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = todoItemDto;
            return Ok(_response);

        }


        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetList()
        {

            var todoItems = await _todoItemManager.GetTodoItemList();
            var todoItemDtos = _mapper.Map<List<TodoItemDto>>(todoItems);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = todoItemDtos;
            return Ok(_response);

        }
    }
}
