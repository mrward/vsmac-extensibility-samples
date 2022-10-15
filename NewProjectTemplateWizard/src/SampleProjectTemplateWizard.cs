using MonoDevelop.Ide.Templates;

namespace NewProjectTemplateWizardSample;

class SampleProjectTemplateWizard : TemplateWizard
{
    public override string Id => "NewProjectTemplateWizardSample.SampleProjectTemplateWizard";

    public override WizardPage GetPage(int pageNumber)
    {
        return new SampleProjectTemplateWizardPage(this);
    }
}

