using Jabba.Complex.LongOperations.Handlers;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel.ChatCompletion;
using Sume.Generation.Domain;
using Sume.Generation.Services.Abstractions;
using Sume.Generation.TaskProviders.Abstractions;

namespace Sume.Generation.Handlers
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

            while (cancellationToken.IsCancellationRequested == false && _taskProvider.HasTasks)
            {
                RawTask task = _taskProvider.Get(cancellationToken);
                ChatHistory chatHistory = await _chatHistoryProvider.Get(task, cancellationToken);
                
                await _generationHandler.Handle(task, chatHistory, forceToken);
            }
        }
    }
}
