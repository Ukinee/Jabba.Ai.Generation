namespace Sume.Generation.Domain
{
    public abstract class GenerationResult
    {
        protected GenerationResult(RawTask rawTask)
        {
            RawTask = rawTask;
        }

        public RawTask RawTask { get; }
    }
}
