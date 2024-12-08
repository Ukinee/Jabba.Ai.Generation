using Jabba.Complex.LongOperations.Abstractions;
using Jabba.Ai.Generation.Domain;

namespace Jabba.Ai.Generation.Services.Abstractions.Components
{
    public interface ITaskDataProvider<T> where T : TaskData
    {
        public Task<T> GetTaskData(ITaskHandler taskHandler, RawTask task, CancellationToken cancellationToken);
    }
}
