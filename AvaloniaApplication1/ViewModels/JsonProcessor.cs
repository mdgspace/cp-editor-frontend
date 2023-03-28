using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.ViewModels;

public class JsonProcessor
{
    public static async Task<CodeforcesModel> LoadJson()
    {
        const string uri = "http://127.0.0.1:5000/scrape/1729-A";
        using (HttpResponseMessage response = await ExternalApiCall.ApiClient.GetAsync(uri))
        {
            if (response.IsSuccessStatusCode)
            {
                CodeforcesModel product = await response.Content.ReadFromJsonAsync<CodeforcesModel>();
                return product;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}