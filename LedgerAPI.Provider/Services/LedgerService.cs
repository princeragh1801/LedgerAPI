using Ledger.Contract.Dtos;
using Ledger.Contract.Enums;
using Ledger.Contract.Interfaces;
using Ledger.Contract.Models;

namespace Ledger.Provider.Services
{
    public class LedgerService : ILedgerService
    {
        public LedgerModel AddLedger(AddLedgerDto addLedgerDto)
        {
            // creating a variable that holds where we have to set the value either in debit or credit
            var credit = IsCredit(addLedgerDto.EntityRefType);

            // creating a new ledger model
            var ledgerModel = new LedgerModel
            {
                CreatedAt = DateTime.Now,
                EntityRefType = addLedgerDto.EntityRefType,
                EntityRefId = addLedgerDto.EntityRefId,
                RefType = addLedgerDto.RefType,
                RefId = addLedgerDto.RefId,
                Perticulars = $"By {addLedgerDto.EntityRefType.ToString()}",
                Debit = credit ? null : addLedgerDto.Amount,
                Credit = credit ? addLedgerDto.Amount : null,
            };
            return ledgerModel;
        }
        public EntryDto ShowLedger(List<LedgerDto> ledgers, decimal? previousDebit, decimal? previousCredit)
        {
            var entry = new EntryDto();
            if (ledgers != null && ledgers.Count > 0)
            {
                var ledgerDto = new LedgerDto
                {
                    CreatedAt = ledgers.OrderBy(x => x.CreatedAt).Select(x => x.CreatedAt).FirstOrDefault().Value.AddDays(-1),
                    Perticulars = "Opening Balance"
                };
                // getting difference for open list
                decimal? difference = previousDebit - previousCredit;

                // assigning value accordingly
                if (difference > 0)
                {
                    ledgerDto.Debit = difference;
                }
                else if (difference < 0)
                {
                    ledgerDto.Credit = Math.Abs(difference.Value);
                }
                else
                {
                    ledgerDto.Debit = 0;
                    ledgerDto.Credit = 0;
                }
                // adding ledger to close list
                ledgers.Add(ledgerDto);
                ledgers = ledgers.OrderBy(x => x.CreatedAt).ToList();

                // getting difference for close list
                difference = GetDifference(ledgers);

                // assigning close list to dto we are sending in response
                entry.Ledgers = ledgers;

                // assiging value accordingly
                if (difference > 0)
                {
                    entry.Debit = difference;
                }
                else if (difference < 0)
                {
                    entry.Credit = Math.Abs(difference.Value);
                }
                else
                {
                    entry.Debit = 0;
                    entry.Credit = 0;
                }
            }
            return entry;
        }

        #region Helpers
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
        
        private bool IsCredit(EntityRefType type)
        {
            switch (type)
            {
                case EntityRefType.Received:
                case EntityRefType.Purchase:
                        return true;
                default:
                    return false;
            }
        }
        #endregion
    }
}
