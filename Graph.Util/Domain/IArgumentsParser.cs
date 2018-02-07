namespace Graph.Util.Domain
{
    public interface IArgumentsParser
    {
        bool AreValid { get; }

        string Path { get; }

        bool UseRecreationMode { get; }

        bool IsHelpPageRequested { get; }

        void Parse(string[] arguments);
    }
}
