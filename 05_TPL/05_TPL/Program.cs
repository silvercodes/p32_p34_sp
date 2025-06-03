
#region Постановка Task в очередь (запуск)

//Task t1 = new Task(() => Console.WriteLine("Vasia"));
//t1.Start();

//Task t2 = Task.Factory.StartNew(() => Console.WriteLine("Petya"));

//Task t3 = Task.Run(() => Console.WriteLine("Dima"));

////
////
////

//t1.Wait();
//t2.Wait();
//t3.Wait();

#endregion

#region RunSynchronously()

//Task t = new Task(() =>
//{
//    Console.WriteLine("Start");
//    Thread.Sleep(1000);
//    Console.WriteLine("End");
//});

//t.Start();                  // async call
//// t.RunSynchronously();       // sync call

//Console.WriteLine("FROM MAIN");
//Console.ReadLine();

#endregion


#region Task

//Task t = new Task(() =>
//{
//    Console.WriteLine("Start");
//    Thread.Sleep(1000);
//    Console.WriteLine("End");
//});

//t.Start();

//Console.WriteLine(t.Id);
//Console.WriteLine(t.Status);
//Console.WriteLine(t.IsCompleted);
//Console.WriteLine(t.Exception);

#endregion


#region Imbedded Tasks

//Task t1 = new Task(() =>
//{
//    Console.WriteLine("t1 started");

//    Task t2 = new Task(() =>
//    {
//        Console.WriteLine("t2 started");
//        Thread.Sleep(1000);
//        Console.WriteLine("t2 finished");
//    }, TaskCreationOptions.AttachedToParent);

//    t2.Start();

//    Console.WriteLine("t1 finished");
//});

//t1.Start();
//t1.Wait();

//Console.WriteLine("Main finished");

#endregion


#region Массив задач

//long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//List<Task> tasks = new List<Task>()
//{ 
//    new Task(() =>
//    {
//        Thread.Sleep(1000);
//        Console.WriteLine("Task 1000 ms finished");
//    }),
//    new Task(() =>
//    {
//        Thread.Sleep(1200);
//        Console.WriteLine("Task 1200 ms finished");
//    }),
//    new Task(() =>
//    {
//        Thread.Sleep(2000);
//        Console.WriteLine("Task 2000 ms finished");
//    }),
//};

//tasks.ForEach(t => t.Start());

//// Task.WaitAll(tasks);                 // BLOCKING
//Task.WaitAny(tasks.ToArray());          // BLOCKING

//Console.WriteLine($"TIME = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time}");

//Console.WriteLine("Main finished");

#endregion


#region Возврат значения

//Task<int> t = new Task<int>(() =>
//{
//    Thread.Sleep(1000);
//    return 10;
//});

//t.Start();
////
////
//int result = t.Result;              // BLOCKING
//Console.WriteLine(result);

//Console.WriteLine("Main finished");




//int a = 3;
//int b = 4;
//Task<int> t = new Task<int>(() => Sum(a, b));
//t.Start();
//Console.WriteLine(t.Result);                    // BLOCKING
//int Sum(int a, int b) => a + b;




//Task<Thread> t = new Task<Thread>(() =>
//{
//    Thread thread = new Thread(() => Console.WriteLine("test from thread"));

//    return thread;
//});
//t.Start();
////
////
//Thread thread = t.Result;
//thread.Start();


#endregion


#region Цепочка
// using System.Text;

//Photo photo = new Photo();

//Task<Photo> t = new Task<Photo>(() =>
//{
//    Task<Photo> t1 = new Task<Photo>(() =>
//    {
//        Thread.Sleep(1000);
//        photo.Filters.Add("filter_1");

//        return photo;
//    });
//    t1.Start();
//    Photo result = t1.Result;               // BLOCKING

//    Task t2 = new Task(() =>
//    {
//        Thread.Sleep(1500);
//        result.Filters.Add("filter_2");
//    });
//    t2.Start();
//    t2.Wait();                              // BLOCKING

//    Task t3 = new Task(() =>
//    {
//        Thread.Sleep(2000);
//        result.Filters.Add("filter_3");
//    });
//    t3.Start();
//    t3.Wait();                              // BLOCKING

//    return result;
//});

//t.Start();
////
////
//Photo result = t.Result;                // BLOCKING
//Console.WriteLine(result);





//Photo photo = new Photo();

//Task<Photo> t1 = new Task<Photo>(() =>
//{
//    Thread.Sleep(1000);
//    photo.Filters.Add("filter_1");

//    return photo;
//});

//Task<Photo> taskResult = t1.ContinueWith((t) =>
//{
//    Photo res = t.Result;
//    res.Filters.Add("filter_2");

//    return res;
//}).ContinueWith((t) =>
//{
//    Photo res = t.Result;
//    res.Filters.Add("filter_3");

//    return res;
//});

//t1.Start();
//Photo resPhoto = taskResult.Result;     // BLOCKING
//Console.WriteLine(resPhoto);




//class Photo
//{
//    public List<string> Filters { get; set; } = new List<string>();
//    public override string ToString()
//    {
//        StringBuilder sb = new StringBuilder();
//        Filters.ForEach(f => sb.Append($"{f} "));

//        return sb.ToString();
//    }
//}




//Task t1 = new Task(() => Console.WriteLine("statr task"));

//Task chain = t1
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id))
//    .ContinueWith(t => Console.WriteLine(t.Id));

//t1.Start();
//chain.Wait();

#endregion



#region Parallel

//Parallel.Invoke(
//        TestPrint,
//        () => Console.WriteLine("test lambda"),
//        () => Sum(3, 4)
//    );

//void TestPrint()
//{
//    Thread.Sleep(2000);
//    Console.WriteLine("Test print");
//}

//int Sum(int a, int b) => a + b;




//ThreadPool.SetMinThreads(20, 2);

//long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//Parallel.For(0, 20, i =>
//{
//    Console.WriteLine($"{Task.CurrentId}: {i}");
//    Thread.Sleep(1000);
//});

//Console.WriteLine($"TIME = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time}");





//ThreadPool.SetMinThreads(10, 2);

//long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

//List<int> nums = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

//Parallel.ForEach(nums, n =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine(n);
//});

//Console.WriteLine($"TIME = {DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time}");

#endregion


#region CancellationToken

// ---- Мягкое прерывание ----

//CancellationTokenSource cts = new CancellationTokenSource();
//CancellationToken token = cts.Token;

//Task t = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            Console.WriteLine("Cancellation requested");
//            return;
//        }
//        Console.WriteLine(i);
//        Thread.Sleep(1000);
//    }
//}, token);

//t.Start();
////
////
//Console.ReadLine();
//cts.Cancel();



// ---- Жесткое прерывание ----

//CancellationTokenSource cts = new CancellationTokenSource();
//CancellationToken token = cts.Token;

//Task t = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            token.ThrowIfCancellationRequested();       // throw TaskCanceledException
//        }
//        Console.WriteLine(i);
//        Thread.Sleep(1000);
//    }
//}, token);


//try
//{
//    t.Start();

//    Console.ReadLine();
//    cts.Cancel();

//    t.Wait();
//}
//catch (AggregateException ex)
//{
//    foreach (Exception e in ex.InnerExceptions)
//    {
//        if (e is TaskCanceledException)
//            Console.WriteLine("Task interrupted!");
//        else
//            Console.WriteLine(e.Message);
//    }
//}
//finally
//{
//    cts.Dispose();
//}

//Console.WriteLine(t.Status);

#endregion


