using Jabba.Complex.LongOperations.Abstractions;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions.Components
{
    public interface ITaskDataProvider<T> where T : TaskData
    {
        public Task<T> GetTaskData(ITaskHandler taskHandler, RawTask task, CancellationToken cancellationToken);
    }
}
