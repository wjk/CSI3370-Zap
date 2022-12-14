namespace Zap.Models;

public sealed class PrimaryModel
{
    private readonly FlowchartContainer _flowchartContainer;
    
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
            if (steps.Count == 1) return Array.Empty<FlowchartStepBase>();

            int count = steps.Count - 1;
            FlowchartStepBase[] newSteps = new FlowchartStepBase[count];
            for (int i = 0; i < count; i++) newSteps[i] = steps[i];

            return newSteps;
        }
    }
}
