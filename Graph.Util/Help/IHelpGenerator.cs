using System.IO;
using System.Threading.Tasks;

namespace Graph.Util.Help
{
    public interface IHelpGenerator
    {
        Task GenerateAsync(Stream target);
    }
}
