
using MonoDevelop.Components;
using MonoDevelop.Core;
using MonoDevelop.Ide.Projects;
using MonoDevelop.Ide.Templates;

namespace NewProjectTemplateWizardSample;

class SampleProjectTemplateWizardPage : WizardPage
{
    SampleProjectTemplateWizard wizard;
    SampleProjectTemplateWizardPageView? view;
    string? projectName;

    public SampleProjectTemplateWizardPage(SampleProjectTemplateWizard wizard)
    {
        this.wizard = wizard;

        UpdateCanMoveNext();
    }

    public override string Title => GettextCatalog.GetString("Configure your Sample Extension");

    public string? ProjectName
    {
        get
        {
            return projectName;
        }
        set
        {
            projectName = value?.Trim();
            wizard.Parameters["ProjectName"] = projectName ?? string.Empty;
            UpdateCanMoveNext();
        }
    }

    void UpdateCanMoveNext()
    {
        CanMoveToNextPage = !string.IsNullOrEmpty(projectName);
    }

    protected override object CreateNativeWidget<T> ()
    {
        view ??= new SampleProjectTemplateWizardPageView(this);
        return view;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && view != null)
        {
            view.Dispose();
            view = null;
        }
        base.Dispose(disposing);
    }
}

