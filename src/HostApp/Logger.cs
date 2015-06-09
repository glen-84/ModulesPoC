using System.Diagnostics;

public class Logger : ILogger
{
    public void Log(string message, params object[] arguments)
    {
        Debug.WriteLine(message, arguments);
    }
}