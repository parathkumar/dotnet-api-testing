using System.Net.Http.Headers;
using HttpClient client = new();

client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


Console.Write("Enter range:");
var range = Convert.ToInt32(Console.ReadLine());
List<int> strings = Enumerable.Range(0, range).ToList();

Functions.CheckAsync(Functions.ParallelFunc, strings, client, "Parallel").Wait();
Functions.CheckAsync(Functions.SyncFunc, strings, client, "Sync").Wait();
