namespace ConsoleApp
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            var start = Stopwatch.StartNew();

            for (var i = 0; i < 5; i++)
            {
                await MakeRestCallAsync("https://bing.com");
            }

            start.Stop();
            var elapsed = start.Elapsed;

            Console.WriteLine($"Total Elapsed time {elapsed.TotalMilliseconds}ms");
        }

        static async Task MakeRestCallAsync(string url)
        {
            try
            {
                var start = Stopwatch.StartNew();

                using var httpClient = new HttpClient();
                using HttpResponseMessage resp = await httpClient.GetAsync(url);
                resp.EnsureSuccessStatusCode();

                start.Stop();
                var elapsed = start.Elapsed;
                Console.WriteLine($"{url} {(int)resp.StatusCode} {resp.StatusCode} Elapsed time: {elapsed.TotalMilliseconds}ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }
        }
    }
}
