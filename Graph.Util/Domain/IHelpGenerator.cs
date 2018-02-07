using System.IO;

namespace Graph.Util.Domain
{
    public interface IHelpGenerator
    {
        void Generate(TextWriter targetWriter);
    }
}
