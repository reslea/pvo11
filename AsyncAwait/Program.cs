//while (true)
//{
//  Task task = new Task(PrintTheadId);
//  task.Start();
//}

Task task1 = new Task(() =>
{
  Console.WriteLine($"Task 2..");
  //throw new ArgumentException();
  Thread.Sleep(500);
});
Task task2 = new Task(() =>
{
  Console.WriteLine($"Task 2");
  Thread.Sleep(500);
});
Task<int> task3 = new Task<int>(() =>
{
  Console.WriteLine($"Task 3");
  Thread.Sleep(500);
  return 100;
});

await task1;

Console.WriteLine("all tasks are completed");

//Task startRequest = new Task(() =>
//{
//  throw new NotImplementedException();
//  Thread.Sleep(500);
//});

//startRequest.Start();

//startRequest
//  .ContinueWith((task) =>
//  {
//    if (task.IsCompletedSuccessfully)
//    {
//      Console.WriteLine($"Task 2");
//      Thread.Sleep(500);
//    }
//  })
//  .ContinueWith((_) =>
//  {
//    if (_.IsCompletedSuccessfully)
//    {
//      Console.WriteLine($"Task 2");
//      Thread.Sleep(500);
//    }
//  });

Console.ReadLine();


ThreadPool.SetMinThreads(1, 10);
ThreadPool.SetMaxThreads(2, 10);

ThreadPool.GetMaxThreads(out int maxThreads, out _);
ThreadPool.GetMinThreads(out int minThreads, out _);
Console.WriteLine("Thread pool settings:");
Console.WriteLine($"min: {minThreads} threads max: {maxThreads} threads");

while (true)
{
    ThreadPool.QueueUserWorkItem<string?>(PrintMessage, null, false);
}






int threadCount = 15;

for (int i = 0; i < threadCount; i++)
{
    Thread thread = new Thread(PrintHi);
    thread.Start();
}

while (true)
{
    Console.WriteLine("im in a main thread");
}

void PrintTheadId()
{
    int threadId = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"thread: {threadId}");

    Thread.Sleep(500);
}

void PrintMessage(string? message)
{
    //message = message == null
    //       ? ""
    //       : message;
    message = message ?? "";

    int threadId = Thread.CurrentThread.ManagedThreadId;
    Console.WriteLine($"thread: {threadId}" + message);

    Thread.Sleep(500);
}

void PrintHi()
{
    while (true)
    {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine($"#{threadId}");
    }
}