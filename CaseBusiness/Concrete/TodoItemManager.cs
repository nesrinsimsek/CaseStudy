using CaseBusiness.Abstract;
using CaseDataAccess.Dals.Abstract;
using CaseDataAccess.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseBusiness.Concrete
{
    public class TodoItemManager : ITodoItemManager
    {
        private readonly ITodoItemDal _todoItemDal;

        public TodoItemManager(ITodoItemDal todoItemDal)
        {
            _todoItemDal = todoItemDal;
        }

        public async Task AddTodoItem(TodoItem todoItem)
        {
            await _todoItemDal.Add(todoItem);
        }

        public async Task DeleteTodoItem(int todoItemId)
        {
            await _todoItemDal.Delete(t => t.Id == todoItemId);
        }

        public async Task<TodoItem> GetTodoItemById(int todoItemId)
        {
            return await _todoItemDal.Get(t => t.Id == todoItemId);
        }

        public async Task<List<TodoItem>> GetTodoItemList()
        {
            return await _todoItemDal.GetList();
        }

        public async Task<List<TodoItem>> GetTodoItemListByUser(int userId)
        {
            return await _todoItemDal.GetList(t => t.User_Id == userId);
        }

        public async Task UpdateTodoItem(TodoItem todoItem)
        {
            await _todoItemDal.Update(todoItem);
        }
    }
}
