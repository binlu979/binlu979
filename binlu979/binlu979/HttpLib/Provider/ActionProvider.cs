using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace binlu979.HttpLib.Provider
{
    public interface ActionProvider
    {
        Action<HttpWebRequest> Make { get; }
        Action<WebHeaderCollection, Stream> Success {get;}
        Action<WebException> Fail { get; }
    }
}
