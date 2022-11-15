namespace Zap.Models.Steps;

public class GroceryDeliveryStep : FlowchartStepBase
{
    private readonly string _storeName;

    public GroceryDeliveryStep(string storeName)
    {
        _storeName = storeName;
    }

    public override string PromptText
    {
        get => "Do you want to pick up your groceries or have them delivered?";
    }

    public override IList<StepAction> Actions => new[]
    {
        new StepAction("Deliver", "Delivery", DeliveryAction),
        new StepAction("PickUp", "Pick up in store", PickUpAction),
    };

    private FlowchartStepBase DeliveryAction()
    {
        UserResponseText = "Delivery";
        return new GroceryLinkStep(_storeName, "Delivery");
    }

    private FlowchartStepBase PickUpAction()
    {
        UserResponseText = "Pick up in store";
        return new GroceryLinkStep(_storeName, "Pickup");
    }
}