using CommonServiceLocator;
using Graph.Util.Arguments;
using Graph.Util.Help;
using System;
using System.IO;
using System.Linq;

namespace Graph.Util
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Activator.Initialise();

            IArgumentsParser parser = ServiceLocator.Current.GetInstance<IArgumentsParser>();
            parser.Parse(args);

            if (!parser.AreValid || parser.IsHelpPageRequested)
            {
                ShowHelp();
            }

            Console.WriteLine("TODO: Process a graph.");
            Console.ReadLine();
        }

        private static void ShowHelp()
        {
            IHelpGenerator generator = ServiceLocator.Current.GetInstance<IHelpGenerator>();

            using (Stream stream = Console.OpenStandardOutput())
            {
                generator.GenerateAsync(stream);
            }
        }
    }
}
