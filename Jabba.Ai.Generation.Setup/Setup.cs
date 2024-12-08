using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using OllamaSharp;
using Jabba.Ai.Generation.Builders;

namespace Jabba.Ai.Generation.Setup
{
    public static class Setup
    {
        [Experimental("SKEXP0070")]
        public static IKernelBuilder SetupGeneration(this IKernelBuilder builder, OllamaApiClient.Configuration chatConfig, OllamaApiClient.Configuration embeddingConfig)
        {
            return builder
                .SetupServices()
                .SetupOllama(chatConfig, embeddingConfig);
        }

        [Experimental("SKEXP0070")]
        private static IKernelBuilder SetupOllama(this IKernelBuilder builder, OllamaApiClient.Configuration chatConfig, OllamaApiClient.Configuration embeddingConfig)
        {
            OllamaApiClient chatClient = new OllamaApiClient(chatConfig);
            OllamaApiClient embeddingClient = new OllamaApiClient(embeddingConfig);
            
            builder.AddOllamaChatCompletion(chatClient);
            builder.AddOllamaTextEmbeddingGeneration(embeddingClient);

            return builder;
        }

        private static IKernelBuilder SetupServices(this IKernelBuilder builder)
        {
            builder.Services.AddTransient<GenerationLongOperationHandlerBuilder>();
            builder.Services.AddKernel();
            
            return builder;
        }
    }
}
