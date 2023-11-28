using Alten.HotelChallenge.Application.Repositories;
using DBFirst.Sample.Project.Models;

namespace Alten.HotelChallenge.SQLServer.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly AltenContext _altenDbContext;

        public Repository(AltenContext altenDbContext)
        {
            _altenDbContext = altenDbContext;
        }

        public AltenContext Context => _altenDbContext;
    }
}
