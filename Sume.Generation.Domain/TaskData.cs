namespace Sume.Generation.Domain
{
    public abstract class TaskData
    {
        protected TaskData(Guid targetId)
        {
            TargetId = targetId;
        }

        public Guid TargetId { get; }
    }
}
