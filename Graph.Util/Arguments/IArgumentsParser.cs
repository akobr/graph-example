namespace Graph.Util.Arguments
{
    public interface IArgumentsParser
    {
        bool AreValid { get; }

        string Path { get; }

        bool UseUnidirectionalMode { get; }

        bool UseRecreationMode { get; }

        bool HasConnectionString { get; }

        string ConnectionString { get; }

        bool IsHelpPageRequested { get; }

        void Parse(string[] arguments);
    }
}
