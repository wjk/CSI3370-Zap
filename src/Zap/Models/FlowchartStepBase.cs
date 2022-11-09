namespace Zap.Models;

public abstract class FlowchartStepBase
{
    public abstract string PromptText { get; }
    
    public abstract string? UserResponseText { get; }

    public abstract IList<StepAction> Actions { get; }

    public virtual IReadOnlyList<(string title, string href)> ExternalLinks => Array.Empty<(string, string)>();

    public record StepAction(string Identifier, string UserVisibleText, Func<FlowchartStepBase> Implementation);
}
