using Mono.Addins;

[assembly: Addin(
    "StartupHandlerSample",
    Namespace = "Microsoft.VisualStudioMac.Extensibility.Samples",
    Version = "0.1",
    Category = "IDE extensions")]

[assembly: AddinName("Startup Handler Sample")]
[assembly: AddinDescription("Extension that has a startup handler")]