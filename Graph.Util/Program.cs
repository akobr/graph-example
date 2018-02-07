using CommonServiceLocator;
using Graph.Model;
using Graph.Util.Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace Graph.Util
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Activator.Initialise();

            IArgumentsParser parser = ServiceLocator.Current.GetInstance<IArgumentsParser>();
            parser.Parse(args);

            using (TextWriter writer = new StreamWriter(Console.OpenStandardOutput()))
            {
                if (!parser.AreValid || parser.IsHelpPageRequested)
                {
                    ShowHelp(writer);
                    Console.ReadLine();
                    return;
                }

                ProcessGraph(parser, writer);
            }

            Console.ReadLine();
        }

        private static void ProcessGraph(IArgumentsParser parser, TextWriter writer)
        {
            IGraphLoader loader = ServiceLocator.Current.GetInstance<IGraphLoader>();
            IList<Node> graph = loader.LoadGraph(parser.Path, writer);

            IGraphStorageService storage = ServiceLocator.Current.GetInstance<IGraphStorageService>();

            if (parser.UseRecreationMode)
            {
                storage.DeleteGraph();
                writer.WriteLine("Old graph has been deleted.");
            }

            storage.SaveGraph(graph);
            writer.WriteLine("Graph data has been saved.");
            writer.Flush();
        }

        private static void ShowHelp(TextWriter writer)
        {
            IHelpGenerator generator = ServiceLocator.Current.GetInstance<IHelpGenerator>();
            generator.Generate(writer);
        }
    }
}
