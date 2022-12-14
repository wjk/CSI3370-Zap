namespace Zap.Services;

public sealed class SessionAccess
{
    public SessionAccess(IHttpContextAccessor accessor)
    {
        Context = accessor.HttpContext!;
    }

    public HttpContext Context { get; }

    public ISession Session => Context.Session;

    public bool IsSignedIn()
    {
        return Session.GetString("AuthenticatedUser") != null;
    }

    public string? FlowchartKey
    {
        get => Session.GetString("Flowchart");
        set => Session.SetString("Flowchart", value ?? string.Empty);
    }
}
