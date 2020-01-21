using System;
using System.Net.Http;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Interfaces
{
    public interface ITodoService : IDisposable
    {
        string Url { get; set; }
        HttpClient Client { get;set; }
        Task<TodoResponse> Get(string id);
        Task<TodoResponse> Add(TodoRequest req);
        Task<TodoResponse> Update(TodoRequest req);
        Task<bool> Delete(string id);
    }
}