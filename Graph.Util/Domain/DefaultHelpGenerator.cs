using System.IO;

namespace Graph.Util.Domain
{
    public class DefaultHelpGenerator : IHelpGenerator
    {
        public void Generate(TextWriter targetWriter)
        {
            targetWriter.WriteLine("Load a graph into a database, from a specified directory.");
            targetWriter.WriteLine();
            targetWriter.WriteLine("GRAPH.UTIL directory-path [/R] [/C [connection-string-to-db]]");
            targetWriter.WriteLine();
            targetWriter.WriteLine("/R\t\tA graph in database will be recreated. The old graph will be deleted and new one is created.");
            targetWriter.WriteLine("/C\t\tSpecify a database connection string. By default the connection string from app.config file is used.");
            targetWriter.WriteLine();
            targetWriter.Flush();
        }
    }
}
