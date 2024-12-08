using Jabba.Complex.LongOperations.Abstractions;
using Microsoft.SemanticKernel.ChatCompletion;
using Jabba.Ai.Generation.Common;
using Jabba.Ai.Generation.Domain;
using Jabba.Ai.Generation.Services.Abstractions;
using Jabba.Ai.Generation.Services.Abstractions.Components;

namespace Jabba.Ai.Generation.Services.Implementations
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
        
        public async Task<ChatHistory> Get(ITaskHandler executor, RawTask task, CancellationToken cancellationToken)
        {
            executor.Stage = GenerationStages.GettingTaskData;
            T taskData = await _taskDataProvider.GetTaskData(executor, task, cancellationToken);

            executor.Stage = GenerationStages.GeneratingChatHistory;
            return await _chatHistoryService.Get(executor, taskData, cancellationToken);
        }
    }
}
