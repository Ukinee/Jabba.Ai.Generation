using Microsoft.Extensions.Logging;
using Sume.Generation.Domain;
using Sume.Generation.Handlers;
using Sume.Generation.Services.Abstractions.Components;
using Sume.Generation.Services.Implementations;
using Sume.Generation.TaskProviders.Abstractions;

namespace Sume.Generation.Builders;

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
