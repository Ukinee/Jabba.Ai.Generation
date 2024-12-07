using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions.Components
{
    public interface IGenerationResultProvider<T> where T : GenerationResult
    {
        public Task<T> Get(RawTask task, ChatHistory chatHistory, CancellationToken cancellationToken);
    }
}
