using Jabba.Complex.LongOperations.Abstractions;
using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions.Components
{
    public interface IGenerationResultConsumer<in T> where T : GenerationResult
    {
        public Task Consume(ITaskHandler executor, T generationResult, CancellationToken cancellationToken);
    }
}
