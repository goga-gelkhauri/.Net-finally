using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        ICurrencyRepository currencyRepository { get; }
        ICurrencyHistoryRepository currencyHistoryRepository { get; }
        void Commit();
        void Rollback();
    }
}
