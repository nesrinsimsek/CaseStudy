using AutoMapper;
using CaseApi.Dtos;
using CaseBusiness.Abstract;
using CaseDataAccess.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemApiController : ControllerBase
    {
        private readonly ITodoItemManager _todoItemManager;
        private readonly IMapper _mapper;
        protected ApiResponse _response;

        public TodoItemApiController(ITodoItemManager todoItemManager, IMapper mapper)
        {
            _todoItemManager = todoItemManager;
            _mapper = mapper;
            _response = new();
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Add([FromBody] TodoItemCreateDto todoItemCreateDto) 
        {
            TodoItem todoItem = _mapper.Map<TodoItem>(todoItemCreateDto);
            await _todoItemManager.AddTodoItem(todoItem);
            _response.StatusCode = HttpStatusCode.Created;
            return CreatedAtAction(nameof(Get), new { todoItemId = todoItem.Id }, _response);


        }

        [HttpPut("{todoItemId}")]
        public async Task<ActionResult<ApiResponse>> Update(int todoItemId, [FromBody] TodoItemUpdateDto todoItemUpdateDto) //bunu dto yap
        {
            TodoItem todoItem = _mapper.Map<TodoItem>(todoItemUpdateDto);
            await _todoItemManager.UpdateTodoItem(todoItem);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);

        }


        [HttpDelete("{todoItemId}")]
        public async Task<ActionResult> Delete(int todoItemId) 
        {
            await _todoItemManager.DeleteTodoItem(todoItemId);
            _response.StatusCode = HttpStatusCode.NoContent;
            return NoContent();

        }

        [HttpGet("ById/{todoItemId}")]
        public async Task<ActionResult<TodoItemDto>> Get(int todoItemId)
        {
            var todoItem = await _todoItemManager.GetTodoItemById(todoItemId);
            var todoItemDto = _mapper.Map<TodoItemDto>(todoItem);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = todoItemDto;
            return Ok(_response);

        }

        [HttpGet("ByUser/{userId}")]
        public async Task<ActionResult<ApiResponse>> GetListByUser(int userId)
        {
            var todoItems = await _todoItemManager.GetTodoItemListByUser(userId);
            var todoItemDtos = _mapper.Map<List<TodoItemDto>>(todoItems);
            _response.StatusCode = HttpStatusCode.OK;
            _response.Data = todoItemDtos;
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
