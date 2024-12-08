namespace Sume.Generation.Common;

public static class GenerationStages
{
    public const string Starting = "Starting_GenerationLongOperationHandler";

    #region WorkLoop

    public const string AwaitingTask = "Awaiting_Task";

    #region ChatHistory

    public const string GettingChatHistory = "Getting_Chat_History";

    public const string GettingTaskData = "Getting_Task_Data";
    public const string GeneratingChatHistory = "Generating_Chat_History";

    #endregion

    #region GeneratingAnswer

    public const string GeneratingAnswer = "Generating_Answer";

    public const string GettingGenerationResult = "Getting_Generation_Result";
    public const string ConsumingGenerationResult = "Consuming_Generation_Result";

    #endregion

    #endregion

    public const string Completing = "Completing_GenerationLongOperationHandler";
}
