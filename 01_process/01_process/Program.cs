
// 1. Процесс (Process)

// 2. Поток (Thread)

// 3. Адрессное пространство (Memory Scope)

// 4. Приложение (Application)

// 5. Сборка (Assembly)

// 6. Модуль (Module)

// 7. Системные ресурсы (System resources)



#region Process

// 1. Memory scope
// 2. Исполняемый код
// 3. Системные дискрипторы
// 4. Контекст безопасности
// 5. Идентификатор
// 6. Переменные окружения
// 7. Приоритет
// 8. Как минимум одним потоком выполнения


using System.Diagnostics;

//Process[] processes = Process.GetProcesses();
//var proc = processes.OrderBy(p => p.Id);

//foreach (Process p in proc)
//    Console.WriteLine($"pid: {p.Id} {p.ProcessName}");







void Run()
{
    string? input;
    while (true)
    {
        Console.WriteLine("1. Show all processes");
        Console.WriteLine("2. Get process by id");
        Console.WriteLine("3. Show threads");
        Console.WriteLine("4. Show modules");

        input = Console.ReadLine();

        switch (input)
        {
            case "1":
                ShowAllProcesses();
                break;
            case "2":
                GetProceesById();
                break;
            case "3":
                ShowThreads();
                break;
            case "4":
                ShowModules();
                break;
        }
    }
}

Run();

void ShowAllProcesses()
{
    Process[] processes = Process.GetProcesses();
    var proc = processes.OrderBy(p => p.Id);

    foreach (Process p in proc)
        Console.WriteLine($"pid: {p.Id} {p.ProcessName}");
}
void GetProceesById()
{
    Console.Write("Enter PID: ");
    string? intput = Console.ReadLine();

    try
    {
        int pid = int.Parse(intput);

        Process p = Process.GetProcessById(pid);

        Console.WriteLine($"{p.Id}\t{p.ProcessName}\t{p.BasePriority}\t{p.StartTime}");
    }
    catch (Exception EX)
    {
        Console.WriteLine($"ERROR: {EX.Message}");
    }
}
void ShowThreads()
{
    Console.Write("Enter PID: ");
    string? intput = Console.ReadLine();

    try
    {
        int pid = int.Parse(intput);

        Process p = Process.GetProcessById(pid);

        var threads = p.Threads;
        Console.WriteLine("Threads list:");
        foreach(ProcessThread t in threads)
        {
            Console.WriteLine($"{t.Id}\t{t.StartTime.ToShortTimeString()}\t{t.PriorityLevel}");
        }
    }
    catch (Exception EX)
    {
        Console.WriteLine($"ERROR: {EX.Message}");
    }
}
void ShowModules()
{
    Console.Write("Enter PID: ");
    string? intput = Console.ReadLine();

    try
    {
        int pid = int.Parse(intput);

        Process p = Process.GetProcessById(pid);

        ProcessModuleCollection modules = p.Modules;

        foreach(ProcessModule m in modules)
            Console.WriteLine($"{m.ModuleName}\t{m.ModuleMemorySize}");
    }
    catch (Exception EX)
    {
        Console.WriteLine($"ERROR: {EX.Message}");
    }
}

#endregion



