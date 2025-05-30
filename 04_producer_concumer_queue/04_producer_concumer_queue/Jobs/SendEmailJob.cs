using PCQueue;

namespace _04_producer_concumer_queue.Jobs;

internal class SendEmailJob : IJob
{
    public Random random;
    public required string Email { get; set; }
    public SendEmailJob()
    {
        random = new Random();
    }
    public void Execute()
    {
        Thread.Sleep(random.Next(50, 200));
        Console.WriteLine($"Email to {Email} was sended...");
    }

    public string GetInfo()
    {
        return $"Email = {Email}";
    }
}
