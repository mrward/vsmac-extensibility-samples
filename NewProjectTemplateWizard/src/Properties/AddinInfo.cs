using System.Runtime.Versioning;
using Mono.Addins;

[assembly: Addin(
    "NewProjectTemplateWizardSample",
    Namespace = "Microsoft.VisualStudioMac.Extensibility.Samples",
    Version = "0.1",
    Category = "IDE extensions")]

[assembly: AddinName("NewProjectTemplateWizardSample")]
[assembly: AddinDescription("Extension that has a new project template wizard")]

// Need to fix CA1416 build warning.
// This call site is reachable on all platforms. 'NSLayoutConstraint.Active' is only supported on: 'ios' 10.0 and later,
// 'maccatalyst' 10.0 and later, 'macOS/OSX' 10.14 and later, 'tvos' 10.0 and later. (CA1416))
// https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1416
[assembly: SupportedOSPlatform("macos10.14")]
