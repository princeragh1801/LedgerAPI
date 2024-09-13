using LedgerAPI.Contract.Dtos;
using LedgerAPI.Contract.Model;

namespace LedgerAPI.Contract.Interfaces
{
    public interface ILedgerService
    {
        public Ledger AddLedger(AddLedgerDto addLedgerDto);

        public ShowLedgerDto ShowLedger(List<LedgerDto> open, List<LedgerDto> close);
    }
}
