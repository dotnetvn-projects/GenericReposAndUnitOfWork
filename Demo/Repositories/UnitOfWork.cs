using Demo.DataContext;
using System;
using System.Threading.Tasks;

namespace Demo.Repositories
{
    public class UnitOfWork : IDisposable
    {
        public DemoDbContext DbContext { get; }

        public IRepository<News> NewsRepository { get; }
        public IRepository<Product> ProductRepository { get; }

        public UnitOfWork(DemoDbContext context,
             IRepository<News> news,
             IRepository<Product> product)
        {
            DbContext = context;
            NewsRepository = news;
            NewsRepository.DbContext = DbContext;

            ProductRepository = product;
            ProductRepository.DbContext = DbContext;    
        }

        public int SaveChanges()
        {
            var iResult = DbContext.SaveChanges();
            return iResult;
        }

        public async Task<int> SaveChangesAsync()
        {
            var iResult = await DbContext.SaveChangesAsync();
            return iResult;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
