using Sume.Generation.Domain;

namespace Sume.Generation.Services.Abstractions.Components
{
    public interface IGenerationResultConsumer<in T> where T : GenerationResult
    {
        public Task Consume(T generationResult, CancellationToken cancellationToken);
    }
}
