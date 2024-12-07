using System.Collections.Concurrent;
using Sume.Generation.Domain;
using Sume.Generation.TaskProviders.Abstractions;

namespace Sume.Generation.TaskProviders.Implementations
{
    public class BasicTaskProvider : ITaskProvider, IDisposable
    {
        private readonly BlockingCollection<RawTask> _tasks = new BlockingCollection<RawTask>();

        public bool HasTasks => _tasks.IsCompleted == false;

        public void Add(RawTask rawTask)
        {
            _tasks.Add(rawTask);
        }

        public RawTask Get(CancellationToken cancellationToken)
        {
            return _tasks.Take(cancellationToken);
        }

        public void Dispose()
        {
            _tasks.Dispose();
        }
    }
}
