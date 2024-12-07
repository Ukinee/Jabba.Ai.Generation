using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Sume.Generation.Setup;

namespace Startup;

class Program
{
    [Experimental("SKEXP0070")]
    static async Task Main(string[] args)
    {
        // BlockingCollection<string> files = new BlockingCollection<string>();
        // IMemoryStore memoryStore = null;
        // IVectorStore vectorStore = null;

        IKernelBuilder builder = Kernel.CreateBuilder()
            .SetupCore()
            .SetupGeneration();
        
        Kernel kernel = builder.Build();
    }
}
