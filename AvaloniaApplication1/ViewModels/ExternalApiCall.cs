using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Input;
using ReactiveUI;

namespace AvaloniaApplication1.ViewModels

{
    public class ExternalApiCall
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
       //     ApiClient.BaseAddress=new Uri()
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
    }
}