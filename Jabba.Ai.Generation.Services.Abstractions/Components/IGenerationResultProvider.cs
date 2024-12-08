using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Jabba.Ai.Generation.Domain;

namespace Jabba.Ai.Generation.Services.Abstractions.Components
{
    public interface IGenerationResultProvider<T> where T : GenerationResult
    {
        public Task<T> Get(ITaskHandler executor, RawTask task, ChatHistory chatHistory, CancellationToken cancellationToken);
    }
}
