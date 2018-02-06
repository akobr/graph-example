using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Graph.Util.Help
{
    public class DefaultHelpGenerator : IHelpGenerator
    {
        public async Task GenerateAsync(Stream target)
        {
            using (TextWriter writer = new StreamWriter(target, Console.OutputEncoding, 1024, true))
            {
                await writer.WriteLineAsync("Load a graph into a database, from a specified directory.");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("GRAPH.UTIL directory-path [/U] [/R] [/C [connection-string-to-db]]");
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("/U\t\tThe unidirectional mode: A oriented graph will be created. By default a non-oriented graph is created.");
                await writer.WriteLineAsync("/R\t\tA graph in database will be recreated. The old graph will be deleted and new one is created.");
                await writer.WriteLineAsync("/C\t\tSpecify a database connection string. By default the connection string from app.config file is used.");
                await writer.WriteLineAsync();
            }
        }
    }
}
