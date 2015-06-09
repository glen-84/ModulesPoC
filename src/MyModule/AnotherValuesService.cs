using System.Collections.Generic;

public class AnotherValuesService : IValuesService
{
    readonly ILogger _logger;

    public AnotherValuesService(ILogger logger)
    {
        _logger = logger;
    }

    public IEnumerable<string> FindAll()
    {
        _logger.Log("FindAll called");

        return new[] { "value1", "value2", "value3" };
    }

    public string Find(int id)
    {
        _logger.Log("Find called with {0}", id);

        return string.Format("value{0}", id);
    }
}