using Zap.Models;

namespace Zap.Services;

public sealed class FlowchartContainer
{
    private readonly Dictionary<string, List<FlowchartStepBase>>
        _stepCache = new Dictionary<string, List<FlowchartStepBase>>();

    public string CreateNewStepStack()
    {
        string stackId = Guid.NewGuid().ToString("B");
        _stepCache[stackId] = new List<FlowchartStepBase>();
        return stackId;
    }

    public void DestroyStepStack(string stackId)
    {
        _stepCache.Remove(stackId);
    }

    public IReadOnlyList<FlowchartStepBase> GetStepStack(string stackId)
    {
        if (_stepCache.TryGetValue(stackId, out var value)) return value;
        _stepCache[stackId] = new List<FlowchartStepBase>();
        return _stepCache[stackId];
    }

    public FlowchartStepBase GetCurrentStep(string stackId)
    {
        return _stepCache[stackId].Last();
    }

    public void PushStep(string stackId, FlowchartStepBase step)
    {
        var stack = _stepCache[stackId];
        stack.Add(step);
    }

    public void PopStep(string stackId)
    {
        var list = _stepCache[stackId];
        list.RemoveAt(list.Count - 1);
    }
}
