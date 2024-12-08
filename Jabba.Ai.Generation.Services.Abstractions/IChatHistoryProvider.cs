using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Jabba.Ai.Generation.Domain;

namespace Jabba.Ai.Generation.Services.Abstractions
{
    public interface IChatHistoryProvider
    {
        public Task<ChatHistory> Get(ITaskHandler executor, RawTask task, CancellationToken cancellationToken);
    }
}
