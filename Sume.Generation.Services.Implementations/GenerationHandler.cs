using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;
using Sume.Generation.Services.Abstractions;
using Sume.Generation.Services.Abstractions.Components;

namespace Sume.Generation.Services.Implementations
{
    public class GenerationHandler<T> : IGenerationHandler where T : GenerationResult
    {
        private readonly IGenerationResultProvider<T> _generationResultProvider;
        private readonly IGenerationResultConsumer<T> _generationResultConsumer;

        public GenerationHandler
        (
            IGenerationResultProvider<T> generationResultProvider,
            IGenerationResultConsumer<T> generationResultConsumer
        )
        {
            _generationResultProvider = generationResultProvider;
            _generationResultConsumer = generationResultConsumer;
        }

        public async Task Handle(RawTask task, ChatHistory chatHistory, CancellationToken cancellationToken)
        {
            T result = await _generationResultProvider.Get(task, chatHistory, cancellationToken);
            
            await _generationResultConsumer.Consume(result, cancellationToken);
        }
    }
}
