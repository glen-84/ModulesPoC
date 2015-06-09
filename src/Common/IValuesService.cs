using System.Collections.Generic;

public interface IValuesService
{
    IEnumerable<string> FindAll();

    string Find(int id);
}