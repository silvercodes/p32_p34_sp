
using System.Reflection;
using System.Runtime.Loader;


#region AppDomain
//AppDomain domain = AppDomain.CurrentDomain;

//Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");

//foreach (Assembly a in domain.GetAssemblies())
//    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");
#endregion

#region Статическая загрузка сборок

// using _03_MathLib;

//AppDomain domain = AppDomain.CurrentDomain;
//Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");

//foreach (Assembly a in domain.GetAssemblies())
//    Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");

//Calculator calculator = new Calculator();
//Console.WriteLine(calculator.Sum(3, 4));






#endregion

#region Динамическая загрузка сборки

Console.WriteLine("======= BEFORE LOADING");
ShowAssemblies();

AssemblyLoadContext ctx = new AssemblyLoadContext("lib_ctx", true);

Assembly assembly = ctx.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "03_MathLib.dll"));

ctx.Unloading += ctx => Console.WriteLine("ASSEMBLY_CONTEXT UNLOADED!!!!!");

Console.WriteLine("======= AFTER LOADING");
ShowAssemblies();

Type? type = assembly.GetType("_03_MathLib.Calculator");

// --- static call
//MethodInfo? method = type?.GetMethod("Factorial");
//int? factorial = (int?)method.Invoke(assembly, new object[] { 5 });
//Console.WriteLine($"Factorial = {factorial}");

// --- non-static call
MethodInfo? method = type?.GetMethod("Sum");
object? calc = Activator.CreateInstance(type);
int? result = (int?)method.Invoke(calc, new object[] { 4, 5 });
Console.WriteLine($"Sum = {result}");


ctx.Unload();
GC.Collect();

Console.WriteLine("======= AFTER UNLOADING");
ShowAssemblies();

void ShowAssemblies()
{
    AppDomain domain = AppDomain.CurrentDomain;
    Console.WriteLine($"{domain.FriendlyName}\t{domain.BaseDirectory}");

    foreach (Assembly a in domain.GetAssemblies())
        Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");
}

#endregion
