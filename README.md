Consider following code

```csharp
using System;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IServerNotifier
    {
        Task NotifyServer();
    }

    class Program
    {
        private static IServerNotifier Notifier;
        static void Main(string[] args)
        {
            Notifier.NotifyServer();
            Console.Write("Server notified.");
        }
    }
}
```

There are 2 problems: first - program may terminate before server is actually notified; second - what happens if server notification fails?
Good chances that *Task* returned by *NotifyServer()* gets to GC and is going to throw an exception on finalizer thread. 
This is probably not the intended behavior. Most likely, the code above should look like
```csharp
        static void Main(string[] args)
        {
            Notifier.NotifyServer().Wait();
            Console.Write("Server notified.");
        }
```
This R# plugin helps to spot such situations.
