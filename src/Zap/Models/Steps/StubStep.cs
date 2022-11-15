namespace Zap.Models.Steps;

public class StubStep : FlowchartStepBase
{
    public override string PromptText
    {
        get => "Unfortunately, this option is not currently supported.";
    }

    public override IList<StepAction> Actions => Array.Empty<StepAction>();
}