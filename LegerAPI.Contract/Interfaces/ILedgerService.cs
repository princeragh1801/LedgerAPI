using Ledger.Contract.Dtos;
using Ledger.Contract.Models;

namespace Ledger.Contract.Interfaces
{
    public interface ILedgerService
    {
        public LedgerModel AddLedger(AddLedgerDto addLedgerDto);

        public EntryDto ShowLedger(List<LedgerDto> ledgers, decimal? previousDebit, decimal? previousCredit);
    }
}
