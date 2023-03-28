using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models
{
    public class Album
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Fetch()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                string responseBody = await client.GetStringAsync("https://dummyjson.com/products/1");

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }


    }
}