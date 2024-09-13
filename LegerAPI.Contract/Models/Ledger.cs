using static LegerAPI.Contract.Enum.Enums;

namespace LegerAPI.Contract.Model
{
    public class Ledger
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public EntityRefType EntityRefType { get; set; }
        public int EntityRefId { get; set; }
        public RefType RefType { get; set; }
        public int RefId { get; set; }
        public decimal ? Debit { get; set; }
        public decimal ? Credit { get; set; }
        public string Particulars   { get; set; } = string.Empty;

    }
}
