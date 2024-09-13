using LegerAPI.Contract.Dtos;
using LegerAPI.Contract.Model;

namespace LegerAPI.Contract.Interfaces
{
    public interface ILedgerService
    {
        public Ledger AddLedger(AddLedgerDto addLedgerDto);

        public ShowLedgerDto ShowLedger(List<LedgerDto> open, List<LedgerDto> close);
    }
}
