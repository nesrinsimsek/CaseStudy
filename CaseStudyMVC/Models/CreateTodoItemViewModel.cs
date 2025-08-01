using CaseStudyMVC.Dtos;

namespace CaseStudyMVC.Models
{
    public class CreateTodoItemViewModel
    {
        public List<UserDto> Users { get; set; }
        public TodoItemCreateDto TodoItemCreateDto { get; set; }
    }
}
