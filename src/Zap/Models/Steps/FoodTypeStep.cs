namespace Zap.Models.Steps;

public class FoodTypeStep : FlowchartStepBase
{
    private string? _userResponseText = null;

    public override string PromptText
    {
        get => "What kind of food are you interested in?";
    }
    
    public override string? UserResponseText => _userResponseText;

    public override IList<StepAction> Actions => new[]
    {
        new StepAction("Groceries", "Groceries", GroceriesAction),
        new StepAction("FastFood", "Fast Food", FastFoodAction),
        new StepAction("Restaurant", "Restaurant", RestaurantAction),
    };

    private FlowchartStepBase GroceriesAction()
    {
        _userResponseText = "Groceries";
        return new StubStep();
    }

    private FlowchartStepBase FastFoodAction()
    {
        _userResponseText = "Fast Food";
        return new StubStep();
    }

    private FlowchartStepBase RestaurantAction()
    {
        _userResponseText = "Restaurant";
        return new StubStep();
    }
}