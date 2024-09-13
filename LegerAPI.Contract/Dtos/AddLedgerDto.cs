using Ledger.Contract.Enums;

namespace Ledger.Contract.Dtos
{
    public class AddLedgerDto
    {
        public EntityRefType EntityRefType { get; set; }
        public int EntityRefId { get; set; }
        public RefType RefType { get; set; }
        public int RefId { get; set; }
        public decimal Amount { get; set; }
    }
}
