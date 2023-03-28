using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.ViewModels;

public class TodoProcessor
{
    public static async Task<TodoModel> LoadTodos()
    {
        const string uri = "https://dummyjson.com/todos/1";
        using (HttpResponseMessage response = await ExternalApiCall.ApiClient.GetAsync(uri))
        {
            if (response.IsSuccessStatusCode)
            {
                TodoModel product = await response.Content.ReadFromJsonAsync<TodoModel>();
                return product;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}