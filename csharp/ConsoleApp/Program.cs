using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Http REST call demo");
            await MakeRestCallAsync("https://bing.com");
        }

        static async Task MakeRestCallAsync(string url)
        {
            try
            {
                using var httpClient = new HttpClient();
                using HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Console.WriteLine($"{url} {(int)response.StatusCode} {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }
    }
}
