using System.Diagnostics;
using System.Text.Json;

public class Functions {
    public static async Task CheckAsync(Func<List<int>, HttpClient, Task> CallApi, List<int> strings, HttpClient client, string Type)
{
    Stopwatch sw = Stopwatch.StartNew();
    await CallApi(strings, client);
    sw.Stop();
    Console.WriteLine(Type + " Time taken: {0}ms", sw.Elapsed.TotalSeconds);
}

public static async Task ParallelFunc(List<int> strings, HttpClient client)
{

    await Parallel.ForEachAsync(strings, new ParallelOptions() { MaxDegreeOfParallelism = 5 }, async (index, ct) =>
{
    var test = await ProcessRepositoriesAsync(client);
});
}

public static async Task SyncFunc(List<int> strings, HttpClient client)
{

    foreach (var item in strings)
    {
        var test = await ProcessRepositoriesAsync(client);
    }
}

public static async Task<List<User>> ProcessRepositoriesAsync(HttpClient client)
{
    await using Stream stream =
        await client.GetStreamAsync("posts");
    var repositories =
        await JsonSerializer.DeserializeAsync<List<User>>(stream);
    return repositories ?? new();
}
}