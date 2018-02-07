using System.Collections.Generic;
using System.IO;
using Graph.Model;

namespace Graph.Util.Domain
{
    public interface IGraphLoader
    {
        IList<Node> LoadGraph(string directoryPath, TextWriter targetWriter);
    }
}