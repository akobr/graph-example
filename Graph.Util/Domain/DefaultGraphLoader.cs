using Graph.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Graph.Util.Domain
{
    public class DefaultGraphLoader : IGraphLoader
    {
        public IList<Node> LoadGraph(string directoryPath, TextWriter targetWriter)
        {
            List<Node> nodes = new List<Node>();

            targetWriter.WriteLine($"Processing specified directory: {directoryPath}");
            string[] filePaths = Directory.GetFiles(directoryPath, "*.xml");

            targetWriter.WriteLine($"{filePaths.Length} files have been found.");
            targetWriter.WriteLine();
            targetWriter.Flush();

            foreach (string filePath in filePaths)
            {
                targetWriter.WriteLine($"Processing file: {Path.GetFileName(filePath)}");
                Node newNode = BuildNode(LoadXmlFile(filePath), targetWriter);
                targetWriter.Flush();

                if (newNode != null)
                {
                    nodes.Add(newNode);
                }
            }

            return nodes;
        }

        private Node BuildNode(XDocument xmlDocument, TextWriter targetWriter)
        {
            try
            {
                Node newNode = new Node()
                {
                    Id = int.Parse(xmlDocument.Root.Element("id").Value),
                    Label = xmlDocument.Root.Element("label").Value
                };

                foreach (XElement adjacentNode in xmlDocument.Root.Element("adjacentNodes").Elements())
                {
                    newNode.OutEdges.Add(
                        new Edge()
                        {
                            IdFrom = newNode.Id,
                            IdTo = int.Parse(adjacentNode.Value)
                        });
                }

                return newNode;
            }
            catch (Exception exception)
            {
                targetWriter.WriteLine($"Node parsing error: {exception.Message}");
                return null;
            }
        }

        private XDocument LoadXmlFile(string filePath)
        {
            using (TextReader reader = new StreamReader(filePath))
            {
                return XDocument.Load(reader);
            }
        }
    }
}
