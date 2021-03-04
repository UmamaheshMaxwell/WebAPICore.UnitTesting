using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPICore.Models;
using WebAPICore.Services.Todo;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly ITodoService _service;
        private readonly IHttpClientFactory _httpClientFactory;
        public TodoController(ITodoService service, IHttpClientFactory httpClientFactory)
        {
            _service = service;
            _httpClientFactory = httpClientFactory;
        }

        // GET api/todo
        public async Task<IActionResult> Get()
        {
            var todos = await _service.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}", Name ="Get")]
        public async Task<IActionResult> Get(int id)
        {
            var todo = await _service.GetTodoByIdAsync(id);
            return Ok(todo);
        }

    }
}
