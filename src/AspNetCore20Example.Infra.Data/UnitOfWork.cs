using AspNetCore20Example.Domain.Core.Interfaces;
using AspNetCore20Example.Infra.Data.Context;

namespace AspNetCore20Example.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}