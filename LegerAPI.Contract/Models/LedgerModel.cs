using Ledger.Contract.Enums;

namespace Ledger.Contract.Models
{
    public class LedgerModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public EntityRefType EntityRefType { get; set; }
        public int EntityRefId { get; set; }
        public RefType RefType { get; set; }
        public int RefId { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public string Perticulars { get; set; } = string.Empty;

    }
}
