using System.Threading.Tasks;

namespace ForceTaskObserve.Tests.test.data.UnobservedTask
{
    public class UnobservedTask
    {
        public async Task DoAsync()
        {
            await Run();
        }

        public Task Do()
        {
            Run();
            RunWithResult();
            Run().Wait();
            var x = Run();
            return Run();
        }

        public Task Run()
        {
            return Task.FromResult(0);
        }

        public Task<int> RunWithResult()
        {
            return Task.FromResult(0);
        }
    }
}