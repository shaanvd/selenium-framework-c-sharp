using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
namespace SauceDemo.Automation.Reporting;
public static class ExtentReportManager
{
    private static readonly object Sync = new();
    private static ExtentReports? _extent;
    private static readonly AsyncLocal<ExtentTest?> Current = new();
    public static bool Enabled { get; private set; }
    public static void Initialise(string reportType, string directory)
    {
        Enabled = reportType.Equals("extent", StringComparison.OrdinalIgnoreCase) ||
                  reportType.Equals("both", StringComparison.OrdinalIgnoreCase);

        if (!Enabled || _extent is not null) return;

        lock (Sync)
        {
            if (_extent is not null) return;

            // 1. Force the path to be absolute, locked to the actual test DLL folder (bin/Debug/net8.0)
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // 2. Safely combine them to guarantee both C# and ExtentReports look in the exact same place
            string absoluteDirectory = Path.GetFullPath(Path.Combine(baseDir, directory));

            // 3. Create the directory safely at the absolute path
            Directory.CreateDirectory(absoluteDirectory);

            // 4. Pass the locked absolute path to the reporter
            string fileName = $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            string fullReportPath = Path.Combine(absoluteDirectory, fileName);

            var reporter = new ExtentSparkReporter(fullReportPath);

            _extent = new ExtentReports();
            _extent.AttachReporter(reporter);
            _extent.AddSystemInfo("Framework", "Selenium C#");
        }
    }
    public static void Start(string name) { if(Enabled) Current.Value = _extent!.CreateTest(name); }
    public static void Pass(string message) { if(Enabled) Current.Value?.Pass(message); }
    public static void Fail(string message, string? screenshot=null) { if(!Enabled)return; Current.Value?.Fail(message); if(screenshot is not null) Current.Value?.AddScreenCaptureFromPath(screenshot); }
    public static void Flush() { if(Enabled) lock(Sync) _extent?.Flush(); }
}
