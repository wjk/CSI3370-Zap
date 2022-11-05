using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Zap.Models;

namespace Zap.Controllers;

public class HomeController : Controller
{
    private SessionAccess _sessionAccess;
    private FlowchartContainer _flowchartContainer;

    public HomeController(SessionAccess session, FlowchartContainer container)
    {
        _sessionAccess = session;
        _flowchartContainer = container;
    }
    
    public IActionResult Index()
    {
        if (_sessionAccess.IsSignedIn())
            return LocalRedirect("/Home/Chatbot");
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Chatbot()
    {
        PrimaryModel model = new PrimaryModel(_flowchartContainer, _flowchartContainer.CreateNewStepStack());
        return View(model);
    }

    [Route("/Home/Chatbot/{actionName}")]
    [HttpPost]
    public IActionResult Chatbot(PrimaryModel model, string actionName)
    {
        var lastStep = model.LastStep;
        var action = lastStep.Actions.Single(a => a.Identifier == actionName);
        var newStep = action.Implementation();
        _flowchartContainer.PushStep(model.FlowchartKey, newStep);
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
