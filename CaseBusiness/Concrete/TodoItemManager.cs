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

        public async Task DeleteTodoItem(int id)
        {
            await _todoItemDal.Delete(t => t.Id == id);
        }

        public async Task<TodoItem> GetTodoItemById(int id)
        {
            return await _todoItemDal.Get(t => t.Id == id);
        }

        public async Task<List<TodoItem>> GetTodoItemList()
        {
            return await _todoItemDal.GetList();
        }

        public async Task<List<TodoItem>> GetTodoItemListByUser(int userId)
        {
            return await _todoItemDal.GetList(t => t.User_Id == userId);
        }

        public async Task UpdateTodoItem(int id, TodoItem updatedItem)
        {
            await _todoItemDal.Update(t => t.Id == id, updatedItem);
        }
    }
}
