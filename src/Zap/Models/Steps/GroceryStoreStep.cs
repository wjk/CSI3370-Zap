namespace Zap.Models.Steps;

public class GroceryStoreStep : FlowchartStepBase
{
    public override string PromptText
    {
        get => "Where do you want to shop for your groceries?";
    }

    public override IList<StepAction> Actions => new[]
    {
        new StepAction("Kroger", "Kroger", KrogerAction),
        new StepAction("Meijer", "Meijer", MeijerAction),
        new StepAction("Walmart", "Walmart", WalmartAction),
    };

    private FlowchartStepBase KrogerAction()
    {
        UserResponseText = "Kroger";
        return new GroceryDeliveryStep("Kroger");
    }

    private FlowchartStepBase MeijerAction()
    {
        UserResponseText = "Meijer";
        return new GroceryDeliveryStep("Meijer");
    }

    private FlowchartStepBase WalmartAction()
    {
        UserResponseText = "Walmart";
        return new GroceryDeliveryStep("Walmart");
    }
}