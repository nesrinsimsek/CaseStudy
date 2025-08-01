using CaseStudyMVC.Dtos;

namespace CaseStudyMVC.Models
{
    public class DisplayTodoItemViewModel
    {
        public List<UserDto> Users { get; set; }
        public List<TodoItemDto> TodoItems { get; set; }
    }
}
