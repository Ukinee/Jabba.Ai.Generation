using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using OllamaSharp;
using Sume.Common;
using Sume.Common.Configs;
using Sume.Generation.Builders;

namespace Sume.Generation.Setup
{
    public static class Setup
    {
        [Experimental("SKEXP0070")]
        public static IKernelBuilder SetupGeneration(this IKernelBuilder builder)
        {
            return builder
                .SetupServices()
                .SetupOllama();
        }

        [Experimental("SKEXP0070")]
        private static IKernelBuilder SetupOllama(this IKernelBuilder builder)
        {
            OllamaApiClient chatClient = new OllamaApiClient(OllamaConfigs.GenerationConfig);
            OllamaApiClient embeddingClient = new OllamaApiClient(OllamaConfigs.EmbeddingConfig);
            
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
