namespace SauceDemo.Automation.Config;
public sealed class TestSettings
{
    public string ?BaseUrl { get; init; } 
    public string ?Browser { get; init; }
    public bool Headless { get; init; }
    public int ExplicitWaitSeconds { get; init; } 
    public int PageLoadTimeoutSeconds { get; init; } 
    public string ?ReportType { get; init; } 
    public string ?Username { get; init; }
    public string ?Username_invalid { get; init; }
    public string ?Username_wrong { get; init; }
    public string ?Password { get; init; }
    public string ?ScreenshotDirectory { get; init; } 
    public string ?ExtentReportDirectory { get; init; }
    public string ?LogDirectory { get; init; } 
}
