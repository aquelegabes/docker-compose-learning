using System.Net.Http;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Components;

namespace web.Pages.Todo
{
    public class TodoGetBase : ComponentBase
    {
        [Inject]
        protected ITodoService TodoService { get;set; }
        [Inject]
        private IHttpClientFactory Http {get;set;}
        public string Id { get;set; }
        public TodoRequest Request { get;set; } = new TodoRequest();
        protected TodoResponse Response { get;set; } = new TodoResponse();

        private const string Url = "http://api:5000/todo";

        public async Task Get()
        {
            TodoService.Url = Url;
            TodoService.Client = Http.CreateClient();
            Response = await TodoService.Get(Id);
        }

        public async Task NewTodo()
        {
            TodoService.Url = Url;
            TodoService.Client = Http.CreateClient();
            Response = await TodoService.Add(Request);
        }
    }
}