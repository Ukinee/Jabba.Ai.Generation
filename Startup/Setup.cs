using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace Startup
{
    public static class Setup
    {
        public static IKernelBuilder SetupCore(this IKernelBuilder builder)
        {
            builder
                .Services
                .AddLogging();
            
            return builder;
        }
    }
}
