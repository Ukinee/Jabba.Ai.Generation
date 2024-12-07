using System.Diagnostics.CodeAnalysis;
using Microsoft.SemanticKernel.Connectors.Ollama;
using OllamaSharp;

namespace Sume.Common
{
    public class OllamaConfigs
    {
        private const string ChatModel = "phi3";
        private const string EmbeddingModel = "phi3";
        private const string OllamaUriString = "http://127.0.0.1:11434";

        public static OllamaApiClient.Configuration ChatConfiguration => new OllamaApiClient.Configuration()
        {
            Model = ChatModel,
            Uri = OllamaUri,
        };
        
        public static OllamaApiClient.Configuration EmbeddingConfiguration => new OllamaApiClient.Configuration()
        {
            Model = EmbeddingModel,
            Uri = OllamaUri,
        };

        [Experimental("SKEXP0070")]
        public static OllamaPromptExecutionSettings PromptExecutionSettings => new OllamaPromptExecutionSettings
        {
            ModelId = ChatModel,
            FunctionChoiceBehavior = null,
            ExtensionData = null,
            Stop = null,
            TopK = null,
            TopP = null,
            Temperature = null,
        };

        private static Uri OllamaUri => new Uri(OllamaUriString);
    }
}
