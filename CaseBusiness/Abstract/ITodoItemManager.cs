using CaseDataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseBusiness.Abstract
{
    public interface ITodoItemManager
    {
        Task AddTodoItem(TodoItem todoItem);
        Task UpdateTodoItem(int id, TodoItem todoItem);
        Task DeleteTodoItem(int todoItemId);
        Task<TodoItem> GetTodoItemById(int todoItemId);
        Task<List<TodoItem>> GetTodoItemList();
        Task<List<TodoItem>> GetTodoItemListByUser(int userId);
    }
}
