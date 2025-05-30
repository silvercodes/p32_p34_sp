
using _04_producer_concumer_queue.Jobs;
using PCQueue;

QueueManager queueManager = new QueueManager(100);
for (int i = 0; i < 1000; ++i)
{
    queueManager.EnqueueJob(new SendEmailJob() { Email = $"user_{i}@mail.com" });
}

for (int i = 0; i < 200; ++i)
{
    Thread.Sleep(100);
    Console.WriteLine($"Main: {i}");
}