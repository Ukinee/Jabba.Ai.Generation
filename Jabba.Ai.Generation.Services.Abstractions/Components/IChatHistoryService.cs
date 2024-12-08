using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Jabba.Ai.Generation.Domain;

namespace Jabba.Ai.Generation.Services.Abstractions.Components
{
    public interface IChatHistoryService<in T> where T : TaskData
    {
        public Task<ChatHistory> Get(ITaskHandler executor, T data, CancellationToken cancellationToken);
    }
}
