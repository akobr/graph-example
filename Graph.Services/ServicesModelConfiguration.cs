using Graph.Model;
using System;
using System.Configuration;

namespace Graph.Services
{
    public class ServicesModelConfiguration : IModelConfiguration
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    }
}