using LedgerAPI.Contract.Interfaces;
using LedgerAPI.Contract.Model;
using static LedgerAPI.Contract.Enum.Enums;
using LedgerAPI.Contract.Dtos;

namespace LedgerAPI.Provider.Services
{
    public class LedgerService : ILedgerService
    {
        private decimal GetDifference(List<LedgerDto> ledgerList)
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;
            foreach (var ledger in ledgerList)
            {
                totalCredit += ledger.Credit != null ? Convert.ToInt32(ledger.Credit) : 0;
                totalDebit += ledger.Debit != null ? Convert.ToInt32(ledger.Debit) : 0;
            }
            return totalDebit - totalCredit;
        }
        public Ledger AddLedger(AddLedgerDto addLedgerDto)
        {
            // creating a variable that holds where we have to set the value
            bool credit = false;

            // checking whether we have to store it in credit or not
            if (addLedgerDto.EntityRefType == EntityRefType.Purchase || addLedgerDto.EntityRefType == EntityRefType.Received)
            {
                credit = true;
            }

            // creating a new ledger model
            var ledgerModel = new Ledger
            {
                CreatedAt = DateTime.Now,
                EntityRefType = addLedgerDto.EntityRefType,
                EntityRefId = addLedgerDto.EntityRefId,
                RefType = addLedgerDto.RefType,
                RefId = addLedgerDto.RefId,
                Particulars = $"By {addLedgerDto.EntityRefType.ToString()}",
                Debit = credit ? null : addLedgerDto.Amount,
                Credit = credit ? addLedgerDto.Amount : null,
            };
            return ledgerModel;
        }
        public ShowLedgerDto ShowLedger(List<LedgerDto> open, List<LedgerDto> close)
        {
            var ledgers = new ShowLedgerDto();
            var ledgerDto = new LedgerDto();
            // getting difference for open list
            decimal difference = GetDifference(open);

            // assigning value accordingly
            if (difference > 0)
            {
                ledgerDto.Debit = difference;
            }
            else if (difference < 0)
            {
                ledgerDto.Credit = Math.Abs(difference);
            }
            else
            {
                ledgerDto.Debit = 0;
                ledgerDto.Credit = 0;
            }
            // adding ledger to close list
            close.Add(ledgerDto);

            // getting difference for close list
            difference = GetDifference(close);

            // assigning close list to dto we are sending in response
            ledgers.ledgers = close;

            // assiging value accordingly
            if (difference > 0)
            {
                ledgers.Debit = difference;
            }
            else if (difference < 0)
            {
                ledgers.Credit = Math.Abs(difference);
            }
            else
            {
                ledgers.Debit = 0;
                ledgers.Credit = 0;
            }
            return ledgers;
        }
    }
}
