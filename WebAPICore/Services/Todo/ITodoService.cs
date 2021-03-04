using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.Services.Todo
{
    public interface ITodoService
    {
        public  Task<List<TodoItem>> GetAllTodosAsync();

        public Task<TodoItem> GetTodoByIdAsync(int Id);

        //TodoItem GetTodoById(int Id);
    }
}
