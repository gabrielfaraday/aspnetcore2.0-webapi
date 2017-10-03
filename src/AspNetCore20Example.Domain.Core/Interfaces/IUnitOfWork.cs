using System;

namespace AspNetCore20Example.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
