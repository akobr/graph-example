using Graph.Model;
using System.Configuration;

namespace Graph.Util.Domain
{
    public class UtilModelConfiguration : IModelConfiguration
    {
        public string ConnectionString
            => ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    }
}
