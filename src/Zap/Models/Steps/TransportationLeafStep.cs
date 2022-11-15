namespace Zap.Models.Steps;

public class TransportationLeafStep : FlowchartStepBase
{
    public enum Provider
    {
        MyRide2,
        TransMedicare,
        AngelCaret
    }

    public TransportationLeafStep(Provider provider)
    {
        _provider = provider;
    }

    private readonly Provider _provider;

    public override string PromptText
    {
        get
        {
            return _provider switch
            {
                Provider.MyRide2 => "To find transportation services, please enter your ZIP Code " +
                                    "in the box that says “Zip Code for Service” and press Search " +
                                    "Providers. You will be matched with community and other transportation " +
                                    "services in your area. You are then able to choose which service " +
                                    "you would like to use.",
                
                Provider.TransMedicare => "For non-emergency medical transportation for distances of 300 " +
                                          "miles or more. Click the link and fill out the form on the page, " +
                                          "or call the number on the page and set up a time and date for " +
                                          "your medical transportation.",
                
                Provider.AngelCaret => "For non-medical transportation services in the counties of South-" +
                                       "eastern Michigan. Fill out the form with the required information to " +
                                       "schedule a pickup time and date.",
                
                _ => throw new ArgumentException("Invalid provider")
            };
        }
    }

    public override IList<StepAction> Actions => Array.Empty<StepAction>();

    public override IReadOnlyList<(string title, string href)> ExternalLinks
    {
        get
        {
            string title, href;

            switch (_provider)
            {
                case Provider.MyRide2:
                    title = "MyRide2";
                    href = "https://wwwm.myride2.com/";
                    break;
                
                case Provider.TransMedicare:
                    title = "TransMedicare";
                    href = "https://trans-medicare.com/contact-us/";
                    break;
                
                case Provider.AngelCaret:
                    title = "AngelCaret Transportation";
                    href = "http://www.angelcarettransportation.com/non-medical-transportation-request-trip";
                    break;
                
                default:
                    throw new ArgumentException("Invalid provider");
            }
            
            var retval = new List<(string title, string href)>();
            retval.Add((title, href));
            return retval;
        }
    }
}