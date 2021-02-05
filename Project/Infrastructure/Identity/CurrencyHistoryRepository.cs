using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class CurrencyHistoryRepository : IdentityGenericRepository<CurrencyHistory>,ICurrencyHistoryRepository
    {
        public CurrencyHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<CurrencyHistory>> GetAllWithUser()
        {
            return await _context.Set<CurrencyHistory>().Include(i => i.User).ToListAsync();
        }
    }
}
