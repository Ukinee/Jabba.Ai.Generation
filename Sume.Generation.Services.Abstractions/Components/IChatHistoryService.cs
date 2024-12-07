using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions.Components
{
    public interface IChatHistoryService<in T> where T : TaskData
    {
        public Task<ChatHistory> Get(T data, CancellationToken cancellationToken);
    }
}
