using Mono.Addins;

[assembly: Addin(
    "SelectTemplateInNewProjectDialogSample",
    Namespace = "Microsoft.VisualStudioMac.Extensibility.Samples",
    Version = "0.1",
    Category = "IDE extensions")]

[assembly: AddinName("Select template in New Project dialog")]
[assembly: AddinDescription("Extension that opens the New Project dialog for a specific template")]