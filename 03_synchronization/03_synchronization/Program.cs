
// Инструменты синхронизация

// 1. Простые методы блокировки (Thread.Sleep(), Thread.Join(), Task.Wait()....)

// 2. Контроль критических секций (lock, Monitor(20нс), Mutex(1000нс), SpinLock, Semaphore(1000нс), SemaphoreSlim, ....)

// 3. Инструменты сигнализации (Monitor.Pulse(), Monitor.PulseAll(), .Wait(), AutoResetEvent, ManualResetEvent, CountdownResetEvent...)

// 4. Неблокирующие инструменты (Thread.MemoryBarrier, Interlocked, Thread.VolitileRead...)


#region Блокировка lock / Monitor (эксллюзивная блокировка)

// Разблокировка
// 1. Выполнение условий блокировки
// 2. Таймаут
// 3. Thread.Interrupt()
// 4. Thread.Abort()



//new Thread(ThreadUnsafe.Run).Start();
//ThreadUnsafe.Run();

//class ThreadUnsafe
//{
//    static int a = 10;
//    static int b = 20;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;

//        if(b != 0)
//        {
//            c = a / b;
//        }

//        b = 0;
//    }
//}

//new Thread(ThreadSafe.Run).Start();
//ThreadSafe.Run();

//class ThreadSafe
//{
//    static int a = 10;
//    static int b = 20;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;

//        // FIFO
//        lock (locker)
//        {
//            if (b != 0)
//            {
//                c = a / b;
//            }

//            b = 0; 
//        }
//    }

//}




//new Thread(ThreadSafe.Run).Start();
//ThreadSafe.Run();

//class ThreadSafe
//{
//    static int a = 10;
//    static int b = 20;
//    static object locker = new object();

//    public static void Run()
//    {
//        int c = 0;
//        bool flag = false;

//        try
//        {
//            Monitor.Enter(locker, ref flag);        // Попытка взятия блокировки у locker

//            if (b != 0)
//            {
//                c = a / b;
//            }

//            b = 0;
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"ERROR: {ex.Message}");
//        }
//        finally
//        {
//            if (flag)
//                Monitor.Exit(locker);               // Освобождение блокировки
//        }

//    }

//}





//object locker = new object();
//int val = 0;

//void Run()
//{
//    bool flag = false;

//    try
//    {
//        flag = Monitor.TryEnter(locker, 500);

//        if (flag)
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                Console.WriteLine($"{Thread.CurrentThread.Name}: {val++}");
//                Thread.Sleep(200);
//            }
//        }

//        Console.WriteLine($"{Thread.CurrentThread.Name} is looser");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"ERROR: {ex.Message}");
//    }
//    finally
//    {
//        if (flag)
//            Monitor.Exit(locker);               // Освобождение блокировки
//    }

//}

//for (int i = 0; i < 3; ++i)
//{
//    Thread t = new Thread(Run)
//    {
//        Name = $"thread_{i}",
//    };
//    t.Start();
//}





//class Container
//{
//    public List<string> Emails { get; set; } = new List<string>();
//    //
//    //

//    public void Run()
//    {
//        //
//        //
//        lock(Emails)
//        {
//            Emails.Add("vasia@mail.com");
//        }
//        //
//        //
//        //
//    }
//}





// ===== deadlock

//object locker1 = new Object();
//object locker2 = new Object();

//new Thread(() =>
//{
//    lock(locker1)
//    {
//        Thread.Sleep(1000);

//        lock(locker2) 
//        {
//            //
//            //
//        }
//    }
//}).Start();


//lock (locker2)
//{
//    Thread.Sleep(1000);

//    lock (locker1)
//    {
//        //
//        //
//    }
//}

#endregion

#region Mutex (Эксклюзивная блокировка)

//int count = 0;
//Mutex mutex = new Mutex();

//void UseResource()
//{
//    if (mutex.WaitOne(500))            // Попытка взять блокировку
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} take the mutex");

//        Thread.Sleep(200);
//        count++;

//        Console.WriteLine($"{Thread.CurrentThread.Name} done the work");

//        Console.WriteLine($"{Thread.CurrentThread.Name} release mutex");

//        mutex.ReleaseMutex();           // Освоюождение mutex
//    }
//    else
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} is looser");
//    }
//}

//void StartThreads()
//{
//    for (int i = 0; i < 5; ++i)
//    {
//        Thread t = new Thread(UseResource)
//        {
//            Name = $"thread_{i}",
//        };
//        t.Start();
//    }
//}

//StartThreads();

#endregion

#region Semaphore (НЕ Эксклюзивная блокировка)

//Semaphore semaphore = new Semaphore(0, 3);
//object locker = new Object();
//int executionTime = 0;

