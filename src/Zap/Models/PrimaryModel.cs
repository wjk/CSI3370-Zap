namespace Zap.Models;

public sealed class PrimaryModel
{
    private FlowchartContainer _flowchartContainer;
    
    public PrimaryModel(FlowchartContainer container, string stackId)
    {
        _flowchartContainer = container;
        FlowchartKey = stackId;
    }
    
    public string FlowchartKey { get; }

    public IReadOnlyList<FlowchartStepBase> Steps => _flowchartContainer.GetStepStack(FlowchartKey);

    public FlowchartStepBase LastStep => _flowchartContainer.GetCurrentStep(FlowchartKey);

    public IReadOnlyList<FlowchartStepBase> PreviousSteps
    {
        get
        {
            var steps = _flowchartContainer.GetStepStack(FlowchartKey);

            int count = steps.Count - 1;
            FlowchartStepBase[] newSteps = new FlowchartStepBase[count];
            for (int i = 0; i < count; i++) newSteps[i] = steps[i];

            return newSteps;
        }
    }
}
