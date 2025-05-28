
#region Intro
//void ShowPlus()
//{
//    for (int i = 0; i < 1000; ++i)
//        Console.Write('+');
//}

//// Thread t = new Thread(new ThreadStart(ShowPlus));
//// >>> EQUALS <<<
//Thread t = new Thread(ShowPlus);
//t.Start();
//Console.WriteLine(t.IsAlive);

//for (int i = 0; i < 1000; ++i)
//    Console.Write('0');





//void Run()
//{
//    for (int i = 0; i < 5; ++i)
//        Console.Write('0');
//}

//new Thread(Run).Start();
//Run();






//bool done = false;

//void Run()
//{
//    if (!done)
//    {
//        // Console.WriteLine("*");
//        done = true;
//        Console.WriteLine("DONE");
//    }
//}

//new Thread(Run).Start();
//Run();






//bool done = false;
//object locker = new object();

//void Run()
//{
//    lock (locker)
//    {
//        if (!done)
//        {
//            Console.WriteLine("*");
//            done = true;
//            Console.WriteLine("DONE");
//        }
//    }
//}

//new Thread(Run).Start();
//Run();






//void Run()
//{
//    for(int i = 0; i < 1000; ++i)
//    {
//        Console.Write('*');
//    }
//    Console.WriteLine();
//}

//Console.WriteLine("Main start");
//Thread t = new Thread(Run);
//t.Start();
//// Thread.Sleep(1);
//t.Join();                       // Блокируем основной поток (ждем завершение потока t)
//Console.WriteLine("Main end");
#endregion


#region Create / Start

// =========== Простые способы ===========
//void Run()
//{
//    Console.WriteLine("hello");
//}

//Thread t = new Thread(new ThreadStart(Run));
//t.Start();
//Run();



//Thread t = new Thread(() => Console.WriteLine("Vasia"));
//t.Start();


//string email = "vasia@mail.com";
//// Thread t = new Thread(new ThreadStart(() => Console.WriteLine($"EMAIL: {email}")));
//// >>> EQUALS <<<
//Thread t = new Thread(() => Console.WriteLine($"EMAIL: {email}"));
//t.Start();




//void Calc(int a, int b)
//{
//    Console.WriteLine($"RESULT: {a + b}");
//}

//int a = 3;
//int b = 4;


//// Способ 1
////void RunCalc(object? obj)
////{
////    if (obj is Parameters p)
////        Calc(p.a, p.b);
////}

////Thread t = new Thread(RunCalc);
////t.Start(new Parameters() { a = a, b = b });
////class Parameters
////{
////    public int a;
////    public int b;
////}

//// Способ 2
//Thread t = new Thread(() => Calc(a, b));
//t.Start();





//void Render(string message, ConsoleColor color)
//{
//    Console.ForegroundColor = color;
//    Console.WriteLine(message);
//    Console.ResetColor();
//}

//string message = "Brus Willis";
//ConsoleColor color = ConsoleColor.Green;

//Thread t = new Thread(() => Render(message, color));
//t.Start();



// :-(
//for (int i = 0; i < 10; i++)
//    new Thread(() => Console.WriteLine(i)).Start();

//for (int i = 0; i < 10; i++)
//{
//    int n = i;
//    new Thread(() => Console.WriteLine(n)).Start();
//}





// !!!!
//int i;
//List<Thread> threads = new List<Thread>();

//for (i = 0; i < 10; ++i)
//    threads.Add(new Thread(() => Console.WriteLine(i)));

//threads.ForEach(t => t.Start());





//void Run()
//{
//    Console.WriteLine($"Message FROM {Thread.CurrentThread.Name}");
//}

//Thread.CurrentThread.Name = "main";

//Thread t = new Thread(Run)
//{
//    Name = "worker",
//};

//t.Start();
//Run();




//Thread t = new Thread(() => Console.ReadLine());

//if (args.Length > 0)
//    t.IsBackground = true;

//t.Start();

#endregion


#region try / catch

//void Run()
//{
//    throw new Exception("Test Exception");
//}

//try
//{
//    new Thread(Run).Start();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}




//void Run()
//{
//    try
//    {
//        throw new Exception("Test Exception");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//}

//new Thread(Run).Start();

#endregion


#region TPL (Task Parallel Library), Thread pool

// Task, Task<T>, ValueTask, ValueTask<T>, Parallel...

//void Run()
//{
//    Console.WriteLine("Vasia");
//}

//Task task = Task.Factory.StartNew(() => Run());
////
////
//task.Wait();            // BLOCKING!!!

// await Task.Factory.StartNew(Run);






//using System.Net;

//string DownloadPageSrc(string url)
//{
//    WebClient client = new WebClient();

//    return client.DownloadString(url);
//}

//// Console.WriteLine(DownloadPageSrc(@"https://wikipedia.org"));


//string url = @"https://wikipedia.org";
//Task<string> t = Task.Factory.StartNew(() => DownloadPageSrc(url));
////
//Console.WriteLine("test");
////
//string content = t.Result;              // BLOCKING
//Console.WriteLine(content);



ThreadPool.SetMinThreads(100, 10);

int count;
int completion;

ThreadPool.GetMinThreads(out count, out completion);

Console.WriteLine($"{count} {completion}");

#endregion