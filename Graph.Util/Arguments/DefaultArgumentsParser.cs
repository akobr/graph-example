using Graph.Util.Extensions;
using System;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace Graph.Util.Arguments
{
    public class DefaultArgumentsParser : IArgumentsParser
    {
        public DefaultArgumentsParser()
        {
            Reset();
        }

        public bool AreValid { get; private set; }

        public string Path { get; private set; }

        public bool UseUnidirectionalMode { get; private set; }

        public bool UseRecreationMode { get; private set; }

        public bool HasConnectionString => !string.IsNullOrWhiteSpace(ConnectionString);

        public string ConnectionString { get; private set; }

        public bool IsHelpPageRequested { get; private set; }

        public void Parse(string[] arguments)
        {
            Reset();

            if (arguments.Length < 1)
            {
                return;
            }

            string path = arguments[0];

            if (!Directory.Exists(path))
            {
                return;
            }

            Path = path;
            IsHelpPageRequested = false;
            ProcessFlags(arguments);

        }

        private void Reset()
        {
            AreValid = false;
            IsHelpPageRequested = true;

            Path = string.Empty;
            ConnectionString = string.Empty;
            UseRecreationMode = false;
            UseUnidirectionalMode = false;
        }

        private void ProcessFlags(string[] arguments)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                string argument = arguments[i];

                if(IsUnidirectionalModeFlag(argument))
                {
                    UseUnidirectionalMode = true;
                }
                else if(IsRecreationModeFlag(argument))
                {
                    UseRecreationMode = true;
                }
                else if(IsHelpPageRequestedFlag(argument))
                {
                    IsHelpPageRequested = true;
                }
                else if (IsConnectionStringFlag(argument) && i < arguments.Length - 1)
                {
                    string connectionString = arguments[i + 1];
                    if (IsConnectionStringValid(connectionString))
                    {
                        ConnectionString = connectionString;
                    }
                }
            }
        }

        private static bool GetIsHelpPageRequested(string[] arguments)
        {
            return arguments.Any(arg => IsHelpPageRequestedFlag(arg));
        }

        private static bool IsUnidirectionalModeFlag(string argument)
        {
            return argument.CheckRegularExpression(@"^(\/|-)u(nidirectional)?$");
        }

        private static bool IsRecreationModeFlag(string argument)
        {
            return argument.CheckRegularExpression(@"^(\/|-)r(ecreate)?$");
        }

        private static bool IsConnectionStringFlag(string argument)
        {
            return argument.CheckRegularExpression(@"^(\/|-)c(onnection)?$");
        }

        private static bool IsHelpPageRequestedFlag(string argument)
        {
            return argument.CheckRegularExpression(@"^((\/|-)h|help)$");
        }

        private static bool IsConnectionStringValid(string connectionString)
        {
            try
            {
                DbConnectionStringBuilder connectionBuilder = new DbConnectionStringBuilder();
                connectionBuilder.ConnectionString = connectionString;
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

    }
}
