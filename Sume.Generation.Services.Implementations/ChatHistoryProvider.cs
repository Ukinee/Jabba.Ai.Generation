using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;
using Sume.Generation.Services.Abstractions;
using Sume.Generation.Services.Abstractions.Components;

namespace Sume.Generation.Services.Implementations
{
    public class ChatHistoryProvider<T> : IChatHistoryProvider where T : TaskData 
    {
        private readonly ITaskDataProvider<T> _taskDataProvider;
        private readonly IChatHistoryService<T> _chatHistoryService;

        public ChatHistoryProvider(ITaskDataProvider<T> taskDataProvider, IChatHistoryService<T> chatHistoryService)
        {
            _taskDataProvider = taskDataProvider;
            _chatHistoryService = chatHistoryService;
        }
        
        public async Task<ChatHistory> Get(RawTask task, CancellationToken cancellationToken)
        {
            T taskData = await _taskDataProvider.GetTaskData(task, cancellationToken);

            return await _chatHistoryService.Get(taskData, cancellationToken);
        }
    }
}
