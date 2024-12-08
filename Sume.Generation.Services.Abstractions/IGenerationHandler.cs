using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions
{
    public interface IGenerationHandler
    {
        public Task Handle(ITaskHandler executor, RawTask task, ChatHistory chatHistory, CancellationToken cancellationToken);
    }
}
