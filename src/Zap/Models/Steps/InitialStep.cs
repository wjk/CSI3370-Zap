namespace Zap.Models.Steps;

public class InitialStep : FlowchartStepBase
{ 
    public override string PromptText
    {
        get => "Please select one of the buttons below to navigate to the assistant option you want.";
    }

    public override IList<StepAction> Actions
    {
        get => new[] { new StepAction("Food", "Food", FoodAction) };
    }

    private FlowchartStepBase FoodAction()
    {
        UserResponseText = "Food";
        return new FoodTypeStep();
    }
}