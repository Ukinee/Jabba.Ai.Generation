using Jabba.Complex.LongOperations.Abstractions;
using Jabba.Ai.Generation.Domain;

namespace Jabba.Ai.Generation.Services.Abstractions.Components
{
    public interface IGenerationResultConsumer<in T> where T : GenerationResult
    {
        public Task Consume(ITaskHandler executor, T generationResult, CancellationToken cancellationToken);
    }
}
