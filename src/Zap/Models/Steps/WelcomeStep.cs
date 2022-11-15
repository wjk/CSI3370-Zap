namespace Zap.Models.Steps;

public class WelcomeStep : FlowchartStepBase
{
    public override string PromptText
    {
        get => "Hello there! My name is ZAP and I will be your chatbot assistant for today. " +
               "I am equipped to assist you with transportation, food, medicine, and keeping " +
               "in touch with friends and family.";
    }

    public override IList<StepAction> Actions { get; } = Array.Empty<StepAction>();
}