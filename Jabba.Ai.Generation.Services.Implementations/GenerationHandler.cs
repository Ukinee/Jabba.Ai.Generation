using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Jabba.Ai.Generation.Common;
using Jabba.Ai.Generation.Domain;
using Jabba.Ai.Generation.Services.Abstractions;
using Jabba.Ai.Generation.Services.Abstractions.Components;

namespace Jabba.Ai.Generation.Services.Implementations
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

        public async Task Handle(ITaskHandler executor, RawTask task, ChatHistory chatHistory, CancellationToken cancellationToken)
        {
            executor.Stage = GenerationStages.GettingGenerationResult;
            T result = await _generationResultProvider.Get(executor, task, chatHistory, cancellationToken);
            
            executor.Stage = GenerationStages.ConsumingGenerationResult;
            await _generationResultConsumer.Consume(executor, result, cancellationToken);
        }
    }
}
