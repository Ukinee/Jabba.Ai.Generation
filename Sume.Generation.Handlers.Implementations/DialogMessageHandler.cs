using Jabba.Complex.LongOperations.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Common;
using Sume.Generation.Domain;
using Sume.Generation.Services.Abstractions;
using Sume.Generation.TaskProviders.Abstractions;

namespace Sume.Generation.Handlers.Implementations
{
    public class GenerationLongOperationHandler : LongOperationHandlerBase
    {
        private readonly ITaskProvider _taskProvider;
        private readonly IChatHistoryProvider _chatHistoryProvider;
        private readonly IGenerationHandler _generationHandler;

        public GenerationLongOperationHandler
        (
            string name,
            ILogger<GenerationLongOperationHandler> logger,
            ITaskProvider taskProvider,
            IChatHistoryProvider chatHistoryProvider,
            IGenerationHandler generationHandler
        ) : base(logger, name)
        {
            _taskProvider = taskProvider;
            _chatHistoryProvider = chatHistoryProvider;
            _generationHandler = generationHandler;
        }

        protected override async Task Run(CancellationToken softToken, CancellationToken forceToken)
        {
            CancellationToken cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(softToken, forceToken).Token;
            Stage = GenerationStages.Starting;

            while (cancellationToken.IsCancellationRequested == false && _taskProvider.HasTasks)
            {
                Stage = GenerationStages.AwaitingTask;
                RawTask task = _taskProvider.Get(cancellationToken);

                Stage = GenerationStages.GettingChatHistory;
                ChatHistory chatHistory = await _chatHistoryProvider.Get(this, task, cancellationToken);

                Stage = GenerationStages.GeneratingAnswer;
                await _generationHandler.Handle(this, task, chatHistory, forceToken);
            }

            Stage = GenerationStages.Completing;
        }
    }
}
