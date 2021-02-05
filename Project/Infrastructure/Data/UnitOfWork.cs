using ApplicationCore.Interfaces;
using Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogDbContext _dbContext;
        private ApplicationDbContext _applicationDbContext;
        public ICurrencyRepository currencyRepository { get; set; }
        public ICurrencyHistoryRepository currencyHistoryRepository { get; set; }

        public UnitOfWork(BlogDbContext dbContext, ICurrencyRepository currencyRepository, ICurrencyHistoryRepository currencyHistoryRepository, ApplicationDbContext applicationDbContext)
        {
            _dbContext = dbContext;
            this.currencyRepository = currencyRepository;
            this.currencyHistoryRepository = currencyHistoryRepository;
            _applicationDbContext = applicationDbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
            _applicationDbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.Dispose(); 
            _applicationDbContext.Dispose(); 
        }
    }
}
