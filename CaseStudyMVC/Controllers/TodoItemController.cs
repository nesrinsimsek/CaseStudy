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
        public TodoItemController(ITodoItemService todoItemService, IUserService userService)
        {
            _todoItemService = todoItemService;
            _userService = userService;
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
            return RedirectToAction("ListByUser", new { userId = todoItemCreateDto.User_Id});
        }
        public async Task<IActionResult> ListByUser(int userId)
        {
            var response = await _todoItemService.GetByUserAsync<ApiResponse>(userId);
            var todoItems = JsonConvert.DeserializeObject<List<TodoItemDto>>(Convert.ToString(response.Data));
            return View(todoItems);
        }
    }
}
