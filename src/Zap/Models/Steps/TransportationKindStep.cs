namespace Zap.Models.Steps;

public class TransportationKindStep : FlowchartStepBase
{
    public override string PromptText
    {
        get => "What kind of transportation assistance do you need?";
    }

    public override IList<StepAction> Actions => new[]
    {
        new StepAction("Database", "A database of transportation services", DatabaseAction),
        new StepAction("LongDistance", "Long-distance medical transportation", LongDistanceAction),
        new StepAction("NonMedical", "Non-medical transportation", NonMedicalAction)
    };

    private FlowchartStepBase DatabaseAction()
    {
        UserResponseText = "A database of transportation services";
        return new TransportationLeafStep(TransportationLeafStep.Provider.MyRide2);
    }

    private FlowchartStepBase LongDistanceAction()
    {
        UserResponseText = "Long-distance medical transportation";
        return new TransportationLeafStep(TransportationLeafStep.Provider.TransMedicare);
    }

    private FlowchartStepBase NonMedicalAction()
    {
        UserResponseText = "Non-medical transportation";
        return new TransportationLeafStep(TransportationLeafStep.Provider.AngelCaret);
    }
}