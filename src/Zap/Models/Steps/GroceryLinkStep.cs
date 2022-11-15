namespace Zap.Models.Steps;

public class GroceryLinkStep : FlowchartStepBase
{
    private readonly string _storeName;
    private readonly string _prompt;
    private readonly string _storeSite;

    public GroceryLinkStep(string storeName, string action)
    {
        _storeName = storeName;

        string actionText = action switch
        {
            "Pickup" => "pick-up in store",
            "Delivery" => "delivery",
            _ => throw new ArgumentException("Invalid action")
        };

        _storeSite = _storeName switch
        {
            "Kroger" => "Kroger.com",
            "Meijer" => "Meijer.com",
            "Walmart" => "Walmart.com",
            _ => throw new ArgumentException("Invalid storeName")
        };

        _prompt = "Sign in or make an account at " + _storeSite + ". During checkout, " +
                  "select " + actionText + " during checkout after you have all the items " +
                  "that you want in your cart.";
        if (action == "Delivery") _prompt += " Be sure to select a good time and date for delivery.";
    }

    public override string PromptText => _prompt;

    public override IList<StepAction> Actions => Array.Empty<StepAction>();

    public override IReadOnlyList<(string title, string href)> ExternalLinks
    {
        get
        {
            var links = new List<(string, string)>();

            string href = _storeName switch
            {
                "Kroger" => "https://www.kroger.com/signin?redirectUrl=/",
                "Meijer" => "https://accounts.meijer.com/manage/Account#/form/user",
                "Walmart" => "https://www.walmart.com/account/login?vid=oaoh&tid=0&returnUrl=%2F",
                _ => throw new ArgumentException($"Unrecognized store name '{_storeName}")
            };
                
            links.Add((_storeSite, href));
            return links;
        }
    }
}