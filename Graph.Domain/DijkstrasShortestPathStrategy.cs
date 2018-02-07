using Graph.Domain.Structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.Domain
{
    public class DijkstrasShortestPathStrategy : IShortestPathStrategy
    {
        public ICollection<int> FindShortestPath(IGraph graph, IGraphNode fromNode, IGraphNode toNode)
        {
            graph.Clean();
            PriorityQueue<IGraphNode, int> priorityQueue = new PriorityQueue<IGraphNode, int>();

            fromNode.Weight = 0;
            priorityQueue.Enqueue(fromNode, 0);

            while (priorityQueue.Count > 0)
            {
                IGraphNode node = priorityQueue.Dequeue();

                foreach (IGraphNode successor in node.Successors)
                {
                    int newWeight = node.Weight + 1;

                    if (newWeight >= successor.Weight)
                    {
                        continue;
                    }

                    successor.Weight = newWeight;
                    successor.PreviousNode = node;
                    priorityQueue.Enqueue(successor, successor.Weight);
                }
            }

            return BuildPath(toNode);
        }

        private ICollection<int> BuildPath(IGraphNode toNode)
        {
            if (toNode.Weight == int.MaxValue)
            {
                return new List<int>();
            }

            LinkedList<int> path = new LinkedList<int>();
            path.AddFirst(toNode.Id);

            IGraphNode node = toNode;
            while ((node = node.PreviousNode) != null)
            {
                path.AddFirst(node.Id);
            }

            return path;
        }
    }
}
