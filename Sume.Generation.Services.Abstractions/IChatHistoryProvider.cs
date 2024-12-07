using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions
{
    public interface IChatHistoryProvider
    {
        public Task<ChatHistory> Get(RawTask task, CancellationToken cancellationToken);
    }
}
