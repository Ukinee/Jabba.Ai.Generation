using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions.Components
{
    public interface ITaskDataProvider<T> where T : TaskData
    {
        public Task<T> GetTaskData(RawTask task, CancellationToken cancellationToken);
    }
}
