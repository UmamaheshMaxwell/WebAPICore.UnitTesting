using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.Services.Todo
{
    public class TodoService : ITodoService
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly IHttpClientFactory _httpClientFactory;
        public TodoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<TodoItem>> GetAllTodosAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/todos");
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.SendAsync(request);

            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<List<TodoItem>>(responseString, options);
        }

        public async Task<TodoItem> GetTodoByIdAsync(int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $@"https://jsonplaceholder.typicode.com/todos/{id}");
            var httpClient = _httpClientFactory.CreateClient();

            var response = await httpClient.SendAsync(request);

            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<TodoItem>(responseString, options);
        }

    }
}
