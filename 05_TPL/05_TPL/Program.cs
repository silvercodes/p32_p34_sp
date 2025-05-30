
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

Task t1 = new Task(() =>
{
    Console.WriteLine("t1 started");

    Task t2 = new Task(() =>
    {
        Console.WriteLine("t2 started");
        Thread.Sleep(1000);
        Console.WriteLine("t2 finished");
    }, TaskCreationOptions.AttachedToParent);

    t2.Start();

    Console.WriteLine("t1 finished");
});

t1.Start();
t1.Wait();

Console.WriteLine("Main finished");

#endregion



