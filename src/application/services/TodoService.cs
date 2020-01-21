using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Models;
using Newtonsoft.Json;

namespace Application.Services
{
    public class TodoService : ITodoService
    {
        public string Url { get; set; }
        public HttpClient Client {get;set;}

        public async Task<TodoResponse> Get(string id)
        {
            try 
            {
                var httpResponse = await Client.GetAsync($"{Url}/{id}");
                var response = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TodoResponse>(response);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public async Task<TodoResponse> Add(TodoRequest req)
        {
            var request = JsonConvert.SerializeObject(req);
            var httpResponse = await Client.PostAsync(Url,
                new StringContent(request, Encoding.Default, "application/json"));
            var response = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TodoResponse>(response);
        }

        public async Task<TodoResponse> Update(TodoRequest req)
        {
            var request = JsonConvert.SerializeObject(req);
            var httpResponse = await Client.PutAsync(Url,
                new StringContent(request, Encoding.Default, "application/json"));
            var response = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TodoResponse>(response);
        }

        public async Task<bool> Delete(string id)
        {
            var httpResponse = await Client.DeleteAsync($"{Url}/{id}");
            var response = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(response);
        }

        public void Dispose()
        {
            Client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}