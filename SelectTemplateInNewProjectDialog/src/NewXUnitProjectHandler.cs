using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;

namespace SelectTemplateInNewProjectDialogSample;

class NewXUnitProjectHandler : CommandHandler
{
    protected override void Run()
    {
        const string projectTemplateId = "Microsoft.Test.xUnit.CSharp";

        // If false then the first page of the New Project dialog will be skipped
        bool showTemplateSelection = true;

        IdeApp.ProjectOperations.NewSolution(projectTemplateId, showTemplateSelection)
            .Ignore();
    }
}

