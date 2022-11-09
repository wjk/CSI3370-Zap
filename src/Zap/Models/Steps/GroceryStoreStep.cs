namespace Zap.Models.Steps;

public class GroceryStoreStep : FlowchartStepBase
{
    private string? _userResponseText;
    
    public override string PromptText
    {
        get => "Where do you want to shop for your groceries?";
    }

    public override string? UserResponseText => _userResponseText;
    public override IList<StepAction> Actions => new[]
    {
        new StepAction("Kroger", "Kroger", KrogerAction),
        new StepAction("Meijer", "Meijer", MeijerAction),
        new StepAction("Walmart", "Walmart", WalmartAction),
    };

    private FlowchartStepBase KrogerAction()
    {
        _userResponseText = "Kroger";
        return new GroceryDeliveryStep("Kroger");
    }

    private FlowchartStepBase MeijerAction()
    {
        _userResponseText = "Meijer";
        return new GroceryDeliveryStep("Meijer");
    }

    private FlowchartStepBase WalmartAction()
    {
        _userResponseText = "Walmart";
        return new GroceryDeliveryStep("Walmart");
    }
}