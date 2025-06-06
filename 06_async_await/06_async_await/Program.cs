
// 1. async

// 2. возврат
// Task
// Task<T>
// void         :-(((
// ValueTask
// ValueTask<T>
// IAsyncEnumerable<T>
// IAsyncEnumerator<T>
// ...

// 3. await

// 4. ...Async




//async Task MethodAsync()
//{
//    Console.WriteLine("Start");

//    Task t = new Task(() => Thread.Sleep(1000));
//    t.Start();

//    Console.WriteLine("ONE");

//    // t.Wait();
//    await t;

//    Console.WriteLine("End");
//}


//_ = MethodAsync();

//Console.WriteLine("MAIN");

//Console.ReadLine();



// -- отмена


//async Task DownloadAsync(string url, CancellationToken token)
//{
//    //
//    //
//    HttpClient client = new HttpClient();
//    string content = await client.GetStringAsync(url, token);
//    //
//    //
//    Console.WriteLine(content);
//}

//var cts = new CancellationTokenSource();
//_ = DownloadAsync("https://wikipedia.org", cts.Token);
//// cts.Cancel();
////
//Console.ReadLine();



// ------- EX_1

//async Task<string> FetchDataAsync(string url)
//{
//    using var httpClient = new HttpClient();

//	try
//	{
//		Task<string> responseTask = httpClient.GetStringAsync(url);

//		// return responseTask.Result;

//		//responseTask.Wait();
//		//return responseTask.Result;

//		return await responseTask;
//    }
//	catch (Exception ex)
//	{
//        Console.WriteLine($"Ошибка запроса: {ex.Message}");
//		return string.Empty;
//	}
//}

//string content = await FetchDataAsync("http://wikipedia.org");
//Console.WriteLine(content);


// ------- EX_2

//async Task<string> FetchDataAsync(string url, CancellationToken token)
//{
//	using var httpClient = new HttpClient();

//	try
//	{
//		Task<string> responseTask = httpClient.GetStringAsync(url, token);

//		return await responseTask;
//	}
//	catch (Exception ex)
//	{
//		Console.WriteLine($"Ошибка запроса: {ex.Message}");
//		return string.Empty;
//	}
//}
//async Task<Dictionary<string, string>> FetchMultipleDataAsync(IEnumerable<string> urls, CancellationToken token)
//{
//	var tasks = new Dictionary<string, Task<string>>();

//	foreach(string url in urls)
//	{
//		tasks.Add(url, FetchDataAsync(url, token));
//	}

//	await Task.WhenAll(tasks.Values);

//	return tasks.ToDictionary(
//		pair => pair.Key,
//		pair => pair.Value.Result
//	);
//}
//var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
//try
//{
//	var results = await FetchMultipleDataAsync(new[]
//	{
//		"https://wikipedia.org",
//		"https://google.com"
//	}, cts.Token);

//	foreach(var result in results)
//	{
//        Console.WriteLine($"{result.Key}: {result.Value.Length}");

//		string domain = new Uri(result.Key).DnsSafeHost;

//		using FileStream fs = File.OpenWrite($"{domain}.html");
//		using StreamWriter sw = new StreamWriter(fs);

//		await sw.WriteAsync(result.Value);
//    }
//}
//catch (TaskCanceledException ex)
//{
//    Console.WriteLine("Операция прервана по таймауту");
//}



// ------ EX_3 IAsyncEnumerable --------

async IAsyncEnumerable<string> ReadLinesAsync(string filePath)
{
    using var sr = new StreamReader(filePath);

    while(! sr.EndOfStream)
    {
        var line = await sr.ReadLineAsync();

        yield return line;

        await Task.Delay(1000);          // Task.Run(() => Thread.Sleep(1000));
    }
}

await foreach (var line in ReadLinesAsync("data.txt"))
{
    Console.WriteLine($"STRING = {line}");
}

// =============== yield ===============

//IEnumerable<int> GetNumbers(int start, int end)
//{
//    for (int i = start; i <= end; i++)
//        yield return i;
//}

//foreach(int n in GetNumbers(1, 15))
//    Console.WriteLine(n);



//IEnumerable<int> GetEvenNumbers(IEnumerable<int> src)
//{
//    foreach(int num in src)
//        if (num % 2 == 0)
//            yield return num;
//}

//var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

//foreach (int n in GetEvenNumbers(numbers))
//{
//    Console.WriteLine(n);
//}







