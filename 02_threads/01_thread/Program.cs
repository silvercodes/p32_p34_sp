
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






#endregion

