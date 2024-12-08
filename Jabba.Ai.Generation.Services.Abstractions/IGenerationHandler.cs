using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Jabba.Ai.Generation.Domain;

namespace Jabba.Ai.Generation.Services.Abstractions
{
    public interface IGenerationHandler
    {
        public Task Handle(ITaskHandler executor, RawTask task, ChatHistory chatHistory, CancellationToken cancellationToken);
    }
}
