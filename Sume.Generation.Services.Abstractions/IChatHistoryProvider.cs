using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions
{
    public interface IChatHistoryProvider
    {
        public Task<ChatHistory> Get(ITaskHandler executor, RawTask task, CancellationToken cancellationToken);
    }
}
