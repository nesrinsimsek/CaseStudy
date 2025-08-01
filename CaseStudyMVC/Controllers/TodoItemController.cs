using AutoMapper;
using CaseStudyMVC.Common;
using CaseStudyMVC.Dtos;
using CaseStudyMVC.Models;
using CaseStudyMVC.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CaseStudyMVC.Controllers
{
    public class TodoItemController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public TodoItemController(ITodoItemService todoItemService, IUserService userService, IMapper mapper)
        {
            _todoItemService = todoItemService;
            _userService = userService;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var response = await _userService.GetAllAsync<ApiResponse>();
            var createTodoItemViewModel = new CreateTodoItemViewModel
            {
                TodoItemCreateDto = new TodoItemCreateDto(),
                Users = JsonConvert.DeserializeObject<List<UserDto>>(Convert.ToString(response.Data))
            };
            return View(createTodoItemViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoItemCreateDto todoItemCreateDto)
        {
            await _todoItemService.CreateAsync<ApiResponse>(todoItemCreateDto);
            return RedirectToAction("Index", "TodoItem");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responseForTodoItem = await _todoItemService.GetAllAsync<ApiResponse>();
            var responseForUser = await _userService.GetAllAsync<ApiResponse>();
            var displayTodoItemViewModel = new DisplayTodoItemViewModel
            {
                TodoItems = JsonConvert.DeserializeObject<List<TodoItemDto>>(Convert.ToString(responseForTodoItem.Data)),
                Users = JsonConvert.DeserializeObject<List<UserDto>>(Convert.ToString(responseForUser.Data))
            };
            
            return View(displayTodoItemViewModel);
        }

        public async Task<IActionResult> DeleteItem(int id)
        {
            await _todoItemService.DeleteAsync<ApiResponse>(id);
            return RedirectToAction("Index", "TodoItem");

        }

        
        public async Task<IActionResult> MarkAsCompleted(int id)
        {
            var response = await _todoItemService.GetAsync<ApiResponse>(id);
            var updatedItemDto = JsonConvert.DeserializeObject<TodoItemDto>(Convert.ToString(response.Data));
            updatedItemDto.IsCompleted = true;
            var todoItemUpdateDto = _mapper.Map<TodoItemUpdateDto>(updatedItemDto);
            await _todoItemService.UpdateAsync<ApiResponse>(id, todoItemUpdateDto);
            return RedirectToAction("Index", "TodoItem");

        }

    }
}
