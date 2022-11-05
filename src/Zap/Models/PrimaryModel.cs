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
}
