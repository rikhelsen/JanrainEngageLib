using System.Collections.Generic;
using System.Xml.Linq;

namespace EngageLib.Interfaces
{
    public interface IEngageApiWrapper
    {
        XElement Call(string methodName, IDictionary<string, string> queryData);
    }
}