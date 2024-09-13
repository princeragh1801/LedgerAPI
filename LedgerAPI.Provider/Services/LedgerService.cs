using LegerAPI.Contract.Dtos;
using LegerAPI.Contract.Interfaces;
using LegerAPI.Contract.Model;

namespace LedgerAPI.Provider.Services
{
    public class LedgerService : ILedgerService
    {
        public Ledger AddLedger(AddLedgerDto addLedgerDto)
        {
            var ledgerModel = new Ledger();
            return ledgerModel;
        }

        public ShowLedgerDto ShowLedger(List<LedgerDto> open, List<LedgerDto> close)
        {
            var ledgers = new ShowLedgerDto();
            return ledgers;
        }
    }
}
