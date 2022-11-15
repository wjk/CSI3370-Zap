namespace Zap.Models.Steps;

public class FoodTypeStep : FlowchartStepBase
{
    public override string PromptText
    {
        get => "What kind of food are you interested in?";
    }
    
    public override IList<StepAction> Actions => new[]
    {
        new StepAction("Groceries", "Groceries", GroceriesAction),
        new StepAction("FastFood", "Fast Food", FastFoodAction),
        new StepAction("Restaurant", "Restaurant", RestaurantAction),
    };

    private FlowchartStepBase GroceriesAction()
    {
        UserResponseText = "Groceries";
        return new GroceryStoreStep();
    }

    private FlowchartStepBase FastFoodAction()
    {
        UserResponseText = "Fast Food";
        return new StubStep();
    }

    private FlowchartStepBase RestaurantAction()
    {
        UserResponseText = "Restaurant";
        return new StubStep();
    }
}