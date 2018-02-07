using System;

namespace Graph.Model
{
    public interface IUnitTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}