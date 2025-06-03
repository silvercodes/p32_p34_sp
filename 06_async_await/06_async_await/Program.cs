
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




async Task MethodAsync()
{
    Console.WriteLine("Start");

    Task t = new Task(() => Thread.Sleep(1000));
    t.Start();

    Console.WriteLine("ONE");

    // t.Wait();
    await t;

    Console.WriteLine("End");
}


_ = MethodAsync();

Console.WriteLine("MAIN");

Console.ReadLine();










