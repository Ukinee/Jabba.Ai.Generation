using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions
{
    public interface IGenerationHandler
    {
        public Task Handle(RawTask task, ChatHistory chatHistory, CancellationToken cancellationToken);
    }
}
