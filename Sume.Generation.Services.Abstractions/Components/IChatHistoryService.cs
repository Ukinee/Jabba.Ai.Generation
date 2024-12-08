using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions.Components
{
    public interface IChatHistoryService<in T> where T : TaskData
    {
        public Task<ChatHistory> Get(ITaskHandler executor, T data, CancellationToken cancellationToken);
    }
}
