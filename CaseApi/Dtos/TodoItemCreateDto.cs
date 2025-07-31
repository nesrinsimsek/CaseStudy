namespace CaseApi.Dtos
{
    public class TodoItemCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public int User_Id { get; set; }
    }
}
