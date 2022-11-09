namespace Zap.Models.Steps;

public class GroceryDeliveryStep : FlowchartStepBase
{
    private readonly string _storeName;
    private string? _userResponseText;

    public GroceryDeliveryStep(string storeName)
    {
        _storeName = storeName;
    }

    public override string PromptText
    {
        get => "Do you want to pick up your groceries or have them delivered?";
    }
    
    public override string? UserResponseText => _userResponseText;

    public override IList<StepAction> Actions => new[]
    {
        new StepAction("Deliver", "Delivery", DeliveryAction),
        new StepAction("PickUp", "Pick up in store", PickUpAction),
    };

    private FlowchartStepBase DeliveryAction()
    {
        _userResponseText = "Delivery";
        return new GroceryLinkStep(_storeName, "Delivery");
    }

    private FlowchartStepBase PickUpAction()
    {
        _userResponseText = "Pick up in store";
        return new GroceryLinkStep(_storeName, "Pickup");
    }
}