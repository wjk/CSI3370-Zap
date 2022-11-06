namespace Zap.Models.Steps;

public class StubStep : FlowchartStepBase
{
    public override string PromptText
    {
        get => "Unfortunately, this option is not currently supported.";
    }

    public override string? UserResponseText => null;
    
    public override IList<StepAction> Actions => Array.Empty<StepAction>();
}