using System.Collections.Concurrent;
using Jabba.Ai.Generation.Domain;
using Jabba.Ai.Generation.TaskProviders.Abstractions;

namespace Jabba.Ai.Generation.TaskProviders.Implementations
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
