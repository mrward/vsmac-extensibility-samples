
using AppKit;
using MonoDevelop.Core;
using MonoDevelop.Ide.Templates;

namespace NewProjectTemplateWizardSample;

class SampleProjectTemplateWizardPageView : NSView
{
    NSTextField projectNameTextField;

    public override bool IsFlipped => true;

    public SampleProjectTemplateWizardPageView(SampleProjectTemplateWizardPage wizardPage)
    {
        WizardPage = wizardPage;

        TranslatesAutoresizingMaskIntoConstraints = false;

        var mainStackView = new NSStackView();
        mainStackView.EdgeInsets = new NSEdgeInsets(40, 40, 20, 40);
        mainStackView.Orientation = NSUserInterfaceLayoutOrientation.Vertical;
        mainStackView.TranslatesAutoresizingMaskIntoConstraints = false;

        AddSubview(mainStackView);

        var projectNameStackView = new NSStackView();
        projectNameStackView.Spacing = 20;
        projectNameStackView.Orientation = NSUserInterfaceLayoutOrientation.Horizontal;
        projectNameStackView.TranslatesAutoresizingMaskIntoConstraints = false;

        mainStackView.AddArrangedSubview(projectNameStackView);

        var projectNameLabel = new NSTextField();
        projectNameLabel.StringValue = GettextCatalog.GetString("Project Name:");
        projectNameLabel.Editable = false;
        projectNameLabel.Bordered = false;
        projectNameLabel.DrawsBackground = false;
        projectNameLabel.Alignment = NSTextAlignment.Right;
        projectNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
        projectNameStackView.AddArrangedSubview(projectNameLabel);

        projectNameTextField = new NSTextField();
        projectNameTextField.TranslatesAutoresizingMaskIntoConstraints = false;
        projectNameStackView.AddArrangedSubview(projectNameTextField);

        projectNameTextField.WidthAnchor.ConstraintEqualTo(248f).Active = true;

        projectNameTextField.Changed += ProjectNameTextField_Changed;
    }

    void ProjectNameTextField_Changed(object? sender, EventArgs e)
    {
        WizardPage.ProjectName = projectNameTextField.StringValue;
    }

    public SampleProjectTemplateWizardPage WizardPage { get; set; }

    public override bool BecomeFirstResponder()
    {
        return projectNameTextField.BecomeFirstResponder();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            projectNameTextField.Changed -= ProjectNameTextField_Changed;
        }
        base.Dispose(disposing);
    }
}

