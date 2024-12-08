using Jabba.Ai.Generation.Domain;
using Microsoft.Extensions.Logging;
using Jabba.Ai.Generation.Handlers.Implementations;
using Jabba.Ai.Generation.Services.Abstractions.Components;
using Jabba.Ai.Generation.Services.Implementations;
using Jabba.Ai.Generation.TaskProviders.Abstractions;

namespace Jabba.Ai.Generation.Builders;

public class GenerationLongOperationHandlerBuilder
{
    private readonly ILoggerFactory _loggerFactory;

    public GenerationLongOperationHandlerBuilder(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public GenerationLongOperationHandler Build<TTaskData, TGenerationResult>
    (
        string name,
        ITaskProvider taskProvider,
        ITaskDataProvider<TTaskData> taskDataProvider,
        IChatHistoryService<TTaskData> chatHistoryService,
        IGenerationResultProvider<TGenerationResult> generationResultProvider,
        IGenerationResultConsumer<TGenerationResult> generationResultConsumer
    )
        where TTaskData : TaskData
        where TGenerationResult : GenerationResult
    {
        ILogger<GenerationLongOperationHandler> logger = _loggerFactory.CreateLogger<GenerationLongOperationHandler>();
        ChatHistoryProvider<TTaskData> chatHistoryProvider = new ChatHistoryProvider<TTaskData>(taskDataProvider, chatHistoryService);
        GenerationHandler<TGenerationResult> generationHandler = new GenerationHandler<TGenerationResult>(generationResultProvider, generationResultConsumer);

        return new GenerationLongOperationHandler(name, logger, taskProvider, chatHistoryProvider, generationHandler);
    }
}
