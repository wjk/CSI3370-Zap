namespace Zap.Models.Steps;

public class InitialStep : FlowchartStepBase
{
    private string? _userResponseText;

    public override string PromptText
    {
        get => "Please select one of the buttons below to navigate to the assistant option you want.";
    }
    
    public override string? UserResponseText => _userResponseText;

    public override IList<StepAction> Actions
    {
        get => new[] { new StepAction("Food", "Food", FoodAction) };
    }

    private FlowchartStepBase FoodAction()
    {
        _userResponseText = "Food";
        return new FoodTypeStep();
    }
}