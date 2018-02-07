using CommonServiceLocator;
using Graph.Model.Interfaces;
using System.Collections.Generic;

namespace Graph.Model
{
    public class GraphStorageService : IGraphStorageService
    {
        public IEnumerable<INode> RetrieveGraph()
        {
            using (IUnitOfWork work = ServiceLocator.Current.GetInstance<IUnitOfWork>())
            {
                return work.GetGenericRepository<Node>().Entities;
            }
        }

        public void SaveGraph(IList<Node> nodes)
        {
            using (IUnitOfWork work = ServiceLocator.Current.GetInstance<IUnitOfWork>())
            using (IUnitTransaction transaction = work.Transaction)
            {
                IGenericDataContext<Node> nodeRepository = work.GetGenericRepository<Node>();
                IGenericDataContext<Edge> edgeRepository = work.GetGenericRepository<Edge>();

                foreach (Node node in nodes)
                {
                    nodeRepository.Insert(node);

                    foreach (Edge edge in node.OutEdges)
                    {
                        edgeRepository.Insert(edge);
                    }
                }

                transaction.Commit();
                work.Save();
            }
        }

        public void DeleteGraph()
        {
            using (IUnitOfWork work = ServiceLocator.Current.GetInstance<IUnitOfWork>())
            using (IUnitTransaction transaction = work.Transaction)
            {
                IGenericDataContext<Edge> edgeRepository = work.GetGenericRepository<Edge>();
                IGenericDataContext<Node> nodeRepository = work.GetGenericRepository<Node>();

                edgeRepository.Entities.RemoveRange(edgeRepository.Entities);
                nodeRepository.Entities.RemoveRange(nodeRepository.Entities);

                transaction.Commit();
                work.Save();
            }
        }
    }
}
