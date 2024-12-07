using Sume.Generation.Domain;

namespace Sume.Generation.TaskProviders.Abstractions;

public interface ITaskProvider
{
    public bool HasTasks { get; }
    
    public void Add(RawTask rawTask);
    public RawTask Get(CancellationToken cancellationToken);
}
