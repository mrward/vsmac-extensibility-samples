
using AppKit;
using MonoDevelop.Core;
using MonoDevelop.Ide.Templates;

namespace NewProjectTemplateWizardSample;

class SampleProjectTemplateWizardPageView : NSView
{
    NSTextField projectNameTextField;
    NSScrollView scrollView;

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

        mainStackView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
        mainStackView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;

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

        scrollView = new NSScrollView();
        scrollView.AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable;
        scrollView.HasVerticalScroller = true;

        var checkboxStackView = new NSStackView();
        checkboxStackView.Orientation = NSUserInterfaceLayoutOrientation.Vertical;
        checkboxStackView.TranslatesAutoresizingMaskIntoConstraints = false;
        scrollView.DocumentView = checkboxStackView;;

        mainStackView.AddArrangedSubview(scrollView);

        scrollView.TopAnchor.ConstraintEqualTo(projectNameStackView.BottomAnchor, 10).Active = true;
        scrollView.BottomAnchor.ConstraintEqualTo(mainStackView.BottomAnchor).Active = true;

        AddCheckBoxes(checkboxStackView);
    }

    void AddCheckBoxes(NSStackView stackView)
    {
        for (int i = 0; i < 20; i++)
        {
            var checkbox = new NSButton();
            checkbox.Title = $"Button {i}";
            checkbox.SetButtonType(NSButtonType.Switch);

            stackView.AddArrangedSubview(checkbox);
        }
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