//void Run(int id)
//{
//    Console.WriteLine($"Thread {id} statrted");

//    semaphore.WaitOne();                        // Попытка взять блокировку

//    Console.WriteLine($"Thread {id} passed semaphore");

//    int time;
//    lock (locker)
//    {
//        executionTime += 200;
//        time = executionTime;
//    }

//    Thread.Sleep(time + 2000);

//    Console.WriteLine($"Thread {id} released semaphore");
//    semaphore.Release();                            // "Освободить 1 место"
//}

//for (int i = 1; i <= 5; ++i)
//{
//    int x = i;
//    Thread t = new Thread(() => Run(x));
//    t.Start();
//}

//Thread.Sleep(3000);
//semaphore.Release(3);

#endregion

#region Signaling

//object locker = new Object();

//void First()
//{
//    try
//    {
//        Monitor.Enter(locker);

//        for (int i = 1; i <= 10; i += 2)
//        {
//            Thread.Sleep(200);
//            Console.Write($"{i} ");
//            Monitor.Pulse(locker);          // Перевод locker в сигнальное состояние
//            Monitor.Wait(locker);           // Ожидание следующего сигнального состояния
//        }
//    }
//    finally
//    {
//        Monitor.Exit(locker);
//    }
//}
//void Second()
//{
//    try
//    {
//        Monitor.Enter(locker);

//        for (int i = 0; i <= 10; i += 2)
//        {
//            Thread.Sleep(200);
//            Console.Write($"{i} ");
//            Monitor.Pulse(locker);
//            Monitor.Wait(locker);
//        }
//    }
//    finally
//    {
//        Monitor.Exit(locker);
//    }
//}

//Thread t1 = new Thread(First);
//Thread t2 = new Thread(Second);

//t2.Start();
//Thread.Sleep(3000);
//t1.Start();


//AutoResetEvent are = new AutoResetEvent(false);
//EventWaitHandle mre = new ManualResetEvent(false);



//SimpleWaitHandle.Run();
//static class SimpleWaitHandle
//{
//    static EventWaitHandle wh = new AutoResetEvent(false);

//    public static void Run()
//    {
//        new Thread(Work).Start();
//        Thread.Sleep(3000);
//        wh.Set();                   // Перевод в сигнальное состояние
//    }

//    public static void Work()
//    {
//        Console.WriteLine("Work(): waiting...");
//        wh.WaitOne();               // Ожидание сигнального состояние
//        Console.WriteLine("Working...");
//    }
//}




//AutoResetEvent are = new AutoResetEvent(false);

//for (int i = 0; i < 5; ++i)
//{
//    Thread t = new Thread(Render)
//    {
//        Name = $"thread_{i}",
//    };
//    t.Start();
//}
//Thread.Sleep(3000);
//are.Set();

//void Render()
//{
//    are.WaitOne();
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
//        Thread.Sleep(200);   
//    }
//    are.Set();
//}






//ManualResetEvent mre = new ManualResetEvent(false);

//UserThread ut1 = new UserThread("first", mre);
//Console.WriteLine("Waiting");
//mre.WaitOne();
//Console.WriteLine("first working");
//mre.Reset();

//UserThread ut2 = new UserThread("second", mre);
//mre.WaitOne();
//Console.WriteLine("second working");
//mre.Reset();

//class UserThread
//{
//    private ManualResetEvent mre;
//    public Thread Thread { get; set; }

//    public UserThread(string name, ManualResetEvent mre)
//    {
//        this.mre = mre;

//        Thread = new Thread(Run)
//        {
//            Name = name,
//        };

//        Thread.Start();
//    }

//    private void Run()
//    {
//        Console.WriteLine($"{Thread.Name} started...");

//        for (int i = 0; i < 5; ++i)
//        {
//            Console.WriteLine($"{Thread.Name}: {i}");
//            Thread.Sleep(200);
//        }

//        mre.Set();
//    }

//}



#endregion

#region Interlocked

//Semaphore semaphore = new Semaphore(0, 3);
//int executionTime = 0;

//void Run(int id)
//{
//    Console.WriteLine($"Thread {id} statrted");

//    semaphore.WaitOne();                        // Попытка взять блокировку

//    Console.WriteLine($"Thread {id} passed semaphore");

//    int time = Interlocked.Add(ref executionTime, 200);
    
//    Thread.Sleep(time + 2000);

//    Console.WriteLine($"Thread {id} released semaphore");
//    semaphore.Release();                            // "Освободить 1 место"
//}

//for (int i = 1; i <= 5; ++i)
//{
//    int x = i;
//    Thread t = new Thread(() => Run(x));
//    t.Start();
//}

//Thread.Sleep(3000);
//semaphore.Release(3);

#endregion
